﻿namespace SFA.Apprenticeships.Web.Candidate.Controllers
{
    using System;
    using System.Globalization;
    using System.Threading.Tasks;
    using System.Web.Mvc;
    using ActionResults;
    using Application.Interfaces.Vacancies;
    using Attributes;
    using Common.Constants;
    using Constants;
    using Domain.Entities.Vacancies.Apprenticeships;
    using Domain.Interfaces.Configuration;
    using FluentValidation.Mvc;
    using Mediators;
    using ViewModels.VacancySearch;

    public class ApprenticeshipSearchController : VacancySearchController
    {
        private readonly IApprenticeshipSearchMediator _apprenticeshipSearchMediator;

        public ApprenticeshipSearchController(IConfigurationManager configManager,
            IApprenticeshipSearchMediator apprenticeshipSearchMediator)
            : base(configManager)
        {
            _apprenticeshipSearchMediator = apprenticeshipSearchMediator;
        }

        [HttpGet]
        [OutputCache(CacheProfile = CacheProfiles.None)]
        [ApplyWebTrends]
        public async Task<ActionResult> Index()
        {
            return await Task.Run<ActionResult>(() =>
            {
                //Originally done in PopulateSortType
                ModelState.Remove("SortType");

                var response = _apprenticeshipSearchMediator.Index();

                return View(response.ViewModel);
            });
        }

        [HttpGet]
        [OutputCache(CacheProfile = CacheProfiles.None)]
        [ApplyWebTrends]
        public async Task<ActionResult> Results(ApprenticeshipSearchViewModel model)
        {
            return await Task.Run<ActionResult>(() =>
            {
                //TODO: DFSW Can we remove model state manipulation entirely? Where are these used?
                if ((model.LocationType == ApprenticeshipLocationType.NonNational && model.SortType == VacancySortType.Relevancy && string.IsNullOrWhiteSpace(model.Keywords)) ||
                    (model.LocationType == ApprenticeshipLocationType.National && string.IsNullOrWhiteSpace(model.Keywords) && model.SortType != VacancySortType.ClosingDate))
                {
                    ModelState.Remove("SortType");
                }

                var response = _apprenticeshipSearchMediator.Results(model);

                switch (response.Code)
                {
                    case Codes.ApprenticeshipSearch.Results.ValidationError:
                        ModelState.Clear();
                        response.ValidationResult.AddToModelState(ModelState, string.Empty);
                        return View(response.ViewModel);
                    case Codes.ApprenticeshipSearch.Results.HasError:
                        ModelState.Clear();
                        SetUserMessage(response.Message.Message, response.Message.Level);
                        return View(response.ViewModel);
                    case Codes.ApprenticeshipSearch.Results.Ok:
                        ModelState.Remove("Location");
                        ModelState.Remove("Latitude");
                        ModelState.Remove("Longitude");
                        return View(response.ViewModel);
                }

                throw new ArgumentException(string.Format("Mediator returned unrecognised code: {0}", response.Code));
            });
        }

        [HttpGet]
        [OutputCache(CacheProfile = CacheProfiles.None)]
        public async Task<ActionResult> DetailsWithDistance(int id, string distance)
        {
            return await Task.Run<ActionResult>(() =>
            {
                UserData.Push(UserDataItemNames.VacancyDistance, distance);
                UserData.Push(UserDataItemNames.LastViewedVacancyId, id.ToString(CultureInfo.InvariantCulture));

                return RedirectToRoute(CandidateRouteNames.ApprenticeshipDetails, new { id });
            });
        }

        [HttpGet]
        [OutputCache(CacheProfile = CacheProfiles.None)]
        [ApplyWebTrends]
        public async Task<ActionResult> Details(int id)
        {
            return await Task.Run<ActionResult>(() =>
            {
                var candidateId = GetCandidateId();

                var searchReturnUrl = GetSearchReturnUrl();
                
                var response = _apprenticeshipSearchMediator.Details(id, candidateId, searchReturnUrl);
                
                switch (response.Code)
                {
                    case Codes.ApprenticeshipSearch.Details.VacancyNotFound: 
                        return new VacancyNotFoundResult();
                    case Codes.ApprenticeshipSearch.Details.VacancyHasError:
                        ModelState.Clear();
                        SetUserMessage(response.Message.Message, response.Message.Level);
                        return View(response.ViewModel);
                    case Codes.ApprenticeshipSearch.Details.Ok:
                        return View(response.ViewModel);
                }

                throw new ArgumentException(string.Format("Mediator returned unrecognised code: {0}", response.Code));
            });
        }

        private Guid? GetCandidateId()
        {
            Guid? candidateId = null;

            if (Request.IsAuthenticated && UserContext != null)
            {
                candidateId = UserContext.CandidateId;
            }

            return candidateId;
        }

        private string GetSearchReturnUrl()
        {
            var urlHelper = new UrlHelper(ControllerContext.RequestContext);
            var url = urlHelper.RouteUrl(CandidateRouteNames.ApprenticeshipResults, null);
            if (Request != null && Request.UrlReferrer != null && Request.UrlReferrer.AbsolutePath == url)
                return Request.UrlReferrer.PathAndQuery;
            return null;
        }
    }
}