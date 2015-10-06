﻿using SFA.Apprenticeships.Web.Manage.Constants;

namespace SFA.Apprenticeships.Web.Manage.Controllers
{
    using System;
    using System.Web;
    using System.Web.Mvc;
    using Common.Constants;
    using Common.Framework;
    using Constants.Messages;
    using Microsoft.Owin.Security;
    using Microsoft.Owin.Security.Cookies;
    using Microsoft.Owin.Security.WsFederation;
    using ControllerBase = Common.Controllers.ControllerBase;

    public class AccountController : ControllerBase
    {

        public void SignIn(string returnUrl)
        {
            if (returnUrl.IsValidReturnUrl())
            {
                UserData.Push(UserDataItemNames.ReturnUrl, Server.UrlEncode(returnUrl));
            }

            var properties = new AuthenticationProperties
            {
                RedirectUri = Url.RouteUrl(ManagementRouteNames.Authorize)
            };

            HttpContext.GetOwinContext().Authentication.Challenge(properties, WsFederationAuthenticationDefaults.AuthenticationType);
        }

        public void SignOut(string returnUrl)
        {
            SignOut(false, returnUrl);
        }

        public void SessionTimeout(string returnUrl)
        {
            SignOut(true, returnUrl);
        }

        public ActionResult SignOutCallback(bool timeout, string returnUrl)
        {
            if (Request.IsAuthenticated)
            {
                // Redirect to home page if the user is authenticated.
                return RedirectToRoute(ManagementRouteNames.LandingPage);
            }

            if (timeout)
            {
                SetUserMessage(AuthorizeMessages.SignedOutTimeout, UserMessageLevel.Info);
            }
            else
            {
                SetUserMessage(AuthorizeMessages.SignedOut, UserMessageLevel.Info);
            }

            return RedirectToRoute(ManagementRouteNames.LandingPage, new {returnUrl});
        }

        private void SignOut(bool timeout, string returnUrl)
        {
            var callbackUrl = Url.RouteUrl(ManagementRouteNames.SignOutCallback, new {timeout, returnUrl}, string.Copy(Request.Url?.Scheme ?? Constants.Url.DefaultScheme));

            var properties = new AuthenticationProperties
            {
                RedirectUri = callbackUrl
            };

            HttpContext.GetOwinContext().Authentication.SignOut(properties, WsFederationAuthenticationDefaults.AuthenticationType, CookieAuthenticationDefaults.AuthenticationType);
        }
    }
}