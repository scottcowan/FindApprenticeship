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
Write(Html.HiddenFor(m => m.AutoSaveTimeoutInSeconds));

            
            #line default
            #line hidden
            
            #line 9 "..\..\Views\VacancyPosting\CreateVacancy.cshtml"
                                                    
    
            
            #line default
            #line hidden
            
            #line 10 "..\..\Views\VacancyPosting\CreateVacancy.cshtml"
Write(Html.DisplayFor(m => m, NewVacancyViewModel.PartialView));

            
            #line default
            #line hidden
            
            #line 10 "..\..\Views\VacancyPosting\CreateVacancy.cshtml"
                                                             

    var saveButtonText = "Save and continue";
    var saveButtonValue = "CreateVacancy";

    if (Model.Status == VacancyStatus.Referred || Model.ComeFromPreview)
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

WriteLiteral(" class=\"button no-autosave\"");

WriteLiteral(" name=\"CreateVacancy\"");

WriteAttribute("value", Tuple.Create(" value=\"", 859), Tuple.Create("\"", 883)
            
            #line 22 "..\..\Views\VacancyPosting\CreateVacancy.cshtml"
                               , Tuple.Create(Tuple.Create("", 867), Tuple.Create<System.Object, System.Int32>(saveButtonValue
            
            #line default
            #line hidden
, 867), false)
);

WriteLiteral(">");

            
            #line 22 "..\..\Views\VacancyPosting\CreateVacancy.cshtml"
                                                                                                                           Write(saveButtonText);

            
            #line default
            #line hidden
WriteLiteral("</button>\r\n        <button");

WriteLiteral(" id=\"createVacancyAndExit\"");

WriteLiteral(" type=\"submit\"");

WriteLiteral(" class=\"button-link no-autosave\"");

WriteLiteral(" name=\"CreateVacancy\"");

WriteLiteral(" value=\"CreateVacancyAndExit\"");

WriteLiteral(">Save and exit</button>\r\n");

            
            #line 24 "..\..\Views\VacancyPosting\CreateVacancy.cshtml"
        
            
            #line default
            #line hidden
            
            #line 24 "..\..\Views\VacancyPosting\CreateVacancy.cshtml"
         if (Model.ComeFromPreview)
        {
            
            
            #line default
            #line hidden
            
            #line 26 "..\..\Views\VacancyPosting\CreateVacancy.cshtml"
       Write(Html.RouteLink("Cancel", RecruitmentRouteNames.PreviewVacancy, new { vacancyReferenceNumber = Model.VacancyReferenceNumber }, new {@class = "no-autosave" }));

            
            #line default
            #line hidden
            
            #line 26 "..\..\Views\VacancyPosting\CreateVacancy.cshtml"
                                                                                                                                                                         
        }

            
            #line default
            #line hidden
WriteLiteral("    </div>\r\n");

            
            #line 29 "..\..\Views\VacancyPosting\CreateVacancy.cshtml"
}

            
            #line default
            #line hidden
WriteLiteral("\r\n");

DefineSection("scripts", () => {

WriteLiteral("\r\n");

WriteLiteral("    ");

            
            #line 33 "..\..\Views\VacancyPosting\CreateVacancy.cshtml"
Write(Scripts.Render("~/bundles/autosave"));

            
            #line default
            #line hidden
WriteLiteral(@"

    <script>
        $(""input[name='OfflineVacancy']"").change(function() {
            var selectedValue = $(""input[name='OfflineVacancy']:checked"").val();
            if (selectedValue === ""False"") {
                $(""#apprenticeship-offline-application-url"").val("""");
                $(""#apprenticheship-offline-application-instructions"").val("""");
            }
        });

        var autoSaveTimeout = ");

            
            #line 44 "..\..\Views\VacancyPosting\CreateVacancy.cshtml"
                         Write(Html.Raw(Json.Encode(Model.AutoSaveTimeoutInSeconds)));

            
            #line default
            #line hidden
WriteLiteral(" * 1000;\r\n\r\n        $(window).on(\'load\', function() {\r\n            autoSave.initi" +
"alise({\r\n                formSelector: \"form\",\r\n                timeout: autoSav" +
"eTimeout,\r\n                postUrl: \'");

            
            #line 50 "..\..\Views\VacancyPosting\CreateVacancy.cshtml"
                     Write(Url.RouteUrl(RecruitmentRouteNames.AutoSaveCreateVacancy));

            
            #line default
            #line hidden
WriteLiteral("\'\r\n            });\r\n        });\r\n    </script>\r\n");

});

WriteLiteral("\r\n");

        }
    }
}
#pragma warning restore 1591
