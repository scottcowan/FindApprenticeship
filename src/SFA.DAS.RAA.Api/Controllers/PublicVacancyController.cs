namespace SFA.DAS.RAA.Api.Controllers
{
    using System;
    using System.Web.Http;
    using System.Web.Http.Description;
    using Apprenticeships.Domain.Entities.Raa.Vacancies;
    using Apprenticeships.Domain.Raa.Interfaces.Repositories;
    using Models;
    using Providers;
    using Strategies;

    [RoutePrefix("public/vacancy")]
    public class PublicVacancyController : ApiController
    {
        private readonly IVacancyProvider _vacancyProvider;

        public PublicVacancyController(IVacancyReadRepository vacancyReadRepository)
        {
            _vacancyProvider = new VacancyProvider(new GetPublicVacancyStrategies(vacancyReadRepository));
        }

        [Route("{id}")]
        [ResponseType(typeof(Vacancy))]
        [HttpGet]
        public IHttpActionResult GetById(int id)
        {
            return Ok(_vacancyProvider.Get(new VacancyIdentifier(id)));
        }

        [Route("reference/{reference}")]
        [ResponseType(typeof(Vacancy))]
        [HttpGet]
        public IHttpActionResult GetByReferenceNumber(string reference)
        {
            return Ok(_vacancyProvider.Get(new VacancyIdentifier(reference)));
        }

        [Route("guid/{guid}")]
        [ResponseType(typeof(Vacancy))]
        [HttpGet]
        public IHttpActionResult GetByGuid(Guid guid)
        {
            return Ok(_vacancyProvider.Get(new VacancyIdentifier(guid)));
        }
    }
}