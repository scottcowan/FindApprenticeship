namespace SFA.DAS.RAA.Api.AcceptanceTests.Comparers
{
    using System;
    using Apprenticeships.Domain.Entities.Vacancies;
    using VacancySummary = Apprenticeships.Domain.Entities.Raa.Vacancies.VacancySummary;
    using DbVacancySummary = Apprenticeships.Infrastructure.Repositories.Sql.Schemas.Vacancy.Entities.VacancySummary;

    public class DbVacancySummaryComparer : IMultiEqualityComparer<DbVacancySummary, VacancySummary>
    {
        public bool Equals(DbVacancySummary object1, VacancySummary object2)
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
                   && object1.ApplicantCount == object2.ApplicantCount
                   && object1.ApprenticeshipLevel == object2.ApprenticeshipLevel
                   && object1.ApplicationClosingDate.Equals(object2.ClosingDate)
                   && object1.CreatedDate.Equals(object2.CreatedDate)
                   && object1.DateFirstSubmitted.Equals(object2.DateFirstSubmitted)
                   && object1.DateQAApproved.Equals(object2.DateQAApproved)
                   && object1.StartedToQADateTime.Equals(object2.DateStartedToQA)
                   && object1.DateSubmitted.Equals(object2.DateSubmitted)
                   && string.Equals(object1.EmployerAnonymousName, object2.EmployerAnonymousName)
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
                   //Not set in full vacancy
                   //&& string.Equals(object1.ProviderTradingName, object2.ProviderTradingName) 
                   && string.Equals(object1.QAUserName, object2.QAUserName)
                   && object1.RegionalTeam == object2.RegionalTeam
                   && string.Equals(object1.SectorCodeName, object2.SectorCodeName)
                   && string.Equals(object1.ShortDescription, object2.ShortDescription)
                   && object1.StandardId == object2.StandardId
                   && object1.VacancyStatusId == object2.Status
                   && object1.SubmissionCount == object2.SubmissionCount
                   && string.Equals(object1.Title, object2.Title)
                   && object1.TrainingTypeId == object2.TrainingType
                   && object1.UpdatedDateTime.Equals(object2.UpdatedDateTime)
                   && object1.VacancyGuid.Equals(object2.VacancyGuid)
                   && object1.VacancyId == object2.VacancyId
                   && object1.VacancyLocationTypeId == (int) object2.VacancyLocationType
                   && object1.VacancyOwnerRelationshipId == object2.VacancyOwnerRelationshipId
                   && object1.VacancyReferenceNumber == object2.VacancyReferenceNumber
                   && object1.VacancyTypeId == object2.VacancyType
                   && object1.WeeklyWage == object2.Wage.Amount
                   && object1.WageLowerBound == object2.Wage.AmountLowerBound
                   && object1.WageUpperBound == object2.Wage.AmountUpperBound
                   && object1.HoursPerWeek == object2.Wage.HoursPerWeek
                   && string.Equals(object1.WageTypeReason, object2.Wage.ReasonForType)
                   && string.Equals(object1.WageText, object2.Wage.Text)
                   && wageType == object2.Wage.Type
                   && CorrectWageUnit(wageType, wageUnit) == object2.Wage.Unit
                   && string.Equals(object1.WorkingWeek, object2.WorkingWeek);
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

        public int GetHashCode(DbVacancySummary object1)
        {
            var hashCode = (object1.AddressLine1 != null ? object1.AddressLine1.GetHashCode() : 0);
            hashCode = (hashCode * 397) ^ (object1.AddressLine2 != null ? object1.AddressLine2.GetHashCode() : 0);
            hashCode = (hashCode * 397) ^ (object1.AddressLine3 != null ? object1.AddressLine3.GetHashCode() : 0);
            hashCode = (hashCode * 397) ^ (object1.AddressLine4 != null ? object1.AddressLine4.GetHashCode() : 0);
            hashCode = (hashCode * 397) ^ (object1.AddressLine5 != null ? object1.AddressLine5.GetHashCode() : 0);
            hashCode = (hashCode * 397) ^ object1.ApplicantCount.GetHashCode();
            hashCode = (hashCode * 397) ^ object1.ApplicationClosingDate.GetHashCode();
            hashCode = (hashCode * 397) ^ object1.ApplyOutsideNAVMS.GetHashCode();
            hashCode = (hashCode * 397) ^ (int)object1.ApprenticeshipLevel;
            hashCode = (hashCode * 397) ^ object1.CountyId;
            hashCode = (hashCode * 397) ^ object1.CreatedDate.GetHashCode();
            hashCode = (hashCode * 397) ^ object1.DateFirstSubmitted.GetHashCode();
            hashCode = (hashCode * 397) ^ object1.DateQAApproved.GetHashCode();
            hashCode = (hashCode * 397) ^ object1.DateSubmitted.GetHashCode();
            hashCode = (hashCode * 397) ^ (object1.EmployerAnonymousName != null ? object1.EmployerAnonymousName.GetHashCode() : 0);
            hashCode = (hashCode * 397) ^ object1.EmployerId;
            hashCode = (hashCode * 397) ^ (object1.EmployerLocation != null ? object1.EmployerLocation.GetHashCode() : 0);
            hashCode = (hashCode * 397) ^ (object1.EmployerName != null ? object1.EmployerName.GetHashCode() : 0);
            hashCode = (hashCode * 397) ^ (object1.ExpectedDuration != null ? object1.ExpectedDuration.GetHashCode() : 0);
            hashCode = (hashCode * 397) ^ (object1.FrameworkCodeName != null ? object1.FrameworkCodeName.GetHashCode() : 0);
            hashCode = (hashCode * 397) ^ object1.GeocodeEasting.GetHashCode();
            hashCode = (hashCode * 397) ^ object1.GeocodeNorthing.GetHashCode();
            hashCode = (hashCode * 397) ^ object1.HoursPerWeek.GetHashCode();
            hashCode = (hashCode * 397) ^ object1.Latitude.GetHashCode();
            hashCode = (hashCode * 397) ^ object1.Longitude.GetHashCode();
            hashCode = (hashCode * 397) ^ object1.NewApplicantCount.GetHashCode();
            hashCode = (hashCode * 397) ^ object1.NoOfOfflineApplicants.GetHashCode();
            hashCode = (hashCode * 397) ^ object1.NumberOfPositions.GetHashCode();
            hashCode = (hashCode * 397) ^ object1.OriginalContractOwnerId.GetHashCode();
            hashCode = (hashCode * 397) ^ (object1.PostCode != null ? object1.PostCode.GetHashCode() : 0);
            hashCode = (hashCode * 397) ^ (object1.QAUserName != null ? object1.QAUserName.GetHashCode() : 0);
            hashCode = (hashCode * 397) ^ (int)object1.RegionalTeam;
            hashCode = (hashCode * 397) ^ (object1.SectorCodeName != null ? object1.SectorCodeName.GetHashCode() : 0);
            hashCode = (hashCode * 397) ^ (object1.ShortDescription != null ? object1.ShortDescription.GetHashCode() : 0);
            hashCode = (hashCode * 397) ^ object1.StandardId.GetHashCode();
            hashCode = (hashCode * 397) ^ object1.StartedToQADateTime.GetHashCode();
            hashCode = (hashCode * 397) ^ object1.SubmissionCount;
            hashCode = (hashCode * 397) ^ (object1.Title != null ? object1.Title.GetHashCode() : 0);
            hashCode = (hashCode * 397) ^ (object1.Town != null ? object1.Town.GetHashCode() : 0);
            hashCode = (hashCode * 397) ^ (int)object1.TrainingTypeId;
            hashCode = (hashCode * 397) ^ object1.UpdatedDateTime.GetHashCode();
            hashCode = (hashCode * 397) ^ object1.VacancyGuid.GetHashCode();
            hashCode = (hashCode * 397) ^ object1.VacancyId;
            hashCode = (hashCode * 397) ^ object1.VacancyLocationTypeId.GetHashCode();
            hashCode = (hashCode * 397) ^ object1.VacancyOwnerRelationshipId;
            hashCode = (hashCode * 397) ^ object1.VacancyReferenceNumber;
            hashCode = (hashCode * 397) ^ (int)object1.VacancyStatusId;
            hashCode = (hashCode * 397) ^ (int)object1.VacancyTypeId;
            hashCode = (hashCode * 397) ^ object1.WageLowerBound.GetHashCode();
            hashCode = (hashCode * 397) ^ (object1.WageText != null ? object1.WageText.GetHashCode() : 0);
            hashCode = (hashCode * 397) ^ object1.WageType;
            hashCode = (hashCode * 397) ^ (object1.WageTypeReason != null ? object1.WageTypeReason.GetHashCode() : 0);
            hashCode = (hashCode * 397) ^ object1.WageUnitId.GetHashCode();
            hashCode = (hashCode * 397) ^ object1.WageUpperBound.GetHashCode();
            hashCode = (hashCode * 397) ^ object1.WeeklyWage.GetHashCode();
            hashCode = (hashCode * 397) ^ (object1.WorkingWeek != null ? object1.WorkingWeek.GetHashCode() : 0);
            return hashCode;
        }

        public int GetHashCode(VacancySummary object2)
        {
            //VacancySummary
            var hashCode = (object2.Address != null ? object2.Address.GetHashCode() : 0);
            hashCode = (hashCode * 397) ^ (object2.AnonymousAboutTheEmployer != null ? object2.AnonymousAboutTheEmployer.GetHashCode() : 0);
            hashCode = (hashCode * 397) ^ object2.ApplicantCount;
            hashCode = (hashCode * 397) ^ (int)object2.ApprenticeshipLevel;
            hashCode = (hashCode * 397) ^ object2.ClosingDate.GetHashCode();
            hashCode = (hashCode * 397) ^ object2.ContractOwnerId;
            hashCode = (hashCode * 397) ^ object2.CreatedDate.GetHashCode();
            hashCode = (hashCode * 397) ^ object2.DateFirstSubmitted.GetHashCode();
            hashCode = (hashCode * 397) ^ object2.DateQAApproved.GetHashCode();
            hashCode = (hashCode * 397) ^ object2.DateStartedToQA.GetHashCode();
            hashCode = (hashCode * 397) ^ object2.DateSubmitted.GetHashCode();
            hashCode = (hashCode * 397) ^ object2.DeliveryOrganisationId.GetHashCode();
            hashCode = (hashCode * 397) ^ object2.Duration.GetHashCode();
            hashCode = (hashCode * 397) ^ (int)object2.DurationType;
            hashCode = (hashCode * 397) ^ (object2.EmployerAnonymousName != null ? object2.EmployerAnonymousName.GetHashCode() : 0);
            hashCode = (hashCode * 397) ^ (object2.EmployerAnonymousReason != null ? object2.EmployerAnonymousReason.GetHashCode() : 0);
            hashCode = (hashCode * 397) ^ object2.EmployerId;
            hashCode = (hashCode * 397) ^ (object2.EmployerLocation != null ? object2.EmployerLocation.GetHashCode() : 0);
            hashCode = (hashCode * 397) ^ (object2.EmployerName != null ? object2.EmployerName.GetHashCode() : 0);
            hashCode = (hashCode * 397) ^ (object2.ExpectedDuration != null ? object2.ExpectedDuration.GetHashCode() : 0);
            hashCode = (hashCode * 397) ^ (object2.FrameworkCodeName != null ? object2.FrameworkCodeName.GetHashCode() : 0);
            hashCode = (hashCode * 397) ^ object2.IsAnonymousEmployer.GetHashCode();
            hashCode = (hashCode * 397) ^ object2.NewApplicationCount;
            hashCode = (hashCode * 397) ^ object2.NoOfOfflineApplicants;
            hashCode = (hashCode * 397) ^ object2.NumberOfPositions.GetHashCode();
            hashCode = (hashCode * 397) ^ object2.OfflineVacancy.GetHashCode();
            hashCode = (hashCode * 397) ^ object2.OriginalContractOwnerId;
            hashCode = (hashCode * 397) ^ object2.ParentVacancyId.GetHashCode();
            hashCode = (hashCode * 397) ^ object2.PossibleStartDate.GetHashCode();
            hashCode = (hashCode * 397) ^ (object2.ProviderTradingName != null ? object2.ProviderTradingName.GetHashCode() : 0);
            hashCode = (hashCode * 397) ^ (object2.QAUserName != null ? object2.QAUserName.GetHashCode() : 0);
            hashCode = (hashCode * 397) ^ (int)object2.RegionalTeam;
            hashCode = (hashCode * 397) ^ (object2.SectorCodeName != null ? object2.SectorCodeName.GetHashCode() : 0);
            hashCode = (hashCode * 397) ^ (object2.ShortDescription != null ? object2.ShortDescription.GetHashCode() : 0);
            hashCode = (hashCode * 397) ^ object2.StandardId.GetHashCode();
            hashCode = (hashCode * 397) ^ (int)object2.Status;
            hashCode = (hashCode * 397) ^ object2.SubmissionCount;
            hashCode = (hashCode * 397) ^ (object2.Title != null ? object2.Title.GetHashCode() : 0);
            hashCode = (hashCode * 397) ^ (int)object2.TrainingType;
            hashCode = (hashCode * 397) ^ object2.UpdatedDateTime.GetHashCode();
            hashCode = (hashCode * 397) ^ object2.VacancyGuid.GetHashCode();
            hashCode = (hashCode * 397) ^ object2.VacancyId;
            hashCode = (hashCode * 397) ^ (int)object2.VacancyLocationType;
            hashCode = (hashCode * 397) ^ object2.VacancyManagerId.GetHashCode();
            hashCode = (hashCode * 397) ^ object2.VacancyOwnerRelationshipId;
            hashCode = (hashCode * 397) ^ object2.VacancyReferenceNumber;
            hashCode = (hashCode * 397) ^ (int)object2.VacancyType;
            hashCode = (hashCode * 397) ^ (object2.Wage != null ? object2.Wage.GetHashCode() : 0);
            hashCode = (hashCode * 397) ^ (object2.WorkingWeek != null ? object2.WorkingWeek.GetHashCode() : 0);

            return hashCode;
        }
    }
}