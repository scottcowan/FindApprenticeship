namespace SFA.Apprenticeships.Web.Candidate.UnitTests.Providers.ApplicationProvider
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
    using ErrorCodes = Domain.Entities.ErrorCodes;

    [TestFixture]
    [Parallelizable]
    public class GetOrCreateApplicationViewModelTests
    {
        const int ValidVacancyId = 1;

        [Test]
        public async Task GetShouldCreate()
        {
            var candidateService = new Mock<ICandidateService>();
            await new ApprenticeshipApplicationProviderBuilder().With(candidateService).Build()
                .CreateApplicationViewModel(Guid.NewGuid(), ValidVacancyId);

            candidateService.Verify(cs => cs.CreateApplication(It.IsAny<Guid>(), It.IsAny<int>()), Times.Once);
            candidateService.Verify(cs => cs.GetApplication(It.IsAny<Guid>(), It.IsAny<int>()), Times.Never);
        }

        [Test]
        public async Task CreateApplicationReturnsNull()
        {
            var candidateId = Guid.NewGuid();
            var candidateService = new Mock<ICandidateService>();
            var apprenticeshipVacancyProvider = new Mock<IApprenticeshipVacancyProvider>();

            candidateService.Setup(cs => cs.CreateApplication(candidateId, ValidVacancyId)).Returns(Task.FromResult((ApprenticeshipApplicationDetail) null));
            apprenticeshipVacancyProvider.Setup(p => p.GetVacancyDetailViewModel(candidateId, ValidVacancyId)).Returns(Task.FromResult((ApprenticeshipVacancyDetailViewModel)null));


            var viewModel = await new ApprenticeshipApplicationProviderBuilder()
                .With(candidateService).With(apprenticeshipVacancyProvider).Build()
                .CreateApplicationViewModel(candidateId, ValidVacancyId);

            viewModel.Should().NotBeNull();
            viewModel.Status.Should().Be(ApplicationStatuses.ExpiredOrWithdrawn);
            viewModel.ViewModelMessage.Should().Be(MyApplicationsPageMessages.ApprenticeshipNoLongerAvailable);
            viewModel.HasError().Should().BeTrue();
        }

        [Test]
        public async Task CreateApplicationReturnsVacancyStatusesUnavailable()
        {
            var candidateId = Guid.NewGuid();
            var candidateService = new Mock<ICandidateService>();
            var apprenticeshipVacancyProvider = new Mock<IApprenticeshipVacancyProvider>();
            candidateService.Setup(cs => cs.CreateApplication(candidateId, ValidVacancyId)).Returns(Task.FromResult(new ApprenticeshipApplicationDetail { VacancyStatus = VacancyStatuses.Unavailable }));
            candidateService.Setup(cs => cs.GetApprenticeshipApplications(candidateId, It.IsAny<bool>())).Returns(new ApprenticeshipApplicationSummary[0]);
            apprenticeshipVacancyProvider.Setup(p => p.GetVacancyDetailViewModel(candidateId, ValidVacancyId)).Returns(Task.FromResult(new ApprenticeshipVacancyDetailViewModel { VacancyStatus = VacancyStatuses.Unavailable }));
            
            var viewModel = await new ApprenticeshipApplicationProviderBuilder()
                .With(candidateService).With(apprenticeshipVacancyProvider).Build()
                .CreateApplicationViewModel(candidateId, ValidVacancyId);

            viewModel.Should().NotBeNull();
            viewModel.Status.Should().Be(ApplicationStatuses.ExpiredOrWithdrawn);
            viewModel.ViewModelMessage.Should().Be(MyApplicationsPageMessages.ApprenticeshipNoLongerAvailable);
            viewModel.HasError().Should().BeTrue();
        }

        [Test]
        public async Task CreateApplicationReturnsVacancyStatusesLive()
        {
            var candidateId = Guid.NewGuid();
            var candidateService = new Mock<ICandidateService>();
            var apprenticeshipVacancyProvider = new Mock<IApprenticeshipVacancyProvider>();
            candidateService.Setup(cs => cs.CreateApplication(candidateId, ValidVacancyId)).Returns(Task.FromResult(new ApprenticeshipApplicationDetail { VacancyStatus = VacancyStatuses.Live }));
            candidateService.Setup(cs => cs.GetApprenticeshipApplications(candidateId, It.IsAny<bool>())).Returns(new ApprenticeshipApplicationSummary[0]);
            apprenticeshipVacancyProvider.Setup(p => p.GetVacancyDetailViewModel(candidateId, ValidVacancyId)).Returns(Task.FromResult(new ApprenticeshipVacancyDetailViewModel { VacancyStatus = VacancyStatuses.Live }));
            var viewModel = await new ApprenticeshipApplicationProviderBuilder()
                .With(candidateService).With(apprenticeshipVacancyProvider).Build()
                .CreateApplicationViewModel(candidateId, ValidVacancyId);

            viewModel.Should().NotBeNull();
            viewModel.Status.Should().Be(ApplicationStatuses.Unknown);
            viewModel.ViewModelMessage.Should().BeNullOrEmpty();
            viewModel.HasError().Should().BeFalse();
        }

        [Test]
        public async Task CreateApplicationReturnsExpiredOrWithdrawn()
        {
            var candidateId = Guid.NewGuid();
            var candidateService = new Mock<ICandidateService>();
            var apprenticeshipVacancyProvider = new Mock<IApprenticeshipVacancyProvider>();
            candidateService.Setup(cs => cs.CreateApplication(candidateId, ValidVacancyId)).Returns(Task.FromResult(new ApprenticeshipApplicationDetail {Status = ApplicationStatuses.ExpiredOrWithdrawn}));
            candidateService.Setup(cs => cs.GetApprenticeshipApplications(candidateId, It.IsAny<bool>())).Returns(new ApprenticeshipApplicationSummary[0]);
            apprenticeshipVacancyProvider.Setup(p => p.GetVacancyDetailViewModel(candidateId, ValidVacancyId)).Returns(Task.FromResult((ApprenticeshipVacancyDetailViewModel)null));
            var viewModel = await new ApprenticeshipApplicationProviderBuilder()
                .With(candidateService).With(apprenticeshipVacancyProvider).Build()
                .CreateApplicationViewModel(candidateId, ValidVacancyId);

            viewModel.Should().NotBeNull();
            viewModel.Status.Should().Be(ApplicationStatuses.ExpiredOrWithdrawn);
            viewModel.ViewModelMessage.Should().Be(MyApplicationsPageMessages.ApprenticeshipNoLongerAvailable);
            viewModel.HasError().Should().BeTrue();
        }

        [Test]
        public async Task ApplicationInIncorrectState()
        {
            var candidateId = Guid.NewGuid();
            var candidateService = new Mock<ICandidateService>();
            
            candidateService.Setup(cs => cs.CreateApplication(candidateId, ValidVacancyId)).Throws(new CustomException(ErrorCodes.EntityStateError));
            var viewModel = await new ApprenticeshipApplicationProviderBuilder()
                .With(candidateService).Build()
                .CreateApplicationViewModel(candidateId, ValidVacancyId);

            viewModel.Should().NotBeNull();
            viewModel.ViewModelStatus.Should().Be(ApplicationViewModelStatus.ApplicationInIncorrectState);
            viewModel.ViewModelMessage.Should().Be(MyApplicationsPageMessages.ApplicationInIncorrectState);
            viewModel.HasError().Should().BeTrue();
            viewModel.Status.Should().Be(ApplicationStatuses.Unknown);
        }

        [Test]
        public async Task UnhandledError()
        {
            var candidateId = Guid.NewGuid();
            var candidateService = new Mock<ICandidateService>();
            
            candidateService.Setup(cs => cs.CreateApplication(candidateId, ValidVacancyId)).Throws(new CustomException(Application.Interfaces.Applications.ErrorCodes.ApplicationNotFoundError));
            var viewModel = await new ApprenticeshipApplicationProviderBuilder()
                .With(candidateService).Build()
                .CreateApplicationViewModel(candidateId, ValidVacancyId);

            viewModel.Should().NotBeNull();
            viewModel.ViewModelStatus.Should().Be(ApplicationViewModelStatus.Error);
            viewModel.ViewModelMessage.Should().Be(MyApplicationsPageMessages.UnhandledError);
            viewModel.HasError().Should().BeTrue();
            viewModel.Status.Should().Be(ApplicationStatuses.Unknown);
        }

        [Test]
        public async Task Error()
        {
            var candidateId = Guid.NewGuid();
            var candidateService = new Mock<ICandidateService>();
            
            candidateService.Setup(cs => cs.CreateApplication(candidateId, ValidVacancyId)).Throws(new Exception());
            var viewModel = await new ApprenticeshipApplicationProviderBuilder()
                .With(candidateService).Build()
                .CreateApplicationViewModel(candidateId, ValidVacancyId);

            viewModel.Should().NotBeNull();
            viewModel.ViewModelStatus.Should().Be(ApplicationViewModelStatus.Error);
            viewModel.ViewModelMessage.Should().Be(MyApplicationsPageMessages.CreateOrRetrieveApplicationFailed);
            viewModel.HasError().Should().BeTrue();
            viewModel.Status.Should().Be(ApplicationStatuses.Unknown);
        }

        [Test]
        public async Task PatchWithVacancyDetail_VacancyNotFound()
        {
            var candidateId = Guid.NewGuid();
            var candidateService = new Mock<ICandidateService>();
            var apprenticeshipVacancyProvider = new Mock<IApprenticeshipVacancyProvider>();

            apprenticeshipVacancyProvider.Setup(p => p.GetVacancyDetailViewModel(candidateId, ValidVacancyId)).Returns(Task.FromResult((ApprenticeshipVacancyDetailViewModel)null));
            candidateService.Setup(cs => cs.CreateApplication(candidateId, ValidVacancyId)).Returns(Task.FromResult(new ApprenticeshipApplicationDetail()));
            candidateService.Setup(cs => cs.GetApprenticeshipApplications(candidateId, It.IsAny<bool>())).Returns(new ApprenticeshipApplicationSummary[0]);
            var viewModel = await new ApprenticeshipApplicationProviderBuilder()
                .With(candidateService).With(apprenticeshipVacancyProvider).Build()
                .CreateApplicationViewModel(candidateId, ValidVacancyId);

            viewModel.Should().NotBeNull();
            viewModel.Status.Should().Be(ApplicationStatuses.ExpiredOrWithdrawn);
            viewModel.ViewModelMessage.Should().Be(MyApplicationsPageMessages.ApprenticeshipNoLongerAvailable);
            viewModel.HasError().Should().BeTrue();
        }

        [Test]
        public async Task PatchWithVacancyDetail_VacancyStatusUnavailable()
        {
            var candidateId = Guid.NewGuid();
            var candidateService = new Mock<ICandidateService>();
            var apprenticeshipVacancyProvider = new Mock<IApprenticeshipVacancyProvider>();

            apprenticeshipVacancyProvider.Setup(p => p.GetVacancyDetailViewModel(candidateId, ValidVacancyId)).Returns(Task.FromResult(new ApprenticeshipVacancyDetailViewModel { VacancyStatus = VacancyStatuses.Unavailable }));
            candidateService.Setup(cs => cs.CreateApplication(candidateId, ValidVacancyId)).Returns(Task.FromResult(new ApprenticeshipApplicationDetail()));
            candidateService.Setup(cs => cs.GetApprenticeshipApplications(candidateId, It.IsAny<bool>())).Returns(new ApprenticeshipApplicationSummary[0]);
            var viewModel = await new ApprenticeshipApplicationProviderBuilder()
                .With(candidateService).With(apprenticeshipVacancyProvider).Build()
                .CreateApplicationViewModel(candidateId, ValidVacancyId);

            viewModel.Should().NotBeNull();
            viewModel.Status.Should().Be(ApplicationStatuses.ExpiredOrWithdrawn);
            viewModel.ViewModelMessage.Should().Be(MyApplicationsPageMessages.ApprenticeshipNoLongerAvailable);
            viewModel.HasError().Should().BeTrue();
        }

        [Test]
        public async Task PatchWithVacancyDetail_VacancyHasError()
        {
            var candidateId = Guid.NewGuid();
            var candidateService = new Mock<ICandidateService>();
            var apprenticeshipVacancyProvider = new Mock<IApprenticeshipVacancyProvider>();

            apprenticeshipVacancyProvider.Setup(p => p.GetVacancyDetailViewModel(candidateId, ValidVacancyId)).Returns(Task.FromResult(new ApprenticeshipVacancyDetailViewModel(ApprenticeshipVacancyDetailPageMessages.GetVacancyDetailFailed)));
            candidateService.Setup(cs => cs.CreateApplication(candidateId, ValidVacancyId)).Returns(Task.FromResult(new ApprenticeshipApplicationDetail()));
            candidateService.Setup(cs => cs.GetApprenticeshipApplications(candidateId, It.IsAny<bool>())).Returns(new ApprenticeshipApplicationSummary[0]);
            var viewModel = await new ApprenticeshipApplicationProviderBuilder()
                .With(candidateService).With(apprenticeshipVacancyProvider).Build()
                .CreateApplicationViewModel(candidateId, ValidVacancyId);

            viewModel.Should().NotBeNull();
            viewModel.Status.Should().Be(ApplicationStatuses.Unknown);
            viewModel.ViewModelMessage.Should().Be(ApprenticeshipVacancyDetailPageMessages.GetVacancyDetailFailed);
            viewModel.HasError().Should().BeTrue();
        }

        [Test]
        public async Task Ok()
        {
            var candidateId = Guid.NewGuid();
            var candidateService = new Mock<ICandidateService>();
            var apprenticeshipVacancyProvider = new Mock<IApprenticeshipVacancyProvider>();

            apprenticeshipVacancyProvider.Setup(p => p.GetVacancyDetailViewModel(candidateId, ValidVacancyId)).Returns(Task.FromResult(new ApprenticeshipVacancyDetailViewModel()));
            candidateService.Setup(cs => cs.CreateApplication(candidateId, ValidVacancyId)).Returns(Task.FromResult(new ApprenticeshipApplicationDetail()));
            candidateService.Setup(cs => cs.GetApprenticeshipApplications(candidateId, It.IsAny<bool>())).Returns(new ApprenticeshipApplicationSummary[0]);
            var viewModel = await new ApprenticeshipApplicationProviderBuilder()
                .With(candidateService).With(apprenticeshipVacancyProvider).Build()
                .CreateApplicationViewModel(candidateId, ValidVacancyId);

            viewModel.Should().NotBeNull();
            viewModel.Status.Should().Be(ApplicationStatuses.Unknown);
            viewModel.ViewModelMessage.Should().BeNullOrEmpty();
            viewModel.HasError().Should().BeFalse();
        }
    }
}
