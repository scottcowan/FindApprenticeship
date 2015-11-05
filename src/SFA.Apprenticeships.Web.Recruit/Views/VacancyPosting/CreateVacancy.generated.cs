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
    
    #line 2 "..\..\Views\VacancyPosting\CreateVacancy.cshtml"
    using SFA.Apprenticeships.Domain.Entities.Vacancies.Apprenticeships;
    
    #line default
    #line hidden
    
    #line 3 "..\..\Views\VacancyPosting\CreateVacancy.cshtml"
    using SFA.Apprenticeships.Domain.Entities.Vacancies.ProviderVacancies;
    
    #line default
    #line hidden
    using SFA.Apprenticeships.Web.Common.Constants;
    using SFA.Apprenticeships.Web.Common.Framework;
    using SFA.Apprenticeships.Web.Common.Models.Common;
    using SFA.Apprenticeships.Web.Recruit;
    
    #line 4 "..\..\Views\VacancyPosting\CreateVacancy.cshtml"
    using SFA.Apprenticeships.Web.Recruit.Constants;
    
    #line default
    #line hidden
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/VacancyPosting/CreateVacancy.cshtml")]
    public partial class CreateVacancy : System.Web.Mvc.WebViewPage<SFA.Apprenticeships.Web.Recruit.ViewModels.Vacancy.NewVacancyViewModel>
    {
        public CreateVacancy()
        {
        }
        public override void Execute()
        {
            
            #line 5 "..\..\Views\VacancyPosting\CreateVacancy.cshtml"
  
    ViewBag.Title = "Recruit an Apprentice - Select framework and level";

    const string selected = "selected";

    var isApplicationThroughRAAYes = !Model.OfflineVacancy ? selected : null;
    var isApplicationThroughRAANo = Model.OfflineVacancy ? selected : null;

    var frameworksSelected = Model.TrainingType == TrainingType.Frameworks ? selected : null;
    var standardsSelected = Model.TrainingType == TrainingType.Standards ? selected : null;

            
            #line default
            #line hidden
WriteLiteral("\r\n\r\n<h1");

WriteLiteral(" class=\"heading-xlarge\"");

WriteLiteral(">\r\n    Enter basic vacancy details\r\n</h1>\r\n\r\n");

            
            #line 21 "..\..\Views\VacancyPosting\CreateVacancy.cshtml"
 using (Html.BeginRouteForm(RecruitmentRouteNames.CreateVacancy, FormMethod.Post))
{
    
            
            #line default
            #line hidden
            
            #line 23 "..\..\Views\VacancyPosting\CreateVacancy.cshtml"
Write(Html.AntiForgeryToken());

            
            #line default
            #line hidden
            
            #line 23 "..\..\Views\VacancyPosting\CreateVacancy.cshtml"
                            
    
            
            #line default
            #line hidden
            
            #line 24 "..\..\Views\VacancyPosting\CreateVacancy.cshtml"
Write(Html.Partial("ValidationSummary", ViewData.ModelState));

            
            #line default
            #line hidden
            
            #line 24 "..\..\Views\VacancyPosting\CreateVacancy.cshtml"
                                                           

    
            
            #line default
            #line hidden
            
            #line 26 "..\..\Views\VacancyPosting\CreateVacancy.cshtml"
Write(Html.FormTextAreaFor(m => m.Title, controlHtmlAttributes: new { type = "text", size = 12, @class = "width-all-1-1 form-textarea-small" }));

            
            #line default
            #line hidden
            
            #line 26 "..\..\Views\VacancyPosting\CreateVacancy.cshtml"
                                                                                                                                              
    
            
            #line default
            #line hidden
            
            #line 27 "..\..\Views\VacancyPosting\CreateVacancy.cshtml"
Write(Html.FormTextAreaFor(m => m.ShortDescription, controlHtmlAttributes: new { type = "text", size = 12, @class = "width-all-1-1 form-textarea-medium" }));

            
            #line default
            #line hidden
            
            #line 27 "..\..\Views\VacancyPosting\CreateVacancy.cshtml"
                                                                                                                                                          


            
            #line default
            #line hidden
WriteLiteral("    <div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(">\r\n        <div");

WriteLiteral(" class=\"blocklabel-single-container\"");

WriteLiteral(">\r\n            <div");

WriteLiteral(" class=\"form-group inline clearfix blocklabel-single hide-nojs\"");

WriteLiteral(">\r\n                <a");

WriteAttribute("name", Tuple.Create(" name=\"", 1480), Tuple.Create("\"", 1542)
            
            #line 32 "..\..\Views\VacancyPosting\CreateVacancy.cshtml"
, Tuple.Create(Tuple.Create("", 1487), Tuple.Create<System.Object, System.Int32>(Html.NameFor(m => m.TrainingType).ToString().ToLower()
            
            #line default
            #line hidden
, 1487), false)
);

WriteLiteral("></a>\r\n                <p>Training type</p>\r\n                ");

WriteLiteral("\r\n                <label");

WriteLiteral(" data-target=\"training-type-frameworks-panel\"");

WriteLiteral(" for=\"training-type-frameworks\"");

WriteAttribute("class", Tuple.Create(" class=\"", 1751), Tuple.Create("\"", 1790)
, Tuple.Create(Tuple.Create("", 1759), Tuple.Create("block-label", 1759), true)
            
            #line 35 "..\..\Views\VacancyPosting\CreateVacancy.cshtml"
                                     , Tuple.Create(Tuple.Create(" ", 1770), Tuple.Create<System.Object, System.Int32>(frameworksSelected
            
            #line default
            #line hidden
, 1771), false)
);

WriteLiteral(">\r\n");

WriteLiteral("                    ");

            
            #line 36 "..\..\Views\VacancyPosting\CreateVacancy.cshtml"
               Write(Html.RadioButtonFor(model => model.TrainingType, TrainingType.Frameworks, new {id = "training-type-frameworks", aria_controls = "training-type-frameworks-panel"}));

            
            #line default
            #line hidden
WriteLiteral("\r\n                    Frameworks\r\n                </label>\r\n                ");

WriteLiteral("\r\n                <label");

WriteLiteral(" data-target=\"training-type-standards-panel\"");

WriteLiteral(" for=\"training-type-standards\"");

WriteAttribute("class", Tuple.Create(" class=\"", 2198), Tuple.Create("\"", 2236)
, Tuple.Create(Tuple.Create("", 2206), Tuple.Create("block-label", 2206), true)
            
            #line 40 "..\..\Views\VacancyPosting\CreateVacancy.cshtml"
                                   , Tuple.Create(Tuple.Create(" ", 2217), Tuple.Create<System.Object, System.Int32>(standardsSelected
            
            #line default
            #line hidden
, 2218), false)
);

WriteLiteral(">\r\n");

WriteLiteral("                    ");

            
            #line 41 "..\..\Views\VacancyPosting\CreateVacancy.cshtml"
               Write(Html.RadioButtonFor(model => model.TrainingType, TrainingType.Standards, new {id = "training-type-standards", aria_controls = "training-type-standards-panel"}));

            
            #line default
            #line hidden
WriteLiteral("\r\n                    Standards\r\n                </label>\r\n            </div>\r\n\r\n" +
"            <div");

WriteLiteral(" id=\"training-type-frameworks-panel\"");

WriteLiteral(" class=\"toggle-content blocklabel-content\"");

WriteLiteral(">\r\n                <div");

WriteAttribute("class", Tuple.Create(" class=\"", 2618), Tuple.Create("\"", 2726)
, Tuple.Create(Tuple.Create("", 2626), Tuple.Create("form-group", 2626), true)
            
            #line 47 "..\..\Views\VacancyPosting\CreateVacancy.cshtml"
, Tuple.Create(Tuple.Create(" ", 2636), Tuple.Create<System.Object, System.Int32>(HtmlExtensions.GetValidationCssClass(Html.GetValidationType(m => m.FrameworkCodeName))
            
            #line default
            #line hidden
, 2637), false)
);

WriteLiteral(">\r\n                    <a");

WriteAttribute("name", Tuple.Create(" name=\"", 2752), Tuple.Create("\"", 2819)
            
            #line 48 "..\..\Views\VacancyPosting\CreateVacancy.cshtml"
, Tuple.Create(Tuple.Create("", 2759), Tuple.Create<System.Object, System.Int32>(Html.NameFor(m => m.FrameworkCodeName).ToString().ToLower()
            
            #line default
            #line hidden
, 2759), false)
);

WriteLiteral("></a>\r\n                    <label");

WriteAttribute("for", Tuple.Create(" for=\"", 2853), Tuple.Create("\"", 2898)
            
            #line 49 "..\..\Views\VacancyPosting\CreateVacancy.cshtml"
, Tuple.Create(Tuple.Create("", 2859), Tuple.Create<System.Object, System.Int32>(Html.NameFor(m => m.FrameworkCodeName)
            
            #line default
            #line hidden
, 2859), false)
);

WriteLiteral(" class=\"form-label\"");

WriteLiteral(">Apprenticeship framework</label>\r\n");

WriteLiteral("                    ");

            
            #line 50 "..\..\Views\VacancyPosting\CreateVacancy.cshtml"
               Write(Html.DropDownListFor(m => m.FrameworkCodeName, Model.SectorsAndFrameworks, new {@class = "para-btm-margin chosen-select", style = "min-width: 50%;"}));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("                    ");

            
            #line 51 "..\..\Views\VacancyPosting\CreateVacancy.cshtml"
               Write(Html.ValidationMessageFor(m => m.FrameworkCodeName));

            
            #line default
            #line hidden
WriteLiteral("\r\n                </div>\r\n\r\n                <div");

WriteAttribute("class", Tuple.Create(" class=\"", 3245), Tuple.Create("\"", 3355)
, Tuple.Create(Tuple.Create("", 3253), Tuple.Create("form-group", 3253), true)
            
            #line 54 "..\..\Views\VacancyPosting\CreateVacancy.cshtml"
, Tuple.Create(Tuple.Create(" ", 3263), Tuple.Create<System.Object, System.Int32>(HtmlExtensions.GetValidationCssClass(Html.GetValidationType(m => m.ApprenticeshipLevel))
            
            #line default
            #line hidden
, 3264), false)
);

WriteLiteral(">\r\n                    <a");

WriteAttribute("name", Tuple.Create(" name=\"", 3381), Tuple.Create("\"", 3450)
            
            #line 55 "..\..\Views\VacancyPosting\CreateVacancy.cshtml"
, Tuple.Create(Tuple.Create("", 3388), Tuple.Create<System.Object, System.Int32>(Html.NameFor(m => m.ApprenticeshipLevel).ToString().ToLower()
            
            #line default
            #line hidden
, 3388), false)
);

WriteLiteral("></a>\r\n                    <label");

WriteLiteral(" class=\"form-label\"");

WriteLiteral(">Apprenticeship level</label>\r\n                    <div");

WriteLiteral(" class=\"small-btm-margin clearfix\"");

WriteLiteral(">\r\n                        ");

WriteLiteral("\r\n                        <label");

WriteLiteral(" for=\"apprenticeship-level-intermediate\"");

WriteLiteral(" class=\"block-label\"");

WriteLiteral(">\r\n");

WriteLiteral("                            ");

            
            #line 60 "..\..\Views\VacancyPosting\CreateVacancy.cshtml"
                       Write(Html.RadioButtonFor(model => model.ApprenticeshipLevel, ApprenticeshipLevel.Intermediate, new {id = "apprenticeship-level-intermediate", aria_labelledby = "apprenticeship-level-label"}));

            
            #line default
            #line hidden
WriteLiteral(" Intermediate\r\n                        </label>\r\n                    </div>\r\n\r\n  " +
"                  <div");

WriteLiteral(" class=\"small-btm-margin clearfix\"");

WriteLiteral(">\r\n                        ");

WriteLiteral("\r\n                        <label");

WriteLiteral(" for=\"apprenticeship-level-advanced\"");

WriteLiteral(" class=\"block-label\"");

WriteLiteral(">\r\n");

WriteLiteral("                            ");

            
            #line 67 "..\..\Views\VacancyPosting\CreateVacancy.cshtml"
                       Write(Html.RadioButtonFor(model => model.ApprenticeshipLevel, ApprenticeshipLevel.Advanced, new {id = "apprenticeship-level-advanced", aria_labelledby = "apprenticeship-level-label"}));

            
            #line default
            #line hidden
WriteLiteral(" Advanced\r\n                        </label>\r\n                    </div>\r\n\r\n      " +
"              <div");

WriteLiteral(" class=\"small-btm-margin clearfix\"");

WriteLiteral(">\r\n                        ");

WriteLiteral("\r\n                        <label");

WriteLiteral(" for=\"apprenticeship-level-higher\"");

WriteLiteral(" class=\"block-label\"");

WriteLiteral(">\r\n");

WriteLiteral("                            ");

            
            #line 74 "..\..\Views\VacancyPosting\CreateVacancy.cshtml"
                       Write(Html.RadioButtonFor(model => model.ApprenticeshipLevel, ApprenticeshipLevel.Higher, new {id = "apprenticeship-level-higher", aria_labelledby = "apprenticeship-level-label"}));

            
            #line default
            #line hidden
WriteLiteral(" Higher\r\n                        </label>\r\n                    </div>\r\n");

WriteLiteral("                    ");

            
            #line 77 "..\..\Views\VacancyPosting\CreateVacancy.cshtml"
               Write(Html.ValidationMessageFor(m => m.ApprenticeshipLevel));

            
            #line default
            #line hidden
WriteLiteral("\r\n                </div>\r\n            </div>\r\n\r\n            <div");

WriteLiteral(" id=\"training-type-standards-panel\"");

WriteLiteral(" class=\"toggle-content blocklabel-content\"");

WriteLiteral(">\r\n                <div");

WriteAttribute("class", Tuple.Create(" class=\"", 5290), Tuple.Create("\"", 5391)
, Tuple.Create(Tuple.Create("", 5298), Tuple.Create("form-group", 5298), true)
            
            #line 82 "..\..\Views\VacancyPosting\CreateVacancy.cshtml"
, Tuple.Create(Tuple.Create(" ", 5308), Tuple.Create<System.Object, System.Int32>(HtmlExtensions.GetValidationCssClass(Html.GetValidationType(m => m.StandardId))
            
            #line default
            #line hidden
, 5309), false)
);

WriteLiteral(">\r\n                    <a");

WriteAttribute("name", Tuple.Create(" name=\"", 5417), Tuple.Create("\"", 5477)
            
            #line 83 "..\..\Views\VacancyPosting\CreateVacancy.cshtml"
, Tuple.Create(Tuple.Create("", 5424), Tuple.Create<System.Object, System.Int32>(Html.NameFor(m => m.StandardId).ToString().ToLower()
            
            #line default
            #line hidden
, 5424), false)
);

WriteLiteral("></a>\r\n                    <label");

WriteAttribute("for", Tuple.Create(" for=\"", 5511), Tuple.Create("\"", 5549)
            
            #line 84 "..\..\Views\VacancyPosting\CreateVacancy.cshtml"
, Tuple.Create(Tuple.Create("", 5517), Tuple.Create<System.Object, System.Int32>(Html.NameFor(m => m.StandardId)
            
            #line default
            #line hidden
, 5517), false)
);

WriteLiteral(" class=\"form-label\"");

WriteLiteral(">Apprenticeship standard</label>\r\n");

WriteLiteral("                    ");

            
            #line 85 "..\..\Views\VacancyPosting\CreateVacancy.cshtml"
               Write(Html.DropDownListFor(m => m.StandardId, Model.Standards, new {@class = "para-btm-margin chosen-select", style = "min-width: 50%;"}));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("                    ");

            
            #line 86 "..\..\Views\VacancyPosting\CreateVacancy.cshtml"
               Write(Html.ValidationMessageFor(m => m.StandardId));

            
            #line default
            #line hidden
WriteLiteral("\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n");

            
            #line 91 "..\..\Views\VacancyPosting\CreateVacancy.cshtml"


            
            #line default
            #line hidden
WriteLiteral("    <div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(">\r\n        <div");

WriteLiteral(" class=\"blocklabel-single-container\"");

WriteLiteral(">\r\n            <div");

WriteLiteral(" class=\"form-group inline clearfix blocklabel-single hide-nojs\"");

WriteLiteral(">\r\n                <h3");

WriteLiteral(" class=\"heading-small\"");

WriteLiteral(">Manage application method</h3>\r\n                <p>\r\n                    Will th" +
"is vacancy be managed through the find an apprentice\r\n                    site?\r" +
"\n                </p>\r\n                ");

WriteLiteral("\r\n                <label");

WriteLiteral(" for=\"apprenticeship-online-vacancy\"");

WriteLiteral(" class=\"block-label\"");

WriteLiteral(" data-target=\"online-panel\"");

WriteLiteral(" ");

            
            #line 101 "..\..\Views\VacancyPosting\CreateVacancy.cshtml"
                                                                                                     Write(isApplicationThroughRAAYes);

            
            #line default
            #line hidden
WriteLiteral(">\r\n");

WriteLiteral("                    ");

            
            #line 102 "..\..\Views\VacancyPosting\CreateVacancy.cshtml"
               Write(Html.RadioButtonFor(model => model.OfflineVacancy, false, new { id = "apprenticeship-online-vacancy", aria_labelledby = "apprenticeship-vacancy-management-type-label" }));

            
            #line default
            #line hidden
WriteLiteral(" Yes\r\n                </label>\r\n\r\n                ");

WriteLiteral("\r\n                <label");

WriteLiteral(" for=\"apprenticeship-offline-vacancy\"");

WriteLiteral(" class=\"block-label\"");

WriteLiteral(" data-target=\"offline-panel\"");

WriteLiteral(" ");

            
            #line 106 "..\..\Views\VacancyPosting\CreateVacancy.cshtml"
                                                                                                       Write(isApplicationThroughRAANo);

            
            #line default
            #line hidden
WriteLiteral(">\r\n");

WriteLiteral("                    ");

            
            #line 107 "..\..\Views\VacancyPosting\CreateVacancy.cshtml"
               Write(Html.RadioButtonFor(model => model.OfflineVacancy, true, new { id = "apprenticeship-offline-vacancy", aria_labelledby = "apprenticeship-vacancy-management-type-label", aria_controls = "offline-panel" }));

            
            #line default
            #line hidden
WriteLiteral(" No\r\n                </label>\r\n            </div>\r\n            <div");

WriteLiteral(" id=\"offline-panel\"");

WriteLiteral(" class=\"toggle-content panel-indent blocklabel-content\"");

WriteLiteral(">\r\n                <div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(">\r\n                    ");

WriteLiteral("\r\n");

WriteLiteral("                    ");

            
            #line 113 "..\..\Views\VacancyPosting\CreateVacancy.cshtml"
               Write(Html.FormTextFor(m => m.OfflineApplicationUrl, controlHtmlAttributes: new { @class = "width-all-1-2", type = "text", size = 12, id = "apprenticeship-offline-application-url" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                </div>\r\n                <div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(">\r\n                    ");

WriteLiteral("\r\n");

WriteLiteral("                    ");

            
            #line 117 "..\..\Views\VacancyPosting\CreateVacancy.cshtml"
               Write(Html.FormTextAreaFor(m => m.OfflineApplicationInstructions, controlHtmlAttributes: new { type = "text", size = 12, @class = "width-all-1-1 form-textarea-medium", id = "apprenticheship-offline-application-instructions" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                    <br />\r\n                </div>\r\n            </div>\r\n       " +
" </div>\r\n    </div>\r\n");

            
            #line 123 "..\..\Views\VacancyPosting\CreateVacancy.cshtml"

    
            
            #line default
            #line hidden
            
            #line 124 "..\..\Views\VacancyPosting\CreateVacancy.cshtml"
Write(Html.HiddenFor(model => model.VacancyReferenceNumber));

            
            #line default
            #line hidden
            
            #line 124 "..\..\Views\VacancyPosting\CreateVacancy.cshtml"
                                                          
    
            
            #line default
            #line hidden
            
            #line 125 "..\..\Views\VacancyPosting\CreateVacancy.cshtml"
Write(Html.HiddenFor(model => model.Ukprn));

            
            #line default
            #line hidden
            
            #line 125 "..\..\Views\VacancyPosting\CreateVacancy.cshtml"
                                         
    
            
            #line default
            #line hidden
            
            #line 126 "..\..\Views\VacancyPosting\CreateVacancy.cshtml"
Write(Html.HiddenFor(model => model.ProviderSiteEmployerLink.ProviderSiteErn));

            
            #line default
            #line hidden
            
            #line 126 "..\..\Views\VacancyPosting\CreateVacancy.cshtml"
                                                                            
    
            
            #line default
            #line hidden
            
            #line 127 "..\..\Views\VacancyPosting\CreateVacancy.cshtml"
Write(Html.HiddenFor(model => model.ProviderSiteEmployerLink.Employer.Ern));

            
            #line default
            #line hidden
            
            #line 127 "..\..\Views\VacancyPosting\CreateVacancy.cshtml"
                                                                         ;
    
            
            #line default
            #line hidden
            
            #line 128 "..\..\Views\VacancyPosting\CreateVacancy.cshtml"
Write(Html.HiddenFor(model => model.VacancyGuid));

            
            #line default
            #line hidden
            
            #line 128 "..\..\Views\VacancyPosting\CreateVacancy.cshtml"
                                               


            
            #line default
            #line hidden
WriteLiteral("    <div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(">\r\n        <button");

WriteLiteral(" type=\"submit\"");

WriteLiteral(" class=\"button\"");

WriteLiteral(" name=\"CreateVacancy\"");

WriteLiteral(" value=\"CreateVacancy\"");

WriteLiteral(">Save and continue</button>\r\n        <button");

WriteLiteral(" id=\"createVacancyAndExit\"");

WriteLiteral(" type=\"submit\"");

WriteLiteral(" class=\"button-link\"");

WriteLiteral(" name=\"CreateVacancy\"");

WriteLiteral(" value=\"CreateVacancyAndExit\"");

WriteLiteral(">Save and exit</button>\r\n    </div>\r\n");

            
            #line 134 "..\..\Views\VacancyPosting\CreateVacancy.cshtml"
}

            
            #line default
            #line hidden
        }
    }
}
#pragma warning restore 1591
