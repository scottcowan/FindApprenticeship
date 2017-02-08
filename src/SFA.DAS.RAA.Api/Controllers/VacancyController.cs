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

        [Route("vacancies")]
        [ResponseType(typeof(Vacancy))]
        [HttpPost]
        public IHttpActionResult CreateVacancy(Vacancy vacancy)
        {
            return Ok(_createVacancyStrategy.CreateVacancy(vacancy, User.GetUkprn()));
        }
    }
}