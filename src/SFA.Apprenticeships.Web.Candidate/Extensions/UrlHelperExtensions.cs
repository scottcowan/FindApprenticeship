﻿namespace SFA.Apprenticeships.Web.Candidate.Extensions
{
    using System.Web.Mvc;
    using Domain.Entities.Extensions;
    using ViewModels.VacancySearch;

    public static class UrlHelperExtensions
    {
        public static string ApprenticeshipSearchViewModelRouteUrl(this UrlHelper url, string routeName, ApprenticeshipSearchViewModel model)
        {
            var actionUrl = url.RouteUrl(routeName, model.RouteValues) + model.SubCategories.ToQueryString("SubCategories");
            return actionUrl;
        }
    }
}