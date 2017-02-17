namespace SFA.DAS.RAA.Api.Controllers
{
    using Apprenticeships.Domain.Entities.Raa;
    using Apprenticeships.Domain.Entities.Raa.Parties;
    using Apprenticeships.Web.Common.Extensions;
    using Models;
    using Strategies;
    using System.Web.Http;
    using System.Web.Http.Description;

    [Authorize(Roles = Roles.Provider)]
    [RoutePrefix("employer")]
    public class EmployerController : ApiController
    {
        private readonly ILinkEmployerStrategy _linkEmployerStrategy;

        public EmployerController(ILinkEmployerStrategy linkEmployerStrategy)
        {
            _linkEmployerStrategy = linkEmployerStrategy;
        }

        /// <summary>
        /// Endpoint for linking an employer to a provider site.
        /// </summary>
        /// <param name="employerProviderSiteLinkRequest">Defines the provider site to link to as well as additional employer information. Note that you can specify the employer identifier in either the URL or the POST body</param>
        /// <param name="edsUrn">The employer's secondary identifier.</param>
        /// <returns></returns>
        [Route("edsurn/{edsUrn}/link")]
        [ResponseType(typeof(EmployerProviderSiteLink))]
        [HttpPost]
        public IHttpActionResult LinkEmployerByEdsUrn(EmployerProviderSiteLinkRequest employerProviderSiteLinkRequest, int edsUrn)
        {
            return Ok(_linkEmployerStrategy.LinkEmployer(employerProviderSiteLinkRequest, edsUrn, User.GetUkprn()));
        }

        [Route("edsurn/{edsUrn}")]
        [ResponseType(typeof(Employer))]
        [HttpGet]
        public IHttpActionResult FindEmployerByEdsUrn(int edsUrn)
        {
            return Ok();
        }

        [Route("employersummaries")]
        [ResponseType(typeof(EmployerSummariesPage))]
        [HttpGet]
        public IHttpActionResult FindEmployer(string name, string location, int page = 1, int pageSize = 10)
        {
            return Ok();
        }
    }

    public class EmployerSummariesPage
    {
    }
}