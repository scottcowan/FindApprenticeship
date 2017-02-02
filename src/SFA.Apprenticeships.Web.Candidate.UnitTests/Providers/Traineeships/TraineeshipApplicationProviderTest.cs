namespace SFA.Apprenticeships.Web.Candidate.UnitTests.Providers.Traineeships
{
    using System;
    using System.Threading.Tasks;
    using Application.Interfaces.Candidates;
    using Candidate.Providers;
    using Candidate.ViewModels.VacancySearch;
    using Common.Models.Application;
    using Constants.Pages;
    using Domain.Entities.Applications;
    using Domain.Entities.Exceptions;
    using Domain.Entities.Vacancies;
    using FluentAssertions;
    using Moq;
    using NUnit.Framework;
    using ErrorCodes = Application.Interfaces.Applications.ErrorCodes;

    [TestFixture]
    [Parallelizable]
    public class TraineeshipApplicationProviderTest
    {
        private const int ValidVacancyId = 1;

        [Test]
        public async Task WhenIGetTheApplicationViewModel_IfIveAlreadyAppliedForTheApprenticeship_IGetAViewModelWithError()
        {
            var candidateService = new Mock<ICandidateService>();
            candidateService.Setup(cs => cs.GetTraineeshipApplication(It.IsAny<Guid>(), It.IsAny<int>())).Returns(new TraineeshipApplicationDetail());
            var traineeshipApplicationProvider = new TraineeshipApplicationProviderBuilder().With(candidateService).Build();

            var traineeshipApplicationViewModel = await traineeshipApplicationProvider.GetApplicationViewModel(Guid.NewGuid(), 1);

            traineeshipApplicationViewModel.HasError().Should().BeTrue();
        }
        [Test]
        public async Task CreateApplicationReturnsNull()
        {
            var candidateId = Guid.NewGuid();
            var candidateService = new Mock<ICandidateService>();
            candidateService.Setup(cs => cs.GetTraineeshipApplication(candidateId, ValidVacancyId)).Returns((TraineeshipApplicationDetail)null);
            candidateService.Setup(cs => cs.CreateTraineeshipApplication(candidateId, ValidVacancyId)).Returns(Task.FromResult((TraineeshipApplicationDetail)null));
            var traineeshipVacancyProvider = new Mock<ITraineeshipVacancyProvider>();
            traineeshipVacancyProvider.Setup(p => p.GetVacancyDetailViewModel(candidateId, ValidVacancyId)).Returns(Task.FromResult((TraineeshipVacancyDetailViewModel)null));
            var traineeshipApplicationProvider = new TraineeshipApplicationProviderBuilder().With(candidateService).With(traineeshipVacancyProvider).Build();
            
            var viewModel = await traineeshipApplicationProvider.GetApplicationViewModel(candidateId, ValidVacancyId);

            viewModel.Should().NotBeNull();
            viewModel.ViewModelMessage.Should().Be(MyApplicationsPageMessages.TraineeshipNoLongerAvailable);
            viewModel.HasError().Should().BeTrue();
        }

        [Test]
        public async Task CreateApplicationReturnsVacancyStatusesUnavailable()
        {
            var candidateId = Guid.NewGuid();
            var candidateService = new Mock<ICandidateService>();
            candidateService.Setup(cs => cs.GetTraineeshipApplication(candidateId, ValidVacancyId)).Returns((TraineeshipApplicationDetail)null);
            candidateService.Setup(cs => cs.CreateTraineeshipApplication(candidateId, ValidVacancyId)).Returns(Task.FromResult(new TraineeshipApplicationDetail { VacancyStatus = VacancyStatuses.Unavailable }));
            var traineeshipVacancyProvider = new Mock<ITraineeshipVacancyProvider>();
            traineeshipVacancyProvider.Setup(p => p.GetVacancyDetailViewModel(candidateId, ValidVacancyId)).Returns(Task.FromResult(new TraineeshipVacancyDetailViewModel { VacancyStatus = VacancyStatuses.Unavailable }));
            var traineeshipApplicationProvider = new TraineeshipApplicationProviderBuilder().With(candidateService).With(traineeshipVacancyProvider).Build();

            var viewModel = await traineeshipApplicationProvider.GetApplicationViewModel(candidateId, ValidVacancyId);

            viewModel.Should().NotBeNull();
            viewModel.ViewModelMessage.Should().Be(MyApplicationsPageMessages.TraineeshipNoLongerAvailable);
            viewModel.HasError().Should().BeTrue();
        }

        [Test]
        public async Task CreateApplicationReturnsVacancyStatusesLive()
        {
            var candidateId = Guid.NewGuid();
            var candidateService = new Mock<ICandidateService>();
            candidateService.Setup(cs => cs.GetTraineeshipApplication(candidateId, ValidVacancyId)).Returns((TraineeshipApplicationDetail)null);
            candidateService.Setup(cs => cs.CreateTraineeshipApplication(candidateId, ValidVacancyId)).Returns(Task.FromResult(new TraineeshipApplicationDetail { VacancyStatus = VacancyStatuses.Live }));
            var traineeshipVacancyProvider = new Mock<ITraineeshipVacancyProvider>();
            traineeshipVacancyProvider.Setup(p => p.GetVacancyDetailViewModel(candidateId, ValidVacancyId)).Returns(Task.FromResult(new TraineeshipVacancyDetailViewModel { VacancyStatus = VacancyStatuses.Live }));
            var traineeshipApplicationProvider = new TraineeshipApplicationProviderBuilder().With(candidateService).With(traineeshipVacancyProvider).Build();

            var viewModel = await traineeshipApplicationProvider.GetApplicationViewModel(candidateId, ValidVacancyId);

            viewModel.Should().NotBeNull();
            viewModel.ViewModelMessage.Should().BeNullOrEmpty();
            viewModel.HasError().Should().BeFalse();
        }

        [Test]
        public async Task CreateApplicationReturnsExpiredOrWithdrawn()
        {
            var candidateId = Guid.NewGuid();
            var candidateService = new Mock<ICandidateService>();
            candidateService.Setup(cs => cs.GetTraineeshipApplication(candidateId, ValidVacancyId)).Returns((TraineeshipApplicationDetail)null);
            candidateService.Setup(cs => cs.CreateTraineeshipApplication(candidateId, ValidVacancyId)).Returns(Task.FromResult(new TraineeshipApplicationDetail { Status = ApplicationStatuses.ExpiredOrWithdrawn }));
            var traineeshipVacancyProvider = new Mock<ITraineeshipVacancyProvider>();
            traineeshipVacancyProvider.Setup(p => p.GetVacancyDetailViewModel(candidateId, ValidVacancyId)).Returns(Task.FromResult((TraineeshipVacancyDetailViewModel)null));
            var traineeshipApplicationProvider = new TraineeshipApplicationProviderBuilder().With(candidateService).With(traineeshipVacancyProvider).Build();

            var viewModel = await traineeshipApplicationProvider.GetApplicationViewModel(candidateId, ValidVacancyId);

            viewModel.Should().NotBeNull();
            viewModel.ViewModelMessage.Should().Be(MyApplicationsPageMessages.TraineeshipNoLongerAvailable);
            viewModel.HasError().Should().BeTrue();
        }

        [Test]
        public async Task UnhandledError()
        {
            var candidateId = Guid.NewGuid();
            var candidateService = new Mock<ICandidateService>();
            candidateService.Setup(cs => cs.GetTraineeshipApplication(candidateId, ValidVacancyId)).Returns((TraineeshipApplicationDetail)null);
            candidateService.Setup(cs => cs.CreateTraineeshipApplication(candidateId, ValidVacancyId)).Throws(new CustomException(ErrorCodes.ApplicationNotFoundError));
            var traineeshipApplicationProvider = new TraineeshipApplicationProviderBuilder().With(candidateService).Build();

            var viewModel = await traineeshipApplicationProvider.GetApplicationViewModel(candidateId, ValidVacancyId);

            viewModel.Should().NotBeNull();
            viewModel.ViewModelStatus.Should().Be(ApplicationViewModelStatus.Error);
            viewModel.ViewModelMessage.Should().Be(MyApplicationsPageMessages.UnhandledError);
            viewModel.HasError().Should().BeTrue();
        }

        [Test]
        public async Task Error()
        {
            var candidateId = Guid.NewGuid();
            var candidateService = new Mock<ICandidateService>();
            candidateService.Setup(cs => cs.GetTraineeshipApplication(candidateId, ValidVacancyId)).Returns((TraineeshipApplicationDetail)null);
            candidateService.Setup(cs => cs.CreateTraineeshipApplication(candidateId, ValidVacancyId)).Throws(new Exception());
            var traineeshipApplicationProvider = new TraineeshipApplicationProviderBuilder().With(candidateService).Build();

            var viewModel = await traineeshipApplicationProvider.GetApplicationViewModel(candidateId, ValidVacancyId);

            viewModel.Should().NotBeNull();
            viewModel.ViewModelStatus.Should().Be(ApplicationViewModelStatus.Error);
            viewModel.ViewModelMessage.Should().Be(MyApplicationsPageMessages.CreateOrRetrieveApplicationFailed);
            viewModel.HasError().Should().BeTrue();
        }

        [Test]
        public async Task PatchWithVacancyDetail_VacancyNotFound()
        {
            var candidateId = Guid.NewGuid();
            var traineeshipVacancyProvider = new Mock<ITraineeshipVacancyProvider>();
            traineeshipVacancyProvider.Setup(p => p.GetVacancyDetailViewModel(candidateId, ValidVacancyId)).Returns(Task.FromResult((TraineeshipVacancyDetailViewModel)null));
            var candidateService = new Mock<ICandidateService>();
            candidateService.Setup(cs => cs.GetTraineeshipApplication(candidateId, ValidVacancyId)).Returns((TraineeshipApplicationDetail)null);
            candidateService.Setup(cs => cs.CreateTraineeshipApplication(candidateId, ValidVacancyId)).Returns(Task.FromResult(new TraineeshipApplicationDetail()));
            var traineeshipApplicationProvider = new TraineeshipApplicationProviderBuilder().With(candidateService).With(traineeshipVacancyProvider).Build();

            var viewModel = await traineeshipApplicationProvider.GetApplicationViewModel(candidateId, ValidVacancyId);

            viewModel.Should().NotBeNull();
            viewModel.ViewModelMessage.Should().Be(MyApplicationsPageMessages.TraineeshipNoLongerAvailable);
            viewModel.HasError().Should().BeTrue();
        }

        [Test]
        public async Task PatchWithVacancyDetail_VacancyStatusUnavailable()
        {
            var candidateId = Guid.NewGuid();
            var traineeshipVacancyProvider = new Mock<ITraineeshipVacancyProvider>();
            traineeshipVacancyProvider.Setup(p => p.GetVacancyDetailViewModel(candidateId, ValidVacancyId)).Returns(Task.FromResult(new TraineeshipVacancyDetailViewModel { VacancyStatus = VacancyStatuses.Unavailable }));
            var candidateService = new Mock<ICandidateService>();
            candidateService.Setup(cs => cs.GetTraineeshipApplication(candidateId, ValidVacancyId)).Returns((TraineeshipApplicationDetail)null);
            candidateService.Setup(cs => cs.CreateTraineeshipApplication(candidateId, ValidVacancyId)).Returns(Task.FromResult(new TraineeshipApplicationDetail()));
            var traineeshipApplicationProvider = new TraineeshipApplicationProviderBuilder().With(candidateService).With(traineeshipVacancyProvider).Build();

            var viewModel = await traineeshipApplicationProvider.GetApplicationViewModel(candidateId, ValidVacancyId);

            viewModel.Should().NotBeNull();
            viewModel.ViewModelMessage.Should().Be(MyApplicationsPageMessages.TraineeshipNoLongerAvailable);
            viewModel.HasError().Should().BeTrue();
        }

        [Test]
        public async Task PatchWithVacancyDetail_VacancyHasError()
        {
            var candidateId = Guid.NewGuid();
            var traineeshipVacancyProvider = new Mock<ITraineeshipVacancyProvider>();
            traineeshipVacancyProvider.Setup(p => p.GetVacancyDetailViewModel(candidateId, ValidVacancyId)).Returns(Task.FromResult(new TraineeshipVacancyDetailViewModel(ApprenticeshipVacancyDetailPageMessages.GetVacancyDetailFailed)));
            var candidateService = new Mock<ICandidateService>();
            candidateService.Setup(cs => cs.GetTraineeshipApplication(candidateId, ValidVacancyId)).Returns((TraineeshipApplicationDetail)null);
            candidateService.Setup(cs => cs.CreateTraineeshipApplication(candidateId, ValidVacancyId)).Returns(Task.FromResult(new TraineeshipApplicationDetail()));
            var traineeshipApplicationProvider = new TraineeshipApplicationProviderBuilder().With(candidateService).With(traineeshipVacancyProvider).Build();

            var viewModel = await traineeshipApplicationProvider.GetApplicationViewModel(candidateId, ValidVacancyId);

            viewModel.Should().NotBeNull();
            viewModel.ViewModelMessage.Should().Be(ApprenticeshipVacancyDetailPageMessages.GetVacancyDetailFailed);
            viewModel.HasError().Should().BeTrue();
        }

        [Test]
        public async Task Ok()
        {
            var candidateId = Guid.NewGuid();
            var traineeshipVacancyProvider = new Mock<ITraineeshipVacancyProvider>();
            traineeshipVacancyProvider.Setup(p => p.GetVacancyDetailViewModel(candidateId, ValidVacancyId)).Returns(Task.FromResult(new TraineeshipVacancyDetailViewModel()));
            var candidateService = new Mock<ICandidateService>();
            candidateService.Setup(cs => cs.GetTraineeshipApplication(candidateId, ValidVacancyId)).Returns((TraineeshipApplicationDetail)null);
            candidateService.Setup(cs => cs.CreateTraineeshipApplication(candidateId, ValidVacancyId)).Returns(Task.FromResult(new TraineeshipApplicationDetail()));
            var traineeshipApplicationProvider = new TraineeshipApplicationProviderBuilder().With(candidateService).With(traineeshipVacancyProvider).Build();

            var viewModel = await traineeshipApplicationProvider.GetApplicationViewModel(candidateId, ValidVacancyId);

            viewModel.Should().NotBeNull();
            viewModel.ViewModelMessage.Should().BeNullOrEmpty();
            viewModel.HasError().Should().BeFalse();
        }
    }
}