﻿using System;
using System.Collections.Generic;
using System.Linq;
using SFA.Apprenticeships.Application.Interfaces.Users;
using SFA.Apprenticeships.Domain.Entities.Users;
using SFA.Apprenticeships.Web.Raa.Common.ViewModels.ProviderUser;

namespace SFA.Apprenticeships.Web.Raa.Common.Providers
{
    public class ProviderUserProvider : IProviderUserProvider
    {
        private readonly IUserProfileService _userProfileService;
        private readonly IProviderUserAccountService _providerUserAccountService;

        public ProviderUserProvider(
            IUserProfileService userProfileService,
            IProviderUserAccountService providerUserAccountService)
        {
            _userProfileService = userProfileService;
            _providerUserAccountService = providerUserAccountService;
        }

        public ProviderUserViewModel GetUserProfileViewModel(string username)
        {
            var providerUser = _userProfileService.GetProviderUser(username);
            if (providerUser != null)
            {
                return Convert(providerUser);
            }

            return null;
        }

        public IEnumerable<ProviderUserViewModel> GetUserProfileViewModels(string ukprn)
        {
            var providerUsers = _userProfileService.GetProviderUsers(ukprn);
            return providerUsers.Select(Convert);
        }

        public bool ValidateEmailVerificationCode(string username, string code)
        {
            var providerUser = _userProfileService.GetProviderUser(username);

            if (code.Equals(providerUser.EmailVerificationCode, StringComparison.CurrentCultureIgnoreCase))
            {
                //TODO: Probably put all this in a strategy in the service
                providerUser.EmailVerificationCode = null;
                providerUser.EmailVerifiedDate = DateTime.UtcNow;
                providerUser.Status = ProviderUserStatuses.EmailVerified;
                _userProfileService.SaveUser(providerUser);

                return true;
            }

            return false;

            //End Stub
        }

        public ProviderUserViewModel SaveProviderUser(string username, string ukprn, ProviderUserViewModel providerUserViewModel)
        {
            var providerUser = _userProfileService.GetProviderUser(username) ?? new ProviderUser();

            var emailChanged = !string.Equals(providerUser.Email, providerUserViewModel.EmailAddress, StringComparison.CurrentCultureIgnoreCase);

            //TODO: Probably put this in a strategy in the service and add the verify email code
            providerUser.Username = username;
            providerUser.Ukprn = ukprn;
            providerUser.Email = providerUserViewModel.EmailAddress;
            providerUser.Fullname = providerUserViewModel.Fullname;
            providerUser.PhoneNumber = providerUserViewModel.PhoneNumber;
            providerUser.PreferredSiteErn = providerUserViewModel.DefaultProviderSiteErn;
            providerUser.Status = providerUser.Status;

            _userProfileService.SaveUser(providerUser);

            if (emailChanged)
            {
                // TODO: AG: US824: call to this service must be moved. Note that this service is responsible for generating the email
                // verification code and updating the user again so take care must be taken around other calls to UserProfileService.SaveUser().
                _providerUserAccountService.SendEmailVerificationCode(username);
            }

            return GetUserProfileViewModel(providerUser.Username);
        }

        public void ResendEmailVerificationCode(string username)
        {
            _providerUserAccountService.ResendEmailVerificationCode(username);
        }

        private static ProviderUserViewModel Convert(ProviderUser providerUser)
        {
            var viewModel = new ProviderUserViewModel
            {
                DefaultProviderSiteErn = providerUser.PreferredSiteErn,
                EmailAddress = providerUser.Email,
                EmailAddressVerified = providerUser.Status == ProviderUserStatuses.EmailVerified,
                Fullname = providerUser.Fullname,
                PhoneNumber = providerUser.PhoneNumber
            };

            return viewModel;
        }
    }
}