namespace SFA.DAS.RAA.Api.Service.V1.Provider
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Apprenticeships.Application.Interfaces;
    using Apprenticeships.Application.Interfaces.Api;
    using Apprenticeships.Application.Interfaces.Employers;
    using Apprenticeships.Application.Interfaces.Generic;
    using Apprenticeships.Application.Interfaces.Providers;
    using Apprenticeships.Application.Provider;
    using Apprenticeships.Application.Provider.Strategies;
    using Apprenticeships.Domain.Entities.Raa.Parties;
    using Apprenticeships.Domain.Raa.Interfaces.Repositories;
    using Apprenticeships.Domain.Raa.Interfaces.Repositories.Models;
    using Client.V1.Models;
    using Mappers;
    using Microsoft.Rest;

    public class ApiProviderService : IProviderService
    {
        private static readonly IMapper ApiClientMappers = new ApiClientMappers();

        private readonly ILogService _logService;
        private readonly IProviderService _providerService;
        private readonly IApiClientProvider _apiClientProvider;

        public ApiProviderService(IProviderReadRepository providerReadRepository,
            IProviderSiteReadRepository providerSiteReadRepository,
            IVacancyOwnerRelationshipReadRepository vacancyOwnerRelationshipReadRepository,
            IVacancyOwnerRelationshipWriteRepository vacancyOwnerRelationshipWriteRepository,
            ILogService logService, IEmployerService employerService, IProviderWriteRepository providerWriteRepository,
            IProviderSiteWriteRepository providerSiteWriteRepository, IGetOwnedProviderSitesStrategy getOwnedProviderSitesStrategy, IGetVacancyOwnerRelationshipStrategy getVacancyOwnerRelationshipStrategy, IApiClientProvider apiClientProvider)
        {
            _logService = logService;
            _apiClientProvider = apiClientProvider;
            _providerService = new ProviderService(providerReadRepository, providerSiteReadRepository, vacancyOwnerRelationshipReadRepository, vacancyOwnerRelationshipWriteRepository, logService, employerService, providerWriteRepository, providerSiteWriteRepository, getOwnedProviderSitesStrategy, getVacancyOwnerRelationshipStrategy);
        }

        public Provider GetProvider(int providerId)
        {
            return _providerService.GetProvider(providerId);
        }

        public Provider GetProvider(string ukprn, bool errorIfNotFound = true)
        {
            return _providerService.GetProvider(ukprn, errorIfNotFound);
        }

        public IEnumerable<Provider> GetProviders(IEnumerable<int> providerIds)
        {
            return _providerService.GetProviders(providerIds);
        }

        public IEnumerable<Provider> SearchProviders(ProviderSearchParameters searchParameters)
        {
            return _providerService.SearchProviders(searchParameters);
        }

        public ProviderSite GetProviderSite(int providerSiteId)
        {
            return _providerService.GetProviderSite(providerSiteId);
        }

        public ProviderSite GetProviderSite(string edsUrn)
        {
            return _providerService.GetProviderSite(edsUrn);
        }

        public IEnumerable<ProviderSite> GetProviderSites(int providerId)
        {
            return _providerService.GetProviderSites(providerId);
        }

        public IEnumerable<ProviderSite> GetProviderSites(string ukprn)
        {
            return _providerService.GetProviderSites(ukprn);
        }

        public IReadOnlyDictionary<int, ProviderSite> GetProviderSites(IEnumerable<int> providerSiteIds)
        {
            return _providerService.GetProviderSites(providerSiteIds);
        }

        public IEnumerable<ProviderSite> GetOwnedProviderSites(int providerId)
        {
            return _providerService.GetOwnedProviderSites(providerId);
        }

        public IEnumerable<ProviderSite> SearchProviderSites(ProviderSiteSearchParameters searchParameters)
        {
            return _providerService.SearchProviderSites(searchParameters);
        }

        public VacancyOwnerRelationship GetVacancyOwnerRelationship(int vacancyOwnerRelationshipId, bool currentOnly)
        {
            return _providerService.GetVacancyOwnerRelationship(vacancyOwnerRelationshipId, currentOnly);
        }

        public VacancyOwnerRelationship GetVacancyOwnerRelationship(int employerId, int providerSiteId, bool liveOnly)
        {
            return _providerService.GetVacancyOwnerRelationship(employerId, providerSiteId, liveOnly);
        }

        public IReadOnlyDictionary<int, VacancyOwnerRelationship> GetVacancyOwnerRelationships(IEnumerable<int> vacancyOwnerRelationshipIds, bool currentOnly)
        {
            return _providerService.GetVacancyOwnerRelationships(vacancyOwnerRelationshipIds, currentOnly);
        }

        public VacancyOwnerRelationship GetVacancyOwnerRelationship(int providerSiteId, string edsUrn, bool liveOnly)
        {
            return _providerService.GetVacancyOwnerRelationship(providerSiteId, edsUrn, liveOnly);
        }

        public async Task<VacancyOwnerRelationship> SaveVacancyOwnerRelationship(VacancyOwnerRelationship vacancyOwnerRelationship, string edsUrn)
        {
            if (_apiClientProvider.IsEnabled())
            {
                var providerSite = GetProviderSite(vacancyOwnerRelationship.ProviderSiteId);

                var employerProviderSiteLinkRequest = new EmployerProviderSiteLinkRequest
                {
                    ProviderSiteEdsUrn = Convert.ToInt32(providerSite.EdsUrn),
                    EmployerDescription = vacancyOwnerRelationship.EmployerDescription,
                    EmployerWebsiteUrl = vacancyOwnerRelationship.EmployerWebsiteUrl
                };

                var apiClient = _apiClientProvider.GetApiClient();

                try
                {
                    var apiVacancyResult = await apiClient.Employer.LinkEmployerByEdsUrnWithHttpMessagesAsync(employerProviderSiteLinkRequest, Convert.ToInt32(edsUrn));
                    var employerProviderSiteLink = apiVacancyResult.Body;
                    return ApiClientMappers.Map<EmployerProviderSiteLink, VacancyOwnerRelationship>(employerProviderSiteLink);
                }
                catch (HttpOperationException ex)
                {
                    _logService.Warn(ex);
                    return null;
                }
                catch (Exception ex)
                {
                    _logService.Error(ex);
                    throw;
                }
            }

            return await _providerService.SaveVacancyOwnerRelationship(vacancyOwnerRelationship, edsUrn);
        }

        public IEnumerable<VacancyOwnerRelationship> GetVacancyOwnerRelationships(int providerSiteId)
        {
            return _providerService.GetVacancyOwnerRelationships(providerSiteId);
        }

        public Pageable<VacancyOwnerRelationship> GetVacancyOwnerRelationships(EmployerSearchRequest request, int currentPage, int pageSize)
        {
            return _providerService.GetVacancyOwnerRelationships(request, currentPage, pageSize);
        }

        public Provider CreateProvider(Provider provider)
        {
            return _providerService.CreateProvider(provider);
        }

        public Provider SaveProvider(Provider provider)
        {
            return _providerService.SaveProvider(provider);
        }

        public ProviderSite CreateProviderSite(ProviderSite providerSite)
        {
            return _providerService.CreateProviderSite(providerSite);
        }

        public ProviderSite SaveProviderSite(ProviderSite providerSite)
        {
            return _providerService.SaveProviderSite(providerSite);
        }

        public ProviderSiteRelationship GetProviderSiteRelationship(int providerSiteRelationshipId)
        {
            return _providerService.GetProviderSiteRelationship(providerSiteRelationshipId);
        }

        public ProviderSiteRelationship CreateProviderSiteRelationship(ProviderSiteRelationship providerSiteRelationship)
        {
            return _providerService.CreateProviderSiteRelationship(providerSiteRelationship);
        }

        public void DeleteProviderSiteRelationship(int providerSiteRelationshipId)
        {
            _providerService.DeleteProviderSiteRelationship(providerSiteRelationshipId);
        }
    }
}