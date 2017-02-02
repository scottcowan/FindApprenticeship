namespace SFA.DAS.RAA.Api.AcceptanceTests.Comparers
{
    using System;
    using Apprenticeships.Domain.Entities.Raa.Reference;
    using Apprenticeships.Domain.Entities.Vacancies;
    using VacancySummary = Apprenticeships.Domain.Entities.Raa.Vacancies.VacancySummary;
    using DbVacancySummary = Apprenticeships.Infrastructure.Repositories.Sql.Schemas.Vacancy.Entities.VacancySummary;

    public class DbPublicVacancySummaryComparer : IMultiEqualityComparer<DbVacancySummary, VacancySummary>
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
                && ((double?)object1.Longitude).Equals(object2.Address.GeoPoint.Longitude)
                && ((double?)object1.Latitude).Equals(object2.Address.GeoPoint.Latitude)
                && object1.GeocodeEasting == object2.Address.GeoPoint.Easting
                && object1.GeocodeNorthing == object2.Address.GeoPoint.Northing
                && object2.AnonymousAboutTheEmployer == null
                && object2.ApplicantCount == 0
                && object1.ApprenticeshipLevel == object2.ApprenticeshipLevel
                && object1.ApplicationClosingDate.Equals(object2.ClosingDate)
                && object2.ContractOwnerId == 0
                && object2.CreatedDate == DateTime.MinValue
                && object2.DateFirstSubmitted == null
                && object1.DateQAApproved == object2.DateQAApproved
                && object2.DateStartedToQA == null
                && object2.DateSubmitted == null
                && object2.DeliveryOrganisationId == null
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
                //Not set in full vacancy
                //&& string.Equals(object1.ProviderTradingName, object2.ProviderTradingName) 
                && object2.QAUserName == null
                && object2.RegionalTeam == RegionalTeam.Other
                && string.Equals(object1.SectorCodeName, object2.SectorCodeName)
                && string.Equals(object1.ShortDescription, object2.ShortDescription)
                && object1.StandardId == object2.StandardId
                && object1.VacancyStatusId == object2.Status
                && object2.SubmissionCount == 0
                && string.Equals(object1.Title, object2.Title)
                && object1.TrainingTypeId == object2.TrainingType
                && object2.UpdatedDateTime == null
                && object1.VacancyGuid.Equals(object2.VacancyGuid)
                && object1.VacancyId == object2.VacancyId
                && object1.VacancyLocationTypeId == (int)object2.VacancyLocationType
                && object2.VacancyManagerId == null
                && object2.VacancyOwnerRelationshipId == 0
                && object1.VacancyReferenceNumber == object2.VacancyReferenceNumber
                && object1.VacancyTypeId == object2.VacancyType
                && object1.WeeklyWage == object2.Wage.Amount
                && object1.WageLowerBound == object2.Wage.AmountLowerBound
                && object1.WageUpperBound == object2.Wage.AmountUpperBound
                && object1.HoursPerWeek == object2.Wage.HoursPerWeek
                && object2.Wage.ReasonForType == null
                && string.Equals(object1.WageText, object2.Wage.Text)
                && wageType == object2.Wage.Type
                && CorrectWageUnit(wageType, wageUnit) == object2.Wage.Unit
                && string.Equals(object1.WorkingWeek, object2.WorkingWeek)
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

        public int GetHashCode(DbVacancySummary object1)
        {
            return 0;
        }

        public int GetHashCode(VacancySummary object2)
        {
            return 0;
        }
    }
}