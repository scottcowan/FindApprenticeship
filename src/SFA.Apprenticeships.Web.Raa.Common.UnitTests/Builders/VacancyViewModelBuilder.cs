﻿namespace SFA.Apprenticeships.Web.Raa.Common.UnitTests.Builders
{
    using System;
    using Domain.Entities.Vacancies.ProviderVacancies;
    using Domain.Entities.Vacancies.ProviderVacancies.Apprenticeship;
    using Ploeh.AutoFixture;
    using ViewModels.Vacancy;
    using Web.Common.ViewModels;

    public class VacancyViewModelBuilder
    {
        private NewVacancyViewModel _newVacancyViewModel = new NewVacancyViewModel();
        private TrainingDetailsViewModel _trainingDetailsViewModel = new TrainingDetailsViewModel();
        private VacancyRequirementsProspectsViewModel _vacancyRequirementsProspectsViewModel = new VacancyRequirementsProspectsViewModel();
        private VacancyQuestionsViewModel _vacancyQuestionsViewModel = new VacancyQuestionsViewModel();
        private VacancySummaryViewModel _vacancySummaryViewModel = new VacancySummaryViewModel
        {
            VacancyDatesViewModel = new VacancyDatesViewModel()
        };

        public VacancyViewModel Build()
        {
            var viewModel = new VacancyViewModel
            {
                NewVacancyViewModel = _newVacancyViewModel,
                TrainingDetailsViewModel = _trainingDetailsViewModel,
                VacancySummaryViewModel = _vacancySummaryViewModel,
                VacancyRequirementsProspectsViewModel = _vacancyRequirementsProspectsViewModel,
                VacancyQuestionsViewModel = _vacancyQuestionsViewModel
            };
            return viewModel;
        }

        public VacancyViewModel BuildValid(ProviderVacancyStatuses status)
        {
            var viewModel = new Fixture().Build<VacancyViewModel>().Create();
            viewModel.NewVacancyViewModel.OfflineVacancy = false;
            viewModel.NewVacancyViewModel.OfflineApplicationUrl = null;
            viewModel.NewVacancyViewModel.OfflineApplicationInstructions = null;
            viewModel.TrainingDetailsViewModel.TrainingType = TrainingType.Frameworks;
            viewModel.TrainingDetailsViewModel.ApprenticeshipLevel = ApprenticeshipLevel.Higher;
            viewModel.VacancySummaryViewModel.Status = status;
            viewModel.VacancySummaryViewModel.HoursPerWeek = 30;
            viewModel.VacancySummaryViewModel.Duration = 12;
            viewModel.VacancySummaryViewModel.DurationType = DurationType.Months;
            viewModel.VacancySummaryViewModel.WageType = WageType.NationalMinimumWage;
            viewModel.VacancySummaryViewModel.VacancyDatesViewModel = new VacancyDatesViewModel
            {
                PossibleStartDate = new DateViewModel(DateTime.UtcNow.AddDays(28)),
                ClosingDate = new DateViewModel(DateTime.UtcNow.AddDays(14))
            };
            viewModel.Status = status;
            return viewModel;
        }

        public VacancyViewModelBuilder With(NewVacancyViewModel newVacancyViewModel)
        {
            _newVacancyViewModel = newVacancyViewModel;
            return this;
        }

        public VacancyViewModelBuilder With(TrainingDetailsViewModel trainingDetailsViewModel)
        {
            _trainingDetailsViewModel = trainingDetailsViewModel;
            return this;
        }

        public VacancyViewModelBuilder With(VacancySummaryViewModel vacancySummaryViewModel)
        {
            _vacancySummaryViewModel = vacancySummaryViewModel;
            return this;
        }

        public VacancyViewModelBuilder With(VacancyRequirementsProspectsViewModel vacancyRequirementsProspectsViewModel)
        {
            _vacancyRequirementsProspectsViewModel = vacancyRequirementsProspectsViewModel;
            return this;
        }

        public VacancyViewModelBuilder With(VacancyQuestionsViewModel vacancyQuestionsViewModel)
        {
            _vacancyQuestionsViewModel = vacancyQuestionsViewModel;
            return this;
        }

        public VacancyViewModelBuilder With(VacancyDatesViewModel vacancyDatesViewModel)
        {
            _vacancySummaryViewModel.VacancyDatesViewModel = vacancyDatesViewModel;
            return this;
        }
    }
}