﻿namespace SFA.Apprenticeships.Web.Recruit.Mediators.ProviderUser
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Claims;
    using System.Web.Mvc;
    using Common.Constants;
    using Common.Mediators;
    using Common.Models.Azure.AccessControlService;
    using Common.Providers.Azure.AccessControlService;
    using Constants.Messages;
    using Domain.Entities.Raa;
    using Raa.Common.Validators.ProviderUser;
    using Apprenticeships.Application.Interfaces.Users;
    using Domain.Entities.Communication;
    using Raa.Common.Constants.ViewModels;
    using Raa.Common.Providers;
    using Raa.Common.ViewModels.ProviderUser;
    using ViewModels.Home;
    using SFA.Infrastructure.Interfaces;
    using ViewModels;
    using ClaimTypes = Common.Constants.ClaimTypes;

    public class ProviderUserMediator : MediatorBase, IProviderUserMediator
    {
        private const int MinProviderSites = 1;        
        private readonly IProviderUserProvider _providerUserProvider;
        private readonly IProviderProvider _providerProvider;
        private readonly IAuthorizationErrorProvider _authorizationErrorProvider;
        private readonly IVacancyPostingProvider _vacancyProvider;
        private readonly IProviderUserAccountService _providerService;
        private readonly ProviderUserViewModelValidator _providerUserViewModelValidator;
        private readonly VerifyEmailViewModelValidator _verifyEmailViewModelValidator;
        private readonly IMapper _mapper;
        private readonly ILogService _logService;

        public ProviderUserMediator(IProviderUserProvider providerUserProvider,
            IProviderProvider providerProvider,
            IAuthorizationErrorProvider authorizationErrorProvider,
            IVacancyPostingProvider vacancyProvider,
            ProviderUserViewModelValidator providerUserViewModelValidator,
            VerifyEmailViewModelValidator verifyEmailViewModelValidator,
            IProviderUserAccountService providerService,IMapper mapper,
            ILogService logService)
        {
            _providerUserProvider = providerUserProvider;
            _providerProvider = providerProvider;
            _authorizationErrorProvider = authorizationErrorProvider;
            _vacancyProvider = vacancyProvider;
            _providerUserViewModelValidator = providerUserViewModelValidator;
            _verifyEmailViewModelValidator = verifyEmailViewModelValidator;
            _providerService = providerService;
            _mapper = mapper;
            _logService = logService;
        }

        public MediatorResponse<AuthorizeResponseViewModel> Authorize(ClaimsPrincipal principal)
        {
            var viewModel = new AuthorizeResponseViewModel();

            if (string.IsNullOrEmpty(principal?.Identity?.Name))
            {
                return GetMediatorResponse(ProviderUserMediatorCodes.Authorize.EmptyUsername, viewModel, AuthorizeMessages.EmptyUsername, UserMessageLevel.Error);
            }

            var username = principal.Identity.Name;

            viewModel.Username = username;

            var userProfile = _providerUserProvider.GetUserProfileViewModel(username);

            if (userProfile != null)
            {
                viewModel.EmailAddress = userProfile.EmailAddress;
                viewModel.EmailAddressVerified = userProfile.EmailAddressVerified;
            }

            var ukprn = principal.Claims.SingleOrDefault(c => c.Type == ClaimTypes.Ukprn)?.Value;

            if (string.IsNullOrWhiteSpace(ukprn))
            {
                return GetMediatorResponse(ProviderUserMediatorCodes.Authorize.MissingProviderIdentifier, viewModel, AuthorizeMessages.MissingProviderIdentifier, UserMessageLevel.Error);
            }

            if (!principal.IsInRole(Roles.Faa))
            {
                return GetMediatorResponse(ProviderUserMediatorCodes.Authorize.MissingServicePermission, viewModel, AuthorizeMessages.MissingServicePermission, UserMessageLevel.Warning);
            }

            var provider = _providerProvider.GetProviderViewModel(ukprn);

            if (provider == null)
            {
                return GetMediatorResponse(ProviderUserMediatorCodes.Authorize.NoProviderProfile, viewModel, AuthorizeMessages.NoProviderProfile, UserMessageLevel.Info);
            }

            ((ClaimsIdentity) principal.Identity).AddClaim(new Claim(ClaimTypes.ProviderId, Convert.ToString(provider.ProviderId)));

            if (provider.ProviderSiteViewModels.Count() < MinProviderSites)
            {
                return GetMediatorResponse(ProviderUserMediatorCodes.Authorize.FailedMinimumSitesCountCheck, viewModel, AuthorizeMessages.FailedMinimumSitesCountCheck, UserMessageLevel.Warning);
            }

            if (userProfile == null)
            {
                var isFirstUser = !_providerUserProvider.GetUserProfileViewModels(ukprn).Any();

                if (isFirstUser)
                {
                    return GetMediatorResponse(ProviderUserMediatorCodes.Authorize.FirstUser, viewModel, AuthorizeMessages.FirstUser, UserMessageLevel.Info);
                }

                return GetMediatorResponse(ProviderUserMediatorCodes.Authorize.NoUserProfile, viewModel, AuthorizeMessages.NoUserProfile, UserMessageLevel.Info);
            }

            if (!userProfile.EmailAddressVerified)
            {
                return GetMediatorResponse(ProviderUserMediatorCodes.Authorize.EmailAddressNotVerified, viewModel, AuthorizeMessages.EmailAddressNotVerified, UserMessageLevel.Info);
            }

            return GetMediatorResponse(ProviderUserMediatorCodes.Authorize.Ok, viewModel);
        }

        public AuthorizationErrorDetailsViewModel AuthorizationError(string errorDetails)
        {
            return _authorizationErrorProvider.GetAuthorizationErrorDetailsViewModel(errorDetails);
        }

        public MediatorResponse<VerifyEmailViewModel> GetVerifyEmailViewModel(string username)
        {
            var providerUserViewModel = _providerUserProvider.GetUserProfileViewModel(username);
            if (providerUserViewModel == null)
            {
                return GetMediatorResponse(ProviderUserMediatorCodes.GetVerifyEmailViewModel.NoUserProfile, (VerifyEmailViewModel)null, AuthorizeMessages.NoUserProfile, UserMessageLevel.Info);
            }

            var verifyEmailViewModel = new VerifyEmailViewModel
            {
                EmailAddress = providerUserViewModel.EmailAddress
            };

            return GetMediatorResponse(ProviderUserMediatorCodes.GetVerifyEmailViewModel.Ok, verifyEmailViewModel);
        }

        public MediatorResponse<SettingsViewModel> GetSettingsViewModel(string username, string ukprn)
        {
            var providerUserViewModel = _providerUserProvider.GetUserProfileViewModel(username) ?? new ProviderUserViewModel();
            var providerSites = GetProviderSites(ukprn);
            var viewModel = new SettingsViewModel
            {
                ProviderUserViewModel = providerUserViewModel,
                ProviderSites = providerSites
            };

            return GetMediatorResponse(ProviderUserMediatorCodes.GetSettingsViewModel.Ok, viewModel);
        }

        public MediatorResponse<SettingsViewModel> UpdateUser(string username, string ukprn, ProviderUserViewModel providerUserViewModel)
        {
            var result = _providerUserViewModelValidator.Validate(providerUserViewModel);

            var providerSites = GetProviderSites(ukprn);
            var viewModel = new SettingsViewModel
            {
                ProviderUserViewModel = providerUserViewModel,
                ProviderSites = providerSites
            };

            if (!result.IsValid)
            {
                return GetMediatorResponse(ProviderUserMediatorCodes.UpdateUser.FailedValidation, viewModel, result);
            }

            var existingUser = _providerUserProvider.GetUserProfileViewModel(username);

            viewModel.ProviderUserViewModel = _providerUserProvider.SaveProviderUser(username, ukprn, providerUserViewModel);

            if (existingUser != null)
            {
                if (!string.Equals(existingUser.EmailAddress, viewModel.ProviderUserViewModel.EmailAddress, StringComparison.CurrentCultureIgnoreCase))
                {
                    return GetMediatorResponse(ProviderUserMediatorCodes.UpdateUser.EmailUpdated, viewModel, ProviderUserViewModelMessages.EmailUpdated, UserMessageLevel.Success);
                }
                return GetMediatorResponse(ProviderUserMediatorCodes.UpdateUser.AccountUpdated, viewModel, ProviderUserViewModelMessages.AccountUpdated, UserMessageLevel.Success);
            }

            return GetMediatorResponse(ProviderUserMediatorCodes.UpdateUser.Ok, viewModel, ProviderUserViewModelMessages.AccountCreated, UserMessageLevel.Success);
        }

        public MediatorResponse VerifyEmailAddress(string username, VerifyEmailViewModel verifyEmailViewModel)
        {
            var result = _verifyEmailViewModelValidator.Validate(verifyEmailViewModel);

            if (!result.IsValid)
            {
                return GetMediatorResponse(ProviderUserMediatorCodes.VerifyEmailAddress.FailedValidation, verifyEmailViewModel, result);
            }

            if (!_providerUserProvider.ValidateEmailVerificationCode(username, verifyEmailViewModel.VerificationCode))
            {
                return GetMediatorResponse(ProviderUserMediatorCodes.VerifyEmailAddress.InvalidCode, VerifyEmailViewModelMessages.VerificationCodeEmailIncorrectMessage, UserMessageLevel.Error);
            }

            return GetMediatorResponse(ProviderUserMediatorCodes.VerifyEmailAddress.Ok);
        }

        public MediatorResponse<VerifyEmailViewModel> ResendVerificationCode(string username)
        {
            var providerUserViewModel = _providerUserProvider.GetUserProfileViewModel(username);

            if (providerUserViewModel == null)
            {
                return GetMediatorResponse(ProviderUserMediatorCodes.ResendVerificationCode.Error, new VerifyEmailViewModel(), VerifyEmailViewModelMessages.VerificationCodeEmailResentFailedMessage, UserMessageLevel.Error);
            }

            var viewModel = new VerifyEmailViewModel
            {
                EmailAddress = providerUserViewModel.EmailAddress
            };

            _providerUserProvider.ResendEmailVerificationCode(username);

            var message = string.Format(VerifyEmailViewModelMessages.VerificationCodeEmailResentMessage, viewModel.EmailAddress);
            return GetMediatorResponse(ProviderUserMediatorCodes.ResendVerificationCode.Ok, viewModel, message, UserMessageLevel.Success);
        }

        public MediatorResponse<HomeViewModel> GetHomeViewModel(string username, string ukprn, VacanciesSummarySearchViewModel vacanciesSummarySearch)
        {
            var providerUserViewModel = _providerUserProvider.GetUserProfileViewModel(username) ?? new ProviderUserViewModel();
            var provider = _providerProvider.GetProviderViewModel(ukprn);
            var providerSites = GetProviderSites(ukprn);
            var vacanciesSummary = _vacancyProvider.GetVacanciesSummaryForProvider(provider.ProviderId, providerUserViewModel.DefaultProviderSiteId, vacanciesSummarySearch);

            var viewModel = new HomeViewModel
            {
                ProviderUserViewModel = providerUserViewModel,
                ProviderViewModel = provider,
                ProviderSites = providerSites,
                VacanciesSummary = vacanciesSummary
            };

            return GetMediatorResponse(ProviderUserMediatorCodes.GetHomeViewModel.Ok, viewModel);
        }

        public MediatorResponse<HomeViewModel> ChangeProviderSite(string username, string ukprn, HomeViewModel viewModel)
        {
            var providerUserViewModel = _providerUserProvider.GetUserProfileViewModel(username);
            if (providerUserViewModel.DefaultProviderSiteId != viewModel.ProviderUserViewModel.DefaultProviderSiteId)
            {
                providerUserViewModel.DefaultProviderSiteId = viewModel.ProviderUserViewModel.DefaultProviderSiteId;
                providerUserViewModel = _providerUserProvider.SaveProviderUser(username, ukprn, providerUserViewModel);
            }
            var providerSites = GetProviderSites(ukprn);
            var homeViewModel = new HomeViewModel
            {
                ProviderUserViewModel = providerUserViewModel,
                ProviderSites = providerSites
            };

            return GetMediatorResponse(ProviderUserMediatorCodes.ChangeProviderSite.Ok, homeViewModel);
        }

        private List<SelectListItem> GetProviderSites(string ukprn)
        {
            var providerSites = _providerProvider.GetProviderSiteViewModels(ukprn);

            var sites = providerSites.Select(ps => new SelectListItem { Value = Convert.ToString(ps.ProviderSiteId), Text = ps.DisplayName }).ToList();

            return sites;
        }

        public bool SendContactMessage(ContactMessageViewModel contactMessageViewModel)
        {
            try
            {
                ProviderContactMessage contactMessage = _mapper.Map<ContactMessageViewModel, ProviderContactMessage>(contactMessageViewModel);                
                _providerService.SubmitContactMessage(contactMessage);
                return true;
            }
            catch(Exception exception)
            {
                _logService.Error($"Exception occured while sending contact us email:{exception.Message}");
                return false;
            }
        }
    }
}
