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

namespace SFA.Apprenticeships.Web.Manage.Views.Vacancy
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
    using SFA.Apprenticeships.Web.Manage;
    
    #line 2 "..\..\Views\Vacancy\Questions.cshtml"
    using SFA.Apprenticeships.Web.Manage.Constants;
    
    #line default
    #line hidden
    
    #line 3 "..\..\Views\Vacancy\Questions.cshtml"
    using SFA.Apprenticeships.Web.Raa.Common.ViewModels.Vacancy;
    
    #line default
    #line hidden
    using SFA.Apprenticeships.Web.Raa.Common.Views.Shared.DisplayTemplates;
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/Vacancy/Questions.cshtml")]
    public partial class Questions : System.Web.Mvc.WebViewPage<VacancyQuestionsViewModel>
    {
        public Questions()
        {
        }
        public override void Execute()
        {
WriteLiteral("\r\n");

            
            #line 5 "..\..\Views\Vacancy\Questions.cshtml"
 using (Html.BeginRouteForm(ManagementRouteNames.Questions, FormMethod.Post, new { id = "vacancy-questions-form" }))
{
    
            
            #line default
            #line hidden
            
            #line 7 "..\..\Views\Vacancy\Questions.cshtml"
Write(Html.DisplayFor(m => m, VacancyQuestionsViewModel.PartialView));

            
            #line default
            #line hidden
            
            #line 7 "..\..\Views\Vacancy\Questions.cshtml"
                                                                   


            
            #line default
            #line hidden
WriteLiteral("    <div");

WriteLiteral(" class=\"form-group sfa-xlarge-top-margin inline\"");

WriteLiteral(">\r\n        <button");

WriteLiteral(" type=\"submit\"");

WriteLiteral(" class=\"button\"");

WriteLiteral(">Save</button>\r\n");

WriteLiteral("        ");

            
            #line 11 "..\..\Views\Vacancy\Questions.cshtml"
   Write(Html.RouteLink("Cancel", ManagementRouteNames.ReviewVacancy, new { vacancyReferenceNumber = Model.VacancyReferenceNumber }, new { @class = "button sfa-button-secondary" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n    </div>\r\n");

            
            #line 13 "..\..\Views\Vacancy\Questions.cshtml"
}
            
            #line default
            #line hidden
        }
    }
}
#pragma warning restore 1591
