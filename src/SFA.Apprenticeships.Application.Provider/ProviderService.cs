﻿namespace SFA.Apprenticeships.Application.Provider
{
    using CuttingEdge.Conditions;
    using Domain.Entities.Raa.Parties;
    using Domain.Raa.Interfaces.Repositories;
    using Domain.Raa.Interfaces.Repositories.Models;
    using Interfaces;
    using Interfaces.Employers;
    using Interfaces.Generic;
    using Interfaces.Providers;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;
    using System.Threading.Tasks;
    using Domain.Entities.Exceptions;
    using Strategies;

    public class ProviderService : IProviderService
    {
        private readonly IEmployerService _employerService;
        private readonly ILogService _logService;
        private readonly IProviderReadRepository _providerReadRepository;
        private readonly IProviderWriteRepository _providerWriteRepository;
        private readonly IProviderSiteReadRepository _providerSiteReadRepository;
        private readonly IProviderSiteWriteRepository _providerSiteWriteRepository;
        private readonly IVacancyOwnerRelationshipReadRepository _vacancyOwnerRelationshipReadRepository;
        private readonly IVacancyOwnerRelationshipWriteRepository _vacancyOwnerRelationshipWriteRepository;
        private readonly IGetOwnedProviderSitesStrategy _getOwnedProviderSitesStrategy;
        private readonly IGetVacancyOwnerRelationshipStrategy _getVacancyOwnerRelationshipStrategy;

        public ProviderService(IProviderReadRepository providerReadRepository,
            IProviderSiteReadRepository providerSiteReadRepository,
            IVacancyOwnerRelationshipReadRepository vacancyOwnerRelationshipReadRepository,
            IVacancyOwnerRelationshipWriteRepository vacancyOwnerRelationshipWriteRepository,
            ILogService logService, IEmployerService employerService, IProviderWriteRepository providerWriteRepository,
            IProviderSiteWriteRepository providerSiteWriteRepository, IGetOwnedProviderSitesStrategy getOwnedProviderSitesStrategy, IGetVacancyOwnerRelationshipStrategy getVacancyOwnerRelationshipStrategy)
        {
            _providerReadRepository = providerReadRepository;
            _providerSiteReadRepository = providerSiteReadRepository;
            _vacancyOwnerRelationshipReadRepository = vacancyOwnerRelationshipReadRepository;
            _vacancyOwnerRelationshipWriteRepository = vacancyOwnerRelationshipWriteRepository;
            _logService = logService;
            _employerService = employerService;
            _providerWriteRepository = providerWriteRepository;
            _providerSiteWriteRepository = providerSiteWriteRepository;
            _getOwnedProviderSitesStrategy = getOwnedProviderSitesStrategy;
            _getVacancyOwnerRelationshipStrategy = getVacancyOwnerRelationshipStrategy;
        }

        public Provider GetProvider(int providerId)
        {
            return _providerReadRepository.GetById(providerId);
        }

        public Provider GetProvider(string ukprn, bool errorIfNotFound = true)
        {
            Condition.Requires(ukprn).IsNotNullOrEmpty();

            _logService.Debug("Calling ProviderReadRepository to get provider with UKPRN='{0}'.", ukprn);

            return _providerReadRepository.GetByUkprn(ukprn, errorIfNotFound);
        }

        public IEnumerable<Provider> GetProviders(IEnumerable<int> providerIds)
        {
            return _providerReadRepository.GetByIds(providerIds);
        }

        public IEnumerable<Provider> SearchProviders(ProviderSearchParameters searchParameters)
        {
            return _providerReadRepository.Search(searchParameters);
        }

        public ProviderSite GetProviderSite(int providerSiteId)
        {
            return _providerSiteReadRepository.GetById(providerSiteId);
        }

        public ProviderSite GetProviderSite(string edsUrn)
        {
            Condition.Requires(edsUrn).IsNotNullOrEmpty();

            _logService.Debug("Calling ProviderSiteReadRepository to get provider site with ERN='{0}'.", edsUrn);

            return _providerSiteReadRepository.GetByEdsUrn(edsUrn);
        }

        public IEnumerable<ProviderSite> GetProviderSites(int providerId)
        {
            return _providerSiteReadRepository.GetByProviderId(providerId);
        }

        public IEnumerable<ProviderSite> GetProviderSites(string ukprn)
        {
            Condition.Requires(ukprn).IsNotNullOrEmpty();
            
            _logService.Debug(
                "Calling ProviderSiteReadRepository to get provider sites for provider with UKPRN='{0}'.", ukprn);

            var provider = _providerReadRepository.GetByUkprn(ukprn);
            if (provider == null)
            {
                throw new CustomException(ProviderServiceCodes.ProviderNotFound, $"Provider cannot be found with ukprn={ukprn}");
            }

            return _providerSiteReadRepository.GetByProviderId(provider.ProviderId);
        }

        public IReadOnlyDictionary<int, ProviderSite> GetProviderSites(IEnumerable<int> providerSiteIds)
        {
            return _providerSiteReadRepository.GetByIds(providerSiteIds);
        }

        public IEnumerable<ProviderSite> GetOwnedProviderSites(int providerId)
        {
            return _getOwnedProviderSitesStrategy.GetOwnedProviderSites(providerId);
        }

        public IEnumerable<ProviderSite> SearchProviderSites(ProviderSiteSearchParameters searchParameters)
        {
            return _providerSiteReadRepository.Search(searchParameters);
        }

        public VacancyOwnerRelationship GetVacancyOwnerRelationship(int vacancyOwnerRelationshipId, bool currentOnly = true)
        {
            return _vacancyOwnerRelationshipReadRepository.GetByIds(new[] { vacancyOwnerRelationshipId }, currentOnly).FirstOrDefault();
        }

        public IReadOnlyDictionary<int, VacancyOwnerRelationship> GetVacancyOwnerRelationships(IEnumerable<int> vacancyOwnerRelationshipIds,
            bool currentOnly = true)
        {
            return
                _vacancyOwnerRelationshipReadRepository.GetByIds(vacancyOwnerRelationshipIds, currentOnly).ToDictionary(vp => vp.VacancyOwnerRelationshipId);
        }

        public VacancyOwnerRelationship GetVacancyOwnerRelationship(int providerSiteId, string edsUrn, bool liveOnly = true)
        {
            return _getVacancyOwnerRelationshipStrategy.GetVacancyOwnerRelationship(providerSiteId, edsUrn, liveOnly);
        }

        public VacancyOwnerRelationship GetVacancyOwnerRelationship(int employerId, int providerSiteId, bool liveOnly = true)
        {
            return _getVacancyOwnerRelationshipStrategy.GetVacancyOwnerRelationship(providerSiteId, employerId, liveOnly);
        }

        public Task<VacancyOwnerRelationship> SaveVacancyOwnerRelationship(VacancyOwnerRelationship vacancyOwnerRelationship, string edsUrn)
        {
            return Task.FromResult(_vacancyOwnerRelationshipWriteRepository.Save(vacancyOwnerRelationship));
        }

        public IEnumerable<VacancyOwnerRelationship> GetVacancyOwnerRelationships(int providerSiteId)
        {
            return _vacancyOwnerRelationshipReadRepository.GetByProviderSiteId(providerSiteId);
        }

        public Pageable<VacancyOwnerRelationship> GetVacancyOwnerRelationships(EmployerSearchRequest request, int currentPage, int pageSize)
        {
            var results = GetVacancyParties(request);

            var pageable = new Pageable<VacancyOwnerRelationship>
            {
                CurrentPage = currentPage
            };

            var resultCount = results.Count;

            pageable.Page = results.Skip((currentPage - 1) * pageSize).Take(pageSize).ToList();
            pageable.ResultsCount = resultCount;
            pageable.TotalNumberOfPages = resultCount / pageSize + 1;

            return pageable;
        }

        public Provider CreateProvider(Provider provider)
        {
            return _providerWriteRepository.Create(provider);
        }

        public Provider SaveProvider(Provider provider)
        {
            return _providerWriteRepository.Update(provider);
        }

        public ProviderSite CreateProviderSite(ProviderSite providerSite)
        {
            return _providerSiteWriteRepository.Create(providerSite);
        }

        public ProviderSite SaveProviderSite(ProviderSite providerSite)
        {
            return _providerSiteWriteRepository.Update(providerSite);
        }

        public ProviderSiteRelationship GetProviderSiteRelationship(int providerSiteRelationshipId)
        {
            return _providerSiteReadRepository.GetProviderSiteRelationship(providerSiteRelationshipId);
        }

        public ProviderSiteRelationship CreateProviderSiteRelationship(ProviderSiteRelationship providerSiteRelationship)
        {
            return _providerSiteWriteRepository.Create(providerSiteRelationship);
        }

        public void DeleteProviderSiteRelationship(int providerSiteRelationshipId)
        {
            _providerSiteWriteRepository.DeleteProviderSiteRelationship(providerSiteRelationshipId);
        }

        private List<VacancyOwnerRelationship> GetVacancyParties(EmployerSearchRequest request)
        {
            Condition.Requires(request).IsNotNull();

            _logService.Debug(
                "Calling VacancyOwnerRelationshipReadRepository to get vacancy party for provider site with Id='{0}'.",
                request.ProviderSiteId);

            var vacancyParties = _vacancyOwnerRelationshipReadRepository.GetByProviderSiteId(request.ProviderSiteId).ToList();

            if (request.IsQuery)
            {
                var employers = _employerService.GetEmployers(vacancyParties.Select(v => v.EmployerId).Distinct());

                if (request.IsEmployerEdsUrnQuery)
                {
                    employers = employers.Where(e => e.EdsUrn == request.EmployerEdsUrn);
                }
                else if (request.IsNameAndLocationQuery)
                {
                    employers = employers.Where(employer =>
                        employer.FullName.ToLower().Contains(request.Name.ToLower()) &&
                        IsMatchingAddress(request, employer));
                }
                else if (request.IsNameQuery)
                {
                    employers = employers.Where(e => e.FullName.ToLower().Contains(request.Name.ToLower()));
                }
                else if (request.IsLocationQuery)
                {
                    employers = employers.Where(e => IsMatchingAddress(request, e));
                }

                vacancyParties = vacancyParties.Where(vp => employers.Any(e => e.EmployerId == vp.EmployerId)).ToList();
            }

            return vacancyParties;
        }

        private static bool IsMatchingAddress(EmployerSearchRequest request, Employer e)
        {
            return
                (e.Address.Postcode != null &&
                 Regex.Replace(e.Address.Postcode, @"\s+", "").ToLower().Contains(request.Location.ToLower())) ||
                (e.Address.AddressLine4 != null &&
                 Regex.Replace(e.Address.AddressLine4, @"\s+", "").ToLower().Contains(request.Location.ToLower())) ||
                (e.Address.Town != null &&
                 Regex.Replace(e.Address.Town, @"\s+", "").ToLower().Contains(request.Location.ToLower()));
        }
    }
}