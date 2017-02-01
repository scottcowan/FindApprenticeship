namespace SFA.DAS.RAA.Api.Service.V1.Vacancy
{
    using System.Threading.Tasks;
    using Apprenticeships.Application.Interfaces;
    using Apprenticeships.Application.Interfaces.Api;
    using Apprenticeships.Application.Interfaces.Service;
    using Apprenticeships.Application.Interfaces.Vacancy;
    using Apprenticeships.Application.Vacancy;
    using Apprenticeships.Domain.Entities.Raa.Vacancies;
    using Mappers;
    using ApiWageUpdate = Client.V1.Models.WageUpdate;

    public class ApiVacancyManagementService : IVacancyManagementService
    {
        private static readonly IMapper ApiClientMappers = new ApiClientMappers();

        private readonly IApiClientProvider _apiClientProvider;
        private readonly IVacancyManagementService _vacancyManagementService;

        public ApiVacancyManagementService(IApiClientProvider apiClientProvider,
            IDeleteVacancyStrategy deleteVacancyStrategy,
            IVacancySummaryService vacancySummaryService)
        {
            _apiClientProvider = apiClientProvider;
            _vacancyManagementService = new VacancyManagementService(deleteVacancyStrategy, vacancySummaryService);
        }

        public IServiceResult Delete(int vacancyId)
        {
            return _vacancyManagementService.Delete(vacancyId);
        }

        public IServiceResult<VacancySummary> FindSummary(int vacancyId)
        {
            return _vacancyManagementService.FindSummary(vacancyId);
        }

        public IServiceResult<VacancySummary> FindSummaryByReferenceNumber(int vacancyReferenceNumber)
        {
            return _vacancyManagementService.FindSummaryByReferenceNumber(vacancyReferenceNumber);
        }

        public async Task<IServiceResult<WageUpdate>> EditWage(WageUpdate wageUpdate, int vacancyReferenceNumber)
        {
            if (_apiClientProvider.IsEnabled())
            {
                var apiWageUpdate = ApiClientMappers.Map<WageUpdate, ApiWageUpdate>(wageUpdate);

                var apiClient = _apiClientProvider.GetApiClient();

                var apiVacancyResult = await apiClient.VacancyManagement.EditWageByVacancyReferenceWithHttpMessagesAsync(apiWageUpdate, vacancyReferenceNumber.ToString());
                if (apiVacancyResult.Response.IsSuccessStatusCode)
                {
                    return new ServiceResult<WageUpdate>(VacancyManagementServiceCodes.EditWage.Ok, wageUpdate);
                }

                return new ServiceResult<WageUpdate>(VacancyManagementServiceCodes.EditWage.Error, wageUpdate);
            }

            return await _vacancyManagementService.EditWage(wageUpdate, vacancyReferenceNumber);
        }
    }
}