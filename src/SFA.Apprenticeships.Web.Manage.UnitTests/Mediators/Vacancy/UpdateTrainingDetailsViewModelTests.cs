namespace SFA.Apprenticeships.Web.Manage.UnitTests.Mediators.Vacancy
{
    using System.Threading.Tasks;
    using Common.Constants;
    using Common.UnitTests.Mediators;
    using Constants.ViewModels;
    using FluentAssertions;
    using Manage.Mediators.Vacancy;
    using Moq;
    using NUnit.Framework;
    using Raa.Common.Providers;
    using Raa.Common.ViewModels.Vacancy;

    [TestFixture]
    [Parallelizable]
    public class UpdateTrainingDetailsViewModelTests
    {
        [Test]
        public async Task ShouldReturnFailedValidationIfTheViewModelIsNotCorrect()
        {
            const int vacancyReferenceNumber = 1;
            var vacancy = VacancyMediatorTestHelper.GetValidVacancyViewModel(vacancyReferenceNumber);
            vacancy.TrainingDetailsViewModel.ContactName = @"<script> </script>"; // Make the vacancy invalid

            var mediator = new VacancyMediatorBuilder().Build();

            var result = await mediator.UpdateVacancy(vacancy.TrainingDetailsViewModel);
            result.AssertValidationResult(VacancyMediatorCodes.UpdateVacancy.FailedValidation);
        }

        [Test]
        public async Task ShouldReturnInvalidVacancyIfTheVacancyIsNotAvailableToQA()
        {
            const int vacancyReferenceNumber = 1;
            var provider = new Mock<IVacancyQAProvider>();
            var vacancy = VacancyMediatorTestHelper.GetValidVacancyViewModel(vacancyReferenceNumber);
            var qaActionResult = new QAActionResult<TrainingDetailsViewModel>(QAActionResultCode.InvalidVacancy);

            provider.Setup(p => p.UpdateVacancyWithComments(vacancy.TrainingDetailsViewModel)).Returns(Task.FromResult(qaActionResult));

            var mediator = new VacancyMediatorBuilder().With(provider).Build();

            var result = await mediator.UpdateVacancy(vacancy.TrainingDetailsViewModel);
            result.AssertMessage(VacancyMediatorCodes.UpdateVacancy.InvalidVacancy, VacancyViewModelMessages.InvalidVacancy, UserMessageLevel.Error);
        }

        [Test]
        public async Task ShouldReturnOkIsThereIsNotAnyIssue()
        {
            const int vacancyReferenceNumber = 1;
            var provider = new Mock<IVacancyQAProvider>();
            var vacancy = VacancyMediatorTestHelper.GetValidVacancyViewModel(vacancyReferenceNumber);
            var qaActionResult = new QAActionResult<TrainingDetailsViewModel>(QAActionResultCode.Ok, vacancy.TrainingDetailsViewModel);

            provider.Setup(p => p.UpdateVacancyWithComments(vacancy.TrainingDetailsViewModel)).Returns(Task.FromResult(qaActionResult));

            var mediator = new VacancyMediatorBuilder().With(provider).Build();

            var result = await mediator.UpdateVacancy(vacancy.TrainingDetailsViewModel);
            result.AssertCodeAndMessage(VacancyMediatorCodes.UpdateVacancy.Ok);
            result.ViewModel.ShouldBeEquivalentTo(vacancy.TrainingDetailsViewModel);
        }
    }
}