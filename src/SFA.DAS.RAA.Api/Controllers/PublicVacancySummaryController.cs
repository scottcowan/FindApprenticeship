namespace SFA.DAS.RAA.Api.Controllers
{
    using System;
    using System.Web.Http;
    using System.Web.Http.Description;
    using Apprenticeships.Application.VacancyPosting.Strategies;
    using Apprenticeships.Domain.Entities.Raa.Vacancies;
    using Apprenticeships.Domain.Raa.Interfaces.Repositories.Models;
    using Models;

    [RoutePrefix("public")]
    public class PublicVacancySummaryController : ApiController
    {
        private readonly IGetVacancySummaryStrategies _getVacancySummaryStrategies;

        public PublicVacancySummaryController(IGetVacancySummaryStrategies getVacancySummaryStrategies)
        {
            _getVacancySummaryStrategies = getVacancySummaryStrategies;
        }

        [Route("vacancysummaries")]
        [ResponseType(typeof(VacancySummariesPage))]
        [HttpGet]
        public IHttpActionResult GetAllLiveVacancySummaries(int page = 1, int pageSize = 5)
        {
            var query = new VacancySummaryByStatusQuery
            {
                PageSize = pageSize,
                RequestedPage = page,
                DesiredStatuses = new[] {VacancyStatus.Live}
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

            return Ok(vacancySummariesPage);
        }
    }
}