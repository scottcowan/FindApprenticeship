namespace SFA.Apprenticeships.Web.Candidate.UnitTests.Mediators.ApprenticeshipApplication
{
    using System;
    using System.Threading.Tasks;
    using Builders;
    using Candidate.Mediators.Application;
    using Candidate.Providers;
    using Candidate.ViewModels.Applications;
    using Candidate.ViewModels.VacancySearch;
    using Common.Constants;
    using Common.Models.Application;
    using Common.UnitTests.Mediators;
    using Constants.Pages;
    using Domain.Entities.Applications;
    using Domain.Entities.Vacancies;
    using Moq;
    using NUnit.Framework;

    [TestFixture]
    [Parallelizable]
    public class ApplyTests
    {
        private const int ValidVacancyId = 1;
        private const int InvalidVacancyId = 99999;

        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        [TestCase(" 491802")]
        [TestCase("VAC000547307")]
        [TestCase("[[imgUrl]]")]
        [TestCase("separator.png")]
        public async Task GivenInvalidVacancyIdString_ThenVacancyNotFound(string vacancyId)
        {
            var mediator = new ApprenticeshipApplicationMediatorBuilder().Build();
            var response = await mediator.Apply(Guid.NewGuid(), vacancyId);

            response.AssertCode(ApprenticeshipApplicationMediatorCodes.Apply.VacancyNotFound, false);
        }

        [Test]
        public async Task CreateWhenApplicationNotFound()
        {
            var apprenticeshipApplicationProvider = new Mock<IApprenticeshipApplicationProvider>();
            apprenticeshipApplicationProvider.Setup(p => p.GetApplicationViewModel(It.IsAny<Guid>(), ValidVacancyId))
                .Returns(Task.FromResult(
                    new ApprenticeshipApplicationViewModelBuilder().HasError(
                        ApplicationViewModelStatus.ApplicationNotFound, MyApplicationsPageMessages.ApplicationNotFound)
                        .Build()));
            apprenticeshipApplicationProvider.Setup(p => p.CreateApplicationViewModel(It.IsAny<Guid>(), ValidVacancyId))
                .Returns(Task.FromResult(new ApprenticeshipApplicationViewModelBuilder().WithVacancyStatus(VacancyStatuses.Live).Build()));
            var mediator =
                new ApprenticeshipApplicationMediatorBuilder().With(apprenticeshipApplicationProvider).Build();

            var response = await mediator.Apply(Guid.NewGuid(), ValidVacancyId.ToString());

            response.AssertCode(ApprenticeshipApplicationMediatorCodes.Apply.Ok, true);

            apprenticeshipApplicationProvider.Verify(p => p.GetApplicationViewModel(It.IsAny<Guid>(), ValidVacancyId),
                Times.Once);
            apprenticeshipApplicationProvider.Verify(
                p => p.CreateApplicationViewModel(It.IsAny<Guid>(), ValidVacancyId), Times.Once);
        }

        [Test]
        public async Task CreateWhenNull()
        {
            var apprenticeshipApplicationProvider = new Mock<IApprenticeshipApplicationProvider>();
            apprenticeshipApplicationProvider.Setup(p => p.GetApplicationViewModel(It.IsAny<Guid>(), ValidVacancyId))
                .Returns(Task.FromResult((ApprenticeshipApplicationViewModel) null));
            apprenticeshipApplicationProvider.Setup(p => p.CreateApplicationViewModel(It.IsAny<Guid>(), ValidVacancyId))
                .Returns(Task.FromResult(new ApprenticeshipApplicationViewModelBuilder().WithVacancyStatus(VacancyStatuses.Live).Build()));
            var mediator =
                new ApprenticeshipApplicationMediatorBuilder().With(apprenticeshipApplicationProvider).Build();

            var response = await mediator.Apply(Guid.NewGuid(), ValidVacancyId.ToString());

            response.AssertCode(ApprenticeshipApplicationMediatorCodes.Apply.Ok, true);

            apprenticeshipApplicationProvider.Verify(p => p.GetApplicationViewModel(It.IsAny<Guid>(), ValidVacancyId),
                Times.Once);
            apprenticeshipApplicationProvider.Verify(
                p => p.CreateApplicationViewModel(It.IsAny<Guid>(), ValidVacancyId), Times.Once);
        }

        [Test]
        public async Task DoNotCreateWhenFound()
        {
            var apprenticeshipApplicationProvider = new Mock<IApprenticeshipApplicationProvider>();
            apprenticeshipApplicationProvider.Setup(p => p.GetApplicationViewModel(It.IsAny<Guid>(), ValidVacancyId))
                .Returns(Task.FromResult(new ApprenticeshipApplicationViewModelBuilder().WithVacancyStatus(VacancyStatuses.Live).Build()));
            var mediator =
                new ApprenticeshipApplicationMediatorBuilder().With(apprenticeshipApplicationProvider).Build();

            var response = await mediator.Apply(Guid.NewGuid(), ValidVacancyId.ToString());

            response.AssertCode(ApprenticeshipApplicationMediatorCodes.Apply.Ok, true);

            apprenticeshipApplicationProvider.Verify(p => p.GetApplicationViewModel(It.IsAny<Guid>(), ValidVacancyId),
                Times.Once);
            apprenticeshipApplicationProvider.Verify(
                p => p.CreateApplicationViewModel(It.IsAny<Guid>(), ValidVacancyId), Times.Never);
        }

        [Test]
        public async Task HasError()
        {
            var apprenticeshipApplicationProvider = new Mock<IApprenticeshipApplicationProvider>();
            apprenticeshipApplicationProvider.Setup(
                p => p.CreateApplicationViewModel(It.IsAny<Guid>(), InvalidVacancyId))
                .Returns(Task.FromResult(new ApprenticeshipApplicationViewModel("Vacancy has error")));
            var mediator =
                new ApprenticeshipApplicationMediatorBuilder().With(apprenticeshipApplicationProvider).Build();

            var response = await mediator.Apply(Guid.NewGuid(), InvalidVacancyId.ToString());

            response.AssertCode(ApprenticeshipApplicationMediatorCodes.Apply.HasError, false);
        }

        [Test]
        public async Task IncorrectState()
        {
            var apprenticeshipApplicationProvider = new Mock<IApprenticeshipApplicationProvider>();
            apprenticeshipApplicationProvider.Setup(p => p.CreateApplicationViewModel(It.IsAny<Guid>(), ValidVacancyId))
                .Returns(Task.FromResult(
                    new ApprenticeshipApplicationViewModelBuilder().WithStatus(ApplicationStatuses.Submitted).Build()));
            var mediator =
                new ApprenticeshipApplicationMediatorBuilder().With(apprenticeshipApplicationProvider).Build();

            var response = await mediator.Apply(Guid.NewGuid(), ValidVacancyId.ToString());

            response.AssertMessage(ApprenticeshipApplicationMediatorCodes.Apply.IncorrectState,
                MyApplicationsPageMessages.ApplicationInIncorrectState, UserMessageLevel.Info, false);
        }

        [Test]
        public async Task OfflineVacancy()
        {
            var apprenticeshipApplicationProvider = new Mock<IApprenticeshipApplicationProvider>();
            apprenticeshipApplicationProvider.Setup(p => p.CreateApplicationViewModel(It.IsAny<Guid>(), ValidVacancyId))
                .Returns(Task.FromResult(new ApprenticeshipApplicationViewModelBuilder().ApplyViaEmployerWebsite(true).Build()));
            var mediator =
                new ApprenticeshipApplicationMediatorBuilder().With(apprenticeshipApplicationProvider).Build();

            var response = await mediator.Apply(Guid.NewGuid(), ValidVacancyId.ToString());

            response.AssertCode(ApprenticeshipApplicationMediatorCodes.Apply.OfflineVacancy, false);
        }

        [Test]
        public async Task Ok()
        {
            var apprenticeshipApplicationProvider = new Mock<IApprenticeshipApplicationProvider>();
            apprenticeshipApplicationProvider.Setup(p => p.CreateApplicationViewModel(It.IsAny<Guid>(), ValidVacancyId))
                .Returns(Task.FromResult(new ApprenticeshipApplicationViewModelBuilder().WithVacancyStatus(VacancyStatuses.Live).Build()));
            var mediator =
                new ApprenticeshipApplicationMediatorBuilder().With(apprenticeshipApplicationProvider).Build();

            var response = await mediator.Apply(Guid.NewGuid(), ValidVacancyId.ToString());

            response.AssertCode(ApprenticeshipApplicationMediatorCodes.Apply.Ok, true);
        }

        [Test]
        public async Task VacancyExpired()
        {
            var apprenticeshipApplicationProvider = new Mock<IApprenticeshipApplicationProvider>();
            apprenticeshipApplicationProvider.Setup(p => p.CreateApplicationViewModel(It.IsAny<Guid>(), ValidVacancyId))
                .Returns(Task.FromResult(
                    new ApprenticeshipApplicationViewModelBuilder().WithVacancyStatus(VacancyStatuses.Expired).Build()));
            var mediator =
                new ApprenticeshipApplicationMediatorBuilder().With(apprenticeshipApplicationProvider).Build();

            var response = await mediator.Apply(Guid.NewGuid(), ValidVacancyId.ToString());

            response.AssertMessage(ApprenticeshipApplicationMediatorCodes.Apply.VacancyNotFound,
                MyApplicationsPageMessages.ApprenticeshipNoLongerAvailable, UserMessageLevel.Warning, false);
        }

        [Test]
        public async Task VacancyNotFound()
        {
            var apprenticeshipApplicationProvider = new Mock<IApprenticeshipApplicationProvider>();
            apprenticeshipApplicationProvider.Setup(
                p => p.CreateApplicationViewModel(It.IsAny<Guid>(), InvalidVacancyId))
                .Returns(Task.FromResult(new ApprenticeshipApplicationViewModel
                {
                    Status = ApplicationStatuses.ExpiredOrWithdrawn,
                    VacancyDetail = new ApprenticeshipVacancyDetailViewModel()
                }));
            var mediator =
                new ApprenticeshipApplicationMediatorBuilder().With(apprenticeshipApplicationProvider).Build();

            var response = await mediator.Apply(Guid.NewGuid(), InvalidVacancyId.ToString());

            response.AssertMessage(ApprenticeshipApplicationMediatorCodes.Apply.VacancyNotFound,
                MyApplicationsPageMessages.ApprenticeshipNoLongerAvailable, UserMessageLevel.Warning, false);
        }
    }
}