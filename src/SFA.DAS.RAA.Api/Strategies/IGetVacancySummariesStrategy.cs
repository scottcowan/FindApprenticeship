using System.Threading.Tasks;
using SFA.Apprenticeships.Domain.Entities.Raa.Vacancies;

namespace SFA.DAS.RAA.Api.Strategies
{
    using Apprenticeships.Domain.Raa.Interfaces.Repositories.Models;
    using Models;

    public interface IGetVacancySummariesStrategy
    {
        Task<ListWithTotalCount<VacancySummary>> GetVacancySummaries(string ukprn, string searchString,
            VacanciesSummaryFilterTypes filterType, VacancySearchMode searchMode, VacancyType vacancyType, Order order,
            VacancySummaryOrderByColumn orderBy, int page, int pageSize);
    }
}