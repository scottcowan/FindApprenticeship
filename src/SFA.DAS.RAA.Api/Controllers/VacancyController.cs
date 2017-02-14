namespace SFA.DAS.RAA.Api.Controllers
{
    using System;
    using System.Web.Http;
    using System.Web.Http.Description;
    using Apprenticeships.Domain.Entities.Raa;
    using Apprenticeships.Domain.Entities.Raa.Vacancies;
    using Apprenticeships.Web.Common.Extensions;
    using Models;
    using Providers;
    using Strategies;

    [Authorize(Roles = Roles.Provider + "," + Roles.Agency)]
    public class VacancyController : ApiController
    {
        private readonly IVacancyProvider _vacancyProvider;
        private readonly ICreateVacancyStrategy _createVacancyStrategy;

        public VacancyController(IVacancyProvider vacancyProvider, ICreateVacancyStrategy createVacancyStrategy)
        {
            _vacancyProvider = vacancyProvider;
            _createVacancyStrategy = createVacancyStrategy;
        }

        [Route("vacancy/{id}")]
        [ResponseType(typeof(Vacancy))]
        [HttpGet]
        public IHttpActionResult GetById(int id)
        {
            return Ok(_vacancyProvider.Get(new VacancyIdentifier(id)));
        }

        [Route("vacancy/reference/{reference}")]
        [ResponseType(typeof(Vacancy))]
        [HttpGet]
        public IHttpActionResult GetByReferenceNumber(string reference)
        {
            return Ok(_vacancyProvider.Get(new VacancyIdentifier(reference)));
        }

        [Route("vacancy/guid/{guid}")]
        [ResponseType(typeof(Vacancy))]
        [HttpGet]
        public IHttpActionResult GetByGuid(Guid guid)
        {
            return Ok(_vacancyProvider.Get(new VacancyIdentifier(guid)));
        }

        /// <summary>
        /// CURRENTLY INCOMPLETE! DO NOT USE YET!
        /// Endpoint for creating a vacancy. Implements the full rule set for creating a valid vacancy but also allows you to create a partial vacancy that can be completed via the UI or API.
        /// Consult the model documentation for the list of required fields and rules.
        /// Please note that all vacancies created through this endpoint will have a Draft status. They need to be submitted separately.
        /// </summary>
        /// <param name="vacancy">The vacancy or partial vacancy to create</param>
        /// <returns>Either the created vacancy or a set of model errors explaining why the vacancy couldn't be created.</returns>
        [Route("vacancies")]
        [ResponseType(typeof(Vacancy))]
        [HttpPost]
        public IHttpActionResult CreateVacancy(Vacancy vacancy)
        {
            if (User.IsInRole(Roles.Provider))
            {
                return Ok(_createVacancyStrategy.CreateVacancy(vacancy, User.GetUkprn()));
            }
            if (User.IsInRole(Roles.Agency))
            {
                return Ok(_createVacancyStrategy.CreateVacancy(vacancy));
            }
            return Unauthorized();
        }
    }
}