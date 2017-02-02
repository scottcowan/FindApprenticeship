﻿namespace SFA.Apprenticeships.Infrastructure.Raa.Mappers
{
    using Domain.Entities.Extensions;
    using Domain.Entities.Locations;
    using Domain.Entities.Raa.Parties;
    using Domain.Entities.ReferenceData;
    using Domain.Entities.Vacancies;
    using Presentation;
    using Application.Interfaces;
    using System;
    using System.Collections.Generic;
    using Domain.Entities.Raa.Vacancies;
    using Extensions;
    using GeoPoint = Domain.Entities.Locations.GeoPoint;
    using PostalAddress = Domain.Entities.Raa.Locations.PostalAddress;
    using VacancyLocationType = Domain.Entities.Vacancies.VacancyLocationType;
    using VacancySummary = Domain.Entities.Raa.Vacancies.VacancySummary;

    public class ApprenticeshipVacancyDetailMapper
    {
        public static ApprenticeshipVacancyDetail GetApprenticeshipVacancyDetail(Vacancy vacancy, Employer employer, Provider provider, ProviderSite providerSite, IList<Category> categories, ILogService logService)
        {
            //Manually mapping rather than using automapper as the two enties are significantly different

            var subcategory = vacancy.GetSubCategory(categories);
            LogSubCategory(vacancy, logService, subcategory);

            var detail = new ApprenticeshipVacancyDetail
            {
                Id = vacancy.VacancyId,
                VacancyReference = vacancy.VacancyReferenceNumber.GetVacancyReference(),
                Title = vacancy.Title,
                Description = vacancy.ShortDescription,
                FullDescription = vacancy.LongDescription,
                //SubCategory = vacancy.,
                StartDate = vacancy.PossibleStartDate ?? DateTime.MinValue,
                ClosingDate = vacancy.ClosingDate ?? DateTime.MinValue,
                PostedDate = vacancy.DateQAApproved ?? DateTime.MinValue,
                //TODO: Where should this come from?
                InterviewFromDate = DateTime.MinValue,
                Wage = vacancy.Wage,
                WorkingWeek = vacancy.WorkingWeek,
                HoursPerWeek = vacancy.Wage.HoursPerWeek,
                OtherInformation = vacancy.OtherInformation,
                FutureProspects = vacancy.FutureProspects,
                //TODO: Where from?
                //VacancyOwner = vacancy.,
                //VacancyManager = vacancy.,
                //LocalAuthority = vacancy.,
                NumberOfPositions = vacancy.NumberOfPositions ?? 0,
                RealityCheck = vacancy.ThingsToConsider,
                VacancyStatus = vacancy.Status.GetVacancyStatuses(),
                EmployerName = employer.FullName,
                AnonymousEmployerName = vacancy.EmployerAnonymousName,
                IsEmployerAnonymous = !string.IsNullOrWhiteSpace(vacancy.EmployerAnonymousName),
                EmployerDescription = string.IsNullOrWhiteSpace(vacancy.AnonymousAboutTheEmployer) ? vacancy.EmployerDescription : vacancy.AnonymousAboutTheEmployer,
                EmployerWebsite = vacancy.EmployerWebsiteUrl,
                ApplyViaEmployerWebsite = vacancy.OfflineVacancy ?? false,
                VacancyUrl = vacancy.OfflineApplicationUrl,
                ApplicationInstructions = vacancy.OfflineApplicationInstructions,
                IsPositiveAboutDisability = employer.IsPositiveAboutDisability,
                ExpectedDuration = vacancy.ExpectedDuration,
                VacancyAddress = GetVacancyAddress(vacancy.Address),
                //TODO: How is this captured in RAA?
                //IsRecruitmentAgencyAnonymous = vacancy.,
                //TODO: How is this captured in RAA?
                //IsSmallEmployerWageIncentive = vacancy.,
                SupplementaryQuestion1 = vacancy.FirstQuestion,
                SupplementaryQuestion2 = vacancy.SecondQuestion,
                //TODO: How is this captured in RAA?
                RecruitmentAgency = providerSite.TradingName,
                ProviderName = provider.TradingName,
                TradingName = employer.TradingName,
                //ProviderDescription = vacancy.,
                Contact = vacancy.GetContactInformation(providerSite),
                TrainingToBeProvided = vacancy.TrainingProvided,
                //TODO: How is this captured in RAA?
                //ContractOwner = vacancy.,
                //DeliveryOrganisation = vacancy.,
                //IsNasProvider = vacancy.,
                PersonalQualities = vacancy.PersonalQualities,
                QualificationRequired = vacancy.DesiredQualifications,
                SkillsRequired = vacancy.DesiredSkills,
                VacancyLocationType = vacancy.VacancyLocationType == Domain.Entities.Raa.Vacancies.VacancyLocationType.Nationwide ? VacancyLocationType.National : VacancyLocationType.NonNational,
                ApprenticeshipLevel = vacancy.ApprenticeshipLevel.GetApprenticeshipLevel(),
                SubCategory = subcategory.FullName,
                TrainingType = vacancy.TrainingType.GetTrainingType(),
                AdditionalLocationInformation = vacancy.AdditionalLocationInformation
            };

            return detail;
        }

        private static void LogSubCategory(VacancySummary vacancy, ILogService logService, Category subcategory)
        {
            if (!subcategory.IsValid())
            {
                logService.Warn("Cannot find a sub category for the apprenticship with Id {0}", vacancy.VacancyId);
            }
        }

        private static Address GetVacancyAddress(PostalAddress address)
        {
            return new Address
            {
                AddressLine1 = address.AddressLine1,
                AddressLine2 = address.AddressLine2,
                AddressLine3 = address.AddressLine3,
                AddressLine4 = address.AddressLine4,
                Town = address.Town,
                County = address.County,
                Postcode = address.Postcode,
                GeoPoint = GetGeoPoint(address.GeoPoint)
            };
        }

        private static GeoPoint GetGeoPoint(Domain.Entities.Raa.Locations.GeoPoint geoPoint)
        {
            return new GeoPoint
            {
                Longitude = geoPoint.Longitude,
                Latitude = geoPoint.Latitude
            };
        }
    }
}