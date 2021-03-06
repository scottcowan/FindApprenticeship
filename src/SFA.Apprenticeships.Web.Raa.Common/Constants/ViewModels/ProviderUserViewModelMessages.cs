﻿using SFA.Apprenticeships.Web.Common.Constants;

namespace SFA.Apprenticeships.Web.Raa.Common.Constants.ViewModels
{
    public class ProviderUserViewModelMessages
    {
        public const string AccountCreated = "You've successfully created your account";
        public const string EmailUpdated = "Your details have been updated successfully";
        public const string AccountUpdated = "Your details have been updated successfully";
        public const string ProviderUserSavedSuccessfully = "The changes to the provider user were saved successfully";
        public const string ProviderUserSaveError = "An error occured when saving the provider user. Please check your entries and try again";
        public const string VerifiedProviderUserEmailSuccessfully = "The provider user's email address was verified successfully";
        public const string VerifyProviderUserEmailError = "An error occured when verifying the provider user's email address. Please try again";

        public static class FullnameMessages
        {
            public const string LabelText = "Full name";
            public const string RequiredErrorText = "Enter your full name";
            public const string TooLongErrorText = "Full name must not be more than 100 characters";
            public const string WhiteListRegularExpression = Whitelists.NameWhitelist.RegularExpression;
            public const string WhiteListErrorText = "Full name " + Whitelists.FreetextWhitelist.ErrorText;
        }

        public static class EmailAddressMessages
        {
            public const string LabelText = "Work email address";
            public const string RequiredErrorText = "Enter work email address";
            public const string TooLongErrorText = "Work email address must not be more than 100 characters";
            public const string WhiteListRegularExpression = Whitelists.EmailAddressWhitelist.RegularExpression;
            public const string WhiteListErrorText = "Work email address " + Whitelists.EmailAddressWhitelist.ErrorText;
        }

        public static class PhoneNumberMessages
        {
            public const string LabelText = "Work phone number";
            public const string RequiredErrorText = "Enter work phone number";
            public const string LengthErrorText = "Work phone number must be between 8 and 16 digits";
            public const string WhiteListRegularExpression = Whitelists.PhoneNumberWhitelist.RegularExpression;
            public const string WhiteListErrorText = "Work phone number " + Whitelists.PhoneNumberWhitelist.ErrorText;
        }

        public static class DefaultProviderSiteErn
        {
            public const string RequiredErrorText = "Select your default provider site";
        }
    }
}
