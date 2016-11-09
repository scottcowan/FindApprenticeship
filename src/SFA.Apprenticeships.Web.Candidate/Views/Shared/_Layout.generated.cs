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

WriteLiteral(">\r\n<!--<![endif]-->\r\n<head>\r\n");

            
            #line 13 "..\..\Views\Shared\_Layout.cshtml"
 if (ViewBag.EnableGoogleTagManager)
{

            
            #line default
            #line hidden
WriteLiteral("<!-- Google Tag Manager -->\r\n");

WriteLiteral(@"<script>(function(w,d,s,l,i){w[l]=w[l]||[];w[l].push({'gtm.start':
new Date().getTime(),event:'gtm.js'});var f=d.getElementsByTagName(s)[0],
j=d.createElement(s),dl=l!='dataLayer'?'&l='+l:'';j.async=true;j.src=
'https://www.googletagmanager.com/gtm.js?id='+i+dl;f.parentNode.insertBefore(j,f);
})(window,document,'script','dataLayer','");

            
            #line 20 "..\..\Views\Shared\_Layout.cshtml"
                                    Write(ViewBag.GoogleContainerId);

            
            #line default
            #line hidden
WriteLiteral("\');</script>\r\n");

WriteLiteral("<!-- End Google Tag Manager -->\r\n");

            
            #line 22 "..\..\Views\Shared\_Layout.cshtml"
}

            
            #line default
            #line hidden
WriteLiteral("    <meta");

WriteLiteral(" charset=\"utf-8\"");

WriteLiteral(">\r\n    <meta");

WriteLiteral(" http-equiv=\"X-UA-Compatible\"");

WriteLiteral(" content=\"IE=edge\"");

WriteLiteral(">\r\n    <title>");

            
            #line 25 "..\..\Views\Shared\_Layout.cshtml"
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

WriteAttribute("content", Tuple.Create(" content=\"", 1465), Tuple.Create("\"", 1516)
            
            #line 31 "..\..\Views\Shared\_Layout.cshtml"
, Tuple.Create(Tuple.Create("", 1475), Tuple.Create<System.Object, System.Int32>(Request.IsAuthenticated ? "Yes" : "No"
            
            #line default
            #line hidden
, 1475), false)
);

WriteLiteral("/>\r\n");

            
            #line 32 "..\..\Views\Shared\_Layout.cshtml"
    
            
            #line default
            #line hidden
            
            #line 32 "..\..\Views\Shared\_Layout.cshtml"
     if (ViewBag.ShouldRobotsIndexPage)
    {

            
            #line default
            #line hidden
WriteLiteral("        <meta");

WriteLiteral(" name=\"ROBOTS\"");

WriteLiteral(" content=\"NOFOLLOW\"");

WriteLiteral(">\r\n");

            
            #line 35 "..\..\Views\Shared\_Layout.cshtml"
    }
    else
    {

            
            #line default
            #line hidden
WriteLiteral("        <meta");

WriteLiteral(" name=\"ROBOTS\"");

WriteLiteral(" content=\"NOFOLLOW,NOINDEX\"");

WriteLiteral(">\r\n");

            
            #line 39 "..\..\Views\Shared\_Layout.cshtml"
    }

            
            #line default
            #line hidden
WriteLiteral("    ");

            
            #line 40 "..\..\Views\Shared\_Layout.cshtml"
Write(RenderSection("metatags", false));

            
            #line default
            #line hidden
WriteLiteral("\r\n    <!--[if gt IE 8]><!-->");

            
            #line 41 "..\..\Views\Shared\_Layout.cshtml"
                     Write(Styles.Render("~/Content/_assets/styles/not-ie8"));

            
            #line default
            #line hidden
WriteLiteral("<!--<![endif]-->\r\n    <!--[if lte IE 8]>");

            
            #line 42 "..\..\Views\Shared\_Layout.cshtml"
                 Write(Styles.Render("~/Content/_assets/styles/ie8"));

            
            #line default
            #line hidden
WriteLiteral("<![endif]-->\r\n    <link");

WriteLiteral(" rel=\"shortcut icon\"");

