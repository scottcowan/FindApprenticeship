namespace SFA.DAS.RAA.Api.Controllers
{
    using System;
    using System.Web.Http;
    using System.Web.Http.Description;
    using Apprenticeships.Application.Interfaces;
    using Apprenticeships.Domain.Entities.Raa.Vacancies;
    using Apprenticeships.Domain.Raa.Interfaces.Repositories;
    using Mappers;
    using Models;
    using Providers;
    using Strategies;

    [RoutePrefix("public/vacancy")]
    public class PublicVacancyController : ApiController
    {
        private static readonly IMapper _apiMappers = new ApiMappers();

        private readonly IVacancyProvider _vacancyProvider;

        public PublicVacancyController(IVacancyReadRepository vacancyReadRepository)
        {
            _vacancyProvider = new VacancyProvider(new GetPublicVacancyStrategies(vacancyReadRepository));
        }

        [Route("{id}")]
        [ResponseType(typeof(PublicVacancy))]
        [HttpGet]
        public IHttpActionResult GetById(int id)
        {
            return Ok(_apiMappers.Map<Vacancy, PublicVacancy>(_vacancyProvider.Get(new VacancyIdentifier(id))));
        }

        [Route("reference/{reference}")]
        [ResponseType(typeof(PublicVacancy))]
        [HttpGet]
        public IHttpActionResult GetByReferenceNumber(string reference)
        {
            return Ok(_apiMappers.Map<Vacancy, PublicVacancy>(_vacancyProvider.Get(new VacancyIdentifier(reference))));
        }

        [Route("guid/{guid}")]
        [ResponseType(typeof(PublicVacancy))]
        [HttpGet]
        public IHttpActionResult GetByGuid(Guid guid)
        {
            return Ok(_apiMappers.Map<Vacancy, PublicVacancy>(_vacancyProvider.Get(new VacancyIdentifier(guid))));
        }
    }
}