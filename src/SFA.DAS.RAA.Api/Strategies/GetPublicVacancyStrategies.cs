namespace SFA.DAS.RAA.Api.Strategies
{
    using System;
    using Apprenticeships.Application.VacancyPosting.Strategies;
    using Apprenticeships.Domain.Entities.Raa.Vacancies;
    using Apprenticeships.Domain.Raa.Interfaces.Repositories;

    public class GetPublicVacancyStrategies : IGetVacancyStrategies
    {
        private readonly IVacancyReadRepository _vacancyReadRepository;

        public GetPublicVacancyStrategies(IVacancyReadRepository vacancyReadRepository)
        {
            _vacancyReadRepository = vacancyReadRepository;
        }

        public Vacancy GetVacancyByReferenceNumber(int vacancyReferenceNumber)
        {
            var vacancy = _vacancyReadRepository.GetByReferenceNumber(vacancyReferenceNumber);
            return GetLiveVacancy(vacancy);
        }

        public Vacancy GetVacancyByGuid(Guid vacancyGuid)
        {
            var vacancy = _vacancyReadRepository.GetByVacancyGuid(vacancyGuid);
            return GetLiveVacancy(vacancy);
        }

        public Vacancy GetVacancyById(int vacancyId)
        {
            var vacancy = _vacancyReadRepository.Get(vacancyId);
            return GetLiveVacancy(vacancy);
        }

        private static Vacancy GetLiveVacancy(Vacancy vacancy)
        {
            return vacancy.Status == VacancyStatus.Live ? vacancy : null;
        }
    }
}