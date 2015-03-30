﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34014
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SFA.Apprenticeships.Web.Candidate.Views.TraineeshipApplication.DisplayTemplates
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
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/TraineeshipApplication/DisplayTemplates/EmployerQuestionAnswersViewModel." +
        "cshtml")]
    public partial class EmployerQuestionAnswersViewModel_ : System.Web.Mvc.WebViewPage<EmployerQuestionAnswersViewModel>
    {
        public EmployerQuestionAnswersViewModel_()
        {
        }
        public override void Execute()
        {
            
            #line 3 "..\..\Views\TraineeshipApplication\DisplayTemplates\EmployerQuestionAnswersViewModel.cshtml"
 if (Model != null && (!string.IsNullOrWhiteSpace(Model.SupplementaryQuestion1) || !string.IsNullOrWhiteSpace(Model.SupplementaryQuestion1)))
{

            
            #line default
            #line hidden
WriteLiteral("    <section");

WriteLiteral(" class=\"section-border\"");

WriteLiteral(">\r\n        <h2");

WriteLiteral(" class=\"heading-large\"");

WriteLiteral(">\r\n            Employer questions\r\n");

            
            #line 8 "..\..\Views\TraineeshipApplication\DisplayTemplates\EmployerQuestionAnswersViewModel.cshtml"
            
            
            #line default
            #line hidden
            
            #line 8 "..\..\Views\TraineeshipApplication\DisplayTemplates\EmployerQuestionAnswersViewModel.cshtml"
             if (ViewBag.VacancyId != null)
            {

            
            #line default
            #line hidden
WriteLiteral("                <a");

WriteLiteral(" class=\"icon-with-text\"");

WriteAttribute("href", Tuple.Create(" href=\"", 396), Tuple.Create("\"", 516)
            
            #line 10 "..\..\Views\TraineeshipApplication\DisplayTemplates\EmployerQuestionAnswersViewModel.cshtml"
, Tuple.Create(Tuple.Create("", 403), Tuple.Create<System.Object, System.Int32>(Url.RouteUrl(CandidateRouteNames.ApprenticeshipApply, new {id = ViewBag.VacancyId})
            
            #line default
            #line hidden
, 403), false)
, Tuple.Create(Tuple.Create("", 487), Tuple.Create("#applyEmployerQuestionAnswers", 487), true)
);

WriteLiteral(">\r\n                    <i");

WriteLiteral(" class=\"the-icon fa fa-pencil\"");

WriteLiteral("></i><span");

WriteLiteral(" class=\"the-text\"");

WriteLiteral(">Edit section</span>\r\n                </a>\r\n");

            
            #line 13 "..\..\Views\TraineeshipApplication\DisplayTemplates\EmployerQuestionAnswersViewModel.cshtml"
            }           

            
            #line default
            #line hidden
WriteLiteral("        </h2>\r\n\r\n");

            
            #line 16 "..\..\Views\TraineeshipApplication\DisplayTemplates\EmployerQuestionAnswersViewModel.cshtml"
        
            
            #line default
            #line hidden
            
            #line 16 "..\..\Views\TraineeshipApplication\DisplayTemplates\EmployerQuestionAnswersViewModel.cshtml"
         if (!string.IsNullOrWhiteSpace(Model.SupplementaryQuestion1))
        {

            
            #line default
            #line hidden
WriteLiteral("            <div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(">\r\n                <p");

WriteLiteral(" class=\"form-label text\"");

WriteLiteral(">");

            
            #line 19 "..\..\Views\TraineeshipApplication\DisplayTemplates\EmployerQuestionAnswersViewModel.cshtml"
                                      Write(Html.Raw(Model.SupplementaryQuestion1));

            
            #line default
            #line hidden
WriteLiteral("</p>\r\n                <span");

WriteLiteral(" class=\"form-prepopped prewrap\"");

WriteLiteral(">");

            
            #line 20 "..\..\Views\TraineeshipApplication\DisplayTemplates\EmployerQuestionAnswersViewModel.cshtml"
                                                Write(Html.Raw(Model.CandidateAnswer1));

            
            #line default
            #line hidden
WriteLiteral("</span>\r\n            </div>\r\n");

            
            #line 22 "..\..\Views\TraineeshipApplication\DisplayTemplates\EmployerQuestionAnswersViewModel.cshtml"
        }

            
            #line default
            #line hidden
WriteLiteral("        ");

            
            #line 23 "..\..\Views\TraineeshipApplication\DisplayTemplates\EmployerQuestionAnswersViewModel.cshtml"
         if (!string.IsNullOrWhiteSpace(Model.SupplementaryQuestion2))
        {

            
            #line default
            #line hidden
WriteLiteral("            <div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(">\r\n                <p");

WriteLiteral(" class=\"form-label text\"");

WriteLiteral(">");

            
            #line 26 "..\..\Views\TraineeshipApplication\DisplayTemplates\EmployerQuestionAnswersViewModel.cshtml"
                                      Write(Html.Raw(Model.SupplementaryQuestion2));

            
            #line default
            #line hidden
WriteLiteral("</p>\r\n                <span");

WriteLiteral(" class=\"form-prepopped prewrap\"");

WriteLiteral(">");

            
            #line 27 "..\..\Views\TraineeshipApplication\DisplayTemplates\EmployerQuestionAnswersViewModel.cshtml"
                                                Write(Html.Raw(Model.CandidateAnswer2));

            
            #line default
            #line hidden
WriteLiteral("</span>\r\n            </div>\r\n");

            
            #line 29 "..\..\Views\TraineeshipApplication\DisplayTemplates\EmployerQuestionAnswersViewModel.cshtml"
        }

            
            #line default
            #line hidden
WriteLiteral("    </section>\r\n");

            
            #line 31 "..\..\Views\TraineeshipApplication\DisplayTemplates\EmployerQuestionAnswersViewModel.cshtml"
}

            
            #line default
            #line hidden
        }
    }
}
#pragma warning restore 1591
