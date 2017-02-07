using System.ComponentModel.DataAnnotations;
using SFA.Apprenticeships.Domain.Entities.Raa.Vacancies;

namespace SFA.DAS.RAA.Api.Controllers
{
    using System.Web.Http;
    using System.Web.Http.Description;
    using Apprenticeships.Domain.Entities.Raa;
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

        [Route("vacancies")]
        [ResponseType(typeof(VacancySummariesPage))]
        [HttpGet]
        public IHttpActionResult GetVacancySummaries(string searchString = null, 
            VacancySearchMode searchMode = VacancySearchMode.All, 
            VacancyType vacancyType = VacancyType.Apprenticeship, 
            Order order = Order.Ascending,
            VacancySummaryOrderByColumn orderBy = VacancySummaryOrderByColumn.Title, 
            VacanciesSummaryFilterTypes filterType = VacanciesSummaryFilterTypes.All, 
            int page = 1, 
            int pageSize = 25)
        {
            return Ok(_getVacancySummariesStrategy.GetVacancySummaries(User.GetUkprn(), searchString, filterType, searchMode, vacancyType, order, orderBy, page, pageSize));
        }
    }
}