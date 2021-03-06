﻿namespace SFA.Apprenticeships.Web.Recruit.Controllers
{
    using Raa.Common.ViewModels.ProviderUser;
    using System.Security.Claims;
    using System.Web.Mvc;
    using Attributes;
    using Common.Attributes;
    using Common.Constants;
    using Common.Extensions;
    using Common.Framework;
    using Common.Mediators;
    using Common.Providers;
    using Constants;
    using Domain.Entities.Raa;
    using FluentValidation.Mvc;
    using Mediators.ProviderUser;
    using Application.Interfaces;
    using ViewModels;
    using SystemClaimTypes = System.Security.Claims.ClaimTypes;

    [OwinSessionTimeout]
    public class ProviderUserController : RecruitmentControllerBase
    {
        private readonly IProviderUserMediator _providerUserMediator;
        private readonly ICookieAuthorizationDataProvider _cookieAuthorizationDataProvider;

        public ProviderUserController(
            IProviderUserMediator providerUserMediator,
            ICookieAuthorizationDataProvider cookieAuthorizationDataProvider,
            IConfigurationService configurationService,
            ILogService logService)
            : base(configurationService, logService)
        {
            _providerUserMediator = providerUserMediator;
            _cookieAuthorizationDataProvider = cookieAuthorizationDataProvider;
        }

        public ActionResult Authorize()
        {
            //TODO: ACS Calls this action during signout. Need to suppress it in a cleaner manner
            if (!Request.IsAuthenticated)
            {
                return null;
            }

            var claimsPrincipal = (ClaimsPrincipal)User;
            var response = _providerUserMediator.Authorize(claimsPrincipal);
            var message = response.Message;
            var viewModel = response.ViewModel;

            //Clear existing claims
            _cookieAuthorizationDataProvider.Clear(HttpContext);

            //Add domain claims
            if (viewModel.EmailAddress != null)
            {
                AddClaim(SystemClaimTypes.Email, viewModel.EmailAddress, viewModel);
            }

            if (viewModel.EmailAddressVerified)
            {
                AddClaim(SystemClaimTypes.Role, Roles.VerifiedEmail, viewModel);
            }

            if (message != null)
            {
                SetUserMessage(message.Text, message.Level);
            }

            switch (response.Code)
            {
                case ProviderUserMediatorCodes.Authorize.EmptyUsername:
                case ProviderUserMediatorCodes.Authorize.MissingProviderIdentifier:
                case ProviderUserMediatorCodes.Authorize.MissingServicePermission:
                    _cookieAuthorizationDataProvider.Clear(HttpContext);

                    return RedirectToRoute(RecruitmentRouteNames.SignOut, new
                    {
                        returnRoute = RecruitmentRouteNames.LandingPage
                    });

                case ProviderUserMediatorCodes.Authorize.NoProviderProfile:
                case ProviderUserMediatorCodes.Authorize.FailedMinimumSitesCountCheck:
                case ProviderUserMediatorCodes.Authorize.FirstUser:
                    return RedirectToRoute(RecruitmentRouteNames.ManageProviderSites);

                case ProviderUserMediatorCodes.Authorize.NoUserProfile:
                    return RedirectToRoute(RecruitmentRouteNames.Settings);

                case ProviderUserMediatorCodes.Authorize.EmailAddressNotVerified:
                    return RedirectToRoute(RecruitmentRouteNames.VerifyEmail);

                case ProviderUserMediatorCodes.Authorize.Ok:
                    var returnUrl = UserData.Pop(UserDataItemNames.ReturnUrl);

                    if (returnUrl.IsValidReturnUrl())
                    {
                        var decodedUrl = Server.UrlDecode(returnUrl);
                        if (decodedUrl != null)
                        {
                            decodedUrl = decodedUrl.Replace("&amp;", "&");
                            return Redirect(decodedUrl.Replace("&amp;", "&"));
                        }
                    }

                    return RedirectToRoute(RecruitmentRouteNames.RecruitmentHome);
                case ProviderUserMediatorCodes.Authorize.ProviderNotMigrated:
                    return RedirectToRoute(RecruitmentRouteNames.OnBoardingComplete);
                default:
                    throw new InvalidMediatorCodeException(response.Code);
            }
        }

        [HttpPost]
        public ActionResult AuthorizationError()
        {
            // This controller action is called when there is a serious ACS error (e.g. bad configuration, no claims etc.)
            var errorDetails = Request["ErrorDetails"];
            var viewModel = _providerUserMediator.AuthorizationError(errorDetails);

            return View(viewModel);
        }

        [HttpGet]
        [AuthorizeUser(Roles = Roles.Faa)]
        [AuthorizeUser(Roles = Roles.VerifiedEmail)]
        public ActionResult Home(VacanciesSummarySearchViewModel vacanciesSummarySearch)
        {
            var response = _providerUserMediator.GetHomeViewModel(User.Identity.Name, User.GetUkprn(), vacanciesSummarySearch);

            ModelState.Clear();

            if (response.Message != null)
            {
                SetUserMessage(response.Message.Text, response.Message.Level);
            }

            switch (response.Code)
            {
                case ProviderUserMediatorCodes.GetHomeViewModel.ProviderNotFound:
                case ProviderUserMediatorCodes.GetHomeViewModel.Error:
                    return View("HomeError", response.ViewModel);

                case ProviderUserMediatorCodes.GetHomeViewModel.Ok:
                    return View(response.ViewModel);

                default:
                    throw new InvalidMediatorCodeException(response.Code);
            }
        }

        [HttpPost]
        [AuthorizeUser(Roles = Roles.Faa)]
        [AuthorizeUser(Roles = Roles.VerifiedEmail)]
        [MultipleFormActionsButton(SubmitButtonActionName = "ChangeProviderSiteAction")]
        public ActionResult ChangeProviderSite(HomeViewModel viewModel)
        {
            var response = _providerUserMediator.ChangeProviderSite(User.Identity.Name, User.GetUkprn(), viewModel);

            switch (response.Code)
            {
                case ProviderUserMediatorCodes.ChangeProviderSite.Ok:
                    return RedirectToRoute(RecruitmentRouteNames.RecruitmentHome);

                default:
                    throw new InvalidMediatorCodeException(response.Code);
            }
        }

        [HttpPost]
        [AuthorizeUser(Roles = Roles.Faa)]
        [AuthorizeUser(Roles = Roles.VerifiedEmail)]
        [MultipleFormActionsButton(SubmitButtonActionName = "SearchVacanciesAction")]
        public ActionResult SearchVacancies(HomeViewModel viewModel)
        {
            return RedirectToRoute(RecruitmentRouteNames.RecruitmentHome, viewModel.VacanciesSummary.VacanciesSummarySearch.RouteValues);
        }

        [HttpPost]
        [AuthorizeUser(Roles = Roles.Faa)]
        [AuthorizeUser(Roles = Roles.VerifiedEmail)]
        [MultipleFormActionsButton(SubmitButtonActionName = "SearchCandidatesAction")]
        public ActionResult SearchCandidates(HomeViewModel viewModel)
        {
            return RedirectToRoute(RecruitmentRouteNames.SearchCandidates, viewModel.CandidateSearch);
        }

        [HttpPost]
        [AuthorizeUser(Roles = Roles.Faa)]
        [AuthorizeUser(Roles = Roles.VerifiedEmail)]
        [MultipleFormActionsButton(SubmitButtonActionName = "NewVacancyAction")]
        public ActionResult NewVacancy(HomeViewModel viewModel)
        {
            var response = _providerUserMediator.ChangeProviderSite(User.Identity.Name, User.GetUkprn(), viewModel);

            switch (response.Code)
            {
                case ProviderUserMediatorCodes.ChangeProviderSite.Ok:
                    return RedirectToRoute(RecruitmentRouteNames.SelectExistingEmployer, new { providerSiteId = viewModel.ProviderUserViewModel.DefaultProviderSiteId });

                default:
                    throw new InvalidMediatorCodeException(response.Code);
            }
        }

        [HttpGet]
        [AuthorizeUser(Roles = Roles.Faa)]
        public ActionResult Settings()
        {
            var response = _providerUserMediator.GetSettingsViewModel(User.Identity.Name, User.GetUkprn());

            ModelState.Clear();

            if (response.Message != null)
            {
                SetUserMessage(response.Message.Text, response.Message.Level);
            }

            switch (response.Code)
            {
                case ProviderUserMediatorCodes.GetSettingsViewModel.ProviderNotFound:
                case ProviderUserMediatorCodes.GetSettingsViewModel.Error:
                    return View("SettingsError", response.ViewModel);

                case ProviderUserMediatorCodes.GetSettingsViewModel.Ok:
                    return View(response.ViewModel);

                default:
                    throw new InvalidMediatorCodeException(response.Code);
            }
        }

        [HttpPost]
        [AuthorizeUser(Roles = Roles.Faa)]
        public ActionResult Settings(SettingsViewModel settingsViewModel)
        {
            var response = _providerUserMediator.UpdateUser(User.Identity.Name, User.GetUkprn(), settingsViewModel.ProviderUserViewModel);

            ModelState.Clear();

            if (response.Message != null)
            {
                SetUserMessage(response.Message.Text, response.Message.Level);
            }

            switch (response.Code)
            {
                case ProviderUserMediatorCodes.UpdateUser.FailedValidation:
                    response.ValidationResult.AddToModelState(ModelState, string.Empty);
                    return View(response.ViewModel);

                case ProviderUserMediatorCodes.UpdateUser.EmailUpdated:
                    _cookieAuthorizationDataProvider.RemoveClaim(SystemClaimTypes.Role, Roles.VerifiedEmail, HttpContext, User.Identity.Name);
                    return RedirectToRoute(RecruitmentRouteNames.RecruitmentHome);

                case ProviderUserMediatorCodes.UpdateUser.AccountUpdated:
                case ProviderUserMediatorCodes.UpdateUser.Ok:
                    return RedirectToRoute(RecruitmentRouteNames.RecruitmentHome);

                default:
                    throw new InvalidMediatorCodeException(response.Code);
            }
        }

        [HttpGet]
        [AuthorizeUser(Roles = Roles.Faa)]
        public ActionResult VerifyEmail()
        {
            var response = _providerUserMediator.GetVerifyEmailViewModel(User.Identity.Name);

            if (response.Message != null)
            {
                SetUserMessage(response.Message.Text, response.Message.Level);
            }

            switch (response.Code)
            {
                case ProviderUserMediatorCodes.GetVerifyEmailViewModel.NoUserProfile:
                    return RedirectToRoute(RecruitmentRouteNames.Settings);
                case ProviderUserMediatorCodes.GetVerifyEmailViewModel.Ok:
                    return View(response.ViewModel);

                default:
                    throw new InvalidMediatorCodeException(response.Code);
            }
        }

        [HttpPost]
        [AuthorizeUser(Roles = Roles.Faa)]
        public ActionResult VerifyEmail(VerifyEmailViewModel verifyEmailViewModel)
        {
            var response = _providerUserMediator.VerifyEmailAddress(User.Identity.Name, verifyEmailViewModel);

            ModelState.Clear();

            switch (response.Code)
            {
                case ProviderUserMediatorCodes.VerifyEmailAddress.FailedValidation:
                    response.ValidationResult.AddToModelState(ModelState, string.Empty);
                    return View(verifyEmailViewModel);
                case ProviderUserMediatorCodes.VerifyEmailAddress.InvalidCode:
                    SetUserMessage(response.Message.Text, response.Message.Level);
                    return View(verifyEmailViewModel);
                case ProviderUserMediatorCodes.VerifyEmailAddress.OkNotYetMigrated:
                    _cookieAuthorizationDataProvider.AddClaim(new Claim(SystemClaimTypes.Role, Roles.VerifiedEmail), HttpContext, User.Identity.Name);
                    return RedirectToRoute(RecruitmentRouteNames.OnBoardingComplete);
                case ProviderUserMediatorCodes.VerifyEmailAddress.Ok:
                    _cookieAuthorizationDataProvider.AddClaim(new Claim(SystemClaimTypes.Role, Roles.VerifiedEmail), HttpContext, User.Identity.Name);
                    return RedirectToRoute(RecruitmentRouteNames.RecruitmentHome);
                default:
                    throw new InvalidMediatorCodeException(response.Code);
            }
        }

        [AuthorizeUser(Roles = Roles.Faa)]
        public ActionResult ResendVerificationCode()
        {
            var response = _providerUserMediator.ResendVerificationCode(User.Identity.Name);
            var verifyEmailViewModel = response.ViewModel;
            var message = response.Message;

            if (message != null)
            {
                SetUserMessage(message.Text, message.Level);
            }

            return View("VerifyEmail", verifyEmailViewModel);
        }

        [HttpGet]
        [AuthorizeUser(Roles = Roles.Faa)]
        [AuthorizeUser(Roles = Roles.VerifiedEmail)]
        public ActionResult OnBoardingComplete()
        {
            return View();
        }
        
        [HttpGet]
        [AuthorizeUser(Roles = Roles.Faa)]
        [AuthorizeUser(Roles = Roles.VerifiedEmail)]
        public ActionResult DismissReleaseNotes(int version)
        {
            _providerUserMediator.DismissReleaseNotes(User.Identity.Name, version);

            return RedirectToRoute(RecruitmentRouteNames.RecruitmentHome);
        }

        #region Helpers

        private void AddClaim(string type, string value, AuthorizeResponseViewModel viewModel)
        {
            var claim = new Claim(type, value);

            _cookieAuthorizationDataProvider.AddClaim(claim, HttpContext, viewModel.Username);
        }

        #endregion
    }
}