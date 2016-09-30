﻿namespace SFA.Apprenticeships.Web.Manage.Controllers
{
    using System;
    using System.Web.Mvc;
    using Application.Interfaces;
    using Attributes;
    using Common.Attributes;
    using Common.Mediators;
    using Constants;
    using Domain.Entities.Raa;
    using FluentValidation.Mvc;
    using Mediators.Admin;
    using Raa.Common.ViewModels.Api;
    using Raa.Common.ViewModels.Provider;

    [AuthorizeUser(Roles = Roles.Raa)]
    [AuthorizeUser(Roles = Roles.Admin)]
    public class AdminController : ManagementControllerBase
    {
        private readonly IAdminMediator _adminMediator;

        public AdminController(IAdminMediator adminMediator, IConfigurationService configurationService, ILogService loggingService) : base(configurationService, loggingService)
        {
            _adminMediator = adminMediator;
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Providers(ProviderSearchViewModel viewModel)
        {
            var response = _adminMediator.SearchProviders(viewModel);

            ModelState.Clear();

            switch (response.Code)
            {
                case AdminMediatorCodes.SearchProviders.FailedValidation:
                    response.ValidationResult.AddToModelState(ModelState, "SearchViewModel");
                    return View(response.ViewModel);

                case AdminMediatorCodes.SearchProviders.Ok:
                    return View(response.ViewModel);

                default:
                    throw new InvalidMediatorCodeException(response.Code);
            }
        }

        [HttpPost]
        [MultipleFormActionsButton(SubmitButtonActionName = "SearchProvidersAction")]
        public ActionResult SearchProviders(ProviderSearchResultsViewModel viewModel)
        {
            viewModel.SearchViewModel.PerformSearch = true;
            return RedirectToRoute(ManagementRouteNames.AdminProviders, viewModel.SearchViewModel);
        }

        [HttpGet]
        public ActionResult Provider(int providerId)
        {
            var response = _adminMediator.GetProvider(providerId);

            return View(response.ViewModel);
        }

        [HttpGet]
        public ActionResult CreateProvider()
        {
            return View(new ProviderViewModel());
        }

        [HttpPost]
        [MultipleFormActionsButton(SubmitButtonActionName = "CreateProviderAction")]
        public ActionResult CreateProvider(ProviderViewModel viewModel)
        {
            var response = _adminMediator.CreateProvider(viewModel);

            ModelState.Clear();

            SetUserMessage(response.Message);

            switch (response.Code)
            {
                case AdminMediatorCodes.CreateProvider.FailedValidation:
                    response.ValidationResult.AddToModelState(ModelState, "SearchViewModel");
                    return View(response.ViewModel);

                case AdminMediatorCodes.CreateProvider.UkprnAlreadyExists:
                    return View(response.ViewModel);

                case AdminMediatorCodes.CreateProvider.Ok:
                    return View(response.ViewModel);

                default:
                    throw new InvalidMediatorCodeException(response.Code);
            }
        }

        [HttpGet]
        public ActionResult ProviderSites(ProviderSiteSearchViewModel viewModel)
        {
            var response = _adminMediator.SearchProviderSites(viewModel);

            ModelState.Clear();

            switch (response.Code)
            {
                case AdminMediatorCodes.SearchProviderSites.FailedValidation:
                    response.ValidationResult.AddToModelState(ModelState, "SearchViewModel");
                    return View(response.ViewModel);

                case AdminMediatorCodes.SearchProviderSites.Ok:
                    return View(response.ViewModel);

                default:
                    throw new InvalidMediatorCodeException(response.Code);
            }
        }

        [HttpPost]
        [MultipleFormActionsButton(SubmitButtonActionName = "SearchProviderSitesAction")]
        public ActionResult SearchProviderSites(ProviderSiteSearchResultsViewModel viewModel)
        {
            viewModel.SearchViewModel.PerformSearch = true;
            return RedirectToRoute(ManagementRouteNames.AdminProviderSites, viewModel.SearchViewModel);
        }

        [HttpGet]
        public ActionResult ProviderSite(int providerSiteId)
        {
            var response = _adminMediator.GetProviderSite(providerSiteId);

            return View(response.ViewModel);
        }

        [HttpGet]
        public ActionResult CreateProviderSite(int providerId)
        {
            return View(new ProviderSiteViewModel { ProviderId = providerId });
        }

        [HttpPost]
        [MultipleFormActionsButton(SubmitButtonActionName = "CreateProviderSiteAction")]
        public ActionResult CreateProviderSite(ProviderSiteViewModel viewModel)
        {
            var response = _adminMediator.CreateProviderSite(viewModel);

            ModelState.Clear();

            SetUserMessage(response.Message);

            switch (response.Code)
            {
                case AdminMediatorCodes.CreateProviderSite.FailedValidation:
                    response.ValidationResult.AddToModelState(ModelState, "SearchViewModel");
                    return View(response.ViewModel);

                case AdminMediatorCodes.CreateProviderSite.EdsUrnAlreadyExists:
                    return View(response.ViewModel);

                case AdminMediatorCodes.CreateProviderSite.Ok:
                    return RedirectToRoute(ManagementRouteNames.AdminViewProvider, new {viewModel.ProviderId});

                default:
                    throw new InvalidMediatorCodeException(response.Code);
            }
        }

        [HttpPost]
        [MultipleFormActionsButton(SubmitButtonActionName = "SaveProviderSiteAction")]
        public ActionResult SaveProviderSite(ProviderSiteViewModel viewModel)
        {
            var response = _adminMediator.SaveProviderSite(viewModel);

            ModelState.Clear();

            SetUserMessage(response.Message);

            switch (response.Code)
            {
                case AdminMediatorCodes.SaveProviderSite.FailedValidation:
                    response.ValidationResult.AddToModelState(ModelState, "SearchViewModel");
                    return View("ProviderSite", response.ViewModel);

                case AdminMediatorCodes.SaveProviderSite.Error:
                    return RedirectToRoute(ManagementRouteNames.AdminViewProviderSite, new { viewModel.ProviderSiteId });

                case AdminMediatorCodes.SaveProviderSite.Ok:
                    return RedirectToRoute(ManagementRouteNames.AdminViewProviderSite, new { viewModel.ProviderSiteId });

                default:
                    throw new InvalidMediatorCodeException(response.Code);
            }
        }

        [HttpPost]
        [MultipleFormActionsButton(SubmitButtonActionName = "CreateProviderSiteRelationshipAction")]
        public ActionResult CreateProviderSiteRelationship(ProviderSiteViewModel viewModel)
        {
            var response = _adminMediator.CreateProviderSiteRelationship(viewModel);

            ModelState.Clear();

            SetUserMessage(response.Message);

            switch (response.Code)
            {
                case AdminMediatorCodes.CreateProviderSiteRelationship.FailedValidation:
                    response.ValidationResult.AddToModelState(ModelState, "SearchViewModel");
                    return View("ProviderSite", response.ViewModel);

                case AdminMediatorCodes.CreateProviderSiteRelationship.InvalidUkprn:
                    return RedirectToRoute(ManagementRouteNames.AdminViewProviderSite, new { viewModel.ProviderSiteId });

                case AdminMediatorCodes.CreateProviderSiteRelationship.Error:
                    return RedirectToRoute(ManagementRouteNames.AdminViewProviderSite, new { viewModel.ProviderSiteId });

                case AdminMediatorCodes.CreateProviderSiteRelationship.Ok:
                    return RedirectToRoute(ManagementRouteNames.AdminViewProviderSite, new { viewModel.ProviderSiteId });

                default:
                    throw new InvalidMediatorCodeException(response.Code);
            }
        }

        [HttpGet]
        public ActionResult ApiUsers(ApiUserSearchViewModel viewModel)
        {
            var response = _adminMediator.SearchApiUsers(viewModel);

            ModelState.Clear();

            switch (response.Code)
            {
                case AdminMediatorCodes.SearchApiUsers.FailedValidation:
                    response.ValidationResult.AddToModelState(ModelState, "SearchViewModel");
                    return View(response.ViewModel);

                case AdminMediatorCodes.SearchApiUsers.Ok:
                    return View(response.ViewModel);

                default:
                    throw new InvalidMediatorCodeException(response.Code);
            }
        }

        [HttpPost]
        [MultipleFormActionsButton(SubmitButtonActionName = "SearchApiUsersAction")]
        public ActionResult SearchApiUsers(ApiUserSearchResultsViewModel viewModel)
        {
            viewModel.SearchViewModel.PerformSearch = true;
            return RedirectToRoute(ManagementRouteNames.AdminApiUsers, viewModel.SearchViewModel);
        }

        [HttpGet]
        public ActionResult ApiUser(Guid externalSystemId)
        {
            var response = _adminMediator.GetApiUser(externalSystemId);

            return View(response.ViewModel);
        }
    }
}