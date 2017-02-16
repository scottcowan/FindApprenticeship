namespace SFA.Apprenticeships.Domain.Entities.Raa.Vacancies.Constants
{
    public class VacancyMessages
    {
        public static class VacancyOwnerRelationshipId
        {
            public const string RequiredErrorText = "Please supply a valid vacancy owner relationship id. This must exist and be associated with a provider site your API key has access to.";
            public const string Unauthorized = "You do not have permission to create a vacancy for the specified vacancy owner relationship.";
        }

        public static class VacancyGuid
        {
            public const string RequiredErrorText = "Please supply a valid vacancy guid. The guid must not have been used to create a vacancy before.";
            public const string DuplicateGuid = "The supplied guid has been used to create a vacancy before. Please supply a unique guid.";
        }

        public static class VacancyLocationType
        {
            public const string RequiredErrorText = "Please supply a vacancy location type value.";
        }

        public class NumberOfPositions
        {
            public const string RequiredErrorText = "Please supply the number of positions for this vacancy";
            public const string LengthErrorText = "There must be at least 1 position for this vacancy";
        }

        public static class EmployerWebsiteUrl
        {
            public const string InvalidUrlText = "Please supply a valid website url for the employer. If you do not supply a url the value from the associated vacancy owner relationship will be used.";
        }

        public static class EmployerDescription
        {
            public const string WhiteListHtmlRegularExpression = Whitelists.FreeHtmlTextWhiteList.RegularExpression;
            public const string WhiteListInvalidCharacterErrorText = "The description for the employer " + Whitelists.FreeHtmlTextWhiteList.InvalidCharacterErrorText + ". If you do not supply a description the value from the associated vacancy owner relationship will be used.";
            public const string WhiteListInvalidTagErrorText = "The description for the employer " + Whitelists.FreeHtmlTextWhiteList.InvalidTagErrorText + ". If you do not supply a description the value from the associated vacancy owner relationship will be used.";
        }

        public class EmployerAnonymousName
        {
            public const string RequiredErrorText = "Please supply an anonymous name for the employer as you have specified that the employer for this vacancy should be anonymous (IsAnonymousEmployer = true)";
            public const string WhiteListHtmlRegularExpression = Whitelists.FreeHtmlTextWhiteList.RegularExpression;
            public const string WhiteListInvalidCharacterErrorText = "The anonymous name for the employer " + Whitelists.FreeHtmlTextWhiteList.InvalidCharacterErrorText;
            public const string WhiteListInvalidTagErrorText = "The anonymous name for the employer " + Whitelists.FreeHtmlTextWhiteList.InvalidTagErrorText;
        }

        public class EmployerAnonymousReason
        {
            public const string RequiredErrorText = "Please supply a reason for keeping the employer anonymous as you have specified that the employer for this vacancy should be anonymous (IsAnonymousEmployer = true)";
            public const string WhiteListHtmlRegularExpression = Whitelists.FreeHtmlTextWhiteList.RegularExpression;
            public const string WhiteListInvalidCharacterErrorText = "The reason for keeping the employer anonymous " + Whitelists.FreeHtmlTextWhiteList.InvalidCharacterErrorText;
            public const string WhiteListInvalidTagErrorText = "The reason for keeping the employer anonymous " + Whitelists.FreeHtmlTextWhiteList.InvalidTagErrorText;
        }

        public class AnonymousAboutTheEmployer
        {
            public const string RequiredErrorText = "Please supply anonymous information about the employer as you have specified that the employer for this vacancy should be anonymous (IsAnonymousEmployer = true)";
            public const string WhiteListHtmlRegularExpression = Whitelists.FreeHtmlTextWhiteList.RegularExpression;
            public const string WhiteListInvalidCharacterErrorText = "The anonymous information about the employer " + Whitelists.FreeHtmlTextWhiteList.InvalidCharacterErrorText;
            public const string WhiteListInvalidTagErrorText = "The anonymous information about the employer " + Whitelists.FreeHtmlTextWhiteList.InvalidTagErrorText;
        }

        public static class VacancyLocations
        {
            public const string RequiredErrorText = "You must supply at least one vacancy location when the vacancy location type is MultipleLocations.";
        }

        public static class Title
        {
            public const string RequiredErrorText = "Please supply a title for the vacancy";
            public const string TooLongErrorText = "The title must not be more than 100 characters";
            public const string WhiteListRegularExpression = Whitelists.FreetextWhitelist.RegularExpression;
            public const string WhiteListErrorText = "The title " + Whitelists.FreetextWhitelist.ErrorText;
        }

        public static class ShortDescription
        {
            public const string RequiredErrorText = "Please supply the short description for the vacancy";
            public const string TooLongErrorText = "The short description must not be more than 350 characters";
            public const string WhiteListRegularExpression = Whitelists.FreetextWhitelist.RegularExpression;
            public const string WhiteListErrorText = "The short description " + Whitelists.FreetextWhitelist.ErrorText;
        }

        public static class OfflineApplicationUrl
        {
            public const string InvalidUrlText = "Please supply a valid website url for candidates to apply for this vacancy on your website";
            public const string TooLongErrorText = "The website address must not be more than 256 characters";
        }

        public static class OfflineApplicationInstructions
        {
            public const string WhiteListRegularExpression = Whitelists.FreetextWhitelist.RegularExpression;
            public const string WhiteListErrorText = "The instructions for candidates to apply for this vacancy on your website " + Whitelists.FreetextWhitelist.ErrorText;
        }

        public static class TrainingProvidedMessages
        {
            public const string WhiteListHtmlRegularExpression = Whitelists.FreeHtmlTextWhiteList.RegularExpression;
            public const string WhiteListTextRegularExpression = Whitelists.FreetextWhitelist.RegularExpression;
            public const string WhiteListInvalidCharacterErrorText = "Training to be provided " + Whitelists.FreeHtmlTextWhiteList.InvalidCharacterErrorText;
            public const string WhiteListInvalidTagErrorText = "Training to be provided " + Whitelists.FreeHtmlTextWhiteList.InvalidTagErrorText;
        }
    }
}