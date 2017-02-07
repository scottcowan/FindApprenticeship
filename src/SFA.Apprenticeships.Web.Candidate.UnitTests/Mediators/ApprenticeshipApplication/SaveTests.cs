
namespace SFA.Apprenticeships.Web.Candidate.UnitTests.Mediators.ApprenticeshipApplication
{
    using System;
    using System.Threading.Tasks;
    using Candidate.Mediators.Application;
    using Candidate.ViewModels.Applications;
    using Candidate.ViewModels.Candidate;
    using Candidate.ViewModels.VacancySearch;
    using Common.Constants;
    using Common.UnitTests.Mediators;
    using Constants.Pages;
    using Domain.Entities.Applications;
    using Moq;
    using NUnit.Framework;

    [TestFixture]
    [Parallelizable]
    public class SaveTests : TestsBase
    {
        private const int ValidVacancyId = 1;

        [Test]
        public async Task AlreadySubmitted()
        {
            var viewModel = new ApprenticeshipApplicationViewModel
            {
                Candidate = new ApprenticeshipCandidateViewModel(),
                VacancyDetail = new ApprenticeshipVacancyDetailViewModel()
            };
            ApprenticeshipApplicationProvider.Setup(p => p.GetApplicationViewModel(It.IsAny<Guid>(), ValidVacancyId)).Returns(Task.FromResult(new ApprenticeshipApplicationViewModel { Status = ApplicationStatuses.Submitted, VacancyDetail = new ApprenticeshipVacancyDetailViewModel() }));
            ApprenticeshipApplicationProvider.Setup(p => p.PatchApplicationViewModel(It.IsAny<Guid>(), It.IsAny<ApprenticeshipApplicationViewModel>(), It.IsAny<ApprenticeshipApplicationViewModel>())).Returns<Guid, ApprenticeshipApplicationViewModel, ApprenticeshipApplicationViewModel>((cid, svm, vm) => vm);

            var response = await Mediator.Save(Guid.NewGuid(), ValidVacancyId, viewModel);

            response.AssertMessage(ApprenticeshipApplicationMediatorCodes.Save.IncorrectState, MyApplicationsPageMessages.ApplicationInIncorrectState, UserMessageLevel.Info, false);
        }

        [Test]
        public async Task Error()
        {
            var viewModel = new ApprenticeshipApplicationViewModel
            {
                Candidate = new ApprenticeshipCandidateViewModel(),
                VacancyDetail = new ApprenticeshipVacancyDetailViewModel()
            };
            ApprenticeshipApplicationProvider.Setup(p => p.GetApplicationViewModel(It.IsAny<Guid>(), ValidVacancyId)).Returns(Task.FromResult(new ApprenticeshipApplicationViewModel("Has Error")));
            
            var response = await Mediator.Save(Guid.NewGuid(), ValidVacancyId, viewModel);

            response.AssertMessage(ApprenticeshipApplicationMediatorCodes.Save.Error, ApplicationPageMessages.SaveFailed, UserMessageLevel.Warning, true);
        }

        [Test]
        public async Task OkIsJavascript()
        {
            var viewModel = new ApprenticeshipApplicationViewModel
            {
                Candidate = new ApprenticeshipCandidateViewModel(),
                VacancyDetail = new ApprenticeshipVacancyDetailViewModel(),
                IsJavascript = true
            };
            ApprenticeshipApplicationProvider.Setup(p => p.GetApplicationViewModel(It.IsAny<Guid>(), ValidVacancyId)).Returns(Task.FromResult(new ApprenticeshipApplicationViewModel { Status = ApplicationStatuses.Draft, VacancyDetail = new ApprenticeshipVacancyDetailViewModel() }));
            ApprenticeshipApplicationProvider.Setup(p => p.PatchApplicationViewModel(It.IsAny<Guid>(), It.IsAny<ApprenticeshipApplicationViewModel>(), It.IsAny<ApprenticeshipApplicationViewModel>())).Returns<Guid, ApprenticeshipApplicationViewModel, ApprenticeshipApplicationViewModel>((cid, svm, vm) => vm);
            ApprenticeshipApplicationProvider.Setup(p => p.SubmitApplication(It.IsAny<Guid>(), It.IsAny<int>())).Returns(Task.FromResult(viewModel));
            
            var response = await Mediator.Save(Guid.NewGuid(), ValidVacancyId, viewModel);

            response.AssertCode(ApprenticeshipApplicationMediatorCodes.Save.Ok, true);
        }

