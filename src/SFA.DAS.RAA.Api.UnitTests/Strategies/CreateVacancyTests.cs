namespace SFA.DAS.RAA.Api.UnitTests.Strategies
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security;
    using Api.Strategies;
    using Apprenticeships.Application.Provider.Strategies;
    using Apprenticeships.Domain.Entities.Raa.Parties;
    using Apprenticeships.Domain.Entities.Raa.Vacancies;
    using Apprenticeships.Domain.Interfaces.Repositories;
    using Apprenticeships.Domain.Raa.Interfaces.Repositories;
    using Factories;
    using FluentAssertions;
    using FluentValidation;
    using Moq;
    using NUnit.Framework;
    using Ploeh.AutoFixture;

    [TestFixture]
    [Parallelizable]
    public class CreateVacancyTests
    {
        private const int VorIdNotFound = 41;
        private const int VorIdOwned = 42;
        private const int VorIdNotOwned = 43;

        private readonly Mock<IVacancyReadRepository> _vacancyReadRepository = new Mock<IVacancyReadRepository>();
        private readonly Mock<IVacancyWriteRepository> _vacancyWriteRepository = new Mock<IVacancyWriteRepository>();
        private readonly Mock<IProviderReadRepository> _providerReadRepository = new Mock<IProviderReadRepository>();
        private readonly Mock<IVacancyOwnerRelationshipReadRepository> _vacancyOwnerRelationshipReadRepository = new Mock<IVacancyOwnerRelationshipReadRepository>();
        private readonly Mock<IGetOwnedProviderSitesStrategy> _getOwnedProviderSitesStrategy = new Mock<IGetOwnedProviderSitesStrategy>();
        private readonly Mock<IReferenceNumberRepository> _referenceNumberRepository = new Mock<IReferenceNumberRepository>();

        private ICreateVacancyStrategy _createVacancyStrategy;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            var sfaProvider = new Fixture().Build<Provider>()
                .With(p => p.ProviderId, RaaApiUserFactory.SkillsFundingAgencyProviderId)
                .With(p => p.Ukprn, RaaApiUserFactory.SkillsFundingAgencyUkprn.ToString())
                .Create();

            _providerReadRepository.Setup(r => r.GetByUkprn(RaaApiUserFactory.SkillsFundingAgencyUkprn.ToString(), false)).Returns(sfaProvider);

            var vorOwned = new Fixture().Build<VacancyOwnerRelationship>()
                .With(vor => vor.VacancyOwnerRelationshipId, VorIdOwned)
                .With(vor => vor.ProviderSiteId, VorIdOwned)
                .Create();

            var vorNotOwned = new Fixture().Build<VacancyOwnerRelationship>()
                .With(vor => vor.VacancyOwnerRelationshipId, VorIdNotOwned)
                .With(vor => vor.ProviderSiteId, VorIdNotOwned)
                .Create();

            _vacancyOwnerRelationshipReadRepository.Setup(
                vor => vor.GetByIds(It.Is<IEnumerable<int>>(ids => ids.Any(id => id == VorIdOwned)), true)).Returns(new[] { vorOwned });

            _vacancyOwnerRelationshipReadRepository.Setup(
                vor => vor.GetByIds(It.Is<IEnumerable<int>>(ids => ids.Any(id => id == VorIdNotOwned)), true)).Returns(new[] { vorNotOwned });

            var ownedProviderSite = new Fixture().Build<ProviderSite>()
                .With(ps => ps.ProviderSiteId, vorOwned.ProviderSiteId)
                .Create();

            var providerSiteRelationship = new Fixture().Build<ProviderSiteRelationship>()
                .With(psr => psr.ProviderId, RaaApiUserFactory.SkillsFundingAgencyProviderId)
                .With(psr => psr.ProviderSiteId, ownedProviderSite.ProviderSiteId)
                .With(psr => psr.ProviderSiteRelationShipTypeId, ProviderSiteRelationshipTypes.Owner)
                .Create();

            ownedProviderSite.ProviderSiteRelationships = new List<ProviderSiteRelationship> { providerSiteRelationship };

            _getOwnedProviderSitesStrategy.Setup(ps => ps.GetOwnedProviderSites(RaaApiUserFactory.SkillsFundingAgencyProviderId)).Returns(new[] { ownedProviderSite });

            _createVacancyStrategy = new CreateVacancyStrategy(_vacancyReadRepository.Object, _vacancyWriteRepository.Object, _providerReadRepository.Object, _vacancyOwnerRelationshipReadRepository.Object, _getOwnedProviderSitesStrategy.Object, _referenceNumberRepository.Object);
        }

        [Test]
        public void UkprnMustBeValid()
        {
            var vacancy = new Vacancy
            {
                VacancyGuid = Guid.NewGuid(),
                VacancyOwnerRelationshipId = VorIdOwned
            };

            Action action = () => _createVacancyStrategy.CreateVacancy(vacancy, "100000");
            action.ShouldThrow<SecurityException>().WithMessage("You do not have permission to create a vacancy for specified provider.");
        }

        [Test]
        public void VacancyGuidCannotBeReused()
        {
            var vacancy = new Vacancy
            {
                VacancyGuid = Guid.NewGuid(),
                VacancyOwnerRelationshipId = VorIdOwned
            };

            _vacancyReadRepository.Setup(r => r.GetByVacancyGuid(vacancy.VacancyGuid)).Returns(vacancy);

            Action action = () => _createVacancyStrategy.CreateVacancy(vacancy, RaaApiUserFactory.SkillsFundingAgencyUkprn.ToString());
            action.ShouldThrow<ValidationException>()
                .And.Errors.Any(e => e.PropertyName == "VacancyGuid" && e.ErrorMessage == "The supplied guid has been used to create a vacancy before. Please supply a unique guid.").Should().BeTrue();
        }

        [Test]
        public void VacancyOwnerRelationshipIdMustExist()
        {
            var vacancy = new Vacancy
            {
                VacancyGuid = Guid.NewGuid(),
                VacancyOwnerRelationshipId = VorIdNotFound
            };

            Action action = () => _createVacancyStrategy.CreateVacancy(vacancy, RaaApiUserFactory.SkillsFundingAgencyUkprn.ToString());
            action.ShouldThrow<ValidationException>()
                .And.Errors.Any(e => e.PropertyName == "VacancyOwnerRelationshipId" && e.ErrorMessage == "Please supply a valid vacancy owner relationship id. This must exist and be associated with a provider site your API key has access to.").Should().BeTrue();
        }

        [Test]
        public void VacancyOwnerRelationshipIdMustBeOwned()
        {
            var vacancy = new Vacancy
            {
                VacancyGuid = Guid.NewGuid(),
                VacancyOwnerRelationshipId = VorIdNotOwned
            };

            Action action = () => _createVacancyStrategy.CreateVacancy(vacancy, RaaApiUserFactory.SkillsFundingAgencyUkprn.ToString());
            action.ShouldThrow<ValidationException>()
                .And.Errors.Any(e => e.PropertyName == "VacancyOwnerRelationshipId" && e.ErrorMessage == "You do not have permission to create a vacancy for the specified vacancy owner relationship.").Should().BeTrue();
        }

        [Test]
        public void CreatingVacancyAutoPopulatesFields()
        {
            var vacancy = new Vacancy
            {
                VacancyGuid = Guid.NewGuid(),
                VacancyOwnerRelationshipId = VorIdOwned,
                VacancyLocationType = VacancyLocationType.SpecificLocation,
                NumberOfPositions = 2
            };

            const int newVacancyId = 356;
            const int newVacancyReferenceNumber = 34534;

            _referenceNumberRepository.Setup(r => r.GetNextVacancyReferenceNumber()).Returns(newVacancyReferenceNumber);
            _vacancyWriteRepository.Setup(r => r.Create(vacancy)).Returns<Vacancy>(v => { v.VacancyId = newVacancyId; return v; });

            var createdVacancy = _createVacancyStrategy.CreateVacancy(vacancy, RaaApiUserFactory.SkillsFundingAgencyUkprn.ToString());

            createdVacancy.VacancyId.Should().Be(newVacancyId);
            createdVacancy.VacancyReferenceNumber.Should().Be(newVacancyReferenceNumber);
            createdVacancy.Status.Should().Be(VacancyStatus.Draft);
            createdVacancy.ContractOwnerId.Should().Be(RaaApiUserFactory.SkillsFundingAgencyProviderId);
            createdVacancy.OriginalContractOwnerId.Should().Be(RaaApiUserFactory.SkillsFundingAgencyProviderId);
            createdVacancy.VacancyManagerId.Should().Be(VorIdOwned);
            createdVacancy.DeliveryOrganisationId.Should().Be(VorIdOwned);
            createdVacancy.VacancySource.Should().Be(VacancySource.Api);
            //TODO: Check created date?
        }
    }
}