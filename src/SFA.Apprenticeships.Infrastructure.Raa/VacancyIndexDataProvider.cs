namespace SFA.Apprenticeships.Infrastructure.Raa
{
    using System;
    using System.Linq;
    using Application.Interfaces.Employers;
    using Application.Interfaces.Providers;
    using Application.ReferenceData;
    using Application.Vacancies;
    using Application.Vacancies.Entities;
    using Domain.Entities.Raa.Vacancies;
    using Domain.Raa.Interfaces.Repositories;
    using Mappers;
    using Application.Interfaces;
    using Application.Interfaces.Api;
    using Application.Interfaces.Vacancy;
    using Domain.Entities.ReferenceData;
    using Domain.Raa.Interfaces.Repositories.Models;

    /// <summary>
    /// TODO: This class will eventually use an RAA service for the data rather than referencing repositories directly.
    /// This service does not exist yet and so the simplest approach has been used for now
    /// </summary>
    public class VacancyIndexDataProvider : IVacancyIndexDataProvider
    {
        private const int PageSize = 500;
        private const int ApiPageSize = 50;

        private static readonly VacancyStatus[] DesiredStatuses = {VacancyStatus.Live};

        private readonly IVacancyReadRepository _vacancyReadRepository;
        private readonly IProviderService _providerService;
        private readonly IEmployerService _employerService;
        private readonly IReferenceDataProvider _referenceDataProvider;
        private readonly ILogService _logService;
        private readonly IVacancySummaryService _vacancySummaryService;
        private readonly IApiClientProvider _apiClientProvider;

        public VacancyIndexDataProvider(IVacancyReadRepository vacancyReadRepository, IProviderService providerService, IEmployerService employerService, IReferenceDataProvider referenceDataProvider, ILogService logService, IVacancySummaryService vacancySummaryService, IApiClientProvider apiClientProvider)
        {
            _vacancyReadRepository = vacancyReadRepository;
            _providerService = providerService;
            _employerService = employerService;
            _referenceDataProvider = referenceDataProvider;
            _logService = logService;
            _vacancySummaryService = vacancySummaryService;
            _apiClientProvider = apiClientProvider;
        }

        public int GetVacancyPageCount()
        {
            int count;

            if (_apiClientProvider.IsEnabled())
            {
                var apiClient = _apiClientProvider.GetApiClient();
                var apiTask = apiClient.PublicVacancySummaryOperations.GetAllLiveVacancySummariesWithHttpMessagesAsync();
                apiTask.Wait();
                var publicVacancySummariesPage = apiTask.Result.Body;
                count = publicVacancySummariesPage.TotalCount;
            }
            else
            {
                count = _vacancyReadRepository.CountWithStatus(DesiredStatuses);
            }

            var pageCount = count/PageSize;
            if (count%PageSize != 0)
            {
                pageCount++;
            }
            return pageCount;
        }

        public VacancySummaries GetVacancySummaries(int pageNumber)
        {
            /*if (_apiClientProvider.IsEnabled())
            {
                var apiClient = _apiClientProvider.GetApiClient();
                var apiTask = apiClient.PublicVacancySummaryOperations.GetAllLiveVacancySummariesWithHttpMessagesAsync(pageNumber, ApiPageSize);
                apiTask.Wait();
                var publicVacancySummariesPage = apiTask.Result.Body;
                var vacancies = publicVacancySummariesPage.VacancySummaries;

                var apprenticeshipSummaries =
                vacancies.Where(v => v.VacancyType == VacancyType.Apprenticeship.ToString()).Select(
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

                var traineeshipSummaries =
                    vacancies.Where(v => v.VacancyType == VacancyType.Traineeship.ToString()).Select(
                        v =>
                        {
                            try
                            {
                                return TraineeshipSummaryMapper.GetTraineeshipSummary(v,
                                    employers[vacancyParties[v.VacancyOwnerRelationshipId].EmployerId],
                                    providers[v.ContractOwnerId],
                                    categories, _logService);
                            }
                            catch (Exception ex)
                            {
                                _logService.Error($"Error indexing the traineeship vacancy with ID={v.VacancyId}", ex);
                                return null;
                            }
                        });

                //count = publicVacancySummariesPage.TotalCount;
            }*/

            //Page number coming in increments from 1 rather than 0, the repo expects pages to start at 0 so take one from the passed in value
            var query = new VacancySummaryByStatusQuery()
            {
                PageSize = PageSize,
                RequestedPage = pageNumber,
                DesiredStatuses = DesiredStatuses
            };

            int totalRecords;

            var vacancies = _vacancySummaryService.GetWithStatus(query, out totalRecords);
            var categories = _referenceDataProvider.GetCategories(CategoryStatus.Active, CategoryStatus.PendingClosure).ToList();
            //TODO: workaround to have the indexing partially working. Should be done properly
            var apprenticeshipSummaries =
                vacancies.Where(v => v.VacancyType == VacancyType.Apprenticeship).Select(
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

            var traineeshipSummaries =
                vacancies.Where(v => v.VacancyType == VacancyType.Traineeship).Select(
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