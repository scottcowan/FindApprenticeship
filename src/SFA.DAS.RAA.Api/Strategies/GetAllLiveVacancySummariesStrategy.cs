namespace SFA.DAS.RAA.Api.Strategies
{
    using System;
    using Apprenticeships.Application.VacancyPosting.Strategies;
    using Apprenticeships.Domain.Entities.Raa.Vacancies;
    using Apprenticeships.Domain.Raa.Interfaces.Repositories.Models;
    using Models;

    public class GetAllLiveVacancySummariesStrategy : IGetAllLiveVacancySummariesStrategy
    {
        private readonly IGetVacancySummaryStrategies _getVacancySummaryStrategies;

        public GetAllLiveVacancySummariesStrategy(IGetVacancySummaryStrategies getVacancySummaryStrategies)
        {
            _getVacancySummaryStrategies = getVacancySummaryStrategies;
        }

        public VacancySummariesPage GetAllLiveVacancySummaries(int page, int pageSize)
        {
            if (page < 1)
            {
                page = 1;
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
            int resultsCount;
            var liveVacancySummaries = _getVacancySummaryStrategies.GetWithStatus(query, out resultsCount);
            var vacancySummariesPage = new VacancySummariesPage
            {
                CurrentPage = page,
                TotalCount = resultsCount,
                TotalPages = resultsCount == 0 ? 1 : (int)Math.Ceiling((double)resultsCount / (double)pageSize),
                VacancySummaries = liveVacancySummaries
            };
            return vacancySummariesPage;
        }
    }
}