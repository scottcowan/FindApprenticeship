﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SFA.Apprenticeships.Web.Candidate.Views.ApprenticeshipSearch
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Text;
    using System.Web;
    using System.Web.Helpers;
    using System.Web.Mvc;
    using System.Web.Mvc.Ajax;
    using System.Web.Mvc.Html;
    using System.Web.Optimization;
    using System.Web.Routing;
    using System.Web.Security;
    using System.Web.UI;
    using System.Web.WebPages;
    
    #line 1 "..\..\Views\ApprenticeshipSearch\Results.cshtml"
    using SFA.Apprenticeships.Application.Interfaces.Vacancies;
    
    #line default
    #line hidden
    
    #line 2 "..\..\Views\ApprenticeshipSearch\Results.cshtml"
    using SFA.Apprenticeships.Domain.Entities.Vacancies;
    
    #line default
    #line hidden
    using SFA.Apprenticeships.Infrastructure.Presentation;
    using SFA.Apprenticeships.Web.Candidate;
    using SFA.Apprenticeships.Web.Candidate.Constants;
    using SFA.Apprenticeships.Web.Candidate.Constants.ViewModels;
    
    #line 3 "..\..\Views\ApprenticeshipSearch\Results.cshtml"
    using SFA.Apprenticeships.Web.Candidate.Extensions;
    
    #line default
    #line hidden
    using SFA.Apprenticeships.Web.Candidate.Helpers;
    using SFA.Apprenticeships.Web.Candidate.ViewModels;
    using SFA.Apprenticeships.Web.Candidate.ViewModels.Candidate;
    using SFA.Apprenticeships.Web.Candidate.ViewModels.Login;
    using SFA.Apprenticeships.Web.Candidate.ViewModels.Register;
    using SFA.Apprenticeships.Web.Candidate.ViewModels.VacancySearch;
    using SFA.Apprenticeships.Web.Common.Constants;
    using SFA.Apprenticeships.Web.Common.Framework;
    using SFA.Apprenticeships.Web.Common.Models.Common;
    using SFA.Apprenticeships.Web.Common.ViewModels.Locations;
    using SFA.Apprenticeships.Web.Common.Views.Shared.DisplayTemplates;
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/ApprenticeshipSearch/Results.cshtml")]
    public partial class Results : System.Web.Mvc.WebViewPage<ApprenticeshipSearchResponseViewModel>
    {
        public Results()
        {
        }
        public override void Execute()
        {
WriteLiteral("\r\n");

            
            #line 7 "..\..\Views\ApprenticeshipSearch\Results.cshtml"
  
    ViewBag.Title = "Results - Find an apprenticeship";
    Layout = "~/Views/Shared/_Layout.cshtml";

    //Any copy changes here also need reflected in the resultsSearch.js file.
    var locationTypeLink = Model.VacancySearch.LocationType == VacancyLocationType.National 
            ? Url.ApprenticeshipSearchViewModelRouteUrl(CandidateRouteNames.ApprenticeshipResults, new ApprenticeshipSearchViewModel(Model.VacancySearch) {LocationType = VacancyLocationType.NonNational, SearchAction = SearchAction.LocationTypeChanged, PageNumber = 1}) 
            : Url.ApprenticeshipSearchViewModelRouteUrl(CandidateRouteNames.ApprenticeshipResults, new ApprenticeshipSearchViewModel(Model.VacancySearch) {LocationType = VacancyLocationType.National, SearchAction = SearchAction.LocationTypeChanged, SortType = VacancySearchSortType.Distance, PageNumber = 1});

    string resultMessage;
    string nationalResultsMessage = "";

    if (Model.TotalLocalHits == 0)
    {
        resultMessage = "";
    }
    else if (Model.TotalLocalHits == 1)
    {
        if (Model.VacancySearch.LocationType == VacancyLocationType.National)
        {
            resultMessage = "We've found <b class=\"bold-medium\">1</b> <a id='localLocationTypeLink' class='update-results' href=" + locationTypeLink + ">apprenticeship in your selected area</a>.";
        }
        else
        {
            resultMessage = "We've found <b class=\"bold-medium\">1</b> apprenticeship in your selected area.";
        }
    }
    else
    {
        if (Model.VacancySearch.LocationType == VacancyLocationType.National)
        {
            var message = "We've found <b class=\"bold-medium\">{0}</b> <a id='localLocationTypeLink' class='update-results' href=" + locationTypeLink + ">apprenticeships in your selected area</a>.";
            resultMessage = string.Format(message, Model.TotalLocalHits);
        }
        else
        {
            resultMessage = string.Format("We've found <b class=\"bold-medium\">{0}</b> apprenticeships in your selected area.", Model.TotalLocalHits);
        }
    }

    if (Model.TotalNationalHits != 0)
    {
        if (Model.TotalLocalHits == 0)
        {
            resultMessage = "There are currently no matching apprenticeships in your selected area.";
            nationalResultsMessage = string.Format("We've found {0} apprenticeships with positions elsewhere in England.", Model.TotalNationalHits);
        }
        else if (Model.TotalNationalHits == 1)
        {
            if (Model.VacancySearch.LocationType == VacancyLocationType.NonNational)
            {
                nationalResultsMessage = string.Format("We've also found <a id='nationwideLocationTypeLink' class='update-results' href={0}>1 apprenticeship with positions elsewhere in England</a>.", locationTypeLink);
            }
            else
            {
                nationalResultsMessage = "We've also found 1 apprenticeship with positions elsewhere in England.";
            }
        }
        else
        {
            if (Model.VacancySearch.LocationType == VacancyLocationType.NonNational)
            {
                nationalResultsMessage = string.Format("We've also found <a id='nationwideLocationTypeLink' class='update-results' href={1}>{0} apprenticeships with positions elsewhere in England</a>.", Model.TotalNationalHits, locationTypeLink);
            }
            else
            {
                nationalResultsMessage = string.Format("We've also found {0} apprenticeships with positions elsewhere in England.", Model.TotalNationalHits);
            }
        }
    }

            
            #line default
            #line hidden
WriteLiteral("\r\n\r\n");

DefineSection("metatags", () => {

WriteLiteral("\r\n    ");

WriteLiteral("\r\n    <meta");

WriteLiteral(" name=\"WT.oss_r\"");

WriteAttribute("content", Tuple.Create(" content=\"", 3996), Tuple.Create("\"", 4027)
            
            #line 82 "..\..\Views\ApprenticeshipSearch\Results.cshtml"
, Tuple.Create(Tuple.Create("", 4006), Tuple.Create<System.Object, System.Int32>(Model.TotalLocalHits
            
            #line default
            #line hidden
, 4006), false)
);

WriteLiteral(" />\r\n");

});

WriteLiteral("\r\n<div");

WriteLiteral(" class=\"search-results-wrapper\"");

WriteLiteral(">\r\n    <div");

WriteLiteral(" class=\"sfa-xxlarge-bottom-margin grid-row\"");

WriteLiteral(">\r\n        <div");

WriteLiteral(" class=\"column-two-thirds\"");

WriteLiteral(">\r\n            <h1");

WriteLiteral(" class=\"heading-xlarge sfa-no-bottom-margin\"");

WriteLiteral(">Search results</h1>\r\n            <div");

WriteLiteral(" id=\"vacancy-result-summary\"");

WriteLiteral(">\r\n                <p");

WriteLiteral(" id=\"result-message\"");

WriteLiteral(" class=\"sfa-small-bottom-margin\"");

WriteLiteral(">");

            
            #line 90 "..\..\Views\ApprenticeshipSearch\Results.cshtml"
                                                                  Write(Html.Raw(resultMessage));

            
            #line default
            #line hidden
WriteLiteral("</p>\r\n                <p");

WriteLiteral(" id=\"national-results-message\"");

WriteLiteral(" class=\"\"");

WriteLiteral(">");

            
            #line 91 "..\..\Views\ApprenticeshipSearch\Results.cshtml"
                                                     Write(Html.Raw(nationalResultsMessage));

            
            #line default
            #line hidden
WriteLiteral("</p>\r\n");

            
            #line 92 "..\..\Views\ApprenticeshipSearch\Results.cshtml"
                
            
            #line default
            #line hidden
            
            #line 92 "..\..\Views\ApprenticeshipSearch\Results.cshtml"
                 if (!string.IsNullOrEmpty(Model.VacancySearch.Location))
                {

            
            #line default
            #line hidden
WriteLiteral("                    <p");

WriteLiteral(" class=\"sfa-small-bottom-margin\"");

WriteLiteral(">\r\n                        <a");

WriteLiteral(" id=\"receiveSaveSearchAlert\"");

WriteAttribute("href", Tuple.Create("\r\n                           href=\"", 4702), Tuple.Create("\"", 4887)
            
            #line 96 "..\..\Views\ApprenticeshipSearch\Results.cshtml"
, Tuple.Create(Tuple.Create("", 4737), Tuple.Create<System.Object, System.Int32>(Url.ApprenticeshipSearchViewModelRouteUrl(CandidateRouteNames.ApprenticeshipSearchSaveSearch, new ApprenticeshipSearchViewModel(Model.VacancySearch))
            
            #line default
            #line hidden
, 4737), false)
);

WriteLiteral("\r\n                           onclick=\"Webtrends.multiTrack({ element: this, argsa" +
": [\'DCS.dcsuri\', \'/apprenticeships/receivealerts\', \'WT.dl\', \'99\', \'WT.ti\', \'Sear" +
"ch Results Receive Alerts\'] })\"");

WriteLiteral("><i");

WriteLiteral(" class=\"fa fa-bell-o\"");

WriteLiteral("></i>Receive alerts for this search</a>\r\n                    </p>\r\n");

            
            #line 99 "..\..\Views\ApprenticeshipSearch\Results.cshtml"
                }

            
            #line default
            #line hidden
WriteLiteral("            </div>\r\n        </div>\r\n    </div>\r\n    \r\n    <div");

WriteLiteral(" class=\"grid-row\"");

WriteLiteral(">\r\n");

            
            #line 105 "..\..\Views\ApprenticeshipSearch\Results.cshtml"
        
            
            #line default
            #line hidden
            
            #line 105 "..\..\Views\ApprenticeshipSearch\Results.cshtml"
         using (Html.BeginRouteForm(CandidateRouteNames.ApprenticeshipResults, FormMethod.Get))
        {
            Html.Partial("ValidationSummary", ViewData.ModelState);
            Html.RenderPartial("_searchUpdate", Model.VacancySearch);


            
            #line default
            #line hidden
WriteLiteral("            <section");

WriteLiteral(" class=\"column-two-thirds\"");

WriteLiteral(">\r\n                <div");

WriteLiteral(" id=\"pagedList\"");

WriteLiteral(">\r\n");

            
            #line 112 "..\..\Views\ApprenticeshipSearch\Results.cshtml"
                    
            
            #line default
            #line hidden
            
            #line 112 "..\..\Views\ApprenticeshipSearch\Results.cshtml"
                       Html.RenderPartial("_searchResults", Model); 
            
            #line default
            #line hidden
WriteLiteral("\r\n                </div>\r\n            </section>\r\n");

            
            #line 115 "..\..\Views\ApprenticeshipSearch\Results.cshtml"
         }

            
            #line default
            #line hidden
WriteLiteral("    </div>\r\n</div>\r\n\r\n<div");

WriteLiteral(" class=\"saving-prompt toggle-content hide-nojs\"");

WriteLiteral(" id=\"ajaxLoading\"");

WriteLiteral(">\r\n    Loading\r\n</div>\r\n\r\n");

DefineSection("scripts", () => {

WriteLiteral("\r\n");

WriteLiteral("    ");

            
            #line 125 "..\..\Views\ApprenticeshipSearch\Results.cshtml"
Write(Scripts.Render("~/bundles/nas/locationsearch"));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("    ");

            
            #line 126 "..\..\Views\ApprenticeshipSearch\Results.cshtml"
Write(Scripts.Render("~/bundles/nas/geoLocater"));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("    ");

            
            #line 127 "..\..\Views\ApprenticeshipSearch\Results.cshtml"
Write(Scripts.Render("~/bundles/cookie"));

            
            #line default
            #line hidden
WriteLiteral(" \r\n    <script>\r\n        var searchUrl = \'");

            
            #line 129 "..\..\Views\ApprenticeshipSearch\Results.cshtml"
                    Write(Url.RouteUrl(CandidateRouteNames.ApprenticeshipResults));

            
            #line default
            #line hidden
WriteLiteral("\';\r\n        var locationUrl = \'");

            
            #line 130 "..\..\Views\ApprenticeshipSearch\Results.cshtml"
                      Write(Url.RouteUrl(CandidateRouteNames.LocationSearch));

            
            #line default
            #line hidden
WriteLiteral("\';\r\n    </script>\r\n");

WriteLiteral("    ");

            
            #line 132 "..\..\Views\ApprenticeshipSearch\Results.cshtml"
Write(Scripts.Render("~/bundles/nas/results"));

            
            #line default
            #line hidden
WriteLiteral("\r\n    <script>\r\n        initSavedVacancies({\r\n            saveUrl:  \'");

            
            #line 135 "..\..\Views\ApprenticeshipSearch\Results.cshtml"
                  Write(Url.RouteUrl(CandidateRouteNames.ApprenticeshipSaveVacancy));

            
            #line default
            #line hidden
WriteLiteral("\',\r\n            deleteUrl: \'");

            
            #line 136 "..\..\Views\ApprenticeshipSearch\Results.cshtml"
                   Write(Url.RouteUrl(CandidateRouteNames.ApprenticeshipDeleteSavedVacancy));

            
            #line default
            #line hidden
WriteLiteral("\',\r\n            title: true});\r\n    </script>\r\n");

});

        }
    }
}
#pragma warning restore 1591
