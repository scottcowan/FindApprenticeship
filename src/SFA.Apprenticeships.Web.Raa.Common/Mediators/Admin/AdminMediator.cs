﻿namespace SFA.Apprenticeships.Web.Raa.Common.Mediators.Admin
{
    using Application.Interfaces;
    using Application.Interfaces.Providers;
    using Application.Interfaces.VacancyPosting;
    using Constants.ViewModels;
    using Domain.Entities.Exceptions;
    using Domain.Entities.Raa.Vacancies;
    using Domain.Entities.Vacancies;
    using Providers;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Validators.Provider;
    using ViewModels.Admin;
    using ViewModels.Provider;
    using Web.Common.Constants;
    using Web.Common.Mediators;

    public class AdminMediator : MediatorBase, IAdminMediator
    {
        private readonly ProviderSearchViewModelServerValidator _providerSearchViewModelServerValidator = new ProviderSearchViewModelServerValidator();
        private readonly ProviderViewModelServerValidator _providerViewModelServerValidator = new ProviderViewModelServerValidator();
        private readonly ProviderSiteSearchViewModelServerValidator _providerSiteSearchViewModelServerValidator = new ProviderSiteSearchViewModelServerValidator();
        private readonly ProviderSiteViewModelServerValidator _providerSiteViewModelServerValidator = new ProviderSiteViewModelServerValidator();
        private readonly ProviderSiteRelationshipViewModelServerValidator _providerSiteRelationshipViewModelServerValidator = new ProviderSiteRelationshipViewModelServerValidator();
        private readonly IProviderProvider _providerProvider;
        private readonly ILogService _logService;
        private readonly IVacancyPostingService _vacancyPostingService;
        private readonly IProviderService _providerService;
        private readonly IVacancyPostingProvider _vacancyPostingProvider;

        public AdminMediator(IProviderProvider providerProvider, ILogService logService, IVacancyPostingService vacancyPostingService,
            IProviderService providerService, IVacancyPostingProvider vacancyPostingProvider)
        {
            _providerProvider = providerProvider;
            _logService = logService;
            _vacancyPostingService = vacancyPostingService;
            _providerService = providerService;
            _vacancyPostingProvider = vacancyPostingProvider;
        }

        public MediatorResponse<ProviderSearchResultsViewModel> SearchProviders(ProviderSearchViewModel searchViewModel)
        {
            var validatonResult = _providerSearchViewModelServerValidator.Validate(searchViewModel);

            if (!validatonResult.IsValid)
            {
                return GetMediatorResponse(AdminMediatorCodes.SearchProviders.FailedValidation, new ProviderSearchResultsViewModel { SearchViewModel = searchViewModel }, validatonResult);
            }

            var viewModel = _providerProvider.SearchProviders(searchViewModel);

            return GetMediatorResponse(AdminMediatorCodes.SearchProviders.Ok, viewModel);
        }

        public MediatorResponse<ProviderViewModel> GetProvider(int providerId)
        {
            var viewModel = _providerProvider.GetProviderViewModel(providerId);

            return GetMediatorResponse(AdminMediatorCodes.GetProvider.Ok, viewModel);
        }

        public MediatorResponse<ProviderViewModel> CreateProvider(ProviderViewModel viewModel)
        {
            var validatonResult = _providerViewModelServerValidator.Validate(viewModel);

            if (!validatonResult.IsValid)
            {
                return GetMediatorResponse(AdminMediatorCodes.CreateProvider.FailedValidation, viewModel, validatonResult);
            }

            var existingViewModel = _providerProvider.GetProviderViewModel(viewModel.Ukprn, false);
            if (existingViewModel != null)
            {
                return GetMediatorResponse(AdminMediatorCodes.CreateProvider.UkprnAlreadyExists, viewModel, ProviderViewModelMessages.UkprnAlreadyExists, UserMessageLevel.Error);
            }

            viewModel = _providerProvider.CreateProvider(viewModel);

            return GetMediatorResponse(AdminMediatorCodes.CreateProvider.Ok, viewModel, ProviderViewModelMessages.ProviderCreatedSuccessfully, UserMessageLevel.Info);
        }

        public MediatorResponse<ProviderSiteSearchResultsViewModel> SearchProviderSites(ProviderSiteSearchViewModel searchViewModel)
        {
            var validatonResult = _providerSiteSearchViewModelServerValidator.Validate(searchViewModel);

            if (!validatonResult.IsValid)
            {
                return GetMediatorResponse(AdminMediatorCodes.SearchProviderSites.FailedValidation, new ProviderSiteSearchResultsViewModel { SearchViewModel = searchViewModel }, validatonResult);
            }

            var viewModel = _providerProvider.SearchProviderSites(searchViewModel);

            return GetMediatorResponse(AdminMediatorCodes.SearchProviderSites.Ok, viewModel);
        }

        public MediatorResponse<ProviderSiteViewModel> GetProviderSite(int providerSiteId)
        {
            var viewModel = _providerProvider.GetProviderSiteViewModel(providerSiteId);

            return GetMediatorResponse(AdminMediatorCodes.GetProviderSite.Ok, viewModel);
        }

        public MediatorResponse<ProviderSiteViewModel> CreateProviderSite(ProviderSiteViewModel viewModel)
        {
            var validatonResult = _providerSiteViewModelServerValidator.Validate(viewModel);

            if (!validatonResult.IsValid)
            {
                return GetMediatorResponse(AdminMediatorCodes.CreateProviderSite.FailedValidation, viewModel, validatonResult);
            }

            var existingViewModel = _providerProvider.GetProviderSiteViewModel(viewModel.EdsUrn);
            if (existingViewModel != null)
            {
                return GetMediatorResponse(AdminMediatorCodes.CreateProviderSite.EdsUrnAlreadyExists, viewModel, ProviderSiteViewModelMessages.EdsUrnAlreadyExists, UserMessageLevel.Error);
            }

            viewModel = _providerProvider.CreateProviderSite(viewModel);

            return GetMediatorResponse(AdminMediatorCodes.CreateProviderSite.Ok, viewModel, ProviderSiteViewModelMessages.ProviderSiteCreatedSuccessfully, UserMessageLevel.Info);
        }

        public MediatorResponse<ProviderSiteViewModel> SaveProviderSite(ProviderSiteViewModel viewModel)
        {
            try
            {
                viewModel = _providerProvider.SaveProviderSite(viewModel);

                return GetMediatorResponse(AdminMediatorCodes.SaveProviderSite.Ok, viewModel, ProviderSiteViewModelMessages.ProviderSiteSavedSuccessfully, UserMessageLevel.Info);
            }
            catch (Exception ex)
            {
                _logService.Error($"Failed to save provider site with id={viewModel.ProviderSiteId}", ex);
                viewModel = _providerProvider.GetProviderSiteViewModel(viewModel.ProviderSiteId);
                return GetMediatorResponse(AdminMediatorCodes.SaveProviderSite.Error, viewModel, ProviderSiteViewModelMessages.ProviderSiteSaveError, UserMessageLevel.Error);
            }
        }

        public MediatorResponse<ProviderSiteViewModel> CreateProviderSiteRelationship(ProviderSiteViewModel viewModel)
        {
            var existingViewModel = _providerProvider.GetProviderSiteViewModel(viewModel.ProviderSiteId);
            existingViewModel.ProviderUkprn = viewModel.ProviderUkprn;
            existingViewModel.ProviderSiteRelationshipType = viewModel.ProviderSiteRelationshipType;
            viewModel = existingViewModel;

            var validatonResult = _providerSiteRelationshipViewModelServerValidator.Validate(viewModel);

            if (!validatonResult.IsValid)
            {
                return GetMediatorResponse(AdminMediatorCodes.CreateProviderSiteRelationship.FailedValidation, viewModel, validatonResult);
            }

            var providerViewModel = _providerProvider.GetProviderViewModel(viewModel.ProviderUkprn);
            if (providerViewModel == null)
            {
                return GetMediatorResponse(AdminMediatorCodes.CreateProviderSiteRelationship.InvalidUkprn, viewModel, ProviderSiteViewModelMessages.ProviderSiteRelationshipInvalidUkprn, UserMessageLevel.Error);
            }

            try
            {
                viewModel = _providerProvider.CreateProviderSiteRelationship(viewModel, providerViewModel.ProviderId);

                return GetMediatorResponse(AdminMediatorCodes.CreateProviderSiteRelationship.Ok, viewModel, ProviderSiteViewModelMessages.ProviderSiteRelationshipCreatedSuccessfully, UserMessageLevel.Info);
            }
            catch (Exception ex)
            {
                _logService.Error($"Failed to create provider site relationship for provider site with id={viewModel.ProviderSiteId}", ex);
                return GetMediatorResponse(AdminMediatorCodes.CreateProviderSiteRelationship.Error, viewModel, ProviderSiteViewModelMessages.ProviderSiteRelationshipCreationError, UserMessageLevel.Error);
            }
        }

        public MediatorResponse<TransferVacanciesResultsViewModel> GetVacancyDetails(TransferVacanciesViewModel viewModel)
        {
            try
            {
                IList<TransferVacancyViewModel> vacanciesToBeTransferred = new List<TransferVacancyViewModel>();
                TransferVacanciesResultsViewModel transferVacanciesResultsViewModel = new TransferVacanciesResultsViewModel()
                {
                    TransferVacanciesViewModel = viewModel
                };

                if (viewModel != null && viewModel.VacancyReferenceNumbers.Any())
                {
                    foreach (var vacancy in viewModel.VacancyReferenceNumbers.Split(','))
                    {
                        string vacancyReference;
                        if (VacancyHelper.TryGetVacancyReference(vacancy, out vacancyReference))
                        {
                            Vacancy vacancyDetails = _vacancyPostingService.GetVacancyByReferenceNumber(Convert.ToInt32(vacancyReference));
                            if (vacancyDetails != null)
                            {
                                TransferVacancyViewModel vacancyView = new TransferVacancyViewModel
                                {
                                    ContractOwnerId = vacancyDetails.ProviderId,
                                    VacancyManagerId = vacancyDetails.VacancyManagerId,
                                    VacancyReferenceNumber = vacancyDetails.VacancyReferenceNumber,
                                    DeliveryOrganisationId = vacancyDetails.DeliveryOrganisationId,
                                    VacancyOwnerRelationShipId = vacancyDetails.VacancyOwnerRelationshipId,
                                    ProviderName = _providerService.GetProvider(vacancyDetails.ProviderId).TradingName,
                                    VacancyTitle = vacancyDetails.Title,
                                    EmployerName = vacancyDetails.EmployerName
                                };
                                if (vacancyDetails.VacancyManagerId.HasValue)
                                {
                                    vacancyView.ProviderSiteName =
                                        _providerService.GetProviderSite(vacancyDetails.VacancyManagerId.Value).TradingName;
                                }
                                vacanciesToBeTransferred.Add(vacancyView);
                            }
                        }
                    }
                }
                transferVacanciesResultsViewModel.VacanciesToBeTransferredVm = vacanciesToBeTransferred;
                return GetMediatorResponse(AdminMediatorCodes.GetVacancyDetails.Ok, transferVacanciesResultsViewModel);
            }
            catch (CustomException exception) when (exception.Code == ErrorCodes.ProviderVacancyAuthorisation.Failed)
            {
                return GetMediatorResponse(AdminMediatorCodes.GetVacancyDetails.FailedAuthorisation, new TransferVacanciesResultsViewModel(), TransferVacanciesMessages.UnAuthorisedAccess, UserMessageLevel.Warning);
            }
        }

        public MediatorResponse<ManageVacancyTransferResultsViewModel> ManageVacanciesTransfers(ManageVacancyTransferViewModel vacancyTransferViewModel)
        {
            try
            {
                if (vacancyTransferViewModel.ProviderId != 0 && vacancyTransferViewModel.ProviderSiteId != 0 && vacancyTransferViewModel.VacancyReferenceNumbers.Any())
                {
                    var vacancies = _vacancyPostingProvider.TransferVacancies(vacancyTransferViewModel);
                    _vacancyPostingProvider.UpdateVacancyOwnerRelationship(vacancies);
                }

                return new MediatorResponse<ManageVacancyTransferResultsViewModel>();
            }
            catch (CustomException exception) when (exception.Code == ErrorCodes.ProviderVacancyAuthorisation.Failed)
            {
                return GetMediatorResponse(AdminMediatorCodes.GetVacancyDetails.FailedAuthorisation, new ManageVacancyTransferResultsViewModel(), TransferVacanciesMessages.UnAuthorisedAccess, UserMessageLevel.Warning);
            }
        }
    }
}