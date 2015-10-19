﻿namespace SFA.Apprenticeships.Web.Recruit.Converters
{
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
                WeeklyWage = apprenticeshipVacancy.WeeklyWage,
                Duration = apprenticeshipVacancy.Duration,
                ClosingDate = apprenticeshipVacancy.ClosingDate,
                PossibleStartDate = apprenticeshipVacancy.PossibleStartDate,
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
            var vacancyViewModel = new VacancyViewModel
            {
                VacancyReferenceNumber = apprenticeshipVacancy.VacancyReferenceNumber,
                Ukprn = apprenticeshipVacancy.Ukprn,
                Title = apprenticeshipVacancy.Title,
                ShortDescription = apprenticeshipVacancy.ShortDescription,
                WorkingWeek = apprenticeshipVacancy.WorkingWeek,
                WeeklyWage = apprenticeshipVacancy.WeeklyWage,
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
                FrameworkCodeName = apprenticeshipVacancy.FrameworkCodeName,
                ProviderSiteEmployerLink = apprenticeshipVacancy.ProviderSiteEmployerLink.Convert(),
            };

            return vacancyViewModel;
        }
    }
}