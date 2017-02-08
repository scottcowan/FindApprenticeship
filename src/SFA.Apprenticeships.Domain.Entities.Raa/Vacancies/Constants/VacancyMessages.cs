﻿namespace SFA.Apprenticeships.Domain.Entities.Raa.Vacancies.Constants
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
    }
}