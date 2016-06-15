﻿namespace SFA.Apprenticeships.Infrastructure.Raa
{
    using Application.Interfaces.Employers;
    using Application.Interfaces.Providers;
    using SFA.Infrastructure.Interfaces;
    using Application.Interfaces.Vacancies;
    using Application.ReferenceData;
    using Application.Vacancy;
    using Domain.Entities.Exceptions;
    using Domain.Entities.Vacancies.Traineeships;
    using Domain.Raa.Interfaces.Repositories;
    using Mappers;

    public class TraineeshipVacancyDataProvider : IVacancyDataProvider<TraineeshipVacancyDetail>
    {
        private readonly IVacancyReadRepository _vacancyReadRepository;
        private readonly IProviderService _providerService;
        private readonly IEmployerService _employerService;
        private readonly IReferenceDataProvider _referenceDataProvider;
        private readonly ILogService _logService;

        public TraineeshipVacancyDataProvider(IVacancyReadRepository vacancyReadRepository, IProviderService providerService, IEmployerService employerService, IReferenceDataProvider referenceDataProvider, ILogService logService)
        {
            _vacancyReadRepository = vacancyReadRepository;
            _providerService = providerService;
            _employerService = employerService;
            _referenceDataProvider = referenceDataProvider;
            _logService = logService;
        }

        public TraineeshipVacancyDetail GetVacancyDetails(int vacancyId, bool errorIfNotFound = false)
        {
            var vacancy = _vacancyReadRepository.Get(vacancyId);

            if (vacancy == null)
            {
                if (errorIfNotFound)
                {
                    throw new DomainException(ErrorCodes.VacancyNotFoundError, new { vacancyId });
                }
                return null;
            }

            var vacancyParty = _providerService.GetVacancyParty(vacancy.OwnerPartyId, false); // Some current vacancies have non-current vacancy parties

            var employer = _employerService.GetEmployer(vacancyParty.EmployerId);

            var providerSite = _providerService.GetProviderSite(vacancyParty.ProviderSiteId);
            if (providerSite == null)
                throw new System.Exception($"Could not find VacancyParty for ProviderSiteId={vacancyParty.ProviderSiteId}");

            var provider = _providerService.GetProvider(providerSite.ProviderId);
            var categories = _referenceDataProvider.GetCategories();
            return TraineeshipVacancyDetailMapper.GetTraineeshipVacancyDetail(vacancy, vacancyParty, employer, provider, categories, _logService);
        }
    }
}