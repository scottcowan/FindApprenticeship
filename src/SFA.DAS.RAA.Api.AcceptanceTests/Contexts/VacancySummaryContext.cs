using System.Collections.Generic;
using DbVacancySummary = SFA.Apprenticeships.Infrastructure.Repositories.Sql.Schemas.Vacancy.Entities.VacancySummary;

namespace SFA.DAS.RAA.Api.AcceptanceTests.Contexts
{
    public class VacancySummaryContext
    {
        public List<DbVacancySummary> VacancySummaries { get; set; }
    }
}
