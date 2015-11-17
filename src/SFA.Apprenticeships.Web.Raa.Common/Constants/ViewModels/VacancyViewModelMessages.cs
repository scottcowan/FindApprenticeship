﻿namespace SFA.Apprenticeships.Web.Raa.Common.Constants.ViewModels
{
    using Web.Common.Constants;

    public class VacancyViewModelMessages
    {
        public static class Title
        {
            public const string LabelText = "Title";
            public const string RequiredErrorText = "Please enter a title";
            public const string TooLongErrorText = "The title must not be more than 100 characters";
            public const string WhiteListRegularExpression = Whitelists.FreetextWhitelist.RegularExpression;
            public const string WhiteListErrorText = "The title " + Whitelists.FreetextWhitelist.ErrorText;
        }

        public static class ShortDescription
        {
            public const string LabelText = "Summary";
            public const string RequiredErrorText = "Please enter a vacancy summary";
            public const string TooLongErrorText = "The short description must not be more than 350 characters";
            public const string WhiteListRegularExpression = Whitelists.FreetextWhitelist.RegularExpression;
            public const string WhiteListErrorText = "The short description " + Whitelists.FreetextWhitelist.ErrorText;
        }

        public static class WorkingWeek
        {
            public const string LabelText = "Working week";
            public const string RequiredErrorText = "Please enter the working week";
            public const string TooLongErrorText = "The working week must not be more than 256 characters";
            public const string WhiteListRegularExpression = Whitelists.FreetextWhitelist.RegularExpression;
            public const string WhiteListErrorText = "The working week " + Whitelists.FreetextWhitelist.ErrorText;
        }

        public static class HoursPerWeek
        {
            public const string LabelText = "Hours per week";
            public const string RequiredErrorText = "Please enter the hours per week";
            public const string HoursPerWeekShouldBeGreaterThan16 = "The hours per week must be more than 16";
        }

        public static class WageType
        {
            public const string LabelText = "Wage";
            public const string RequiredErrorText = "Please select a wage";
        }

        public static class Wage
        {
            public const string LabelText = "Wage";
            public const string WhiteListRegularExpression = Whitelists.FreetextWhitelist.RegularExpression;
            public const string WhiteListErrorText = "The wage " + Whitelists.FreetextWhitelist.ErrorText;
            public const string RequiredErrorText = "Please enter an amount for wage";
            public const string WageLessThanMinimum = "The wage should not be less than the National Minimum Wage for apprentices";
        }

        public static class Duration
        {
            public const string LabelText = "Apprenticeship duration";
            public const string WhiteListRegularExpression = Whitelists.IntegerWhitelist.RegularExpression;
            public const string WhiteListErrorText = "The apprenticeship duration " + Whitelists.IntegerWhitelist.ErrorText;
            public const string RequiredErrorText = "Please enter the apprenticeship duration";
            public const string RangeErrorText = "The apprenticeship duration must be a whole number";
            public const string DurationCantBeLessThan12Months = "The duration must be at least 12 months (52 weeks)";
            public const string DurationWarning16Hours =
                "The minimum apprenticeship duration is 23 months based on the hours per week selected";
            public const string DurationWarning18Hours =
                "The minimum apprenticeship duration is 20 months based on the hours per week selected";
            public const string DurationWarning20Hours =
                "The minimum apprenticeship duration is 18 months based on the hours per week selected";
            public const string DurationWarning22Hours =
                "The minimum apprenticeship duration is 17 months based on the hours per week selected";
            public const string DurationWarning25Hours =
                "The minimum apprenticeship duration is 15 months based on the hours per week selected";
            public const string DurationWarning28Hours =
                "The minimum apprenticeship duration is 13 months based on the hours per week selected";
            public const string DurationWarning30Hours =
                "The minimum apprenticeship duration is 12 months based on the hours per week selected";
        }

        public static class ClosingDate
        {
            public const string LabelText = "Closing date";
            public const string RequiredErrorText = "Please specify a valid closing date";
            public const string TooSoonErrorText = "The closing date should be at least two weeks from now";
        }

        public static class PossibleStartDate
        {
            public const string LabelText = "Possible start date";
            public const string RequiredErrorText = "Please specify a valid possible start date";
            public const string TooSoonErrorText = "The possible start date should be at least two weeks from now";
            public const string BeforePublishDateErrorText = "The possible start date should be after the closing date";
        }

        public static class LongDescription
        {
            public const string LabelText = "Vacancy description";
            public const string RequiredErrorText = "Please enter the long description";
            public const string TooLongErrorText = "The long description must not be more than 4000 characters";
            public const string WhiteListRegularExpression = Whitelists.FreetextWhitelist.RegularExpression;
            public const string WhiteListErrorText = "The long description " + Whitelists.FreetextWhitelist.ErrorText;
        }

        public static class DesiredSkills
        {
            public const string LabelText = "Desired skills";
            public const string RequiredErrorText = "Please enter the desired skills";
            public const string TooLongErrorText = "Desired skills must not be more than 4000 characters";
            public const string WhiteListRegularExpression = Whitelists.FreetextWhitelist.RegularExpression;
            public const string WhiteListErrorText = "Desired skills " + Whitelists.FreetextWhitelist.ErrorText;
        }

        public static class FutureProspects
        {
            public const string LabelText = "Future prospects";
            public const string RequiredErrorText = "Please enter the future prospects";
            public const string TooLongErrorText = "Future prospects must not be more than 4000 characters";
            public const string WhiteListRegularExpression = Whitelists.FreetextWhitelist.RegularExpression;
            public const string WhiteListErrorText = "Future prospects " + Whitelists.FreetextWhitelist.ErrorText;
        }

        public static class PersonalQualities
        {
            public const string LabelText = "Personal qualities";
            public const string RequiredErrorText = "Please enter the personal qualities required";
            public const string TooLongErrorText = "Personal qualities must not be more than 4000 characters";
            public const string WhiteListRegularExpression = Whitelists.FreetextWhitelist.RegularExpression;
            public const string WhiteListErrorText = "Personal qualities " + Whitelists.FreetextWhitelist.ErrorText;
        }

        public static class ThingsToConsider
        {
            public const string LabelText = "Things to consider (optional)";
            public const string TooLongErrorText = "Things to consider must not be more than 4000 characters";
            public const string WhiteListRegularExpression = Whitelists.FreetextWhitelist.RegularExpression;
            public const string WhiteListErrorText = "Things to consider " + Whitelists.FreetextWhitelist.ErrorText;
        }

        public static class DesiredQualifications
        {
            public const string LabelText = "Desired qualifications";
            public const string RequiredErrorText = "Please enter the desired qualifications";
            public const string TooLongErrorText = "Desired qualifications must not be more than 4000 characters";
            public const string WhiteListRegularExpression = Whitelists.FreetextWhitelist.RegularExpression;
            public const string WhiteListErrorText = "Desired qualifications " + Whitelists.FreetextWhitelist.ErrorText;
        }

        public static class FirstQuestion
        {
            public const string LabelText = "First question (optional)";
            public const string TooLongErrorText = "The first question must not be more than 4000 characters";
            public const string WhiteListRegularExpression = Whitelists.FreetextWhitelist.RegularExpression;
            public const string WhiteListErrorText = "The first question " + Whitelists.FreetextWhitelist.ErrorText;
        }

        public static class SecondQuestion
        {
            public const string LabelText = "Second question (optional)";
            public const string TooLongErrorText = "The second question must not be more than 4000 characters";
            public const string WhiteListRegularExpression = Whitelists.FreetextWhitelist.RegularExpression;
            public const string WhiteListErrorText = "The second question " + Whitelists.FreetextWhitelist.ErrorText;
        }

        public static class FirstQuestionComment
        {
            public const string WhiteListRegularExpression = Whitelists.FreetextWhitelist.RegularExpression;
            public const string WhiteListErrorText = "The first question " + Whitelists.FreetextWhitelist.ErrorText;
        }

        public static class SecondQuestionComment
        {
            public const string WhiteListRegularExpression = Whitelists.FreetextWhitelist.RegularExpression;
            public const string WhiteListErrorText = "The second question " + Whitelists.FreetextWhitelist.ErrorText;
        }

        public static class OfflineApplicationUrl
        {
            public const string LabelText = "What website address should candidates apply through?";
            public const string RequiredErrorText = "Please enter a valid website address";
            public const string TooLongErrorText = "The website address must not be more than 100 characters";
            public const string WhiteListRegularExpression = Whitelists.FreetextWhitelist.RegularExpression;
            public const string WhiteListErrorText = "The website address " + Whitelists.FreetextWhitelist.ErrorText;
            public const string ErrorUriText = "Please enter a valid website address";
        }

        public static class OfflineApplicationInstructions
        {
            public const string LabelText = "Please explain to candidates what will happen when they apply (optional)";
            public const string WhiteListRegularExpression = Whitelists.FreetextWhitelist.RegularExpression;
            public const string WhiteListErrorText = "The candidate explanation " + Whitelists.FreetextWhitelist.ErrorText;
        }

        public static class ApprenticeshipLevel
        {
            public const string RequiredErrorText = "Please select the apprenticeship level";
        }

        public static class FrameworkCodeName
        {
            public const string RequiredErrorText = "Please select the apprenticeship framework";
        }

        public static class StandardId
        {
            public const string RequiredErrorText = "Please select the apprenticeship standard";
        }

        public static class Comment
        {
            public const string LabelText = "QA Comment";
            public const string WhiteListRegularExpression = Whitelists.FreetextWhitelist.RegularExpression;
            public const string WhiteListErrorText = "Comment " + Whitelists.FreetextWhitelist.ErrorText;
        }
    }
}