// Code generated by Microsoft (R) AutoRest Code Generator 0.17.0.0
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.

namespace SFA.DAS.RAA.Api.Client.V1.Models
{
    using System.Linq;

    public partial class Vacancy
    {
        /// <summary>
        /// Initializes a new instance of the Vacancy class.
        /// </summary>
        public Vacancy() { }

        /// <summary>
        /// Initializes a new instance of the Vacancy class.
        /// </summary>
        /// <param name="offlineVacancyType">Possible values include:
        /// 'Unknown', 'SingleUrl', 'MultiUrl'</param>
        /// <param name="vacancySource">Possible values include: 'Unknown',
        /// 'Av', 'Api', 'Raa'</param>
        /// <param name="frameworkStatus">Possible values include: 'Active',
        /// 'Ceased', 'PendingClosure'</param>
        /// <param name="standardStatus">Possible values include: 'Active',
        /// 'Ceased', 'PendingClosure'</param>
        /// <param name="durationType">Possible values include: 'Unknown',
        /// 'Weeks', 'Months', 'Years'</param>
        /// <param name="trainingType">Possible values include: 'Unknown',
        /// 'Frameworks', 'Standards', 'Sectors'</param>
        /// <param name="apprenticeshipLevel">Possible values include:
        /// 'Unknown', 'Intermediate', 'Advanced', 'Higher',
        /// 'FoundationDegree', 'Degree', 'Masters'</param>
        /// <param name="status">Possible values include: 'Unknown', 'Draft',
        /// 'Live', 'Referred', 'Deleted', 'Submitted', 'Closed',
        /// 'Withdrawn', 'Completed', 'PostedInError', 'ReservedForQA'</param>
        /// <param name="vacancyType">Possible values include: 'Unknown',
        /// 'Apprenticeship', 'Traineeship'</param>
        /// <param name="regionalTeam">Possible values include: 'Other',
        /// 'North', 'NorthWest', 'YorkshireAndHumberside', 'EastMidlands',
        /// 'WestMidlands', 'EastAnglia', 'SouthEast', 'SouthWest'</param>
        /// <param name="vacancyLocationType">Possible values include:
        /// 'Unknown', 'SpecificLocation', 'MultipleLocations',
        /// 'Nationwide'</param>
        public Vacancy(string additionalLocationInformation = default(string), string additionalLocationInformationComment = default(string), string apprenticeshipLevelComment = default(string), string closingDateComment = default(string), string contactDetailsComment = default(string), string contactEmail = default(string), string contactName = default(string), string contactNumber = default(string), string createdByProviderUsername = default(string), string desiredQualifications = default(string), string desiredQualificationsComment = default(string), string desiredSkills = default(string), string desiredSkillsComment = default(string), string durationComment = default(string), bool? editedInRaa = default(bool?), string employerDescription = default(string), string employerDescriptionComment = default(string), string employerWebsiteUrl = default(string), string employerWebsiteUrlComment = default(string), string firstQuestion = default(string), string firstQuestionComment = default(string), string frameworkCodeNameComment = default(string), string futureProspects = default(string), string futureProspectsComment = default(string), int? lastEditedById = default(int?), string localAuthorityCode = default(string), string locationAddressesComment = default(string), string longDescription = default(string), string longDescriptionComment = default(string), string numberOfPositionsComment = default(string), string offlineApplicationInstructions = default(string), string offlineApplicationInstructionsComment = default(string), string offlineApplicationUrl = default(string), string offlineApplicationUrlComment = default(string), string offlineVacancyType = default(string), string otherInformation = default(string), string otherInformationComment = default(string), string personalQualities = default(string), string personalQualitiesComment = default(string), string possibleStartDateComment = default(string), string secondQuestion = default(string), string secondQuestionComment = default(string), string sectorCodeNameComment = default(string), string shortDescriptionComment = default(string), string standardIdComment = default(string), string thingsToConsider = default(string), string thingsToConsiderComment = default(string), string titleComment = default(string), string trainingProvided = default(string), string trainingProvidedComment = default(string), string vacancySource = default(string), string wageComment = default(string), string workingWeekComment = default(string), string anonymousEmployerDescriptionComment = default(string), string anonymousEmployerReasonComment = default(string), string anonymousAboutTheEmployerComment = default(string), string frameworkStatus = default(string), string standardStatus = default(string), System.DateTime? createdDateTime = default(System.DateTime?), int? vacancyId = default(int?), int? vacancyOwnerRelationshipId = default(int?), int? vacancyReferenceNumber = default(int?), System.Guid? vacancyGuid = default(System.Guid?), string title = default(string), string shortDescription = default(string), string workingWeek = default(string), string expectedDuration = default(string), string durationType = default(string), int? duration = default(int?), System.DateTime? closingDate = default(System.DateTime?), System.DateTime? possibleStartDate = default(System.DateTime?), bool? offlineVacancy = default(bool?), int? noOfOfflineApplicants = default(int?), System.DateTime? dateSubmitted = default(System.DateTime?), System.DateTime? dateFirstSubmitted = default(System.DateTime?), System.DateTime? dateStartedToQA = default(System.DateTime?), string qAUserName = default(string), System.DateTime? dateQAApproved = default(System.DateTime?), int? submissionCount = default(int?), int? vacancyManagerId = default(int?), int? deliveryOrganisationId = default(int?), int? parentVacancyId = default(int?), string trainingType = default(string), string apprenticeshipLevel = default(string), string frameworkCodeName = default(string), int? standardId = default(int?), string sectorCodeName = default(string), string status = default(string), string employerAnonymousName = default(string), string employerAnonymousReason = default(string), bool? isAnonymousEmployer = default(bool?), string anonymousAboutTheEmployer = default(string), int? numberOfPositions = default(int?), string vacancyType = default(string), System.DateTime? updatedDateTime = default(System.DateTime?), PostalAddress address = default(PostalAddress), int? contractOwnerId = default(int?), int? originalContractOwnerId = default(int?), string regionalTeam = default(string), string vacancyLocationType = default(string), int? employerId = default(int?), string employerName = default(string), string employerLocation = default(string), int? newApplicationCount = default(int?), int? applicantCount = default(int?), string providerTradingName = default(string), System.DateTime? createdDate = default(System.DateTime?), Wage wage = default(Wage), bool? isMultiLocation = default(bool?))
        {
            AdditionalLocationInformation = additionalLocationInformation;
            AdditionalLocationInformationComment = additionalLocationInformationComment;
            ApprenticeshipLevelComment = apprenticeshipLevelComment;
            ClosingDateComment = closingDateComment;
            ContactDetailsComment = contactDetailsComment;
            ContactEmail = contactEmail;
            ContactName = contactName;
            ContactNumber = contactNumber;
            CreatedByProviderUsername = createdByProviderUsername;
            DesiredQualifications = desiredQualifications;
            DesiredQualificationsComment = desiredQualificationsComment;
            DesiredSkills = desiredSkills;
            DesiredSkillsComment = desiredSkillsComment;
            DurationComment = durationComment;
            EditedInRaa = editedInRaa;
            EmployerDescription = employerDescription;
            EmployerDescriptionComment = employerDescriptionComment;
            EmployerWebsiteUrl = employerWebsiteUrl;
            EmployerWebsiteUrlComment = employerWebsiteUrlComment;
            FirstQuestion = firstQuestion;
            FirstQuestionComment = firstQuestionComment;
            FrameworkCodeNameComment = frameworkCodeNameComment;
            FutureProspects = futureProspects;
            FutureProspectsComment = futureProspectsComment;
            LastEditedById = lastEditedById;
            LocalAuthorityCode = localAuthorityCode;
            LocationAddressesComment = locationAddressesComment;
            LongDescription = longDescription;
            LongDescriptionComment = longDescriptionComment;
            NumberOfPositionsComment = numberOfPositionsComment;
            OfflineApplicationInstructions = offlineApplicationInstructions;
            OfflineApplicationInstructionsComment = offlineApplicationInstructionsComment;
            OfflineApplicationUrl = offlineApplicationUrl;
            OfflineApplicationUrlComment = offlineApplicationUrlComment;
            OfflineVacancyType = offlineVacancyType;
            OtherInformation = otherInformation;
            OtherInformationComment = otherInformationComment;
            PersonalQualities = personalQualities;
            PersonalQualitiesComment = personalQualitiesComment;
            PossibleStartDateComment = possibleStartDateComment;
            SecondQuestion = secondQuestion;
            SecondQuestionComment = secondQuestionComment;
            SectorCodeNameComment = sectorCodeNameComment;
            ShortDescriptionComment = shortDescriptionComment;
            StandardIdComment = standardIdComment;
            ThingsToConsider = thingsToConsider;
            ThingsToConsiderComment = thingsToConsiderComment;
            TitleComment = titleComment;
            TrainingProvided = trainingProvided;
            TrainingProvidedComment = trainingProvidedComment;
            VacancySource = vacancySource;
            WageComment = wageComment;
            WorkingWeekComment = workingWeekComment;
            AnonymousEmployerDescriptionComment = anonymousEmployerDescriptionComment;
            AnonymousEmployerReasonComment = anonymousEmployerReasonComment;
            AnonymousAboutTheEmployerComment = anonymousAboutTheEmployerComment;
            FrameworkStatus = frameworkStatus;
            StandardStatus = standardStatus;
            CreatedDateTime = createdDateTime;
            VacancyId = vacancyId;
            VacancyOwnerRelationshipId = vacancyOwnerRelationshipId;
            VacancyReferenceNumber = vacancyReferenceNumber;
            VacancyGuid = vacancyGuid;
            Title = title;
            ShortDescription = shortDescription;
            WorkingWeek = workingWeek;
            ExpectedDuration = expectedDuration;
            DurationType = durationType;
            Duration = duration;
            ClosingDate = closingDate;
            PossibleStartDate = possibleStartDate;
            OfflineVacancy = offlineVacancy;
            NoOfOfflineApplicants = noOfOfflineApplicants;
            DateSubmitted = dateSubmitted;
            DateFirstSubmitted = dateFirstSubmitted;
            DateStartedToQA = dateStartedToQA;
            QAUserName = qAUserName;
            DateQAApproved = dateQAApproved;
            SubmissionCount = submissionCount;
            VacancyManagerId = vacancyManagerId;
            DeliveryOrganisationId = deliveryOrganisationId;
            ParentVacancyId = parentVacancyId;
            TrainingType = trainingType;
            ApprenticeshipLevel = apprenticeshipLevel;
            FrameworkCodeName = frameworkCodeName;
            StandardId = standardId;
            SectorCodeName = sectorCodeName;
            Status = status;
            EmployerAnonymousName = employerAnonymousName;
            EmployerAnonymousReason = employerAnonymousReason;
            IsAnonymousEmployer = isAnonymousEmployer;
            AnonymousAboutTheEmployer = anonymousAboutTheEmployer;
            NumberOfPositions = numberOfPositions;
            VacancyType = vacancyType;
            UpdatedDateTime = updatedDateTime;
            Address = address;
            ContractOwnerId = contractOwnerId;
            OriginalContractOwnerId = originalContractOwnerId;
            RegionalTeam = regionalTeam;
            VacancyLocationType = vacancyLocationType;
            EmployerId = employerId;
            EmployerName = employerName;
            EmployerLocation = employerLocation;
            NewApplicationCount = newApplicationCount;
            ApplicantCount = applicantCount;
            ProviderTradingName = providerTradingName;
            CreatedDate = createdDate;
            Wage = wage;
            IsMultiLocation = isMultiLocation;
        }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "AdditionalLocationInformation")]
        public string AdditionalLocationInformation { get; set; }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "AdditionalLocationInformationComment")]
        public string AdditionalLocationInformationComment { get; set; }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "ApprenticeshipLevelComment")]
        public string ApprenticeshipLevelComment { get; set; }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "ClosingDateComment")]
        public string ClosingDateComment { get; set; }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "ContactDetailsComment")]
        public string ContactDetailsComment { get; set; }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "ContactEmail")]
        public string ContactEmail { get; set; }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "ContactName")]
        public string ContactName { get; set; }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "ContactNumber")]
        public string ContactNumber { get; set; }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "CreatedByProviderUsername")]
        public string CreatedByProviderUsername { get; set; }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "DesiredQualifications")]
        public string DesiredQualifications { get; set; }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "DesiredQualificationsComment")]
        public string DesiredQualificationsComment { get; set; }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "DesiredSkills")]
        public string DesiredSkills { get; set; }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "DesiredSkillsComment")]
        public string DesiredSkillsComment { get; set; }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "DurationComment")]
        public string DurationComment { get; set; }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "EditedInRaa")]
        public bool? EditedInRaa { get; set; }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "EmployerDescription")]
        public string EmployerDescription { get; set; }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "EmployerDescriptionComment")]
        public string EmployerDescriptionComment { get; set; }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "EmployerWebsiteUrl")]
        public string EmployerWebsiteUrl { get; set; }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "EmployerWebsiteUrlComment")]
        public string EmployerWebsiteUrlComment { get; set; }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "FirstQuestion")]
        public string FirstQuestion { get; set; }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "FirstQuestionComment")]
        public string FirstQuestionComment { get; set; }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "FrameworkCodeNameComment")]
        public string FrameworkCodeNameComment { get; set; }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "FutureProspects")]
        public string FutureProspects { get; set; }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "FutureProspectsComment")]
        public string FutureProspectsComment { get; set; }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "LastEditedById")]
        public int? LastEditedById { get; set; }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "LocalAuthorityCode")]
        public string LocalAuthorityCode { get; set; }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "LocationAddressesComment")]
        public string LocationAddressesComment { get; set; }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "LongDescription")]
        public string LongDescription { get; set; }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "LongDescriptionComment")]
        public string LongDescriptionComment { get; set; }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "NumberOfPositionsComment")]
        public string NumberOfPositionsComment { get; set; }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "OfflineApplicationInstructions")]
        public string OfflineApplicationInstructions { get; set; }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "OfflineApplicationInstructionsComment")]
        public string OfflineApplicationInstructionsComment { get; set; }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "OfflineApplicationUrl")]
        public string OfflineApplicationUrl { get; set; }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "OfflineApplicationUrlComment")]
        public string OfflineApplicationUrlComment { get; set; }

        /// <summary>
        /// Gets or sets possible values include: 'Unknown', 'SingleUrl',
        /// 'MultiUrl'
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "OfflineVacancyType")]
        public string OfflineVacancyType { get; set; }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "OtherInformation")]
        public string OtherInformation { get; set; }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "OtherInformationComment")]
        public string OtherInformationComment { get; set; }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "PersonalQualities")]
        public string PersonalQualities { get; set; }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "PersonalQualitiesComment")]
        public string PersonalQualitiesComment { get; set; }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "PossibleStartDateComment")]
        public string PossibleStartDateComment { get; set; }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "SecondQuestion")]
        public string SecondQuestion { get; set; }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "SecondQuestionComment")]
        public string SecondQuestionComment { get; set; }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "SectorCodeNameComment")]
        public string SectorCodeNameComment { get; set; }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "ShortDescriptionComment")]
        public string ShortDescriptionComment { get; set; }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "StandardIdComment")]
        public string StandardIdComment { get; set; }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "ThingsToConsider")]
        public string ThingsToConsider { get; set; }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "ThingsToConsiderComment")]
        public string ThingsToConsiderComment { get; set; }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "TitleComment")]
        public string TitleComment { get; set; }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "TrainingProvided")]
        public string TrainingProvided { get; set; }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "TrainingProvidedComment")]
        public string TrainingProvidedComment { get; set; }

        /// <summary>
        /// Gets or sets possible values include: 'Unknown', 'Av', 'Api', 'Raa'
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "VacancySource")]
        public string VacancySource { get; set; }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "WageComment")]
        public string WageComment { get; set; }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "WorkingWeekComment")]
        public string WorkingWeekComment { get; set; }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "AnonymousEmployerDescriptionComment")]
        public string AnonymousEmployerDescriptionComment { get; set; }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "AnonymousEmployerReasonComment")]
        public string AnonymousEmployerReasonComment { get; set; }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "AnonymousAboutTheEmployerComment")]
        public string AnonymousAboutTheEmployerComment { get; set; }

        /// <summary>
        /// Gets or sets possible values include: 'Active', 'Ceased',
        /// 'PendingClosure'
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "FrameworkStatus")]
        public string FrameworkStatus { get; set; }

        /// <summary>
        /// Gets or sets possible values include: 'Active', 'Ceased',
        /// 'PendingClosure'
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "StandardStatus")]
        public string StandardStatus { get; set; }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "CreatedDateTime")]
        public System.DateTime? CreatedDateTime { get; set; }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "VacancyId")]
        public int? VacancyId { get; set; }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "VacancyOwnerRelationshipId")]
        public int? VacancyOwnerRelationshipId { get; set; }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "VacancyReferenceNumber")]
        public int? VacancyReferenceNumber { get; set; }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "VacancyGuid")]
        public System.Guid? VacancyGuid { get; set; }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "Title")]
        public string Title { get; set; }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "ShortDescription")]
        public string ShortDescription { get; set; }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "WorkingWeek")]
        public string WorkingWeek { get; set; }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "ExpectedDuration")]
        public string ExpectedDuration { get; set; }

        /// <summary>
        /// Gets or sets possible values include: 'Unknown', 'Weeks',
        /// 'Months', 'Years'
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "DurationType")]
        public string DurationType { get; set; }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "Duration")]
        public int? Duration { get; set; }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "ClosingDate")]
        public System.DateTime? ClosingDate { get; set; }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "PossibleStartDate")]
        public System.DateTime? PossibleStartDate { get; set; }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "OfflineVacancy")]
        public bool? OfflineVacancy { get; set; }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "NoOfOfflineApplicants")]
        public int? NoOfOfflineApplicants { get; set; }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "DateSubmitted")]
        public System.DateTime? DateSubmitted { get; set; }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "DateFirstSubmitted")]
        public System.DateTime? DateFirstSubmitted { get; set; }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "DateStartedToQA")]
        public System.DateTime? DateStartedToQA { get; set; }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "QAUserName")]
        public string QAUserName { get; set; }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "DateQAApproved")]
        public System.DateTime? DateQAApproved { get; set; }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "SubmissionCount")]
        public int? SubmissionCount { get; set; }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "VacancyManagerId")]
        public int? VacancyManagerId { get; set; }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "DeliveryOrganisationId")]
        public int? DeliveryOrganisationId { get; set; }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "ParentVacancyId")]
        public int? ParentVacancyId { get; set; }

        /// <summary>
        /// Gets or sets possible values include: 'Unknown', 'Frameworks',
        /// 'Standards', 'Sectors'
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "TrainingType")]
        public string TrainingType { get; set; }

        /// <summary>
        /// Gets or sets possible values include: 'Unknown', 'Intermediate',
        /// 'Advanced', 'Higher', 'FoundationDegree', 'Degree', 'Masters'
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "ApprenticeshipLevel")]
        public string ApprenticeshipLevel { get; set; }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "FrameworkCodeName")]
        public string FrameworkCodeName { get; set; }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "StandardId")]
        public int? StandardId { get; set; }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "SectorCodeName")]
        public string SectorCodeName { get; set; }

        /// <summary>
        /// Gets or sets possible values include: 'Unknown', 'Draft', 'Live',
        /// 'Referred', 'Deleted', 'Submitted', 'Closed', 'Withdrawn',
        /// 'Completed', 'PostedInError', 'ReservedForQA'
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "Status")]
        public string Status { get; set; }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "EmployerAnonymousName")]
        public string EmployerAnonymousName { get; set; }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "EmployerAnonymousReason")]
        public string EmployerAnonymousReason { get; set; }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "IsAnonymousEmployer")]
        public bool? IsAnonymousEmployer { get; set; }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "AnonymousAboutTheEmployer")]
        public string AnonymousAboutTheEmployer { get; set; }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "NumberOfPositions")]
        public int? NumberOfPositions { get; set; }

        /// <summary>
        /// Gets or sets possible values include: 'Unknown', 'Apprenticeship',
        /// 'Traineeship'
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "VacancyType")]
        public string VacancyType { get; set; }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "UpdatedDateTime")]
        public System.DateTime? UpdatedDateTime { get; set; }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "Address")]
        public PostalAddress Address { get; set; }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "ContractOwnerId")]
        public int? ContractOwnerId { get; set; }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "OriginalContractOwnerId")]
        public int? OriginalContractOwnerId { get; set; }

        /// <summary>
        /// Gets or sets possible values include: 'Other', 'North',
        /// 'NorthWest', 'YorkshireAndHumberside', 'EastMidlands',
        /// 'WestMidlands', 'EastAnglia', 'SouthEast', 'SouthWest'
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "RegionalTeam")]
        public string RegionalTeam { get; set; }

        /// <summary>
        /// Gets or sets possible values include: 'Unknown',
        /// 'SpecificLocation', 'MultipleLocations', 'Nationwide'
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "VacancyLocationType")]
        public string VacancyLocationType { get; set; }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "EmployerId")]
        public int? EmployerId { get; set; }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "EmployerName")]
        public string EmployerName { get; set; }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "EmployerLocation")]
        public string EmployerLocation { get; set; }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "NewApplicationCount")]
        public int? NewApplicationCount { get; set; }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "ApplicantCount")]
        public int? ApplicantCount { get; set; }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "ProviderTradingName")]
        public string ProviderTradingName { get; set; }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "CreatedDate")]
        public System.DateTime? CreatedDate { get; set; }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "Wage")]
        public Wage Wage { get; set; }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "IsMultiLocation")]
        public bool? IsMultiLocation { get; set; }

    }
}
