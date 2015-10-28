﻿using SFA.Apprenticeships.Domain.Entities.Vacancies.Apprenticeships;

namespace SFA.Apprenticeships.Web.Recruit.Converters
{
    using Common.ViewModels;
    using Domain.Entities.Vacancies.ProviderVacancies.Apprenticeship;
    using ViewModels.Vacancy;

    public static class ApprenticeshipVacancyConverter
    {
        public static VacancySummaryViewModel ConvertToVacancySummaryViewModel(this ApprenticeshipVacancy apprenticeshipVacancy)
        {
            var vacancyViewModel = new VacancySummaryViewModel
            {
                VacancyReferenceNumber = apprenticeshipVacancy.VacancyReferenceNumber,
                WorkingWeek = apprenticeshipVacancy.WorkingWeek,
                Wage = apprenticeshipVacancy.Wage,
                Duration = apprenticeshipVacancy.Duration,
                ClosingDate = new DateViewModel(apprenticeshipVacancy.ClosingDate),
                PossibleStartDate = new DateViewModel(apprenticeshipVacancy.PossibleStartDate),
                LongDescription = apprenticeshipVacancy.LongDescription
            };

            return vacancyViewModel;
        }

        public static VacancyRequirementsProspectsViewModel ConvertToVacancyRequirementsProspectsViewModel(this ApprenticeshipVacancy apprenticeshipVacancy)
        {
            var vacancyViewModel = new VacancyRequirementsProspectsViewModel
            {
                VacancyReferenceNumber = apprenticeshipVacancy.VacancyReferenceNumber,
                DesiredSkills = apprenticeshipVacancy.DesiredSkills,
                FutureProspects = apprenticeshipVacancy.FutureProspects,
                PersonalQualities = apprenticeshipVacancy.PersonalQualities,
                ThingsToConsider = apprenticeshipVacancy.ThingsToConsider,
                DesiredQualifications = apprenticeshipVacancy.DesiredQualifications
            };

            return vacancyViewModel;
        }

        public static VacancyQuestionsViewModel ConvertToVacancyQuestionsViewModel(this ApprenticeshipVacancy apprenticeshipVacancy)
        {
            var vacancyViewModel = new VacancyQuestionsViewModel
            {
                VacancyReferenceNumber = apprenticeshipVacancy.VacancyReferenceNumber,
                FirstQuestion = apprenticeshipVacancy.FirstQuestion,
                SecondQuestion = apprenticeshipVacancy.SecondQuestion
            };

            return vacancyViewModel;
        }

        public static VacancyViewModel ConvertToVacancyViewModel(this ApprenticeshipVacancy apprenticeshipVacancy)
        {
            //TODO: Automap
            var vacancyViewModel = new VacancyViewModel
            {
                VacancyReferenceNumber = apprenticeshipVacancy.VacancyReferenceNumber,
                Ukprn = apprenticeshipVacancy.Ukprn,
                Title = apprenticeshipVacancy.Title,
                ShortDescription = apprenticeshipVacancy.ShortDescription,
                WorkingWeek = apprenticeshipVacancy.WorkingWeek,
                HoursPerWeek = apprenticeshipVacancy.HoursPerWeek,
                WageType = apprenticeshipVacancy.WageType,
                Wage = apprenticeshipVacancy.Wage,
                DurationType = apprenticeshipVacancy.DurationType,
                Duration = apprenticeshipVacancy.Duration,
                ClosingDate = apprenticeshipVacancy.ClosingDate,
                PossibleStartDate = apprenticeshipVacancy.PossibleStartDate,
                LongDescription = apprenticeshipVacancy.LongDescription,
                DesiredSkills = apprenticeshipVacancy.DesiredSkills,
                FutureProspects = apprenticeshipVacancy.FutureProspects,
                PersonalQualities = apprenticeshipVacancy.PersonalQualities,
                ThingsToConsider = apprenticeshipVacancy.ThingsToConsider,
                DesiredQualifications = apprenticeshipVacancy.DesiredQualifications,
                FirstQuestion = apprenticeshipVacancy.FirstQuestion,
                SecondQuestion = apprenticeshipVacancy.SecondQuestion,
                ApprenticeshipLevel = apprenticeshipVacancy.ApprenticeshipLevel,
                Status = apprenticeshipVacancy.Status,
                FrameworkCodeName = apprenticeshipVacancy.FrameworkCodeName,
                ProviderSiteEmployerLink = apprenticeshipVacancy.ProviderSiteEmployerLink.Convert(),
                OfflineVacancy = apprenticeshipVacancy.OfflineVacancy,
                OfflineApplicationUrl = apprenticeshipVacancy.OfflineApplicationUrl,
                OfflineApplicationInstructions = apprenticeshipVacancy.OfflineApplicationInstructions
            };

            return vacancyViewModel;
        }

        public static NewVacancyViewModel ConvertToNewVacancyViewModel(this ApprenticeshipVacancy apprenticeshipVacancy)
        {
            var vacancyViewModel = new NewVacancyViewModel()
            {
                ApprenticeshipLevel = apprenticeshipVacancy.ApprenticeshipLevel,
                FrameworkCodeName = apprenticeshipVacancy.FrameworkCodeName,
                ShortDescription = apprenticeshipVacancy.ShortDescription,
                Title = apprenticeshipVacancy.Title,
                Ukprn = apprenticeshipVacancy.Ukprn,
                VacancyReferenceNumber = apprenticeshipVacancy.VacancyReferenceNumber,
                ProviderSiteEmployerLink = apprenticeshipVacancy.ProviderSiteEmployerLink.Convert(),
                OfflineVacancy = apprenticeshipVacancy.OfflineVacancy,
                OfflineApplicationUrl = apprenticeshipVacancy.OfflineApplicationUrl,
                OfflineApplicationInstructions = apprenticeshipVacancy.OfflineApplicationInstructions
            };

            return vacancyViewModel;
        }
    }
}