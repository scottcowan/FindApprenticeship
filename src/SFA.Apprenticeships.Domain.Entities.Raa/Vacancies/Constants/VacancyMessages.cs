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
        }
    }
}