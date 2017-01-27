namespace SFA.DAS.RAA.Api.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Http;
    using System.Web.Http.Description;
    using Apprenticeships.Domain.Entities.Raa;
    using Apprenticeships.Domain.Entities.Raa.Vacancies;
    using Apprenticeships.Domain.Raa.Interfaces.Repositories;
    using Apprenticeships.Domain.Raa.Interfaces.Repositories.Models;
    using Apprenticeships.Web.Common.Extensions;
    using Models;
    using Strategies;

    [Authorize(Roles = Roles.Provider)]
    public class VacancySummaryController : ApiController
    {
        private readonly IGetVacancySummariesStrategy _getVacancySummariesStrategy;

        public VacancySummaryController(IGetVacancySummariesStrategy getVacancySummariesStrategy)
        {
            _getVacancySummariesStrategy = getVacancySummariesStrategy;
        }

        [Route("vacancysummaries")]
        [ResponseType(typeof(VacancySummariesPage))]
        [HttpGet]
        public IHttpActionResult GetVacancySummaries(VacanciesSummaryFilterTypes filterType = VacanciesSummaryFilterTypes.All, int page = 1, int pageSize = 25)
        {
            return Ok(_getVacancySummariesStrategy.GetVacancySummaries(User.GetUkprn(), filterType, page, pageSize));
        }
    }
}