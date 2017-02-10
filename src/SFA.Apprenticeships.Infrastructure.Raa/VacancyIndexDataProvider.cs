namespace SFA.Apprenticeships.Infrastructure.Raa
{
    using Application.Interfaces;
    using Application.Interfaces.Api;
    using Application.Interfaces.Vacancy;
    using Application.ReferenceData;
    using Application.Vacancies;
    using Application.Vacancies.Entities;
    using DAS.RAA.Api.Client.V1.Models;
    using DAS.RAA.Api.Service.V1.Mappers;
    using Domain.Entities.Raa.Vacancies;
    using Domain.Entities.ReferenceData;
    using Domain.Raa.Interfaces.Repositories;
    using Domain.Raa.Interfaces.Repositories.Models;
    using Mappers;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Category = Domain.Entities.ReferenceData.Category;
    using VacancySummary = Domain.Entities.Raa.Vacancies.VacancySummary;

    public class VacancyIndexDataProvider : IVacancyIndexDataProvider
    {
        private const int PageSize = 500;
        private const int ApiPageSize = 250;

        private static readonly IMapper ApiClientMappers = new ApiClientMappers();

        private static readonly VacancyStatus[] DesiredStatuses = { VacancyStatus.Live };

        private readonly IVacancyReadRepository _vacancyReadRepository;
        private readonly IReferenceDataProvider _referenceDataProvider;
        private readonly ILogService _logService;
        private readonly IVacancySummaryService _vacancySummaryService;
        private readonly IApiClientProvider _apiClientProvider;

        public VacancyIndexDataProvider(IVacancyReadRepository vacancyReadRepository, IReferenceDataProvider referenceDataProvider, ILogService logService, IVacancySummaryService vacancySummaryService, IApiClientProvider apiClientProvider)
        {
            _vacancyReadRepository = vacancyReadRepository;
            _referenceDataProvider = referenceDataProvider;
            _logService = logService;
            _vacancySummaryService = vacancySummaryService;
            _apiClientProvider = apiClientProvider;
        }

        public async Task<int> GetVacancyPageCount()
        {
            int count;
            int pageSize;

            if (_apiClientProvider.IsEnabled())
            {
                var apiClient = _apiClientProvider.GetApiClient();
                var apiResponse = await apiClient.PublicVacancySummaryOperations.GetAllLiveVacancySummariesWithHttpMessagesAsync(1, 1);
                var publicVacancySummariesPage = apiResponse.Body;
                count = publicVacancySummariesPage.TotalCount;
                pageSize = ApiPageSize;
            }
            else
            {
                count = _vacancyReadRepository.CountWithStatus(DesiredStatuses);
                pageSize = PageSize;
            }

            var pageCount = count / pageSize;
            if (count % pageSize != 0)
            {
                pageCount++;
            }
            return pageCount;
        }

        public async Task<VacancySummaries> GetVacancySummaries(int pageNumber)
        {
            IList<VacancySummary> vacancies;

            try
            {
                if (_apiClientProvider.IsEnabled())
                {
                    var apiClient = _apiClientProvider.GetApiClient();
                    var apiResponse = await apiClient.PublicVacancySummaryOperations.GetAllLiveVacancySummariesWithHttpMessagesAsync(pageNumber, ApiPageSize);
                    var publicVacancySummariesPage = apiResponse.Body;

                    vacancies = ApiClientMappers.Map<IList<PublicVacancySummary>, IList<VacancySummary>>(publicVacancySummariesPage.VacancySummaries);
                }
                else
                {
                    //Page number coming in increments from 1 rather than 0, the repo expects pages to start at 0 so take one from the passed in value
                    var query = new VacancySummaryByStatusQuery()
                    {
                        PageSize = PageSize,
                        RequestedPage = pageNumber,
                        DesiredStatuses = DesiredStatuses
                    };

                    int totalRecords;

                    vacancies = _vacancySummaryService.GetWithStatus(query, out totalRecords);
                }
            }
            catch (Exception ex)
            {
                _logService.Error($"Exception thrown when retrieving vacancy summaries page {pageNumber}", ex);
                throw;
            }

            var categories = new List<Category>(_referenceDataProvider.GetCategories(CategoryStatus.Active, CategoryStatus.PendingClosure).ToList());

            var apprenticeshipSummaries = vacancies.Where(v => v.VacancyType == VacancyType.Apprenticeship).Select(
                    v =>
                    {
                        try
                        {
                            return ApprenticeshipSummaryMapper.GetApprenticeshipSummary(v, categories, _logService);
                        }
                        catch (Exception ex)
                        {
                            _logService.Error($"Error indexing the apprenticeship vacancy with ID={v.VacancyId}", ex);
                            return null;
                        }
                    });

            var traineeshipSummaries = vacancies.Where(v => v.VacancyType == VacancyType.Traineeship).Select(
                    v =>
                    {
                        try
                        {
                            return TraineeshipSummaryMapper.GetTraineeshipSummary(v, categories, _logService);
                        }
                        catch (Exception ex)
                        {
                            _logService.Error($"Error indexing the traineeship vacancy with ID={v.VacancyId}", ex);
                            return null;
                        }
                    });

            return new VacancySummaries(apprenticeshipSummaries.Where(s => s != null), traineeshipSummaries.Where(s => s != null));
        }
    }
}