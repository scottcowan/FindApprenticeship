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
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/Home/Feedback.cshtml")]
    public partial class Feedback : System.Web.Mvc.WebViewPage<SFA.Apprenticeships.Web.Candidate.ViewModels.Home.FeedbackViewModel>
    {
        public Feedback()
        {
        }
        public override void Execute()
        {
            
            #line 3 "..\..\Views\Home\Feedback.cshtml"
  
    ViewBag.Title = "Give feedback - Find an apprenticeship";
    Layout = "~/Views/Shared/_Layout.cshtml";

            
            #line default
            #line hidden
WriteLiteral("\r\n\r\n<div");

WriteLiteral(" class=\"hgroup\"");

WriteLiteral(">\r\n    <h1");

WriteLiteral(" class=\"heading-xlarge\"");

WriteLiteral(">Give feedback</h1>\r\n</div>\r\n\r\n");

            
            #line 12 "..\..\Views\Home\Feedback.cshtml"
 using (Html.BeginForm("Feedback", "Home", FormMethod.Post))
{
    
            
            #line default
            #line hidden
            
            #line 14 "..\..\Views\Home\Feedback.cshtml"
Write(Html.AntiForgeryToken());

            
            #line default
            #line hidden
            
            #line 14 "..\..\Views\Home\Feedback.cshtml"
                            
    
            
            #line default
            #line hidden
            
            #line 15 "..\..\Views\Home\Feedback.cshtml"
Write(Html.FormTextFor(
            m => m.Name,
            containerHtmlAttributes: new { @class = "form-group-compound" },
            controlHtmlAttributes: new { type = "text", autocorrect = "off", maxlength = "71" }));

            
            #line default
            #line hidden
            
            #line 18 "..\..\Views\Home\Feedback.cshtml"
                                                                                                

    
            
            #line default
            #line hidden
            
            #line 20 "..\..\Views\Home\Feedback.cshtml"
Write(Html.FormTextFor(
            m => m.Email,
            containerHtmlAttributes: new { @class = "form-group-compound" },
                controlHtmlAttributes: new { type = "email", spellcheck = "false", maxlength = "100" },
            hintHtmlAttributes: new { @class = "text" }));

            
            #line default
            #line hidden
            
            #line 24 "..\..\Views\Home\Feedback.cshtml"
                                                        

    
            
            #line default
            #line hidden
            
            #line 26 "..\..\Views\Home\Feedback.cshtml"
Write(Html.FormTextAreaFor(m => m.Details,
                controlHtmlAttributes: new { @data_val_length_max = "4000", rows = "4", role = "textbox", aria_multiline = "true" },
                hintHtmlAttributes: new { @class = "text" }));

            
            #line default
            #line hidden
            
            #line 28 "..\..\Views\Home\Feedback.cshtml"
                                                            
    

            
            #line default
            #line hidden
WriteLiteral("    <div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(">\r\n        <button");

WriteLiteral(" id=\"give-feedback-form-button\"");

WriteLiteral(" class=\"button\"");

WriteLiteral(">Give feedback</button>\r\n    </div>\r\n");

            
            #line 33 "..\..\Views\Home\Feedback.cshtml"
}

            
            #line default
            #line hidden
        }
    }
}
#pragma warning restore 1591