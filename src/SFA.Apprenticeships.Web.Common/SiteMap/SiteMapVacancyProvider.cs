﻿namespace SFA.Apprenticeships.Web.Common.SiteMap
{
    using System.Collections.Generic;
    using System.Linq;
    using Domain.Interfaces.Caching;

    public class SiteMapVacancyProvider : ISiteMapVacancyProvider
    {
        private const string CacheKey = "SiteMap.Vacancies";
        private readonly ICacheService _cacheService;

        public SiteMapVacancyProvider(ICacheService cacheService)
        {
            _cacheService = cacheService;
        }

        public IEnumerable<SiteMapVacancy> GetVacancies()
        {
            return _cacheService.Get<SiteMapVacancy[]>(CacheKey);
        }

        public void SetVacancies(IEnumerable<SiteMapVacancy> siteMapVacancies)
        {
            // TODO: AG: US438: review cache duration.
            _cacheService.PutObject(CacheKey, siteMapVacancies.ToArray(), CacheDuration.OneDay);
        }
    }
}