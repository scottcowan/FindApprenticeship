using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFA.Apprenticeships.Application.Interfaces;
using SFA.Apprenticeships.Application.Interfaces.Api;
using SFA.Apprenticeships.Application.Interfaces.Service;
using SFA.Apprenticeships.Application.Interfaces.Vacancy;
using SFA.Apprenticeships.Application.Vacancy;
using SFA.Apprenticeships.Domain.Entities.Raa.Vacancies;
using SFA.Apprenticeships.Domain.Raa.Interfaces.Queries;
using SFA.Apprenticeships.Domain.Raa.Interfaces.Repositories;
using SFA.Apprenticeships.Domain.Raa.Interfaces.Repositories.Models;
using SFA.DAS.RAA.Api.Client.V1;
using SFA.DAS.RAA.Api.Service.V1.Mappers;

namespace SFA.DAS.RAA.Api.Service.V1.Vacancy
{
    class ApiVacancySummaryService : IVacancySummaryService
    {
        private static readonly IMapper ApiClientMappers = new ApiClientMappers();

        private readonly IApiClientProvider _apiClientProvider;
        private readonly IVacancySummaryService _vacancySummaryService;

        public ApiVacancySummaryService(IApiClientProvider apiClientProvider, 
            IVacancySummaryRepository vacancySummaryRepository)
        {
            _apiClientProvider = apiClientProvider;
            _vacancySummaryService = new VacancySummaryService(vacancySummaryRepository);
        }

        public async Task<IServiceResult<ListWithTotalCount<VacancySummary>>> GetSummariesForProvider(VacancySummaryQuery query)
        {
            if (_apiClientProvider.IsEnabled())
            {
                var apiClient = _apiClientProvider.GetApiClient();

                var apiVacancyResult = await apiClient.VacancySummaryOperations.GetVacancySummariesWithHttpMessagesAsync(
                    query.SearchString,
                    query.SearchMode.ToString(),
                    query.VacancyType.ToString(),
                    query.Order.ToString(),
                    query.OrderByField.ToString(),
                    query.Filter.ToString(),
                    query.RequestedPage,
                    query.PageSize
                    );

                var list = ApiClientMappers.Map<IList<Client.V1.Models.VacancySummary>, IEnumerable<VacancySummary>>(
                    apiVacancyResult.Body.VacancySummaries);

                if (apiVacancyResult.Response.IsSuccessStatusCode)
                {
                    return new ServiceResult<ListWithTotalCount<VacancySummary>>(VacancyManagementServiceCodes.EditWage.Ok, 
                        new ListWithTotalCount<VacancySummary>(list, apiVacancyResult.Body.TotalCount));
                }

                return new ServiceResult<ListWithTotalCount<VacancySummary>>(VacancyManagementServiceCodes.EditWage.Error, 
                    new ListWithTotalCount<VacancySummary>(list, apiVacancyResult.Body.TotalCount));
            }

            return await _vacancySummaryService.GetSummariesForProvider(query);
        }

        public VacancyCounts GetLotteryCounts(VacancySummaryQuery query)
        {
            return _vacancySummaryService.GetLotteryCounts(query);
        }

        public IList<VacancySummary> GetWithStatus(VacancySummaryByStatusQuery query, out int totalRecords)
        {
            return _vacancySummaryService.GetWithStatus(query, out totalRecords);
        }

        public IList<RegionalTeamMetrics> GetRegionalTeamMetrics(VacancySummaryByStatusQuery query)
        {
            return _vacancySummaryService.GetRegionalTeamMetrics(query);
        }

        public VacancySummary GetById(int vacancyId)
        {
            return _vacancySummaryService.GetById(vacancyId);
        }

        public VacancySummary GetByReferenceNumber(int vacancyReferenceNumber)
        {
            return _vacancySummaryService.GetByReferenceNumber(vacancyReferenceNumber);
        }

        public IList<VacancySummary> GetByIds(IEnumerable<int> vacancyIds)
        {
            return _vacancySummaryService.GetByIds(vacancyIds);
        }

        public IList<VacancySummary> Find(ApprenticeshipVacancyQuery query, out int resultCount)
        {
            return _vacancySummaryService.Find(query, out resultCount);
        }
    }
}
