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
                && object1.ContractOwnerID == object2.ContractOwnerId
                && object2.CreatedDate == DateTime.MinValue
                && object2.DateFirstSubmitted == null
                && object1.DateQAApproved == object2.DateQAApproved
                && object2.DateStartedToQA == null
                && object2.DateSubmitted == null
                && object2.DeliveryOrganisationId == null
                && object1.DurationValue == object2.Duration
                && object1.DurationTypeId == (int)object2.DurationType
                && string.Equals(object1.EmployerAnonymousName, object2.EmployerAnonymousName)
                && object2.EmployerAnonymousReason == null
                && object1.EmployerId == object2.EmployerId
                && object2.EmployerLocation == null
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
                && object1.VacancyOwnerRelationshipId == object2.VacancyOwnerRelationshipId
                && object1.VacancyReferenceNumber == object2.VacancyReferenceNumber
                && object1.VacancyTypeId == (int)object2.VacancyType
                && object1.WeeklyWage == object2.Wage.Amount
                && object1.WageLowerBound == object2.Wage.AmountLowerBound
                && object1.WageUpperBound == object2.Wage.AmountUpperBound
                && object1.HoursPerWeek == object2.Wage.HoursPerWeek
                && object2.Wage.ReasonForType == null
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
                && object2.LocalAuthorityCode == null
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
                && object2.StandardStatus == 0
                && object1.IsEmployerPositiveAboutDisability == object2.IsEmployerPositiveAboutDisability;
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