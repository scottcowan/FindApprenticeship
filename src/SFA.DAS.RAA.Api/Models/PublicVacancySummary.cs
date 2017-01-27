namespace SFA.DAS.RAA.Api.Models
{
    using System;
    using Apprenticeships.Domain.Entities.Raa.Locations;
    using Apprenticeships.Domain.Entities.Raa.Reference;
    using Apprenticeships.Domain.Entities.Raa.Vacancies;
    using Apprenticeships.Domain.Entities.Vacancies;
    using ApprenticeshipLevel = Apprenticeships.Domain.Entities.Raa.Vacancies.ApprenticeshipLevel;
    using TrainingType = Apprenticeships.Domain.Entities.Raa.Vacancies.TrainingType;
    using VacancyLocationType = Apprenticeships.Domain.Entities.Raa.Vacancies.VacancyLocationType;
    using VacancyType = Apprenticeships.Domain.Entities.Raa.Vacancies.VacancyType;

    public class PublicVacancySummary
    {
        public int VacancyId { get; set; }
        public int VacancyReferenceNumber { get; set; }
        public Guid VacancyGuid { get; set; }
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public string WorkingWeek { get; set; }
        public string ExpectedDuration { get; set; }
        public DurationType DurationType { get; set; }
        public int? Duration { get; set; }
        public DateTime? ClosingDate { get; set; }
        public DateTime? PossibleStartDate { get; set; }
        public bool? OfflineVacancy { get; set; }
        public TrainingType TrainingType { get; set; }
        public ApprenticeshipLevel ApprenticeshipLevel { get; set; }
        public string FrameworkCodeName { get; set; }
        public int? StandardId { get; set; }
        public string SectorCodeName { get; set; }
        public VacancyStatus Status { get; set; }
        public string EmployerAnonymousName { get; set; }
        public bool? IsAnonymousEmployer { get; set; }
        public string AnonymousAboutTheEmployer { get; set; }
        public int? NumberOfPositions { get; set; }
        public VacancyType VacancyType { get; set; }
        public PostalAddress Address { get; set; }
        public VacancyLocationType VacancyLocationType { get; set; }
        public int EmployerId { get; set; }
        public string EmployerName { get; set; }
        public string EmployerLocation { get; set; }
        public string ProviderTradingName { get; set; }
        public Wage Wage { get; set; }
    }
}