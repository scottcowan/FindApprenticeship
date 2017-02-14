// ReSharper disable InconsistentNaming
namespace SFA.Apprenticeships.Domain.Entities.Raa.Vacancies
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Reference;

    /// <summary>
    /// The full information of a vacancy summary
    /// </summary>
    public class Vacancy : VacancySummary, ICreatableEntity, IUpdatableEntity, ICloneable
    {
        /// <summary>
        /// (optional) If the vacancy has multiple locations, this property may contain additional information about those locations
        /// </summary>
        public string AdditionalLocationInformation { get; set; }
        /// <summary>
        /// QA comments regarding the supplied value for AdditionalLocationInformation
        /// </summary>
        public string AdditionalLocationInformationComment { get; set; }
        /// <summary>
        /// QA comments regarding the supplied value for ApprenticeshipLevel
        /// </summary>
        public string ApprenticeshipLevelComment { get; set; }
        /// <summary>
        /// QA comments regarding the supplied value for ClosingDate
        /// </summary>
        public string ClosingDateComment { get; set; }
        /// <summary>
        /// QA comments regarding the supplied values for ContactEmail, ContactName and ContactNumber
        /// </summary>
        public string ContactDetailsComment { get; set; }
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
        /// The username of the user account or API account used to create this vacancy
        /// </summary>
        public string CreatedByProviderUsername { get; set; }
        /// <summary>
        /// The qualifications the employer is looking for in prospective candidates. Not present for traineeships
        /// </summary>
        public string DesiredQualifications { get; set; }
        /// <summary>
        /// QA comments regarding the supplied value for DesiredQualifications
        /// </summary>
        public string DesiredQualificationsComment { get; set; }
        /// <summary>
        /// The skill set the employer is looking for prospective candidates to demonstrate
        /// </summary>
        public string DesiredSkills { get; set; }
        /// <summary>
        /// QA comments regarding the supplied value for DesiredSkills
        /// </summary>
        public string DesiredSkillsComment { get; set; }
        /// <summary>
        /// QA comments regarding the supplied value for Duration
        /// </summary>
        public string DurationComment { get; set; }
        /// <summary>
        /// For internal use only. Used to determine if this is a legacy vacancy or not
        /// </summary>
        public bool EditedInRaa { get; set; }
        /// <summary>
        /// The description of the employer
        /// </summary>
        public string EmployerDescription { get; set; }
        /// <summary>
        /// QA comments regarding the supplied value for EmployerDescription
        /// </summary>
        public string EmployerDescriptionComment { get; set; }
        /// <summary>
        /// A link to the employer's website
        /// </summary>
        public string EmployerWebsiteUrl { get; set; }
        /// <summary>
        /// QA comments regarding the supplied value for EmployerWebsiteUrl
        /// </summary>
        public string EmployerWebsiteUrlComment { get; set; }
        /// <summary>
        /// The first screening question for candidates
        /// </summary>
        public string FirstQuestion { get; set; }
        /// <summary>
        /// QA comments regarding the supplied value for FirstQuestion
        /// </summary>
        public string FirstQuestionComment { get; set; }
        /// <summary>
        /// QA comments regarding the supplied value for FrameworkCodeName
        /// </summary>
        public string FrameworkCodeNameComment { get; set; }
        /// <summary>
        /// The likely career progression, skills or qualifications a candidate will gain in this vacancy
        /// </summary>
        public string FutureProspects { get; set; }
        /// <summary>
        /// QA comments regarding the supplied value for FutureProspects
        /// </summary>
        public string FutureProspectsComment { get; set; }
        /// <summary>
        /// The primary identifier of the user account who last edited this vacancy 
        /// </summary>
        public int LastEditedById { get; set; }
        /// <summary>
        /// QA comments regarding the supplied values for VacancyLocations
        /// </summary>
        public string LocationAddressesComment { get; set; }
        /// <summary>
        /// The full, detailed description of the vacancy
        /// </summary>
        public string LongDescription { get; set; }
        /// <summary>
        /// QA comments regarding the supplied value for LongDescription
        /// </summary>
        public string LongDescriptionComment { get; set; }
        /// <summary>
        /// QA comments regarding the supplied value for NumberOfPositions
        /// </summary>
        public string NumberOfPositionsComment { get; set; }
        /// <summary>
        /// If applications for this vacancy are made via an external web site, this property must contain instructions on how to apply
        /// </summary>
        public string OfflineApplicationInstructions { get; set; }
        /// <summary>
        /// QA comments regarding the supplied value for OfflineApplicationInstructions
        /// </summary>
        public string OfflineApplicationInstructionsComment { get; set; }
        /// <summary>
        /// If applications for this vacancy are made via an external web site, this property must contain the web site URL
        /// </summary>
        public string OfflineApplicationUrl { get; set; }
        /// <summary>
        /// QA comments regarding the supplied value for OfflineApplicationUrl
        /// </summary>
        public string OfflineApplicationUrlComment { get; set; }
        /// <summary>
        /// Defines the type of offline vacancy. Unknown means that this is not an offline vacancy and Single and Multiple are for SpecificLocation and MultipleLocations location types
        /// </summary>
        public OfflineVacancyType? OfflineVacancyType { get; set; }
        /// <summary>
        /// Only present if the vacancy was created in the legacy system or via the legacy API. Contains any additional information the employer deems pertinent to the vacancy. Will be ignored if passed to the API
        /// </summary>
        public string OtherInformation { get; set; }
        /// <summary>
        /// QA comments regarding the supplied value for OtherInformation
        /// </summary>
        public string OtherInformationComment { get; set; }
        /// <summary>
        /// The soft skills and personal qualities the employer is looking for in prospective candidates
        /// </summary>
        public string PersonalQualities { get; set; }
        /// <summary>
        /// QA comments regarding the supplied value for PersonalQualities
        /// </summary>
        public string PersonalQualitiesComment { get; set; }
        /// <summary>
        /// QA comments regarding the supplied value for PossibleStartDate
        /// </summary>
        public string PossibleStartDateComment { get; set; }
        /// <summary>
        /// The second screening question for candidates
        /// </summary>
        public string SecondQuestion { get; set; }
        /// <summary>
        /// QA comments regarding the supplied value for SecondQuestion
        /// </summary>
        public string SecondQuestionComment { get; set; }
        /// <summary>
        /// QA comments regarding the supplied value for SectorCodeName
        /// </summary>
        public string SectorCodeNameComment { get; set; }
        /// <summary>
        /// QA comments regarding the supplied value for ShortDescription
        /// </summary>
        public string ShortDescriptionComment { get; set; }
        /// <summary>
        /// QA comments regarding the supplied value for StandardId
        /// </summary>
        public string StandardIdComment { get; set; }
        /// <summary>
        /// Any information that the employer feels a candidate should be mindful of when applying for this vacancy
        /// </summary>
        public string ThingsToConsider { get; set; }
        /// <summary>
        /// QA comments regarding the supplied value for ThingsToConsider
        /// </summary>
        public string ThingsToConsiderComment { get; set; }
        /// <summary>
        /// QA comments regarding the supplied value for the Title
        /// </summary>
        public string TitleComment { get; set; }
        /// <summary>
        /// The training that will be provided by the training provider associated with this vacancy
        /// </summary>
        public string TrainingProvided { get; set; }
        /// <summary>
        /// QA comments regarding the supplied value for TrainingProvided
        /// </summary>
        public string TrainingProvidedComment { get; set; }
        /// <summary>
        /// For internal use only. Specifies the source of the vacancy. Always set to API when created via the API
        /// </summary>
        public VacancySource VacancySource { get; set; }
        /// <summary>
        /// QA comments regarding the supplied value for Wage
        /// </summary>
        public string WageComment { get; set; }
        /// <summary>
        /// QA comments regarding the supplied value for WorkingWeek
        /// </summary>
        public string WorkingWeekComment { get; set; }
        /// <summary>
        /// QA comments regarding the supplied value for AnonymousEmployerDescription
        /// </summary>
        public string AnonymousEmployerDescriptionComment { get; set; }
        /// <summary>
        /// QA comments regarding the supplied value for AnonymousEmployerReason
        /// </summary>
        public string AnonymousEmployerReasonComment { get; set; }
        /// <summary>
        /// QA comments regarding the supplied value for AnonymousAboutTheEmployer
        /// </summary>
        public string AnonymousAboutTheEmployerComment { get; set; }
        /// <summary>
        /// The status of the specified framework
        /// </summary>
        public FrameworkStatusType FrameworkStatus { get; set; }
        /// <summary>
        /// The status of the specified standard
        /// </summary>
        public FrameworkStatusType StandardStatus { get; set; }
        /// <summary>
        /// The date this vacancy was created. Will be ignored if passed to the API
        /// </summary>
        public DateTime CreatedDateTime { get; set; }
        /// <summary>
        /// List of locations for this vacancy. Only supply if creating a MultipleLocations location vacancy
        /// </summary>
        public List<VacancyLocation> VacancyLocations { get; set; }

        public object Clone()
        {
            List<VacancyLocation> vacancyLocations = null;
            if (VacancyLocations != null)
            {
                vacancyLocations = new List<VacancyLocation>(VacancyLocations.Count);
                vacancyLocations.AddRange(VacancyLocations.Select(vacancyLocation => vacancyLocation.Clone()));
            }

            return new Vacancy
            {
                VacancyReferenceNumber = VacancyReferenceNumber,
                VacancyOwnerRelationshipId = VacancyOwnerRelationshipId,
                VacancyGuid = VacancyGuid,
                Title = Title,
                TitleComment = TitleComment,
                ShortDescription = ShortDescription,
                ShortDescriptionComment = ShortDescriptionComment,
                WorkingWeek = WorkingWeek,
                Wage = Wage,
                ExpectedDuration = ExpectedDuration,
                DurationType = DurationType,
                Duration = Duration,
                ClosingDate = ClosingDate,
                PossibleStartDate = PossibleStartDate,
                LongDescription = LongDescription,
                DesiredSkills = DesiredSkills,
                DesiredSkillsComment = DesiredSkillsComment,
                FutureProspects = FutureProspects,
                FutureProspectsComment = FutureProspectsComment,
                PersonalQualities = PersonalQualities,
                PersonalQualitiesComment = PersonalQualitiesComment,
                ThingsToConsider = ThingsToConsider,
                ThingsToConsiderComment = ThingsToConsiderComment,
                DesiredQualifications = DesiredQualifications,
                DesiredQualificationsComment = DesiredQualificationsComment,
                FirstQuestion = FirstQuestion,
                SecondQuestion = SecondQuestion,
                EmployerDescription = EmployerDescription,
                EmployerWebsiteUrl = EmployerWebsiteUrl,
                OfflineVacancy = OfflineVacancy,
                OfflineVacancyType = OfflineVacancyType,
                OfflineApplicationUrl = OfflineApplicationUrl,
                OfflineApplicationUrlComment = OfflineApplicationUrlComment,
                OfflineApplicationInstructions = OfflineApplicationInstructions,
                OfflineApplicationInstructionsComment = OfflineApplicationInstructionsComment,
                NoOfOfflineApplicants = NoOfOfflineApplicants,
                DateSubmitted = DateSubmitted,
                DateFirstSubmitted = DateFirstSubmitted,
                DateStartedToQA = DateStartedToQA,
                QAUserName = QAUserName,
                DateQAApproved = DateQAApproved,
                SubmissionCount = SubmissionCount,
                VacancyManagerId = VacancyManagerId,
                LastEditedById = LastEditedById,
                ParentVacancyId = ParentVacancyId,
                TrainingType = TrainingType,
                ApprenticeshipLevel = ApprenticeshipLevel,
                ApprenticeshipLevelComment = ApprenticeshipLevelComment,
                FrameworkCodeName = FrameworkCodeName,
                FrameworkStatus = FrameworkStatus,
                StandardStatus = StandardStatus,
                FrameworkCodeNameComment = FrameworkCodeNameComment,
                StandardId = StandardId,
                StandardIdComment = StandardIdComment,
                SectorCodeName = SectorCodeName,
                SectorCodeNameComment = SectorCodeNameComment,
                Status = Status,
                WageComment = WageComment,
                ClosingDateComment = ClosingDateComment,
                DurationComment = DurationComment,
                LongDescriptionComment = LongDescriptionComment,
                PossibleStartDateComment = PossibleStartDateComment,
                WorkingWeekComment = WorkingWeekComment,
                FirstQuestionComment = FirstQuestionComment,
                SecondQuestionComment = SecondQuestionComment,
                AdditionalLocationInformation = AdditionalLocationInformation,
                VacancyLocationType = VacancyLocationType,
                NumberOfPositions = NumberOfPositions,
                EmployerDescriptionComment = EmployerDescriptionComment,
                EmployerWebsiteUrlComment = EmployerWebsiteUrlComment,
                LocationAddressesComment = LocationAddressesComment,
                NumberOfPositionsComment = NumberOfPositionsComment,
                AdditionalLocationInformationComment = AdditionalLocationInformationComment,
                TrainingProvided = TrainingProvided,
                TrainingProvidedComment = TrainingProvidedComment,
                ContactName = ContactName,
                ContactNumber = ContactNumber,
                ContactEmail = ContactEmail,
                ContactDetailsComment = ContactDetailsComment,
                VacancyType = VacancyType,
                Address = Address,
                ContractOwnerId = ContractOwnerId,
                OriginalContractOwnerId = OriginalContractOwnerId,
                EditedInRaa = EditedInRaa,
                AnonymousEmployerReasonComment = AnonymousEmployerReasonComment,
                AnonymousEmployerDescriptionComment = AnonymousEmployerDescriptionComment,
                AnonymousAboutTheEmployerComment = AnonymousAboutTheEmployerComment,
                IsEmployerPositiveAboutDisability = IsEmployerPositiveAboutDisability,
                VacancyLocations = vacancyLocations
            };
        }

        protected bool Equals(Vacancy other)
        {
            return base.Equals(other) && string.Equals(AdditionalLocationInformation, other.AdditionalLocationInformation) && string.Equals(AdditionalLocationInformationComment, other.AdditionalLocationInformationComment) && string.Equals(ApprenticeshipLevelComment, other.ApprenticeshipLevelComment) && string.Equals(ClosingDateComment, other.ClosingDateComment) && string.Equals(ContactDetailsComment, other.ContactDetailsComment) && string.Equals(ContactEmail, other.ContactEmail) && string.Equals(ContactName, other.ContactName) && string.Equals(ContactNumber, other.ContactNumber) && string.Equals(CreatedByProviderUsername, other.CreatedByProviderUsername) && string.Equals(DesiredQualifications, other.DesiredQualifications) && string.Equals(DesiredQualificationsComment, other.DesiredQualificationsComment) && string.Equals(DesiredSkills, other.DesiredSkills) && string.Equals(DesiredSkillsComment, other.DesiredSkillsComment) && string.Equals(DurationComment, other.DurationComment) && EditedInRaa == other.EditedInRaa && string.Equals(EmployerDescription, other.EmployerDescription) && string.Equals(EmployerDescriptionComment, other.EmployerDescriptionComment) && string.Equals(EmployerWebsiteUrl, other.EmployerWebsiteUrl) && string.Equals(EmployerWebsiteUrlComment, other.EmployerWebsiteUrlComment) && string.Equals(FirstQuestion, other.FirstQuestion) && string.Equals(FirstQuestionComment, other.FirstQuestionComment) && string.Equals(FrameworkCodeNameComment, other.FrameworkCodeNameComment) && string.Equals(FutureProspects, other.FutureProspects) && string.Equals(FutureProspectsComment, other.FutureProspectsComment) && LastEditedById == other.LastEditedById && string.Equals(LocationAddressesComment, other.LocationAddressesComment) && string.Equals(LongDescription, other.LongDescription) && string.Equals(LongDescriptionComment, other.LongDescriptionComment) && string.Equals(NumberOfPositionsComment, other.NumberOfPositionsComment) && string.Equals(OfflineApplicationInstructions, other.OfflineApplicationInstructions) && string.Equals(OfflineApplicationInstructionsComment, other.OfflineApplicationInstructionsComment) && string.Equals(OfflineApplicationUrl, other.OfflineApplicationUrl) && string.Equals(OfflineApplicationUrlComment, other.OfflineApplicationUrlComment) && OfflineVacancyType == other.OfflineVacancyType && string.Equals(OtherInformation, other.OtherInformation) && string.Equals(OtherInformationComment, other.OtherInformationComment) && string.Equals(PersonalQualities, other.PersonalQualities) && string.Equals(PersonalQualitiesComment, other.PersonalQualitiesComment) && string.Equals(PossibleStartDateComment, other.PossibleStartDateComment) && string.Equals(SecondQuestion, other.SecondQuestion) && string.Equals(SecondQuestionComment, other.SecondQuestionComment) && string.Equals(SectorCodeNameComment, other.SectorCodeNameComment) && string.Equals(ShortDescriptionComment, other.ShortDescriptionComment) && string.Equals(StandardIdComment, other.StandardIdComment) && string.Equals(ThingsToConsider, other.ThingsToConsider) && string.Equals(ThingsToConsiderComment, other.ThingsToConsiderComment) && string.Equals(TitleComment, other.TitleComment) && string.Equals(TrainingProvided, other.TrainingProvided) && string.Equals(TrainingProvidedComment, other.TrainingProvidedComment) && VacancySource == other.VacancySource && string.Equals(WageComment, other.WageComment) && string.Equals(WorkingWeekComment, other.WorkingWeekComment) && string.Equals(AnonymousEmployerDescriptionComment, other.AnonymousEmployerDescriptionComment) && string.Equals(AnonymousEmployerReasonComment, other.AnonymousEmployerReasonComment) && string.Equals(AnonymousAboutTheEmployerComment, other.AnonymousAboutTheEmployerComment) && FrameworkStatus == other.FrameworkStatus && StandardStatus == other.StandardStatus && CreatedDateTime.Equals(other.CreatedDateTime);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Vacancy) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = base.GetHashCode();
                hashCode = (hashCode * 397) ^ (AdditionalLocationInformation != null ? AdditionalLocationInformation.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (AdditionalLocationInformationComment != null ? AdditionalLocationInformationComment.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (ApprenticeshipLevelComment != null ? ApprenticeshipLevelComment.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (ClosingDateComment != null ? ClosingDateComment.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (ContactDetailsComment != null ? ContactDetailsComment.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (ContactEmail != null ? ContactEmail.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (ContactName != null ? ContactName.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (ContactNumber != null ? ContactNumber.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (CreatedByProviderUsername != null ? CreatedByProviderUsername.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (DesiredQualifications != null ? DesiredQualifications.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (DesiredQualificationsComment != null ? DesiredQualificationsComment.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (DesiredSkills != null ? DesiredSkills.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (DesiredSkillsComment != null ? DesiredSkillsComment.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (DurationComment != null ? DurationComment.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ EditedInRaa.GetHashCode();
                hashCode = (hashCode * 397) ^ (EmployerDescription != null ? EmployerDescription.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (EmployerDescriptionComment != null ? EmployerDescriptionComment.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (EmployerWebsiteUrl != null ? EmployerWebsiteUrl.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (EmployerWebsiteUrlComment != null ? EmployerWebsiteUrlComment.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (FirstQuestion != null ? FirstQuestion.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (FirstQuestionComment != null ? FirstQuestionComment.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (FrameworkCodeNameComment != null ? FrameworkCodeNameComment.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (FutureProspects != null ? FutureProspects.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (FutureProspectsComment != null ? FutureProspectsComment.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ LastEditedById;
                hashCode = (hashCode * 397) ^ (LocationAddressesComment != null ? LocationAddressesComment.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (LongDescription != null ? LongDescription.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (LongDescriptionComment != null ? LongDescriptionComment.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (NumberOfPositionsComment != null ? NumberOfPositionsComment.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (OfflineApplicationInstructions != null ? OfflineApplicationInstructions.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (OfflineApplicationInstructionsComment != null ? OfflineApplicationInstructionsComment.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (OfflineApplicationUrl != null ? OfflineApplicationUrl.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (OfflineApplicationUrlComment != null ? OfflineApplicationUrlComment.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ OfflineVacancyType.GetHashCode();
                hashCode = (hashCode * 397) ^ (OtherInformation != null ? OtherInformation.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (OtherInformationComment != null ? OtherInformationComment.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (PersonalQualities != null ? PersonalQualities.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (PersonalQualitiesComment != null ? PersonalQualitiesComment.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (PossibleStartDateComment != null ? PossibleStartDateComment.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (SecondQuestion != null ? SecondQuestion.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (SecondQuestionComment != null ? SecondQuestionComment.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (SectorCodeNameComment != null ? SectorCodeNameComment.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (ShortDescriptionComment != null ? ShortDescriptionComment.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (StandardIdComment != null ? StandardIdComment.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (ThingsToConsider != null ? ThingsToConsider.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (ThingsToConsiderComment != null ? ThingsToConsiderComment.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (TitleComment != null ? TitleComment.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (TrainingProvided != null ? TrainingProvided.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (TrainingProvidedComment != null ? TrainingProvidedComment.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (int) VacancySource;
                hashCode = (hashCode * 397) ^ (WageComment != null ? WageComment.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (WorkingWeekComment != null ? WorkingWeekComment.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (AnonymousEmployerDescriptionComment != null ? AnonymousEmployerDescriptionComment.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (AnonymousEmployerReasonComment != null ? AnonymousEmployerReasonComment.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (AnonymousAboutTheEmployerComment != null ? AnonymousAboutTheEmployerComment.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (int) FrameworkStatus;
                hashCode = (hashCode * 397) ^ (int) StandardStatus;
                hashCode = (hashCode * 397) ^ CreatedDateTime.GetHashCode();
                return hashCode;
            }
        }
    }
}
