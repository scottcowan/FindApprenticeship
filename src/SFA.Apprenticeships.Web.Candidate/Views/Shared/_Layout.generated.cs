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

namespace SFA.Apprenticeships.Web.Candidate.Views.Shared
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
    using SFA.Apprenticeships.Infrastructure.Presentation;
    using SFA.Apprenticeships.Web.Candidate;
    
    #line 1 "..\..\Views\Shared\_Layout.cshtml"
    using SFA.Apprenticeships.Web.Candidate.Attributes;
    
    #line default
    #line hidden
    using SFA.Apprenticeships.Web.Candidate.Constants;
    using SFA.Apprenticeships.Web.Candidate.Constants.ViewModels;
    
    #line 2 "..\..\Views\Shared\_Layout.cshtml"
    using SFA.Apprenticeships.Web.Candidate.Controllers;
    
    #line default
    #line hidden
    using SFA.Apprenticeships.Web.Candidate.Helpers;
    using SFA.Apprenticeships.Web.Candidate.ViewModels;
    using SFA.Apprenticeships.Web.Candidate.ViewModels.Candidate;
    using SFA.Apprenticeships.Web.Candidate.ViewModels.Login;
    using SFA.Apprenticeships.Web.Candidate.ViewModels.Register;
    using SFA.Apprenticeships.Web.Candidate.ViewModels.VacancySearch;
    using SFA.Apprenticeships.Web.Common.Constants;
    
    #line 3 "..\..\Views\Shared\_Layout.cshtml"
    using SFA.Apprenticeships.Web.Common.Framework;
    
    #line default
    #line hidden
    using SFA.Apprenticeships.Web.Common.Models.Common;
    using SFA.Apprenticeships.Web.Common.ViewModels.Locations;
    using SFA.Apprenticeships.Web.Common.Views.Shared.DisplayTemplates;
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/Shared/_Layout.cshtml")]
    public partial class Layout : System.Web.Mvc.WebViewPage<dynamic>
    {
        public Layout()
        {
        }
        public override void Execute()
        {
WriteLiteral("\r\n<!DOCTYPE html>\r\n<!--[if lt IE 7]><html class=\"no-js lt-ie9 lt-ie8 lt-ie7\"><![e" +
"ndif]-->\r\n<!--[if IE 7]><html class=\"no-js lt-ie9 lt-ie8\"><![endif]-->\r\n<!--[if " +
"IE 8]><html class=\"no-js lt-ie9\"><![endif]-->\r\n<!--[if gt IE 8]><!-->\r\n<html");

WriteLiteral(" lang=\"en-GB\"");

WriteLiteral(" class=\"no-js not-ie8\"");

WriteLiteral(">\r\n<!--<![endif]-->\r\n<head>\r\n    <meta");

WriteLiteral(" charset=\"utf-8\"");

WriteLiteral(">\r\n    <meta");

WriteLiteral(" http-equiv=\"X-UA-Compatible\"");

WriteLiteral(" content=\"IE=edge\"");

WriteLiteral(">\r\n    <title>");

            
            #line 15 "..\..\Views\Shared\_Layout.cshtml"
      Write(ViewBag.Title);

            
            #line default
            #line hidden
WriteLiteral("</title>\r\n    <meta");

WriteLiteral(" name=\"description\"");

WriteLiteral(" content=\"We’ve introduced a new way to find and apply for an apprenticeship in E" +
"ngland.\"");

WriteLiteral(">\r\n    <meta");

WriteLiteral(" name=\"viewport\"");

WriteLiteral(" content=\"width=device-width, initial-scale=1\"");

WriteLiteral(">\r\n    <meta");

WriteLiteral(" name=\"format-detection\"");

WriteLiteral(" content=\"telephone=no\"");

WriteLiteral(">\r\n    <meta");

WriteLiteral(" name=\"format-detection\"");

WriteLiteral(" content=\"date=no\"");

WriteLiteral(">\r\n    <meta");

WriteLiteral(" name=\"format-detection\"");

WriteLiteral(" content=\"address=no\"");

WriteLiteral(">\r\n    <meta");

WriteLiteral(" name=\"DCSext.Authenticated\"");

WriteAttribute("content", Tuple.Create(" content=\"", 980), Tuple.Create("\"", 1031)
            
            #line 21 "..\..\Views\Shared\_Layout.cshtml"
, Tuple.Create(Tuple.Create("", 990), Tuple.Create<System.Object, System.Int32>(Request.IsAuthenticated ? "Yes" : "No"
            
            #line default
            #line hidden
, 990), false)
);

WriteLiteral(" />\r\n");

            
            #line 22 "..\..\Views\Shared\_Layout.cshtml"
    
            
            #line default
            #line hidden
            
            #line 22 "..\..\Views\Shared\_Layout.cshtml"
     if (ViewBag.ShouldRobotsIndexPage)
    {

            
            #line default
            #line hidden
WriteLiteral("        <meta");

WriteLiteral(" name=\"ROBOTS\"");

WriteLiteral(" content=\"NOFOLLOW\"");

WriteLiteral(">\r\n");

            
            #line 25 "..\..\Views\Shared\_Layout.cshtml"
    }
    else
    {

            
            #line default
            #line hidden
WriteLiteral("        <meta");

WriteLiteral(" name=\"ROBOTS\"");

WriteLiteral(" content=\"NOFOLLOW,NOINDEX\"");

WriteLiteral(">\r\n");

            
            #line 29 "..\..\Views\Shared\_Layout.cshtml"
    }

            
            #line default
            #line hidden
WriteLiteral("    ");

            
            #line 30 "..\..\Views\Shared\_Layout.cshtml"
Write(RenderSection("metatags", false));

            
            #line default
            #line hidden
WriteLiteral("\r\n    <!--[if gt IE 8]><!-->");

            
            #line 31 "..\..\Views\Shared\_Layout.cshtml"
                     Write(Styles.Render("~/Content/_assets/styles/not-ie8"));

            
            #line default
            #line hidden
WriteLiteral("<!--<![endif]-->\r\n    <!--[if lte IE 8]>");

            
            #line 32 "..\..\Views\Shared\_Layout.cshtml"
                 Write(Styles.Render("~/Content/_assets/styles/ie8"));

            
            #line default
            #line hidden
WriteLiteral("<![endif]-->\r\n    <link");

WriteLiteral(" rel=\"shortcut icon\"");

WriteAttribute("href", Tuple.Create(" href=\"", 1466), Tuple.Create("\"", 1501)
            
            #line 33 "..\..\Views\Shared\_Layout.cshtml"
, Tuple.Create(Tuple.Create("", 1473), Tuple.Create<System.Object, System.Int32>(Url.CdnImage("favicon.ico")
            
            #line default
            #line hidden
, 1473), false)
);

WriteLiteral(" type=\"image/x-icon\"");

WriteLiteral(">\r\n    <link");

WriteLiteral(" rel=\"apple-touch-icon-precomposed\"");

WriteLiteral(" sizes=\"152x152\"");

WriteAttribute("href", Tuple.Create(" href=\"", 1585), Tuple.Create("\"", 1637)
            
            #line 34 "..\..\Views\Shared\_Layout.cshtml"
, Tuple.Create(Tuple.Create("", 1592), Tuple.Create<System.Object, System.Int32>(Url.CdnImage("apple-touch-icon-152x152.png")
            
            #line default
            #line hidden
, 1592), false)
);

WriteLiteral(">\r\n    <link");

WriteLiteral(" rel=\"apple-touch-icon-precomposed\"");

WriteLiteral(" sizes=\"120x120\"");

WriteAttribute("href", Tuple.Create(" href=\"", 1701), Tuple.Create("\"", 1753)
            
            #line 35 "..\..\Views\Shared\_Layout.cshtml"
, Tuple.Create(Tuple.Create("", 1708), Tuple.Create<System.Object, System.Int32>(Url.CdnImage("apple-touch-icon-120x120.png")
            
            #line default
            #line hidden
, 1708), false)
);

WriteLiteral(">\r\n    <link");

WriteLiteral(" rel=\"apple-touch-icon-precomposed\"");

WriteLiteral(" sizes=\"76x76\"");

WriteAttribute("href", Tuple.Create(" href=\"", 1815), Tuple.Create("\"", 1865)
            
            #line 36 "..\..\Views\Shared\_Layout.cshtml"
, Tuple.Create(Tuple.Create("", 1822), Tuple.Create<System.Object, System.Int32>(Url.CdnImage("apple-touch-icon-76x76.png")
            
            #line default
            #line hidden
, 1822), false)
);

WriteLiteral(">\r\n    <link");

WriteLiteral(" rel=\"apple-touch-icon-precomposed\"");

WriteAttribute("href", Tuple.Create(" href=\"", 1913), Tuple.Create("\"", 1963)
            
            #line 37 "..\..\Views\Shared\_Layout.cshtml"
, Tuple.Create(Tuple.Create("", 1920), Tuple.Create<System.Object, System.Int32>(Url.CdnImage("apple-touch-icon-60x60.png")
            
            #line default
            #line hidden
, 1920), false)
);

WriteLiteral(">\r\n");

WriteLiteral("    ");

            
            #line 38 "..\..\Views\Shared\_Layout.cshtml"
Write(Styles.Render("~/bundles/font-awesome"));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("    ");

            
            #line 39 "..\..\Views\Shared\_Layout.cshtml"
Write(Html.Partial("_Scripts"));

            
            #line default
            #line hidden
WriteLiteral("\r\n</head>\r\n<body>\r\n\r\n    <script>document.body.className = ((document.body.classN" +
"ame) ? document.body.className + \' js-enabled\' : \'js-enabled\');</script>\r\n\r\n    " +
"<div");

WriteLiteral(" id=\"skiplink-container\"");

WriteLiteral(">\r\n        <div>\r\n            <a");

WriteLiteral(" href=\"#content\"");

WriteLiteral(" class=\"skiplink\"");

WriteLiteral(">Skip to main content</a>\r\n        </div>\r\n    </div>\r\n\r\n");

            
            #line 51 "..\..\Views\Shared\_Layout.cshtml"
    
            
            #line default
            #line hidden
            
            #line 51 "..\..\Views\Shared\_Layout.cshtml"
     if (ViewBag.ShowEuCookieDirective == true)
    {

            
            #line default
            #line hidden
WriteLiteral("        <div");

WriteLiteral(" id=\"global-cookie-message\"");

WriteLiteral(" class=\"cookie-banner\"");

WriteLiteral(">\r\n            <div");

WriteLiteral(" class=\"content-container\"");

WriteLiteral(" role=\"alert\"");

WriteLiteral(">\r\n                <span");

WriteLiteral(" class=\"copy-16\"");

WriteLiteral(">GOV.UK uses cookies to make the site simpler. <a");

WriteAttribute("href", Tuple.Create(" href=\'", 2617), Tuple.Create("\'", 2666)
            
            #line 55 "..\..\Views\Shared\_Layout.cshtml"
             , Tuple.Create(Tuple.Create("", 2624), Tuple.Create<System.Object, System.Int32>(Url.RouteUrl(CandidateRouteNames.Privacy)
            
            #line default
            #line hidden
, 2624), false)
);

WriteLiteral(">Find out more about cookies</a></span>\r\n            </div>\r\n        </div>\r\n");

            
            #line 58 "..\..\Views\Shared\_Layout.cshtml"
    }

            
            #line default
            #line hidden
WriteLiteral("\r\n");

            
            #line 60 "..\..\Views\Shared\_Layout.cshtml"
    
            
            #line default
            #line hidden
            
            #line 60 "..\..\Views\Shared\_Layout.cshtml"
     if (!string.IsNullOrEmpty(ViewBag.PlannedOutageMessage))
    {

            
            #line default
            #line hidden
WriteLiteral("        <div");

WriteLiteral(" id=\"planned-outage-message\"");

WriteLiteral(" class=\"maintenance-banner\"");

WriteLiteral(">\r\n            <div");

WriteLiteral(" class=\"content-container\"");

WriteLiteral(" role=\"alert\"");

WriteLiteral(">\r\n                <div");

WriteLiteral(" class=\"font-xsmall maintenance-content\"");

WriteLiteral(">\r\n                    <div>");

            
            #line 65 "..\..\Views\Shared\_Layout.cshtml"
                    Write(Html.Raw(ViewBag.PlannedOutageMessage));

            
            #line default
            #line hidden
WriteLiteral("</div>\r\n                    <a");

WriteAttribute("href", Tuple.Create(" href=\"", 3108), Tuple.Create("\"", 3196)
            
            #line 66 "..\..\Views\Shared\_Layout.cshtml"
, Tuple.Create(Tuple.Create("", 3115), Tuple.Create<System.Object, System.Int32>(Url.RouteUrl(RouteNames.DismissPlannedOutageMessage, new {isJavascript = false})
            
            #line default
            #line hidden
, 3115), false)
);

WriteLiteral(" class=\"maintenance-close\"");

WriteLiteral(">\r\n                        <i");

WriteLiteral(" id=\"dismiss-planned-outage-message\"");

WriteLiteral(" class=\"icon-black fa fa-times-circle\"");

WriteLiteral("></i>\r\n                    </a>\r\n                </div>\r\n            </div>\r\n    " +
"    </div>\r\n");

            
            #line 72 "..\..\Views\Shared\_Layout.cshtml"
    }

            
            #line default
            #line hidden
WriteLiteral("    \r\n    <header");

WriteLiteral(" role=\"banner\"");

WriteLiteral(" id=\"global-header\"");

WriteLiteral(" class=\"with-proposition\"");

WriteLiteral(">\r\n        <div");

WriteLiteral(" class=\"header-wrapper\"");

WriteLiteral(">\r\n            <div");

WriteLiteral(" class=\"header-global\"");

WriteLiteral(">\r\n                <div");

WriteLiteral(" class=\"header-logo\"");

WriteLiteral(">\r\n                    <a");

WriteLiteral(" href=\"https://www.gov.uk\"");

WriteLiteral(" title=\"Go to the GOV.UK homepage\"");

WriteLiteral(" id=\"logo\"");

WriteLiteral(" class=\"content\"");

WriteLiteral(">\r\n                        <img");

WriteAttribute("src", Tuple.Create(" src=\"", 3765), Tuple.Create("\"", 3854)
            
            #line 79 "..\..\Views\Shared\_Layout.cshtml"
, Tuple.Create(Tuple.Create("", 3771), Tuple.Create<System.Object, System.Int32>(Url.Content("~/Content/_assets/img/gov.uk_logotype_crown_invert_trans.png")
            
            #line default
            #line hidden
, 3771), false)
, Tuple.Create(Tuple.Create("", 3847), Tuple.Create("?0.19.0", 3847), true)
);

WriteLiteral(" width=\"36\"");

WriteLiteral(" height=\"32\"");

WriteLiteral(" alt=\"\"");

WriteLiteral("> GOV.UK\r\n                    </a>\r\n                </div>\r\n\r\n            </div>\r" +
"\n\r\n            <div");

WriteLiteral(" class=\"header-proposition\"");

WriteLiteral(">\r\n                <div");

WriteLiteral(" class=\"content\"");

WriteLiteral(">\r\n                    <a");

WriteLiteral(" href=\"#proposition-links\"");

WriteLiteral(" class=\"js-header-toggle menu\"");

WriteLiteral(">Menu</a>\r\n                    <nav");

WriteLiteral(" id=\"proposition-menu\"");

WriteLiteral(">\r\n");

            
            #line 89 "..\..\Views\Shared\_Layout.cshtml"
                        
            
            #line default
            #line hidden
            
            #line 89 "..\..\Views\Shared\_Layout.cshtml"
                         if (ViewBag.UserJourney == UserJourney.Apprenticeship)
                        {

            
            #line default
            #line hidden
WriteLiteral("                            <a");

WriteLiteral(" id=\"proposition-name\"");

WriteAttribute("href", Tuple.Create(" href=\"", 4352), Tuple.Create("\"", 4414)
            
            #line 91 "..\..\Views\Shared\_Layout.cshtml"
, Tuple.Create(Tuple.Create("", 4359), Tuple.Create<System.Object, System.Int32>(Url.RouteUrl(CandidateRouteNames.ApprenticeshipSearch)
            
            #line default
            #line hidden
, 4359), false)
);

WriteLiteral(">Find an apprenticeship</a>\r\n");

            
            #line 92 "..\..\Views\Shared\_Layout.cshtml"
                        }
                        else if (ViewBag.UserJourney == UserJourney.Traineeship)
                        {

            
            #line default
            #line hidden
WriteLiteral("                            <a");

WriteLiteral(" id=\"proposition-name\"");

WriteAttribute("href", Tuple.Create(" href=\"", 4632), Tuple.Create("\"", 4691)
            
            #line 95 "..\..\Views\Shared\_Layout.cshtml"
, Tuple.Create(Tuple.Create("", 4639), Tuple.Create<System.Object, System.Int32>(Url.RouteUrl(CandidateRouteNames.TraineeshipSearch)
            
            #line default
            #line hidden
, 4639), false)
);

WriteLiteral(">Find a traineeship</a>\r\n");

            
            #line 96 "..\..\Views\Shared\_Layout.cshtml"
                        }

            
            #line default
            #line hidden
WriteLiteral("                        <ul");

WriteLiteral(" id=\"proposition-links\"");

WriteLiteral(">\r\n                            ");

WriteLiteral("\r\n                        </ul>\r\n                    </nav>\r\n                </di" +
"v>\r\n            </div>\r\n\r\n\r\n        </div>\r\n    </header>\r\n\r\n    <div");

WriteLiteral(" id=\"content\"");

WriteLiteral(" role=\"main\"");

WriteLiteral(" tabindex=\"-1\"");

WriteLiteral(">\r\n        <div");

WriteLiteral(" id=\"global-header-bar\"");

WriteLiteral("></div>\r\n        <div");

WriteLiteral(" class=\"phase-banner-beta grid-row\"");

WriteLiteral(">\r\n            <p");

WriteLiteral(" class=\"column-two-thirds\"");

WriteLiteral(">\r\n                <strong");

WriteLiteral(" class=\"phase-tag\"");

WriteLiteral(">BETA</strong>\r\n                <span>You can help us improve this app by complet" +
"ing our <a");

WriteLiteral(" href=\"https://www.surveymonkey.co.uk/r/2MZRS9H\"");

WriteLiteral(">5 minute survey</a>.</span>\r\n            </p>\r\n            <p");

WriteLiteral(" class=\"column-one-third\"");

WriteLiteral(">\r\n");

WriteLiteral("                ");

            
            #line 118 "..\..\Views\Shared\_Layout.cshtml"
           Write(Html.Partial("_LoginPartial"));

            
            #line default
            #line hidden
WriteLiteral("\r\n            </p>\r\n        </div>\r\n        \r\n        <main");

WriteLiteral(" id=\"content\"");

WriteLiteral(">\r\n");

            
            #line 123 "..\..\Views\Shared\_Layout.cshtml"
            
            
            #line default
            #line hidden
            
            #line 123 "..\..\Views\Shared\_Layout.cshtml"
              
                var controller = ViewContext.Controller as CandidateControllerBase;

                if (controller != null)
                {
                    var infoMessage = controller.UserData.Pop(UserMessageConstants.InfoMessage);
                    var successMessage = controller.UserData.Pop(UserMessageConstants.SuccessMessage);
                    var warningMessage = controller.UserData.Pop(UserMessageConstants.WarningMessage);
                    var errorMessage = controller.UserData.Pop(UserMessageConstants.ErrorMessage);

                    if (infoMessage != null)
                    {

            
            #line default
            #line hidden
WriteLiteral("                        <div");

WriteLiteral(" role=\"alert\"");

WriteLiteral(" class=\"panel-info\"");

WriteLiteral(">\r\n                            <p");

WriteLiteral(" id=\"InfoMessageText\"");

WriteLiteral(">");

            
            #line 136 "..\..\Views\Shared\_Layout.cshtml"
                                               Write(Html.Raw(infoMessage));

            
            #line default
            #line hidden
WriteLiteral("</p>\r\n                        </div>\r\n");

            
            #line 138 "..\..\Views\Shared\_Layout.cshtml"
                    }
                    if (successMessage != null)
                    {

            
            #line default
            #line hidden
WriteLiteral("                        <div");

WriteLiteral(" role=\"alert\"");

WriteLiteral(" class=\"panel-success\"");

WriteLiteral(">\r\n                            <p");

WriteLiteral(" id=\"SuccessMessageText\"");

WriteLiteral("><i");

WriteLiteral(" class=\"fa fa-check\"");

WriteLiteral("></i>");

            
            #line 142 "..\..\Views\Shared\_Layout.cshtml"
                                                                             Write(Html.Raw(successMessage));

            
            #line default
            #line hidden
WriteLiteral("</p>\r\n                        </div>\r\n");

            
            #line 144 "..\..\Views\Shared\_Layout.cshtml"
                    }
                    if (warningMessage != null)
                    {

            
            #line default
            #line hidden
WriteLiteral("                        <div");

WriteLiteral(" role=\"alert\"");

WriteLiteral(" class=\"panel-warning\"");

WriteLiteral(">\r\n                            <p");

WriteLiteral(" id=\"WarningMessageText\"");

WriteLiteral(">");

            
            #line 148 "..\..\Views\Shared\_Layout.cshtml"
                                                  Write(Html.Raw(warningMessage));

            
            #line default
            #line hidden
WriteLiteral("</p>\r\n                        </div>\r\n");

            
            #line 150 "..\..\Views\Shared\_Layout.cshtml"
                    }
                    if (errorMessage != null)
                    {

            
            #line default
            #line hidden
WriteLiteral("                        <div");

WriteLiteral(" role=\"alert\"");

WriteLiteral(" class=\"panel-danger\"");

WriteLiteral(">\r\n                            <p");

WriteLiteral(" id=\"ErrorMessageText\"");

WriteLiteral(">");

            
            #line 154 "..\..\Views\Shared\_Layout.cshtml"
                                                Write(Html.Raw(errorMessage));

            
            #line default
            #line hidden
WriteLiteral("</p>\r\n                        </div>\r\n");

            
            #line 156 "..\..\Views\Shared\_Layout.cshtml"
                    }
                }
            
            
            #line default
            #line hidden
WriteLiteral("\r\n\r\n");

WriteLiteral("            ");

            
            #line 160 "..\..\Views\Shared\_Layout.cshtml"
       Write(RenderBody());

            
            #line default
            #line hidden
WriteLiteral("\r\n        </main>\r\n\r\n");

            
            #line 163 "..\..\Views\Shared\_Layout.cshtml"
        
            
            #line default
            #line hidden
            
            #line 163 "..\..\Views\Shared\_Layout.cshtml"
         if (ViewBag.EnableWebTrends == true)
        {

            
            #line default
            #line hidden
WriteLiteral("            <noscript>\r\n                <img");

WriteLiteral(" alt=\"dcsimg\"");

WriteLiteral(" id=\"dcsimg\"");

WriteLiteral(" width=\"1\"");

WriteLiteral(" height=\"1\"");

WriteAttribute("src", Tuple.Create(" src=\"", 7794), Tuple.Create("\"", 7956)
, Tuple.Create(Tuple.Create("", 7800), Tuple.Create("//stats.matraxis.net/", 7800), true)
            
            #line 166 "..\..\Views\Shared\_Layout.cshtml"
             , Tuple.Create(Tuple.Create("", 7821), Tuple.Create<System.Object, System.Int32>(ViewBag.WebTrendsDscId
            
            #line default
            #line hidden
, 7821), false)
, Tuple.Create(Tuple.Create("", 7844), Tuple.Create("/njs.gif?dcsuri=/nojavascript&amp;WT.js=No&amp;WT.tv=10.4.11&amp;WT.dl=0&amp;dcss" +
"ip=", 7844), true)
            
            #line 166 "..\..\Views\Shared\_Layout.cshtml"
                                                                                                                        , Tuple.Create(Tuple.Create("", 7928), Tuple.Create<System.Object, System.Int32>(ViewBag.WebTrendsDomainName
            
            #line default
            #line hidden
, 7928), false)
);

WriteLiteral(" />\r\n            </noscript>\r\n");

            
            #line 168 "..\..\Views\Shared\_Layout.cshtml"
        }

            
            #line default
            #line hidden
WriteLiteral("    </div>\r\n\r\n    <footer");

WriteLiteral(" class=\"gov-border\"");

WriteLiteral(" role=\"contentinfo\"");

WriteLiteral(">\r\n        <div");

WriteLiteral(" class=\"footer__wrapper\"");

WriteLiteral(">\r\n            <div");

WriteLiteral(" class=\"footer__meta\"");

WriteLiteral(">\r\n                <ul");

WriteLiteral(" class=\"footer__nav\"");

WriteLiteral(">\r\n                    <li");

WriteLiteral(" class=\"small-btm-margin\"");

WriteLiteral(">\r\n                        <a");

WriteLiteral(" class=\"footer__link bold-medium\"");

WriteAttribute("href", Tuple.Create(" href=\'", 8295), Tuple.Create("\'", 8345)
            
            #line 176 "..\..\Views\Shared\_Layout.cshtml"
, Tuple.Create(Tuple.Create("", 8302), Tuple.Create<System.Object, System.Int32>(Url.RouteUrl(CandidateRouteNames.Helpdesk)
            
            #line default
            #line hidden
, 8302), false)
);

WriteLiteral(">Contact us</a>\r\n                        <a");

WriteLiteral(" class=\"footer__link bold-medium\"");

WriteAttribute("href", Tuple.Create(" href=\'", 8422), Tuple.Create("\'", 8472)
            
            #line 177 "..\..\Views\Shared\_Layout.cshtml"
, Tuple.Create(Tuple.Create("", 8429), Tuple.Create<System.Object, System.Int32>(Url.RouteUrl(CandidateRouteNames.Feedback)
            
            #line default
            #line hidden
, 8429), false)
);

WriteLiteral(">Give feedback</a>\r\n                    </li>\r\n                    <li");

WriteLiteral(" class=\"footer__link\"");

WriteLiteral("><a");

WriteAttribute("href", Tuple.Create(" href=\'", 8567), Tuple.Create("\'", 8616)
            
            #line 179 "..\..\Views\Shared\_Layout.cshtml"
, Tuple.Create(Tuple.Create("", 8574), Tuple.Create<System.Object, System.Int32>(Url.RouteUrl(CandidateRouteNames.Privacy)
            
            #line default
            #line hidden
, 8574), false)
);

WriteLiteral(">Privacy and cookies</a></li>\r\n                    <li");

WriteLiteral(" class=\"footer__link\"");

WriteLiteral("><a");

WriteAttribute("href", Tuple.Create(" href=\'", 8695), Tuple.Create("\'", 8742)
            
            #line 180 "..\..\Views\Shared\_Layout.cshtml"
, Tuple.Create(Tuple.Create("", 8702), Tuple.Create<System.Object, System.Int32>(Url.RouteUrl(CandidateRouteNames.Terms)
            
            #line default
            #line hidden
, 8702), false)
);

WriteLiteral(">Terms and conditions</a></li>\r\n                    <li");

WriteLiteral(" class=\"footer__link\"");

WriteLiteral(">Built by the <a");

WriteLiteral(" href=\"http://gov.uk/sfa\"");

WriteLiteral(" target=\"_blank\"");

WriteLiteral(">Skills Funding Agency</a></li>\r\n                    <li");

WriteLiteral(" class=\"footer__ogl\"");

WriteLiteral("><a");

WriteLiteral(" href=\"http://www.nationalarchives.gov.uk/doc/open-government-licence/version/2\"");

WriteLiteral(" class=\"ir ogl-logo\"");

WriteLiteral(">OGL</a>All content is available under the <a");

WriteLiteral(" href=\"http://www.nationalarchives.gov.uk/doc/open-government-licence/version/2\"");

WriteLiteral(">Open Government Licence v2.0</a>, except where otherwise stated</li>\r\n          " +
"      </ul>\r\n                <a");

WriteLiteral(" class=\"footer__copyright\"");

WriteLiteral(" href=\"http://www.nationalarchives.gov.uk/information-management/our-services/cro" +
"wn-copyright.htm\"");

WriteLiteral(" target=\"_blank\"");

WriteLiteral(">\r\n                    <img");

WriteAttribute("src", Tuple.Create(" src=\"", 9459), Tuple.Create("\"", 9500)
            
            #line 185 "..\..\Views\Shared\_Layout.cshtml"
, Tuple.Create(Tuple.Create("", 9465), Tuple.Create<System.Object, System.Int32>(Url.CdnImage("govuk-crest-2x.png")
            
            #line default
            #line hidden
, 9465), false)
);

WriteLiteral(" width=\"125\"");

WriteLiteral(" height=\"102\"");

WriteLiteral(" alt=\"Crown copyright logo\"");

WriteLiteral(">\r\n                    <p>&copy; Crown copyright</p>\r\n                </a>\r\n");

WriteLiteral("                ");

            
            #line 188 "..\..\Views\Shared\_Layout.cshtml"
           Write(Html.Partial("_AboutDisguised"));

            
            #line default
            #line hidden
WriteLiteral("\r\n            </div>\r\n            <div");

WriteLiteral(" class=\"toggle-content hide-nojs show-print nobreak-print\"");

WriteLiteral(">\r\n                <h3");

WriteLiteral(" class=\"heading-small\"");

WriteLiteral(">Contact the Skills Funding Agency helpdesk</h3>\r\n                <p");

WriteLiteral(" class=\"small-btm-margin\"");

WriteLiteral(">Telephone (free): 0800 015 0400</p>\r\n            </div>\r\n        </div>\r\n    </f" +
"ooter>\r\n\r\n");

            
            #line 197 "..\..\Views\Shared\_Layout.cshtml"
    
            
            #line default
            #line hidden
            
            #line 197 "..\..\Views\Shared\_Layout.cshtml"
     if (ViewBag.ShowAbout != null && ViewBag.ShowAbout == true)
    {
        
            
            #line default
            #line hidden
            
            #line 199 "..\..\Views\Shared\_Layout.cshtml"
   Write(Html.Partial("_AboutFull"));

            
            #line default
            #line hidden
            
            #line 199 "..\..\Views\Shared\_Layout.cshtml"
                                   
    }

            
            #line default
            #line hidden
WriteLiteral("\r\n    <!-- Placed at the end of the document so the pages load faster -->\r\n");

WriteLiteral("    ");

            
            #line 203 "..\..\Views\Shared\_Layout.cshtml"
Write(Scripts.Render("~/bundles/jquery"));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("    ");

            
            #line 204 "..\..\Views\Shared\_Layout.cshtml"
Write(Scripts.Render("~/bundles/fastclick"));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("    ");

            
            #line 205 "..\..\Views\Shared\_Layout.cshtml"
Write(Scripts.Render("~/bundles/underscore"));

            
            #line default
            #line hidden
WriteLiteral("\r\n\r\n    <script");

WriteLiteral(" type=\"text/javascript\"");

WriteLiteral(">\r\n        if (typeof jQuery === \'undefined\') {\r\n            var e = document.cre" +
"ateElement(\"script\");\r\n\r\n            e.src = \'");

            
            #line 211 "..\..\Views\Shared\_Layout.cshtml"
                Write(Url.Content("~/Content/_assets/js/vendor/jquery-1.11.1.js"));

            
            #line default
            #line hidden
WriteLiteral(@"';
            e.type = ""text/javascript"";
            document.getElementsByTagName(""head"")[0].appendChild(e);
        }

        $(function () {
            $(""#dismiss-planned-outage-message"")
                .click(function (event) {

                    event.preventDefault();

                    var request = $.ajax({
                        type: ""GET"",
                        url: '");

            
            #line 224 "..\..\Views\Shared\_Layout.cshtml"
                         Write(Url.RouteUrl(RouteNames.DismissPlannedOutageMessage, new {isJavascript = true}));

            
            #line default
            #line hidden
WriteLiteral("\'\r\n                    });\r\n\r\n                    request.done(function () {\r\n\r\n " +
"                       $(\"#planned-outage-message\").hide();\r\n\r\n                 " +
"   });\r\n                });\r\n\r\n");

            
            #line 234 "..\..\Views\Shared\_Layout.cshtml"
            
            
            #line default
            #line hidden
            
            #line 234 "..\..\Views\Shared\_Layout.cshtml"
             if (ViewBag.SavedAndDraftCount != null)
        {

            
            #line default
            #line hidden
WriteLiteral("            ");

WriteLiteral("UpdateSavedAndDraftCount(");

            
            #line 236 "..\..\Views\Shared\_Layout.cshtml"
                                  Write(ViewBag.SavedAndDraftCount);

            
            #line default
            #line hidden
WriteLiteral(");\r\n");

            
            #line 237 "..\..\Views\Shared\_Layout.cshtml"
                                                                                }

            
            #line default
            #line hidden
WriteLiteral("\r\n");

            
            #line 239 "..\..\Views\Shared\_Layout.cshtml"
            
            
            #line default
            #line hidden
            
            #line 239 "..\..\Views\Shared\_Layout.cshtml"
             if (ViewBag.ApplicationStatusChangeCount != null)
        {

            
            #line default
            #line hidden
WriteLiteral("            ");

WriteLiteral("UpdateApplicationStatusChangeCount(");

            
            #line 241 "..\..\Views\Shared\_Layout.cshtml"
                                            Write(ViewBag.ApplicationStatusChangeCount);

            
            #line default
            #line hidden
WriteLiteral(");\r\n");

            
            #line 242 "..\..\Views\Shared\_Layout.cshtml"
                                                                                }

            
            #line default
            #line hidden
WriteLiteral("        });\r\n    </script>\r\n\r\n");

WriteLiteral("    ");

            
            #line 246 "..\..\Views\Shared\_Layout.cshtml"
Write(Scripts.Render("~/bundles/nascript"));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("    ");

            
            #line 247 "..\..\Views\Shared\_Layout.cshtml"
Write(Scripts.Render("~/bundles/vendor"));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("    ");

            
            #line 248 "..\..\Views\Shared\_Layout.cshtml"
Write(Scripts.Render("~/bundles/nas"));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("    ");

            
            #line 249 "..\..\Views\Shared\_Layout.cshtml"
Write(RenderSection("scripts", required: false));

            
            #line default
            #line hidden
WriteLiteral("\r\n\r\n</body>\r\n</html>\r\n");

        }
    }
}
#pragma warning restore 1591
