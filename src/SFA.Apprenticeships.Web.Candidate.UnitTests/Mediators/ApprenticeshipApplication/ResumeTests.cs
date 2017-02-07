namespace SFA.Apprenticeships.Web.Candidate.UnitTests.Mediators.ApprenticeshipApplication
{
    using System;
    using System.Threading.Tasks;
    using Builders;
    using Candidate.Mediators.Application;
    using Candidate.ViewModels.Applications;
    using Candidate.ViewModels.VacancySearch;
    using Common.Constants;
    using Common.UnitTests.Mediators;
    using Constants.Pages;
    using Domain.Entities.Applications;
    using Domain.Entities.Vacancies;
    using Moq;
    using NUnit.Framework;

    [TestFixture]
    [Parallelizable]
    public class ResumeTests : TestsBase
    {
        private const int ValidVacancyId = 1;
        private const int InvalidVacancyId = 99999;

        [Test]
        public async Task ApplicationExpired()
        {
            ApprenticeshipApplicationProvider.Setup(p => p.GetApplicationViewModel(It.IsAny<Guid>(), ValidVacancyId))
                .Returns(Task.FromResult(new ApprenticeshipApplicationViewModel
                {
                    Status = ApplicationStatuses.ExpiredOrWithdrawn
                }));

            var response = await Mediator.Resume(Guid.NewGuid(), ValidVacancyId);

            response.AssertMessage(ApprenticeshipApplicationMediatorCodes.Resume.HasError,
                MyApplicationsPageMessages.ApprenticeshipNoLongerAvailable, UserMessageLevel.Warning, false);
        }

        [Test]
        public async Task HasError()
        {
            ApprenticeshipApplicationProvider.Setup(p => p.GetApplicationViewModel(It.IsAny<Guid>(), InvalidVacancyId))
                .Returns(Task.FromResult(new ApprenticeshipApplicationViewModel("Vacancy not found")));

            var response = await Mediator.Resume(Guid.NewGuid(), InvalidVacancyId);

            response.AssertMessage(ApprenticeshipApplicationMediatorCodes.Resume.HasError, "Vacancy not found",
                UserMessageLevel.Warning, false);
        }

        [Test]
        public async Task IncorrectState()
        {
            ApprenticeshipApplicationProvider.Setup(p => p.GetApplicationViewModel(It.IsAny<Guid>(), ValidVacancyId))
                .Returns(Task.FromResult(new ApprenticeshipApplicationViewModelBuilder().WithStatus(ApplicationStatuses.Submitted).Build()));

            var response = await Mediator.Resume(Guid.NewGuid(), ValidVacancyId);

            response.AssertMessage(ApprenticeshipApplicationMediatorCodes.Resume.IncorrectState,
                MyApplicationsPageMessages.ApplicationInIncorrectState, UserMessageLevel.Info, false);
        }

        [Test]
        public async Task Ok()
        {
            ApprenticeshipApplicationProvider.Setup(p => p.GetApplicationViewModel(It.IsAny<Guid>(), ValidVacancyId))
                .Returns(Task.FromResult(new ApprenticeshipApplicationViewModelBuilder().WithVacancyStatus(VacancyStatuses.Live).Build()));

            var response = await Mediator.Resume(Guid.NewGuid(), ValidVacancyId);

            response.AssertCode(ApprenticeshipApplicationMediatorCodes.Resume.Ok, false, true);
        }

        [Test]
        public async Task VacancyExpired()
        {
            ApprenticeshipApplicationProvider.Setup(p => p.GetApplicationViewModel(It.IsAny<Guid>(), ValidVacancyId))
                .Returns(Task.FromResult(new ApprenticeshipApplicationViewModel
                {
                    VacancyDetail = new ApprenticeshipVacancyDetailViewModel
                    {
                        VacancyStatus = VacancyStatuses.Expired
                    }
                }));

            var response = await Mediator.Resume(Guid.NewGuid(), ValidVacancyId);

            response.AssertMessage(ApprenticeshipApplicationMediatorCodes.Resume.HasError,
                MyApplicationsPageMessages.ApprenticeshipNoLongerAvailable, UserMessageLevel.Warning, false);
        }
    }
}