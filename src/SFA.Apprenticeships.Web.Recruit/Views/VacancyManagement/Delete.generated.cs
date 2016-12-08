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

namespace SFA.Apprenticeships.Web.Recruit.Views.VacancyManagement
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
    
    #line 2 "..\..\Views\VacancyManagement\Delete.cshtml"
    using System.Web.Mvc.Html;
    
    #line default
    #line hidden
    using System.Web.Optimization;
    using System.Web.Routing;
    using System.Web.Security;
    using System.Web.UI;
    using System.Web.WebPages;
    using SFA.Apprenticeships.Infrastructure.Presentation;
    using SFA.Apprenticeships.Web.Common.Constants;
    using SFA.Apprenticeships.Web.Common.Framework;
    using SFA.Apprenticeships.Web.Common.Models.Common;
    
    #line 3 "..\..\Views\VacancyManagement\Delete.cshtml"
    using SFA.Apprenticeships.Web.Raa.Common.ViewModels.ProviderUser;
    
    #line default
    #line hidden
    using SFA.Apprenticeships.Web.Raa.Common.Views.Shared.DisplayTemplates;
    using SFA.Apprenticeships.Web.Recruit;
    
    #line 4 "..\..\Views\VacancyManagement\Delete.cshtml"
    using SFA.Apprenticeships.Web.Recruit.Constants;
    
    #line default
    #line hidden
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/VacancyManagement/Delete.cshtml")]
    public partial class Delete : System.Web.Mvc.WebViewPage<SFA.Apprenticeships.Web.Raa.Common.ViewModels.Vacancy.DeleteVacancyViewModel>
    {
        public Delete()
        {
        }
        public override void Execute()
        {
WriteLiteral("\r\n");

            
            #line 6 "..\..\Views\VacancyManagement\Delete.cshtml"
  
    ViewBag.Title = "Recruit an Apprentice - Delete a vacancy";
    var vacancyTitle = string.IsNullOrEmpty(Model.VacancyTitle) ? "(No Title)" : Model.VacancyTitle;

            
            #line default
            #line hidden
WriteLiteral("\r\n\r\n<h1");

WriteLiteral(" class=\"heading-xlarge\"");

WriteLiteral(">\r\n    Delete ");

            
            #line 12 "..\..\Views\VacancyManagement\Delete.cshtml"
      Write(vacancyTitle);

            
            #line default
            #line hidden
WriteLiteral(" vacancy\r\n</h1>\r\n\r\n");

            
            #line 15 "..\..\Views\VacancyManagement\Delete.cshtml"
 using (Html.BeginRouteForm(RecruitmentRouteNames.DeleteVacancy, FormMethod.Post, new { id = "delete-vacancy-form" }))
{

            
            #line default
            #line hidden
WriteLiteral("    <div>\r\n        <p>You will not be able to retreive this vacancy once it has b" +
"een deleted</p>\r\n        <div");

WriteLiteral(" class=\"grid grid-1-1\"");

WriteLiteral(">\r\n");

            
            #line 20 "..\..\Views\VacancyManagement\Delete.cshtml"
            
            
            #line default
            #line hidden
            
            #line 20 "..\..\Views\VacancyManagement\Delete.cshtml"
             foreach (var prop in Model.GetType().GetProperties())
            {
                var getter = prop.GetGetMethod();
                
            
            #line default
            #line hidden
            
            #line 23 "..\..\Views\VacancyManagement\Delete.cshtml"
           Write(Html.Hidden(prop.Name, getter.Invoke(Model, new object[] { })));

            
            #line default
            #line hidden
            
            #line 23 "..\..\Views\VacancyManagement\Delete.cshtml"
                                                                               
                ;
            }

            
            #line default
            #line hidden
WriteLiteral("            <button");

WriteLiteral(" class=\"button\"");

WriteLiteral(" id=\"confirmDeleteVacancy\"");

WriteLiteral(" name=\"ConfirmDeleteVacancy\"");

WriteLiteral(" value=\"ConfirmDeleteVacancy\"");

WriteLiteral(">Confirm and return to recruitment home</button>\r\n");

WriteLiteral("            ");

            
            #line 27 "..\..\Views\VacancyManagement\Delete.cshtml"
       Write(Html.RouteLink("Cancel", RecruitmentRouteNames.RecruitmentHome, Model as VacanciesSummarySearchViewModel));

            
            #line default
            #line hidden
WriteLiteral("\r\n        </div>\r\n    </div>\r\n");

            
            #line 30 "..\..\Views\VacancyManagement\Delete.cshtml"
}
            
            #line default
            #line hidden
        }
    }
}
#pragma warning restore 1591
