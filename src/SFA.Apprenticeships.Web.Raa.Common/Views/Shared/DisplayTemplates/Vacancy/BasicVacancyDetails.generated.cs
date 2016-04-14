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
    
    #line 2 "..\..\Views\Shared\DisplayTemplates\Vacancy\BasicVacancyDetails.cshtml"
    using SFA.Apprenticeships.Domain.Entities.Raa.Vacancies;
    
    #line default
    #line hidden
    using SFA.Apprenticeships.Web.Common.Constants;
    using SFA.Apprenticeships.Web.Common.Framework;
    using SFA.Apprenticeships.Web.Common.Models.Common;
    using SFA.Apprenticeships.Web.Raa.Common;
    
    #line 3 "..\..\Views\Shared\DisplayTemplates\Vacancy\BasicVacancyDetails.cshtml"
    using SFA.Apprenticeships.Web.Raa.Common.Extensions;
    
    #line default
    #line hidden
    
    #line 4 "..\..\Views\Shared\DisplayTemplates\Vacancy\BasicVacancyDetails.cshtml"
    using SFA.Apprenticeships.Web.Raa.Common.ViewModels.Vacancy;
    
    #line default
    #line hidden
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/Shared/DisplayTemplates/Vacancy/BasicVacancyDetails.cshtml")]
    public partial class BasicVacancyDetails : System.Web.Mvc.WebViewPage<NewVacancyViewModel>
    {
        public BasicVacancyDetails()
        {
        }
        public override void Execute()
        {
WriteLiteral("\r\n");

            
            #line 6 "..\..\Views\Shared\DisplayTemplates\Vacancy\BasicVacancyDetails.cshtml"
  
    ViewBag.Title = "Recruit an Apprentice - Select framework and level";

    const string selected = "selected";

    var isApplicationThroughRAAYes = (Model.OfflineVacancy.HasValue && !Model.OfflineVacancy.Value) ? selected : null;
    var isApplicationThroughRAANo = (Model.OfflineVacancy.HasValue && Model.OfflineVacancy.Value) ? selected : null;


            
            #line default
            #line hidden
WriteLiteral("    <h1");

WriteLiteral(" class=\"heading-xlarge\"");

WriteLiteral(">\r\n        Enter basic vacancy details\r\n    </h1>\r\n");

            
            #line 17 "..\..\Views\Shared\DisplayTemplates\Vacancy\BasicVacancyDetails.cshtml"

    
            
            #line default
            #line hidden
            
            #line 18 "..\..\Views\Shared\DisplayTemplates\Vacancy\BasicVacancyDetails.cshtml"
Write(Html.AntiForgeryToken());

            
            #line default
            #line hidden
            
            #line 18 "..\..\Views\Shared\DisplayTemplates\Vacancy\BasicVacancyDetails.cshtml"
                            
    
            
            #line default
            #line hidden
            
            #line 19 "..\..\Views\Shared\DisplayTemplates\Vacancy\BasicVacancyDetails.cshtml"
Write(Html.HiddenFor(m => m.IsEmployerLocationMainApprenticeshipLocation));

            
            #line default
            #line hidden
            
            #line 19 "..\..\Views\Shared\DisplayTemplates\Vacancy\BasicVacancyDetails.cshtml"
                                                                        
    
            
            #line default
            #line hidden
            
            #line 20 "..\..\Views\Shared\DisplayTemplates\Vacancy\BasicVacancyDetails.cshtml"
Write(Html.HiddenFor(m => m.NumberOfPositions));

            
            #line default
            #line hidden
            
            #line 20 "..\..\Views\Shared\DisplayTemplates\Vacancy\BasicVacancyDetails.cshtml"
                                             
    
            
            #line default
            #line hidden
            
            #line 21 "..\..\Views\Shared\DisplayTemplates\Vacancy\BasicVacancyDetails.cshtml"
Write(Html.HiddenFor(m => m.ComeFromPreview));

            
            #line default
            #line hidden
            
            #line 21 "..\..\Views\Shared\DisplayTemplates\Vacancy\BasicVacancyDetails.cshtml"
                                           
    
            
            #line default
            #line hidden
            
            #line 22 "..\..\Views\Shared\DisplayTemplates\Vacancy\BasicVacancyDetails.cshtml"
Write(Html.Partial("ValidationSummary", ViewData.ModelState));

            
            #line default
            #line hidden
            
            #line 22 "..\..\Views\Shared\DisplayTemplates\Vacancy\BasicVacancyDetails.cshtml"
                                                           

    
            
            #line default
            #line hidden
            
            #line 24 "..\..\Views\Shared\DisplayTemplates\Vacancy\BasicVacancyDetails.cshtml"
Write(Html.FormTextAreaFor(m => m.Title, controlHtmlAttributes: new {type = "text", size = 12, @class = "width-all-1-1 form-textarea-small"}));

            
            #line default
            #line hidden
            
            #line 24 "..\..\Views\Shared\DisplayTemplates\Vacancy\BasicVacancyDetails.cshtml"
                                                                                                                                            
    
            
            #line default
            #line hidden
            
            #line 25 "..\..\Views\Shared\DisplayTemplates\Vacancy\BasicVacancyDetails.cshtml"
Write(Html.EditorFor(m => m.TitleComment, "Comment", Html.GetLabelFor(m => m.TitleComment)));

            
            #line default
            #line hidden
            
            #line 25 "..\..\Views\Shared\DisplayTemplates\Vacancy\BasicVacancyDetails.cshtml"
                                                                                          
    
            
            #line default
            #line hidden
            
            #line 26 "..\..\Views\Shared\DisplayTemplates\Vacancy\BasicVacancyDetails.cshtml"
Write(Html.ValidationMessageFor(m => m.TitleComment));

            
            #line default
            #line hidden
            
            #line 26 "..\..\Views\Shared\DisplayTemplates\Vacancy\BasicVacancyDetails.cshtml"
                                                   

    
            
            #line default
            #line hidden
            
            #line 28 "..\..\Views\Shared\DisplayTemplates\Vacancy\BasicVacancyDetails.cshtml"
Write(Html.FormTextAreaFor(m => m.ShortDescription, controlHtmlAttributes: new {type = "text", size = 12, @class = "width-all-1-1 form-textarea-medium"}));

            
            #line default
            #line hidden
            
            #line 28 "..\..\Views\Shared\DisplayTemplates\Vacancy\BasicVacancyDetails.cshtml"
                                                                                                                                                        
    
            
            #line default
            #line hidden
            
            #line 29 "..\..\Views\Shared\DisplayTemplates\Vacancy\BasicVacancyDetails.cshtml"
Write(Html.EditorFor(m => m.ShortDescriptionComment, "Comment", Html.GetLabelFor(m => m.ShortDescriptionComment)));

            
            #line default
            #line hidden
            
            #line 29 "..\..\Views\Shared\DisplayTemplates\Vacancy\BasicVacancyDetails.cshtml"
                                                                                                                
    
            
            #line default
            #line hidden
            
            #line 30 "..\..\Views\Shared\DisplayTemplates\Vacancy\BasicVacancyDetails.cshtml"
Write(Html.ValidationMessageFor(m => m.ShortDescriptionComment));

            
            #line default
            #line hidden
            
            #line 30 "..\..\Views\Shared\DisplayTemplates\Vacancy\BasicVacancyDetails.cshtml"
                                                              


            
            #line default
            #line hidden
WriteLiteral("    <div");

WriteAttribute("class", Tuple.Create(" class=\"", 1541), Tuple.Create("\"", 1684)
, Tuple.Create(Tuple.Create("", 1549), Tuple.Create("form-group", 1549), true)
            
            #line 32 "..\..\Views\Shared\DisplayTemplates\Vacancy\BasicVacancyDetails.cshtml"
, Tuple.Create(Tuple.Create(" ", 1559), Tuple.Create<System.Object, System.Int32>(SFA.Apprenticeships.Web.Common.Framework.HtmlExtensions.GetValidationCssClass(Html.GetValidationType(m => m.VacancyType))
            
            #line default
            #line hidden
, 1560), false)
);

WriteLiteral(">\r\n        <a");

WriteAttribute("name", Tuple.Create(" name=\"", 1698), Tuple.Create("\"", 1759)
            
            #line 33 "..\..\Views\Shared\DisplayTemplates\Vacancy\BasicVacancyDetails.cshtml"
, Tuple.Create(Tuple.Create("", 1705), Tuple.Create<System.Object, System.Int32>(Html.NameFor(m => m.VacancyType).ToString().ToLower()
            
            #line default
            #line hidden
, 1705), false)
);

WriteLiteral("></a>\r\n        <label");

WriteLiteral(" class=\"form-label\"");

WriteLiteral(">Vacancy type</label>\r\n        ");

WriteLiteral("\r\n        <label");

WriteLiteral(" for=\"vacancy-type-apprenticeship\"");

WriteLiteral(" class=\"block-label\"");

WriteLiteral(">\r\n");

WriteLiteral("            ");

            
            #line 37 "..\..\Views\Shared\DisplayTemplates\Vacancy\BasicVacancyDetails.cshtml"
       Write(Html.RadioButtonFor(model => model.VacancyType, VacancyType.Apprenticeship, new { id = "vacancy-type-apprenticeship", aria_labelledby = "vacancy-type-label" }));

            
            #line default
            #line hidden
WriteLiteral(" Apprenticeship\r\n        </label>\r\n        ");

WriteLiteral("\r\n        <label");

WriteLiteral(" for=\"vacancy-type-traineeship\"");

WriteLiteral(" class=\"block-label\"");

WriteLiteral(">\r\n");

WriteLiteral("            ");

            
            #line 41 "..\..\Views\Shared\DisplayTemplates\Vacancy\BasicVacancyDetails.cshtml"
       Write(Html.RadioButtonFor(model => model.VacancyType, VacancyType.Traineeship, new { id = "vacancy-type-traineeship", aria_labelledby = "vacancy-type-label" }));

            
            #line default
            #line hidden
WriteLiteral(" Traineeship\r\n        </label>\r\n");

WriteLiteral("        ");

            
            #line 43 "..\..\Views\Shared\DisplayTemplates\Vacancy\BasicVacancyDetails.cshtml"
   Write(Html.ValidationMessageFor(m => m.VacancyType));

            
            #line default
            #line hidden
WriteLiteral("\r\n    </div>\r\n");

            
            #line 45 "..\..\Views\Shared\DisplayTemplates\Vacancy\BasicVacancyDetails.cshtml"


            
            #line default
            #line hidden
WriteLiteral("    <div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(">\r\n        <div");

WriteLiteral(" class=\"blocklabel-single-container\"");

WriteLiteral(">\r\n            <div");

WriteLiteral(" class=\"form-group inline clearfix blocklabel-single form-group-compound\"");

WriteLiteral(">\r\n                <h3");

WriteLiteral(" class=\"heading-small\"");

WriteLiteral(">Manage application method</h3>\r\n                <p>\r\n                    How wil" +
"l candidates apply for this vacancy?\r\n                </p>\r\n                ");

WriteLiteral("\r\n                <label");

WriteLiteral(" for=\"apprenticeship-online-vacancy\"");

WriteLiteral(" class=\"block-label\"");

WriteLiteral(" data-target=\"online-panel\"");

WriteLiteral(" ");

            
            #line 54 "..\..\Views\Shared\DisplayTemplates\Vacancy\BasicVacancyDetails.cshtml"
                                                                                                     Write(isApplicationThroughRAAYes);

            
            #line default
            #line hidden
WriteLiteral(">\r\n");

WriteLiteral("                    ");

            
            #line 55 "..\..\Views\Shared\DisplayTemplates\Vacancy\BasicVacancyDetails.cshtml"
               Write(Html.RadioButtonFor(model => model.OfflineVacancy, false, new {id = "apprenticeship-online-vacancy", aria_labelledby = "apprenticeship-vacancy-management-type-label"}));

            
            #line default
            #line hidden
WriteLiteral(" Candidates will apply on this website\r\n                </label>\r\n\r\n             " +
"   ");

WriteLiteral("\r\n                <label");

WriteLiteral(" for=\"apprenticeship-offline-vacancy\"");

WriteLiteral(" class=\"block-label\"");

WriteLiteral(" data-target=\"offline-panel\"");

WriteLiteral(" ");

            
            #line 59 "..\..\Views\Shared\DisplayTemplates\Vacancy\BasicVacancyDetails.cshtml"
                                                                                                       Write(isApplicationThroughRAANo);

            
            #line default
            #line hidden
WriteLiteral(">\r\n");

WriteLiteral("                    ");

            
            #line 60 "..\..\Views\Shared\DisplayTemplates\Vacancy\BasicVacancyDetails.cshtml"
               Write(Html.RadioButtonFor(model => model.OfflineVacancy, true, new {id = "apprenticeship-offline-vacancy", aria_labelledby = "apprenticeship-vacancy-management-type-label", aria_controls = "offline-panel"}));

            
            #line default
            #line hidden
WriteLiteral(" Candidates will apply through an external website\r\n                </label>\r\n");

WriteLiteral("                ");

            
            #line 62 "..\..\Views\Shared\DisplayTemplates\Vacancy\BasicVacancyDetails.cshtml"
           Write(Html.ValidationMessageFor(m => m.OfflineVacancy));

            
            #line default
            #line hidden
WriteLiteral("\r\n            </div>\r\n            <div");

WriteLiteral(" class=\"hide-js\"");

WriteLiteral(">Only answer if the vacancy applications will be managed through an extedsErnal w" +
"ebsite:</div>\r\n            <div");

WriteLiteral(" id=\"offline-panel\"");

WriteLiteral(" class=\"toggle-content panel-indent blocklabel-content\"");

WriteLiteral(">\r\n                <div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(">\r\n                    ");

WriteLiteral("\r\n");

WriteLiteral("                    ");

            
            #line 68 "..\..\Views\Shared\DisplayTemplates\Vacancy\BasicVacancyDetails.cshtml"
               Write(Html.FormTextFor(m => m.OfflineApplicationUrl, controlHtmlAttributes: new {@class = "width-all-1-1", type = "text", size = 12, id = "apprenticeship-offline-application-url"}));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("                    ");

            
            #line 69 "..\..\Views\Shared\DisplayTemplates\Vacancy\BasicVacancyDetails.cshtml"
               Write(Html.EditorFor(m => m.OfflineApplicationUrlComment, "Comment", Html.GetLabelFor(m => m.OfflineApplicationUrlComment)));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("                    ");

            
            #line 70 "..\..\Views\Shared\DisplayTemplates\Vacancy\BasicVacancyDetails.cshtml"
               Write(Html.ValidationMessageFor(m => m.OfflineApplicationUrlComment));

            
            #line default
            #line hidden
WriteLiteral("\r\n                </div>\r\n                <div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(">\r\n                    ");

WriteLiteral("\r\n");

WriteLiteral("                    ");

            
            #line 74 "..\..\Views\Shared\DisplayTemplates\Vacancy\BasicVacancyDetails.cshtml"
               Write(Html.FormTextAreaFor(m => m.OfflineApplicationInstructions, controlHtmlAttributes: new {type = "text", size = 12, @class = "width-all-1-1 form-textarea-medium", id = "apprenticheship-offline-application-instructions"}));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("                    ");

            
            #line 75 "..\..\Views\Shared\DisplayTemplates\Vacancy\BasicVacancyDetails.cshtml"
               Write(Html.EditorFor(m => m.OfflineApplicationInstructionsComment, "Comment", Html.GetLabelFor(m => m.OfflineApplicationInstructionsComment)));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("                    ");

            
            #line 76 "..\..\Views\Shared\DisplayTemplates\Vacancy\BasicVacancyDetails.cshtml"
               Write(Html.ValidationMessageFor(m => m.OfflineApplicationInstructionsComment));

            
            #line default
            #line hidden
WriteLiteral("\r\n                    <br/>\r\n                </div>\r\n            </div>\r\n        " +
"</div>\r\n    </div>\r\n");

            
            #line 82 "..\..\Views\Shared\DisplayTemplates\Vacancy\BasicVacancyDetails.cshtml"

    
            
            #line default
            #line hidden
            
            #line 83 "..\..\Views\Shared\DisplayTemplates\Vacancy\BasicVacancyDetails.cshtml"
Write(Html.HiddenFor(model => model.VacancyReferenceNumber));

            
            #line default
            #line hidden
            
            #line 83 "..\..\Views\Shared\DisplayTemplates\Vacancy\BasicVacancyDetails.cshtml"
                                                          
    
            
            #line default
            #line hidden
            
            #line 84 "..\..\Views\Shared\DisplayTemplates\Vacancy\BasicVacancyDetails.cshtml"
Write(Html.HiddenFor(model => model.Ukprn));

            
            #line default
            #line hidden
            
            #line 84 "..\..\Views\Shared\DisplayTemplates\Vacancy\BasicVacancyDetails.cshtml"
                                         
    
            
            #line default
            #line hidden
            
            #line 85 "..\..\Views\Shared\DisplayTemplates\Vacancy\BasicVacancyDetails.cshtml"
Write(Html.HiddenFor(model => model.OwnerParty.VacancyPartyId));

            
            #line default
            #line hidden
            
            #line 85 "..\..\Views\Shared\DisplayTemplates\Vacancy\BasicVacancyDetails.cshtml"
                                                             
    
            
            #line default
            #line hidden
            
            #line 86 "..\..\Views\Shared\DisplayTemplates\Vacancy\BasicVacancyDetails.cshtml"
Write(Html.HiddenFor(model => model.VacancyGuid));

            
            #line default
            #line hidden
            
            #line 86 "..\..\Views\Shared\DisplayTemplates\Vacancy\BasicVacancyDetails.cshtml"
                                               
    
            
            #line default
            #line hidden
            
            #line 87 "..\..\Views\Shared\DisplayTemplates\Vacancy\BasicVacancyDetails.cshtml"
Write(Html.HiddenFor(model => model.Status));

            
            #line default
            #line hidden
            
            #line 87 "..\..\Views\Shared\DisplayTemplates\Vacancy\BasicVacancyDetails.cshtml"
                                          

            
            #line default
            #line hidden
        }
    }
}
#pragma warning restore 1591