﻿namespace SFA.Apprenticeships.Web.Manage.UnitTests.Mediators.Vacancy
{
    using Manage.Mediators.Vacancy;
    using Moq;
    using Raa.Common.Providers;
    using Raa.Common.Validators.Vacancy;

    public class VacancyMediatorBuilder
    {
        private readonly NewVacancyViewModelServerValidator _newVacancyViewModelServerValidator =
            new NewVacancyViewModelServerValidator();

        private Mock<IVacancyQAProvider> _vacancyProvider = new Mock<IVacancyQAProvider>();

        private readonly VacancySummaryViewModelServerValidator _vacancySummaryViewModelServerValidator =
            new VacancySummaryViewModelServerValidator();
        private VacancyRequirementsProspectsViewModelServerValidator _vacancyRequirementsProspectsViewModelServerValidator = new VacancyRequirementsProspectsViewModelServerValidator();

        private readonly VacancyViewModelValidator _vacancyViewModelValidator = new VacancyViewModelValidator();
        private readonly VacancyQuestionsViewModelServerValidator _vacancyQuestionsViewModelServerValidator = new VacancyQuestionsViewModelServerValidator();

        public IVacancyMediator Build()
        {
            return new VacancyMediator(_vacancyProvider.Object, _vacancyViewModelValidator, _vacancySummaryViewModelServerValidator, 
            _newVacancyViewModelServerValidator, _vacancyQuestionsViewModelServerValidator, _vacancyRequirementsProspectsViewModelServerValidator);
        }

        public VacancyMediatorBuilder With(Mock<IVacancyQAProvider> provider)
        {
            _vacancyProvider = provider;
            return this;
        }
    }
}