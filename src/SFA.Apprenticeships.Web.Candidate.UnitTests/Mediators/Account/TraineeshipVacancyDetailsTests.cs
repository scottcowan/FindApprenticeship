namespace SFA.Apprenticeships.Web.Candidate.UnitTests.Mediators.Account
{
    using System;
    using System.Threading.Tasks;
    using Candidate.Mediators.Account;
    using Candidate.Providers;
    using Candidate.ViewModels.VacancySearch;
    using Common.Constants;
    using Constants.Pages;
    using Domain.Entities.Vacancies;
    using FluentAssertions;
    using Moq;
    using NUnit.Framework;

    [TestFixture]
    [Parallelizable]
    public class TraineeshipVacancyDetailsTests
    {
        [Test]
        public async Task VacancyStatusLiveTest()
        {
            var vacancyDetailViewModel = new TraineeshipVacancyDetailViewModel
            {
                VacancyStatus = VacancyStatuses.Live
            };

            var traineeshipVacancyProvider = new Mock<ITraineeshipVacancyProvider>();
            traineeshipVacancyProvider.Setup(x => x.GetVacancyDetailViewModel(It.IsAny<Guid>(), It.IsAny<int>())).Returns(Task.FromResult(vacancyDetailViewModel));
            var accountMediator = new AccountMediatorBuilder().With(traineeshipVacancyProvider).Build();

            var response = await accountMediator.TraineeshipVacancyDetails(Guid.NewGuid(), 42);

            response.Code.Should().Be(AccountMediatorCodes.VacancyDetails.Available);
            response.Message.Should().BeNull();
        }

        [Test]
        public async Task VacancyStatusExpiredTest()
        {
            var vacancyDetailViewModel = new TraineeshipVacancyDetailViewModel
            {
                VacancyStatus = VacancyStatuses.Expired
            };

            var traineeshipVacancyProvider = new Mock<ITraineeshipVacancyProvider>();
            traineeshipVacancyProvider.Setup(x => x.GetVacancyDetailViewModel(It.IsAny<Guid>(), It.IsAny<int>())).Returns(Task.FromResult(vacancyDetailViewModel));
            var accountMediator = new AccountMediatorBuilder().With(traineeshipVacancyProvider).Build();

            var response = await accountMediator.TraineeshipVacancyDetails(Guid.NewGuid(), 42);

            response.Code.Should().Be(AccountMediatorCodes.VacancyDetails.Available);
            response.Message.Should().BeNull();
        }

        [Test]
        public async Task VacancyStatusUnavailableTest()
        {
            var vacancyDetailViewModel = new TraineeshipVacancyDetailViewModel
            {
                VacancyStatus = VacancyStatuses.Unavailable
            };

            var traineeshipVacancyProvider = new Mock<ITraineeshipVacancyProvider>();
            traineeshipVacancyProvider.Setup(x => x.GetVacancyDetailViewModel(It.IsAny<Guid>(), It.IsAny<int>())).Returns(Task.FromResult(vacancyDetailViewModel));
            var accountMediator = new AccountMediatorBuilder().With(traineeshipVacancyProvider).Build();

            var response = await accountMediator.TraineeshipVacancyDetails(Guid.NewGuid(), 42);

            response.Code.Should().Be(AccountMediatorCodes.VacancyDetails.Unavailable);
            response.Message.Should().NotBeNull();
            response.Message.Text.Should().Be(MyApplicationsPageMessages.ApprenticeshipNoLongerAvailable);
            response.Message.Level.Should().Be(UserMessageLevel.Warning);
        }

        [Test]
        public async Task VacancyNotFoundTest()
        {
            var traineeshipVacancyProvider = new Mock<ITraineeshipVacancyProvider>();
            traineeshipVacancyProvider.Setup(x => x.GetVacancyDetailViewModel(It.IsAny<Guid>(), It.IsAny<int>())).Returns(Task.FromResult(default(TraineeshipVacancyDetailViewModel)));
            var accountMediator = new AccountMediatorBuilder().With(traineeshipVacancyProvider).Build();

            var response = await accountMediator.TraineeshipVacancyDetails(Guid.NewGuid(), 42);

            response.Code.Should().Be(AccountMediatorCodes.VacancyDetails.Unavailable);
            response.Message.Should().NotBeNull();
            response.Message.Text.Should().Be(MyApplicationsPageMessages.ApprenticeshipNoLongerAvailable);
            response.Message.Level.Should().Be(UserMessageLevel.Warning);
        }

        [Test]
        public async Task ErrorTest()
        {
            var vacancyDetailViewModel = new TraineeshipVacancyDetailViewModel
            {
                ViewModelMessage = "Has error"
            };

            var traineeshipVacancyProvider = new Mock<ITraineeshipVacancyProvider>();
            traineeshipVacancyProvider.Setup(x => x.GetVacancyDetailViewModel(It.IsAny<Guid>(), It.IsAny<int>())).Returns(Task.FromResult(vacancyDetailViewModel));
            var accountMediator = new AccountMediatorBuilder().With(traineeshipVacancyProvider).Build();

            var response = await accountMediator.TraineeshipVacancyDetails(Guid.NewGuid(), 42);

            response.Code.Should().Be(AccountMediatorCodes.VacancyDetails.Error);
            response.Message.Should().NotBeNull();
            response.Message.Text.Should().Be(vacancyDetailViewModel.ViewModelMessage);
            response.Message.Level.Should().Be(UserMessageLevel.Error);
        }
    }
}