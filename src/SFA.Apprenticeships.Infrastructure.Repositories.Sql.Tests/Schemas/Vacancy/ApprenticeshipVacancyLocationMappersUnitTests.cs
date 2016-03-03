﻿namespace SFA.Apprenticeships.Infrastructure.Repositories.Sql.Tests.Schemas.Vacancy
{
    using FluentAssertions;
    using NUnit.Framework;
    using Ploeh.AutoFixture;
    using Sql.Schemas.Vacancy;
    using DbVacancyLocation = Sql.Schemas.Vacancy.Entities.VacancyLocation;
    using DomainVacancyLocation = Domain.Entities.Raa.Locations.VacancyLocation;


    [TestFixture]
    public class ApprenticeshipVacancyLocationMappersUnitTests : TestBase
    {
        
        [Test]
        public void DoesVacancyLocationDomainObjectToDatabaseObjectMapperChokeInPractice()
        {
            // Arrange
            var x = new ApprenticeshipVacancyMappers();

            var vacancy =
                new Fixture().Build<DomainVacancyLocation>()
                    .Create();

            // Act / Assert no exception
            x.Map<DomainVacancyLocation, DbVacancyLocation>(vacancy);
        }

        [Test]
        public void DoesDatabaseVacancyObjectToDomainObjectMapperChokeInPractice()
        {
            // Arrange
            var mapper = new ApprenticeshipVacancyMappers();
            var databaseVacancyLocation = CreateValidDatabaseVacancyLocation();

            // Act / Assert no exception
            mapper.Map<DbVacancyLocation, DomainVacancyLocation>(databaseVacancyLocation);
        }

        [Test]
        public void DoesDatabaseVacancyObjectMappingRoundTripViaDomainObjectExcludingHardOnes()
        {
            // Arrange
            var mapper = new ApprenticeshipVacancyMappers();
            var domainVacancyLocation1 = new Fixture().Create<DomainVacancyLocation>();

            // Act

            var databaseVacancyLocation = mapper.Map<DomainVacancyLocation, DbVacancyLocation>(domainVacancyLocation1);
            var domainVacancyLocation2 = mapper.Map<DbVacancyLocation, DomainVacancyLocation>(databaseVacancyLocation);

            // Assert
            domainVacancyLocation2.ShouldBeEquivalentTo(domainVacancyLocation1, options => options
                .Excluding(vl => vl.Address.PostalAddressId)
                .Excluding(vl => vl.Address.ValidationSourceCode)
                .Excluding(vl => vl.Address.ValidationSourceKeyValue)
                .Excluding(vl => vl.Address.DateValidated)
                .Excluding(vl => vl.Address.County));
        }
        
        [Test]
        public void DoesVacancyLocationDomainObjectMappingRoundTripViaDatabaseObject()
        {
            // Arrange
            var mapper = new ApprenticeshipVacancyMappers();
            var databaseVacancyLocation1 = CreateValidDatabaseVacancyLocation();

            // Act
            var domainVacancyLocation = mapper.Map<DbVacancyLocation, DomainVacancyLocation>(databaseVacancyLocation1);
            var databaseVacancyLocation2 = mapper.Map<DomainVacancyLocation, DbVacancyLocation>(domainVacancyLocation);

            // Assert
            databaseVacancyLocation2.ShouldBeEquivalentTo(databaseVacancyLocation1, options => options
                .Excluding(vl => vl.DirectApplicationUrl)
                .Excluding(vl => vl.CountyId)
                .Excluding(vl => vl.LocalAuthorityId)
                .Excluding(vl => vl.GeocodeEasting)
                .Excluding(vl => vl.GeocodeNorthing)
                );
        }
    }
}