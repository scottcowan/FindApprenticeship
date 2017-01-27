namespace SFA.DAS.RAA.Api.Controllers
{
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

        [Route("vacancysummaries")]
        [ResponseType(typeof(VacancySummariesPage))]
        [HttpGet]
        public IHttpActionResult GetAllLiveVacancySummaries(int page = 1, int pageSize = 25)
        {
            return Ok(_getAllLiveVacancySummariesStrategy.GetAllLiveVacancySummaries(page, pageSize));
        }
    }
}