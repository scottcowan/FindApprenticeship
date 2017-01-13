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
    
    #line 2 "..\..\Views\Vacancy\EmployerInformation.cshtml"
    using SFA.Apprenticeships.Domain.Entities.Raa.Vacancies;
    
    #line default
    #line hidden
    using SFA.Apprenticeships.Infrastructure.Presentation;
    using SFA.Apprenticeships.Web.Common.Constants;
    using SFA.Apprenticeships.Web.Common.Framework;
    using SFA.Apprenticeships.Web.Common.Models.Common;
    using SFA.Apprenticeships.Web.Manage;
    
    #line 3 "..\..\Views\Vacancy\EmployerInformation.cshtml"
    using SFA.Apprenticeships.Web.Manage.Constants;
    
    #line default
    #line hidden
    
    #line 4 "..\..\Views\Vacancy\EmployerInformation.cshtml"
    using SFA.Apprenticeships.Web.Raa.Common.ViewModels.Provider;
    
    #line default
    #line hidden
    using SFA.Apprenticeships.Web.Raa.Common.Views.Shared.DisplayTemplates;
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/Vacancy/EmployerInformation.cshtml")]
    public partial class EmployerInformation : System.Web.Mvc.WebViewPage<VacancyOwnerRelationshipViewModel>
    {
        public EmployerInformation()
        {
        }
        public override void Execute()
        {
WriteLiteral("\r\n");

            
            #line 6 "..\..\Views\Vacancy\EmployerInformation.cshtml"
  
    ViewBag.Title = "Recruit an Apprentice - Check employer information";

    var saveButtonText = Model.VacancyLocationType == VacancyLocationType.SpecificLocation ? "Save" : "Save and continue";

            
            #line default
            #line hidden
WriteLiteral("\r\n\r\n<div");

WriteLiteral(" class=\"grid-row\"");

WriteLiteral(">\r\n    <div");

WriteLiteral(" class=\"column-two-thirds\"");

WriteLiteral(">\r\n        <h1");

WriteLiteral(" class=\"heading-xlarge\"");

WriteLiteral(">\r\n            Check employer information\r\n        </h1>\r\n    </div>\r\n</div>\r\n\r\n");

            
            #line 20 "..\..\Views\Vacancy\EmployerInformation.cshtml"
 using (Html.BeginRouteForm(ManagementRouteNames.EmployerInformation, FormMethod.Post, new { id = "employer-information-form" }))
{   
    
            
            #line default
            #line hidden
            
            #line 22 "..\..\Views\Vacancy\EmployerInformation.cshtml"
Write(Html.DisplayFor(m => m, VacancyOwnerRelationshipViewModel.PartialView));

            
            #line default
            #line hidden
            
            #line 22 "..\..\Views\Vacancy\EmployerInformation.cshtml"
                                                                           


            
            #line default
            #line hidden
WriteLiteral("    <div");

WriteLiteral(" clss=\"grid-row\"");

WriteLiteral(">\r\n        <div");

WriteLiteral(" class=\"column-full inline\"");

WriteLiteral(">\r\n            <button");

WriteLiteral(" class=\"button\"");

WriteLiteral(" id=\"confirmEmployer\"");

WriteLiteral(" name=\"ConfirmEmployer\"");

WriteLiteral(" value=\"ConfirmEmployer\"");

WriteLiteral(">");

            
            #line 26 "..\..\Views\Vacancy\EmployerInformation.cshtml"
                                                                                                  Write(saveButtonText);

            
            #line default
            #line hidden
WriteLiteral("</button>\r\n");

WriteLiteral("            ");

            
            #line 27 "..\..\Views\Vacancy\EmployerInformation.cshtml"
       Write(Html.RouteLink("Cancel", ManagementRouteNames.ReviewVacancy, new { vacancyReferenceNumber = Model.VacancyReferenceNumber }, new { @class = "button sfa-button-secondary" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n        </div>\r\n    </div>\r\n");

            
            #line 30 "..\..\Views\Vacancy\EmployerInformation.cshtml"
}

            
            #line default
            #line hidden
WriteLiteral("\r\n");

DefineSection("scripts", () => {

WriteLiteral("\r\n    <script");

WriteLiteral(" type=\"text/javascript\"");

WriteLiteral(@">

        $(""#NumberOfPositionsJS"").attr(""id"", ""NumberOfPositions"").attr(""Name"", ""NumberOfPositions"");
        $(""#NumberOfPositionsNWJS"").attr(""id"", ""NumberOfPositionsNationwide"").attr(""Name"", ""NumberOfPositionsNationwide"");

        $(""#NonAnonymousEmployerJS"").attr(""id"", ""NonAnonymousEmployer"").attr(""Name"", ""NonAnonymousEmployer"");
        $(""#AnonymousEmployerJS"").attr(""id"", ""AnonymousEmployer"").attr(""Name"", ""AnonymousEmployer"");
        

        $(""#location-type-main-location"").on('click', function () {
                $(""#confirmEmployer"").text(""Save"");
        });

        $(""#location-type-different-location"").on('click', function () {
            $(""#confirmEmployer"").text(""Save and continue"");
        });
    </script>

    ");

WriteLiteral("\r\n");

});

        }
    }
}
#pragma warning restore 1591
