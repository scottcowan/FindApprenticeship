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

namespace SFA.Apprenticeships.Web.Raa.Common.Views.Shared.DisplayTemplates.Vacancy
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
    using SFA.Apprenticeships.Web.Common.Constants;
    using SFA.Apprenticeships.Web.Common.Framework;
    using SFA.Apprenticeships.Web.Common.Models.Common;
    using SFA.Apprenticeships.Web.Raa.Common;
    
    #line 2 "..\..\Views\Shared\DisplayTemplates\Vacancy\EmployerQuestions.cshtml"
    using SFA.Apprenticeships.Web.Raa.Common.Extensions;
    
    #line default
    #line hidden
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/Shared/DisplayTemplates/Vacancy/EmployerQuestions.cshtml")]
    public partial class EmployerQuestions : System.Web.Mvc.WebViewPage<SFA.Apprenticeships.Web.Raa.Common.ViewModels.Vacancy.VacancyQuestionsViewModel>
    {
        public EmployerQuestions()
        {
        }
        public override void Execute()
        {
WriteLiteral("\r\n");

            
            #line 4 "..\..\Views\Shared\DisplayTemplates\Vacancy\EmployerQuestions.cshtml"
  
    ViewBag.Title = "Recruit an Apprentice - Extra questions you'd like to ask candidates (optional)";

            
            #line default
            #line hidden
WriteLiteral("\r\n\r\n<h1");

WriteLiteral(" class=\"heading-xlarge\"");

WriteLiteral(">\r\n    Extra questions you\'d like to ask candidates (optional)\r\n</h1>\r\n\r\n");

            
            #line 12 "..\..\Views\Shared\DisplayTemplates\Vacancy\EmployerQuestions.cshtml"
Write(Html.AntiForgeryToken());

            
            #line default
            #line hidden
WriteLiteral("\r\n");

            
            #line 13 "..\..\Views\Shared\DisplayTemplates\Vacancy\EmployerQuestions.cshtml"
Write(Html.Partial("ValidationSummary", ViewData.ModelState));

            
            #line default
            #line hidden
WriteLiteral("\r\n\r\n");

            
            #line 15 "..\..\Views\Shared\DisplayTemplates\Vacancy\EmployerQuestions.cshtml"
Write(Html.HiddenFor(m => m.VacancyReferenceNumber));

            
            #line default
            #line hidden
WriteLiteral("\r\n\r\n<section>\r\n    <div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(">\r\n");

WriteLiteral("        ");

            
            #line 19 "..\..\Views\Shared\DisplayTemplates\Vacancy\EmployerQuestions.cshtml"
   Write(Html.FormTextAreaFor(m => m.FirstQuestion, controlHtmlAttributes: new { @class = "form-control form-control-4-4 form-textarea-medium", type = "text" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("        ");

            
            #line 20 "..\..\Views\Shared\DisplayTemplates\Vacancy\EmployerQuestions.cshtml"
   Write(Html.EditorFor(m => m.FirstQuestionComment, "Comment", Html.GetLabelFor(m => m.FirstQuestionComment)));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("        ");

            
            #line 21 "..\..\Views\Shared\DisplayTemplates\Vacancy\EmployerQuestions.cshtml"
   Write(Html.FormTextAreaFor(m => m.SecondQuestion, controlHtmlAttributes: new { @class = "form-control form-control-4-4 form-textarea-medium", type = "text" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("        ");

            
            #line 22 "..\..\Views\Shared\DisplayTemplates\Vacancy\EmployerQuestions.cshtml"
   Write(Html.EditorFor(m => m.SecondQuestionComment, "Comment", Html.GetLabelFor(m => m.SecondQuestionComment)));

            
            #line default
            #line hidden
WriteLiteral("\r\n    </div>\r\n</section>");

        }
    }
}
#pragma warning restore 1591
