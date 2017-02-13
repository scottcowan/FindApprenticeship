namespace SFA.DAS.RAA.Api.Service.V1.VacancyPosting
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Apprenticeships.Application.Interfaces;
    using Apprenticeships.Application.Interfaces.Api;
    using Apprenticeships.Application.Interfaces.VacancyPosting;
    using Apprenticeships.Application.VacancyPosting.Strategies;
    using Apprenticeships.Domain.Entities.Raa.Vacancies;
    using Apprenticeships.Domain.Raa.Interfaces.Repositories.Models;
    using Mappers;
    using Microsoft.Rest;
    using ApiVacancy = Client.V1.Models.Vacancy;

    public class ApiVacancyPostingService : IVacancyPostingService
    {
        private static readonly IMapper ApiClientMappers = new ApiClientMappers();

        private readonly ICreateVacancyStrategy _createVacancyStrategy;
        private readonly IUpdateVacancyStrategy _updateVacancyStrategy;
        private readonly IArchiveVacancyStrategy _archiveVacancyStrategy;
        private readonly IGetNextVacancyReferenceNumberStrategy _getNextVacancyReferenceNumberStrategy;
        private readonly IGetVacancyStrategies _getVacancyStrategies;
        private readonly IGetVacancySummaryStrategies _getVacancySummaryStrategies;
        private readonly IQaVacancyStrategies _qaVacancyStrategies;
        private readonly IVacancyLocationsStrategies _vacancyLocationsStrategies;
        private readonly IApiClientProvider _apiClientProvider;
        private readonly ILogService _logService;

        public ApiVacancyPostingService(
            ICreateVacancyStrategy createVacancyStrategy,
            IUpdateVacancyStrategy updateVacancyStrategy,
            IArchiveVacancyStrategy archiveVacancyStrategy,
            IGetNextVacancyReferenceNumberStrategy getNextVacancyReferenceNumberStrategy,
            IGetVacancyStrategies getVacancyStrategies,
            IGetVacancySummaryStrategies getVacancySummaryStrategies,
            IQaVacancyStrategies qaVacancyStrategies,
            IVacancyLocationsStrategies vacancyLocationsStrategies, 
            IApiClientProvider apiClientProvider, 
            ILogService logService)
        {
            _createVacancyStrategy = createVacancyStrategy;
            _updateVacancyStrategy = updateVacancyStrategy;
            _archiveVacancyStrategy = archiveVacancyStrategy;
            _getNextVacancyReferenceNumberStrategy = getNextVacancyReferenceNumberStrategy;
            _getVacancyStrategies = getVacancyStrategies;
            _getVacancySummaryStrategies = getVacancySummaryStrategies;
            _qaVacancyStrategies = qaVacancyStrategies;
            _vacancyLocationsStrategies = vacancyLocationsStrategies;
            _apiClientProvider = apiClientProvider;
            _logService = logService;
        }

        public async Task<Vacancy> CreateVacancy(Vacancy vacancy)
        {
            if (_apiClientProvider.IsEnabled())
            {
                var apiClient = _apiClientProvider.GetApiClient();

                try
                {
                    vacancy.VacancySource = VacancySource.Raa;
                    var apiVacancy = ApiClientMappers.Map<Vacancy, ApiVacancy>(vacancy);
                    var apiVacancyResult = await apiClient.VacancyOperations.CreateVacancyWithHttpMessagesAsync(apiVacancy);
                    var createdApiVacancy = apiVacancyResult.Body;
                    return ApiClientMappers.Map<ApiVacancy, Vacancy>(createdApiVacancy);
                }
                catch (HttpOperationException ex)
                {
                    _logService.Info(ex.ToString());
                    throw;
                }
            }

            return _createVacancyStrategy.CreateVacancy(vacancy);
        }

        public Vacancy UpdateVacancy(Vacancy vacancy)
        {
            return _updateVacancyStrategy.UpdateVacancy(vacancy);
        }

        public Vacancy ArchiveVacancy(Vacancy vacancy)
        {
            return _archiveVacancyStrategy.ArchiveVacancy(vacancy);
        }

        public int GetNextVacancyReferenceNumber()
        {
            return _getNextVacancyReferenceNumberStrategy.GetNextVacancyReferenceNumber();
        }

        public async Task<Vacancy> GetVacancyByReferenceNumber(int vacancyReferenceNumber)
        {
            if (_apiClientProvider.IsEnabled())
            {
                var apiClient = _apiClientProvider.GetApiClient();

                try
                {
                    var apiVacancyResult = await apiClient.VacancyOperations.GetByReferenceNumberWithHttpMessagesAsync(vacancyReferenceNumber.ToString());
                    var apiVacancy = apiVacancyResult.Body;
                    return ApiClientMappers.Map<ApiVacancy, Vacancy>(apiVacancy);
                }
                catch (HttpOperationException ex)
                {
                    _logService.Info(ex.ToString());
                    return null;
                }
            }

            return _getVacancyStrategies.GetVacancyByReferenceNumber(vacancyReferenceNumber);
        }

        public async Task<Vacancy> GetVacancy(Guid vacancyGuid)
        {
            if (_apiClientProvider.IsEnabled())
            {
                var apiClient = _apiClientProvider.GetApiClient();

                try
                {
                    var apiVacancyResult = await apiClient.VacancyOperations.GetByGuidWithHttpMessagesAsync(vacancyGuid);
                    var apiVacancy = apiVacancyResult.Body;
                    return ApiClientMappers.Map<ApiVacancy, Vacancy>(apiVacancy);
                }
                catch (HttpOperationException ex)
                {
                    _logService.Info(ex.ToString());
                    return null;
                }
            }

            return _getVacancyStrategies.GetVacancyByGuid(vacancyGuid);
        }

        public async Task<Vacancy> GetVacancy(int vacancyId)
        {
            if (_apiClientProvider.IsEnabled())
            {
                var apiClient = _apiClientProvider.GetApiClient();

                try
                {
                    var apiVacancyResult = await apiClient.VacancyOperations.GetByIdWithHttpMessagesAsync(vacancyId);
                    var apiVacancy = apiVacancyResult.Body;
                    return ApiClientMappers.Map<ApiVacancy, Vacancy>(apiVacancy);
                }
                catch (HttpOperationException ex)
                {
                    _logService.Info(ex.ToString());
                    return null;
                }
            }

            return _getVacancyStrategies.GetVacancyById(vacancyId);
        }

        public IList<VacancySummary> GetWithStatus(VacancySummaryByStatusQuery query, out int totalRecords)
        {
            return _getVacancySummaryStrategies.GetWithStatus(query, out totalRecords);
        }

        public IReadOnlyList<VacancySummary> GetVacancySummariesByIds(IEnumerable<int> vacancyIds)
        {
            return _getVacancySummaryStrategies.GetVacancySummariesByIds(vacancyIds);
        }

        public Vacancy ReserveVacancyForQA(int vacancyReferenceNumber)
        {
            return _qaVacancyStrategies.ReserveVacancyForQa(vacancyReferenceNumber);
        }

        public void UnReserveVacancyForQa(int vacancyReferenceNumber)
        {
            _qaVacancyStrategies.UnReserveVacancyForQa(vacancyReferenceNumber);
        }

        public List<VacancyLocation> GetVacancyLocations(int vacancyId)
        {
            return _vacancyLocationsStrategies.GetVacancyLocations(vacancyId);
        }

        public List<VacancyLocation> GetVacancyLocationsByReferenceNumber(int vacancyReferenceNumber)
        {
            return _vacancyLocationsStrategies.GetVacancyLocationsByReferenceNumber(vacancyReferenceNumber);
        }

        public List<VacancyLocation> CreateVacancyLocations(List<VacancyLocation> vacancyLocations)
        {
            return _vacancyLocationsStrategies.CreateVacancyLocations(vacancyLocations);
        }

        public List<VacancyLocation> UpdateVacancyLocations(List<VacancyLocation> vacancyLocations)
        {
            return _vacancyLocationsStrategies.UpdateVacancyLocations(vacancyLocations);
        }

        public void DeleteVacancyLocationsFor(int vacancyId)
        {
            _vacancyLocationsStrategies.DeleteVacancyLocationsFor(vacancyId);
        }

        public IReadOnlyDictionary<int, IEnumerable<VacancyLocation>> GetVacancyLocationsByVacancyIds(IEnumerable<int> vacancyOwnerRelationshipIds)
        {
            return _vacancyLocationsStrategies.GetVacancyLocationsByVacancyIds(vacancyOwnerRelationshipIds);
        }

        public Vacancy UpdateVacanciesWithNewProvider(Vacancy vacancy)
        {
            return _updateVacancyStrategy.UpdateVacancyWithNewProvider(vacancy);
        }

        public IList<RegionalTeamMetrics> GetRegionalTeamsMetrics(VacancySummaryByStatusQuery query)
        {
            return _getVacancySummaryStrategies.GetRegionalTeamMetrics(query);
        }
    }
}
