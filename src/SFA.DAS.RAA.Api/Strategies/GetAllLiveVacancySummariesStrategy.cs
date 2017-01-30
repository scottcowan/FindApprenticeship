namespace SFA.DAS.RAA.Api.Strategies
{
    using System;
    using System.Collections.Generic;
    using Apprenticeships.Application.Interfaces;
    using Apprenticeships.Application.VacancyPosting.Strategies;
    using Apprenticeships.Domain.Entities.Raa.Vacancies;
    using Apprenticeships.Domain.Raa.Interfaces.Repositories.Models;
    using Mappers;
    using Models;

    public class GetAllLiveVacancySummariesStrategy : IGetAllLiveVacancySummariesStrategy
    {
        private static readonly IMapper _apiMappers = new ApiMappers();

        private readonly IGetVacancySummaryStrategies _getVacancySummaryStrategies;

        public GetAllLiveVacancySummariesStrategy(IGetVacancySummaryStrategies getVacancySummaryStrategies)
        {
            _getVacancySummaryStrategies = getVacancySummaryStrategies;
        }

        public PublicVacancySummariesPage GetAllLiveVacancySummaries(int page, int pageSize)
        {
            if (page < 1)
            {
                page = 1;
            }
            if (pageSize < 1)
            {
                pageSize = 1;
            }
            if (pageSize > 50)
            {
                pageSize = 50;
            }

            var query = new VacancySummaryByStatusQuery
            {
                PageSize = pageSize,
                RequestedPage = page,
                DesiredStatuses = new[] { VacancyStatus.Live }
            };
            int totalRecords;
            var liveVacancySummaries = _getVacancySummaryStrategies.GetWithStatus(query, out totalRecords);
            var vacancySummariesPage = new PublicVacancySummariesPage
            {
                CurrentPage = page,
                TotalCount = totalRecords,
                TotalPages = totalRecords == 0 ? 1 : (int)Math.Ceiling((double)totalRecords / (double)pageSize),
                VacancySummaries = _apiMappers.Map<IList<VacancySummary>, IList<PublicVacancySummary>>(liveVacancySummaries)
            };
            return vacancySummariesPage;
        }
    }
}