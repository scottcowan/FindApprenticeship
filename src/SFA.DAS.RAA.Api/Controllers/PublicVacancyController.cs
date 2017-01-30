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

        /// <summary>
        /// Endpoint to retrieve a Live vacancy. Note that this endpoint will only return live vacancies and will return a more cut down vacancy object.
        /// This includes only the public facing vacancy data. If you need the full vacancy information for a vacancy you have access too, use the non public end point.
        /// </summary>
        /// <param name="id">The primary identifier for the vacancy</param>
        /// <returns>The public live vacancy if found</returns>
        [Route("{id}")]
        [ResponseType(typeof(PublicVacancy))]
        [HttpGet]
        public IHttpActionResult GetById(int id)
        {
            return Ok(_apiMappers.Map<Vacancy, PublicVacancy>(_vacancyProvider.Get(new VacancyIdentifier(id))));
        }

        /// <summary>
        /// Endpoint to retrieve a Live vacancy. Note that this endpoint will only return live vacancies and will return a more cut down vacancy object.
        /// This includes only the public facing vacancy data. If you need the full vacancy information for a vacancy you have access too, use the non public end point.
        /// </summary>
        /// <param name="reference">The secondary reference for the vacancy. Can be either the numerical part of the vacancy reference e.g. 123456 or the full version e.g. VAC000123456</param>
        /// <returns>The public live vacancy if found</returns>
        [Route("reference/{reference}")]
        [ResponseType(typeof(PublicVacancy))]
        [HttpGet]
        public IHttpActionResult GetByReferenceNumber(string reference)
        {
            return Ok(_apiMappers.Map<Vacancy, PublicVacancy>(_vacancyProvider.Get(new VacancyIdentifier(reference))));
        }

        /// <summary>
        /// Endpoint to retrieve a Live vacancy. Note that this endpoint will only return live vacancies and will return a more cut down vacancy object.
        /// This includes only the public facing vacancy data. If you need the full vacancy information for a vacancy you have access too, use the non public end point.
        /// </summary>
        /// <param name="guid">The secondary GUID identifier for the vacancy</param>
        /// <returns>The public live vacancy if found</returns>
        [Route("guid/{guid}")]
        [ResponseType(typeof(PublicVacancy))]
        [HttpGet]
        public IHttpActionResult GetByGuid(Guid guid)
        {
            return Ok(_apiMappers.Map<Vacancy, PublicVacancy>(_vacancyProvider.Get(new VacancyIdentifier(guid))));
        }
    }
}