        [Test]
        public async Task Ok()
        {
            var viewModel = new ApprenticeshipApplicationViewModel
            {
                Candidate = new ApprenticeshipCandidateViewModel(),
                VacancyDetail = new ApprenticeshipVacancyDetailViewModel()
            };
            ApprenticeshipApplicationProvider.Setup(p => p.GetApplicationViewModel(It.IsAny<Guid>(), ValidVacancyId)).Returns(Task.FromResult(new ApprenticeshipApplicationViewModel { Status = ApplicationStatuses.Draft, VacancyDetail = new ApprenticeshipVacancyDetailViewModel() }));
            ApprenticeshipApplicationProvider.Setup(p => p.PatchApplicationViewModel(It.IsAny<Guid>(), It.IsAny<ApprenticeshipApplicationViewModel>(), It.IsAny<ApprenticeshipApplicationViewModel>())).Returns<Guid, ApprenticeshipApplicationViewModel, ApprenticeshipApplicationViewModel>((cid, svm, vm) => vm);
            ApprenticeshipApplicationProvider.Setup(p => p.SubmitApplication(It.IsAny<Guid>(), It.IsAny<int>())).Returns(Task.FromResult(viewModel));
            
            var response = await Mediator.Save(Guid.NewGuid(), ValidVacancyId, viewModel);

            response.AssertCode(ApprenticeshipApplicationMediatorCodes.Save.Ok, true);
        }

        [Test]
        public async Task VacancyNotFound()
        {
            var viewModel = new ApprenticeshipApplicationViewModel
            {
                Candidate = new ApprenticeshipCandidateViewModel(),
                VacancyDetail = new ApprenticeshipVacancyDetailViewModel()
            };
            ApprenticeshipApplicationProvider.Setup(p => p.GetApplicationViewModel(It.IsAny<Guid>(), ValidVacancyId)).Returns(Task.FromResult(new ApprenticeshipApplicationViewModel { Status = ApplicationStatuses.ExpiredOrWithdrawn }));
            
            var response = await Mediator.Save(Guid.NewGuid(), ValidVacancyId, viewModel);

            response.AssertCodeAndMessage(ApprenticeshipApplicationMediatorCodes.Save.VacancyNotFound);
        }

        [Test]
        public async Task ValidationError()
        {
            var viewModel = new ApprenticeshipApplicationViewModel
            {
                Candidate = new ApprenticeshipCandidateViewModel
                {
                    Education = new EducationViewModel
                    {
                        FromYear = "1066"
                    }
                },
                VacancyDetail = new ApprenticeshipVacancyDetailViewModel()
            };
            ApprenticeshipApplicationProvider.Setup(p => p.GetApplicationViewModel(It.IsAny<Guid>(), ValidVacancyId))
                .Returns(Task.FromResult(new ApprenticeshipApplicationViewModel
                {
                    Status = ApplicationStatuses.Draft,
                    VacancyDetail = new ApprenticeshipVacancyDetailViewModel()
                }));
            ApprenticeshipApplicationProvider.Setup(
                p =>
                    p.PatchApplicationViewModel(It.IsAny<Guid>(), It.IsAny<ApprenticeshipApplicationViewModel>(),
                        It.IsAny<ApprenticeshipApplicationViewModel>()))
                .Returns<Guid, ApprenticeshipApplicationViewModel, ApprenticeshipApplicationViewModel>(
                    (cid, svm, vm) => vm);

            var response = await Mediator.Save(Guid.NewGuid(), ValidVacancyId, viewModel);

            response.AssertValidationResult(ApprenticeshipApplicationMediatorCodes.Save.ValidationError);
        }

        [Test]
        public async Task OfflineVacancy()
        {
            var viewModel = new ApprenticeshipApplicationViewModel
            {
                Candidate = new ApprenticeshipCandidateViewModel(),
                VacancyDetail = new ApprenticeshipVacancyDetailViewModel()
            };
            ApprenticeshipApplicationProvider.Setup(p => p.GetApplicationViewModel(It.IsAny<Guid>(), ValidVacancyId)).Returns(Task.FromResult(new ApprenticeshipApplicationViewModel { Status = ApplicationStatuses.Draft, VacancyDetail = new ApprenticeshipVacancyDetailViewModel { ApplyViaEmployerWebsite = true } }));
            ApprenticeshipApplicationProvider.Setup(p => p.PatchApplicationViewModel(It.IsAny<Guid>(), It.IsAny<ApprenticeshipApplicationViewModel>(), It.IsAny<ApprenticeshipApplicationViewModel>())).Returns<Guid, ApprenticeshipApplicationViewModel, ApprenticeshipApplicationViewModel>((cid, svm, vm) => vm);
            ApprenticeshipApplicationProvider.Setup(p => p.SubmitApplication(It.IsAny<Guid>(), It.IsAny<int>())).Returns(Task.FromResult(viewModel));

            var response = await Mediator.Save(Guid.NewGuid(), ValidVacancyId, viewModel);

            response.AssertCode(ApprenticeshipApplicationMediatorCodes.Save.OfflineVacancy, false);
        }
    }
}