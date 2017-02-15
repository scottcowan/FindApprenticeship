namespace SFA.DAS.RAA.Api.AcceptanceTests.MockProviders
{
    using System.Collections.Generic;
    using System.Linq;
    using Apprenticeships.Infrastructure.Repositories.Sql.Schemas.dbo;
    using Apprenticeships.Infrastructure.Repositories.Sql.Schemas.dbo.Entities;
    using Apprenticeships.Infrastructure.Repositories.Sql.Schemas.Provider;
    using Apprenticeships.Infrastructure.Repositories.Sql.Schemas.Provider.Entities;
    using Apprenticeships.Infrastructure.Repositories.Sql.Schemas.Vacancy;
    using Extensions;
    using Factories;
    using Moq;
    using Ploeh.AutoFixture;
    using UnitTests.Factories;
    using DbVacancy = Apprenticeships.Infrastructure.Repositories.Sql.Schemas.Vacancy.Entities.Vacancy;
    using VacancyOwnerRelationship = Apprenticeships.Infrastructure.Repositories.Sql.Schemas.dbo.Entities.VacancyOwnerRelationship;

    public class VacancyMockProvider
    {
        private const int VorOwnedId = 42;
        private const int ProviderSiteId = 24;
        private const int EmployerId = 77;
        
        public void MockVacancyOwnerRelationships()
        {
            var vorOwned = new Fixture().Build<VacancyOwnerRelationship>()
                .With(vor => vor.VacancyOwnerRelationshipId, VorOwnedId)
                .With(vor => vor.ProviderSiteID, 24)
                .With(vor => vor.EmployerId, EmployerId)
                .Create();

            RaaMockFactory.GetMockGetOpenConnection()
                .Setup(
                    m =>
                        m.Query<VacancyOwnerRelationship>(
                            It.Is<string>(s => s.StartsWith(VacancyOwnerRelationshipRepository.SelectByIdsSql)),
                            It.Is<object>(o => o.GetPropertyValue<int[]>("VacancyOwnerRelationshipIds")[0] == VorOwnedId),
                            null, null))
                .Returns(new[] { vorOwned });
        }

        public void MockEmployer()
        {
            var employer = new Fixture().Build<Employer>()
                .With(e => e.EmployerId, EmployerId)
                .Create();

            RaaMockFactory.GetMockGetOpenConnection().Setup(
                m => m.Query<Employer>(It.Is<string>(s => s.StartsWith(EmployerRepository.BasicQuery)), It.Is<object>(o => o.GetHashCode() == new { EmployerId }.GetHashCode()), null, null))
                .Returns(new[] { employer });

            RaaMockFactory.GetMockGetOpenConnection().Setup(
                m => m.Query<Employer>(It.Is<string>(s => s.StartsWith(EmployerRepository.BasicQuery)), It.Is<object>(o => o.GetHashCode() == new { employer.EdsUrn }.GetHashCode()), null, null))
                .Returns(new[] { employer });
        }

        public void MockProviderSite(int providerSiteId)
        {
            var providerSite = new Fixture().Build<ProviderSite>()
                .With(ps => ps.ProviderSiteId, ProviderSiteId)
                .Create();

            var providerSiteRelationship = new Fixture().Build<ProviderSiteRelationship>()
                .With(psr => psr.ProviderId, RaaApiUserFactory.SkillsFundingAgencyProviderId)
                .With(psr => psr.ProviderSiteId, providerSite.ProviderSiteId)
                .With(psr => psr.ProviderSiteRelationShipTypeId, 1)
                .Create();

            RaaMockFactory.GetMockGetOpenConnection().Setup(
                m => m.Query<ProviderSite>(It.Is<string>(s => s.StartsWith(ProviderSiteRepository.SelectByProviderIdSql)), It.Is<object>(o => o.GetPropertyValue<int>("providerId") == RaaApiUserFactory.SkillsFundingAgencyProviderId), null, null))
                .Returns(new[] { providerSite });

            RaaMockFactory.GetMockGetOpenConnection().Setup(
                m => m.Query<ProviderSiteRelationship>(It.Is<string>(s => s.StartsWith(ProviderSiteRepository.SelectProviderSiteRelationshipsByProviderSiteIdsSql)), It.Is<object>(o => o.GetPropertyValue<IEnumerable<int>>("providerSiteIds").Contains(ProviderSiteId)), null, null))
                .Returns(new[] { providerSiteRelationship });
        }

        public void MockVacancyCreation()
        {
            RaaMockFactory.GetMockGetOpenConnection().Setup(
                m => m.Query<int>(ReferenceNumberRepository.GetNextVacancyReferenceNumberSql, null, null, null))
                .Returns(new[] { 450987 });

            RaaMockFactory.GetMockGetOpenConnection().Setup(m => m.Insert(It.IsAny<DbVacancy>(), null)).Returns(3453).Callback<DbVacancy, int?>(
                (v, ct) =>
                {
                    RaaMockFactory.GetMockGetOpenConnection()
                        .Setup(
                            m =>
                                m.Query<DbVacancy>(VacancyRepository.SelectByIdSql,
                                    It.Is<object>(o => o.GetHashCode() == new { vacancyId = 3453 }.GetHashCode()), null,
                                    null))
                        .Returns(new[] { v });
                });
        }
    }
}