WriteAttribute("href", Tuple.Create(" href=\"", 1950), Tuple.Create("\"", 1985)
            
            #line 43 "..\..\Views\Shared\_Layout.cshtml"
, Tuple.Create(Tuple.Create("", 1957), Tuple.Create<System.Object, System.Int32>(Url.CdnImage("favicon.ico")
            
            #line default
            #line hidden
, 1957), false)
);

WriteLiteral(" type=\"image/x-icon\"");

WriteLiteral(">\r\n    <link");

WriteLiteral(" rel=\"apple-touch-icon-precomposed\"");

WriteLiteral(" sizes=\"152x152\"");

WriteAttribute("href", Tuple.Create(" href=\"", 2069), Tuple.Create("\"", 2121)
            
            #line 44 "..\..\Views\Shared\_Layout.cshtml"
, Tuple.Create(Tuple.Create("", 2076), Tuple.Create<System.Object, System.Int32>(Url.CdnImage("apple-touch-icon-152x152.png")
            
            #line default
            #line hidden
, 2076), false)
);

WriteLiteral(">\r\n    <link");

WriteLiteral(" rel=\"apple-touch-icon-precomposed\"");

WriteLiteral(" sizes=\"120x120\"");

WriteAttribute("href", Tuple.Create(" href=\"", 2185), Tuple.Create("\"", 2237)
            
            #line 45 "..\..\Views\Shared\_Layout.cshtml"
, Tuple.Create(Tuple.Create("", 2192), Tuple.Create<System.Object, System.Int32>(Url.CdnImage("apple-touch-icon-120x120.png")
            
            #line default
            #line hidden
, 2192), false)
);

WriteLiteral(">\r\n    <link");

WriteLiteral(" rel=\"apple-touch-icon-precomposed\"");

WriteLiteral(" sizes=\"76x76\"");

WriteAttribute("href", Tuple.Create(" href=\"", 2299), Tuple.Create("\"", 2349)
            
            #line 46 "..\..\Views\Shared\_Layout.cshtml"
, Tuple.Create(Tuple.Create("", 2306), Tuple.Create<System.Object, System.Int32>(Url.CdnImage("apple-touch-icon-76x76.png")
            
            #line default
            #line hidden
, 2306), false)
);

WriteLiteral(">\r\n    <link");

WriteLiteral(" rel=\"apple-touch-icon-precomposed\"");

WriteAttribute("href", Tuple.Create(" href=\"", 2397), Tuple.Create("\"", 2447)
            
            #line 47 "..\..\Views\Shared\_Layout.cshtml"
, Tuple.Create(Tuple.Create("", 2404), Tuple.Create<System.Object, System.Int32>(Url.CdnImage("apple-touch-icon-60x60.png")
            
            #line default
            #line hidden
, 2404), false)
);

WriteLiteral(">\r\n");

WriteLiteral("    ");

            
            #line 48 "..\..\Views\Shared\_Layout.cshtml"
