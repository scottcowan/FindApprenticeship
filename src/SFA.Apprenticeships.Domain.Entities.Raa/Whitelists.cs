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
    }
}