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
    
    #line 2 "..\..\Views\VacancyPosting\VacancySummary.cshtml"
    using System.Web.Mvc.Html;
    
    #line default
    #line hidden
    using System.Web.Optimization;
    using System.Web.Routing;
    using System.Web.Security;
    using System.Web.UI;
    using System.Web.WebPages;
    
    #line 3 "..\..\Views\VacancyPosting\VacancySummary.cshtml"
    using SFA.Apprenticeships.Domain.Entities.Raa.Vacancies;
    
    #line default
    #line hidden
    using SFA.Apprenticeships.Infrastructure.Presentation;
    using SFA.Apprenticeships.Web.Common.Constants;
    using SFA.Apprenticeships.Web.Common.Framework;
    using SFA.Apprenticeships.Web.Common.Models.Common;
    
    #line 5 "..\..\Views\VacancyPosting\VacancySummary.cshtml"
    using SFA.Apprenticeships.Web.Raa.Common.ViewModels.Vacancy;
    
    #line default
    #line hidden
    using SFA.Apprenticeships.Web.Raa.Common.Views.Shared.DisplayTemplates;
    using SFA.Apprenticeships.Web.Recruit;
    
    #line 4 "..\..\Views\VacancyPosting\VacancySummary.cshtml"
    using SFA.Apprenticeships.Web.Recruit.Constants;
    
    #line default
    #line hidden
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/VacancyPosting/VacancySummary.cshtml")]
    public partial class VacancySummary : System.Web.Mvc.WebViewPage<FurtherVacancyDetailsViewModel>
    {
        public VacancySummary()
        {
        }
        public override void Execute()
        {
WriteLiteral("\r\n");

            
            #line 7 "..\..\Views\VacancyPosting\VacancySummary.cshtml"
 using (Html.BeginRouteForm(
    Model.Status.CanManageVacancyDates() ? RecruitmentRouteNames.ManageDates : RecruitmentRouteNames.VacancySummary,
    new RouteValueDictionary { { "vacancyReferenceNumber", Model.VacancyReferenceNumber } },
    FormMethod.Post))
{
    
            
            #line default
            #line hidden
            
            #line 12 "..\..\Views\VacancyPosting\VacancySummary.cshtml"
Write(Html.HiddenFor(m => m.AutoSaveTimeoutInSeconds));

            
            #line default
            #line hidden
            
            #line 12 "..\..\Views\VacancyPosting\VacancySummary.cshtml"
                                                    
    
            
            #line default
            #line hidden
            
            #line 13 "..\..\Views\VacancyPosting\VacancySummary.cshtml"
Write(Html.DisplayFor(m => m, FurtherVacancyDetailsViewModel.PartialView));

            
            #line default
            #line hidden
            
            #line 13 "..\..\Views\VacancyPosting\VacancySummary.cshtml"
                                                                        

    var saveButtonText = "Save and continue";
    var saveButtonValue = "VacancySummary";

    if (Model.Status == VacancyStatus.Referred || Model.ComeFromPreview)
    {
        saveButtonText = "Save and return to Preview";
        saveButtonValue = "VacancySummaryAndPreview";
    }


            
            #line default
            #line hidden
WriteLiteral("    <div");

WriteLiteral(" class=\"form-group inline sfa-xlarge-top-margin\"");

WriteLiteral(">\r\n");

            
            #line 25 "..\..\Views\VacancyPosting\VacancySummary.cshtml"
        
            
            #line default
            #line hidden
            
            #line 25 "..\..\Views\VacancyPosting\VacancySummary.cshtml"
         if (Model.Status.CanManageVacancyDates())
        {

            
            #line default
            #line hidden
WriteLiteral("            <button");

WriteLiteral(" class=\"button\"");

WriteLiteral(" type=\"submit\"");

WriteLiteral(">Save and return</button>\r\n");

            
            #line 28 "..\..\Views\VacancyPosting\VacancySummary.cshtml"
        }
        else
        {

            
            #line default
            #line hidden
WriteLiteral("            <button");

WriteLiteral(" id=\"vacancySummaryButton\"");

WriteLiteral(" type=\"submit\"");

WriteLiteral(" class=\"button no-autosave\"");

WriteLiteral(" name=\"VacancySummary\"");

WriteAttribute("value", Tuple.Create(" value=\"", 1273), Tuple.Create("\"", 1297)
            
            #line 31 "..\..\Views\VacancyPosting\VacancySummary.cshtml"
                                    , Tuple.Create(Tuple.Create("", 1281), Tuple.Create<System.Object, System.Int32>(saveButtonValue
            
            #line default
            #line hidden
, 1281), false)
);

WriteLiteral(">");

            
            #line 31 "..\..\Views\VacancyPosting\VacancySummary.cshtml"
                                                                                                                                 Write(saveButtonText);

            
            #line default
            #line hidden
WriteLiteral("</button>\r\n");

WriteLiteral("            <button");

WriteLiteral(" id=\"vacancySummaryAndExit\"");

WriteLiteral(" type=\"submit\"");

WriteLiteral(" class=\"button sfa-button-secondary no-autosave\"");

WriteLiteral(" name=\"VacancySummary\"");

WriteLiteral(" value=\"VacancySummaryAndExit\"");

WriteLiteral(">Save and exit</button>\r\n");

            
            #line 33 "..\..\Views\VacancyPosting\VacancySummary.cshtml"
        }

            
            #line default
            #line hidden
WriteLiteral("        ");

            
            #line 34 "..\..\Views\VacancyPosting\VacancySummary.cshtml"
         if (Model.ComeFromPreview)
        {
            
            
            #line default
            #line hidden
            
            #line 36 "..\..\Views\VacancyPosting\VacancySummary.cshtml"
       Write(Html.RouteLink("Cancel", RecruitmentRouteNames.PreviewVacancy, new {vacancyReferenceNumber = Model.VacancyReferenceNumber}, new {@class = "no-autosave button sfa-button-secondary"}));

            
            #line default
            #line hidden
            
            #line 36 "..\..\Views\VacancyPosting\VacancySummary.cshtml"
                                                                                                                                                                                                  
        }

            
            #line default
            #line hidden
WriteLiteral("    </div>\r\n");

            
            #line 39 "..\..\Views\VacancyPosting\VacancySummary.cshtml"
}

            
            #line default
            #line hidden
WriteLiteral("\r\n");

DefineSection("scripts", () => {

WriteLiteral("\r\n");

WriteLiteral("    ");

            
            #line 43 "..\..\Views\VacancyPosting\VacancySummary.cshtml"
Write(Scripts.Render("~/bundles/autosave"));

            
            #line default
            #line hidden
WriteLiteral("\r\n\r\n    <script>\r\n        var autoSaveTimeout = ");

            
            #line 46 "..\..\Views\VacancyPosting\VacancySummary.cshtml"
                         Write(Html.Raw(Json.Encode(Model.AutoSaveTimeoutInSeconds)));

            
            #line default
            #line hidden
WriteLiteral(" * 1000;\r\n\r\n        $(window).on(\'load\', function() {\r\n            autoSave.initi" +
"alise({\r\n                formSelector: \"form\",\r\n                timeout: autoSav" +
"eTimeout,\r\n                postUrl: \'");

            
            #line 52 "..\..\Views\VacancyPosting\VacancySummary.cshtml"
                     Write(Url.RouteUrl(RecruitmentRouteNames.AutoSaveVacancySummary));

            
            #line default
            #line hidden
WriteLiteral("\'\r\n            });\r\n        });\r\n    </script>\r\n\r\n");

WriteLiteral("    ");

            
            #line 57 "..\..\Views\VacancyPosting\VacancySummary.cshtml"
Write(Html.Partial("HtmlTextEditor"));

            
            #line default
            #line hidden
WriteLiteral("\r\n\r\n");

});

        }
    }
}
#pragma warning restore 1591
