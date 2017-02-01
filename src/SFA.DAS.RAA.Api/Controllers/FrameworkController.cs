using System.Web.Http;

namespace SFA.DAS.RAA.Api.Controllers
{
    using Apprenticeships.Domain.Entities.ReferenceData;
    using Strategies;
    using System.Collections.Generic;
    using System.Web.Http.Description;

    /// <summary>
    /// FrameworkController
    /// </summary>
    public class FrameworkController : ApiController
    {
        private readonly IGetFrameworksStrategy _getFrameworksStrategy;

        /// <summary>
        /// FrameworkController constructor
        /// </summary>
        /// <param name="getFrameworksStrategy"></param>
        public FrameworkController(IGetFrameworksStrategy getFrameworksStrategy)
        {
            _getFrameworksStrategy = getFrameworksStrategy;
        }

        /// <summary>
        /// Gets all frameworks
        /// </summary>
        /// <returns></returns>
        [Route("frameworks")]
        [ResponseType(typeof(IEnumerable<Category>))]
        [HttpGet]
        public IHttpActionResult GetFrameworks()
        {
            return Ok(_getFrameworksStrategy.GetFrameworks());
        }

        /// <summary>
        /// Returns the information for the framework identified by the primary identifier in the URL
        /// </summary>
        /// <param name="id">The framework's primary identifier</param>
        /// <returns>The Category object</returns>
        [Route("framework/{id}")]
        [ResponseType(typeof(Category))]
        [HttpGet]
        public IHttpActionResult GetFrameworkById(int id)
        {
            return Ok(_getFrameworksStrategy.GetFramework(id));
        }
    }
}
