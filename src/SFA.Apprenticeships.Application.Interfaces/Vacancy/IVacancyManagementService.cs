namespace SFA.Apprenticeships.Application.Interfaces.Vacancy
{
    using System.Threading.Tasks;
    using Domain.Entities.Raa.Vacancies;
    using Service;

    public interface IVacancyManagementService
    {
        IServiceResult Delete(int vacancyId);
        IServiceResult<VacancySummary> FindSummary(int vacancyId);
        IServiceResult<VacancySummary> FindSummaryByReferenceNumber(int vacancyReferenceNumber);
        Task<IServiceResult<WageUpdate>> EditWage(WageUpdate wageUpdate, int vacancyReferenceNumber);
    }
}