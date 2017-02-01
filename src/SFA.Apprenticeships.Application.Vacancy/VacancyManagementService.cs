namespace SFA.Apprenticeships.Application.Vacancy
{
    using System.Threading.Tasks;
    using Domain.Entities.Raa.Vacancies;
    using Interfaces.Service;
    using Interfaces.Vacancy;

    public class VacancyManagementService : IVacancyManagementService
    {
        private readonly IVacancySummaryService _vacancySummaryService;
        private readonly IDeleteVacancyStrategy _deleteVacancyStrategy;

        public VacancyManagementService(IDeleteVacancyStrategy deleteVacancyStrategy,
            IVacancySummaryService vacancySummaryService)
        {
            _deleteVacancyStrategy = deleteVacancyStrategy;
            _vacancySummaryService = vacancySummaryService;
        }

        public IServiceResult Delete(int vacancyId)
        {
            var summary = _vacancySummaryService.GetById(vacancyId);
            var result = _deleteVacancyStrategy.Execute(summary);

            return new ServiceResult(result.Code);
        }

        public IServiceResult<VacancySummary> FindSummary(int vacancyId)
        {
            var vacancySummary = _vacancySummaryService.GetById(vacancyId);
            if (vacancySummary == null)
            {
                return new ServiceResult<VacancySummary>(VacancyManagementServiceCodes.FindSummary.NotFound, null);
            }

            return new ServiceResult<VacancySummary>(VacancyManagementServiceCodes.FindSummary.Ok, vacancySummary);
        }

        public IServiceResult<VacancySummary> FindSummaryByReferenceNumber(int vacancyReferenceNumber)
        {
            var vacancySummary = _vacancySummaryService.GetByReferenceNumber(vacancyReferenceNumber);
            if (vacancySummary == null)
            {
                return new ServiceResult<VacancySummary>(VacancyManagementServiceCodes.FindSummary.NotFound, null);
            }

            return new ServiceResult<VacancySummary>(VacancyManagementServiceCodes.FindSummary.Ok, vacancySummary);
        }

        public Task<IServiceResult<WageUpdate>> EditWage(WageUpdate wageUpdate, int vacancyReferenceNumber)
        {
            throw new System.NotImplementedException();
        }
    }
}