﻿namespace SFA.Apprenticeships.Web.Raa.Common.Providers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Application.Interfaces.Employers;
    using Application.Interfaces.Providers;
    using Application.Interfaces.VacancyPosting;
    using Configuration;
    using Converters;
    using Domain.Entities.Raa.Vacancies;

    using SFA.Apprenticeships.Application.Interfaces;
    using SFA.Infrastructure.Interfaces;
    using ViewModels.Provider;
    using ViewModels.VacancyPosting;
    using Web.Common.Converters;

    public class ProviderProvider : IProviderProvider, IProviderQAProvider
    {
        private readonly IVacancyPostingService _vacancyPostingService;
        private readonly IProviderService _providerService;
        private readonly IEmployerService _employerService;
        private readonly IConfigurationService _configurationService;

        public ProviderProvider(IProviderService providerService, IConfigurationService configurationService, IVacancyPostingService vacancyPostingService, IEmployerService employerService)
        {
            _providerService = providerService;
            _configurationService = configurationService;
            _vacancyPostingService = vacancyPostingService;
            _employerService = employerService;
        }

        public ProviderViewModel GetProviderViewModel(string ukprn)
        {
            var provider = _providerService.GetProvider(ukprn);
            var providerSites = _providerService.GetProviderSites(ukprn);

            return provider.Convert(providerSites);
        }

        public ProviderViewModel GetProviderViewModel(int providerId)
        {
            var provider = _providerService.GetProvider(providerId);
            var providerSites = _providerService.GetProviderSites(provider.Ukprn);

            return provider.Convert(providerSites);
        }

        public ProviderSiteViewModel GetProviderSiteViewModel(string edsUrn)
        {
            var providerSite = _providerService.GetProviderSite(edsUrn);

            return providerSite.Convert();
        }

        public IEnumerable<ProviderSiteViewModel> GetProviderSiteViewModels(string ukprn)
        {
            var providerSites = _providerService.GetProviderSites(ukprn);
            return providerSites.Select(ps => ps.Convert());
        }

        public VacancyPartyViewModel GetVacancyPartyViewModel(int vacancyPartyId)
        {
            var vacancyParty = _providerService.GetVacancyParty(vacancyPartyId, true);
            var employer = _employerService.GetEmployer(vacancyParty.EmployerId);
            return vacancyParty.Convert(employer);
        }

        public VacancyPartyViewModel GetVacancyPartyViewModel(int providerSiteId, string edsUrn)
        {
            var vacancyParty = _providerService.GetVacancyParty(providerSiteId, edsUrn);
            var employer = _employerService.GetEmployer(vacancyParty.EmployerId);
            return vacancyParty.Convert(employer);
        }

        public VacancyPartyViewModel ConfirmVacancyParty(VacancyPartyViewModel viewModel)
        {
            var vacancyParty = _providerService.GetVacancyParty(viewModel.ProviderSiteId, viewModel.Employer.EdsUrn);
            vacancyParty.EmployerWebsiteUrl = viewModel.EmployerWebsiteUrl;
            vacancyParty.EmployerDescription = viewModel.EmployerDescription;
            vacancyParty = _providerService.SaveVacancyParty(vacancyParty);

            var vacancy = GetVacancy(viewModel);
            if (vacancy != null)
            {
                vacancy.OwnerPartyId = vacancyParty.VacancyPartyId;
                vacancy.EmployerWebsiteUrl = vacancyParty.EmployerWebsiteUrl;
                vacancy.EmployerDescription = vacancyParty.EmployerDescription;
                if (viewModel.IsEmployerLocationMainApprenticeshipLocation != null)
                    vacancy.IsEmployerLocationMainApprenticeshipLocation =
                        viewModel.IsEmployerLocationMainApprenticeshipLocation.Value;
                if (viewModel.NumberOfPositions != null) vacancy.NumberOfPositions = viewModel.NumberOfPositions.Value;

                _vacancyPostingService.UpdateVacancy(vacancy);
            }

            var employer = _employerService.GetEmployer(vacancyParty.EmployerId);
            var result = vacancyParty.Convert(employer);
            
            return result;
        }

        private Vacancy GetVacancy(VacancyPartyViewModel viewModel)
        {
            var vacancy = _vacancyPostingService.GetVacancy(viewModel.VacancyGuid) ??
                          _vacancyPostingService.GetVacancyByReferenceNumber(viewModel.VacancyReferenceNumber);

            return vacancy;
        }

        public EmployerSearchViewModel GetVacancyPartyViewModels(int providerSiteId)
        {
            var pageSize = _configurationService.Get<RecruitWebConfiguration>().PageSize;
            var parameters = new EmployerSearchRequest(providerSiteId);
            var vacancyParties = _providerService.GetVacancyParties(parameters, 1, pageSize);

            var employerIds = vacancyParties.Page
                .Select(vacancyParty => vacancyParty.EmployerId)
                .Distinct();

            var employers = _employerService.GetEmployers(employerIds);

            var resultsPage = vacancyParties.ToViewModel(vacancyParties.Page
                // Exclude employers from search results that are NOT returned from Employer Service, status may be 'Suspended' etc.
                .Where(vacancyParty => employers
                    .Any(employer => employer.EmployerId == vacancyParty.EmployerId))
                .Select(vacancyParty => vacancyParty.Convert(employers.Single(employer => employer.EmployerId == vacancyParty.EmployerId))
                    .Employer
                    .ConvertToResult()));

            return new EmployerSearchViewModel
            {
                ProviderSiteId = providerSiteId,
                EmployerResultsPage = resultsPage
            };
        }

        public EmployerSearchViewModel GetVacancyPartyViewModels(EmployerSearchViewModel viewModel)
        {
            EmployerSearchRequest parameters;

            switch (viewModel.FilterType)
            {
                case EmployerFilterType.EdsUrn:
                    parameters = new EmployerSearchRequest(viewModel.ProviderSiteId, viewModel.EdsUrn);
                    break;
                case EmployerFilterType.NameAndLocation:
                    parameters = new EmployerSearchRequest(viewModel.ProviderSiteId, viewModel.Name, viewModel.Location);
                    break;
                case EmployerFilterType.Undefined:
                    parameters = new EmployerSearchRequest(viewModel.ProviderSiteId);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(viewModel), viewModel.FilterType, string.Empty);
            }

            var pageSize = _configurationService.Get<RecruitWebConfiguration>().PageSize;
            var vacancyParties = _providerService.GetVacancyParties(parameters, viewModel.EmployerResultsPage.CurrentPage, pageSize);

            var employerIds = vacancyParties.Page
                .Select(vp => vp.EmployerId)
                .Distinct();

            var employers = _employerService.GetEmployers(employerIds);

            var resultsPage = vacancyParties.ToViewModel(vacancyParties.Page
                // Exclude employers from search results that are NOT returned from Employer Service, status may be 'Suspended' etc.
                .Where(vacancyParty => employers
                    .Any(employer => employer.EmployerId == vacancyParty.EmployerId))
                .Select(vacancyParty => vacancyParty.Convert(employers.Single(employer => employer.EmployerId == vacancyParty.EmployerId))
                    .Employer
                    .ConvertToResult()));

            viewModel.EmployerResultsPage = resultsPage;

            return viewModel;
        }
    }
}
