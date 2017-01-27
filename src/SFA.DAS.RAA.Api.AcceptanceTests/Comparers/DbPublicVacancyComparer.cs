namespace SFA.DAS.RAA.Api.AcceptanceTests.Comparers
{
    using System;
    using Apprenticeships.Domain.Entities.Raa.Reference;
    using Apprenticeships.Domain.Entities.Raa.Vacancies;
    using Apprenticeships.Domain.Entities.Vacancies;
    using DbVacancy = Apprenticeships.Infrastructure.Repositories.Sql.Schemas.Vacancy.Entities.Vacancy;

    public class DbPublicVacancyComparer : IMultiEqualityComparer<DbVacancy, Vacancy>
    {
        public bool Equals(DbVacancy object1, Vacancy object2)
        {
            if (ReferenceEquals(null, object1)) return false;
            if (ReferenceEquals(null, object2)) return false;

            var wageType = object1.WageType == (int)WageType.LegacyWeekly ? WageType.Custom : (WageType)object1.WageType;
            var wageUnit = object1.WageUnitId.HasValue ? (WageUnit)object1.WageUnitId.Value : object1.WageType == (int)WageType.LegacyWeekly ? WageUnit.Weekly : WageUnit.NotApplicable;

            return string.Equals(object1.AddressLine1, object2.Address.AddressLine1)
                && string.Equals(object1.AddressLine2, object2.Address.AddressLine2)
                && string.Equals(object1.AddressLine3, object2.Address.AddressLine3)
                && string.Equals(object1.AddressLine4, object2.Address.AddressLine4)
                && string.Equals(object1.AddressLine5, object2.Address.AddressLine5)
                && string.Equals(object1.Town, object2.Address.Town)
                && string.Equals(object1.PostCode, object2.Address.Postcode)
                //No direct comparison here
                //&& string.Equals(object1.CountyId, object2.Address.County)
                && ((double?)object1.Longitude).Equals(object2.Address.GeoPoint.Longitude)
                && ((double?)object1.Latitude).Equals(object2.Address.GeoPoint.Latitude)
                && object1.GeocodeEasting == object2.Address.GeoPoint.Easting
                && object1.GeocodeNorthing == object2.Address.GeoPoint.Northing
                && string.Equals(object1.AnonymousAboutTheEmployer, object2.AnonymousAboutTheEmployer)
                && object2.ApplicantCount == 0
                && object1.ApprenticeshipLevel == object2.ApprenticeshipLevel
                && object1.ApplicationClosingDate.Equals(object2.ClosingDate)
                && object2.ContractOwnerId == 0
                && object2.CreatedDate == DateTime.MinValue
                && object2.DateFirstSubmitted == null
                && object2.DateQAApproved == null
                && object2.DateStartedToQA == null
                && object2.DateSubmitted == null
                && object2.DeliveryOrganisationId == null
                && object1.DurationValue == object2.Duration
                && object1.DurationTypeId == (int)object2.DurationType
                && string.Equals(object1.EmployerAnonymousName, object2.EmployerAnonymousName)
                && object2.EmployerAnonymousReason == null
                && object1.EmployerId == object2.EmployerId
                && string.Equals(object1.EmployerLocation, object2.EmployerLocation)
                && string.Equals(object1.EmployerName, object2.EmployerName)
                && string.Equals(object1.ExpectedDuration, object2.ExpectedDuration)
                && string.Equals(object1.FrameworkCodeName, object2.FrameworkCodeName)
                //Ignored in mapper
                //&& string.IsNullOrEmpty(object1.EmployerAnonymousName) == object2.IsAnonymousEmployer
                && object2.NewApplicationCount == 0
                && object2.NoOfOfflineApplicants == 0
                && object1.NumberOfPositions == object2.NumberOfPositions
                && object1.ApplyOutsideNAVMS == object2.OfflineVacancy
                && object2.OriginalContractOwnerId == 0
                && object2.ParentVacancyId == null
                && object1.ExpectedStartDate.Equals(object2.PossibleStartDate)
                //Not set in full vacancy
                //&& string.Equals(object1.ProviderTradingName, object2.ProviderTradingName) 
                && object2.QAUserName == null
                && object2.RegionalTeam == RegionalTeam.Other
                && string.Equals(object1.SectorCodeName, object2.SectorCodeName)
                && string.Equals(object1.ShortDescription, object2.ShortDescription)
                && object1.StandardId == object2.StandardId
                && object1.VacancyStatusId == (int)object2.Status
                && object2.SubmissionCount == 0
                && string.Equals(object1.Title, object2.Title)
                && object1.TrainingTypeId == (int)object2.TrainingType
                && object2.UpdatedDateTime == null
                && object1.VacancyGuid.Equals(object2.VacancyGuid)
                && object1.VacancyId == object2.VacancyId
                && object1.VacancyLocationTypeId == (int)object2.VacancyLocationType
                && object2.VacancyManagerId == null
                && object2.VacancyOwnerRelationshipId == 0
                && object1.VacancyReferenceNumber == object2.VacancyReferenceNumber
                && object1.VacancyTypeId == (int)object2.VacancyType
                && object1.WeeklyWage == object2.Wage.Amount
                && object1.WageLowerBound == object2.Wage.AmountLowerBound
                && object1.WageUpperBound == object2.Wage.AmountUpperBound
                && object1.HoursPerWeek == object2.Wage.HoursPerWeek
                && string.Equals(object1.WageTypeReason, object2.Wage.ReasonForType)
                && string.Equals(object1.WageText, object2.Wage.Text)
                && wageType == object2.Wage.Type
                && CorrectWageUnit(wageType, wageUnit) == object2.Wage.Unit
                && string.Equals(object1.WorkingWeek, object2.WorkingWeek)
                && string.Equals(object1.AdditionalLocationInformation, object2.AdditionalLocationInformation)
                && object2.AdditionalLocationInformationComment == null
                && object2.ApprenticeshipLevelComment == null
                && object2.ClosingDateComment == null
                && object2.ContactDetailsComment == null
                && string.Equals(object1.ContactEmail, object2.ContactEmail)
                && string.Equals(object1.ContactName, object2.ContactName)
                && string.Equals(object1.ContactNumber, object2.ContactNumber)
                && object2.CreatedByProviderUsername == null
                && string.Equals(object1.DesiredQualifications, object2.DesiredQualifications)
                && object2.DesiredQualificationsComment == null
                && string.Equals(object1.DesiredSkills, object2.DesiredSkills)
                && object2.DesiredSkillsComment == null
                && object2.DurationComment == null
                && object2.EditedInRaa == false
                && string.Equals(object1.EmployerDescription, object2.EmployerDescription)
                && object2.EmployerDescriptionComment == null
                && string.Equals(object1.EmployersWebsite, object2.EmployerWebsiteUrl)
                && object2.EmployerWebsiteUrlComment == null
                && string.Equals(object1.FirstQuestion, object2.FirstQuestion)
                && object2.FirstQuestionComment == null
                && object2.FrameworkCodeNameComment == null
                && string.Equals(object1.FutureProspects, object2.FutureProspects)
                && object2.FutureProspectsComment == null
                //Ignored in mapper
                //&& object1.LastEditedById == object2.LastEditedById 
                && string.Equals(object1.LocalAuthorityCode, object2.LocalAuthorityCode)
                && object2.LocationAddressesComment == null
                && string.Equals(object1.Description, object2.LongDescription)
                && object2.LongDescriptionComment == null
                && object2.NumberOfPositionsComment == null
                && string.Equals(object1.EmployersApplicationInstructions, object2.OfflineApplicationInstructions)
                && object2.OfflineApplicationInstructionsComment == null
                && string.Equals(object1.EmployersRecruitmentWebsite, object2.OfflineApplicationUrl)
                && object2.OfflineApplicationUrlComment == null
                && object2.OfflineVacancyType == null
                && string.Equals(object1.OtherInformation, object2.OtherInformation)
                && string.Equals(object1.PersonalQualities, object2.PersonalQualities)
                && object2.PersonalQualitiesComment == null
                && object2.PossibleStartDateComment == null
                && string.Equals(object1.SecondQuestion, object2.SecondQuestion)
                && object2.SecondQuestionComment == null
                && object2.SectorCodeNameComment == null
                && object2.ShortDescriptionComment == null
                && object2.StandardIdComment == null
                && string.Equals(object1.ThingsToConsider, object2.ThingsToConsider)
                && object2.ThingsToConsiderComment == null
                && object2.TitleComment == null
                && string.Equals(object1.TrainingProvided, object2.TrainingProvided)
                && object2.TrainingProvidedComment == null
                && object2.VacancySource == VacancySource.Unknown
                && object2.WageComment == null
                && object2.WorkingWeekComment == null
                && object2.AnonymousEmployerDescriptionComment == null
                && object2.AnonymousEmployerReasonComment == null
                && object2.AnonymousAboutTheEmployerComment == null
                && object2.CreatedDateTime == DateTime.MinValue
                && object2.FrameworkStatus == 0
                && object2.StandardStatus == 0;
        }

        public static WageUnit CorrectWageUnit(WageType type, WageUnit unit)
        {
            switch (type)
            {
                case WageType.CustomRange:
                    if (unit == WageUnit.NotApplicable)
                        return WageUnit.Weekly;
                    return unit;

                case WageType.LegacyText:
                case WageType.CompetitiveSalary:
                case WageType.ToBeAgreedUponAppointment:
                case WageType.Unwaged:
                    return WageUnit.NotApplicable;

                case WageType.Custom:
                    switch (unit)
                    {
                        case WageUnit.Weekly:
                        case WageUnit.Monthly:
                        case WageUnit.Annually:
                        case WageUnit.NotApplicable:
                            return unit;

                        default:
                            throw new ArgumentOutOfRangeException(nameof(WageUnit), $"Invalid Wage Unit: {unit}");
                    }

                case WageType.LegacyWeekly:
                default:
                    return WageUnit.Weekly;
            }
        }

        public int GetHashCode(DbVacancy object1)
        {
            var hashCode = (object1.AdditionalLocationInformation != null ? object1.AdditionalLocationInformation.GetHashCode() : 0);
            hashCode = (hashCode * 397) ^ (object1.AdditionalLocationInformationComment != null ? object1.AdditionalLocationInformationComment.GetHashCode() : 0);
            hashCode = (hashCode * 397) ^ (object1.AddressLine1 != null ? object1.AddressLine1.GetHashCode() : 0);
            hashCode = (hashCode * 397) ^ (object1.AddressLine2 != null ? object1.AddressLine2.GetHashCode() : 0);
            hashCode = (hashCode * 397) ^ (object1.AddressLine3 != null ? object1.AddressLine3.GetHashCode() : 0);
            hashCode = (hashCode * 397) ^ (object1.AddressLine4 != null ? object1.AddressLine4.GetHashCode() : 0);
            hashCode = (hashCode * 397) ^ (object1.AddressLine5 != null ? object1.AddressLine5.GetHashCode() : 0);
            hashCode = (hashCode * 397) ^ (object1.AnonymousAboutTheEmployer != null ? object1.AnonymousAboutTheEmployer.GetHashCode() : 0);
            hashCode = (hashCode * 397) ^ (object1.AnonymousAboutTheEmployerComment != null ? object1.AnonymousAboutTheEmployerComment.GetHashCode() : 0);
            hashCode = (hashCode * 397) ^ (object1.AnonymousEmployerDescriptionComment != null ? object1.AnonymousEmployerDescriptionComment.GetHashCode() : 0);
            hashCode = (hashCode * 397) ^ (object1.AnonymousEmployerReasonComment != null ? object1.AnonymousEmployerReasonComment.GetHashCode() : 0);
            hashCode = (hashCode * 397) ^ object1.ApplicantCount.GetHashCode();
            hashCode = (hashCode * 397) ^ object1.ApplicationClosingDate.GetHashCode();
            hashCode = (hashCode * 397) ^ object1.ApplyOutsideNAVMS.GetHashCode();
            hashCode = (hashCode * 397) ^ object1.ApprenticeshipFrameworkId.GetHashCode();
            hashCode = (hashCode * 397) ^ (int)object1.ApprenticeshipLevel;
            hashCode = (hashCode * 397) ^ (object1.ApprenticeshipLevelComment != null ? object1.ApprenticeshipLevelComment.GetHashCode() : 0);
            hashCode = (hashCode * 397) ^ object1.ApprenticeshipType.GetHashCode();
            hashCode = (hashCode * 397) ^ (object1.BeingSupportedBy != null ? object1.BeingSupportedBy.GetHashCode() : 0);
            hashCode = (hashCode * 397) ^ (object1.ClosingDateComment != null ? object1.ClosingDateComment.GetHashCode() : 0);
            hashCode = (hashCode * 397) ^ (object1.ContactDetailsComment != null ? object1.ContactDetailsComment.GetHashCode() : 0);
            hashCode = (hashCode * 397) ^ (object1.ContactEmail != null ? object1.ContactEmail.GetHashCode() : 0);
            hashCode = (hashCode * 397) ^ (object1.ContactName != null ? object1.ContactName.GetHashCode() : 0);
            hashCode = (hashCode * 397) ^ (object1.ContactNumber != null ? object1.ContactNumber.GetHashCode() : 0);
            hashCode = (hashCode * 397) ^ object1.ContractOwnerID.GetHashCode();
            hashCode = (hashCode * 397) ^ object1.CountyId;
            hashCode = (hashCode * 397) ^ (object1.CreatedByProviderUsername != null ? object1.CreatedByProviderUsername.GetHashCode() : 0);
            hashCode = (hashCode * 397) ^ object1.CreatedDate.GetHashCode();
            hashCode = (hashCode * 397) ^ object1.DateFirstSubmitted.GetHashCode();
            hashCode = (hashCode * 397) ^ object1.DateQAApproved.GetHashCode();
            hashCode = (hashCode * 397) ^ object1.DateSubmitted.GetHashCode();
            hashCode = (hashCode * 397) ^ object1.DeliveryOrganisationID.GetHashCode();
            hashCode = (hashCode * 397) ^ (object1.Description != null ? object1.Description.GetHashCode() : 0);
            hashCode = (hashCode * 397) ^ (object1.DesiredQualifications != null ? object1.DesiredQualifications.GetHashCode() : 0);
            hashCode = (hashCode * 397) ^ (object1.DesiredQualificationsComment != null ? object1.DesiredQualificationsComment.GetHashCode() : 0);
            hashCode = (hashCode * 397) ^ (object1.DesiredSkills != null ? object1.DesiredSkills.GetHashCode() : 0);
            hashCode = (hashCode * 397) ^ (object1.DesiredSkillsComment != null ? object1.DesiredSkillsComment.GetHashCode() : 0);
            hashCode = (hashCode * 397) ^ (object1.DurationComment != null ? object1.DurationComment.GetHashCode() : 0);
            hashCode = (hashCode * 397) ^ object1.DurationTypeId;
            hashCode = (hashCode * 397) ^ object1.DurationValue.GetHashCode();
            hashCode = (hashCode * 397) ^ object1.EditedInRaa.GetHashCode();
            hashCode = (hashCode * 397) ^ (object1.EmployerAnonymousName != null ? object1.EmployerAnonymousName.GetHashCode() : 0);
            hashCode = (hashCode * 397) ^ (object1.EmployerAnonymousReason != null ? object1.EmployerAnonymousReason.GetHashCode() : 0);
            hashCode = (hashCode * 397) ^ (object1.EmployerDescription != null ? object1.EmployerDescription.GetHashCode() : 0);
            hashCode = (hashCode * 397) ^ (object1.EmployerDescriptionComment != null ? object1.EmployerDescriptionComment.GetHashCode() : 0);
            hashCode = (hashCode * 397) ^ object1.EmployerId;
            hashCode = (hashCode * 397) ^ (object1.EmployerLocation != null ? object1.EmployerLocation.GetHashCode() : 0);
            hashCode = (hashCode * 397) ^ (object1.EmployerName != null ? object1.EmployerName.GetHashCode() : 0);
            hashCode = (hashCode * 397) ^ (object1.EmployersApplicationInstructions != null ? object1.EmployersApplicationInstructions.GetHashCode() : 0);
            hashCode = (hashCode * 397) ^ (object1.EmployersRecruitmentWebsite != null ? object1.EmployersRecruitmentWebsite.GetHashCode() : 0);
            hashCode = (hashCode * 397) ^ (object1.EmployersWebsite != null ? object1.EmployersWebsite.GetHashCode() : 0);
            hashCode = (hashCode * 397) ^ (object1.EmployerWebsiteUrlComment != null ? object1.EmployerWebsiteUrlComment.GetHashCode() : 0);
            hashCode = (hashCode * 397) ^ (object1.ExpectedDuration != null ? object1.ExpectedDuration.GetHashCode() : 0);
            hashCode = (hashCode * 397) ^ object1.ExpectedStartDate.GetHashCode();
            hashCode = (hashCode * 397) ^ (object1.FirstQuestion != null ? object1.FirstQuestion.GetHashCode() : 0);
            hashCode = (hashCode * 397) ^ (object1.FirstQuestionComment != null ? object1.FirstQuestionComment.GetHashCode() : 0);
            hashCode = (hashCode * 397) ^ (object1.FrameworkCodeName != null ? object1.FrameworkCodeName.GetHashCode() : 0);
            hashCode = (hashCode * 397) ^ (object1.FrameworkCodeNameComment != null ? object1.FrameworkCodeNameComment.GetHashCode() : 0);
            hashCode = (hashCode * 397) ^ (object1.FutureProspects != null ? object1.FutureProspects.GetHashCode() : 0);
            hashCode = (hashCode * 397) ^ (object1.FutureProspectsComment != null ? object1.FutureProspectsComment.GetHashCode() : 0);
            hashCode = (hashCode * 397) ^ object1.GeocodeEasting.GetHashCode();
            hashCode = (hashCode * 397) ^ object1.GeocodeNorthing.GetHashCode();
            hashCode = (hashCode * 397) ^ object1.HoursPerWeek.GetHashCode();
            hashCode = (hashCode * 397) ^ object1.InterviewsFromDate.GetHashCode();
            hashCode = (hashCode * 397) ^ object1.Latitude.GetHashCode();
            hashCode = (hashCode * 397) ^ (object1.LocalAuthorityCode != null ? object1.LocalAuthorityCode.GetHashCode() : 0);
            hashCode = (hashCode * 397) ^ object1.LocalAuthorityId.GetHashCode();
            hashCode = (hashCode * 397) ^ (object1.LocationAddressesComment != null ? object1.LocationAddressesComment.GetHashCode() : 0);
            hashCode = (hashCode * 397) ^ object1.LockedForSupportUntil.GetHashCode();
            hashCode = (hashCode * 397) ^ (object1.LongDescriptionComment != null ? object1.LongDescriptionComment.GetHashCode() : 0);
            hashCode = (hashCode * 397) ^ object1.Longitude.GetHashCode();
            hashCode = (hashCode * 397) ^ object1.MasterVacancyId.GetHashCode();
            hashCode = (hashCode * 397) ^ object1.MaxNumberofApplications.GetHashCode();
            hashCode = (hashCode * 397) ^ object1.NewApplicantCount.GetHashCode();
            hashCode = (hashCode * 397) ^ object1.NoOfOfflineApplicants.GetHashCode();
            hashCode = (hashCode * 397) ^ object1.NoOfOfflineSystemApplicants.GetHashCode();
            hashCode = (hashCode * 397) ^ object1.NumberOfPositions.GetHashCode();
            hashCode = (hashCode * 397) ^ (object1.NumberOfPositionsComment != null ? object1.NumberOfPositionsComment.GetHashCode() : 0);
            hashCode = (hashCode * 397) ^ object1.NumberOfViews.GetHashCode();
            hashCode = (hashCode * 397) ^ (object1.OfflineApplicationInstructionsComment != null ? object1.OfflineApplicationInstructionsComment.GetHashCode() : 0);
            hashCode = (hashCode * 397) ^ (object1.OfflineApplicationUrlComment != null ? object1.OfflineApplicationUrlComment.GetHashCode() : 0);
            hashCode = (hashCode * 397) ^ object1.OfflineVacancyTypeId.GetHashCode();
            hashCode = (hashCode * 397) ^ object1.OriginalContractOwnerId.GetHashCode();
            hashCode = (hashCode * 397) ^ (object1.OtherInformation != null ? object1.OtherInformation.GetHashCode() : 0);
            hashCode = (hashCode * 397) ^ (object1.PersonalQualities != null ? object1.PersonalQualities.GetHashCode() : 0);
            hashCode = (hashCode * 397) ^ (object1.PersonalQualitiesComment != null ? object1.PersonalQualitiesComment.GetHashCode() : 0);
            hashCode = (hashCode * 397) ^ (object1.PossibleStartDateComment != null ? object1.PossibleStartDateComment.GetHashCode() : 0);
            hashCode = (hashCode * 397) ^ (object1.PostCode != null ? object1.PostCode.GetHashCode() : 0);
            hashCode = (hashCode * 397) ^ (object1.QAUserName != null ? object1.QAUserName.GetHashCode() : 0);
            hashCode = (hashCode * 397) ^ (int)object1.RegionalTeam;
            hashCode = (hashCode * 397) ^ (object1.SecondQuestion != null ? object1.SecondQuestion.GetHashCode() : 0);
            hashCode = (hashCode * 397) ^ (object1.SecondQuestionComment != null ? object1.SecondQuestionComment.GetHashCode() : 0);
            hashCode = (hashCode * 397) ^ (object1.SectorCodeName != null ? object1.SectorCodeName.GetHashCode() : 0);
            hashCode = (hashCode * 397) ^ (object1.SectorCodeNameComment != null ? object1.SectorCodeNameComment.GetHashCode() : 0);
            hashCode = (hashCode * 397) ^ object1.SectorId.GetHashCode();
            hashCode = (hashCode * 397) ^ (object1.ShortDescription != null ? object1.ShortDescription.GetHashCode() : 0);
            hashCode = (hashCode * 397) ^ (object1.ShortDescriptionComment != null ? object1.ShortDescriptionComment.GetHashCode() : 0);
            hashCode = (hashCode * 397) ^ object1.SmallEmployerWageIncentive.GetHashCode();
            hashCode = (hashCode * 397) ^ object1.StandardId.GetHashCode();
            hashCode = (hashCode * 397) ^ (object1.StandardIdComment != null ? object1.StandardIdComment.GetHashCode() : 0);
            hashCode = (hashCode * 397) ^ object1.StartedToQADateTime.GetHashCode();
            hashCode = (hashCode * 397) ^ object1.SubmissionCount;
            hashCode = (hashCode * 397) ^ (object1.ThingsToConsider != null ? object1.ThingsToConsider.GetHashCode() : 0);
            hashCode = (hashCode * 397) ^ (object1.ThingsToConsiderComment != null ? object1.ThingsToConsiderComment.GetHashCode() : 0);
            hashCode = (hashCode * 397) ^ (object1.Title != null ? object1.Title.GetHashCode() : 0);
            hashCode = (hashCode * 397) ^ (object1.TitleComment != null ? object1.TitleComment.GetHashCode() : 0);
            hashCode = (hashCode * 397) ^ (object1.Town != null ? object1.Town.GetHashCode() : 0);
            hashCode = (hashCode * 397) ^ (object1.TrainingProvided != null ? object1.TrainingProvided.GetHashCode() : 0);
            hashCode = (hashCode * 397) ^ (object1.TrainingProvidedComment != null ? object1.TrainingProvidedComment.GetHashCode() : 0);
            hashCode = (hashCode * 397) ^ object1.TrainingTypeId;
            hashCode = (hashCode * 397) ^ object1.UpdatedDateTime.GetHashCode();
            hashCode = (hashCode * 397) ^ object1.VacancyGuid.GetHashCode();
            hashCode = (hashCode * 397) ^ object1.VacancyId;
            hashCode = (hashCode * 397) ^ object1.VacancyLocationTypeId.GetHashCode();
            hashCode = (hashCode * 397) ^ object1.VacancyManagerAnonymous.GetHashCode();
            hashCode = (hashCode * 397) ^ object1.VacancyManagerID.GetHashCode();
            hashCode = (hashCode * 397) ^ object1.VacancyOwnerRelationshipId;
            hashCode = (hashCode * 397) ^ object1.VacancyReferenceNumber;
            hashCode = (hashCode * 397) ^ object1.VacancySourceId;
            hashCode = (hashCode * 397) ^ object1.VacancyStatusId;
            hashCode = (hashCode * 397) ^ object1.VacancyTypeId;
            hashCode = (hashCode * 397) ^ (object1.WageComment != null ? object1.WageComment.GetHashCode() : 0);
            hashCode = (hashCode * 397) ^ object1.WageLowerBound.GetHashCode();
            hashCode = (hashCode * 397) ^ (object1.WageText != null ? object1.WageText.GetHashCode() : 0);
            hashCode = (hashCode * 397) ^ object1.WageType;
            hashCode = (hashCode * 397) ^ (object1.WageTypeReason != null ? object1.WageTypeReason.GetHashCode() : 0);
            hashCode = (hashCode * 397) ^ object1.WageUnitId.GetHashCode();
            hashCode = (hashCode * 397) ^ object1.WageUpperBound.GetHashCode();
            hashCode = (hashCode * 397) ^ object1.WeeklyWage.GetHashCode();
            hashCode = (hashCode * 397) ^ (object1.WorkingWeek != null ? object1.WorkingWeek.GetHashCode() : 0);
            hashCode = (hashCode * 397) ^ (object1.WorkingWeekComment != null ? object1.WorkingWeekComment.GetHashCode() : 0);
            hashCode = (hashCode * 397) ^ (int)object1.FrameworkStatus;
            hashCode = (hashCode * 397) ^ (int)object1.StandardStatus;
            return hashCode;
        }

        public int GetHashCode(Vacancy object2)
        {
            //VacancySummary
            var hashCode = (object2.Address != null ? object2.Address.GetHashCode() : 0);
            hashCode = (hashCode * 397) ^ (object2.AnonymousAboutTheEmployer != null ? object2.AnonymousAboutTheEmployer.GetHashCode() : 0);
            hashCode = (hashCode * 397) ^ (int)object2.ApprenticeshipLevel;
            hashCode = (hashCode * 397) ^ object2.ClosingDate.GetHashCode();
            hashCode = (hashCode * 397) ^ object2.Duration.GetHashCode();
            hashCode = (hashCode * 397) ^ (int)object2.DurationType;
            hashCode = (hashCode * 397) ^ (object2.EmployerAnonymousName != null ? object2.EmployerAnonymousName.GetHashCode() : 0);
            hashCode = (hashCode * 397) ^ object2.EmployerId;
            hashCode = (hashCode * 397) ^ (object2.EmployerLocation != null ? object2.EmployerLocation.GetHashCode() : 0);
            hashCode = (hashCode * 397) ^ (object2.EmployerName != null ? object2.EmployerName.GetHashCode() : 0);
            hashCode = (hashCode * 397) ^ (object2.ExpectedDuration != null ? object2.ExpectedDuration.GetHashCode() : 0);
            hashCode = (hashCode * 397) ^ (object2.FrameworkCodeName != null ? object2.FrameworkCodeName.GetHashCode() : 0);
            hashCode = (hashCode * 397) ^ object2.IsAnonymousEmployer.GetHashCode();
            hashCode = (hashCode * 397) ^ object2.NumberOfPositions.GetHashCode();
            hashCode = (hashCode * 397) ^ object2.OfflineVacancy.GetHashCode();
            hashCode = (hashCode * 397) ^ object2.PossibleStartDate.GetHashCode();
            hashCode = (hashCode * 397) ^ (object2.ProviderTradingName != null ? object2.ProviderTradingName.GetHashCode() : 0);
            hashCode = (hashCode * 397) ^ (object2.SectorCodeName != null ? object2.SectorCodeName.GetHashCode() : 0);
            hashCode = (hashCode * 397) ^ (object2.ShortDescription != null ? object2.ShortDescription.GetHashCode() : 0);
            hashCode = (hashCode * 397) ^ object2.StandardId.GetHashCode();
            hashCode = (hashCode * 397) ^ (int)object2.Status;
            hashCode = (hashCode * 397) ^ (object2.Title != null ? object2.Title.GetHashCode() : 0);
            hashCode = (hashCode * 397) ^ (int)object2.TrainingType;
            hashCode = (hashCode * 397) ^ object2.VacancyGuid.GetHashCode();
            hashCode = (hashCode * 397) ^ object2.VacancyId;
            hashCode = (hashCode * 397) ^ (int)object2.VacancyLocationType;
            hashCode = (hashCode * 397) ^ object2.VacancyReferenceNumber;
            hashCode = (hashCode * 397) ^ (int)object2.VacancyType;
            hashCode = (hashCode * 397) ^ (object2.Wage != null ? object2.Wage.GetHashCode() : 0);
            hashCode = (hashCode * 397) ^ (object2.WorkingWeek != null ? object2.WorkingWeek.GetHashCode() : 0);

            //Vacancy
            hashCode = (hashCode * 397) ^ (object2.AdditionalLocationInformation != null ? object2.AdditionalLocationInformation.GetHashCode() : 0);
            hashCode = (hashCode * 397) ^ (object2.ContactEmail != null ? object2.ContactEmail.GetHashCode() : 0);
            hashCode = (hashCode * 397) ^ (object2.ContactName != null ? object2.ContactName.GetHashCode() : 0);
            hashCode = (hashCode * 397) ^ (object2.ContactNumber != null ? object2.ContactNumber.GetHashCode() : 0);
            hashCode = (hashCode * 397) ^ (object2.DesiredQualifications != null ? object2.DesiredQualifications.GetHashCode() : 0);
            hashCode = (hashCode * 397) ^ (object2.DesiredSkills != null ? object2.DesiredSkills.GetHashCode() : 0);
            hashCode = (hashCode * 397) ^ (object2.EmployerDescription != null ? object2.EmployerDescription.GetHashCode() : 0);
            hashCode = (hashCode * 397) ^ (object2.EmployerWebsiteUrl != null ? object2.EmployerWebsiteUrl.GetHashCode() : 0);
            hashCode = (hashCode * 397) ^ (object2.FirstQuestion != null ? object2.FirstQuestion.GetHashCode() : 0);
            hashCode = (hashCode * 397) ^ (object2.FutureProspects != null ? object2.FutureProspects.GetHashCode() : 0);
            hashCode = (hashCode * 397) ^ (object2.LocalAuthorityCode != null ? object2.LocalAuthorityCode.GetHashCode() : 0);
            hashCode = (hashCode * 397) ^ (object2.LongDescription != null ? object2.LongDescription.GetHashCode() : 0);
            hashCode = (hashCode * 397) ^ (object2.OfflineApplicationInstructions != null ? object2.OfflineApplicationInstructions.GetHashCode() : 0);
            hashCode = (hashCode * 397) ^ (object2.OfflineApplicationUrl != null ? object2.OfflineApplicationUrl.GetHashCode() : 0);
            hashCode = (hashCode * 397) ^ (object2.OtherInformation != null ? object2.OtherInformation.GetHashCode() : 0);
            hashCode = (hashCode * 397) ^ (object2.PersonalQualities != null ? object2.PersonalQualities.GetHashCode() : 0);
            hashCode = (hashCode * 397) ^ (object2.SecondQuestion != null ? object2.SecondQuestion.GetHashCode() : 0);
            hashCode = (hashCode * 397) ^ (object2.ThingsToConsider != null ? object2.ThingsToConsider.GetHashCode() : 0);
            hashCode = (hashCode * 397) ^ (object2.TrainingProvided != null ? object2.TrainingProvided.GetHashCode() : 0);

            return hashCode;
        }
    }
}