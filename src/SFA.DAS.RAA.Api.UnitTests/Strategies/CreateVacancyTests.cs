namespace SFA.DAS.RAA.Api.UnitTests.Strategies
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Api.Strategies;
    using Apprenticeships.Domain.Entities.Raa.Parties;
    using Apprenticeships.Domain.Entities.Raa.Vacancies;
    using Apprenticeships.Domain.Raa.Interfaces.Repositories;
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

        private readonly Mock<IVacancyOwnerRelationshipReadRepository> _vacancyOwnerRelationshipReadRepository = new Mock<IVacancyOwnerRelationshipReadRepository>();
        private readonly Mock<IProviderSiteReadRepository> _providerSiteReadRepository = new Mock<IProviderSiteReadRepository>();

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            var vorOwned = new Fixture().Build<VacancyOwnerRelationship>()
                .With(vor => vor.VacancyOwnerRelationshipId, VorIdOwned)
                .Create();

            var vorNotOwned = new Fixture().Build<VacancyOwnerRelationship>()
                .With(vor => vor.VacancyOwnerRelationshipId, VorIdNotOwned)
                .Create();

            _vacancyOwnerRelationshipReadRepository.Setup(
                vor => vor.GetByIds(It.Is<IEnumerable<int>>(ids => ids.Any(id => id == VorIdOwned)), true)).Returns(new[] { vorOwned });

            _vacancyOwnerRelationshipReadRepository.Setup(
                vor => vor.GetByIds(It.Is<IEnumerable<int>>(ids => ids.Any(id => id == VorIdNotOwned)), true)).Returns(new[] { vorNotOwned });
        }

        [Test]
        public void VacancyGuidCannotBeReused()
        {
            var vacancy = new Vacancy
            {
                VacancyGuid = Guid.NewGuid(),
                VacancyOwnerRelationshipId = VorIdOwned
            };

            var strategy = new CreateVacancyStrategy(_vacancyOwnerRelationshipReadRepository.Object, _providerSiteReadRepository.Object);

            //First call should be OK
            strategy.CreateVacancy(vacancy);
            //Second should throw an exception
            Action action = () => strategy.CreateVacancy(vacancy);
            action.ShouldThrow<ValidationException>().WithMessage("Something about duplicate GUIDs");
        }

        [Test]
        public void VacancyOwnerRelationshipIdMustExist()
        {
            var vacancy = new Vacancy
            {
                VacancyGuid = Guid.NewGuid(),
                VacancyOwnerRelationshipId = VorIdNotFound
            };

            var strategy = new CreateVacancyStrategy(_vacancyOwnerRelationshipReadRepository.Object, _providerSiteReadRepository.Object);

            Action action = () => strategy.CreateVacancy(vacancy);
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

            var strategy = new CreateVacancyStrategy(_vacancyOwnerRelationshipReadRepository.Object, _providerSiteReadRepository.Object);

            Action action = () => strategy.CreateVacancy(vacancy);
            action.ShouldThrow<ValidationException>()
                .And.Errors.Any(e => e.PropertyName == "VacancyOwnerRelationshipId" && e.ErrorMessage == "Please supply a valid vacancy owner relationship id. This must exist and be associated with a provider site your API key has access to.").Should().BeTrue();
        }
    }
}