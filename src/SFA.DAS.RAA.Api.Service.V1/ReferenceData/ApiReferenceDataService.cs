namespace SFA.DAS.RAA.Api.Service.V1.ReferenceData
{
    using Apprenticeships.Application.Interfaces;
    using Apprenticeships.Application.Interfaces.Api;
    using Apprenticeships.Application.Interfaces.ReferenceData;
    using Apprenticeships.Application.ReferenceData;
    using Apprenticeships.Domain.Entities.Raa.Reference;
    using Apprenticeships.Domain.Entities.Raa.Vacancies;
    using Apprenticeships.Domain.Entities.ReferenceData;
    using Mappers;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using ApiCategory = Client.V1.Models.Category;
    using ApiCounty = Client.V1.Models.County;
    using ApiLocalAuthority = Client.V1.Models.LocalAuthority;
    using ApiRegion = Client.V1.Models.Region;
    using ApiStandardSubjectAreaTierOne = Client.V1.Models.StandardSubjectAreaTierOne;

    public class ApiReferenceDataService : IReferenceDataService
    {
        private static readonly IMapper ApiClientMappers = new ApiClientMappers();

        private readonly IApiClientProvider _apiClientProvider;
        private readonly IReferenceDataService _referenceDataService;

        public ApiReferenceDataService(IApiClientProvider apiClientProvider, IReferenceDataProvider referenceDataProvider)
        {
            _apiClientProvider = apiClientProvider;
            _referenceDataService = new ReferenceDataService(referenceDataProvider);
        }

        public IEnumerable<Category> GetCategories()
        {
            return _referenceDataService.GetCategories();
        }

        public Category GetSubCategoryByName(string subCategoryName)
        {
            return _referenceDataService.GetSubCategoryByName(subCategoryName);
        }

        public Category GetCategoryByName(string categoryName)
        {
            return _referenceDataService.GetCategoryByName(categoryName);
        }

        public Category GetSubCategoryByCode(string subCategoryCode)
        {
            return _referenceDataService.GetSubCategoryByCode(subCategoryCode);
        }

        public Category GetCategoryByCode(string categoryCode)
        {
            return _referenceDataService.GetCategoryByCode(categoryCode);
        }

        public async Task<IEnumerable<Category>> GetFrameworks()
        {
            if (_apiClientProvider.IsEnabled())
            {
                var apiClient = _apiClientProvider.GetApiClient();
                var apiResult = await apiClient.Reference.GetFrameworksWithHttpMessagesAsync();
                return ApiClientMappers.Map<IList<ApiCategory>, IList<Category>>(apiResult.Body);
            }
            return await _referenceDataService.GetFrameworks();
        }

        public async Task<IEnumerable<StandardSubjectAreaTierOne>> GetStandardSubjectAreaTierOnes()
        {
            if (_apiClientProvider.IsEnabled())
            {
                var apiClient = _apiClientProvider.GetApiClient();
                var apiResult = await apiClient.Reference.GetStandardsWithHttpMessagesAsync();
                return ApiClientMappers.Map<IList<ApiStandardSubjectAreaTierOne>, IList<StandardSubjectAreaTierOne>>(apiResult.Body);
            }
            return await _referenceDataService.GetStandardSubjectAreaTierOnes();
        }

        public IEnumerable<Sector> GetSectors()
        {
            return _referenceDataService.GetSectors();
        }

        public IList<ReleaseNote> GetReleaseNotes(DasApplication dasApplication)
        {
            return _referenceDataService.GetReleaseNotes(dasApplication);
        }

        public async Task<IEnumerable<County>> GetCounties()
        {
            if (_apiClientProvider.IsEnabled())
            {
                var apiClient = _apiClientProvider.GetApiClient();

                var apiResult = await apiClient.Reference.GetCountiesWithHttpMessagesAsync();
                return ApiClientMappers.Map<IList<ApiCounty>, IList<County>>(apiResult.Body);
            }

            return await _referenceDataService.GetCounties();
        }

        public async Task<County> GetCountyById(int countyId)
        {
            if (_apiClientProvider.IsEnabled())
            {
                var apiClient = _apiClientProvider.GetApiClient();

                var apiResult = await apiClient.Reference.GetCountyByIdWithHttpMessagesAsync(countyId);
                return ApiClientMappers.Map<ApiCounty, County>(apiResult.Body);
            }

            return await _referenceDataService.GetCountyById(countyId);
        }

        public async Task<County> GetCountyByCode(string countyCode)
        {
            if (_apiClientProvider.IsEnabled())
            {
                var apiClient = _apiClientProvider.GetApiClient();

                var apiResult = await apiClient.Reference.GetCountyByCodeWithHttpMessagesAsync(countyCode);
                return ApiClientMappers.Map<ApiCounty, County>(apiResult.Body);
            }

            return await _referenceDataService.GetCountyByCode(countyCode);
        }

        public async Task<County> GetCountyByName(string countyName)
        {
            return await _referenceDataService.GetCountyByName(countyName);
        }

        public async Task<IEnumerable<LocalAuthority>> GetLocalAuthorities()
        {
            if (_apiClientProvider.IsEnabled())
            {
                var apiClient = _apiClientProvider.GetApiClient();

                var apiResult = await apiClient.Reference.GetLocalAuthoritiesWithHttpMessagesAsync();
                return ApiClientMappers.Map<IList<ApiLocalAuthority>, IList<LocalAuthority>>(apiResult.Body);
            }

            return await _referenceDataService.GetLocalAuthorities();
        }

        public async Task<LocalAuthority> GetLocalAuthorityById(int localAuthorityId)
        {
            if (_apiClientProvider.IsEnabled())
            {
                var apiClient = _apiClientProvider.GetApiClient();

                var apiResult = await apiClient.Reference.GetLocalAuthorityByIdWithHttpMessagesAsync(localAuthorityId);
                return ApiClientMappers.Map<ApiLocalAuthority, LocalAuthority>(apiResult.Body);
            }

            return await _referenceDataService.GetLocalAuthorityById(localAuthorityId);
        }

        public async Task<LocalAuthority> GetLocalAuthorityByCode(string localAuthorityCode)
        {
            if (_apiClientProvider.IsEnabled())
            {
                var apiClient = _apiClientProvider.GetApiClient();

                var apiResult = await apiClient.Reference.GetLocalAuthorityByCodeWithHttpMessagesAsync(localAuthorityCode);
                return ApiClientMappers.Map<ApiLocalAuthority, LocalAuthority>(apiResult.Body);
            }

            return await _referenceDataService.GetLocalAuthorityByCode(localAuthorityCode);
        }

        public async Task<IEnumerable<Region>> GetRegions()
        {
            if (_apiClientProvider.IsEnabled())
            {
                var apiClient = _apiClientProvider.GetApiClient();

                var apiResult = await apiClient.Reference.GetRegionsWithHttpMessagesAsync();
                return ApiClientMappers.Map<IList<ApiRegion>, IList<Region>>(apiResult.Body);
            }

            return await _referenceDataService.GetRegions();
        }

        public async Task<Region> GetRegionById(int regionId)
        {
            if (_apiClientProvider.IsEnabled())
            {
                var apiClient = _apiClientProvider.GetApiClient();

                var apiResult = await apiClient.Reference.GetRegionByIdWithHttpMessagesAsync(regionId);
                return ApiClientMappers.Map<ApiRegion, Region>(apiResult.Body);
            }

            return await _referenceDataService.GetRegionById(regionId);
        }

        public async Task<Region> GetRegionByCode(string regionCode)
        {
            if (_apiClientProvider.IsEnabled())
            {
                var apiClient = _apiClientProvider.GetApiClient();

                var apiResult = await apiClient.Reference.GetRegionByCodeWithHttpMessagesAsync(regionCode);
                return ApiClientMappers.Map<ApiRegion, Region>(apiResult.Body);
            }

            return await _referenceDataService.GetRegionByCode(regionCode);
        }
    }
}