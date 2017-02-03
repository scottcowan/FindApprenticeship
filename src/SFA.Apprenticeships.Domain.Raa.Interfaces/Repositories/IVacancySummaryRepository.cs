namespace SFA.Apprenticeships.Domain.Raa.Interfaces.Repositories
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Entities.Raa.Vacancies;
    using Models;
    using Queries;

    public interface IVacancySummaryRepository
    {
        IList<VacancySummary> GetSummariesForProvider(VacancySummaryQuery query, out int totalRecords);
        VacancyCounts GetLotteryCounts(VacancySummaryQuery query);
        IList<VacancySummary> GetByStatus(VacancySummaryByStatusQuery query, out int totalRecords);
        Task<ListWithTotalCount<VacancySummary>> GetByStatusAsync(VacancySummaryByStatusQuery query);
        IList<RegionalTeamMetrics> GetRegionalTeamMetrics(VacancySummaryByStatusQuery query);
        VacancySummary GetById(int vacancyId);
        VacancySummary GetByReferenceNumber(int vacancyReferenceNumber);
        List<VacancySummary> GetByIds(IEnumerable<int> vacancyId);
        IList<VacancySummary> Find(ApprenticeshipVacancyQuery query, out int totalRecords);
    }
}
