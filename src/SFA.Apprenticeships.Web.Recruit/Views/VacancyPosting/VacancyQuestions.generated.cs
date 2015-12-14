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

namespace SFA.Apprenticeships.Web.Recruit.Views.VacancyPosting
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
    
    #line 2 "..\..\Views\VacancyPosting\VacancyQuestions.cshtml"
    using SFA.Apprenticeships.Domain.Entities.Vacancies.ProviderVacancies;
    
    #line default
    #line hidden
    using SFA.Apprenticeships.Web.Common.Constants;
    using SFA.Apprenticeships.Web.Common.Framework;
    using SFA.Apprenticeships.Web.Common.Models.Common;
    using SFA.Apprenticeships.Web.Raa.Common.Views.Shared.DisplayTemplates;
    using SFA.Apprenticeships.Web.Raa.Common.Views.Shared.EditorTemplates;
    using SFA.Apprenticeships.Web.Recruit;
    
    #line 3 "..\..\Views\VacancyPosting\VacancyQuestions.cshtml"
    using SFA.Apprenticeships.Web.Recruit.Constants;
    
    #line default
    #line hidden
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/VacancyPosting/VacancyQuestions.cshtml")]
    public partial class VacancyQuestions : System.Web.Mvc.WebViewPage<SFA.Apprenticeships.Web.Raa.Common.ViewModels.Vacancy.VacancyQuestionsViewModel>
    {
        public VacancyQuestions()
        {
        }
        public override void Execute()
        {
            
            #line 4 "..\..\Views\VacancyPosting\VacancyQuestions.cshtml"
  
    ViewBag.Title = "Recruit an Apprentice - Enter vacancy question";

    var saveButtonText = (Model.Status == ProviderVacancyStatuses.RejectedByQA || Model.ComeFromPreview) ? "Save and return to Preview" : "Save and preview vacancy";

            
            #line default
            #line hidden
WriteLiteral("\r\n\r\n<h1");

WriteLiteral(" class=\"heading-xlarge\"");

WriteLiteral(">\r\n    Questions for candidates\r\n</h1>\r\n\r\n");

            
            #line 14 "..\..\Views\VacancyPosting\VacancyQuestions.cshtml"
 using (Html.BeginRouteForm(RecruitmentRouteNames.VacancyQuestions, FormMethod.Post))
{
    
            
            #line default
            #line hidden
            
            #line 16 "..\..\Views\VacancyPosting\VacancyQuestions.cshtml"
Write(Html.AntiForgeryToken());

            
            #line default
            #line hidden
            
            #line 16 "..\..\Views\VacancyPosting\VacancyQuestions.cshtml"
                            
    
            
            #line default
            #line hidden
            
            #line 17 "..\..\Views\VacancyPosting\VacancyQuestions.cshtml"
Write(Html.Partial("ValidationSummary", ViewData.ModelState));

            
            #line default
            #line hidden
            
            #line 17 "..\..\Views\VacancyPosting\VacancyQuestions.cshtml"
                                                           

    
            
            #line default
            #line hidden
            
            #line 19 "..\..\Views\VacancyPosting\VacancyQuestions.cshtml"
Write(Html.HiddenFor(m => m.VacancyReferenceNumber));

            
            #line default
            #line hidden
            
            #line 19 "..\..\Views\VacancyPosting\VacancyQuestions.cshtml"
                                                  


            
            #line default
            #line hidden
WriteLiteral("    <section>\r\n        <div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(">\r\n");

WriteLiteral("            ");

            
            #line 23 "..\..\Views\VacancyPosting\VacancyQuestions.cshtml"
       Write(Html.FormTextAreaFor(m => m.FirstQuestion, controlHtmlAttributes: new { @class = "width-all-1-1 form-textarea-medium", type = "text" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("            ");

            
            #line 24 "..\..\Views\VacancyPosting\VacancyQuestions.cshtml"
       Write(Html.DisplayFor(m => m.FirstQuestionComment, "Comment"));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("            ");

            
            #line 25 "..\..\Views\VacancyPosting\VacancyQuestions.cshtml"
       Write(Html.FormTextAreaFor(m => m.SecondQuestion, controlHtmlAttributes: new { @class = "width-all-1-1 form-textarea-medium", type = "text" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("            ");

            
            #line 26 "..\..\Views\VacancyPosting\VacancyQuestions.cshtml"
       Write(Html.DisplayFor(m => m.SecondQuestionComment, "Comment"));

            
            #line default
            #line hidden
WriteLiteral("\r\n        </div>\r\n    </section>\r\n");

WriteLiteral("    <div");

WriteLiteral(" class=\"grid grid-1-2\"");

WriteLiteral(">\r\n        <button");

WriteLiteral(" type=\"submit\"");

WriteLiteral(" class=\"button\"");

WriteLiteral(" name=\"VacancyQuestions\"");

WriteLiteral(" value=\"VacancyQuestions\"");

WriteLiteral(">");

            
            #line 30 "..\..\Views\VacancyPosting\VacancyQuestions.cshtml"
                                                                                         Write(saveButtonText);

            
            #line default
            #line hidden
WriteLiteral("</button>\r\n        <button");

WriteLiteral(" id=\"VacancyQuestionsAndExit\"");

WriteLiteral(" type=\"submit\"");

WriteLiteral(" class=\"button-link\"");

WriteLiteral(" name=\"VacancyQuestions\"");

WriteLiteral(" value=\"VacancyQuestionsAndExit\"");

WriteLiteral(">Save and exit</button>\r\n    </div>\r\n");

            
            #line 33 "..\..\Views\VacancyPosting\VacancyQuestions.cshtml"
}
            
            #line default
            #line hidden
        }
    }
}
#pragma warning restore 1591
