﻿namespace SFA.Apprenticeships.Web.Candidate.UnitTests.Mediators.TraineeshipApplication
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Builders;
    using Candidate.Mediators.Application;
    using Candidate.ViewModels.Applications;
    using Candidate.ViewModels.Candidate;
    using Candidate.ViewModels.VacancySearch;
    using Common.Constants;
    using Common.Models.Application;
    using Common.UnitTests.Mediators;
    using Constants.Pages;
    using Moq;
    using NUnit.Framework;

    [TestFixture]
    [Parallelizable]
    public class SubmitTests : TestsBase
    {
        private const int ValidVacancyId = 1;

        [Test]
        public async Task FailValidation()
        {
            var viewModel = new TraineeshipApplicationViewModel
            {
                Candidate = new TraineeshipCandidateViewModel
                {
                    MonitoringInformation = new MonitoringInformationViewModel
                    {
                        AnythingWeCanDoToSupportYourInterview = new string('X', 9999)
                    }
                }
            };
            TraineeshipApplicationProvider.Setup(p => p.GetApplicationViewModel(It.IsAny<Guid>(), ValidVacancyId))
                .Returns(Task.FromResult(viewModel));
            TraineeshipApplicationProvider.Setup(
                p =>
                    p.PatchApplicationViewModel(It.IsAny<Guid>(), It.IsAny<TraineeshipApplicationViewModel>(),
                        It.IsAny<TraineeshipApplicationViewModel>()))
                .Returns<Guid, TraineeshipApplicationViewModel, TraineeshipApplicationViewModel>((cid, svm, vm) => vm);

            var response = await Mediator.Submit(Guid.NewGuid(), ValidVacancyId, viewModel);

            response.AssertValidationResult(TraineeshipApplicationMediatorCodes.Submit.ValidationError, true, false);
        }

        [Test]
        public async Task FailValidationEducationLongerThan15Char()
        {
            var viewModel = new TraineeshipApplicationViewModel
            {
                Candidate = new TraineeshipCandidateViewModel
                {
                    MonitoringInformation = new MonitoringInformationViewModel(),
                    HasQualifications = true,
                    Qualifications = new List<QualificationsViewModel>
                    {
                        new QualificationsViewModel
                        {
                            Grade = "Grade is Longer than 15 chars",
                            QualificationType = "QUAL",
                            Year = "2012"
                        }
                    }
                }
            };
            TraineeshipApplicationProvider.Setup(p => p.GetApplicationViewModel(It.IsAny<Guid>(), ValidVacancyId))
                .Returns(Task.FromResult(viewModel));
            TraineeshipApplicationProvider.Setup(
                p =>
                    p.PatchApplicationViewModel(It.IsAny<Guid>(), It.IsAny<TraineeshipApplicationViewModel>(),
                        It.IsAny<TraineeshipApplicationViewModel>()))
                .Returns<Guid, TraineeshipApplicationViewModel, TraineeshipApplicationViewModel>((cid, svm, vm) => vm);

            var response = await Mediator.Submit(Guid.NewGuid(), ValidVacancyId, viewModel);

            response.AssertValidationResult(TraineeshipApplicationMediatorCodes.Submit.ValidationError, true, false);
        }

        [Test]
        public async Task GetApplicationViewModelError()
        {
            var getApplicationViewModel =
                new TraineeshipApplicationViewModelBuilder().WithMessage(ApplicationPageMessages.SubmitApplicationFailed)
                    .Build();
            TraineeshipApplicationProvider.Setup(p => p.GetApplicationViewModel(It.IsAny<Guid>(), ValidVacancyId))
                .Returns(Task.FromResult(getApplicationViewModel));

            var viewModel = new TraineeshipApplicationViewModelBuilder().Build();
            var response = await Mediator.Submit(Guid.NewGuid(), ValidVacancyId, viewModel);

            response.AssertMessage(TraineeshipApplicationMediatorCodes.Submit.Error,
                ApplicationPageMessages.SubmitApplicationFailed, UserMessageLevel.Warning, true, true);
        }

        [Test]
        public async Task IncorrectState()
        {
            var viewModel = new TraineeshipApplicationViewModel
            {
                Candidate = new TraineeshipCandidateViewModel(),
                VacancyDetail = new TraineeshipVacancyDetailViewModel(),
                ViewModelStatus = ApplicationViewModelStatus.ApplicationInIncorrectState
            };
            TraineeshipApplicationProvider.Setup(p => p.GetApplicationViewModel(It.IsAny<Guid>(), ValidVacancyId))
                .Returns(Task.FromResult(new TraineeshipApplicationViewModel
                {
                    ViewModelStatus = ApplicationViewModelStatus.ApplicationInIncorrectState
                }));
            TraineeshipApplicationProvider.Setup(
                p =>
                    p.PatchApplicationViewModel(It.IsAny<Guid>(), It.IsAny<TraineeshipApplicationViewModel>(),
                        It.IsAny<TraineeshipApplicationViewModel>()))
                .Returns<Guid, TraineeshipApplicationViewModel, TraineeshipApplicationViewModel>((cid, svm, vm) => vm);
            TraineeshipApplicationProvider.Setup(
                p => p.SubmitApplication(It.IsAny<Guid>(), It.IsAny<int>(), It.IsAny<TraineeshipApplicationViewModel>()))
                .Returns<Guid, int, TraineeshipApplicationViewModel>((cid, vid, vm) => Task.FromResult(vm));

            var response = await Mediator.Submit(Guid.NewGuid(), ValidVacancyId, viewModel);

            response.AssertCode(TraineeshipApplicationMediatorCodes.Submit.IncorrectState, false);
        }

        [Test]
        public async Task Ok()
        {
            var viewModel = new TraineeshipApplicationViewModel
            {
                Candidate = new TraineeshipCandidateViewModel(),
                VacancyDetail = new TraineeshipVacancyDetailViewModel()
            };
            TraineeshipApplicationProvider.Setup(p => p.GetApplicationViewModel(It.IsAny<Guid>(), ValidVacancyId))
                .Returns(Task.FromResult(new TraineeshipApplicationViewModel()));
            TraineeshipApplicationProvider.Setup(
                p =>
                    p.PatchApplicationViewModel(It.IsAny<Guid>(), It.IsAny<TraineeshipApplicationViewModel>(),
                        It.IsAny<TraineeshipApplicationViewModel>()))
                .Returns<Guid, TraineeshipApplicationViewModel, TraineeshipApplicationViewModel>((cid, svm, vm) => vm);
            TraineeshipApplicationProvider.Setup(
                p => p.SubmitApplication(It.IsAny<Guid>(), It.IsAny<int>(), It.IsAny<TraineeshipApplicationViewModel>()))
                .Returns<Guid, int, TraineeshipApplicationViewModel>((cid, vid, vm) => Task.FromResult(vm));

            var response = await Mediator.Submit(Guid.NewGuid(), ValidVacancyId, viewModel);

            response.AssertCode(TraineeshipApplicationMediatorCodes.Submit.Ok, false, true);
        }

        [Test]
        public async Task OkIsJavascript()
        {
            var viewModel = new TraineeshipApplicationViewModel
            {
                Candidate = new TraineeshipCandidateViewModel(),
                VacancyDetail = new TraineeshipVacancyDetailViewModel(),
                IsJavascript = true
            };
            TraineeshipApplicationProvider.Setup(p => p.GetApplicationViewModel(It.IsAny<Guid>(), ValidVacancyId))
                .Returns(Task.FromResult(new TraineeshipApplicationViewModel()));
            TraineeshipApplicationProvider.Setup(
                p =>
                    p.PatchApplicationViewModel(It.IsAny<Guid>(), It.IsAny<TraineeshipApplicationViewModel>(),
                        It.IsAny<TraineeshipApplicationViewModel>()))
                .Returns<Guid, TraineeshipApplicationViewModel, TraineeshipApplicationViewModel>((cid, svm, vm) => vm);
            TraineeshipApplicationProvider.Setup(
                p => p.SubmitApplication(It.IsAny<Guid>(), It.IsAny<int>(), It.IsAny<TraineeshipApplicationViewModel>()))
                .Returns<Guid, int, TraineeshipApplicationViewModel>((cid, vid, vm) => Task.FromResult(vm));

            var response = await Mediator.Submit(Guid.NewGuid(), ValidVacancyId, viewModel);

            response.AssertCode(TraineeshipApplicationMediatorCodes.Submit.Ok, false, true);
        }

        [Test]
        public async Task SubmitApplicationError()
        {
            var viewModel = new TraineeshipApplicationViewModel
            {
                Candidate = new TraineeshipCandidateViewModel(),
                VacancyDetail = new TraineeshipVacancyDetailViewModel(),
                ViewModelStatus = ApplicationViewModelStatus.Error
            };
            TraineeshipApplicationProvider.Setup(p => p.GetApplicationViewModel(It.IsAny<Guid>(), ValidVacancyId))
                .Returns(Task.FromResult(new TraineeshipApplicationViewModel {ViewModelStatus = ApplicationViewModelStatus.Error}));
            TraineeshipApplicationProvider.Setup(
                p =>
                    p.PatchApplicationViewModel(It.IsAny<Guid>(), It.IsAny<TraineeshipApplicationViewModel>(),
                        It.IsAny<TraineeshipApplicationViewModel>()))
                .Returns<Guid, TraineeshipApplicationViewModel, TraineeshipApplicationViewModel>((cid, svm, vm) => vm);
            TraineeshipApplicationProvider.Setup(
                p => p.SubmitApplication(It.IsAny<Guid>(), It.IsAny<int>(), It.IsAny<TraineeshipApplicationViewModel>()))
                .Returns<Guid, int, TraineeshipApplicationViewModel>((cid, vid, vm) => Task.FromResult(vm));

            var response = await Mediator.Submit(Guid.NewGuid(), ValidVacancyId, viewModel);

            response.AssertMessage(TraineeshipApplicationMediatorCodes.Submit.Error,
                ApplicationPageMessages.SubmitApplicationFailed, UserMessageLevel.Warning, true, true);
        }
    }
}