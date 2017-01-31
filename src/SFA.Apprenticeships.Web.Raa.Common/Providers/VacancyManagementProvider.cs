namespace SFA.Apprenticeships.Web.Raa.Common.Providers
{
    using System.Threading.Tasks;
    using Application.Interfaces.Api;
    using Application.Interfaces.Service;
    using Application.Vacancy;
    using Domain.Entities.Raa.Vacancies;
    using ViewModels.VacancyManagement;
    using WageUpdate = DAS.RAA.Api.Client.V1.Models.WageUpdate;

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
            var wageUpdate = ApiClientMappers.Map<EditWageViewModel, WageUpdate>(editWageViewModel);

            var apiClient = _apiClientProvider.GetApiClient();

            var apiVacancyResult = await apiClient.VacancyManagement.EditWageByVacancyReferenceWithHttpMessagesAsync(wageUpdate, editWageViewModel.VacancyReferenceNumber.ToString());
            if (apiVacancyResult.Response.IsSuccessStatusCode)
            {
                return new ServiceResult<EditWageViewModel>(VacancyManagementServiceCodes.EditWage.Ok, editWageViewModel);
            }

            return new ServiceResult<EditWageViewModel>(VacancyManagementServiceCodes.EditWage.Error, editWageViewModel);
        }
    }
}