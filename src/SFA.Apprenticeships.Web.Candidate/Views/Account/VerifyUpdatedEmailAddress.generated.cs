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

namespace SFA.Apprenticeships.Web.Candidate.Views.Account
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
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/Account/VerifyUpdatedEmailAddress.cshtml")]
    public partial class VerifyUpdatedEmailAddress : System.Web.Mvc.WebViewPage<SFA.Apprenticeships.Web.Candidate.ViewModels.Account.VerifyUpdatedEmailViewModel>
    {
        public VerifyUpdatedEmailAddress()
        {
        }
        public override void Execute()
        {
            
            #line 2 "..\..\Views\Account\VerifyUpdatedEmailAddress.cshtml"
  
    ViewBag.Title = "Verify your email address - Find an apprenticeship";
    Layout = "~/Views/Shared/_Layout.cshtml";

            
            #line default
            #line hidden
WriteLiteral("\r\n\r\n<div");

WriteLiteral(" class=\"grid-row\"");

WriteLiteral(">\r\n    <div");

WriteLiteral(" class=\"column-two-thirds\"");

WriteLiteral(">\r\n        <h1");

WriteLiteral(" class=\"heading-xlarge\"");

WriteLiteral(">Verify your email address</h1>\r\n    </div>\r\n    <div");

WriteLiteral(" class=\"column-one-third sfa-align-right-tablet sfa-xlarge-top-margin\"");

WriteLiteral(">\r\n        <ul");

WriteLiteral(" class=\"list\"");

WriteLiteral(">\r\n            <li>\r\n");

WriteLiteral("                ");

            
            #line 14 "..\..\Views\Account\VerifyUpdatedEmailAddress.cshtml"
           Write(Html.RouteLink("Find an apprenticeship", CandidateRouteNames.ApprenticeshipSearch, null, new { id = "find-apprenticeship-link", @class = "" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n            </li>\r\n        </ul>\r\n    </div>\r\n</div>\r\n<p >\r\n    You\'ve been sen" +
"t a code to your new email address, enter your code to verify\r\n    your address." +
"\r\n</p>\r\n\r\n");

            
            #line 24 "..\..\Views\Account\VerifyUpdatedEmailAddress.cshtml"
 using (Html.BeginRouteForm(RouteNames.VerifyUpdatedEmail, FormMethod.Post, new {autocomplete = "off"}))
{
    
            
            #line default
            #line hidden
            
            #line 26 "..\..\Views\Account\VerifyUpdatedEmailAddress.cshtml"
Write(Html.AntiForgeryToken());

            
            #line default
            #line hidden
            
            #line 26 "..\..\Views\Account\VerifyUpdatedEmailAddress.cshtml"
                            
    
            
            #line default
            #line hidden
            
            #line 27 "..\..\Views\Account\VerifyUpdatedEmailAddress.cshtml"
Write(Html.Partial("ValidationSummary", ViewData.ModelState));

            
            #line default
            #line hidden
            
            #line 27 "..\..\Views\Account\VerifyUpdatedEmailAddress.cshtml"
                                                           

            
            #line default
            #line hidden
WriteLiteral("    <input");

WriteLiteral(" type=\"password\"");

WriteLiteral(" title=\"Hidden password field to stop autocomplete\"");

WriteLiteral(" value=\"\"");

WriteLiteral(" class=\"sfa-hide\"");

WriteLiteral(" />\r\n");

WriteLiteral("    <input");

WriteLiteral(" type=\"password\"");

WriteLiteral(" title=\"Hidden password field to stop autocomplete\"");

WriteLiteral(" value=\"\"");

WriteLiteral(" class=\"sfa-hide\"");

WriteLiteral(" />\r\n");

            
            #line 30 "..\..\Views\Account\VerifyUpdatedEmailAddress.cshtml"

    
            
            #line default
            #line hidden
            
            #line 31 "..\..\Views\Account\VerifyUpdatedEmailAddress.cshtml"
Write(Html.FormTextFor(m => m.PendingUsernameCode, controlHtmlAttributes: new { spellcheck = "false", autofocus = "autofocus", autocomplete = "off" }, labelText: "Enter code", containerHtmlAttributes: new { @class = "form-group-withlink" }));

            
            #line default
            #line hidden
            
            #line 31 "..\..\Views\Account\VerifyUpdatedEmailAddress.cshtml"
                                                                                                                                                                                                                                               
    

            
            #line default
            #line hidden
WriteLiteral("    <div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(">\r\n        <p>\r\n            <a");

WriteAttribute("href", Tuple.Create(" href=\"", 1538), Tuple.Create("\"", 1608)
            
            #line 35 "..\..\Views\Account\VerifyUpdatedEmailAddress.cshtml"
, Tuple.Create(Tuple.Create("", 1545), Tuple.Create<System.Object, System.Int32>(Url.RouteUrl(CandidateRouteNames.ResendUpdateEmailAddressCode)
            
            #line default
            #line hidden
, 1545), false)
);

WriteLiteral(" title=\"Resend code\"");

WriteLiteral(">Resend code</a>\r\n        </p>\r\n    </div>\r\n");

            
            #line 38 "..\..\Views\Account\VerifyUpdatedEmailAddress.cshtml"
    
    
            
            #line default
            #line hidden
            
            #line 39 "..\..\Views\Account\VerifyUpdatedEmailAddress.cshtml"
Write(Html.FormPasswordFor(m => m.VerifyPassword, controlHtmlAttributes: new { autocomplete = "off" }));

            
            #line default
            #line hidden
            
            #line 39 "..\..\Views\Account\VerifyUpdatedEmailAddress.cshtml"
                                                                                                     
    

            
            #line default
            #line hidden
WriteLiteral("    <div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(">\r\n        <button");

WriteLiteral(" class=\"button\"");

WriteLiteral(" id=\"verify-email-button\"");

WriteLiteral(">Verify email</button>\r\n    </div>\r\n");

            
            #line 44 "..\..\Views\Account\VerifyUpdatedEmailAddress.cshtml"
}

            
            #line default
            #line hidden
        }
    }
}
#pragma warning restore 1591
