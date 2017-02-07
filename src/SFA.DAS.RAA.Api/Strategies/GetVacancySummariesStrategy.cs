namespace SFA.DAS.RAA.Api.Strategies
{
    using System;
    using System.Linq;
    using Apprenticeships.Domain.Entities.Raa.Vacancies;
    using Apprenticeships.Domain.Raa.Interfaces.Repositories;
    using Apprenticeships.Domain.Raa.Interfaces.Repositories.Models;
    using Models;

    public class GetVacancySummariesStrategy : IGetVacancySummariesStrategy
    {
        private readonly IProviderReadRepository _providerReadRepository;
        private readonly IProviderSiteReadRepository _providerSiteReadRepository;
        private readonly IVacancySummaryRepository _vacancySummaryRepository;

        public GetVacancySummariesStrategy(IProviderReadRepository providerReadRepository, IProviderSiteReadRepository providerSiteReadRepository, IVacancySummaryRepository vacancySummaryRepository)
        {
            _providerReadRepository = providerReadRepository;
            _providerSiteReadRepository = providerSiteReadRepository;
            _vacancySummaryRepository = vacancySummaryRepository;
        }

        public VacancySummariesPage GetVacancySummaries(string ukprn, string searchString, VacanciesSummaryFilterTypes filterType, VacancySearchMode searchMode, VacancyType vacancyType, Order order, VacancySummaryOrderByColumn orderBy, int page, int pageSize)
        {
            //TODO: Support employer access

            if (page < 1)
            {
                page = 1;
            }
            if (pageSize > 200)
            {
                pageSize = 200;
            }

            var provider = _providerReadRepository.GetByUkprn(ukprn);
            var providerSites = _providerSiteReadRepository.GetByProviderId(provider.ProviderId);
            var providerSiteId = providerSites.First().ProviderSiteId;
            
            var query = new VacancySummaryQuery
            {
                ProviderId = provider.ProviderId,
                ProviderSiteId = providerSiteId,
                OrderByField = orderBy,
                Filter = filterType,
                PageSize = pageSize,
                RequestedPage = page,
                SearchMode = searchMode,
                SearchString = searchString,
                Order = order,
                VacancyType = vacancyType
            };
            int totalRecords;
            var vacancySummaries = _vacancySummaryRepository.GetSummariesForProvider(query, out totalRecords);

            var vacancySummariesPage = new VacancySummariesPage
            {
                CurrentPage = page,
                TotalCount = totalRecords,
                TotalPages = totalRecords == 0 ? 1 : (int)Math.Ceiling((double)totalRecords / (double)pageSize),
                VacancySummaries = vacancySummaries
            };
            return vacancySummariesPage;
        }
    }
}