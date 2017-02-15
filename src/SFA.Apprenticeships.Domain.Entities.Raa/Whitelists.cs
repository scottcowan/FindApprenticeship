namespace SFA.Apprenticeships.Domain.Entities.Raa
{
    public static class Whitelists
    {
        public static class FreeHtmlTextWhiteList
        {
            public const string RegularExpression = @"^[a-zA-Z0-9\u0080-\uFFA7?$@#()""'!,+\-=_:;.&€£*%\s\/<>\[\]]+$";
            public const string RegularExpressionScripts = @"<script[^>]*\s*[^>]*\s*[^>]*>";
            public const string RegularExpressionInputs = @"<input[^>]*\s*[^>]*\s*[^>]*>";
            public const string RegularExpressionObjects = @"<object[^>]*\s*[^>]*\s*[^>]*>";
            public const string InvalidCharacterErrorText = @"contains some invalid characters";
            public const string InvalidTagErrorText = @"contains some invalid tags";
        }

        public static class FreetextWhitelist
        {
            public const string RegularExpression = @"^[a-zA-Z0-9\u0080-\uFFA7?$@#()""'!,+\-=_:;.&€£*%\s\/\[\]]+$";
            public const string ErrorText = @"contains some invalid characters";
        }

        public static class PostcodeWhitelist
        {
            // See http://stackoverflow.com/questions/164979/uk-postcode-regex-comprehensive
            public const string RegularExpression = "^(([gG][iI][rR] {0,}0[aA]{2})|((([a-pr-uwyzA-PR-UWYZ][a-hk-yA-HK-Y]?[0-9][0-9]?)|(([a-pr-uwyzA-PR-UWYZ][0-9][a-hjkstuwA-HJKSTUW])|([a-pr-uwyzA-PR-UWYZ][a-hk-yA-HK-Y][0-9][abehmnprv-yABEHMNPRV-Y]))) {0,}[0-9][abd-hjlnp-uw-zABD-HJLNP-UW-Z]{2}))$"; //"^(GIR 0AA)|((([A-Z-[QVX]][0-9][0-9]?)|(([A-Z-[QVX]][A-Z-[IJZ]][0-9][0-9]?)|(([A-Z-[QVX]][0-9][A-HJKSTUW])|([A-Z-[QVX]][A-Z-[IJZ]][0-9][ABEHMNPRVWXY])))) [0-9][A-Z-[CIKMOV]]{2})$";
            public const string ErrorText = @" is not a valid format";
        }
    }
}