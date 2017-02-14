namespace SFA.Apprenticeships.Domain.Entities.Raa.Vacancies
{
    using Entities.Vacancies;
    using Locations;
    using Reference;
    using System;

    /// <summary>
    /// The full summary information of a vacancy summary
    /// </summary>
    public class VacancySummary
    {
        /// <summary>
        /// The primary identifier for the vacancy. Automatically generated when vacancy is created
        /// </summary>
        public int VacancyId { get; set; }
        /// <summary>
        /// The primary identifier of the linking object between a provider site and an employer. This must exist and be linked to a provider site owned by the provider identified by your API key
        /// </summary>
        public int VacancyOwnerRelationshipId { get; set; }
        /// <summary>
        /// The secondary reference number for the vacancy. The numerical part of the vacancy reference e.g. 123456 for VAC000123456. Automatically generated when vacancy is created
        /// </summary>
        public int VacancyReferenceNumber { get; set; }
        /// <summary>
        /// The secondary GUID identifier for the vacancy. Must be supplied when creating the vacancy and must be unique per vacancy
        /// </summary>
        public Guid VacancyGuid { get; set; }
        /// <summary>
        /// The main heading for the vacancy e.g. Retail Apprentice
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// A short paragraph of text giving a brief overview of the role
        /// </summary>
        public string ShortDescription { get; set; }
        /// <summary>
        /// A description of the working week e.g. 9-5 Monday to Friday with occasional weekend work
        /// </summary>
        public string WorkingWeek { get; set; }
        /// <summary>
        /// The text based expected duration of a vacancy. Only set if the vacancy originated in the legacy system or the legacy API and will be ignored if passed to the REST API
        /// </summary>
        public string ExpectedDuration { get; set; }
        /// <summary>
        /// Clarification of the Duration property specifying weeks, months or years
        /// </summary>
        public DurationType DurationType { get; set; }
        /// <summary>
        /// The estimated duration of the vacancy
        /// </summary>
        public int? Duration { get; set; }
        /// <summary>
        /// The closing date for applications. Must be in the future
        /// </summary>
        public DateTime? ClosingDate { get; set; }
        /// <summary>
        /// The likely start date for the vacancy. Must be in the future and after the closing date
        /// </summary>
        public DateTime? PossibleStartDate { get; set; }
        /// <summary>
        /// If true, applications for this vacancy will be made on an external recruitment system rather than on Find an Apprenticeship/Traineeship. OfflineApplicationUrl must also be supplied if this field is set to true
        /// </summary>
        public bool? OfflineVacancy { get; set; }
        /// <summary>
        /// Provides the click count logged by candidates clicking on the offline application link. Will be ignored if passed to the API
        /// </summary>
        public int NoOfOfflineApplicants { get; set; }
        /// <summary>
        /// The date this vacancy was last submitted to the QA process. Will be ignored if passed to the API
        /// </summary>
        public DateTime? DateSubmitted { get; set; }
        /// <summary>
        /// The date this vacancy was first submitted to the QA process. Will be ignored if passed to the API
        /// </summary>
        public DateTime? DateFirstSubmitted { get; set; }
        /// <summary>
        /// The date this vacancy was last reviewed by a member of the QA team. Will be ignored if passed to the API
        /// </summary>
        public DateTime? DateStartedToQA { get; set; }
        /// <summary>
        /// The username of the member of the QA team who last reviewed this vacancy. Will be ignored if passed to the API
        /// </summary>
        public string QAUserName { get; set; }
        /// <summary>
        /// The date this vacancy went live. Will be ignored if passed to the API
        /// </summary>
        public DateTime? DateQAApproved { get; set; }
        /// <summary>
        /// The number of times this vacancy has been submitted to QA for review
        /// </summary>
        public int SubmissionCount { get; set; }
        /// <summary>
        /// The primary identifier of the provider site that manages the vacancy. This includes managing applications for this vacancy. Always set to the id of the provider site specified in the supplied vacancy owner relationship
        /// </summary>
        public int? VacancyManagerId { get; set; }
        /// <summary>
        /// The primary identifier of the provider site that delivers the candidate training for the vacancy. This includes managing applications for this vacancy. Always set to the id of the provider site specified in the supplied vacancy owner relationship
        /// </summary>
        public int? DeliveryOrganisationId { get; set; }
        /// <summary>
        /// Set when a multi location vacancy is approved. The primary identifier of the original parent vacancy the child location vacancies was cloned from. Will be ignored if passed to the API
        /// </summary>
        public int? ParentVacancyId { get; set; }
        /// <summary>
        /// Specifies the classification system of the training the apprentice will receive from the apprenticeship/traineeship. 
        /// Either via a framework or standard if the vacancy is an apprenticeship or a sector for traineeships
        /// </summary>
        public TrainingType TrainingType { get; set; }
        /// <summary>
        /// The level of the apprenticeship. Related to the TrainingType and the education level the apprentice will gain or requires. Can only be specified for Frameworks and for Apprenticeships
        /// </summary>
        public ApprenticeshipLevel ApprenticeshipLevel { get; set; }
        /// <summary>
        /// The code name of the framework the apprenticeship is operating under
        /// </summary>
        //TODO: Use Id rather than code name
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
        /// The status of the vacancy. Will always be set to Draft when creating a vacancy
        /// </summary>
        public VacancyStatus Status { get; set; }
        /// <summary>
        /// The displayed name the employer would prefer to be displayed on the vacancy
        /// </summary>
        public string EmployerAnonymousName { get; set; }
        /// <summary>
        /// The reason the employer has requested a different name to be displayed on the vacancy
        /// </summary>
        public string EmployerAnonymousReason { get; set; }
        /// <summary>
        /// Set to true if the employer has requested a different name displayed on the vacancy other than their own
        /// </summary>
        public bool? IsAnonymousEmployer { get; set; }
        /// <summary>
        /// The description the employer would prefer to be displayed on the vacancy
        /// </summary>
        public string AnonymousAboutTheEmployer { get; set; }
        /// <summary>
        /// The number of positions available for this vacancy
        /// </summary>
        public int? NumberOfPositions { get; set; }
        /// <summary>
        /// The type of a vacancy
        /// </summary>
        public VacancyType VacancyType { get; set; }
        /// <summary>
        /// The last time this vacancy was updated. Will be ignored if passed to the API
        /// </summary>
        public DateTime? UpdatedDateTime { get; set; }
        /// <summary>
        /// The address of the vacancy. If the VacancyLocationType is SpecificLocation or Nationwide this will be set to the employer's address. Will be ignored if passed to the API
        /// </summary>
        public PostalAddress Address { get; set; }
        /// <summary>
        /// The primary identifier of the provider who has the funding contract with the SFA
        /// </summary>
        public int ContractOwnerId { get; set; }
        /// <summary>
        /// The primary identifier of the original provider who has the funding contract with the SFA
        /// </summary>
        public int OriginalContractOwnerId { get; set; }
        /// <summary>
        /// For QA usage. Specifies which regional QA team will review this vacancy. Will be ignored if passed to the API
        /// </summary>
        public RegionalTeam RegionalTeam { get; set; }
        /// <summary>
        /// (Required) The type of address of the vacancy. Indicates whether it's the employer's address or somewhere different
        /// </summary>
        public VacancyLocationType VacancyLocationType { get; set; }
        /// <summary>
        /// The primary identifier of the vacancy's employer. Will be ignored if passed to the API
        /// </summary>
        public int EmployerId { get; set; }
        /// <summary>
        /// The employer's trading name. Will be ignored if passed to the API
        /// </summary>
        public string EmployerName { get; set; }
        /// <summary>
        /// The employer's location (town or postcode). Will be ignored if passed to the API
        /// </summary>
        public string EmployerLocation { get; set; }
        /// <summary>
        /// The count of new applications submitted by candidates. A new application is one that hasn't been reviewed in Recruit an Apprentice
        /// </summary>
        public int NewApplicationCount { get; set; }
        /// <summary>
        /// The total account of all applications submitted by candidates
        /// </summary>
        public int ApplicantCount { get; set; }
        /// <summary>
        /// The training provider's trading name. Will be ignored if passed to the API
        /// </summary>
        public string ProviderTradingName { get; set; }
        /// <summary>
        /// The date this vacancy was created. Will be ignored if passed to the API
        /// </summary>
        public DateTime CreatedDate { get; set; }
        /// <summary>
        /// Object detailing the wage information for the vacancy
        /// </summary>
        public Wage Wage { get; set; }
        /// <summary>
        /// Set to true if there is more than one vacancy location associated with this vacancy
        /// </summary>
        public bool? IsMultiLocation { get; set; }
        /// <summary>
        /// If true, the employer actively encourages candidates with a disability to apply. Will be ignored if passed to the API
        /// </summary>
        public bool IsEmployerPositiveAboutDisability { get; set; }

        protected bool Equals(VacancySummary other)
        {
            return VacancyId == other.VacancyId && VacancyOwnerRelationshipId == other.VacancyOwnerRelationshipId && VacancyReferenceNumber == other.VacancyReferenceNumber && VacancyGuid.Equals(other.VacancyGuid) && string.Equals(Title, other.Title) && string.Equals(ShortDescription, other.ShortDescription) && string.Equals(WorkingWeek, other.WorkingWeek) && string.Equals(ExpectedDuration, other.ExpectedDuration) && DurationType == other.DurationType && Duration == other.Duration && ClosingDate.Equals(other.ClosingDate) && PossibleStartDate.Equals(other.PossibleStartDate) && OfflineVacancy == other.OfflineVacancy && NoOfOfflineApplicants == other.NoOfOfflineApplicants && DateSubmitted.Equals(other.DateSubmitted) && DateFirstSubmitted.Equals(other.DateFirstSubmitted) && DateStartedToQA.Equals(other.DateStartedToQA) && string.Equals(QAUserName, other.QAUserName) && DateQAApproved.Equals(other.DateQAApproved) && SubmissionCount == other.SubmissionCount && VacancyManagerId == other.VacancyManagerId && DeliveryOrganisationId == other.DeliveryOrganisationId && ParentVacancyId == other.ParentVacancyId && TrainingType == other.TrainingType && ApprenticeshipLevel == other.ApprenticeshipLevel && string.Equals(FrameworkCodeName, other.FrameworkCodeName) && StandardId == other.StandardId && string.Equals(SectorCodeName, other.SectorCodeName) && Status == other.Status && string.Equals(EmployerAnonymousName, other.EmployerAnonymousName) && string.Equals(EmployerAnonymousReason, other.EmployerAnonymousReason) && IsAnonymousEmployer == other.IsAnonymousEmployer && string.Equals(AnonymousAboutTheEmployer, other.AnonymousAboutTheEmployer) && NumberOfPositions == other.NumberOfPositions && VacancyType == other.VacancyType && UpdatedDateTime.Equals(other.UpdatedDateTime) && Equals(Address, other.Address) && ContractOwnerId == other.ContractOwnerId && OriginalContractOwnerId == other.OriginalContractOwnerId && RegionalTeam == other.RegionalTeam && VacancyLocationType == other.VacancyLocationType && EmployerId == other.EmployerId && string.Equals(EmployerName, other.EmployerName) && string.Equals(EmployerLocation, other.EmployerLocation) && NewApplicationCount == other.NewApplicationCount && ApplicantCount == other.ApplicantCount && string.Equals(ProviderTradingName, other.ProviderTradingName) && CreatedDate.Equals(other.CreatedDate) && Equals(Wage, other.Wage) && IsMultiLocation == other.IsMultiLocation && IsEmployerPositiveAboutDisability == other.IsEmployerPositiveAboutDisability;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((VacancySummary) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = VacancyId;
                hashCode = (hashCode * 397) ^ VacancyOwnerRelationshipId;
                hashCode = (hashCode * 397) ^ VacancyReferenceNumber;
                hashCode = (hashCode * 397) ^ VacancyGuid.GetHashCode();
                hashCode = (hashCode * 397) ^ (Title != null ? Title.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (ShortDescription != null ? ShortDescription.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (WorkingWeek != null ? WorkingWeek.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (ExpectedDuration != null ? ExpectedDuration.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (int) DurationType;
                hashCode = (hashCode * 397) ^ Duration.GetHashCode();
                hashCode = (hashCode * 397) ^ ClosingDate.GetHashCode();
                hashCode = (hashCode * 397) ^ PossibleStartDate.GetHashCode();
                hashCode = (hashCode * 397) ^ OfflineVacancy.GetHashCode();
                hashCode = (hashCode * 397) ^ NoOfOfflineApplicants;
                hashCode = (hashCode * 397) ^ DateSubmitted.GetHashCode();
                hashCode = (hashCode * 397) ^ DateFirstSubmitted.GetHashCode();
                hashCode = (hashCode * 397) ^ DateStartedToQA.GetHashCode();
                hashCode = (hashCode * 397) ^ (QAUserName != null ? QAUserName.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ DateQAApproved.GetHashCode();
                hashCode = (hashCode * 397) ^ SubmissionCount;
                hashCode = (hashCode * 397) ^ VacancyManagerId.GetHashCode();
                hashCode = (hashCode * 397) ^ DeliveryOrganisationId.GetHashCode();
                hashCode = (hashCode * 397) ^ ParentVacancyId.GetHashCode();
                hashCode = (hashCode * 397) ^ (int) TrainingType;
                hashCode = (hashCode * 397) ^ (int) ApprenticeshipLevel;
                hashCode = (hashCode * 397) ^ (FrameworkCodeName != null ? FrameworkCodeName.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ StandardId.GetHashCode();
                hashCode = (hashCode * 397) ^ (SectorCodeName != null ? SectorCodeName.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (int) Status;
                hashCode = (hashCode * 397) ^ (EmployerAnonymousName != null ? EmployerAnonymousName.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (EmployerAnonymousReason != null ? EmployerAnonymousReason.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ IsAnonymousEmployer.GetHashCode();
                hashCode = (hashCode * 397) ^ (AnonymousAboutTheEmployer != null ? AnonymousAboutTheEmployer.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ NumberOfPositions.GetHashCode();
                hashCode = (hashCode * 397) ^ (int) VacancyType;
                hashCode = (hashCode * 397) ^ UpdatedDateTime.GetHashCode();
                hashCode = (hashCode * 397) ^ (Address != null ? Address.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ ContractOwnerId;
                hashCode = (hashCode * 397) ^ OriginalContractOwnerId;
                hashCode = (hashCode * 397) ^ (int) RegionalTeam;
                hashCode = (hashCode * 397) ^ (int) VacancyLocationType;
                hashCode = (hashCode * 397) ^ EmployerId;
                hashCode = (hashCode * 397) ^ (EmployerName != null ? EmployerName.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (EmployerLocation != null ? EmployerLocation.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ NewApplicationCount;
                hashCode = (hashCode * 397) ^ ApplicantCount;
                hashCode = (hashCode * 397) ^ (ProviderTradingName != null ? ProviderTradingName.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ CreatedDate.GetHashCode();
                hashCode = (hashCode * 397) ^ (Wage != null ? Wage.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ IsMultiLocation.GetHashCode();
                hashCode = (hashCode * 397) ^ IsEmployerPositiveAboutDisability.GetHashCode();
                return hashCode;
            }
        }
    }
}
