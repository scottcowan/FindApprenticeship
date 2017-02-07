namespace SFA.Apprenticeships.Web.Candidate.UnitTests.Mediators.ApprenticeshipApplication
{
    using System;
    using System.Threading.Tasks;
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
    public class PreviewTests : TestsBase
    {
        private const int ValidVacancyId = 1;
        private const int InvalidVacancyId = 99999;

        [Test]
        public async Task HasError()
        {
            ApprenticeshipApplicationProvider.Setup(
                p => p.GetApplicationPreviewViewModel(It.IsAny<Guid>(), InvalidVacancyId))
                .Returns(Task.FromResult(new ApprenticeshipApplicationPreviewViewModel("Vacancy not found")));

            var response = await Mediator.Preview(Guid.NewGuid(), InvalidVacancyId);

            response.AssertCode(ApprenticeshipApplicationMediatorCodes.Preview.HasError, false);
        }

        [Test]
        public async Task IncorrectState()
        {
            ApprenticeshipApplicationProvider
                .Setup(p => p.GetApplicationPreviewViewModel(It.IsAny<Guid>(), ValidVacancyId))
                .Returns(Task.FromResult(new ApprenticeshipApplicationPreviewViewModel
                {
                    Status = ApplicationStatuses.Submitted,
                    VacancyDetail = new ApprenticeshipVacancyDetailViewModel
                    {
                        VacancyStatus = VacancyStatuses.Live
                    }
                }));

            var response = await Mediator.Preview(Guid.NewGuid(), ValidVacancyId);

            response.AssertMessage(ApprenticeshipApplicationMediatorCodes.Preview.IncorrectState,
                MyApplicationsPageMessages.ApplicationInIncorrectState, UserMessageLevel.Info, false);
        }

        [Test]
        public async Task OfflineVacancy()
        {
            ApprenticeshipApplicationProvider
                .Setup(p => p.GetApplicationPreviewViewModel(It.IsAny<Guid>(), ValidVacancyId))
                .Returns(Task.FromResult(new ApprenticeshipApplicationPreviewViewModel
                {
                    VacancyDetail = new ApprenticeshipVacancyDetailViewModel
                    {
                        ApplyViaEmployerWebsite = true
                    }
                }));

            var response = await Mediator.Preview(Guid.NewGuid(), ValidVacancyId);

            response.AssertCode(ApprenticeshipApplicationMediatorCodes.Preview.OfflineVacancy, false);
        }

        [Test]
        public async Task Ok()
        {
            ApprenticeshipApplicationProvider
                .Setup(p => p.GetApplicationPreviewViewModel(It.IsAny<Guid>(), ValidVacancyId))
                .Returns(Task.FromResult(new ApprenticeshipApplicationPreviewViewModel
                {
                    Status = ApplicationStatuses.Draft,
                    VacancyDetail = new ApprenticeshipVacancyDetailViewModel
                    {
                        VacancyStatus = VacancyStatuses.Live
                    }
                }));

            var response = await Mediator.Preview(Guid.NewGuid(), ValidVacancyId);

            response.AssertCode(ApprenticeshipApplicationMediatorCodes.Preview.Ok, true);
        }

        [Test]
        public async Task VacancyExpired()
        {
            ApprenticeshipApplicationProvider.Setup(
                p => p.GetApplicationPreviewViewModel(It.IsAny<Guid>(), ValidVacancyId))
                .Returns(Task.FromResult(new ApprenticeshipApplicationPreviewViewModel
                {
                    VacancyDetail = new ApprenticeshipVacancyDetailViewModel
                    {
                        VacancyStatus = VacancyStatuses.Expired
                    }
                }));

            var response = await Mediator.Preview(Guid.NewGuid(), ValidVacancyId);

            response.AssertCode(ApprenticeshipApplicationMediatorCodes.Preview.VacancyNotFound, false);
        }

        [Test]
        public async Task VacancyNotFound()
        {
            ApprenticeshipApplicationProvider
                .Setup(p => p.GetApplicationPreviewViewModel(It.IsAny<Guid>(), InvalidVacancyId))
                .Returns(Task.FromResult(new ApprenticeshipApplicationPreviewViewModel
                {
                    Status = ApplicationStatuses.ExpiredOrWithdrawn,
                    VacancyDetail = new ApprenticeshipVacancyDetailViewModel()
                }));

            var response = await Mediator.Preview(Guid.NewGuid(), InvalidVacancyId);

            response.AssertCode(ApprenticeshipApplicationMediatorCodes.Preview.VacancyNotFound, false);
        }
    }
}