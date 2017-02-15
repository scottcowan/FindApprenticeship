namespace SFA.DAS.RAA.Api.Controllers
{
    using System.Threading.Tasks;
    using System.Web.Http;
    using System.Web.Http.Description;
    using Models;
    using Strategies;

    [RoutePrefix("public")]
    public class PublicVacancySummaryController : ApiController
    {
        private readonly IGetAllLiveVacancySummariesStrategy _getAllLiveVacancySummariesStrategy;

        public PublicVacancySummaryController(IGetAllLiveVacancySummariesStrategy getAllLiveVacancySummariesStrategy)
        {
            _getAllLiveVacancySummariesStrategy = getAllLiveVacancySummariesStrategy;
        }

        /// <summary>
        /// Endpoint to retrieve a page of Live vacancy summaries. Note that this endpoint will only return live vacancies and will return a more cut down vacancy object.
        /// This includes only the public facing vacancy data. If you need the full vacancy information for a vacancy you have access to, use the non public end point.
        /// </summary>
        /// <param name="page">The page of vacancies required. If this is less than 1 or greater than the total number of pages, it will be set to 1 or the last page respectively</param>
        /// <param name="pageSize">The number of vacancies to return per page up to a maximum of 250. Values larger than this will be set to 250</param>
        /// <returns>The requested page of live vacancy summaries along with the total number of vacancies and pages available. Vacancies are ordered by date submitted</returns>
        [Route("vacancysummaries")]
        [ResponseType(typeof(PublicVacancySummariesPage))]
        [HttpGet]
        public async Task<IHttpActionResult> GetAllLiveVacancySummaries(int page = 1, int pageSize = 25)
        {
            return Ok(await _getAllLiveVacancySummariesStrategy.GetAllLiveVacancySummaries(page, pageSize));
        }
    }
}