Write(Styles.Render("~/bundles/font-awesome"));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

            
            #line 49 "..\..\Views\Shared\_Layout.cshtml"
 if (ViewBag.EnableAppInsights)
{

            
            #line default
            #line hidden
WriteLiteral("<script");

WriteLiteral(" type=\"text/javascript\"");

WriteLiteral(@">
  var appInsights=window.appInsights||function(config){
    function i(config){t[config]=function(){var i=arguments;t.queue.push(function(){t[config].apply(t,i)})}}var t={config:config},u=document,e=window,o=""script"",s=""AuthenticatedUserContext"",h=""start"",c=""stop"",l=""Track"",a=l+""Event"",v=l+""Page"",y=u.createElement(o),r,f;y.src=config.url||""https://az416426.vo.msecnd.net/scripts/a/ai.0.js"";u.getElementsByTagName(o)[0].parentNode.appendChild(y);try{t.cookie=u.cookie}catch(p){}for(t.queue=[],t.version=""1.0"",r=[""Event"",""Exception"",""Metric"",""PageView"",""Trace"",""Dependency""];r.length;)i(""track""+r.pop());return i(""set""+s),i(""clear""+s),i(h+a),i(c+a),i(h+v),i(c+v),i(""flush""),config.disableExceptionTracking||(r=""onerror"",i(""_""+r),f=e[r],e[r]=function(config,i,u,e,o){var s=f&&f(config,i,u,e,o);return s!==!0&&t[""_""+r](config,i,u,e,o),s}),t
    }({
        instrumentationKey:""");

            
            #line 55 "..\..\Views\Shared\_Layout.cshtml"
                       Write(ViewBag.AppInsightsInstrumentationKey);

            
            #line default
            #line hidden
WriteLiteral("\"\r\n    });\r\n       \r\n    window.appInsights=appInsights;\r\n    appInsights.trackPa" +
"geView();\r\n</script>\r\n");

            
            #line 61 "..\..\Views\Shared\_Layout.cshtml"
}

            
            #line default
            #line hidden
WriteLiteral("    ");

            
            #line 62 "..\..\Views\Shared\_Layout.cshtml"
Write(Html.Partial("_Scripts"));

            
            #line default
            #line hidden
WriteLiteral("\r\n</head>\r\n<body>\r\n");

            
            #line 65 "..\..\Views\Shared\_Layout.cshtml"
 if (ViewBag.EnableGoogleTagManager)
{

            
            #line default
            #line hidden
WriteLiteral("<!-- Google Tag Manager (noscript) -->\r\n");

WriteLiteral("<noscript><iframe");

WriteAttribute("src", Tuple.Create(" src=\"", 3734), Tuple.Create("\"", 3817)
            
            #line 68 "..\..\Views\Shared\_Layout.cshtml"
, Tuple.Create(Tuple.Create("", 3740), Tuple.Create<System.Object, System.Int32>("https://www.googletagmanager.com/ns.html?id=" + ViewBag.GoogleContainerId
            
            #line default
            #line hidden
, 3740), false)
);

WriteLiteral("\r\nheight=\"0\"");

WriteLiteral(" width=\"0\"");

WriteLiteral(" style=\"display:none;visibility:hidden\"");

WriteLiteral("></iframe></noscript>\r\n");

WriteLiteral("<!-- End Google Tag Manager (noscript) -->\r\n");

            
            #line 71 "..\..\Views\Shared\_Layout.cshtml"
}

            
            #line default
            #line hidden
            
            #line 72 "..\..\Views\Shared\_Layout.cshtml"
    
            
            #line default
            #line hidden
            
            #line 72 "..\..\Views\Shared\_Layout.cshtml"
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

WriteAttribute("href", Tuple.Create(" href=\'", 4213), Tuple.Create("\'", 4262)
            
            #line 76 "..\..\Views\Shared\_Layout.cshtml"
             , Tuple.Create(Tuple.Create("", 4220), Tuple.Create<System.Object, System.Int32>(Url.RouteUrl(CandidateRouteNames.Privacy)
            
            #line default
            #line hidden
, 4220), false)
);

WriteLiteral(">Find out more about cookies</a></span>\r\n            </div>\r\n        </div>\r\n");

            
            #line 79 "..\..\Views\Shared\_Layout.cshtml"
    }

            
            #line default
            #line hidden
WriteLiteral("\r\n");

            
            #line 81 "..\..\Views\Shared\_Layout.cshtml"
    
            
            #line default
            #line hidden
            
            #line 81 "..\..\Views\Shared\_Layout.cshtml"
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

            
            #line 86 "..\..\Views\Shared\_Layout.cshtml"
                    Write(Html.Raw(ViewBag.PlannedOutageMessage));

            
            #line default
            #line hidden
WriteLiteral("</div>\r\n                    <a");

WriteAttribute("href", Tuple.Create(" href=\"", 4704), Tuple.Create("\"", 4794)
            
            #line 87 "..\..\Views\Shared\_Layout.cshtml"
, Tuple.Create(Tuple.Create("", 4711), Tuple.Create<System.Object, System.Int32>(Url.RouteUrl(RouteNames.DismissPlannedOutageMessage, new { isJavascript = false })
            
            #line default
            #line hidden
, 4711), false)
);

WriteLiteral(" class=\"maintenance-close\"");

WriteLiteral(">\r\n                        <i");

WriteLiteral(" id=\"dismiss-planned-outage-message\"");

WriteLiteral(" class=\"icon-black fa fa-times-circle\"");

WriteLiteral("></i>\r\n                    </a>\r\n                </div>\r\n            </div>\r\n    " +
"    </div>\r\n");

            
            #line 93 "..\..\Views\Shared\_Layout.cshtml"
    }

            
            #line default
            #line hidden
WriteLiteral("\r\n    <div");

WriteLiteral(" class=\"skiplink-container\"");

WriteLiteral(">\r\n        <div>\r\n            <a");

WriteLiteral(" href=\"#main\"");

WriteLiteral(" class=\"skiplink\"");

WriteLiteral(">Skip to main content</a>\r\n        </div>\r\n    </div>\r\n    <header");

WriteLiteral(" role=\"banner\"");

WriteLiteral(" class=\"global-header\"");

WriteLiteral(">\r\n        <div");

WriteLiteral(" class=\"global-header__wrapper\"");

WriteLiteral(">\r\n            <div");

WriteLiteral(" class=\"global-header__logo\"");

WriteLiteral(">\r\n                <a");

WriteLiteral(" href=\"http://gov.uk\"");

WriteLiteral(" title=\"Go to the GOV.UK homepage\"");

WriteLiteral(" class=\"govuk-logo\"");

WriteLiteral(">\r\n                    <img");

WriteAttribute("src", Tuple.Create(" src=\"", 5440), Tuple.Create("\"", 5488)
            
            #line 104 "..\..\Views\Shared\_Layout.cshtml"
, Tuple.Create(Tuple.Create("", 5446), Tuple.Create<System.Object, System.Int32>(Url.CdnImage("gov.uk_logotype_crown.png")
            
            #line default
            #line hidden
, 5446), false)
);

WriteLiteral(" alt=\"Crown\"");

WriteLiteral(">\r\n                    GOV.UK\r\n                </a>\r\n            </div>\r\n        " +
"    ");

WriteLiteral("\r\n");

            
            #line 109 "..\..\Views\Shared\_Layout.cshtml"
            
            
            #line default
            #line hidden
            
            #line 109 "..\..\Views\Shared\_Layout.cshtml"
             if (ViewBag.UserJourney == UserJourney.Apprenticeship)
            {

            
            #line default
            #line hidden
WriteLiteral("                <div");

WriteLiteral(" class=\"global-header__nav\"");

WriteLiteral(">\r\n                    <div");

WriteLiteral(" id=\"global-header-title\"");

WriteLiteral(" class=\"global-header__title\"");

WriteLiteral("><a");

WriteLiteral(" id=\"headerLinkFAA\"");

WriteAttribute("href", Tuple.Create(" href=\"", 5859), Tuple.Create("\"", 5921)
            
            #line 112 "..\..\Views\Shared\_Layout.cshtml"
                           , Tuple.Create(Tuple.Create("", 5866), Tuple.Create<System.Object, System.Int32>(Url.RouteUrl(CandidateRouteNames.ApprenticeshipSearch)
            
            #line default
            #line hidden
, 5866), false)
);

WriteLiteral(">Find an apprenticeship</a></div>\r\n                </div>\r\n");

            
            #line 114 "..\..\Views\Shared\_Layout.cshtml"
            }
            else if (ViewBag.UserJourney == UserJourney.Traineeship)
            {

            
            #line default
            #line hidden
WriteLiteral("                <div");

WriteLiteral(" class=\"global-header__nav\"");

WriteLiteral(">\r\n                    <div");

WriteLiteral(" id=\"global-header-title\"");

WriteLiteral(" class=\"global-header__title\"");

WriteLiteral("><a");

WriteAttribute("href", Tuple.Create(" href=\"", 6212), Tuple.Create("\"", 6271)
            
            #line 118 "..\..\Views\Shared\_Layout.cshtml"
        , Tuple.Create(Tuple.Create("", 6219), Tuple.Create<System.Object, System.Int32>(Url.RouteUrl(CandidateRouteNames.TraineeshipSearch)
            
            #line default
            #line hidden
, 6219), false)
);

WriteLiteral(">Find a traineeship</a></div>\r\n                </div>\r\n");

            
            #line 120 "..\..\Views\Shared\_Layout.cshtml"
            }

            
            #line default
            #line hidden
WriteLiteral("        </div>\r\n    </header>\r\n    <div");

WriteLiteral(" class=\"content-container\"");

WriteLiteral(">\r\n        <div");

WriteLiteral(" class=\"fixed-container\"");

WriteLiteral(">\r\n            <div");

WriteLiteral(" class=\"banner-container\"");

WriteLiteral(">\r\n                <div");

WriteLiteral(" class=\"phase-notice gov-border grid-wrapper\"");

WriteLiteral(">\r\n                    <div");

WriteLiteral(" class=\"grid grid-1-2\"");

WriteLiteral(">\r\n                        &nbsp;\r\n                    </div>\r\n                  " +
"  <div");

WriteLiteral(" class=\"grid grid-1-2\"");

WriteLiteral(">\r\n");

WriteLiteral("                        ");

            
            #line 131 "..\..\Views\Shared\_Layout.cshtml"
                   Write(Html.Partial("_LoginPartial"));

            
            #line default
            #line hidden
WriteLiteral("\r\n                    </div>\r\n                </div>\r\n            </div>\r\n       " +
" </div>\r\n        <main");

WriteLiteral(" role=\"main\"");

WriteLiteral(" id=\"main\"");

WriteLiteral(">\r\n");

            
            #line 137 "..\..\Views\Shared\_Layout.cshtml"
            
            
            #line default
            #line hidden
            
            #line 137 "..\..\Views\Shared\_Layout.cshtml"
              
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

            
            #line 150 "..\..\Views\Shared\_Layout.cshtml"
                                               Write(Html.Raw(infoMessage));

            
            #line default
            #line hidden
WriteLiteral("</p>\r\n                        </div>\r\n");

            
            #line 152 "..\..\Views\Shared\_Layout.cshtml"
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

            
            #line 156 "..\..\Views\Shared\_Layout.cshtml"
                                                                             Write(Html.Raw(successMessage));

            
            #line default
            #line hidden
WriteLiteral("</p>\r\n                        </div>\r\n");

            
            #line 158 "..\..\Views\Shared\_Layout.cshtml"
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

            
            #line 162 "..\..\Views\Shared\_Layout.cshtml"
                                                  Write(Html.Raw(warningMessage));

            
            #line default
            #line hidden
WriteLiteral("</p>\r\n                        </div>\r\n");

            
            #line 164 "..\..\Views\Shared\_Layout.cshtml"
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

            
            #line 168 "..\..\Views\Shared\_Layout.cshtml"
                                                Write(Html.Raw(errorMessage));

            
            #line default
            #line hidden
WriteLiteral("</p>\r\n                        </div>\r\n");

            
            #line 170 "..\..\Views\Shared\_Layout.cshtml"
                    }
                }
            
            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("            ");

            
            #line 173 "..\..\Views\Shared\_Layout.cshtml"
       Write(RenderBody());

            
            #line default
            #line hidden
WriteLiteral("\r\n        </main>\r\n");

            
            #line 175 "..\..\Views\Shared\_Layout.cshtml"
        
            
            #line default
            #line hidden
            
            #line 175 "..\..\Views\Shared\_Layout.cshtml"
         if (ViewBag.EnableWebTrends == true)
        {

            
            #line default
            #line hidden
WriteLiteral("            <noscript>\r\n                <img");

WriteLiteral(" alt=\"dcsimg\"");

WriteLiteral(" id=\"dcsimg\"");

WriteLiteral(" width=\"1\"");

WriteLiteral(" height=\"1\"");

WriteAttribute("src", Tuple.Create(" src=\"", 8822), Tuple.Create("\"", 8984)
, Tuple.Create(Tuple.Create("", 8828), Tuple.Create("//stats.matraxis.net/", 8828), true)
            
            #line 178 "..\..\Views\Shared\_Layout.cshtml"
             , Tuple.Create(Tuple.Create("", 8849), Tuple.Create<System.Object, System.Int32>(ViewBag.WebTrendsDscId
            
            #line default
            #line hidden
, 8849), false)
, Tuple.Create(Tuple.Create("", 8872), Tuple.Create("/njs.gif?dcsuri=/nojavascript&amp;WT.js=No&amp;WT.tv=10.4.11&amp;WT.dl=0&amp;dcss" +
"ip=", 8872), true)
            
            #line 178 "..\..\Views\Shared\_Layout.cshtml"
                                                                                                                        , Tuple.Create(Tuple.Create("", 8956), Tuple.Create<System.Object, System.Int32>(ViewBag.WebTrendsDomainName
            
            #line default
            #line hidden
, 8956), false)
);

WriteLiteral(" />\r\n            </noscript>\r\n");

            
            #line 180 "..\..\Views\Shared\_Layout.cshtml"
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

WriteAttribute("href", Tuple.Create(" href=\'", 9323), Tuple.Create("\'", 9373)
            
            #line 188 "..\..\Views\Shared\_Layout.cshtml"
, Tuple.Create(Tuple.Create("", 9330), Tuple.Create<System.Object, System.Int32>(Url.RouteUrl(CandidateRouteNames.Helpdesk)
            
            #line default
            #line hidden
, 9330), false)
);

WriteLiteral(">Contact us</a>\r\n                        <a");

WriteLiteral(" class=\"footer__link bold-medium\"");

WriteAttribute("href", Tuple.Create(" href=\'", 9450), Tuple.Create("\'", 9500)
            
            #line 189 "..\..\Views\Shared\_Layout.cshtml"
, Tuple.Create(Tuple.Create("", 9457), Tuple.Create<System.Object, System.Int32>(Url.RouteUrl(CandidateRouteNames.Feedback)
            
            #line default
            #line hidden
, 9457), false)
);

WriteLiteral(">Give feedback</a>\r\n                    </li>\r\n                    <li");

WriteLiteral(" class=\"footer__link\"");

WriteLiteral("><a");

WriteAttribute("href", Tuple.Create(" href=\'", 9595), Tuple.Create("\'", 9644)
            
            #line 191 "..\..\Views\Shared\_Layout.cshtml"
, Tuple.Create(Tuple.Create("", 9602), Tuple.Create<System.Object, System.Int32>(Url.RouteUrl(CandidateRouteNames.Privacy)
            
            #line default
            #line hidden
, 9602), false)
);

WriteLiteral(">Privacy and cookies</a></li>\r\n                    <li");

WriteLiteral(" class=\"footer__link\"");

WriteLiteral("><a");

WriteAttribute("href", Tuple.Create(" href=\'", 9723), Tuple.Create("\'", 9770)
            
            #line 192 "..\..\Views\Shared\_Layout.cshtml"
, Tuple.Create(Tuple.Create("", 9730), Tuple.Create<System.Object, System.Int32>(Url.RouteUrl(CandidateRouteNames.Terms)
            
            #line default
            #line hidden
, 9730), false)
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

WriteAttribute("src", Tuple.Create(" src=\"", 10487), Tuple.Create("\"", 10528)
            
            #line 197 "..\..\Views\Shared\_Layout.cshtml"
, Tuple.Create(Tuple.Create("", 10493), Tuple.Create<System.Object, System.Int32>(Url.CdnImage("govuk-crest-2x.png")
            
            #line default
            #line hidden
, 10493), false)
);

WriteLiteral(" width=\"125\"");

WriteLiteral(" height=\"102\"");

WriteLiteral(" alt=\"Crown copyright logo\"");

WriteLiteral(">\r\n                    <p>&copy; Crown copyright</p>\r\n                </a>\r\n");

WriteLiteral("                ");

            
            #line 200 "..\..\Views\Shared\_Layout.cshtml"
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

            
            #line 209 "..\..\Views\Shared\_Layout.cshtml"
    
            
            #line default
            #line hidden
            
            #line 209 "..\..\Views\Shared\_Layout.cshtml"
     if (ViewBag.ShowAbout != null && ViewBag.ShowAbout == true)
    {
        
            
            #line default
            #line hidden
            
            #line 211 "..\..\Views\Shared\_Layout.cshtml"
   Write(Html.Partial("_AboutFull"));

            
            #line default
            #line hidden
            
            #line 211 "..\..\Views\Shared\_Layout.cshtml"
                                   
    }

            
            #line default
            #line hidden
WriteLiteral("\r\n    <!-- Placed at the end of the document so the pages load faster -->\r\n");

WriteLiteral("    ");

            
            #line 215 "..\..\Views\Shared\_Layout.cshtml"
Write(Scripts.Render("~/bundles/jquery"));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("    ");

            
            #line 216 "..\..\Views\Shared\_Layout.cshtml"
Write(Scripts.Render("~/bundles/fastclick"));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("    ");

            
            #line 217 "..\..\Views\Shared\_Layout.cshtml"
Write(Scripts.Render("~/bundles/underscore"));

            
            #line default
            #line hidden
WriteLiteral("\r\n\r\n    <script");

WriteLiteral(" type=\"text/javascript\"");

WriteLiteral(">\r\n        if (typeof jQuery === \'undefined\') {\r\n            var e = document.cre" +
"ateElement(\"script\");\r\n\r\n            e.src = \'");

            
            #line 223 "..\..\Views\Shared\_Layout.cshtml"
                Write(Url.Content("~/Content/_assets/js/vendor/jquery-1.11.1.js"));

            
            #line default
            #line hidden
WriteLiteral(@"';
            e.type = ""text/javascript"";
            document.getElementsByTagName(""head"")[0].appendChild(e);
        }

        $(function () {
            $(""#dismiss-planned-outage-message"").click(function (event) {

                event.preventDefault();

                var request = $.ajax({
                    type: ""GET"",
                    url: '");

            
            #line 235 "..\..\Views\Shared\_Layout.cshtml"
                     Write(Url.RouteUrl(RouteNames.DismissPlannedOutageMessage, new { isJavascript = true }));

            
            #line default
            #line hidden
WriteLiteral("\'\r\n                });\r\n\r\n                request.done(function () {\r\n\r\n         " +
"           $(\"#planned-outage-message\").hide();\r\n\r\n                });\r\n        " +
"    });\r\n\r\n");

            
            #line 245 "..\..\Views\Shared\_Layout.cshtml"
            
            
            #line default
            #line hidden
            
            #line 245 "..\..\Views\Shared\_Layout.cshtml"
             if (ViewBag.SavedAndDraftCount != null)
        {

            
            #line default
            #line hidden
WriteLiteral("            ");

WriteLiteral("UpdateSavedAndDraftCount(");

            
            #line 247 "..\..\Views\Shared\_Layout.cshtml"
                                  Write(ViewBag.SavedAndDraftCount);

            
            #line default
            #line hidden
WriteLiteral(");\r\n");

            
            #line 248 "..\..\Views\Shared\_Layout.cshtml"
                                }

            
            #line default
            #line hidden
WriteLiteral("\r\n");

            
            #line 250 "..\..\Views\Shared\_Layout.cshtml"
            
            
            #line default
            #line hidden
            
            #line 250 "..\..\Views\Shared\_Layout.cshtml"
             if (ViewBag.ApplicationStatusChangeCount != null)
        {

            
            #line default
            #line hidden
WriteLiteral("            ");

WriteLiteral("UpdateApplicationStatusChangeCount(");

            
            #line 252 "..\..\Views\Shared\_Layout.cshtml"
                                            Write(ViewBag.ApplicationStatusChangeCount);

            
            #line default
            #line hidden
WriteLiteral(");\r\n");

            
            #line 253 "..\..\Views\Shared\_Layout.cshtml"
                                }

            
            #line default
            #line hidden
WriteLiteral("        });\r\n    </script>\r\n\r\n");

WriteLiteral("    ");

            
            #line 257 "..\..\Views\Shared\_Layout.cshtml"
Write(Scripts.Render("~/bundles/nascript"));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("    ");

            
            #line 258 "..\..\Views\Shared\_Layout.cshtml"
Write(Scripts.Render("~/bundles/vendor"));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("    ");

            
            #line 259 "..\..\Views\Shared\_Layout.cshtml"
Write(Scripts.Render("~/bundles/nas"));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("    ");

            
            #line 260 "..\..\Views\Shared\_Layout.cshtml"
Write(RenderSection("scripts", required: false));

            
            #line default
            #line hidden
WriteLiteral("\r\n\r\n</body>\r\n</html>\r\n");

        }
    }
}
#pragma warning restore 1591
