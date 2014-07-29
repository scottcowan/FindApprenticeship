﻿namespace SFA.Apprenticeships.Web.Candidate.Controllers
{
    using System.Web.Mvc;
    using Common.Controllers;
    using Common.Providers;
    using Constants.ViewModels;
    using Domain.Entities.Users;
    using FluentValidation.Mvc;
    using NLog;
    using Providers;
    using Validators;
    using ViewModels.Login;

    // TODO: AG: US444: need to implement resend account unlock code somewhere.

    public class LoginController : SfaControllerBase
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        private readonly AccountUnlockViewModelServerValidator _accountUnlockViewModelServerValidator;
        private readonly ICandidateServiceProvider _candidateServiceProvider;
        private readonly LoginViewModelServerValidator _loginViewModelServerValidator;

        public LoginController(
            ISessionStateProvider session,
            IUserServiceProvider userServiceProvider,
            LoginViewModelServerValidator loginViewModelServerValidator,
            AccountUnlockViewModelServerValidator accountUnlockViewModelServerValidator,
            ICandidateServiceProvider candidateServiceProvider)
            : base(session, userServiceProvider)
        {
            _loginViewModelServerValidator = loginViewModelServerValidator;
            _accountUnlockViewModelServerValidator = accountUnlockViewModelServerValidator;
            _candidateServiceProvider = candidateServiceProvider;
        }

        [HttpGet]
        public ActionResult Index(string returnUrl)
        {
            if (!string.IsNullOrWhiteSpace(returnUrl))
            {
                UserServiceProvider.SetReturnUrlCookie(HttpContext, returnUrl);
            }

            return View();
        }

        [HttpPost]
        public ActionResult Index(LoginViewModel model)
        {
            // Validate view model.
            var validationResult = _loginViewModelServerValidator.Validate(model);

            if (!validationResult.IsValid)
            {
                ModelState.Clear();
                validationResult.AddToModelState(ModelState, string.Empty);

                return View(model);
            }

            // Authenticate candidate.
            var authenticated = _candidateServiceProvider.Authenticate(model);
            var userStatus = _candidateServiceProvider.GetUserStatus(model.EmailAddress);

            if (authenticated)
            {
                return RedirectOnAuthenticated(userStatus);
            }

            if (userStatus == UserStatuses.Locked)
            {
                return RedirectOnAccountLocked(model.EmailAddress);
            }

            // Authentication failed.
            ModelState.Clear();
            ModelState.AddModelError(
                "EmailAddress",
                LoginViewModelMessages.AuthenticationMessages.AuthenticationFailedErrorText);

            return View(model);
        }

        // TODO: AG: US444: consider renaming to Unlock.

        [HttpGet]
        public ActionResult AccountUnlock()
        {
            var emailAddress = TempData["EmailAddress"] as string;

            if (string.IsNullOrWhiteSpace(emailAddress))
            {
                return RedirectToAction("Index");
            }

            return View(new AccountUnlockViewModel
            {
                EmailAddress = emailAddress
            });
        }

        [HttpPost]
        public ActionResult AccountUnlock(AccountUnlockViewModel model)
        {
            // Validate view model.
            var validationResult = _accountUnlockViewModelServerValidator.Validate(model);

            if (!validationResult.IsValid)
            {
                ModelState.Clear();
                validationResult.AddToModelState(ModelState, string.Empty);

                return View(model);
            }

            var verified = _candidateServiceProvider.VerifyAccountUnlockCode(model);

            if (verified)
            {
                return RedirectOnAuthenticated(UserStatuses.Active);
            }

            // Verification failed.
            ModelState.Clear();
            ModelState.AddModelError(
                "AccountUnlockCode",
                AccountUnlockViewModelMessages.AccountUnlockCodeMessages.WrongAccountUnlockCodeErrorText);

            return View(model);
        }

        public ActionResult ResendAccountUnlockCode(string emailAddress)
        {
            var model = new AccountUnlockViewModel
            {
                EmailAddress = emailAddress
            };

            Logger.Debug("{0} requested account unlock code", model.EmailAddress);

            _candidateServiceProvider.RequestAccountUnlockCode(model);

            TempData["EmailAddress"] = model.EmailAddress;

            return RedirectToAction("AccountUnlock");
        }

        #region Helpers

        private ActionResult RedirectOnAuthenticated(UserStatuses userStatus)
        {
            if (userStatus == UserStatuses.PendingActivation)
            {
                return RedirectOnPendingActivation();
            }

            // Redirect to last viewed vacancy (if any).
            if (_candidateServiceProvider.LastViewedVacancyId.HasValue)
            {
                return RedirectToLastViewedVacancy(_candidateServiceProvider.LastViewedVacancyId.Value);
            }

            // Redirect to return URL (if any).
            var returnUrl = UserServiceProvider.GetReturnUrl(HttpContext);

            if (!string.IsNullOrWhiteSpace(returnUrl))
            {
                return RedirectToReturnUrl(returnUrl);
            }

            // TODO: redirect to candidate 'home' page.
            return RedirectToAction("Index", "VacancySearch");
        }

        private ActionResult RedirectToLastViewedVacancy(int lastViewedVacancyId)
        {
            // Clear last viewed vacancy.
            _candidateServiceProvider.LastViewedVacancyId = null;

            return RedirectToAction(
                "Details", "VacancySearch", new
                {
                    id = lastViewedVacancyId
                });
        }

        private ActionResult RedirectToReturnUrl(string returnUrl)
        {
            UserServiceProvider.DeleteReturnUrlCookie(HttpContext);

            return Redirect(returnUrl);
        }

        private ActionResult RedirectOnPendingActivation()
        {
            return RedirectToAction("Activation", "Register");
        }

        private ActionResult RedirectOnAccountLocked(string emailAddress)
        {
            TempData["EmailAddress"] = emailAddress;

            return RedirectToAction("AccountUnlock");
        }

        #endregion
    }
}
