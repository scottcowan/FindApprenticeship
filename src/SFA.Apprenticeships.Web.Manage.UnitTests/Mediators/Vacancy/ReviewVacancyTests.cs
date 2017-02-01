namespace SFA.Apprenticeships.Web.Manage.UnitTests.Mediators.Vacancy
{
    using System.Threading.Tasks;
    using Common.Constants;
    using Common.UnitTests.Mediators;
    using Constants.ViewModels;
    using Domain.Entities.Raa.Vacancies;
    using FluentAssertions;
    using FluentValidation.Results;
    using Manage.Mediators.Vacancy;
    using Moq;
    using NUnit.Framework;
    using Raa.Common.Providers;
    using Raa.Common.Validators.Vacancy;
    using Raa.Common.ViewModels.Vacancy;

    [TestFixture]
    [Parallelizable]
    public class ReviewVacancyTests
    {
        [Test]
        public async Task ShouldReturnTheViewModelIfAllIsOk()
        {
            const int vacancyReferenceNumber = 1;
            var viewModel = VacancyMediatorTestHelper.GetValidVacancyViewModel(vacancyReferenceNumber);

            var provider = new Mock<IVacancyQAProvider>();

            provider.Setup(p => p.ReviewVacancy(vacancyReferenceNumber)).Returns(Task.FromResult(viewModel));

            var validator = new Mock<VacancyViewModelValidator>();
            validator.Setup(v => v.Validate(It.IsAny<VacancyViewModel>()))
                .Returns(new ValidationResult());

            var mediator = new VacancyMediatorBuilder().With(validator).With(provider).Build();

            var result = await mediator.ReviewVacancy(vacancyReferenceNumber);

            result.AssertCodeAndMessage(VacancyMediatorCodes.ReviewVacancy.Ok);
            result.ViewModel.VacancyReferenceNumber.Should().Be(vacancyReferenceNumber);
        }

        [Test]
        public void ShouldCallTheVacancyValidator()
        {
            const int vacancyReferenceNumber = 1;
            var viewModel = VacancyMediatorTestHelper.GetValidVacancyViewModel(vacancyReferenceNumber);

            var provider = new Mock<IVacancyQAProvider>();
            provider.Setup(p => p.ReviewVacancy(vacancyReferenceNumber)).Returns(Task.FromResult(viewModel));

            var validator = new Mock<VacancyViewModelValidator>();
            validator.Setup(v => v.Validate(It.IsAny<VacancyViewModel>()))
                .Returns(new ValidationResult());

            var mediator = new VacancyMediatorBuilder().With(validator).With(provider).Build();

            mediator.ReviewVacancy(vacancyReferenceNumber);

            validator.Verify(v => v.Validate(It.IsAny<VacancyViewModel>()), Times.Once);
        }

        [Test]
        public async Task ShouldReturnAResponseWithValidationErrorsIfThereAreValidationErrors()
        {
            const int vacancyReferenceNumber = 1;
            var viewModel = VacancyMediatorTestHelper.GetValidVacancyViewModel(vacancyReferenceNumber);
            viewModel.NewVacancyViewModel.Title = null;

            var provider = new Mock<IVacancyQAProvider>();
            provider.Setup(p => p.ReviewVacancy(vacancyReferenceNumber)).Returns(Task.FromResult(viewModel));

            var validator = new Mock<VacancyViewModelValidator>();
            var validationFailure = new ValidationFailure("NewVacancyViewModel.Title", "someError");
            validator.Setup(v => v.Validate(It.IsAny<VacancyViewModel>()))
                .Returns(new ValidationResult(new[] {validationFailure}));

            var mediator = new VacancyMediatorBuilder().With(validator).With(provider).Build();

            var result = await mediator.ReviewVacancy(vacancyReferenceNumber);

            result.AssertValidationResult(VacancyMediatorCodes.ReviewVacancy.FailedValidation, true);
            result.ViewModel.VacancyReferenceNumber.Should().Be(vacancyReferenceNumber);
        }

        [Test]
        public async Task ShouldReturnAMessageIfTheVacancyReturnedIsNull()
        {
            const int vacancyReferenceNumber = 1;
            VacancyViewModel viewModel = null;

            var provider = new Mock<IVacancyQAProvider>();

            provider.Setup(p => p.ReviewVacancy(vacancyReferenceNumber)).Returns(Task.FromResult(viewModel));

            var mediator = new VacancyMediatorBuilder().With(provider).Build();

            var result = await mediator.ReviewVacancy(vacancyReferenceNumber);

            result.AssertMessage(VacancyMediatorCodes.ReviewVacancy.InvalidVacancy,
                VacancyViewModelMessages.InvalidVacancy, UserMessageLevel.Error);
        }

        [TestCase(VacancySource.Av, VacancyMediatorCodes.ReviewVacancy.VacancyAuthoredInAvms, VacancyViewModelMessages.VacancyAuthoredInAvms)]
        [TestCase(VacancySource.Api, VacancyMediatorCodes.ReviewVacancy.VacancyAuthoredInApi, VacancyViewModelMessages.VacancyAuthoredInApi)]
        public async Task ShouldReturnTheViewModelAndAMessageIfTheVacancySourceIsNotRaa(VacancySource vacancySource, string code, string message)
        {
            const int vacancyReferenceNumber = 1;
            var viewModel = VacancyMediatorTestHelper.GetValidVacancyViewModel(vacancyReferenceNumber, vacancySource);

            var provider = new Mock<IVacancyQAProvider>();

            provider.Setup(p => p.ReviewVacancy(vacancyReferenceNumber)).Returns(Task.FromResult(viewModel));

            var validator = new Mock<VacancyViewModelValidator>();
            validator.Setup(v => v.Validate(It.IsAny<VacancyViewModel>()))
                .Returns(new ValidationResult());

            var mediator = new VacancyMediatorBuilder().With(validator).With(provider).Build();

            var result = await mediator.ReviewVacancy(vacancyReferenceNumber);

            result.ViewModel.VacancyReferenceNumber.Should().Be(vacancyReferenceNumber);
            result.AssertMessage(code, 
                message,
                UserMessageLevel.Info);
        }

        [TestCase(VacancySource.Av, VacancyMediatorCodes.ReviewVacancy.VacancyAuthoredInAvmsWithValidationErrors, VacancyViewModelMessages.VacancyAuthoredInAvms)]
        [TestCase(VacancySource.Api, VacancyMediatorCodes.ReviewVacancy.VacancyAuthoredInApiWithValidationErrors, VacancyViewModelMessages.VacancyAuthoredInApi)]
        public async Task ShouldReturnTheViewModelAndAMessageIfTheVacancySourceIsNotRaaAndHasValidationErrors(VacancySource vacancySource, string code, string message)
        {
            const int vacancyReferenceNumber = 1;
            var viewModel = VacancyMediatorTestHelper.GetValidVacancyViewModel(vacancyReferenceNumber, vacancySource);

            var provider = new Mock<IVacancyQAProvider>();

            provider.Setup(p => p.ReviewVacancy(vacancyReferenceNumber)).Returns(Task.FromResult(viewModel));

            var validator = new Mock<VacancyViewModelValidator>();
            var validationFailure = new ValidationFailure("NewVacancyViewModel.Title", "someError");
            validator.Setup(v => v.Validate(It.IsAny<VacancyViewModel>()))
                .Returns(new ValidationResult(new[] { validationFailure }));

            var mediator = new VacancyMediatorBuilder().With(validator).With(provider).Build();

            var result = await mediator.ReviewVacancy(vacancyReferenceNumber);

            result.ViewModel.VacancyReferenceNumber.Should().Be(vacancyReferenceNumber);
            result.AssertValidationResultWithMessage(code, message, UserMessageLevel.Info, true);
        }
    }
}