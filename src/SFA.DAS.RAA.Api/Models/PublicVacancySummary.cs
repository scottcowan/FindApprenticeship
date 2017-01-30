namespace SFA.DAS.RAA.Api.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using Apprenticeships.Domain.Entities.Raa.Locations;
    using Apprenticeships.Domain.Entities.Raa.Vacancies;
    using ApprenticeshipLevel = Apprenticeships.Domain.Entities.Raa.Vacancies.ApprenticeshipLevel;
    using TrainingType = Apprenticeships.Domain.Entities.Raa.Vacancies.TrainingType;
    using VacancyLocationType = Apprenticeships.Domain.Entities.Raa.Vacancies.VacancyLocationType;
    using VacancyType = Apprenticeships.Domain.Entities.Raa.Vacancies.VacancyType;

    /// <summary>
    /// The public facing properties of a vacancy summary. The full information can be found in the VacancySummary object
    /// </summary>
    public class PublicVacancySummary
    {
        /// <summary>
        /// The primary identifier for the vacancy
        /// </summary>
        [Required]
        public int VacancyId { get; set; }
        /// <summary>
        /// The secondary reference number for the vacancy. The numerical part of the vacancy reference e.g. 123456 for VAC000123456
        /// </summary>
        [Required]
        public int VacancyReferenceNumber { get; set; }
        /// <summary>
        /// The secondary GUID identifier for the vacancy
        /// </summary>
        [Required]
        public Guid VacancyGuid { get; set; }
        /// <summary>
        /// The main heading for the vacancy e.g. Retail Apprentice
        /// </summary>
        [Required]
        public string Title { get; set; }
        /// <summary>
        /// A short paragraph of text giving a brief overview of the role
        /// </summary>
        [Required]
        public string ShortDescription { get; set; }
        /// <summary>
        /// A description of the working week e.g. 9-5 Monday to Friday with occasional weekend work
        /// </summary>
        [Required]
        public string WorkingWeek { get; set; }
        /// <summary>
        /// The text based expected duration of a vacancy. Only set if the vacancy originated in the legacy system or the legacy API
        /// </summary>
        public string ExpectedDuration { get; set; }
        /// <summary>
        /// Clarification of the Duration property specifying weeks, months or years
        /// </summary>
        [Required]
        public DurationType DurationType { get; set; }
        /// <summary>
        /// The estimated duration of the vacancy
        /// </summary>
        [Required]
        public int? Duration { get; set; }
        /// <summary>
        /// The closing date for applications
        /// </summary>
        [Required]
        public DateTime? ClosingDate { get; set; }
        /// <summary>
        /// The likely start date for the vacancy
        /// </summary>
        [Required]
        public DateTime? PossibleStartDate { get; set; }
        /// <summary>
        /// If true, applications for this vacancy will be made on an external recruitment system rather than on Find an Apprenticeship/Traineeship 
        /// </summary>
        [Required]
        public bool? OfflineVacancy { get; set; }
        /// <summary>
        /// Specifies the classification system of the training the apprentice will receive from the apprenticeship/traineeship. 
        /// Either via a framework or standard if the vacancy is an apprenticeship or a sector for traineeships
        /// </summary>
        [Required]
        public TrainingType TrainingType { get; set; }
        /// <summary>
        /// The level of the apprenticeship. Related to the TrainingType and the education level the apprentice will gain or requires
        /// </summary>
        [Required]
        public ApprenticeshipLevel ApprenticeshipLevel { get; set; }
        /// <summary>
        /// The code name of the framework the apprenticeship is operating under
        /// </summary>
        public string FrameworkCodeName { get; set; }
        /// <summary>
        /// The primary id of the standard the apprenticeship is operating under
        /// </summary>
        public int? StandardId { get; set; }
        /// <summary>
        /// The code name of the sector the apprenticeship is operating under
        /// </summary>
        public string SectorCodeName { get; set; }
        /// <summary>
        /// The status of the vacancy. Always Live for public vacancies
        /// </summary>
        [Required]
        public VacancyStatus Status { get; set; }
        /// <summary>
        /// The displayed name the employer would prefer to be displayed on the vacancy
        /// </summary>
        public string EmployerAnonymousName { get; set; }
        /// <summary>
        /// True if the employer has requested a different name displayed on the vacancy other than their own
        /// </summary>
        [Required]
        public bool? IsAnonymousEmployer { get; set; }
        /// <summary>
        /// The number of positions available for this vacancy
        /// </summary>
        [Required]
        public int? NumberOfPositions { get; set; }
        /// <summary>
        /// The type of a vacancy. Always either Apprenticeship or Traineeship for live vacancies
        /// </summary>
        [Required]
        public VacancyType VacancyType { get; set; }
        /// <summary>
        /// The address of the vacancy. Not always the employer's address
        /// </summary>
        [Required]
        public PostalAddress Address { get; set; }
        /// <summary>
        /// The type of address of the vacancy. Indicates whether it's the employer's address or somewhere different
        /// </summary>
        [Required]
        public VacancyLocationType VacancyLocationType { get; set; }
        /// <summary>
        /// The primary identifier of the vacancy's employer
        /// </summary>
        [Required]
        public int EmployerId { get; set; }
        /// <summary>
        /// The employer's trading name
        /// </summary>
        [Required]
        public string EmployerName { get; set; }
        /// <summary>
        /// The training provider's trading name
        /// </summary>
        [Required]
        public string ProviderTradingName { get; set; }
        /// <summary>
        /// Object detailing the wage information for the vacancy
        /// </summary>
        [Required]
        public PublicWage Wage { get; set; }
    }
}