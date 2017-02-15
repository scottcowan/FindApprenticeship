namespace SFA.DAS.RAA.Api.Strategies
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Apprenticeships.Application.Interfaces;
    using Apprenticeships.Domain.Entities.Raa.Vacancies;
    using Apprenticeships.Domain.Raa.Interfaces.Repositories;
    using Apprenticeships.Domain.Raa.Interfaces.Repositories.Models;
    using Mappers;
    using Models;

    public class GetAllLiveVacancySummariesStrategy : IGetAllLiveVacancySummariesStrategy
    {
        private static readonly IMapper _apiMappers = new ApiMappers();

        private readonly IVacancySummaryRepository _vacancySummaryRepository;

        public GetAllLiveVacancySummariesStrategy(IVacancySummaryRepository vacancySummaryRepository)
        {
            _vacancySummaryRepository = vacancySummaryRepository;
        }

        public async Task<PublicVacancySummariesPage> GetAllLiveVacancySummaries(int page, int pageSize)
        {
            if (page < 1)
            {
                page = 1;
            }
            if (pageSize < 1)
            {
                pageSize = 1;
            }
            if (pageSize > 250)
            {
                pageSize = 250;
            }

            var query = new VacancySummaryByStatusQuery
            {
                PageSize = pageSize,
                RequestedPage = page,
                DesiredStatuses = new[] { VacancyStatus.Live }
            };
            var liveVacancySummaries = await _vacancySummaryRepository.GetLiveAsync(query);
            var totalRecords = liveVacancySummaries.TotalCount;
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