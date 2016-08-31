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
 using (Html.BeginRouteForm(RecruitmentRouteNames.VacancySummary, FormMethod.Post))
{
    
            
            #line default
            #line hidden
            
            #line 9 "..\..\Views\VacancyPosting\VacancySummary.cshtml"
Write(Html.HiddenFor(m => m.AutoSaveTimeoutInSeconds));

            
            #line default
            #line hidden
            
            #line 9 "..\..\Views\VacancyPosting\VacancySummary.cshtml"
                                                    
    
            
            #line default
            #line hidden
            
            #line 10 "..\..\Views\VacancyPosting\VacancySummary.cshtml"
Write(Html.DisplayFor(m => m, FurtherVacancyDetailsViewModel.PartialView));

            
            #line default
            #line hidden
            
            #line 10 "..\..\Views\VacancyPosting\VacancySummary.cshtml"
                                                                        

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

WriteLiteral(" class=\"grid grid-1-2\"");

WriteLiteral(">\r\n        <button");

WriteLiteral(" id=\"vacancySummaryButton\"");

WriteLiteral(" type=\"submit\"");

WriteLiteral(" class=\"button no-autosave\"");

WriteLiteral(" name=\"VacancySummary\"");

WriteAttribute("value", Tuple.Create(" value=\"", 889), Tuple.Create("\"", 913)
            
            #line 22 "..\..\Views\VacancyPosting\VacancySummary.cshtml"
                                 , Tuple.Create(Tuple.Create("", 897), Tuple.Create<System.Object, System.Int32>(saveButtonValue
            
            #line default
            #line hidden
, 897), false)
);

WriteLiteral(">");

            
            #line 22 "..\..\Views\VacancyPosting\VacancySummary.cshtml"
                                                                                                                             Write(saveButtonText);

            
            #line default
            #line hidden
WriteLiteral("</button>\r\n        <button");

WriteLiteral(" id=\"vacancySummaryAndExit\"");

WriteLiteral(" type=\"submit\"");

WriteLiteral(" class=\"button-link no-autosave\"");

WriteLiteral(" name=\"VacancySummary\"");

WriteLiteral(" value=\"VacancySummaryAndExit\"");

WriteLiteral(">Save and exit</button>\r\n");

            
            #line 24 "..\..\Views\VacancyPosting\VacancySummary.cshtml"
        
            
            #line default
            #line hidden
            
            #line 24 "..\..\Views\VacancyPosting\VacancySummary.cshtml"
         if (Model.ComeFromPreview)
        {
            
            
            #line default
            #line hidden
            
            #line 26 "..\..\Views\VacancyPosting\VacancySummary.cshtml"
       Write(Html.RouteLink("Cancel", RecruitmentRouteNames.PreviewVacancy, new { vacancyReferenceNumber = Model.VacancyReferenceNumber }, new {@class = "no-autosave" }));

            
            #line default
            #line hidden
            
            #line 26 "..\..\Views\VacancyPosting\VacancySummary.cshtml"
                                                                                                                                                                         
        }

            
            #line default
            #line hidden
WriteLiteral("    </div>\r\n");

            
            #line 29 "..\..\Views\VacancyPosting\VacancySummary.cshtml"
}

            
            #line default
            #line hidden
WriteLiteral("\r\n");

DefineSection("scripts", () => {

WriteLiteral("\r\n");

WriteLiteral("    ");

            
            #line 33 "..\..\Views\VacancyPosting\VacancySummary.cshtml"
Write(Scripts.Render("~/bundles/autosave"));

            
            #line default
            #line hidden
WriteLiteral("\r\n\r\n    <script>\r\n        var autoSaveTimeout = ");

            
            #line 36 "..\..\Views\VacancyPosting\VacancySummary.cshtml"
                         Write(Html.Raw(Json.Encode(Model.AutoSaveTimeoutInSeconds)));

            
            #line default
            #line hidden
WriteLiteral(" * 1000;\r\n\r\n        $(window).on(\'load\', function() {\r\n            autoSave.initi" +
"alise({\r\n                formSelector: \"form\",\r\n                timeout: autoSav" +
"eTimeout,\r\n                postUrl: \'");

            
            #line 42 "..\..\Views\VacancyPosting\VacancySummary.cshtml"
                     Write(Url.RouteUrl(RecruitmentRouteNames.AutoSaveVacancySummary));

            
            #line default
            #line hidden
WriteLiteral("\'\r\n            });\r\n        });\r\n    </script>\r\n\r\n    <!---->\r\n    <script");

WriteLiteral(" src=\"https://cdn.ckeditor.com/4.5.10/standard/ckeditor.js\"");

WriteLiteral("></script>\r\n    <script");

WriteLiteral(" src=\"https://cdn.ckeditor.com/4.5.10/standard/adapters/jquery.js\"");

WriteLiteral(@"></script>
    <script>
            if (typeof CKEDITOR == 'undefined') {
                document.write(unescape(""%3Cscript src='/Content/_assets/js/vendor/ckeditor/ckeditor.js' type='text/javascript'%3E%3C/script%3E""));
                document.write(unescape(""%3Cscript src='/Content/_assets/js/vendor/ckeditor/adapters/jquery.js' type='text/javascript'%3E%3C/script%3E""));
            }
    </script>

    <script");

WriteAttribute("src", Tuple.Create(" src=\"", 2421), Tuple.Create("\"", 2476)
, Tuple.Create(Tuple.Create("", 2427), Tuple.Create<System.Object, System.Int32>(Href("~/Content/_assets/js/vendor/nanospell/autoload.js")
, 2427), false)
);

WriteLiteral(@"></script>
    <script>
            CKEDITOR.replace('LongDescription', {
                customConfig: '/Content/_assets/js/vendor/ckeditor/config.js',
                contentsCss: '/Content/_assets/js/vendor/ckeditor/contents.css'
            });
    </script>

    <script>
            nanospell.ckeditor('all',
            {
                dictionary: ""en_uk"", // 24 free international dictionaries
                server: ""asp.net"" // can be php, asp, asp.net or java
            });
    </script>

");

});

        }
    }
}
#pragma warning restore 1591
