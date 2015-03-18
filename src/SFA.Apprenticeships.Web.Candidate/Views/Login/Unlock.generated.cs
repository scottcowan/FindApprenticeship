﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34209
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
    using SFA.Apprenticeships.Web.Candidate;
    using SFA.Apprenticeships.Web.Candidate.Constants;
    using SFA.Apprenticeships.Web.Candidate.Constants.ViewModels;
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
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/Login/Unlock.cshtml")]
    public partial class Unlock : System.Web.Mvc.WebViewPage<AccountUnlockViewModel>
    {
        public Unlock()
        {
        }
        public override void Execute()
        {
            
            #line 3 "..\..\Views\Login\Unlock.cshtml"
  
    ViewBag.Title = "Account locked - Find an apprenticeship";
    Layout = "~/Views/Shared/_Layout.cshtml";

            
            #line default
            #line hidden
WriteLiteral("\r\n\r\n<h1");

WriteLiteral(" id=\"account-unlock-h1\"");

WriteLiteral(" class=\"heading-large\"");

WriteLiteral(">Account locked</h1>\r\n<p");

WriteLiteral(" class=\"text\"");

WriteLiteral(">You should receive a 6-character code in your email. Enter the code to unlock yo" +
"ur account.</p>\r\n\r\n");

            
            #line 11 "..\..\Views\Login\Unlock.cshtml"
Write(Html.Partial("ValidationSummary", ViewData.ModelState));

            
            #line default
            #line hidden
WriteLiteral("\r\n\r\n");

            
            #line 13 "..\..\Views\Login\Unlock.cshtml"
 using (Html.BeginForm("Unlock", "Login", FormMethod.Post, new { @id = "account-unlock-form" }))
{
    
            
            #line default
            #line hidden
            
            #line 15 "..\..\Views\Login\Unlock.cshtml"
Write(Html.AntiForgeryToken());

            
            #line default
            #line hidden
            
            #line 15 "..\..\Views\Login\Unlock.cshtml"
                            ;

            
            #line default
            #line hidden
WriteLiteral("    <div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(">\r\n");

WriteLiteral("        ");

            
            #line 17 "..\..\Views\Login\Unlock.cshtml"
   Write(Html.FormTextFor(
                m => m.EmailAddress,
                containerHtmlAttributes: new { @class = "form-group-withlink" },
                controlHtmlAttributes: new { type = "email", autofocus = "autofocus", spellcheck = "false" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n\r\n\r\n    </div>\r\n");

            
            #line 24 "..\..\Views\Login\Unlock.cshtml"

    
            
            #line default
            #line hidden
            
            #line 25 "..\..\Views\Login\Unlock.cshtml"
Write(Html.FormTextFor(
        m => m.AccountUnlockCode, 
        controlHtmlAttributes: new { @maxlength = "6" }, 
        containerHtmlAttributes: new { @class = "form-group-withlink" }));

            
            #line default
            #line hidden
            
            #line 28 "..\..\Views\Login\Unlock.cshtml"
                                                                        
    

            
            #line default
            #line hidden
WriteLiteral("    <div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(">\r\n        <button");

WriteLiteral(" class=\"button hide-button\"");

WriteLiteral(" type=\"submit\"");

WriteLiteral(" name=\"LoginAction:Unlock\"");

WriteLiteral(" tabindex=\"-1\"");

WriteLiteral(">Unlock account</button>\r\n        <button");

WriteLiteral(" id=\"ResendAccountUnlockCodeLink\"");

WriteLiteral(" type=\"submit\"");

WriteLiteral(" name=\"LoginAction:Resend\"");

WriteLiteral(" class=\"button-link\"");

WriteLiteral(" value=\"Resend\"");

WriteLiteral(" formnovalidate>Resend code</button>\r\n        <p>\r\n            <button");

WriteLiteral(" class=\"button\"");

WriteLiteral(" id=\"verify-code-button\"");

WriteLiteral(" type=\"submit\"");

WriteLiteral(" name=\"LoginAction:Unlock\"");

WriteLiteral(">Unlock account</button>\r\n        </p>\r\n    </div>\r\n");

            
            #line 37 "..\..\Views\Login\Unlock.cshtml"
}

            
            #line default
            #line hidden
        }
    }
}
#pragma warning restore 1591
