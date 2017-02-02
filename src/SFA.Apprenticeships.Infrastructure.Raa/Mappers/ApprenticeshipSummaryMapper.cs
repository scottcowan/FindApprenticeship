﻿namespace SFA.Apprenticeships.Infrastructure.Raa.Mappers
{
    using Application.Interfaces;
    using Domain.Entities.Extensions;
    using Domain.Entities.ReferenceData;
    using Domain.Entities.Vacancies;
    using Extensions;
    using System;
    using System.Collections.Generic;
    using DAS.RAA.Api.Client.V1.Models;
    using GeoPoint = Domain.Entities.Locations.GeoPoint;
    using VacancyLocationType = Domain.Entities.Vacancies.VacancyLocationType;
    using VacancySummary = Domain.Entities.Raa.Vacancies.VacancySummary;

    public class ApprenticeshipSummaryMapper
    {
        public static ApprenticeshipSummary GetApprenticeshipSummary(VacancySummary vacancy, IList<Category> categories, ILogService logService)
        {
            try
            {
                //Manually mapping rather than using automapper as the two enties are significantly different

                var location = GetGeoPoint(vacancy);

                var category = vacancy.GetCategory(categories);
                var subcategory = vacancy.GetSubCategory(categories);
                LogCategoryAndSubCategory(vacancy, logService, category, subcategory);

                var summary = new ApprenticeshipSummary
                {
                    Id = vacancy.VacancyId,
                    //Goes into elastic unformatted for searching
                    VacancyReference = vacancy.VacancyReferenceNumber.ToString(),
                    Title = vacancy.Title,
                    // ReSharper disable PossibleInvalidOperationException
                    PostedDate = vacancy.DateQAApproved.Value,
                    StartDate = vacancy.PossibleStartDate.Value,
                    ClosingDate = vacancy.ClosingDate.Value,
                    // ReSharper restore PossibleInvalidOperationException
                    Description = vacancy.ShortDescription,
                    NumberOfPositions = vacancy.NumberOfPositions,
                    EmployerName = string.IsNullOrEmpty(vacancy.EmployerAnonymousName) ? vacancy.EmployerName : vacancy.EmployerAnonymousName,
                    ProviderName = vacancy.ProviderTradingName,
                    IsPositiveAboutDisability = vacancy.IsEmployerPositiveAboutDisability,
                    IsEmployerAnonymous = !string.IsNullOrEmpty(vacancy.EmployerAnonymousName),
                    Location = location,
                    VacancyLocationType = vacancy.VacancyLocationType == Domain.Entities.Raa.Vacancies.VacancyLocationType.Nationwide ? VacancyLocationType.National : VacancyLocationType.NonNational,
                    ApprenticeshipLevel = vacancy.ApprenticeshipLevel.GetApprenticeshipLevel(),
                    Wage = vacancy.Wage,
                    WorkingWeek = vacancy.WorkingWeek,
                    CategoryCode = category.CodeName,
                    Category = category.FullName,
                    SubCategoryCode = subcategory.CodeName,
                    SubCategory = subcategory.FullName,
                    AnonymousEmployerName = vacancy.EmployerAnonymousName
                };

                return summary;
            }
            catch (Exception ex)
            {
                logService.Error($"Failed to map apprenticeship with Id: {vacancy?.VacancyId ?? 0}", ex);
                return null;
            }
        }

        private static GeoPoint GetGeoPoint(VacancySummary vacancy)
        {
            if (vacancy.Address?.GeoPoint == null)
            {
                return new GeoPoint();
            }

            return new GeoPoint
            {
                Latitude = vacancy.Address.GeoPoint.Latitude,
                Longitude = vacancy.Address.GeoPoint.Longitude
            };
        }

        private static void LogCategoryAndSubCategory(VacancySummary vacancy, ILogService logService, Category category, Category subcategory)
        {
            if (!category.IsValid())
            {
                logService.Warn("Cannot find a category for the apprenticeship with Id {0}", vacancy.VacancyId);
            }
            if (!subcategory.IsValid())
            {
                logService.Warn("Cannot find a category for the apprenticeship with Id {0}", vacancy.VacancyId);
            }
        }
    }
}