namespace SFA.DAS.RAA.Api.Models
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// The public facing properties of a vacancy. The full information can be found in the Vacancy object
    /// </summary>
    public class PublicVacancy : PublicVacancySummary
    {
        /// <summary>
        /// If the vacancy has multiple locations, this property may contain additional information about those locations
        /// </summary>
        public string AdditionalLocationInformation { get; set; }
        /// <summary>
        /// A contact email for candidates to request more information about the vacancy
        /// </summary>
        public string ContactEmail { get; set; }
        /// <summary>
        /// A contact name for candidates to request more information about the vacancy
        /// </summary>
        public string ContactName { get; set; }
        /// <summary>
        /// A contact number for candidates to request more information about the vacancy
        /// </summary>
        public string ContactNumber { get; set; }
        /// <summary>
        /// The qualifications the employer is looking for in prospective candidates. Not present for traineeships
        /// </summary>
        [Required]
        public string DesiredQualifications { get; set; }
        /// <summary>
        /// The skill set the employer is looking for prospective candidates to demonstrate
        /// </summary>
        [Required]
        public string DesiredSkills { get; set; }
        /// <summary>
        /// The description of the employer
        /// </summary>
        [Required]
        public string EmployerDescription { get; set; }
        /// <summary>
        /// A link to the employer's website if specified
        /// </summary>
        public string EmployerWebsiteUrl { get; set; }
        /// <summary>
        /// The first screening question for candidates
        /// </summary>
        public string FirstQuestion { get; set; }
        /// <summary>
        /// The likely career progression, skills or qualifications a candidate will gain in this vacancy
        /// </summary>
        [Required]
        public string FutureProspects { get; set; }
        /// <summary>
        /// The full, detailed description of the vacancy
        /// </summary>
        [Required]
        public string LongDescription { get; set; }
        /// <summary>
        /// If applications for this vacancy are made via an external web site, this property will contain instructions on how to apply
        /// </summary>
        public string OfflineApplicationInstructions { get; set; }
        /// <summary>
        /// If applications for this vacancy are made via an external web site, this property will contain the web site URL
        /// </summary>
        public string OfflineApplicationUrl { get; set; }
        /// <summary>
        /// Only present if the vacancy was created in the legacy system or via the legacy API. Contains any additional information the employer deems pertinent to the vacancy
        /// </summary>
        public string OtherInformation { get; set; }
        /// <summary>
        /// The soft skills and personal qualities the employer is looking for in prospective candidates
        /// </summary>
        public string PersonalQualities { get; set; }
        /// <summary>
        /// The second screening question for candidates
        /// </summary>
        public string SecondQuestion { get; set; }
        /// <summary>
        /// Any information that the employer feels a candidate should be mindful of when applying for this vacancy
        /// </summary>
        public string ThingsToConsider { get; set; }
        /// <summary>
        /// The training that will be provided by the training provider associated with this vacancy
        /// </summary>
        [Required]
        public string TrainingProvided { get; set; }
    }
}