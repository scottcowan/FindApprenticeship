﻿namespace SFA.Apprenticeships.Web.Manage.UnitTests.Mediators.Vacancy
{
    using Manage.Mediators.Vacancy;
    using Moq;
    using Raa.Common.Providers;
    using Raa.Common.Validators.Provider;
    using Raa.Common.Validators.Vacancy;
    using Raa.Common.Validators.VacancyPosting;

    public class VacancyMediatorBuilder
    {
        private readonly NewVacancyViewModelServerValidator _newVacancyViewModelServerValidator = new NewVacancyViewModelServerValidator();

        private Mock<IVacancyQAProvider> _vacancyProvider = new Mock<IVacancyQAProvider>();

        private readonly VacancySummaryViewModelServerValidator _vacancySummaryViewModelServerValidator = new VacancySummaryViewModelServerValidator();
        private readonly VacancyRequirementsProspectsViewModelServerValidator _vacancyRequirementsProspectsViewModelServerValidator = new VacancyRequirementsProspectsViewModelServerValidator();

        private Mock<VacancyViewModelValidator> _vacancyViewModelValidator = new Mock<VacancyViewModelValidator>();
        private readonly VacancyQuestionsViewModelServerValidator _vacancyQuestionsViewModelServerValidator = new VacancyQuestionsViewModelServerValidator();
        private readonly Mock<IProviderQAProvider> _providerQaProvider = new Mock<IProviderQAProvider>();
        private readonly LocationSearchViewModelServerValidator _locationSearchViewModelServerValidator = new LocationSearchViewModelServerValidator();
        private readonly Mock<ILocationsProvider> _locationsProvider = new Mock<ILocationsProvider>();
        private readonly VacancyOwnerRelationshipViewModelValidator _vacancyOwnerRelationshipViewModelValidator = new VacancyOwnerRelationshipViewModelValidator();

        private readonly TrainingDetailsViewModelServerValidator _trainingDetailsViewModelServerValidator = new TrainingDetailsViewModelServerValidator();

        public IVacancyMediator Build()
        {   
            return new VacancyMediator(_vacancyProvider.Object, _vacancyViewModelValidator.Object,
                _vacancySummaryViewModelServerValidator,
                _newVacancyViewModelServerValidator, _vacancyQuestionsViewModelServerValidator,
                _vacancyRequirementsProspectsViewModelServerValidator, _vacancyOwnerRelationshipViewModelValidator,
                _providerQaProvider.Object, _locationSearchViewModelServerValidator, _locationsProvider.Object, _trainingDetailsViewModelServerValidator);
        }

        public VacancyMediatorBuilder With(Mock<IVacancyQAProvider> provider)
        {
            _vacancyProvider = provider;
            return this;
        }

        public VacancyMediatorBuilder With(Mock<VacancyViewModelValidator> validator)
        {
            _vacancyViewModelValidator = validator;
            return this;
        }
    }
}