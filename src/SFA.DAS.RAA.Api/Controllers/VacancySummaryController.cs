using System.Threading.Tasks;
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

        /// <summary>
        /// Endpoint for retrieving a list of vacancy summaries associated with the supplied api key. Note that this endpoint will return a more cut down vacancy object.
        /// All parameters are optional.
        /// </summary>
        /// <param name="searchString">Text to search for within the fields selected by the <paramref name="searchMode" /> parameter</param>
        /// <param name="searchMode">The fields to search for any specified <paramref name="searchString"/> in. Defaulted to All where not specified</param>
        /// <param name="vacancyType">Search either Apprenticeships or Traineeships. Defaulted to Apprenticeships where not specified</param>
        /// <param name="order">The order in which the results are presented. Specify the field to order by using the <paramref name="orderBy"/> parameter. Defaulted to Ascending where not specified</param>
        /// <param name="orderBy">The field to order the results by. Defaulted to Title where not specified</param>
        /// <param name="filterType">The vacancy status to filter the results by. Defaulted to All where not specified</param>
        /// <param name="page">The page of vacancies required. If this is less than 1 or greater than the total number of pages, it will be set to 1 or the last page respectively</param>
        /// <param name="pageSize">The number of vacancies to return per page up to a maximum of 250. Values larger than this will be set to 250</param>
        /// <returns></returns>
        [Route("vacancies")]
        [ResponseType(typeof(VacancySummariesPage))]
        [HttpGet]
        public async Task<IHttpActionResult> GetVacancySummaries(string searchString = null, 
            VacancySearchMode searchMode = VacancySearchMode.All, 
            VacancyType vacancyType = VacancyType.Apprenticeship, 
            Order order = Order.Ascending,
            VacancySummaryOrderByColumn orderBy = VacancySummaryOrderByColumn.Title, 
            VacanciesSummaryFilterTypes filterType = VacanciesSummaryFilterTypes.All, 
            int page = 1, 
            int pageSize = 25)
        {
            var list = await _getVacancySummariesStrategy.GetVacancySummaries(User.GetUkprn(), searchString, filterType,
                searchMode, vacancyType, order, orderBy, page, pageSize);

            var vacancyPage = new VacancySummariesPage()
            {
                VacancySummaries = list,
                TotalCount = list.TotalCount,
                CurrentPage = page,
                TotalPages = list.TotalCount / pageSize
            };

            return Ok(vacancyPage);
        }
    }
}