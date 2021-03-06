﻿namespace SFA.Apprenticeships.Web.Recruit.Constants.Messages
{
    public class AuthorizeMessages
    {
        public const string EmptyUsername = "We have not been able to identify you successfully. Please contact helpdesk";
        public const string MissingProviderIdentifier = "We have not been able to identify your provider information. Please contact helpdesk";
        public const string MissingServicePermission = "You do not have permission to access this service. Please contact helpdesk";
        public const string NoProviderProfile = "As you're the first person to sign in from your organisation, please start by adding your provider name";
        public const string FailedMinimumSitesCountCheck = "Please create at least one site";
        public const string FirstUser = "As you're the first person to sign in from your organisation, please take a moment to review your training sites.<br/>Please email our <a href=\"mailto:nationalhelpdesk@findapprenticeship.service.gov.uk\">helpdesk</a> if any of your details need to be changed";
        public const string NoUserProfile = "Enter your user profile";
        public const string EmailAddressNotVerified = "Verify your email address";
        public const string SignedOut = "You have successfully signed out";
        public const string SignedOutTimeout = "You have been signed out due to inactivity";
        public const string ProviderNotMigrated = "There is a problem with your account. Please call our helpdesk on 0800 015 0400 to resolve this issue. The helpdesk is open daily from 8am to 10pm.";
    }
}
