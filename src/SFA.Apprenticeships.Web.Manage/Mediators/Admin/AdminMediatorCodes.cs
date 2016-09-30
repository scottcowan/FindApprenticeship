﻿namespace SFA.Apprenticeships.Web.Manage.Mediators.Admin
{
    public class AdminMediatorCodes
    {
        public class SearchProviders
        {
            public const string FailedValidation = "AdminMediatorCodes.SearchProviders.FailedValidation";
            public const string Ok = "AdminMediatorCodes.SearchProviders.Ok";
        }

        public class GetProvider
        {
            public const string Ok = "AdminMediatorCodes.GetProvider.Ok";
        }

        public class CreateProvider
        {
            public const string FailedValidation = "AdminMediatorCodes.CreateProvider.FailedValidation";
            public const string UkprnAlreadyExists = "AdminMediatorCodes.CreateProvider.UkprnAlreadyExists";
            public const string Ok = "AdminMediatorCodes.CreateProvider.Ok";
        }

        public class SearchProviderSites
        {
            public const string FailedValidation = "AdminMediatorCodes.SearchProviderSites.FailedValidation";
            public const string Ok = "AdminMediatorCodes.SearchProviderSites.Ok";
        }

        public class GetProviderSite
        {
            public const string Ok = "AdminMediatorCodes.GetProviderSite.Ok";
        }

        public class CreateProviderSite
        {
            public const string FailedValidation = "AdminMediatorCodes.CreateProviderSite.FailedValidation";
            public const string EdsUrnAlreadyExists = "AdminMediatorCodes.CreateProviderSite.EdsUrnAlreadyExists";
            public const string Ok = "AdminMediatorCodes.CreateProviderSite.Ok";
        }

        public class SaveProviderSite
        {
            public const string FailedValidation = "AdminMediatorCodes.SaveProviderSite.FailedValidation";
            public const string Error = "AdminMediatorCodes.SaveProviderSite.Error";
            public const string Ok = "AdminMediatorCodes.SaveProviderSite.Ok";
        }

        public class CreateProviderSiteRelationship
        {
            public const string FailedValidation = "AdminMediatorCodes.CreateProviderSiteRelationship.FailedValidation";
            public const string InvalidUkprn = "AdminMediatorCodes.CreateProviderSiteRelationship.InvalidUkprn";
            public const string Error = "AdminMediatorCodes.CreateProviderSiteRelationship.Error";
            public const string Ok = "AdminMediatorCodes.CreateProviderSiteRelationship.Ok";
        }

        public class SearchApiUsers
        {
            public const string FailedValidation = "AdminMediatorCodes.SearchApiUsers.FailedValidation";
            public const string Ok = "AdminMediatorCodes.SearchApiUsers.Ok";
        }

        public class GetApiUser
        {
            public const string Ok = "AdminMediatorCodes.GetApiUser.Ok";
        }
    }
}