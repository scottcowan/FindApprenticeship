﻿namespace SFA.Apprenticeships.Web.Recruit.Controllers
{
    using Application.Interfaces;
    using Attributes;
    using Common.Attributes;
    using Common.Mediators;
    using Common.Validators.Extensions;
    using Constants;
    using Domain.Entities.Applications;
    using Domain.Entities.Raa;
    using Mediators.Application;
    using Raa.Common.ViewModels.Application;
    using Raa.Common.ViewModels.Application.Apprenticeship;
    using System;
    using System.Threading.Tasks;
    using System.Web.Mvc;

    [AuthorizeUser(Roles = Roles.VerifiedEmail)]
    [AuthorizeUser(Roles = Roles.Faa)]
    public class ApprenticeshipApplicationController : RecruitmentControllerBase
    {
        private readonly IApprenticeshipApplicationMediator _apprenticeshipApplicationMediator;

        public ApprenticeshipApplicationController(IApprenticeshipApplicationMediator apprenticeshipApplicationMediator, IConfigurationService configurationService, ILogService logService)
            : base(configurationService, logService)
        {
            _apprenticeshipApplicationMediator = apprenticeshipApplicationMediator;
        }

        [HttpGet]
        public async Task<ActionResult> Review(ApplicationSelectionViewModel applicationSelectionViewModel)
        {
            var response = await _apprenticeshipApplicationMediator.Review(applicationSelectionViewModel);

            switch (response.Code)
            {
                case ApprenticeshipApplicationMediatorCodes.Review.Ok:
                    return View(response.ViewModel);

                case ApprenticeshipApplicationMediatorCodes.Review.NoApplicationId:
                    SetUserMessage(response.Message);
                    return RedirectToRoute(RecruitmentRouteNames.RecruitmentHome);

                default:
                    throw new InvalidMediatorCodeException(response.Code);
            }
        }

        private async Task<ActionResult> ReviewAppointCandidate(ApprenticeshipApplicationViewModel apprenticeshipApplicationViewModel)
        {
            var response = await _apprenticeshipApplicationMediator.ReviewAppointCandidate(apprenticeshipApplicationViewModel);
            var viewModel = response.ViewModel;

            ModelState.Clear();

            if (response.Message != null)
            {
                SetUserMessage(response.Message);
            }

            switch (response.Code)
            {
                case ApprenticeshipApplicationMediatorCodes.ReviewAppointCandidate.Error:
                    return View("Review", response.ViewModel);

                case ApprenticeshipApplicationMediatorCodes.ReviewAppointCandidate.FailedValidation:
                    response.ValidationResult.AddToModelStateWithSeverity(ModelState, string.Empty);
                    return RedirectToRoute(RecruitmentRouteNames.ReviewApprenticeshipApplication, viewModel);

                case ApprenticeshipApplicationMediatorCodes.ReviewAppointCandidate.Ok:
                    return RedirectToRoute(RecruitmentRouteNames.ConfirmSuccessfulApprenticeshipApplication, viewModel.ApplicationSelection.RouteValues);

                default:
                    throw new InvalidMediatorCodeException(response.Code);
            }
        }

        private async Task<ActionResult> ReviewRejectCandidate(ApprenticeshipApplicationViewModel apprenticeshipApplicationViewModel)
        {
            var response = await _apprenticeshipApplicationMediator.ReviewRejectCandidate(apprenticeshipApplicationViewModel);
            var viewModel = response.ViewModel;

            ModelState.Clear();

            if (response.Message != null)
            {
                SetUserMessage(response.Message);
            }

            switch (response.Code)
            {
                case ApprenticeshipApplicationMediatorCodes.ReviewRejectCandidate.Error:
                    return View("Review", response.ViewModel);

                case ApprenticeshipApplicationMediatorCodes.ReviewRejectCandidate.FailedValidation:
                    response.ValidationResult.AddToModelStateWithSeverity(ModelState, string.Empty);
                    return RedirectToRoute(RecruitmentRouteNames.ReviewApprenticeshipApplication, viewModel);

                case ApprenticeshipApplicationMediatorCodes.ReviewRejectCandidate.Ok:
                    return RedirectToRoute(RecruitmentRouteNames.ConfirmUnsuccessfulApprenticeshipApplication, viewModel.ApplicationSelection.RouteValues);

                default:
                    throw new InvalidMediatorCodeException(response.Code);
            }
        }

        [HttpPost]
        [MultipleFormActionsButton(SubmitButtonActionName = "Review")]
        public async Task<ActionResult> ReviewRevertToInProgress(ApprenticeshipApplicationViewModel apprenticeshipApplicationViewModel)
        {
            var response = await _apprenticeshipApplicationMediator.ReviewRevertToInProgress(apprenticeshipApplicationViewModel);
            var viewModel = response.ViewModel;

            ModelState.Clear();

            if (response.Message != null)
            {
                SetUserMessage(response.Message);
            }

            switch (response.Code)
            {
                case ApprenticeshipApplicationMediatorCodes.ReviewRevertToInProgress.Error:
                    return View("Review", response.ViewModel);

                case ApprenticeshipApplicationMediatorCodes.ReviewRevertToInProgress.FailedValidation:
                    response.ValidationResult.AddToModelStateWithSeverity(ModelState, string.Empty);
                    return RedirectToRoute(RecruitmentRouteNames.ReviewApprenticeshipApplication, viewModel);

                case ApprenticeshipApplicationMediatorCodes.ReviewRevertToInProgress.Ok:
                    return RedirectToRoute(RecruitmentRouteNames.ConfirmRevertToInProgress, viewModel.ApplicationSelection.RouteValues);

                default:
                    throw new InvalidMediatorCodeException(response.Code);
            }
        }

        [HttpPost]
        [MultipleFormActionsButton(SubmitButtonActionName = "Review")]
        public async Task<ActionResult> ReviewSaveAndContinue(ApprenticeshipApplicationViewModel apprenticeshipApplicationViewModel)
        {
            switch (apprenticeshipApplicationViewModel.Status)
            {
                case ApplicationStatuses.Submitted:
                    return await SetToSubmitted(apprenticeshipApplicationViewModel);
                case ApplicationStatuses.InProgress:
                    return await PromoteToInProgress(apprenticeshipApplicationViewModel);
                case ApplicationStatuses.Successful:
                    return await ReviewAppointCandidate(apprenticeshipApplicationViewModel);
                case ApplicationStatuses.Unsuccessful:
                    return await ReviewRejectCandidate(apprenticeshipApplicationViewModel);
                default:
                    throw new InvalidOperationException("Invalid status change");
            }
        }

        private async Task<ActionResult> PromoteToInProgress(ApprenticeshipApplicationViewModel apprenticeshipApplicationViewModel)
        {
            var response = await _apprenticeshipApplicationMediator.PromoteToInProgress(apprenticeshipApplicationViewModel);
            var viewModel = response.ViewModel;

            ModelState.Clear();

            if (response.Message != null)
            {
                SetUserMessage(response.Message);
            }

            switch (response.Code)
            {
                case ApprenticeshipApplicationMediatorCodes.PromoteToInProgress.Error:
                    return View("Review", response.ViewModel);

                case ApprenticeshipApplicationMediatorCodes.PromoteToInProgress.FailedValidation:
                    response.ValidationResult.AddToModelStateWithSeverity(ModelState, string.Empty);
                    return RedirectToRoute(RecruitmentRouteNames.ReviewApprenticeshipApplication, viewModel);

                case ApprenticeshipApplicationMediatorCodes.PromoteToInProgress.Ok:
                    return RedirectToRoute(RecruitmentRouteNames.VacancyApplications, viewModel.ApplicationSelection.RouteValues);

                default:
                    throw new InvalidMediatorCodeException(response.Code);
            }
        }

        private async Task<ActionResult> SetToSubmitted(ApprenticeshipApplicationViewModel apprenticeshipApplicationViewModel)
        {
            var response = await _apprenticeshipApplicationMediator.ReviewSetToSubmitted(apprenticeshipApplicationViewModel);
            var viewModel = response.ViewModel;

            ModelState.Clear();

            if (response.Message != null)
            {
                SetUserMessage(response.Message);
            }

            switch (response.Code)
            {
                case ApprenticeshipApplicationMediatorCodes.ReviewSaveAndContinue.Error:
                    return View("Review", response.ViewModel);

                case ApprenticeshipApplicationMediatorCodes.ReviewSaveAndContinue.FailedValidation:
                    response.ValidationResult.AddToModelStateWithSeverity(ModelState, string.Empty);
                    return RedirectToRoute(RecruitmentRouteNames.ReviewApprenticeshipApplication, viewModel);

                case ApprenticeshipApplicationMediatorCodes.ReviewSaveAndContinue.Ok:
                    return RedirectToRoute(RecruitmentRouteNames.VacancyApplications, viewModel.ApplicationSelection.RouteValues);

                default:
                    throw new InvalidMediatorCodeException(response.Code);
            }
        }

        [HttpGet]
        public async Task<ActionResult> ConfirmSuccessfulDecision(ApplicationSelectionViewModel applicationSelectionViewModel)
        {
            var response = await _apprenticeshipApplicationMediator.ConfirmSuccessfulDecision(applicationSelectionViewModel);

            switch (response.Code)
            {
                case ApprenticeshipApplicationMediatorCodes.ConfirmSuccessfulDecision.Ok:
                    return View(response.ViewModel);

                case ApprenticeshipApplicationMediatorCodes.ConfirmSuccessfulDecision.NoApplicationId:
                    SetUserMessage(response.Message);
                    return RedirectToRoute(RecruitmentRouteNames.RecruitmentHome);

                default:
                    throw new InvalidMediatorCodeException(response.Code);
            }
        }

        [HttpPost]
        [MultipleFormActionsButton(SubmitButtonActionName = "SendSuccessfulDecision")]
        public async Task<ActionResult> SendSuccessfulDecision(ApprenticeshipApplicationViewModel apprenticeshipApplicationViewModel, string applicationIds)
        {
            var response = await _apprenticeshipApplicationMediator.SendSuccessfulDecision(apprenticeshipApplicationViewModel.ApplicationSelection);
            ConfirmationStatusViewModel confirmationStatusViewModel = new ConfirmationStatusViewModel()
            {
                CustomMessage = response.ViewModel.ConfirmationStatusSentMessage + response.ViewModel.ApplicantDetails.Name,
                VacancyReferenceNumber = response.ViewModel.Vacancy.VacancyReferenceNumber
            };
            switch (response.Code)
            {
                case ApprenticeshipApplicationMediatorCodes.SendSuccessfulDecision.Ok:
                    return View("SentDecisionConfirmation", confirmationStatusViewModel);
                default:
                    throw new InvalidMediatorCodeException(response.Code);
            }
        }

        [HttpGet]
        public async Task<ActionResult> ConfirmUnsuccessfulDecision(ApplicationSelectionViewModel applicationSelectionViewModel)
        {
            var response = await _apprenticeshipApplicationMediator.ConfirmUnsuccessfulDecision(applicationSelectionViewModel);
            switch (response.Code)
            {
                case ApprenticeshipApplicationMediatorCodes.ConfirmUnsuccessfulDecision.Ok:
                    return View(response.ViewModel);

                case ApprenticeshipApplicationMediatorCodes.ConfirmUnsuccessfulDecision.NoApplicationId:
                    SetUserMessage(response.Message);
                    return RedirectToRoute(RecruitmentRouteNames.RecruitmentHome);

                default:
                    throw new InvalidMediatorCodeException(response.Code);
            }
        }

        [HttpPost]
        [MultipleFormActionsButton(SubmitButtonActionName = "SendUnsuccessfulDecision")]
        public async Task<ActionResult> SendUnsuccessfulDecision(ApprenticeshipApplicationViewModel apprenticeshipApplicationViewModel)
        {
            var response = await _apprenticeshipApplicationMediator.SendUnsuccessfulDecision(apprenticeshipApplicationViewModel);
            ConfirmationStatusViewModel confirmationStatusViewModel = new ConfirmationStatusViewModel()
            {
                CustomMessage = response.ViewModel.ConfirmationStatusSentMessage + response.ViewModel.ApplicantDetails.Name,
                VacancyReferenceNumber = response.ViewModel.Vacancy.VacancyReferenceNumber
            };
            switch (response.Code)
            {
                case ApprenticeshipApplicationMediatorCodes.SendUnsuccessfulDecision.Ok:
                    return View("SentDecisionConfirmation", confirmationStatusViewModel);

                default:
                    throw new InvalidMediatorCodeException(response.Code);
            }
        }

        [HttpGet]
        public async Task<ActionResult> ConfirmRevertToInProgress(ApplicationSelectionViewModel applicationSelectionViewModel)
        {
            var response = await _apprenticeshipApplicationMediator.ConfirmRevertToInProgress(applicationSelectionViewModel);

            switch (response.Code)
            {
                case ApprenticeshipApplicationMediatorCodes.ConfirmRevertToInProgress.Ok:
                    return View(response.ViewModel);

                case ApprenticeshipApplicationMediatorCodes.ConfirmRevertToInProgress.NoApplicationId:
                    SetUserMessage(response.Message);
                    return RedirectToRoute(RecruitmentRouteNames.RecruitmentHome);

                default:
                    throw new InvalidMediatorCodeException(response.Code);
            }
        }

        [HttpPost]
        [MultipleFormActionsButton(SubmitButtonActionName = "RevertToInProgress")]
        public async Task<ActionResult> RevertToInProgress(ApprenticeshipApplicationViewModel apprenticeshipApplicationViewModel)
        {
            var response = await _apprenticeshipApplicationMediator.RevertToInProgress(apprenticeshipApplicationViewModel.ApplicationSelection);

            switch (response.Code)
            {
                case ApprenticeshipApplicationMediatorCodes.RevertToInProgress.Ok:
                    if (response.Message != null)
                    {
                        SetUserMessage(response.Message.Text);
                    }

                    return RedirectToRoute(RecruitmentRouteNames.VacancyApplications, response.ViewModel.RouteValues);

                default:
                    throw new InvalidMediatorCodeException(response.Code);
            }
        }
    }
}
