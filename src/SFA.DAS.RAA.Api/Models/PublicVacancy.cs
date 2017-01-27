namespace SFA.DAS.RAA.Api.Models
{
    public class PublicVacancy : PublicVacancySummary
    {
        public string AdditionalLocationInformation { get; set; }
        public string ContactEmail { get; set; }
        public string ContactName { get; set; }
        public string ContactNumber { get; set; }
        public string DesiredQualifications { get; set; }
        public string DesiredSkills { get; set; }
        public string EmployerDescription { get; set; }
        public string EmployerWebsiteUrl { get; set; }
        public string FirstQuestion { get; set; }
        public string FutureProspects { get; set; }
        public string LocalAuthorityCode { get; set; }
        public string LongDescription { get; set; }
        public string OfflineApplicationInstructions { get; set; }
        public string OfflineApplicationUrl { get; set; }
        public string OtherInformation { get; set; }
        public string PersonalQualities { get; set; }
        public string SecondQuestion { get; set; }
        public string ThingsToConsider { get; set; }
        public string TrainingProvided { get; set; }
    }
}