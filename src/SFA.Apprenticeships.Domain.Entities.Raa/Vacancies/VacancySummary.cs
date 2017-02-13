namespace SFA.Apprenticeships.Domain.Entities.Raa.Vacancies
{
    using Entities.Vacancies;
    using Locations;
    using Reference;
    using System;

    public class VacancySummary
    {
        public int VacancyId { get; set; }
        public int VacancyOwnerRelationshipId { get; set; }
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
        public int NoOfOfflineApplicants { get; set; }
        public DateTime? DateSubmitted { get; set; }
        public DateTime? DateFirstSubmitted { get; set; }
        public DateTime? DateStartedToQA { get; set; }
        public string QAUserName { get; set; }
        public DateTime? DateQAApproved { get; set; }
        public int SubmissionCount { get; set; }
        public int? VacancyManagerId { get; set; }
        public int? DeliveryOrganisationId { get; set; }
        public int? ParentVacancyId { get; set; }
        public TrainingType TrainingType { get; set; }
        public ApprenticeshipLevel ApprenticeshipLevel { get; set; }
        //TODO: Use Id rather than code name
        public string FrameworkCodeName { get; set; }
        public int? StandardId { get; set; }
        public string SectorCodeName { get; set; }
        public VacancyStatus Status { get; set; }
        public string EmployerAnonymousName { get; set; }
        public string EmployerAnonymousReason { get; set; }
        public bool? IsAnonymousEmployer { get; set; }
        public string AnonymousAboutTheEmployer { get; set; }
        public int? NumberOfPositions { get; set; }
        public VacancyType VacancyType { get; set; }
        public DateTime? UpdatedDateTime { get; set; }
        public PostalAddress Address { get; set; }
        public int ContractOwnerId { get; set; }
        public int OriginalContractOwnerId { get; set; }
        public RegionalTeam RegionalTeam { get; set; }
        public VacancyLocationType VacancyLocationType { get; set; }
        public int EmployerId { get; set; }
        public string EmployerName { get; set; }
        public string EmployerLocation { get; set; }
        public int NewApplicationCount { get; set; }
        public int ApplicantCount { get; set; }
        public string ProviderTradingName { get; set; }
        public DateTime CreatedDate { get; set; }
        public Wage Wage { get; set; }
        public bool? IsMultiLocation { get; set; }
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
