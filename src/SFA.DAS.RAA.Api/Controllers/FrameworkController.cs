using System.Web.Http;

namespace SFA.DAS.RAA.Api.Controllers
{
    using Apprenticeships.Application.ReferenceData;
    using Apprenticeships.Domain.Entities.ReferenceData;
    using System.Collections.Generic;
    using System.Web.Http.Description;

    public class FrameworkController : ApiController
    {
        private readonly IReferenceDataProvider _referenceDataProvider;

        public FrameworkController(IReferenceDataProvider referenceDataProvider)
        {
            _referenceDataProvider = referenceDataProvider;
        }

        [Route("frameworks")]
        [ResponseType(typeof(IEnumerable<Category>))]
        [HttpGet]
        public IHttpActionResult GetFrameworks()
        {
            return Ok(_referenceDataProvider.GetFrameworks());
        }
    }
}
