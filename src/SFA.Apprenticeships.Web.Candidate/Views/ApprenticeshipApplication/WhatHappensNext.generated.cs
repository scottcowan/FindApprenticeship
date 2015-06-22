﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18444
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SFA.Apprenticeships.Web.Candidate.Views.ApprenticeshipApplication
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
    
    #line 1 "..\..\Views\ApprenticeshipApplication\WhatHappensNext.cshtml"
    using SFA.Apprenticeships.Domain.Entities.Applications;
    
    #line default
    #line hidden
    using SFA.Apprenticeships.Web.Candidate;
    using SFA.Apprenticeships.Web.Candidate.Constants;
    using SFA.Apprenticeships.Web.Candidate.Constants.ViewModels;
    
    #line 2 "..\..\Views\ApprenticeshipApplication\WhatHappensNext.cshtml"
    using SFA.Apprenticeships.Web.Candidate.Extensions;
    
    #line default
    #line hidden
    using SFA.Apprenticeships.Web.Candidate.Helpers;
    using SFA.Apprenticeships.Web.Candidate.ViewModels;
    using SFA.Apprenticeships.Web.Candidate.ViewModels.Candidate;
    using SFA.Apprenticeships.Web.Candidate.ViewModels.Locations;
    using SFA.Apprenticeships.Web.Candidate.ViewModels.Login;
    using SFA.Apprenticeships.Web.Candidate.ViewModels.Register;
    using SFA.Apprenticeships.Web.Candidate.ViewModels.VacancySearch;
    using SFA.Apprenticeships.Web.Common.Constants;
    using SFA.Apprenticeships.Web.Common.Framework;
    using SFA.Apprenticeships.Web.Common.Models.Common;
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/ApprenticeshipApplication/WhatHappensNext.cshtml")]
    public partial class WhatHappensNext : System.Web.Mvc.WebViewPage<SFA.Apprenticeships.Web.Candidate.ViewModels.Applications.WhatHappensNextApprenticeshipViewModel>
    {
        public WhatHappensNext()
        {
        }
        public override void Execute()
        {
            
            #line 4 "..\..\Views\ApprenticeshipApplication\WhatHappensNext.cshtml"
  
    ViewBag.Title = "Apprenticeship application submitted - Find an apprenticeship";
    Layout = "~/Views/Shared/_Layout.cshtml";

            
            #line default
            #line hidden
WriteLiteral("\r\n<div");

WriteLiteral(" class=\"progress-indicator progress-indicator-horizontal\"");

WriteLiteral(">\r\n    <ul>\r\n        <li><span");

WriteLiteral(" class=\"hide-tablet\"");

WriteLiteral(">Step </span>1<span");

WriteLiteral(" class=\"hide-tablet\"");

WriteLiteral("> of 3</span>. Application form</li>\r\n        <li><span");

WriteLiteral(" class=\"hide-tablet\"");

WriteLiteral(">Step </span>2<span");

WriteLiteral(" class=\"hide-tablet\"");

WriteLiteral("> of 3</span>. Check your application</li>\r\n        <li");

WriteLiteral(" class=\"active\"");

WriteLiteral("><span");

WriteLiteral(" class=\"hide-tablet\"");

WriteLiteral(">Step </span>3<span");

WriteLiteral(" class=\"hide-tablet\"");

WriteLiteral("> of 3</span>. Submitted</li>\r\n    </ul>\r\n</div>\r\n<div");

WriteLiteral(" class=\"success-banner\"");

WriteLiteral(" role=\"alert\"");

WriteLiteral(" aria-live=\"assertive\"");

WriteLiteral(">\r\n    <h1");

WriteLiteral(" class=\"heading-large no-btm-margin\"");

WriteLiteral("><i");

WriteLiteral(" class=\"fa fa-check\"");

WriteLiteral("></i>Apprenticeship application submitted</h1>\r\n</div>\r\n<section");

WriteLiteral(" class=\"section-border\"");

WriteLiteral(">\r\n    <div");

WriteLiteral(" class=\"text\"");

WriteLiteral(">\r\n        <p>\r\n            <i");

WriteLiteral(" class=\"fa fa-envelope-o\"");

WriteLiteral("></i>\r\n            We\'ve sent you an email confirming your <b>");

            
            #line 22 "..\..\Views\ApprenticeshipApplication\WhatHappensNext.cshtml"
                                                  Write(Html.DisplayFor(m => m.VacancyTitle));

            
            #line default
            #line hidden
WriteLiteral("</b> application.\r\n            You can also <a");

WriteLiteral(" title=\"Track the progress of your application\"");

WriteAttribute("href", Tuple.Create(" href=\"", 1293), Tuple.Create("\"", 1349)
            
            #line 23 "..\..\Views\ApprenticeshipApplication\WhatHappensNext.cshtml"
 , Tuple.Create(Tuple.Create("", 1300), Tuple.Create<System.Object, System.Int32>(Url.RouteUrl(CandidateRouteNames.MyApplications)
            
            #line default
            #line hidden
, 1300), false)
);

WriteLiteral(">track the progress</a> of your application.\r\n        </p>\r\n        <p>You’ll be " +
"contacted if you’ve been selected for the next stage of the application process." +
"</p>\r\n        <details>\r\n            <summary>Contact the provider</summary>\r\n  " +
"          <div");

WriteLiteral(" class=\"detail-content\"");

WriteLiteral(">");

            
            #line 28 "..\..\Views\ApprenticeshipApplication\WhatHappensNext.cshtml"
                                   Write(Model.ProviderContactInfo);

            
            #line default
            #line hidden
WriteLiteral("</div>\r\n        </details>\r\n    </div>\r\n</section>\r\n<section");

WriteLiteral(" class=\"section-border\"");

WriteLiteral(">\r\n    \r\n");

            
            #line 34 "..\..\Views\ApprenticeshipApplication\WhatHappensNext.cshtml"
    
            
            #line default
            #line hidden
            
            #line 34 "..\..\Views\ApprenticeshipApplication\WhatHappensNext.cshtml"
     if ((Model.SuggestedVacancies == null || !Model.SuggestedVacancies.Any()) && (Model.SavedAndDraftApplications == null || !Model.SavedAndDraftApplications.Any()))
    {

            
            #line default
            #line hidden
WriteLiteral("        <div");

WriteLiteral(" class=\"form-group form-group-compound get-started\"");

WriteLiteral(">\r\n            <a");

WriteLiteral(" id=\"find-apprenticeship-btn\"");

WriteLiteral(" role=\"button\"");

WriteLiteral(" class=\"button\"");

WriteAttribute("href", Tuple.Create(" href=\'", 2060), Tuple.Create("\'", 2122)
            
            #line 37 "..\..\Views\ApprenticeshipApplication\WhatHappensNext.cshtml"
, Tuple.Create(Tuple.Create("", 2067), Tuple.Create<System.Object, System.Int32>(Url.RouteUrl(CandidateRouteNames.ApprenticeshipSearch)
            
            #line default
            #line hidden
, 2067), false)
);

WriteLiteral(">Find an apprenticeship</a>\r\n        </div>\r\n");

            
            #line 39 "..\..\Views\ApprenticeshipApplication\WhatHappensNext.cshtml"
    }
    else
    {
        if (Model.SavedAndDraftApplications != null && Model.SavedAndDraftApplications.Any())
        {

            
            #line default
            #line hidden
WriteLiteral("            <div");

WriteLiteral(" class=\"hgroup-medium text\"");

WriteLiteral(">\r\n                <h2");

WriteLiteral(" class=\"heading-medium\"");

WriteLiteral(">Saved apprenticeships</h2>\r\n            </div>\r\n");

WriteLiteral("            <div");

WriteLiteral(" class=\"grid-wrapper\"");

WriteLiteral(">\r\n");

            
            #line 48 "..\..\Views\ApprenticeshipApplication\WhatHappensNext.cshtml"
                
            
            #line default
            #line hidden
            
            #line 48 "..\..\Views\ApprenticeshipApplication\WhatHappensNext.cshtml"
                 for (int i = 0; i < Math.Min(3, Model.SavedAndDraftApplications.Count); i++)
                {

            
            #line default
            #line hidden
WriteLiteral("                    <div");

WriteLiteral(" class=\"grid grid-1-3\"");

WriteAttribute("id", Tuple.Create(" id=\"", 2635), Tuple.Create("\"", 2699)
, Tuple.Create(Tuple.Create("", 2640), Tuple.Create("saved-vacancy-", 2640), true)
            
            #line 50 "..\..\Views\ApprenticeshipApplication\WhatHappensNext.cshtml"
, Tuple.Create(Tuple.Create("", 2654), Tuple.Create<System.Object, System.Int32>(Model.SavedAndDraftApplications[i].VacancyId
            
            #line default
            #line hidden
, 2654), false)
);

WriteLiteral(">\r\n                        <div");

WriteLiteral(" class=\"inner-block-padr\"");

WriteLiteral(">\r\n                            \r\n");

            
            #line 53 "..\..\Views\ApprenticeshipApplication\WhatHappensNext.cshtml"
                            
            
            #line default
            #line hidden
            
            #line 53 "..\..\Views\ApprenticeshipApplication\WhatHappensNext.cshtml"
                             if (Model.SavedAndDraftApplications[i].IsPositiveAboutDisability)
                            {

            
            #line default
            #line hidden
WriteLiteral("                                <a");

WriteLiteral(" href=\"https://www.gov.uk/looking-for-work-if-disabled\"");

WriteLiteral(" target=\"_blank\"");

WriteLiteral(">\r\n                                    <img");

WriteAttribute("src", Tuple.Create(" src=\"", 3064), Tuple.Create("\"", 3131)
            
            #line 56 "..\..\Views\ApprenticeshipApplication\WhatHappensNext.cshtml"
, Tuple.Create(Tuple.Create("", 3070), Tuple.Create<System.Object, System.Int32>(Url.Content("~/content/_assets/img/logo-ticks-small-2x.png")
            
            #line default
            #line hidden
, 3070), false)
);

WriteLiteral(" width=\"37\"");

WriteLiteral(" height=\"30\"");

WriteLiteral(" align=\"right\"");

WriteLiteral(" alt=\"\"");

WriteLiteral(">\r\n                                </a>\r\n");

            
            #line 58 "..\..\Views\ApprenticeshipApplication\WhatHappensNext.cshtml"
                            }

            
            #line default
            #line hidden
WriteLiteral("\r\n                            <h3");

WriteLiteral(" class=\"heading-small\"");

WriteLiteral("><a");

WriteAttribute("href", Tuple.Create(" href=\"", 3306), Tuple.Create("\"", 3437)
            
            #line 60 "..\..\Views\ApprenticeshipApplication\WhatHappensNext.cshtml"
, Tuple.Create(Tuple.Create("", 3313), Tuple.Create<System.Object, System.Int32>(Url.RouteUrl(CandidateRouteNames.ApprenticeshipDetails, new {id = Model.SavedAndDraftApplications[i].VacancyId.ToString()})
            
            #line default
            #line hidden
, 3313), false)
);

WriteLiteral(">");

            
            #line 60 "..\..\Views\ApprenticeshipApplication\WhatHappensNext.cshtml"
                                                                                                                                                                                        Write(Model.SavedAndDraftApplications[i].Title);

            
            #line default
            #line hidden
WriteLiteral("</a></h3>\r\n                            <p><b>Closing date:</b> ");

            
            #line 61 "..\..\Views\ApprenticeshipApplication\WhatHappensNext.cshtml"
                                               Write(Model.SavedAndDraftApplications[i].ClosingDate.ToFriendlyClosingToday());

            
            #line default
            #line hidden
WriteLiteral("</p>\r\n");

            
            #line 62 "..\..\Views\ApprenticeshipApplication\WhatHappensNext.cshtml"
                            
            
            #line default
            #line hidden
            
            #line 62 "..\..\Views\ApprenticeshipApplication\WhatHappensNext.cshtml"
                             if (@Model.SavedAndDraftApplications[i].ApplicationStatus == ApplicationStatuses.Saved)
                            {

            
            #line default
            #line hidden
WriteLiteral("                                <p><a");

WriteAttribute("href", Tuple.Create(" href=\"", 3807), Tuple.Create("\"", 3937)
            
            #line 64 "..\..\Views\ApprenticeshipApplication\WhatHappensNext.cshtml"
, Tuple.Create(Tuple.Create("", 3814), Tuple.Create<System.Object, System.Int32>(Url.RouteUrl(CandidateRouteNames.ApprenticeshipApply, new { id = Model.SavedAndDraftApplications[i].VacancyId.ToString()})
            
            #line default
            #line hidden
, 3814), false)
);

WriteLiteral(">Apply</a></p>\r\n");

            
            #line 65 "..\..\Views\ApprenticeshipApplication\WhatHappensNext.cshtml"
                            }
                            else
                            {

            
            #line default
            #line hidden
WriteLiteral("                                <p><a");

WriteAttribute("href", Tuple.Create(" href=\"", 4087), Tuple.Create("\"", 4214)
            
            #line 68 "..\..\Views\ApprenticeshipApplication\WhatHappensNext.cshtml"
, Tuple.Create(Tuple.Create("", 4094), Tuple.Create<System.Object, System.Int32>(Url.Action("Resume", "ApprenticeshipApplication", new { id = Model.SavedAndDraftApplications[i].VacancyId.ToString() })
            
            #line default
            #line hidden
, 4094), false)
);

WriteLiteral(">Resume</a></p>\r\n");

            
            #line 69 "..\..\Views\ApprenticeshipApplication\WhatHappensNext.cshtml"
                            }

            
            #line default
            #line hidden
WriteLiteral("                        </div>\r\n                    </div>\r\n");

            
            #line 72 "..\..\Views\ApprenticeshipApplication\WhatHappensNext.cshtml"
                }

            
            #line default
            #line hidden
WriteLiteral("            </div>\r\n");

            
            #line 74 "..\..\Views\ApprenticeshipApplication\WhatHappensNext.cshtml"
        }
        else if (Model.SuggestedVacancies != null && Model.SuggestedVacancies.Any())
        {

            
            #line default
            #line hidden
WriteLiteral("            <div");

WriteLiteral(" class=\"hgroup-medium text\"");

WriteLiteral(">\r\n                <h2");

WriteLiteral(" class=\"heading-medium\"");

WriteLiteral(">Similar apprenticeships</h2>\r\n                <span");

WriteLiteral(" class=\"subtitle\"");

WriteLiteral(">Also in the ");

            
            #line 79 "..\..\Views\ApprenticeshipApplication\WhatHappensNext.cshtml"
                                              Write(Model.SuggestedVacanciesCategory);

            
            #line default
            #line hidden
WriteLiteral(" sub-category and within ");

            
            #line 79 "..\..\Views\ApprenticeshipApplication\WhatHappensNext.cshtml"
                                                                                                        Write(Model.SuggestedVacanciesSearchDistance);

            
            #line default
            #line hidden
WriteLiteral(" miles of ");

            
            #line 79 "..\..\Views\ApprenticeshipApplication\WhatHappensNext.cshtml"
                                                                                                                                                         Write(Model.SuggestedVacanciesSearchLocation);

            
            #line default
            #line hidden
WriteLiteral("</span>\r\n            </div>\r\n");

WriteLiteral("            <div");

WriteLiteral(" class=\"grid-wrapper\"");

WriteLiteral(">\r\n");

            
            #line 82 "..\..\Views\ApprenticeshipApplication\WhatHappensNext.cshtml"
                
            
            #line default
            #line hidden
            
            #line 82 "..\..\Views\ApprenticeshipApplication\WhatHappensNext.cshtml"
                 for (int i = 0; i < Math.Min(3, Model.SuggestedVacancies.Count()); i++)
                {

            
            #line default
            #line hidden
WriteLiteral("                    <div");

WriteLiteral(" class=\"grid grid-1-3\"");

WriteAttribute("id", Tuple.Create(" id=\"", 5010), Tuple.Create("\"", 5071)
, Tuple.Create(Tuple.Create("", 5015), Tuple.Create("suggested-vacancy-", 5015), true)
            
            #line 84 "..\..\Views\ApprenticeshipApplication\WhatHappensNext.cshtml"
, Tuple.Create(Tuple.Create("", 5033), Tuple.Create<System.Object, System.Int32>(Model.SuggestedVacancies[i].VacancyId
            
            #line default
            #line hidden
, 5033), false)
);

WriteLiteral(">\r\n                        <div");

WriteLiteral(" class=\"inner-block-padr\"");

WriteLiteral(">\r\n                            \r\n");

            
            #line 87 "..\..\Views\ApprenticeshipApplication\WhatHappensNext.cshtml"
                            
            
            #line default
            #line hidden
            
            #line 87 "..\..\Views\ApprenticeshipApplication\WhatHappensNext.cshtml"
                             if (Model.SuggestedVacancies[i].IsPositiveAboutDisability)
                            {

            
            #line default
            #line hidden
WriteLiteral("                                <a");

WriteLiteral(" href=\"https://www.gov.uk/looking-for-work-if-disabled\"");

WriteLiteral(" target=\"_blank\"");

WriteLiteral(">\r\n                                    <img");

WriteAttribute("src", Tuple.Create(" src=\"", 5429), Tuple.Create("\"", 5496)
            
            #line 90 "..\..\Views\ApprenticeshipApplication\WhatHappensNext.cshtml"
, Tuple.Create(Tuple.Create("", 5435), Tuple.Create<System.Object, System.Int32>(Url.Content("~/content/_assets/img/logo-ticks-small-2x.png")
            
            #line default
            #line hidden
, 5435), false)
);

WriteLiteral(" width=\"37\"");

WriteLiteral(" height=\"30\"");

WriteLiteral(" align=\"right\"");

WriteLiteral(" alt=\"\"");

WriteLiteral(">\r\n                                </a>\r\n");

            
            #line 92 "..\..\Views\ApprenticeshipApplication\WhatHappensNext.cshtml"
                            }

            
            #line default
            #line hidden
WriteLiteral("                            \r\n                            <h3");

WriteLiteral(" class=\"heading-small\"");

WriteLiteral("><a");

WriteAttribute("href", Tuple.Create(" href=\"", 5699), Tuple.Create("\"", 5823)
            
            #line 94 "..\..\Views\ApprenticeshipApplication\WhatHappensNext.cshtml"
, Tuple.Create(Tuple.Create("", 5706), Tuple.Create<System.Object, System.Int32>(Url.RouteUrl(CandidateRouteNames.ApprenticeshipDetails, new {id = Model.SuggestedVacancies[i].VacancyId.ToString()})
            
            #line default
            #line hidden
, 5706), false)
);

WriteLiteral(">");

            
            #line 94 "..\..\Views\ApprenticeshipApplication\WhatHappensNext.cshtml"
                                                                                                                                                                                 Write(Model.SuggestedVacancies[i].VacancyTitle);

            
            #line default
            #line hidden
WriteLiteral("</a></h3>\r\n                            <p><b>Distance:</b> ");

            
            #line 95 "..\..\Views\ApprenticeshipApplication\WhatHappensNext.cshtml"
                                           Write(Model.SuggestedVacancies[i].Distance);

            
            #line default
            #line hidden
WriteLiteral(" miles</p>\r\n                        </div>\r\n                    </div>\r\n");

            
            #line 98 "..\..\Views\ApprenticeshipApplication\WhatHappensNext.cshtml"
                }

            
            #line default
            #line hidden
WriteLiteral("            </div>\r\n");

            
            #line 100 "..\..\Views\ApprenticeshipApplication\WhatHappensNext.cshtml"
        }
        
        if (Model.SuggestedVacanciesSearchViewModel != null){

            
            #line default
            #line hidden
WriteLiteral("             <p>View apprenticeships in the <a");

WriteAttribute("href", Tuple.Create(" href=\"", 6203), Tuple.Create("\"", 6355)
            
            #line 103 "..\..\Views\ApprenticeshipApplication\WhatHappensNext.cshtml"
, Tuple.Create(Tuple.Create("", 6210), Tuple.Create<System.Object, System.Int32>(Url.ApprenticeshipSearchViewModelRouteUrl(CandidateRouteNames.ApprenticeshipResults, Model.SuggestedVacanciesSearchViewModel)
            
            #line default
            #line hidden
, 6210), false)
, Tuple.Create(Tuple.Create("", 6336), Tuple.Create("&FromSubmitted=true", 6336), true)
);

WriteAttribute("title", Tuple.Create(" title=\"", 6356), Tuple.Create("\"", 6436)
, Tuple.Create(Tuple.Create("", 6364), Tuple.Create("View", 6364), true)
, Tuple.Create(Tuple.Create(" ", 6368), Tuple.Create("apprenticeships", 6369), true)
, Tuple.Create(Tuple.Create(" ", 6384), Tuple.Create("in", 6385), true)
, Tuple.Create(Tuple.Create(" ", 6387), Tuple.Create("sub-category", 6388), true)
, Tuple.Create(Tuple.Create(" ", 6400), Tuple.Create("\'", 6401), true)
            
            #line 103 "..\..\Views\ApprenticeshipApplication\WhatHappensNext.cshtml"
                                                                                                                                                                     , Tuple.Create(Tuple.Create("", 6402), Tuple.Create<System.Object, System.Int32>(Model.SuggestedVacanciesCategory
            
            #line default
            #line hidden
, 6402), false)
, Tuple.Create(Tuple.Create("", 6435), Tuple.Create("\'", 6435), true)
);

WriteLiteral(">");

            
            #line 103 "..\..\Views\ApprenticeshipApplication\WhatHappensNext.cshtml"
                                                                                                                                                                                                                                                                                    Write(Model.SuggestedVacanciesCategory);

            
            #line default
            #line hidden
WriteLiteral("</a> sub-category.</p>\r\n");

            
            #line 104 "..\..\Views\ApprenticeshipApplication\WhatHappensNext.cshtml"
        }
    }

            
            #line default
            #line hidden
WriteLiteral("\r\n");

            
            #line 107 "..\..\Views\ApprenticeshipApplication\WhatHappensNext.cshtml"
    
            
            #line default
            #line hidden
            
            #line 107 "..\..\Views\ApprenticeshipApplication\WhatHappensNext.cshtml"
     if (ViewBag.SearchReturnUrl != null)
    {

            
            #line default
            #line hidden
WriteLiteral("        <div");

WriteLiteral(" id=\"search-return-link\"");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(">\r\n            <a");

WriteAttribute("href", Tuple.Create(" href=\"", 6637), Tuple.Create("\"", 6668)
            
            #line 110 "..\..\Views\ApprenticeshipApplication\WhatHappensNext.cshtml"
, Tuple.Create(Tuple.Create("", 6644), Tuple.Create<System.Object, System.Int32>(ViewBag.SearchReturnUrl
            
            #line default
            #line hidden
, 6644), false)
);

WriteLiteral(" title=\"Return to search results\"");

WriteLiteral(" id=\"lnk-return-search-results\"");

WriteLiteral(">Return to search results</a>\r\n        </div>\r\n");

            
            #line 112 "..\..\Views\ApprenticeshipApplication\WhatHappensNext.cshtml"
    }

            
            #line default
            #line hidden
WriteLiteral("</section>\r\n\r\n<div");

WriteLiteral(" class=\"text form-group\"");

WriteLiteral(">\r\n    <p>\r\n        <a");

WriteAttribute("href", Tuple.Create(" href=\"", 6851), Tuple.Create("\"", 6878)
            
            #line 117 "..\..\Views\ApprenticeshipApplication\WhatHappensNext.cshtml"
, Tuple.Create(Tuple.Create("", 6858), Tuple.Create<System.Object, System.Int32>(ViewBag.FeedbackUrl
            
            #line default
            #line hidden
, 6858), false)
);

WriteLiteral(" target=\"_blank\"");

WriteLiteral(" rel=\"external\"");

WriteLiteral(">What did you think of this service?</a>\r\n        <br>(30 second survey, this wil" +
"l open in a new tab)\r\n    </p>\r\n</div>\r\n");

        }
    }
}
#pragma warning restore 1591
