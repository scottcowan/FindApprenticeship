using SFA.Apprenticeships.Application.Interfaces.Service;

namespace SFA.Apprenticeships.Application.Interfaces.Vacancy
{
    using System.Collections.Generic;
    using Domain.Entities.Raa.Vacancies;
    using Domain.Raa.Interfaces.Queries;
    using Domain.Raa.Interfaces.Repositories.Models;
    using System.Threading.Tasks;

    public interface IVacancySummaryService
    {
        Task<IServiceResult<ListWithTotalCount<VacancySummary>>> GetSummariesForProvider(VacancySummaryQuery query);
        VacancyCounts GetLotteryCounts(VacancySummaryQuery query);
        IList<VacancySummary> GetWithStatus(VacancySummaryByStatusQuery query, out int totalRecords);
        IList<RegionalTeamMetrics> GetRegionalTeamMetrics(VacancySummaryByStatusQuery query);
        VacancySummary GetById(int vacancyId);
        VacancySummary GetByReferenceNumber(int vacancyReferenceNumber);
        IList<VacancySummary> GetByIds(IEnumerable<int> vacancyIds);
        IList<VacancySummary> Find(ApprenticeshipVacancyQuery query, out int resultCount);
    }
}
