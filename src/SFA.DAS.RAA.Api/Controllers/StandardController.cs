using System.Web.Http;

namespace SFA.DAS.RAA.Api.Controllers
{
    using Apprenticeships.Domain.Entities.Raa.Vacancies;
    using Strategies;
    using System.Collections.Generic;
    using System.Web.Http.Description;

    /// <summary>
    /// Standards Controller for API
    /// </summary>
    public class StandardController : ApiController
    {
        private readonly IGetStandardsStrategy _getStandardsStrategy;

        /// <summary>
        /// Controller constructor
        /// </summary>
        /// <param name="getStandardsStrategy"></param>
        public StandardController(IGetStandardsStrategy getStandardsStrategy)
        {
            _getStandardsStrategy = getStandardsStrategy;
        }

        /// <summary>
        /// Gets all standards
        /// </summary>
        /// <returns></returns>
        [Route("standards")]
        [ResponseType(typeof(IEnumerable<StandardSubjectAreaTierOne>))]
        [HttpGet]
        public IHttpActionResult GetStandards()
        {
            return Ok(_getStandardsStrategy.GetStandards());
        }

        /// <summary>
        /// Returns the information for the standard identified by the primary identifier in the URL
        /// </summary>
        /// <param name="id">The standard's primary identifier</param>
        /// <returns>The StandardSubjectAreaTierOne object</returns>
        [Route("standard/{id}")]
        [ResponseType(typeof(Standard))]
        [HttpGet]
        public IHttpActionResult GetStandardById(int id)
        {
            return Ok(_getStandardsStrategy.GetStandard(id));
        }
    }
}
