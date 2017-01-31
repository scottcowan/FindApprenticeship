using System.Web.Http;

namespace SFA.DAS.RAA.Api.Controllers
{
    using Apprenticeships.Application.ReferenceData;
    using Apprenticeships.Domain.Entities.Raa.Vacancies;
    using System.Collections.Generic;
    using System.Web.Http.Description;

    public class StandardController : ApiController
    {
        private readonly IReferenceDataProvider _referenceDataProvider;

        public StandardController(IReferenceDataProvider referenceDataProvider)
        {
            _referenceDataProvider = referenceDataProvider;
        }

        [Route("standards")]
        [ResponseType(typeof(IEnumerable<StandardSubjectAreaTierOne>))]
        [HttpGet]
        public IHttpActionResult GetStandards()
        {
            return Ok(_referenceDataProvider.GetStandardSubjectAreaTierOnes());
        }
    }
}
