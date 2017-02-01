namespace SFA.Apprenticeships.Web.Raa.Common.Providers
{
    using System.Threading.Tasks;
    using Application.Interfaces.Service;
    using Application.Interfaces.Vacancy;
    using Domain.Entities.Raa.Vacancies;
    using ViewModels.VacancyManagement;

    public class VacancyManagementProvider : IVacancyManagementProvider
    {
        private readonly IVacancyManagementService _vacancyManagementService;

        public VacancyManagementProvider(IVacancyManagementService vacancyManagementService)
        {
            _vacancyManagementService = vacancyManagementService;
        }

        public IServiceResult Delete(int vacancyId)
        {
            return new ServiceResult(_vacancyManagementService.Delete(vacancyId).Code);
        }

        public IServiceResult<VacancySummary> FindSummary(int vacancyId)
        {
            return _vacancyManagementService.FindSummary(vacancyId);
        }

        public IServiceResult<VacancySummary> FindSummaryByReferenceNumber(int vacancyReferenceNumber)
        {
            return _vacancyManagementService.FindSummaryByReferenceNumber(vacancyReferenceNumber);
        }

        public async Task<IServiceResult<EditWageViewModel>> EditWage(EditWageViewModel editWageViewModel)
        {
            var serviceResult = await _vacancyManagementService.EditWage(editWageViewModel, editWageViewModel.VacancyReferenceNumber);
            return new ServiceResult<EditWageViewModel>(serviceResult.Code, editWageViewModel);
        }
    }
}