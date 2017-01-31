﻿namespace SFA.Apprenticeships.Web.Manage.UnitTests.Mediators.Vacancy
{
    using System.Linq;
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
    public class ApproveVacancyTests
    {
        [Test]
        public async Task ShouldGetStatusOkIfNoProblem()
        {
            const int vacancyReferenceNumber = 1;
            var provider = new Mock<IVacancyQAProvider>();
            provider.Setup(p => p.GetNextAvailableVacancy()).Returns(new DashboardVacancySummaryViewModel());

            var mediator = new VacancyMediatorBuilder().With(provider).Build();

            var result = await mediator.ApproveVacancy(vacancyReferenceNumber);
            result.Code.Should().Be(VacancyMediatorCodes.ApproveVacancy.Ok);
        }

        [Test]
        public void ShouldUpdateTheStatusOfTheVacancyToLive()
        {
            const int vacancyReferenceNumber = 1;
            var pendingQAVacancies = VacancyMediatorTestHelper.GetPendingVacancies(new[]
            {
                vacancyReferenceNumber
            });
            var provider = new Mock<IVacancyQAProvider>();
            provider.Setup(p => p.GetPendingQAVacancies()).Returns(pendingQAVacancies.ToList());

            var mediator = new VacancyMediatorBuilder().With(provider).Build();

            mediator.ApproveVacancy(vacancyReferenceNumber);

            provider.Verify(p => p.ApproveVacancy(vacancyReferenceNumber), Times.Once);
        }

        [Test]
        public void ShouldGetTheNextVacancyIfVacancyIsApproved()
        {
            const int vacancyReferenceNumber = 1;
            var pendingQAVacancies = VacancyMediatorTestHelper.GetPendingVacancies(new[]
            {
                vacancyReferenceNumber
            });
            var provider = new Mock<IVacancyQAProvider>();
            provider.Setup(p => p.GetPendingQAVacancies()).Returns(pendingQAVacancies.ToList());

            var mediator = new VacancyMediatorBuilder().With(provider).Build();

            mediator.ApproveVacancy(vacancyReferenceNumber);

            provider.Verify(p => p.GetNextAvailableVacancy(), Times.Once);
        }

        [Test]
        public async Task ShouldReturnTheNextAvailableVacancyAfterApprovingOne()
        {
            const int vacancyReferenceNumber = 1;
            const int nextVacancyReferenceNumber = 2;

            var provider = new Mock<IVacancyQAProvider>();

            provider.Setup(p => p.GetNextAvailableVacancy())
                .Returns(new DashboardVacancySummaryViewModel {VacancyReferenceNumber = nextVacancyReferenceNumber});

            var mediator = new VacancyMediatorBuilder().With(provider).Build();

            var result = await mediator.ApproveVacancy(vacancyReferenceNumber);
            result.AssertCodeAndMessage(VacancyMediatorCodes.ApproveVacancy.Ok);
            result.ViewModel.VacancyReferenceNumber.Should().Be(nextVacancyReferenceNumber);
        }

        [Test]
        public async Task ShouldReturnNoAvailableVacanciesIfThereArentAnyAvailableVacancies()
        {
            const int vacancyReferenceNumber = 1;
            DashboardVacancySummaryViewModel nullVacancy = null;

            var provider = new Mock<IVacancyQAProvider>();

            provider.Setup(p => p.GetNextAvailableVacancy()).Returns(nullVacancy);

            var mediator = new VacancyMediatorBuilder().With(provider).Build();

            var result = await mediator.ApproveVacancy(vacancyReferenceNumber);
            result.AssertMessage(VacancyMediatorCodes.ApproveVacancy.NoAvailableVacancies, VacancyViewModelMessages.NoVacanciesAvailble, UserMessageLevel.Info);
        }

        [Test]
        public async Task ShouldReturnInvalidVacancyIfTheVacancyIsNotAvailableToQA()
        {
            const int vacancyReferenceNumber = 1;
            var provider = new Mock<IVacancyQAProvider>();

            provider.Setup(p => p.ApproveVacancy(vacancyReferenceNumber)).Returns(Task.FromResult(QAActionResultCode.InvalidVacancy));

            var mediator = new VacancyMediatorBuilder().With(provider).Build();

            var result = await mediator.ApproveVacancy(vacancyReferenceNumber);
            result.AssertMessage(VacancyMediatorCodes.ApproveVacancy.InvalidVacancy, VacancyViewModelMessages.InvalidVacancy, UserMessageLevel.Error);
        }

        [Test]
        public async Task ShouldReturnPostcodeLookupFailedIfTheVacancyIsThereWasAnErrorGeocodingTheVacancy()
        {
            const int vacancyReferenceNumber = 1;
            var provider = new Mock<IVacancyQAProvider>();

            provider.Setup(p => p.ApproveVacancy(vacancyReferenceNumber)).Returns(Task.FromResult(QAActionResultCode.GeocodingFailure));

            var mediator = new VacancyMediatorBuilder().With(provider).Build();

            var result = await mediator.ApproveVacancy(vacancyReferenceNumber);
            result.AssertMessage(VacancyMediatorCodes.ApproveVacancy.PostcodeLookupFailed, VacancyViewModelMessages.PostcodeLookupFailed, UserMessageLevel.Error);
        }
    }
}