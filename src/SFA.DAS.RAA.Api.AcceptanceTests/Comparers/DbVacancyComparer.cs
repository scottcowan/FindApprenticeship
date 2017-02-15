namespace SFA.DAS.RAA.Api.AcceptanceTests.Comparers
{
    using System;
    using Apprenticeships.Domain.Entities.Raa.Vacancies;
    using Apprenticeships.Domain.Entities.Vacancies;
    using DbVacancy = Apprenticeships.Infrastructure.Repositories.Sql.Schemas.Vacancy.Entities.Vacancy;

    public class DbVacancyComparer : IMultiEqualityComparer<DbVacancy, Vacancy>
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
                && ((double?) object1.Longitude).Equals(object2.Address.GeoPoint.Longitude)
                && ((double?) object1.Latitude).Equals(object2.Address.GeoPoint.Latitude)
                && object1.GeocodeEasting == object2.Address.GeoPoint.Easting
                && object1.GeocodeNorthing == object2.Address.GeoPoint.Northing
                && string.Equals(object1.AnonymousAboutTheEmployer, object2.AnonymousAboutTheEmployer)
                && object1.ApplicantCount == object2.ApplicantCount
                && object1.ApprenticeshipLevel == object2.ApprenticeshipLevel
                && object1.ApplicationClosingDate.Equals(object2.ClosingDate)
                && object1.ContractOwnerID == object2.ContractOwnerId
                && object1.CreatedDate.Equals(object2.CreatedDate)
                && object1.DateFirstSubmitted.Equals(object2.DateFirstSubmitted)
                && object1.DateQAApproved.Equals(object2.DateQAApproved)
                && object1.StartedToQADateTime.Equals(object2.DateStartedToQA)
                && object1.DateSubmitted.Equals(object2.DateSubmitted)
                && object1.DeliveryOrganisationID == object2.DeliveryOrganisationId
                && object1.DurationValue == object2.Duration
                && object1.DurationTypeId == (int) object2.DurationType
                && string.Equals(object1.EmployerAnonymousName, object2.EmployerAnonymousName)
                && string.Equals(object1.EmployerAnonymousReason, object2.EmployerAnonymousReason)
                && object1.EmployerId == object2.EmployerId
                && string.Equals(object1.EmployerLocation, object2.EmployerLocation)
                && string.Equals(object1.EmployerName, object2.EmployerName)
                && string.Equals(object1.ExpectedDuration, object2.ExpectedDuration)
                && string.Equals(object1.FrameworkCodeName, object2.FrameworkCodeName)
                //Ignored in mapper
                //&& string.IsNullOrEmpty(object1.EmployerAnonymousName) == object2.IsAnonymousEmployer
                && object1.NewApplicantCount == object2.NewApplicationCount
                && object1.NoOfOfflineApplicants == object2.NoOfOfflineApplicants
                && object1.NumberOfPositions == object2.NumberOfPositions
                && object1.ApplyOutsideNAVMS == object2.OfflineVacancy
                && object1.OriginalContractOwnerId == object2.OriginalContractOwnerId
                && object1.MasterVacancyId == object2.ParentVacancyId
                && object1.ExpectedStartDate.Equals(object2.PossibleStartDate)
                //Not set in full vacancy
                //&& string.Equals(object1.ProviderTradingName, object2.ProviderTradingName) 
                && string.Equals(object1.QAUserName, object2.QAUserName) 
                && object1.RegionalTeam == object2.RegionalTeam 
                && string.Equals(object1.SectorCodeName, object2.SectorCodeName) 
                && string.Equals(object1.ShortDescription, object2.ShortDescription) 
                && object1.StandardId == object2.StandardId 
                && object1.VacancyStatusId == (int)object2.Status 
                && object1.SubmissionCount == object2.SubmissionCount 
                && string.Equals(object1.Title, object2.Title) 
                && object1.TrainingTypeId == (int)object2.TrainingType 
                && object1.UpdatedDateTime.Equals(object2.UpdatedDateTime) 
                && object1.VacancyGuid.Equals(object2.VacancyGuid) 
                && object1.VacancyId == object2.VacancyId 
                && object1.VacancyLocationTypeId == (int)object2.VacancyLocationType 
                && object1.VacancyManagerID == object2.VacancyManagerId 
                && object1.VacancyOwnerRelationshipId == object2.VacancyOwnerRelationshipId 
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
                && string.Equals(object1.AdditionalLocationInformationComment, object2.AdditionalLocationInformationComment) 
                && string.Equals(object1.ApprenticeshipLevelComment, object2.ApprenticeshipLevelComment) 
                && string.Equals(object1.ClosingDateComment, object2.ClosingDateComment) 
                && string.Equals(object1.ContactDetailsComment, object2.ContactDetailsComment) 
                && string.Equals(object1.ContactEmail, object2.ContactEmail) 
                && string.Equals(object1.ContactName, object2.ContactName) 
                && string.Equals(object1.ContactNumber, object2.ContactNumber) 
                && string.Equals(object1.CreatedByProviderUsername, object2.CreatedByProviderUsername) 
                && string.Equals(object1.DesiredQualifications, object2.DesiredQualifications) 
                && string.Equals(object1.DesiredQualificationsComment, object2.DesiredQualificationsComment) 
                && string.Equals(object1.DesiredSkills, object2.DesiredSkills) 
                && string.Equals(object1.DesiredSkillsComment, object2.DesiredSkillsComment) 
                && string.Equals(object1.DurationComment, object2.DurationComment) 
                && object1.EditedInRaa == object2.EditedInRaa 
                && string.Equals(object1.EmployerDescription, object2.EmployerDescription) 
                && string.Equals(object1.EmployerDescriptionComment, object2.EmployerDescriptionComment) 
                && string.Equals(object1.EmployersWebsite, object2.EmployerWebsiteUrl) 
                && string.Equals(object1.EmployerWebsiteUrlComment, object2.EmployerWebsiteUrlComment) 
                && string.Equals(object1.FirstQuestion, object2.FirstQuestion) 
                && string.Equals(object1.FirstQuestionComment, object2.FirstQuestionComment) 
                && string.Equals(object1.FrameworkCodeNameComment, object2.FrameworkCodeNameComment) 
                && string.Equals(object1.FutureProspects, object2.FutureProspects) 
                && string.Equals(object1.FutureProspectsComment, object2.FutureProspectsComment) 
                //Ignored in mapper
                //&& object1.LastEditedById == object2.LastEditedById 
                && string.Equals(object1.LocationAddressesComment, object2.LocationAddressesComment) 
                && string.Equals(object1.Description, object2.LongDescription) 
                && string.Equals(object1.LongDescriptionComment, object2.LongDescriptionComment) 
                && string.Equals(object1.NumberOfPositionsComment, object2.NumberOfPositionsComment) 
                && string.Equals(object1.EmployersApplicationInstructions, object2.OfflineApplicationInstructions) 
                && string.Equals(object1.OfflineApplicationInstructionsComment, object2.OfflineApplicationInstructionsComment) 
                && string.Equals(object1.EmployersRecruitmentWebsite, object2.OfflineApplicationUrl) 
                && string.Equals(object1.OfflineApplicationUrlComment, object2.OfflineApplicationUrlComment) 
                && object1.OfflineVacancyTypeId == (int?)object2.OfflineVacancyType 
                && string.Equals(object1.OtherInformation, object2.OtherInformation) 
                && string.Equals(object1.PersonalQualities, object2.PersonalQualities) 
                && string.Equals(object1.PersonalQualitiesComment, object2.PersonalQualitiesComment) 
                && string.Equals(object1.PossibleStartDateComment, object2.PossibleStartDateComment) 
                && string.Equals(object1.SecondQuestion, object2.SecondQuestion) 
                && string.Equals(object1.SecondQuestionComment, object2.SecondQuestionComment) 
                && string.Equals(object1.SectorCodeNameComment, object2.SectorCodeNameComment) 
                && string.Equals(object1.ShortDescriptionComment, object2.ShortDescriptionComment) 
                && string.Equals(object1.StandardIdComment, object2.StandardIdComment) 
                && string.Equals(object1.ThingsToConsider, object2.ThingsToConsider) 
                && string.Equals(object1.ThingsToConsiderComment, object2.ThingsToConsiderComment) 
                && string.Equals(object1.TitleComment, object2.TitleComment) 
                && string.Equals(object1.TrainingProvided, object2.TrainingProvided) 
                && string.Equals(object1.TrainingProvidedComment, object2.TrainingProvidedComment) 
                && object1.VacancySourceId == (int)object2.VacancySource 
                && string.Equals(object1.WageComment, object2.WageComment) 
                && string.Equals(object1.WorkingWeekComment, object2.WorkingWeekComment) 
                && string.Equals(object1.AnonymousEmployerDescriptionComment, object2.AnonymousEmployerDescriptionComment) 
                && string.Equals(object1.AnonymousEmployerReasonComment, object2.AnonymousEmployerReasonComment) 
                && string.Equals(object1.AnonymousAboutTheEmployerComment, object2.AnonymousAboutTheEmployerComment) 
                && object1.CreatedDate.Equals(object2.CreatedDateTime) 
                && object1.FrameworkStatus == object2.FrameworkStatus
                && object1.StandardStatus == object2.StandardStatus;
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
            return 0;
        }

        public int GetHashCode(Vacancy object2)
        {
            return 0;
        }
    }
}