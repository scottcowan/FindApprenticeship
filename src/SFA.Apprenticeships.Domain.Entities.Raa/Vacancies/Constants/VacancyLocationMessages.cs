namespace SFA.Apprenticeships.Domain.Entities.Raa.Vacancies.Constants
{
    public class VacancyLocationMessages
    {
        public static class Address
        {
            public const string RequiredErrorText = "Please supply an address for this vacancy location.";
        }

        public class NumberOfPositions
        {
            public const string LengthErrorText = "There must be at least 1 position for this vacancy location.";
        }

        public static class EmployersWebsite
        {
            public const string InvalidUrlText = "Please supply a valid website url for the employer. This is the link that will be used to apply on the employer's website if the vacancy is set as offline.";
        }
    }
}