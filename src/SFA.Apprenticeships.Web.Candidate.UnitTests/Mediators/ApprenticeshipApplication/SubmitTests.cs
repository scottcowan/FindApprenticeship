namespace SFA.Apprenticeships.Web.Candidate.UnitTests.Mediators.ApprenticeshipApplication
{
    using System;
    using System.Threading.Tasks;
    using Candidate.Mediators.Application;
    using Candidate.ViewModels.Applications;
    using Candidate.ViewModels.Candidate;
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
    public class SubmitTests : TestsBase
    {
        private const int ValidVacancyId = 1;

        [Test]
        public async Task AcceptSubmitValidationError()
        {
            var postedViewModel = new ApprenticeshipApplicationPreviewViewModel
            {
                AcceptSubmit = false
            };

            var viewModel = new ApprenticeshipApplicationPreviewViewModel
            {
                Candidate = new ApprenticeshipCandidateViewModel(),
                VacancyDetail = new ApprenticeshipVacancyDetailViewModel
                {
                    VacancyStatus = VacancyStatuses.Live
                },
                Status = ApplicationStatuses.Draft
            };

            ApprenticeshipApplicationProvider.Setup(
                p => p.GetApplicationPreviewViewModel(It.IsAny<Guid>(), It.IsAny<int>())).Returns(Task.FromResult(viewModel));
            ApprenticeshipApplicationProvider.Setup(p => p.SubmitApplication(It.IsAny<Guid>(), It.IsAny<int>()))
                .Returns(Task.FromResult<ApprenticeshipApplicationViewModel>(viewModel));

            var response = await Mediator.Submit(Guid.NewGuid(), ValidVacancyId, postedViewModel);

            response.AssertValidationResult(ApprenticeshipApplicationMediatorCodes.Submit.AcceptSubmitValidationError);
        }

        [Test]
        public async Task ErrorGettingApplicationViewModel()
        {
            var postedViewModel = new ApprenticeshipApplicationPreviewViewModel
            {
                AcceptSubmit = true
            };

            var viewModel = new ApprenticeshipApplicationPreviewViewModel
            {
                Candidate = new ApprenticeshipCandidateViewModel(),
                VacancyDetail = new ApprenticeshipVacancyDetailViewModel()
            };

            ApprenticeshipApplicationProvider.Setup(
                p => p.GetApplicationPreviewViewModel(It.IsAny<Guid>(), It.IsAny<int>())).Returns(Task.FromResult(viewModel));
            ApprenticeshipApplicationProvider.Setup(p => p.CreateApplicationViewModel(It.IsAny<Guid>(), ValidVacancyId))
                .Returns(Task.FromResult(new ApprenticeshipApplicationViewModel(MyApplicationsPageMessages.ApplicationNotFound,
                    ApplicationViewModelStatus.ApplicationNotFound)));
            ApprenticeshipApplicationProvider.Setup(
                p =>
                    p.PatchApplicationViewModel(It.IsAny<Guid>(), It.IsAny<ApprenticeshipApplicationViewModel>(),
                        It.IsAny<ApprenticeshipApplicationViewModel>()))
                .Returns<Guid, ApprenticeshipApplicationViewModel, ApprenticeshipApplicationViewModel>(
                    (cid, svm, vm) => vm);
            ApprenticeshipApplicationProvider.Setup(p => p.SubmitApplication(It.IsAny<Guid>(), It.IsAny<int>()))
                .Returns(Task.FromResult<ApprenticeshipApplicationViewModel>(viewModel));

            var response = await Mediator.Submit(Guid.NewGuid(), ValidVacancyId, postedViewModel);

            response.AssertCode(ApprenticeshipApplicationMediatorCodes.Submit.VacancyNotFound, false);
        }

        [Test]
        public async Task GetApplicationViewModelError()
        {
            var postedViewModel = new ApprenticeshipApplicationPreviewViewModel
            {
                AcceptSubmit = true
            };

            var savedViewModel = new ApprenticeshipApplicationPreviewViewModel
            {
                Candidate = new ApprenticeshipCandidateViewModel(),
                VacancyDetail = new ApprenticeshipVacancyDetailViewModel
                {
                    VacancyStatus = VacancyStatuses.Live
                }
            };
            var submittedApplicationViewModel = new ApprenticeshipApplicationViewModel
            {
                Candidate = new ApprenticeshipCandidateViewModel(),
                VacancyDetail = new ApprenticeshipVacancyDetailViewModel(),
                ViewModelStatus = ApplicationViewModelStatus.Error,
                ViewModelMessage = "An error message"
            };
            ApprenticeshipApplicationProvider.Setup(
                p => p.GetApplicationPreviewViewModel(It.IsAny<Guid>(), It.IsAny<int>())).Returns(Task.FromResult(savedViewModel));
            ApprenticeshipApplicationProvider.Setup(p => p.SubmitApplication(It.IsAny<Guid>(), It.IsAny<int>()))
                .Returns(Task.FromResult(submittedApplicationViewModel));

            var response = await Mediator.Submit(Guid.NewGuid(), ValidVacancyId, postedViewModel);

            response.AssertMessage(ApprenticeshipApplicationMediatorCodes.Submit.Error,
                ApplicationPageMessages.SubmitApplicationFailed, UserMessageLevel.Warning, false, true);
        }

        [Test]
        public async Task IncorrectState()
        {
            var postedViewModel = new ApprenticeshipApplicationPreviewViewModel
            {
                AcceptSubmit = true
            };

            var viewModel = new ApprenticeshipApplicationPreviewViewModel
            {
                Candidate = new ApprenticeshipCandidateViewModel(),
                VacancyDetail = new ApprenticeshipVacancyDetailViewModel
                {
                    VacancyStatus = VacancyStatuses.Live
                },
                ViewModelStatus = ApplicationViewModelStatus.ApplicationInIncorrectState
            };

            ApprenticeshipApplicationProvider.Setup(
                p => p.GetApplicationPreviewViewModel(It.IsAny<Guid>(), It.IsAny<int>())).Returns(Task.FromResult(viewModel));
            ApprenticeshipApplicationProvider.Setup(p => p.SubmitApplication(It.IsAny<Guid>(), It.IsAny<int>()))
                .Returns(Task.FromResult<ApprenticeshipApplicationViewModel>(viewModel));

            var response = await Mediator.Submit(Guid.NewGuid(), ValidVacancyId, postedViewModel);

            response.AssertMessage(ApprenticeshipApplicationMediatorCodes.Submit.IncorrectState,
                MyApplicationsPageMessages.ApplicationInIncorrectState, UserMessageLevel.Info, false);
        }

        [Test]
        public async Task Ok()
        {
            var postedViewModel = new ApprenticeshipApplicationPreviewViewModel
            {
                AcceptSubmit = true
            };

            var viewModel = new ApprenticeshipApplicationPreviewViewModel
            {
                Candidate = new ApprenticeshipCandidateViewModel(),
                VacancyDetail = new ApprenticeshipVacancyDetailViewModel
                {
                    VacancyStatus = VacancyStatuses.Live
                }
            };

            ApprenticeshipApplicationProvider.Setup(
                p => p.GetApplicationPreviewViewModel(It.IsAny<Guid>(), It.IsAny<int>())).Returns(Task.FromResult(viewModel));
            ApprenticeshipApplicationProvider.Setup(p => p.CreateApplicationViewModel(It.IsAny<Guid>(), ValidVacancyId))
                .Returns(Task.FromResult(new ApprenticeshipApplicationViewModel()));
            ApprenticeshipApplicationProvider.Setup(
                p =>
                    p.PatchApplicationViewModel(It.IsAny<Guid>(), It.IsAny<ApprenticeshipApplicationViewModel>(),
                        It.IsAny<ApprenticeshipApplicationViewModel>()))
                .Returns<Guid, ApprenticeshipApplicationViewModel, ApprenticeshipApplicationViewModel>(
                    (cid, svm, vm) => vm);
            ApprenticeshipApplicationProvider.Setup(p => p.SubmitApplication(It.IsAny<Guid>(), It.IsAny<int>()))
                .Returns(Task.FromResult<ApprenticeshipApplicationViewModel>(viewModel));

            var response = await Mediator.Submit(Guid.NewGuid(), ValidVacancyId, postedViewModel);

            response.AssertCode(ApprenticeshipApplicationMediatorCodes.Submit.Ok, false, true);
        }

        [Test]
        public async Task SubmitApplicationError()
        {
            var postedViewModel = new ApprenticeshipApplicationPreviewViewModel
            {
                AcceptSubmit = true
            };

            var viewModel = new ApprenticeshipApplicationPreviewViewModel
            {
                Candidate = new ApprenticeshipCandidateViewModel(),
                VacancyDetail = new ApprenticeshipVacancyDetailViewModel(),
                ViewModelStatus = ApplicationViewModelStatus.Error,
                ViewModelMessage = "An error message"
            };

            ApprenticeshipApplicationProvider.Setup(
                p => p.GetApplicationPreviewViewModel(It.IsAny<Guid>(), It.IsAny<int>())).Returns(Task.FromResult(viewModel));
            ApprenticeshipApplicationProvider.Setup(p => p.SubmitApplication(It.IsAny<Guid>(), It.IsAny<int>()))
                .Returns(Task.FromResult<ApprenticeshipApplicationViewModel>(viewModel));

            var response = await Mediator.Submit(Guid.NewGuid(), ValidVacancyId, postedViewModel);

            response.AssertMessage(ApprenticeshipApplicationMediatorCodes.Submit.Error,
                ApplicationPageMessages.SubmitApplicationFailed, UserMessageLevel.Warning, false, true);
        }

        [Test]
        public async Task VacancyExpired()
        {
            var postedViewModel = new ApprenticeshipApplicationPreviewViewModel
            {
                AcceptSubmit = true
            };

            var viewModel = new ApprenticeshipApplicationPreviewViewModel
            {
                Candidate = new ApprenticeshipCandidateViewModel(),
                VacancyDetail = new ApprenticeshipVacancyDetailViewModel()
            };

            ApprenticeshipApplicationProvider.Setup(
                p => p.GetApplicationPreviewViewModel(It.IsAny<Guid>(), It.IsAny<int>())).Returns(Task.FromResult(viewModel));

            ApprenticeshipApplicationProvider.Setup(p => p.CreateApplicationViewModel(It.IsAny<Guid>(), ValidVacancyId))
                .Returns(Task.FromResult(new ApprenticeshipApplicationViewModel
                {
                    VacancyDetail = new ApprenticeshipVacancyDetailViewModel
                    {
                        VacancyStatus = VacancyStatuses.Expired
                    }
                }));

            ApprenticeshipApplicationProvider.Setup(
                p =>
                    p.PatchApplicationViewModel(It.IsAny<Guid>(), It.IsAny<ApprenticeshipApplicationViewModel>(),
                        It.IsAny<ApprenticeshipApplicationViewModel>()))
                .Returns<Guid, ApprenticeshipApplicationViewModel, ApprenticeshipApplicationViewModel>(
                    (cid, svm, vm) => vm);
            ApprenticeshipApplicationProvider.Setup(p => p.SubmitApplication(It.IsAny<Guid>(), It.IsAny<int>()))
                .Returns(Task.FromResult<ApprenticeshipApplicationViewModel>(viewModel));

            var response = await Mediator.Submit(Guid.NewGuid(), ValidVacancyId, postedViewModel);

            response.AssertCode(ApprenticeshipApplicationMediatorCodes.Submit.VacancyNotFound, false);
        }

        [Test]
        public async Task VacancyNotFound()
        {
            var postedViewModel = new ApprenticeshipApplicationPreviewViewModel
            {
                AcceptSubmit = true
            };

            var viewModel = new ApprenticeshipApplicationPreviewViewModel
            {
                Candidate = new ApprenticeshipCandidateViewModel(),
                VacancyDetail = new ApprenticeshipVacancyDetailViewModel(),
                Status = ApplicationStatuses.ExpiredOrWithdrawn
            };

            ApprenticeshipApplicationProvider.Setup(
                p => p.GetApplicationPreviewViewModel(It.IsAny<Guid>(), It.IsAny<int>())).Returns(Task.FromResult(viewModel));
            ApprenticeshipApplicationProvider.Setup(p => p.SubmitApplication(It.IsAny<Guid>(), It.IsAny<int>()))
                .Returns(Task.FromResult<ApprenticeshipApplicationViewModel>(viewModel));

            var response = await Mediator.Submit(Guid.NewGuid(), ValidVacancyId, postedViewModel);

            response.AssertCode(ApprenticeshipApplicationMediatorCodes.Submit.VacancyNotFound, false);
        }

        [Test]
        public async Task VacancyNotFound_GatewayError()
        {
            var postedViewModel = new ApprenticeshipApplicationPreviewViewModel
            {
                AcceptSubmit = true
            };

            var savedViewModel = new ApprenticeshipApplicationPreviewViewModel
            {
                Candidate = new ApprenticeshipCandidateViewModel(),
                VacancyDetail = new ApprenticeshipVacancyDetailViewModel
                {
                    VacancyStatus = VacancyStatuses.Live
                }
            };

            var submittedViewModel =
                new ApprenticeshipApplicationViewModel(ApprenticeshipVacancyDetailPageMessages.GetVacancyDetailFailed)
                {
                    Candidate = new ApprenticeshipCandidateViewModel(),
                    VacancyDetail =
                        new ApprenticeshipVacancyDetailViewModel(
                            ApprenticeshipVacancyDetailPageMessages.GetVacancyDetailFailed)
                };

            ApprenticeshipApplicationProvider.Setup(
                p => p.GetApplicationPreviewViewModel(It.IsAny<Guid>(), It.IsAny<int>())).Returns(Task.FromResult(savedViewModel));
            ApprenticeshipApplicationProvider.Setup(p => p.SubmitApplication(It.IsAny<Guid>(), It.IsAny<int>()))
                .Returns(Task.FromResult(submittedViewModel));

            var response = await Mediator.Submit(Guid.NewGuid(), ValidVacancyId, postedViewModel);

            response.AssertMessage(ApprenticeshipApplicationMediatorCodes.Submit.Error,
                ApplicationPageMessages.SubmitApplicationFailed, UserMessageLevel.Warning, false, true);
        }

        [Test]
        public async Task ValidationError()
        {
            var postedViewModel = new ApprenticeshipApplicationPreviewViewModel
            {
                AcceptSubmit = true
            };

            var viewModel = new ApprenticeshipApplicationPreviewViewModel
            {
                Candidate = new ApprenticeshipCandidateViewModel
                {
                    Education = new EducationViewModel
                    {
                        NameOfMostRecentSchoolCollege = "A School",
                        FromYear = "0",
                        ToYear = "0"
                    }
                },
                VacancyDetail = new ApprenticeshipVacancyDetailViewModel
                {
                    VacancyStatus = VacancyStatuses.Live
                },
                ViewModelStatus = ApplicationViewModelStatus.Error
            };

            ApprenticeshipApplicationProvider.Setup(
                p => p.GetApplicationPreviewViewModel(It.IsAny<Guid>(), It.IsAny<int>())).Returns(Task.FromResult(viewModel));
            ApprenticeshipApplicationProvider.Setup(p => p.SubmitApplication(It.IsAny<Guid>(), It.IsAny<int>()))
                .Returns(Task.FromResult<ApprenticeshipApplicationViewModel>(viewModel));

            var response = await Mediator.Submit(Guid.NewGuid(), ValidVacancyId, postedViewModel);

            response.AssertValidationResult(ApprenticeshipApplicationMediatorCodes.Submit.ValidationError);
        }
    }
}