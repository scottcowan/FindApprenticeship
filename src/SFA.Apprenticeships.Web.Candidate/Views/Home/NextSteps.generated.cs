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

namespace SFA.Apprenticeships.Web.Candidate.Views.Home
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
    using SFA.Apprenticeships.Web.Candidate.Constants;
    using SFA.Apprenticeships.Web.Candidate.Constants.ViewModels;
    using SFA.Apprenticeships.Web.Candidate.Helpers;
    using SFA.Apprenticeships.Web.Candidate.ViewModels;
    using SFA.Apprenticeships.Web.Candidate.ViewModels.Login;
    using SFA.Apprenticeships.Web.Candidate.ViewModels.Register;
    using SFA.Apprenticeships.Web.Candidate.ViewModels.VacancySearch;
    using SFA.Apprenticeships.Web.Common.Constants;
    using SFA.Apprenticeships.Web.Common.Framework;
    using SFA.Apprenticeships.Web.Common.Models.Common;
    using SFA.Apprenticeships.Web.Common.ViewModels;
    using SFA.Apprenticeships.Web.Common.ViewModels.Candidate;
    using SFA.Apprenticeships.Web.Common.ViewModels.Locations;
    using SFA.Apprenticeships.Web.Common.ViewModels.VacancySearch;
    using SFA.Apprenticeships.Web.Common.Views.Shared.DisplayTemplates;
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/Home/NextSteps.cshtml")]
    public partial class NextSteps : System.Web.Mvc.WebViewPage<dynamic>
    {
        public NextSteps()
        {
        }
        public override void Execute()
        {
            
            #line 1 "..\..\Views\Home\NextSteps.cshtml"
  
    ViewBag.Title = "Next steps - Find an apprenticeship";
    Layout = "~/Views/Shared/_Layout.cshtml";

            
            #line default
            #line hidden
WriteLiteral("\r\n\r\n<h2");

WriteLiteral(" class=\"heading-xlarge\"");

WriteLiteral(">Next steps</h2>\r\n<div");

WriteLiteral(" class=\"text\"");

WriteLiteral(">\r\n    <p>\r\n        If your application was unsuccessful there are a few things y" +
"ou can do\r\n        to ensure you have a better chance next time.\r\n    </p>\r\n</di" +
"v>\r\n<div");

WriteLiteral(" class=\"text\"");

WriteLiteral(">\r\n    <p>\r\n        Read the <a");

WriteLiteral(" href=\"https://nationalcareersservice.direct.gov.uk/advice/courses/typesoflearnin" +
"g/Pages/apprenticeship-application-help.aspx\"");

WriteLiteral("\r\n                    rel=\"external\"");

WriteLiteral(" target=\"_blank\"");

WriteLiteral(">National Careers Service’s application guide</a> if you\'d like more advice.\r\n   " +
" </p>\r\n    <p>\r\n        To help you write a better application you can take a gu" +
"ided tour of\r\n        the application form.\r\n    </p>\r\n    <div");

WriteLiteral(" class=\"form-group hide-nojs\"");

WriteLiteral(">\r\n");

WriteLiteral("        ");

            
            #line 23 "..\..\Views\Home\NextSteps.cshtml"
   Write(Html.RouteLink("Start tour", CandidateRouteNames.HowToApply, null, new { @class = "button" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n    </div>\r\n</div>\r\n<div");

WriteLiteral(" class=\"text\"");

WriteLiteral(">\r\n    <h3");

WriteLiteral(" class=\"heading-medium heading-with-check\"");

WriteLiteral(">\r\n        <i");

WriteLiteral(" class=\"font-large fa fa-users\"");

WriteLiteral("></i>What the shortlisters say\r\n    </h3>\r\n    <div");

WriteLiteral(" class=\"panel-indent\"");

WriteLiteral(">\r\n        <div");

WriteLiteral(" class=\"med-btm-margin\"");

WriteLiteral(">\r\n            <p>\r\n                <i");

WriteLiteral(" class=\"fa fa-quote-left\"");

WriteLiteral(@"></i>Good applicants have well-written
                application forms where they have taken the time to give examples
                of their skills and have a good balance between academic achievement
                and enthusiasm for the job/industry that they are applying for.
            </p>
        </div>
        <div");

WriteLiteral(" class=\"med-btm-margin\"");

WriteLiteral(">\r\n            <p>\r\n                <i");

WriteLiteral(" class=\"fa fa-quote-left\"");

WriteLiteral("></i>Your application needs to show that\r\n                you have thought about " +
"why you are applying for the job.\r\n            </p>\r\n        </div>\r\n        <di" +
"v");

WriteLiteral(" class=\"med-btm-margin\"");

WriteLiteral(">\r\n            <p>\r\n                <i");

WriteLiteral(" class=\"fa fa-quote-left\"");

WriteLiteral(@"></i>Avoid poor spelling, grammar and
                punctuation. This is critical if you want to be taken seriously
                in your application. Ask someone else with a good eye for detail
                to proofread your application before you submit it.
            </p>
        </div>
        <div");

WriteLiteral(" class=\"med-btm-margin\"");

WriteLiteral(">\r\n            <p>\r\n                <i");

WriteLiteral(" class=\"fa fa-quote-left\"");

WriteLiteral("></i>Remember to tailor your application\r\n                for the job that you ar" +
"e applying for.\r\n            </p>\r\n        </div>\r\n    </div>\r\n    <h3");

WriteLiteral(" class=\"heading-medium heading-with-check\"");

WriteLiteral(">\r\n        <i");

WriteLiteral(" class=\"font-large fa fa-check-square-o\"");

WriteLiteral("></i>Mistakes can spell trouble\r\n    </h3>\r\n    <details>\r\n        <summary>More " +
"details</summary>\r\n        <div");

WriteLiteral(" class=\"detail-content panel-indent\"");

WriteLiteral(@">
            <p>
                Mistakes make employers think you haven’t taken the time to get things
                right. They could be concerned about how you will communicate with
                customers and other organisations.
            </p>
            <p>
                If spelling and grammar aren’t your strong points, ask someone who’s
                good with words to check your application. Our advisers can also
                tell you how to improve your writing.
            </p>
        </div>
    </details>
    <h3");

WriteLiteral(" class=\"heading-medium heading-with-check\"");

WriteLiteral(">\r\n        <i");

WriteLiteral(" class=\"font-large fa fa-check-square-o\"");

WriteLiteral("></i>Tailored applications, not mass mailshot\r\n    </h3>\r\n    <details>\r\n        " +
"<summary>More details</summary>\r\n        <div");

WriteLiteral(" class=\"detail-content panel-indent\"");

WriteLiteral(@">
            <p>
                Employers will be impressed if your application seems carefully considered,
                and if you’ve made an effort to understand the role and what’s
                required of you.
            </p>
            <p>
                You can create this impression by applying for fewer jobs but taking
                the time to make sure each application is tailored to an organisation
                and role.
            </p>
        </div>
    </details>
    <h3");

WriteLiteral(" class=\"heading-medium heading-with-check\"");

WriteLiteral(">\r\n        <i");

WriteLiteral(" class=\"font-large fa fa-check-square-o\"");

WriteLiteral("></i>The perfect apprentice\r\n    </h3>\r\n    <details>\r\n        <summary>More deta" +
"ils</summary>\r\n        <div");

WriteLiteral(" class=\"detail-content panel-indent\"");

WriteLiteral(">\r\n            Employers want an apprentice who’s:\r\n            <ul");

WriteLiteral(" class=\"list-bullet med-btm-margin\"");

WriteLiteral(@">
                <li>reliable</li>
                <li>hard-working</li>
                <li>eager to learn</li>
                <li>good at dealing with people</li>
            </ul>
            <p>
                In your application try to include examples of times when you’ve
                shown these qualities. You can then apply for another apprenticeship
                and see if you're more successful.
            </p>
        </div>
    </details>
    <p>
        If you'd like more advice on careers contact the
        <a");

WriteLiteral(" href=\"https://nationalcareersservice.direct.gov.uk/advice/Pages/default.aspx\"");

WriteLiteral("\r\n            rel=\"external\"");

WriteLiteral(" target=\"_blank\"");

WriteLiteral(">National Careers Service</a>.\r\n    </p>\r\n    <div");

WriteLiteral(" class=\"get-started\"");

WriteLiteral(">\r\n        <div");

WriteLiteral(" class=\"get-started\"");

WriteLiteral(">");

            
            #line 122 "..\..\Views\Home\NextSteps.cshtml"
                            Write(Html.RouteLink("Find an apprenticeship", CandidateRouteNames.ApprenticeshipSearch, null, new { @id = "find-apprenticeship-button", @class = "button" }));

            
            #line default
            #line hidden
WriteLiteral("</div>\r\n    </div>\r\n</div>\r\n<ol");

WriteLiteral(" id=\"newAppChanges\"");

WriteLiteral(" class=\"alwayshidden\"");

WriteLiteral(">\r\n    <li");

WriteLiteral(" class=\"tourPushDown\"");

WriteLiteral(" data-id=\"applicationsLink\"");

WriteLiteral(" data-button=\"Close\"");

WriteLiteral(">\r\n        <h3");

WriteLiteral(" class=\"heading-small\"");

WriteLiteral(">Updates to your applications</h3>\r\n        <p");

WriteLiteral(" aria-live=\"polite\"");

WriteLiteral(">You\'ve got 2 updates</p>\r\n    </li>\r\n</ol>\r\n");

        }
    }
}
#pragma warning restore 1591
