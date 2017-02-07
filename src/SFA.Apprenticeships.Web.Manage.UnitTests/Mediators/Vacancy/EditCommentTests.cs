namespace SFA.Apprenticeships.Web.Manage.UnitTests.Mediators.Vacancy
{
    using System;
    using System.Threading.Tasks;
    using Common.UnitTests.Mediators;
    using Common.ViewModels;
    using Domain.Entities.Raa.Vacancies;
    using Domain.Entities.Vacancies;
    using Manage.Mediators.Vacancy;
    using Moq;
    using NUnit.Framework;
    using Raa.Common.Providers;
    using Raa.Common.ViewModels.Vacancy;

    [TestFixture]
    [Parallelizable]
    public class EditCommentTests
    {
        [Test]
        public async Task GetVacancySummaryViewModelShouldgetViewModelFromProvider()
        {
            const int vacancyReferenceNumber = 1;
            var vacancyProvider = new Mock<IVacancyQAProvider>();
            vacancyProvider.Setup(vp => vp.GetVacancySummaryViewModel(vacancyReferenceNumber)).Returns(Task.FromResult(new FurtherVacancyDetailsViewModel
            {
                VacancyDatesViewModel = new VacancyDatesViewModel
                {
                    ClosingDate = new DateViewModel(DateTime.UtcNow),
                    PossibleStartDate = new DateViewModel(DateTime.UtcNow)
                },
                Wage = new WageViewModel() { Type = WageType.ApprenticeshipMinimum, Classification = WageClassification.ApprenticeshipMinimum, Amount = null, AmountLowerBound = null, AmountUpperBound = null, Text = null, Unit = WageUnit.NotApplicable, HoursPerWeek = null }
            }));

            var mediator = new VacancyMediatorBuilder().With(vacancyProvider).Build();

            await mediator.GetVacancySummaryViewModel(vacancyReferenceNumber);

            vacancyProvider.Verify(vp => vp.GetVacancySummaryViewModel(vacancyReferenceNumber));
        }

        [Test]
        public async Task GetVacancySummaryViewModelShoudReturnValidationFailedIfValidationFailed()
        {
            const int vacancyReferenceNumber = 1;
            var vacancyPostingProvider = new Mock<IVacancyQAProvider>();
            vacancyPostingProvider.Setup(vp => vp.GetVacancySummaryViewModel(vacancyReferenceNumber)).Returns(Task.FromResult(new FurtherVacancyDetailsViewModel
            {
                VacancyDatesViewModel = new VacancyDatesViewModel
                {
                    ClosingDate = new DateViewModel(DateTime.UtcNow),
                    PossibleStartDate = new DateViewModel(DateTime.UtcNow)
                },
                Wage = new WageViewModel() { Type = WageType.ApprenticeshipMinimum, Classification = WageClassification.ApprenticeshipMinimum, Amount = null, AmountLowerBound = null, AmountUpperBound = null, Text = null, Unit = WageUnit.NotApplicable, HoursPerWeek = null }
            }));

            var mediator = new VacancyMediatorBuilder().With(vacancyPostingProvider).Build();

            var response = await mediator.GetVacancySummaryViewModel(vacancyReferenceNumber);

            response.AssertValidationResult(VacancyMediatorCodes.GetVacancySummaryViewModel.FailedValidation);
        }

        [Test]
        public async Task GetVacancySummaryViewModelShoudReturnOkIfValidationPassed()
        {
            const int vacancyReferenceNumber = 1;
            var vacancyProvider = new Mock<IVacancyQAProvider>();
            vacancyProvider.Setup(vp => vp.GetVacancySummaryViewModel(vacancyReferenceNumber)).Returns(Task.FromResult(GetValidVacancySummaryViewModel(vacancyReferenceNumber)));

            var mediator = new VacancyMediatorBuilder().With(vacancyProvider).Build();

            var response = await mediator.GetVacancySummaryViewModel(vacancyReferenceNumber);

            response.AssertCodeAndMessage(VacancyMediatorCodes.GetVacancySummaryViewModel.Ok);
        }


        [Test]
        public async Task UpdateVacancyWillNotUpdateVacancyIfViewModelIsNotValid()
        {
            var vacancyProvider = new Mock<IVacancyQAProvider>();

            var mediator = new VacancyMediatorBuilder().With(vacancyProvider).Build();
            var viewModel = new FurtherVacancyDetailsViewModel
            {
                VacancyDatesViewModel = new VacancyDatesViewModel
                {
                    ClosingDate = new DateViewModel(DateTime.UtcNow),
                    PossibleStartDate = new DateViewModel(DateTime.UtcNow)
                },
                Wage = new WageViewModel() { Type = WageType.ApprenticeshipMinimum, Classification = WageClassification.ApprenticeshipMinimum, Amount = null, AmountLowerBound = null, AmountUpperBound = null, Text = null, Unit = WageUnit.NotApplicable, HoursPerWeek = null }
            };

            var result = await mediator.UpdateVacancy(viewModel);

            result.AssertValidationResult(VacancyMediatorCodes.UpdateVacancy.FailedValidation);
            vacancyProvider.Verify(vp => vp.UpdateVacancyWithComments(viewModel), Times.Never);
        }

        [Test]
        public async Task UpdateVacancyWithAVacancyThatAcceptsWarningsWithWarningsShouldUpdateVacancy()
        {
            var vacancyProvider = new Mock<IVacancyQAProvider>();

            var mediator = new VacancyMediatorBuilder().With(vacancyProvider).Build();
            var viewModel = GetValidVacancySummaryViewModel(1);
            viewModel.VacancyDatesViewModel.ClosingDate = new DateViewModel(DateTime.UtcNow.AddDays(10));
            viewModel.AcceptWarnings = true;

            vacancyProvider.Setup(vp => vp.UpdateVacancyWithComments(viewModel))
                .Returns(Task.FromResult(new QAActionResult<FurtherVacancyDetailsViewModel>(QAActionResultCode.Ok,
                    new FurtherVacancyDetailsViewModel())));

            var result = await mediator.UpdateVacancy(viewModel);

            result.AssertCodeAndMessage(VacancyMediatorCodes.UpdateVacancy.Ok);
            vacancyProvider.Verify(vp => vp.UpdateVacancyWithComments(viewModel));
        }

        [Test]
        public async Task UpdateVacancyWithAVacancyThatDontAcceptsWarningsWithWarningsShouldNotUpdateVacancy()
        {
            var vacancyProvider = new Mock<IVacancyQAProvider>();

            var mediator = new VacancyMediatorBuilder().With(vacancyProvider).Build();
            var viewModel = GetValidVacancySummaryViewModel(1);
            viewModel.VacancyDatesViewModel.ClosingDate = new DateViewModel(DateTime.UtcNow.AddDays(10));
            viewModel.AcceptWarnings = false;

            var result = await mediator.UpdateVacancy(viewModel);

            result.AssertValidationResult(VacancyMediatorCodes.UpdateVacancy.FailedValidation);
            vacancyProvider.Verify(vp => vp.UpdateVacancyWithComments(viewModel), Times.Never);
        }

        [Test]
        public async Task GetVacancyQuestionsViewModelShouldGetViewmodelFromProvider()
        {
            const int vacancyReferenceNumber = 1;
            var vacancyProvider = new Mock<IVacancyQAProvider>();
            var mediator = new VacancyMediatorBuilder().With(vacancyProvider).Build();
            var viewModel = new VacancyQuestionsViewModel();
            vacancyProvider.Setup(vp => vp.GetVacancyQuestionsViewModel(vacancyReferenceNumber)).Returns(Task.FromResult(viewModel));

            var result = await mediator.GetVacancyQuestionsViewModel(vacancyReferenceNumber);

            result.AssertCodeAndMessage(VacancyMediatorCodes.GetVacancyQuestionsViewModel.Ok);
            vacancyProvider.Verify(vp => vp.GetVacancyQuestionsViewModel(vacancyReferenceNumber));
        }

        private static FurtherVacancyDetailsViewModel GetValidVacancySummaryViewModel(int vacancyReferenceNumber)
        {
            return new FurtherVacancyDetailsViewModel
            {
                VacancyReferenceNumber = vacancyReferenceNumber,
                VacancyDatesViewModel = new VacancyDatesViewModel
                {
                    ClosingDate = new DateViewModel(DateTime.UtcNow.AddDays(20)),
                    PossibleStartDate = new DateViewModel(DateTime.UtcNow.AddDays(30))
                },
                Duration = 3,
                DurationType = DurationType.Years,
                LongDescription = "A description",
                Wage = new WageViewModel() { Type = WageType.ApprenticeshipMinimum, Classification = WageClassification.ApprenticeshipMinimum, Amount = null, AmountLowerBound = null, AmountUpperBound = null, Text = null, Unit = WageUnit.NotApplicable, HoursPerWeek = 30 },
                WorkingWeek = "A working week"
            };
        }
    }
}