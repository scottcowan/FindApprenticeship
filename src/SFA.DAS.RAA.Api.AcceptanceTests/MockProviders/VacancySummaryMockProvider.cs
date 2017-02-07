using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.Components.DictionaryAdapter;
using Moq;
using Ploeh.AutoFixture;
using SFA.Apprenticeships.Domain.Entities.Raa.Vacancies;
using SFA.Apprenticeships.Infrastructure.Repositories.Sql.Schemas.Provider;
using SFA.Apprenticeships.Infrastructure.Repositories.Sql.Schemas.Vacancy;
using SFA.DAS.RAA.Api.AcceptanceTests.Factories;
using DbVacancySummary = SFA.Apprenticeships.Infrastructure.Repositories.Sql.Schemas.Vacancy.Entities.VacancySummary;
using DbProviderSite = SFA.Apprenticeships.Infrastructure.Repositories.Sql.Schemas.Provider.Entities.ProviderSite;
using Vacancy = SFA.Apprenticeships.Infrastructure.Repositories.Sql.Schemas.Vacancy.Entities.Vacancy;

namespace SFA.DAS.RAA.Api.AcceptanceTests.MockProviders
{
    public static class VacancySummaryMockProvider
    {
        public static object MockLock = new object();

        public static void MockAssortedVacancySummaries(int totalCount, int pageSize)
        {
            var blockSize = pageSize / 4;

            var vacancySummaries = new EditableList<DbVacancySummary>();

            for (var i = 0; i < 3; i++)
            {
                vacancySummaries.AddRange(new Fixture().Build<DbVacancySummary>()
                    .With(v => v.TotalResultCount, totalCount)
                    .With(v => v.VacancyStatusId, (VacancyStatus)(i+1))
                    .CreateMany(blockSize).ToList());
            }

            // correct the wage type
            vacancySummaries.ForEach(f => f.WageType = 2);

            RaaMockFactory.GetMockGetOpenConnection().Setup(
                        m => m.Query<DbVacancySummary>(It.Is<string>(s => s.StartsWith(VacancySummaryRepository.CoreQuery)), It.IsAny<object>(), null, null))
                    .Returns(new List<DbVacancySummary>(vacancySummaries));
        }

        public static void MockProviderSites()
        {
            RaaMockFactory.GetMockGetOpenConnection().Setup(
                    m => m.Query<DbProviderSite>(It.Is<string>(s => s.StartsWith(ProviderSiteRepository.SelectByProviderIdSql)), It.IsAny<object>(), null, null))
                .Returns(new List<DbProviderSite>()
            {
                new DbProviderSite() {ProviderSiteId = 12}
            });
        }
    }
}
