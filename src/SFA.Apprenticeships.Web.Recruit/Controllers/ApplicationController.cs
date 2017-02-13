﻿namespace SFA.Apprenticeships.Web.Recruit.Controllers
{
    using Application.Interfaces;
    using Attributes;
    using Common.Attributes;
    using Common.Mediators;
    using Common.Validators.Extensions;
    using Constants;
    using Domain.Entities.Raa;
    using Domain.Raa.Interfaces.Repositories.Models;
    using FluentValidation.Mvc;
    using Mediators.Application;
    using Raa.Common.ViewModels.Application;
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Web.Mvc;

    [AuthorizeUser(Roles = Roles.Faa)]
    [AuthorizeUser(Roles = Roles.VerifiedEmail)]
    public class ApplicationController : RecruitmentControllerBase
    {
        private readonly IApplicationMediator _applicationMediator;

        public ApplicationController(IApplicationMediator applicationMediator, IConfigurationService configurationService,
            ILogService logService) : base(configurationService, logService)
        {
            _applicationMediator = applicationMediator;
        }

        [HttpGet]
        public async Task<ActionResult> VacancyApplications(VacancyApplicationsSearchViewModel vacancyApplicationsSearch)
        {
            var response = await _applicationMediator.GetVacancyApplicationsViewModel(vacancyApplicationsSearch);
            if (response.Message != null)
            {
                SetUserMessage(response.Message.Text, response.Message.Level);
            }
            switch (response.Code)
            {
                case ApplicationMediatorCodes.GetVacancyApplicationsViewModel.Ok:
                    return View(response.ViewModel);

                default:
                    throw new InvalidMediatorCodeException(response.Code);
            }
        }

        [HttpPost]
        public ActionResult VacancyApplications(VacancyApplicationsViewModel vacancyApplications)
        {
            return RedirectToRoute(RecruitmentRouteNames.VacancyApplications, vacancyApplications.VacancyApplicationsSearch.RouteValues);
        }

        [HttpGet]
        public async Task<ActionResult> ShareApplications(int vacancyReferenceNumber)
        {
            var response = await _applicationMediator.ShareApplications(vacancyReferenceNumber);

            switch (response.Code)
            {
                case ApplicationMediatorCodes.GetShareApplicationsViewModel.Ok:
                    return View(response.ViewModel);
                default:
                    throw new InvalidMediatorCodeException(response.Code);
            }
        }

        [HttpPost]
        public async Task<ActionResult> ShareApplications(ShareApplicationsViewModel viewModel)
        {
            var response = await _applicationMediator.ShareApplications(viewModel, Url);

            switch (response.Code)
            {
                case ApplicationMediatorCodes.ShareApplications.Ok:
                    SetUserMessage($"You have shared {response.ViewModel.SelectedApplicationIds.Count()} applications with {viewModel.RecipientEmailAddress}");
                    return View(response.ViewModel);
                case ApplicationMediatorCodes.ShareApplications.FailedValidation:
                    response.ValidationResult.AddToModelStateWithSeverity(ModelState, string.Empty);
                    return View(response.ViewModel);
                default:
                    throw new InvalidMediatorCodeException(response.Code);
            }
        }

        [HttpGet]
        public async Task<ActionResult> BulkDeclineCandidates(BulkDeclineCandidatesViewModel bulkDeclineCandidatesViewModel)
        {
            var response = await _applicationMediator.GetBulkDeclineCandidatesViewModel(bulkDeclineCandidatesViewModel);
            return View("BulkDeclineCandidates", response.ViewModel);
        }

        [HttpGet]
        public async Task<ActionResult> BulkDeclineCandidatesSearch(VacancyApplicationsSearchViewModel viewModel)
        {
            return await BulkDeclineCandidates(new BulkDeclineCandidatesViewModel() {VacancyApplicationsSearch = viewModel});
        }

        [HttpPost]
        [MultipleFormActionsButton(SubmitButtonActionName = "BulkSearchApplicationsAction")]
        public async Task<ActionResult> BulkFilterApplicationsAll(BulkDeclineCandidatesViewModel bulkDeclineCandidatesViewModel)
        {
            bulkDeclineCandidatesViewModel.VacancyApplicationsSearch.FilterType = VacancyApplicationsFilterTypes.All;
            return await BulkDeclineCandidates(bulkDeclineCandidatesViewModel);
        }

        [HttpPost]
        [MultipleFormActionsButton(SubmitButtonActionName = "BulkSearchApplicationsAction")]
        public async Task<ActionResult> BulkFilterApplicationsNew(BulkDeclineCandidatesViewModel bulkDeclineCandidatesViewModel)
        {
            bulkDeclineCandidatesViewModel.VacancyApplicationsSearch.FilterType = VacancyApplicationsFilterTypes.New;
            return await BulkDeclineCandidates(bulkDeclineCandidatesViewModel);
        }

        [HttpPost]
        [MultipleFormActionsButton(SubmitButtonActionName = "BulkSearchApplicationsAction")]
        public async Task<ActionResult> BulkFilterApplicationsInProgress(BulkDeclineCandidatesViewModel bulkDeclineCandidatesViewModel)
        {
            bulkDeclineCandidatesViewModel.VacancyApplicationsSearch.FilterType = VacancyApplicationsFilterTypes.InProgress;
            return await BulkDeclineCandidates(bulkDeclineCandidatesViewModel);
        }

        [HttpPost]
        [MultipleFormActionsButton(SubmitButtonActionName = "BulkOrderApplicationsAction")]
        public async Task<ActionResult> BulkOrderApplicationsLastName(BulkDeclineCandidatesViewModel bulkDeclineCandidatesViewModel)
        {
            bulkDeclineCandidatesViewModel.VacancyApplicationsSearch.OrderByField = VacancyApplicationsSearchViewModel.OrderByFieldLastName;
            bulkDeclineCandidatesViewModel.VacancyApplicationsSearch.Order = bulkDeclineCandidatesViewModel.VacancyApplicationsSearch.Order == Order.Ascending ? Order.Descending : Order.Ascending;
            return await BulkDeclineCandidates(bulkDeclineCandidatesViewModel);
        }

        [HttpPost]
        [MultipleFormActionsButton(SubmitButtonActionName = "BulkOrderApplicationsAction")]
        public async Task<ActionResult> BulkOrderApplicationsFirstName(BulkDeclineCandidatesViewModel bulkDeclineCandidatesViewModel)
        {
            bulkDeclineCandidatesViewModel.VacancyApplicationsSearch.OrderByField = VacancyApplicationsSearchViewModel.OrderByFieldFirstName;
            bulkDeclineCandidatesViewModel.VacancyApplicationsSearch.Order = bulkDeclineCandidatesViewModel.VacancyApplicationsSearch.Order == Order.Ascending ? Order.Descending : Order.Ascending;
            return await BulkDeclineCandidates(bulkDeclineCandidatesViewModel);
        }

        [HttpPost]
        [MultipleFormActionsButton(SubmitButtonActionName = "BulkOrderApplicationsAction")]
        public async Task<ActionResult> BulkOrderApplicationsManagerNotes(BulkDeclineCandidatesViewModel bulkDeclineCandidatesViewModel)
        {
            bulkDeclineCandidatesViewModel.VacancyApplicationsSearch.OrderByField = VacancyApplicationsSearchViewModel.OrderByFieldManagerNotes;
            bulkDeclineCandidatesViewModel.VacancyApplicationsSearch.Order = bulkDeclineCandidatesViewModel.VacancyApplicationsSearch.Order == Order.Ascending ? Order.Descending : Order.Ascending;
            return await BulkDeclineCandidates(bulkDeclineCandidatesViewModel);
        }

        [HttpPost]
        [MultipleFormActionsButton(SubmitButtonActionName = "BulkOrderApplicationsAction")]
        public async Task<ActionResult> BulkOrderApplicationsSubmitted(BulkDeclineCandidatesViewModel bulkDeclineCandidatesViewModel)
        {
            bulkDeclineCandidatesViewModel.VacancyApplicationsSearch.OrderByField = VacancyApplicationsSearchViewModel.OrderByFieldSubmitted;
            bulkDeclineCandidatesViewModel.VacancyApplicationsSearch.Order = bulkDeclineCandidatesViewModel.VacancyApplicationsSearch.Order == Order.Ascending ? Order.Descending : Order.Ascending;
            return await BulkDeclineCandidates(bulkDeclineCandidatesViewModel);
        }

        [HttpPost]
        [MultipleFormActionsButton(SubmitButtonActionName = "BulkOrderApplicationsAction")]
        public async Task<ActionResult> BulkOrderApplicationsStatus(BulkDeclineCandidatesViewModel bulkDeclineCandidatesViewModel)
        {
            bulkDeclineCandidatesViewModel.VacancyApplicationsSearch.OrderByField = VacancyApplicationsSearchViewModel.OrderByFieldStatus;
            bulkDeclineCandidatesViewModel.VacancyApplicationsSearch.Order = bulkDeclineCandidatesViewModel.VacancyApplicationsSearch.Order == Order.Ascending ? Order.Descending : Order.Ascending;
            return await BulkDeclineCandidates(bulkDeclineCandidatesViewModel);
        }

        [HttpPost]
        [MultipleFormActionsButton(SubmitButtonActionName = "ConfirmBulkDeclineCandidatesAction")]
        public async Task<ActionResult> ConfirmBulkDeclineCandidates(BulkDeclineCandidatesViewModel bulkDeclineCandidatesViewModel)
        {
            var response = await _applicationMediator.ConfirmBulkDeclineCandidates(bulkDeclineCandidatesViewModel);
            switch (response.Code)
            {
                case ApprenticeshipApplicationMediatorCodes.ConfirmBulkDeclineCandidates.Ok:
                    return View("ConfirmBulkUnsuccessfulDecision", response.ViewModel);
                case ApprenticeshipApplicationMediatorCodes.ConfirmBulkDeclineCandidates.FailedValidation:
                    response.ValidationResult.AddToModelState(ModelState, string.Empty);
                    return View("BulkDeclineCandidates", response.ViewModel);
                default:
                    throw new InvalidOperationException();
            }
        }

        [HttpPost]
        [MultipleFormActionsButton(SubmitButtonActionName = "EditBulkDeclineCandidatesAction")]
        public async Task<ActionResult> EditBulkDeclineCandidates(BulkDeclineCandidatesViewModel bulkDeclineCandidatesViewModel)
        {
            return await BulkDeclineCandidates(bulkDeclineCandidatesViewModel);
        }

        [HttpPost]
        [MultipleFormActionsButton(SubmitButtonActionName = "SendBulkUnsuccessfulDecisionAction")]
        public async Task<ActionResult> SendBulkUnsuccessfulDecision(BulkDeclineCandidatesViewModel bulkDeclineCandidatesViewModel)
        {
            bulkDeclineCandidatesViewModel.UnSuccessfulReasonRequired = true;
            var response = await _applicationMediator.SendBulkUnsuccessfulDecision(bulkDeclineCandidatesViewModel);
            switch (response.Code)
            {
                case ApprenticeshipApplicationMediatorCodes.SendBulkUnsuccessfulDecision.Ok:
                    {
                        return View("SentDecisionConfirmation", response.ViewModel);
                    }
                case ApprenticeshipApplicationMediatorCodes.SendBulkUnsuccessfulDecision.FailedValidation:
                    response.ValidationResult.AddToModelState(ModelState, string.Empty);
                    return View("ConfirmBulkUnsuccessfulDecision", response.ViewModel);
                default:
                    throw new InvalidMediatorCodeException(response.Code);
            }
        }
    }
}