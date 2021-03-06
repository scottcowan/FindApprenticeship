﻿namespace SFA.Apprenticeships.Application.Vacancy
{
    using Domain.Raa.Interfaces.Repositories;
    using Interfaces.Vacancies;

    public class CandidateVacancyService : ICandidateVacancyService
    {
        private readonly IVacancyWriteRepository _vacancyWriteRepository;

        public CandidateVacancyService(IVacancyWriteRepository vacancyWriteRepository)
        {
            _vacancyWriteRepository = vacancyWriteRepository;
        }

        public void IncrementOfflineApplicationClickThrough(int vacancyId)
        {
            _vacancyWriteRepository.IncrementOfflineApplicationClickThrough(vacancyId);
        }
    }
}