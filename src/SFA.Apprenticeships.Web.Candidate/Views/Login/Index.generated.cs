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

namespace SFA.Apprenticeships.Web.Candidate.Views.Login
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
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/Login/Index.cshtml")]
    public partial class Index : System.Web.Mvc.WebViewPage<LoginViewModel>
    {
        public Index()
        {
        }
        public override void Execute()
        {
            
            #line 3 "..\..\Views\Login\Index.cshtml"
  
    ViewBag.Title = "Sign in or Create an account - Find an apprenticeship";
    Layout = "~/Views/Shared/_Layout.cshtml";

            
            #line default
            #line hidden
WriteLiteral("\r\n\r\n");

            
            #line 8 "..\..\Views\Login\Index.cshtml"
Write(Html.Partial("ValidationSummary", ViewData.ModelState));

            
            #line default
            #line hidden
WriteLiteral("\r\n\r\n<div");

WriteLiteral(" class=\"grid-row\"");

WriteLiteral(">\r\n    <div");

WriteLiteral(" class=\"column-one-half\"");

WriteLiteral(">\r\n");

            
            #line 12 "..\..\Views\Login\Index.cshtml"
        
            
            #line default
            #line hidden
            
            #line 12 "..\..\Views\Login\Index.cshtml"
         using (Html.BeginRouteForm(RouteNames.SignIn, FormMethod.Post))
        {
            
            
            #line default
            #line hidden
            
            #line 14 "..\..\Views\Login\Index.cshtml"
       Write(Html.AntiForgeryToken());

            
            #line default
            #line hidden
            
            #line 14 "..\..\Views\Login\Index.cshtml"
                                    ;

            
            #line default
            #line hidden
WriteLiteral("            <h1");

WriteLiteral(" class=\"heading-large\"");

WriteLiteral(">Sign in</h1>\r\n");

WriteLiteral("            <p");

WriteLiteral(" class=\"sfa-hide-tablet\"");

WriteLiteral(">\r\n");

WriteLiteral("                ");

            
            #line 17 "..\..\Views\Login\Index.cshtml"
           Write(Html.ActionLink("Create an account", controllerName: "Register", actionName: "Index"));

            
            #line default
            #line hidden
WriteLiteral(".\r\n            </p>\r\n");

            
            #line 19 "..\..\Views\Login\Index.cshtml"

            
            
            #line default
            #line hidden
            
            #line 20 "..\..\Views\Login\Index.cshtml"
       Write(Html.FormTextFor(
                m => m.EmailAddress,
                containerHtmlAttributes: new { @class = "form-group-compound" },
                controlHtmlAttributes: new { @class = "form-control-3-4", type = "email", autofocus = "autofocus", spellcheck = "false" }));

            
            #line default
            #line hidden
            
            #line 23 "..\..\Views\Login\Index.cshtml"
                                                                                                                                          


            
            #line default
            #line hidden
WriteLiteral("            <div");

WriteLiteral(" class=\"form-group form-group-compound\"");

WriteLiteral(">\r\n                <a");

WriteLiteral(" id=\"password\"");

WriteLiteral("></a>\r\n");

WriteLiteral("                ");

            
            #line 27 "..\..\Views\Login\Index.cshtml"
           Write(Html.LabelFor(m => m.Password, new { @class = "form-label-bold" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("                ");

            
            #line 28 "..\..\Views\Login\Index.cshtml"
           Write(Html.ValidationMessageFor(m => m.Password, null));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("                ");

            
            #line 29 "..\..\Views\Login\Index.cshtml"
           Write(Html.PasswordFor(m => m.Password, new { @class = "form-control form-control-3-4" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n            </div>\r\n");

            
            #line 31 "..\..\Views\Login\Index.cshtml"


            
            #line default
            #line hidden
WriteLiteral("            <div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(">\r\n                <p><a");

WriteAttribute("href", Tuple.Create(" href=\'", 1345), Tuple.Create("\'", 1398)
            
            #line 33 "..\..\Views\Login\Index.cshtml"
, Tuple.Create(Tuple.Create("", 1352), Tuple.Create<System.Object, System.Int32>(Url.RouteUrl(RouteNames.ForgottenCredentials)
            
            #line default
            #line hidden
, 1352), false)
);

WriteLiteral(">I can\'t access my account</a></p>\r\n            </div>\r\n");

            
            #line 35 "..\..\Views\Login\Index.cshtml"


            
            #line default
            #line hidden
WriteLiteral("            <div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(">\r\n                <button");

WriteLiteral(" class=\"button\"");

WriteLiteral(" id=\"sign-in-button\"");

WriteLiteral(">Sign in</button>\r\n            </div>\r\n");

WriteLiteral("            <div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(">\r\n                <details");

WriteLiteral(" class=\"text sfa-hide-tablet\"");

WriteLiteral(">\r\n                    <summary><span");

WriteLiteral(" class=\"summary\"");

WriteLiteral(">Activate your account</span></summary>\r\n                    <div");

WriteLiteral(" class=\"panel panel-border-narrow\"");

WriteLiteral(">\r\n                        <ol");

WriteLiteral(" class=\"list list-number\"");

WriteLiteral(@">
                            <li>Once you've created an account we'll send you an activation code.</li>
                            <li>Sign in using your email address and password.</li>
                            <li>You'll then be asked to enter your activation code.</li>
                        </ol>
                    </div>
                </details>
            </div>
");

            
            #line 51 "..\..\Views\Login\Index.cshtml"
        }

            
            #line default
            #line hidden
WriteLiteral("    </div>\r\n    <div");

WriteLiteral(" class=\"column-one-half\"");

WriteLiteral(">\r\n        <h2");

WriteLiteral(" class=\"heading-large\"");

WriteLiteral(">New to this service?</h2>\r\n        <div >\r\n            <p>\r\n                If y" +
"ou haven’t used this service before you must\r\n");

WriteLiteral("                ");

            
            #line 58 "..\..\Views\Login\Index.cshtml"
           Write(Html.ActionLink("create an account", "Index", "Register", null, new { id = "create-account-link", @class = "inl-block" }));

            
            #line default
            #line hidden
WriteLiteral(", even if you already have an existing account with \"Apprenticeship vacancies\".\r\n" +
"            </p>\r\n            <p");

WriteLiteral(" class=\"sfa-small-bottom-margin\"");

WriteLiteral(">Creating an account allows you to:</p>\r\n            <ul");

WriteLiteral(" class=\"list list-bullet\"");

WriteLiteral(">\r\n                <li>apply for an apprenticeship or traineeship</li>\r\n         " +
"       <li>track your apprenticeship applications</li>\r\n                <li>rece" +
"ive alerts about new apprenticeships</li>\r\n            </ul>\r\n        </div>\r\n  " +
"      <details");

WriteLiteral(" class=\"text sfa-hide-mobile\"");

WriteLiteral(">\r\n            <summary><span");

WriteLiteral(" class=\"summary\"");

WriteLiteral(">Activate your account</span></summary>\r\n            <div");

WriteLiteral(" class=\"panel panel-border-narrow\"");

WriteLiteral(">\r\n                <ol");

WriteLiteral(" class=\"list list-number\"");

WriteLiteral(@">
                    <li>Once you've created an account we'll send you an activation code.</li>
                    <li>Sign in using your email address and password.</li>
                    <li>You'll then be asked to enter your activation code.</li>
                </ol>
            </div>
        </details>
    </div>
</div>
");

        }
    }
}
#pragma warning restore 1591
