﻿namespace SFA.Apprenticeships.Web.Raa.Common.Constants.ViewModels
{
    using Web.Common.Constants;

    public class LocationSearchViewModelMessages
    {
        public static class AdditionalLocationInformation
        {
            public const string LabelText = "Additional location information (optional)";
            public const string WhiteListRegularExpression = Whitelists.FreetextWhitelist.RegularExpression;
            public const string WhiteListErrorText = "The additional location information " + Whitelists.FreetextWhitelist.ErrorText;
        }

        public class PostCodeSearch
        {
            public const string LabelText = "Enter the vacancy location or postcode";
            public const string ErrorText = "You must enter a full postcode";
        }

        public class Addresses
        {
            public const string NoAddressesErrorText =
                "You must enter at least one location before continuing";
        }

        public class LocationAddressesComment
        {
            public const string LabelText = "Vacancy location(s) comment";
        }

        public class AdditionalLocationInformationComment
        {
            public const string LabelText = "Additional location information comment";
            public const string WhiteListRegularExpression = Whitelists.FreetextWhitelist.RegularExpression;
            public const string WhiteListErrorText = "The additional location information comment " + Whitelists.FreetextWhitelist.ErrorText;
        }
    }
}