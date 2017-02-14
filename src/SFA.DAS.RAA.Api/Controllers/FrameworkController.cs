﻿using System.Web.Http;

namespace SFA.DAS.RAA.Api.Controllers
{
    using Apprenticeships.Domain.Entities.Raa.Reference;
    using Apprenticeships.Domain.Entities.ReferenceData;
    using Strategies;
    using System.Collections.Generic;
    using System.Web.Http.Description;

    /// <summary>
    /// Framework Controller for API
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
        /// <returns>A list of Category objects</returns>
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
        /// <returns>Returns a Category object</returns>
        [Route("framework/{id}")]
        [ResponseType(typeof(Framework))]
        [HttpGet]
        public IHttpActionResult GetFrameworkById(int id)
        {
            return Ok(_getFrameworksStrategy.GetFramework(id));
        }
    }
}
