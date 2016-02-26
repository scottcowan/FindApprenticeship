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
    
    #line 2 "..\..\Views\VacancyPosting\CreateVacancy.cshtml"
    using System.Web.Mvc.Html;
    
    #line default
    #line hidden
    using System.Web.Optimization;
    using System.Web.Routing;
    using System.Web.Security;
    using System.Web.UI;
    using System.Web.WebPages;
    
    #line 3 "..\..\Views\VacancyPosting\CreateVacancy.cshtml"
    using SFA.Apprenticeships.Domain.Entities.Raa.Vacancies;
    
    #line default
    #line hidden
    using SFA.Apprenticeships.Infrastructure.Presentation;
    using SFA.Apprenticeships.Web.Common.Constants;
    using SFA.Apprenticeships.Web.Common.Framework;
    using SFA.Apprenticeships.Web.Common.Models.Common;
    
    #line 5 "..\..\Views\VacancyPosting\CreateVacancy.cshtml"
    using SFA.Apprenticeships.Web.Raa.Common.ViewModels.Vacancy;
    
    #line default
    #line hidden
    using SFA.Apprenticeships.Web.Raa.Common.Views.Shared.DisplayTemplates;
    using SFA.Apprenticeships.Web.Recruit;
    
    #line 4 "..\..\Views\VacancyPosting\CreateVacancy.cshtml"
    using SFA.Apprenticeships.Web.Recruit.Constants;
    
    #line default
    #line hidden
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/VacancyPosting/CreateVacancy.cshtml")]
    public partial class CreateVacancy : System.Web.Mvc.WebViewPage<NewVacancyViewModel>
    {
        public CreateVacancy()
        {
        }
        public override void Execute()
        {
WriteLiteral("\r\n");

            
            #line 7 "..\..\Views\VacancyPosting\CreateVacancy.cshtml"
 using (Html.BeginRouteForm(RecruitmentRouteNames.CreateVacancy, FormMethod.Post))
{
    
            
            #line default
            #line hidden
            
            #line 9 "..\..\Views\VacancyPosting\CreateVacancy.cshtml"
Write(Html.DisplayFor(m => m, NewVacancyViewModel.PartialView));

            
            #line default
            #line hidden
            
            #line 9 "..\..\Views\VacancyPosting\CreateVacancy.cshtml"
                                                             

    var saveButtonText = "Save and continue";
    var saveButtonValue = "CreateVacancy";

    if (Model.Status == VacancyStatus.RejectedByQA || Model.ComeFromPreview)
    {
        saveButtonText = "Save and return to Preview";
        saveButtonValue = "CreateVacancyAndPreview";
    }


            
            #line default
            #line hidden
WriteLiteral("    <div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(">\r\n        <button");

WriteLiteral(" id=\"createVacancyButton\"");

WriteLiteral(" type=\"submit\"");

WriteLiteral(" class=\"button\"");

WriteLiteral(" name=\"CreateVacancy\"");

WriteAttribute("value", Tuple.Create(" value=\"", 797), Tuple.Create("\"", 821)
            
            #line 21 "..\..\Views\VacancyPosting\CreateVacancy.cshtml"
                   , Tuple.Create(Tuple.Create("", 805), Tuple.Create<System.Object, System.Int32>(saveButtonValue
            
            #line default
            #line hidden
, 805), false)
);

WriteLiteral(">");

            
            #line 21 "..\..\Views\VacancyPosting\CreateVacancy.cshtml"
                                                                                                               Write(saveButtonText);

            
            #line default
            #line hidden
WriteLiteral("</button>\r\n        <button");

WriteLiteral(" id=\"createVacancyAndExit\"");

WriteLiteral(" type=\"submit\"");

WriteLiteral(" class=\"button-link\"");

WriteLiteral(" name=\"CreateVacancy\"");

WriteLiteral(" value=\"CreateVacancyAndExit\"");

WriteLiteral(">Save and exit</button>\r\n");

            
            #line 23 "..\..\Views\VacancyPosting\CreateVacancy.cshtml"
        
            
            #line default
            #line hidden
            
            #line 23 "..\..\Views\VacancyPosting\CreateVacancy.cshtml"
         if (Model.ComeFromPreview)
        {
            
            
            #line default
            #line hidden
            
            #line 25 "..\..\Views\VacancyPosting\CreateVacancy.cshtml"
       Write(Html.RouteLink("Cancel", RecruitmentRouteNames.PreviewVacancy, new { vacancyReferenceNumber = Model.VacancyReferenceNumber }));

            
            #line default
            #line hidden
            
            #line 25 "..\..\Views\VacancyPosting\CreateVacancy.cshtml"
                                                                                                                                          
        }

            
            #line default
            #line hidden
WriteLiteral("    </div>\r\n");

            
            #line 28 "..\..\Views\VacancyPosting\CreateVacancy.cshtml"
}

            
            #line default
            #line hidden
WriteLiteral("\r\n");

DefineSection("scripts", () => {

WriteLiteral(@"
    <script>
        $(""input[name='OfflineVacancy']"").change(function () {
            var selectedValue = $(""input[name='OfflineVacancy']:checked"").val();
            if (selectedValue === ""False"") {
                $(""#apprenticeship-offline-application-url"").val("""");
                $(""#apprenticheship-offline-application-instructions"").val("""");
            }
        });
    </script>
");

});

WriteLiteral("\r\n");

        }
    }
}
#pragma warning restore 1591
