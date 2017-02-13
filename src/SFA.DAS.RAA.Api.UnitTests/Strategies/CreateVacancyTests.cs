namespace SFA.DAS.RAA.Api.UnitTests.Strategies
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security;
    using Api.Strategies;
    using Apprenticeships.Application.Employer.Strategies;
    using Apprenticeships.Application.Location.Strategies;
    using Apprenticeships.Application.Provider.Strategies;
    using Apprenticeships.Domain.Entities.Exceptions;
    using Apprenticeships.Domain.Entities.Raa.Locations;
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
        private readonly Mock<IGetByIdStrategy> _getEmployerByIdStrategy = new Mock<IGetByIdStrategy>();
        private readonly Mock<IGetByEdsUrnStrategy> _getEmployerByEdsUrnStrategy = new Mock<IGetByEdsUrnStrategy>();
        private readonly Mock<IPostalAddressStrategy> _postalAddressStrategy = new Mock<IPostalAddressStrategy>();

        private ICreateVacancyStrategy _createVacancyStrategy;

        private Employer _employer;
        private VacancyOwnerRelationship _vorOwned;
        private PostalAddress _coventry = new PostalAddress
        {
            AddressLine1 = "Address Line 1",
            Town = "Coventry",
            Postcode = "CV1 2WT",
            GeoPoint = new GeoPoint
            {
                Longitude = 1.1,
                Latitude = 2.2
            }
        };

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            var sfaProvider = new Fixture().Build<Provider>()
                .With(p => p.ProviderId, RaaApiUserFactory.SkillsFundingAgencyProviderId)
                .With(p => p.Ukprn, RaaApiUserFactory.SkillsFundingAgencyUkprn.ToString())
                .Create();

            _providerReadRepository.Setup(r => r.GetByUkprn(RaaApiUserFactory.SkillsFundingAgencyUkprn.ToString(), false)).Returns(sfaProvider);

            _vorOwned = new Fixture().Build<VacancyOwnerRelationship>()
                .With(vor => vor.VacancyOwnerRelationshipId, VorIdOwned)
                .With(vor => vor.ProviderSiteId, VorIdOwned)
                .With(vor => vor.EmployerId, 42)
                .Create();

            var vorNotOwned = new Fixture().Build<VacancyOwnerRelationship>()
                .With(vor => vor.VacancyOwnerRelationshipId, VorIdNotOwned)
                .With(vor => vor.ProviderSiteId, VorIdNotOwned)
                .With(vor => vor.EmployerId, 43)
                .Create();

            _vacancyOwnerRelationshipReadRepository.Setup(
                vor => vor.GetByIds(It.Is<IEnumerable<int>>(ids => ids.Any(id => id == VorIdOwned)), true)).Returns(new[] { _vorOwned });

            _vacancyOwnerRelationshipReadRepository.Setup(
                vor => vor.GetByIds(It.Is<IEnumerable<int>>(ids => ids.Any(id => id == VorIdNotOwned)), true)).Returns(new[] { vorNotOwned });

            var ownedProviderSite = new Fixture().Build<ProviderSite>()
                .With(ps => ps.ProviderSiteId, _vorOwned.ProviderSiteId)
                .Create();

            var providerSiteRelationship = new Fixture().Build<ProviderSiteRelationship>()
                .With(psr => psr.ProviderId, RaaApiUserFactory.SkillsFundingAgencyProviderId)
                .With(psr => psr.ProviderSiteId, ownedProviderSite.ProviderSiteId)
                .With(psr => psr.ProviderSiteRelationShipTypeId, ProviderSiteRelationshipTypes.Owner)
                .Create();

            ownedProviderSite.ProviderSiteRelationships = new List<ProviderSiteRelationship> { providerSiteRelationship };

            _getOwnedProviderSitesStrategy.Setup(ps => ps.GetOwnedProviderSites(RaaApiUserFactory.SkillsFundingAgencyProviderId)).Returns(new[] { ownedProviderSite });

            _employer = new Fixture().Build<Employer>()
                .With(e => e.EmployerId, _vorOwned.EmployerId)
                .With(e => e.EdsUrn, "123456")
                .Create();

            var vorNotOwnedEmployer = new Fixture().Build<Employer>()
                .With(e => e.EmployerId, vorNotOwned.EmployerId)
                .With(e => e.EdsUrn, "654321")
                .Create();

            _getEmployerByIdStrategy.Setup(r => r.Get(_vorOwned.EmployerId, true)).Returns(_employer);
            _getEmployerByEdsUrnStrategy.Setup(r => r.Get(_employer.EdsUrn)).Returns(_employer);

            _getEmployerByIdStrategy.Setup(r => r.Get(vorNotOwned.EmployerId, true)).Returns(vorNotOwnedEmployer);
            _getEmployerByEdsUrnStrategy.Setup(r => r.Get(vorNotOwnedEmployer.EdsUrn)).Returns(vorNotOwnedEmployer);

            _postalAddressStrategy.Setup(
                s => s.GetPostalAddress(It.IsAny<PostalAddress>())).Throws(new CustomException("", Apprenticeships.Infrastructure.Postcode.ErrorCodes.PostalAddressGeocodeFailed));

            _postalAddressStrategy.Setup(
                s => s.GetPostalAddress(It.Is<PostalAddress>(a => a.Postcode == _coventry.Postcode))).Returns(_coventry);

            _createVacancyStrategy = new CreateVacancyStrategy(_vacancyReadRepository.Object, _vacancyWriteRepository.Object, _providerReadRepository.Object, _vacancyOwnerRelationshipReadRepository.Object, _getOwnedProviderSitesStrategy.Object, _referenceNumberRepository.Object, _getEmployerByIdStrategy.Object, _getEmployerByEdsUrnStrategy.Object, _postalAddressStrategy.Object);
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
        
        [TestCase(VacancyLocationType.SpecificLocation, true)]
        [TestCase(VacancyLocationType.MultipleLocations, true)]
        [TestCase(VacancyLocationType.Nationwide, true)]
        public void CreatingVacancyAssignsEmployerAddress(VacancyLocationType vacancyLocationType, bool useEmployerAddress)
        {
            var vacancy = new Vacancy
            {
                VacancyGuid = Guid.NewGuid(),
                VacancyOwnerRelationshipId = VorIdOwned,
                VacancyLocationType = vacancyLocationType,
                NumberOfPositions = 2,
                EmployerWebsiteUrl = "http://different.com",
                EmployerDescription = "Different",
                VacancyLocations = vacancyLocationType == VacancyLocationType.MultipleLocations ? new List<VacancyLocation>
                {
                    new VacancyLocation
                    {
                        Address = new PostalAddress
                        {
                            AddressLine1 = "Address Line 1",
                            Town = "Town",
                            Postcode = "CV1 2WT"
                        },
                        NumberOfPositions = 2
                    },
                    new VacancyLocation
                    {
                        Address = new PostalAddress
                        {
                            AddressLine1 = "Address Line 1",
                            Town = "Town",
                            Postcode = "CV1 2WT"
                        },
                        NumberOfPositions = 2
                    }
                } : null
            };

            const int newVacancyId = 356;
            const int newVacancyReferenceNumber = 34534;

            _referenceNumberRepository.Setup(r => r.GetNextVacancyReferenceNumber()).Returns(newVacancyReferenceNumber);
            _vacancyWriteRepository.Setup(r => r.Create(vacancy)).Returns<Vacancy>(v => { v.VacancyId = newVacancyId; return v; });

            var createdVacancy = _createVacancyStrategy.CreateVacancy(vacancy, RaaApiUserFactory.SkillsFundingAgencyUkprn.ToString());

            if (useEmployerAddress)
            {
                createdVacancy.Address.Equals(_employer.Address).Should().BeTrue();
            }
            else
            {
                createdVacancy.Address.Should().BeNull();
            }

            createdVacancy.EmployerWebsiteUrl.Should().Be(vacancy.EmployerWebsiteUrl);
            createdVacancy.EmployerDescription.Should().Be(vacancy.EmployerDescription);
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
            createdVacancy.EmployerWebsiteUrl.Should().Be(_vorOwned.EmployerWebsiteUrl);
            createdVacancy.EmployerDescription.Should().Be(_vorOwned.EmployerDescription);
            //TODO: Check created date?
        }

        [TestCase(VacancySource.Unknown)]
        [TestCase(VacancySource.Av)]
        [TestCase(VacancySource.LegacyApi)]
        [TestCase(VacancySource.Raa)]
        [TestCase(VacancySource.Api)]
        public void CreatingVacancyHonorsSource(VacancySource vacancySource)
        {
            var vacancy = new Vacancy
            {
                VacancyGuid = Guid.NewGuid(),
                VacancyOwnerRelationshipId = VorIdOwned,
                VacancyLocationType = VacancyLocationType.SpecificLocation,
                NumberOfPositions = 2,
                VacancySource = vacancySource
            };

            const int newVacancyId = 356;
            const int newVacancyReferenceNumber = 34534;

            _referenceNumberRepository.Setup(r => r.GetNextVacancyReferenceNumber()).Returns(newVacancyReferenceNumber);
            _vacancyWriteRepository.Setup(r => r.Create(vacancy)).Returns<Vacancy>(v => { v.VacancyId = newVacancyId; return v; });

            var createdVacancy = _createVacancyStrategy.CreateVacancy(vacancy, RaaApiUserFactory.SkillsFundingAgencyUkprn.ToString());

            if (vacancySource == VacancySource.Raa)
            {
                createdVacancy.VacancySource.Should().Be(VacancySource.Raa);
            }
            else
            {
                createdVacancy.VacancySource.Should().Be(VacancySource.Api);
            }
        }

        [Test]
        public void MultipleLocationsAreGeocoded()
        {
            var vacancy = new Vacancy
            {
                VacancyGuid = Guid.NewGuid(),
                VacancyOwnerRelationshipId = VorIdOwned,
                VacancyLocationType = VacancyLocationType.MultipleLocations,
                NumberOfPositions = 2,
                EmployerWebsiteUrl = "http://different.com",
                EmployerDescription = "Different",
                VacancyLocations = new List<VacancyLocation>
                {
                    new VacancyLocation
                    {
                        Address = new PostalAddress
                        {
                            AddressLine1 = "Address Line 1",
                            Town = "Town",
                            Postcode = "CV1 2WT"
                        },
                        NumberOfPositions = 2
                    },
                    new VacancyLocation
                    {
                        Address = new PostalAddress
                        {
                            AddressLine1 = "Address Line 1",
                            Town = "Town",
                            Postcode = "CV1 2WT"
                        },
                        NumberOfPositions = 2
                    }
                }
            };

            const int newVacancyId = 356;
            const int newVacancyReferenceNumber = 34534;

            _referenceNumberRepository.Setup(r => r.GetNextVacancyReferenceNumber()).Returns(newVacancyReferenceNumber);
            _vacancyWriteRepository.Setup(r => r.Create(vacancy)).Returns<Vacancy>(v => { v.VacancyId = newVacancyId; return v; });

            var createdVacancy = _createVacancyStrategy.CreateVacancy(vacancy, RaaApiUserFactory.SkillsFundingAgencyUkprn.ToString());

            createdVacancy.VacancyLocations[0].Address.GeoPoint.Should().NotBeNull();
            createdVacancy.VacancyLocations[0].Address.GeoPoint.Longitude.Should().Be(_coventry.GeoPoint.Longitude);
            createdVacancy.VacancyLocations[0].Address.GeoPoint.Latitude.Should().Be(_coventry.GeoPoint.Latitude);
        }

        [Test]
        public void MultipleLocationsAreValidated()
        {
            var vacancy = new Vacancy
            {
                VacancyGuid = Guid.NewGuid(),
                VacancyOwnerRelationshipId = VorIdOwned,
                VacancyLocationType = VacancyLocationType.MultipleLocations,
                NumberOfPositions = 2,
                EmployerWebsiteUrl = "http://different.com",
                EmployerDescription = "Different",
                VacancyLocations = new List<VacancyLocation>
                {
                    new VacancyLocation
                    {
                        Address = new PostalAddress
                        {
                            AddressLine1 = "Address Line 1",
                            Town = "Town",
                            Postcode = "CV1 2ZZ"
                        },
                        NumberOfPositions = 2
                    },
                    new VacancyLocation
                    {
                        Address = new PostalAddress
                        {
                            AddressLine1 = "Address Line 1",
                            Town = "Town",
                            Postcode = "CV1 2WT"
                        },
                        NumberOfPositions = 2
                    }
                }
            };

            Action action = () => _createVacancyStrategy.CreateVacancy(vacancy, RaaApiUserFactory.SkillsFundingAgencyUkprn.ToString());
            action.ShouldThrow<ValidationException>()
                .And.Errors.Any(e => e.PropertyName == "VacancyLocations[0].Address.Postcode" && e.ErrorMessage == "The supplied postcode has not been recognized. Please supply a valid postcode.").Should().BeTrue();
        }

        [Test]
        public void MultipleLocationsSingleUsesAddress()
        {
            var vacancy = new Vacancy
            {
                VacancyGuid = Guid.NewGuid(),
                VacancyOwnerRelationshipId = VorIdOwned,
                VacancyLocationType = VacancyLocationType.MultipleLocations,
                NumberOfPositions = 2,
                EmployerWebsiteUrl = "http://different.com",
                EmployerDescription = "Different",
                VacancyLocations = new List<VacancyLocation>
                {
                    new VacancyLocation
                    {
                        Address = new PostalAddress
                        {
                            AddressLine1 = "Address Line 1",
                            Town = "Town",
                            Postcode = "CV1 2WT"
                        },
                        NumberOfPositions = 3
                    }
                }
            };

            const int newVacancyId = 356;
            const int newVacancyReferenceNumber = 34534;

            _referenceNumberRepository.Setup(r => r.GetNextVacancyReferenceNumber()).Returns(newVacancyReferenceNumber);
            _vacancyWriteRepository.Setup(r => r.Create(vacancy)).Returns<Vacancy>(v => { v.VacancyId = newVacancyId; return v; });

            var createdVacancy = _createVacancyStrategy.CreateVacancy(vacancy, RaaApiUserFactory.SkillsFundingAgencyUkprn.ToString());

            createdVacancy.VacancyLocations.Should().BeNullOrEmpty();
            createdVacancy.Address.AddressLine1.Should().Be(_coventry.AddressLine1);
            createdVacancy.Address.Town.Should().Be(_coventry.Town);
            createdVacancy.Address.Postcode.Should().Be(_coventry.Postcode);
            createdVacancy.Address.GeoPoint.Longitude.Should().Be(_coventry.GeoPoint.Longitude);
            createdVacancy.Address.GeoPoint.Latitude.Should().Be(_coventry.GeoPoint.Latitude);
            createdVacancy.NumberOfPositions.Should().Be(3);
        }
    }
}