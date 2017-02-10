namespace SFA.Apprenticeships.Domain.Entities.Raa.Locations.Constants
{
    public class PostalAddressMessages
    {
        public static class AddressLine1
        {
            public const string RequiredErrorText = "Please supply the first line of the address.";
            public const string TooLongErrorText = "First line of address must not be more than {0} characters.";
            public const string WhiteListRegularExpression = Whitelists.FreetextWhitelist.RegularExpression;
            public const string WhiteListErrorText = "First line of address " + Whitelists.FreetextWhitelist.ErrorText;
        }

        public static class AddressLine2
        {
            public const string TooLongErrorText = "Second line of address must not be more than {0} characters.";
            public const string WhiteListRegularExpression = Whitelists.FreetextWhitelist.RegularExpression;
            public const string WhiteListErrorText = "Second line of address " + Whitelists.FreetextWhitelist.ErrorText;
        }

        public static class AddressLine3
        {
            public const string TooLongErrorText = "Third line of address must not be more than {0} characters.";
            public const string WhiteListRegularExpression = Whitelists.FreetextWhitelist.RegularExpression;
            public const string WhiteListErrorText = "Third line of address " + Whitelists.FreetextWhitelist.ErrorText;
        }

        public static class AddressLine4
        {
            public const string TooLongErrorText = "Fourth line of address must not be more than {0} characters.";
            public const string WhiteListRegularExpression = Whitelists.FreetextWhitelist.RegularExpression;
            public const string WhiteListErrorText = "Fourth line of address " + Whitelists.FreetextWhitelist.ErrorText;
        }

        public static class AddressLine5
        {
            public const string TooLongErrorText = "Fifth line of address must not be more than {0} characters.";
            public const string WhiteListRegularExpression = Whitelists.FreetextWhitelist.RegularExpression;
            public const string WhiteListErrorText = "Fifth line of address " + Whitelists.FreetextWhitelist.ErrorText;
        }

        public static class Town
        {
            public const string RequiredErrorText = "Please supply a value for the town property of the address.";
            public const string TooLongErrorText = "Town must not be more than {0} characters";
            public const string WhiteListRegularExpression = Whitelists.FreetextWhitelist.RegularExpression;
            public const string WhiteListErrorText = "Town " + Whitelists.FreetextWhitelist.ErrorText;
        }

        public static class Postcode
        {
            public const string RequiredErrorText = "Please supply a value for the postcode property of the address.";
            public const string TooLongErrorText = "Postcode must not be more than 8 characters";
            public const string WhiteListRegularExpression = Whitelists.PostcodeWhitelist.RegularExpression;
            public const string WhiteListErrorText = "'Postcode' " + Whitelists.PostcodeWhitelist.ErrorText;
        }
    }
}