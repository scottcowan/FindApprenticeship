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
    
    #line 2 "..\..\Views\VacancyPosting\VacancySummary.cshtml"
    using SFA.Apprenticeships.Domain.Entities.Vacancies.ProviderVacancies;
    
    #line default
    #line hidden
    using SFA.Apprenticeships.Web.Common.Constants;
    
    #line 4 "..\..\Views\VacancyPosting\VacancySummary.cshtml"
    using SFA.Apprenticeships.Web.Common.Extensions;
    
    #line default
    #line hidden
    using SFA.Apprenticeships.Web.Common.Framework;
    using SFA.Apprenticeships.Web.Common.Models.Common;
    
    #line 5 "..\..\Views\VacancyPosting\VacancySummary.cshtml"
    using SFA.Apprenticeships.Web.Common.Validators.Extensions;
    
    #line default
    #line hidden
    
    #line 6 "..\..\Views\VacancyPosting\VacancySummary.cshtml"
    using SFA.Apprenticeships.Web.Raa.Common.Constants.ViewModels;
    
    #line default
    #line hidden
    using SFA.Apprenticeships.Web.Raa.Common.Views.Shared.DisplayTemplates;
    using SFA.Apprenticeships.Web.Raa.Common.Views.Shared.EditorTemplates;
    using SFA.Apprenticeships.Web.Recruit;
    
    #line 3 "..\..\Views\VacancyPosting\VacancySummary.cshtml"
    using SFA.Apprenticeships.Web.Recruit.Constants;
    
    #line default
    #line hidden
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/VacancyPosting/VacancySummary.cshtml")]
    public partial class VacancySummary : System.Web.Mvc.WebViewPage<SFA.Apprenticeships.Web.Raa.Common.ViewModels.Vacancy.VacancySummaryViewModel>
    {
        public VacancySummary()
        {
        }
        public override void Execute()
        {
            
            #line 7 "..\..\Views\VacancyPosting\VacancySummary.cshtml"
  
    ViewBag.Title = "Recruit an Apprentice - Enter vacancy summary";

    var saveButtonText = "Save and continue";
    var saveButtonValue = "VacancySummary";

    if (Model.Status == ProviderVacancyStatuses.RejectedByQA)
    {
        saveButtonText = "Save and return to Preview";
        saveButtonValue = "VacancySummaryAndPreview";
    }

            
            #line default
            #line hidden
WriteLiteral("\r\n\r\n<h1");

WriteLiteral(" class=\"heading-xlarge\"");

WriteLiteral(">\r\n    Enter vacancy details\r\n</h1>\r\n\r\n");

            
            #line 24 "..\..\Views\VacancyPosting\VacancySummary.cshtml"
 using (Html.BeginRouteForm(RecruitmentRouteNames.VacancySummary, FormMethod.Post))
{
    
            
            #line default
            #line hidden
            
            #line 26 "..\..\Views\VacancyPosting\VacancySummary.cshtml"
Write(Html.AntiForgeryToken());

            
            #line default
            #line hidden
            
            #line 26 "..\..\Views\VacancyPosting\VacancySummary.cshtml"
                            
    
            
            #line default
            #line hidden
            
            #line 27 "..\..\Views\VacancyPosting\VacancySummary.cshtml"
Write(Html.Partial("ValidationSummary", ViewData.ModelState));

            
            #line default
            #line hidden
            
            #line 27 "..\..\Views\VacancyPosting\VacancySummary.cshtml"
                                                           

    
            
            #line default
            #line hidden
            
            #line 29 "..\..\Views\VacancyPosting\VacancySummary.cshtml"
Write(Html.HiddenFor(m => m.VacancyReferenceNumber));

            
            #line default
            #line hidden
            
            #line 29 "..\..\Views\VacancyPosting\VacancySummary.cshtml"
                                                  
    
            
            #line default
            #line hidden
            
            #line 30 "..\..\Views\VacancyPosting\VacancySummary.cshtml"
Write(Html.HiddenFor(model => model.Status));

            
            #line default
            #line hidden
            
            #line 30 "..\..\Views\VacancyPosting\VacancySummary.cshtml"
                                          


            
            #line default
            #line hidden
WriteLiteral("    <section>\r\n        <div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(">\r\n            <fieldset");

WriteLiteral(" class=\"form-group inline-fixed\"");

WriteLiteral(">\r\n");

WriteLiteral("                ");

            
            #line 35 "..\..\Views\VacancyPosting\VacancySummary.cshtml"
           Write(Html.FormTextAreaFor(m => m.WorkingWeek, containerHtmlAttributes: new {@baseClassName = "working-week"}, controlHtmlAttributes: new {@class = "width-all-1-1", type = "text", size = 12}));

            
            #line default
            #line hidden
WriteLiteral("\r\n            </fieldset>\r\n\r\n            <fieldset");

WriteLiteral(" class=\"form-group inline-fixed\"");

WriteLiteral(">\r\n");

WriteLiteral("                ");

            
            #line 39 "..\..\Views\VacancyPosting\VacancySummary.cshtml"
           Write(Html.FormTextFor(m => m.HoursPerWeek, controlHtmlAttributes: new { @class = "form-control-small", type = "tel", size = 12 }, containerHtmlAttributes: new {style = "margin-bottom: 15px"}));

            
            #line default
            #line hidden
WriteLiteral("\r\n            </fieldset>\r\n            <div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(">");

            
            #line 41 "..\..\Views\VacancyPosting\VacancySummary.cshtml"
                               Write(Html.DisplayFor(m => m.WorkingWeekComment, "Comment"));

            
            #line default
            #line hidden
WriteLiteral("</div>\r\n            <div");

WriteLiteral(" class=\"blocklabel-single-container\"");

WriteLiteral(">\r\n                <div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(">\r\n                    <a");

WriteAttribute("name", Tuple.Create(" name=\"", 1929), Tuple.Create("\"", 1987)
            
            #line 44 "..\..\Views\VacancyPosting\VacancySummary.cshtml"
, Tuple.Create(Tuple.Create("", 1936), Tuple.Create<System.Object, System.Int32>(Html.NameFor(m => m.WageType).ToString().ToLower()
            
            #line default
            #line hidden
, 1936), false)
);

WriteLiteral("></a>\r\n                    <label");

WriteLiteral(" class=\"form-label\"");

WriteLiteral(" for=\"weekly-wage\"");

WriteLiteral(">Wage</label>\r\n                    <div");

WriteAttribute("class", Tuple.Create(" class=\"", 2097), Tuple.Create("\"", 2196)
, Tuple.Create(Tuple.Create("", 2105), Tuple.Create("form-group", 2105), true)
            
            #line 46 "..\..\Views\VacancyPosting\VacancySummary.cshtml"
, Tuple.Create(Tuple.Create(" ", 2115), Tuple.Create<System.Object, System.Int32>(HtmlExtensions.GetValidationCssClass(Html.GetValidationType(m => m.WageType))
            
            #line default
            #line hidden
, 2116), false)
);

WriteLiteral(" data-editable-x=\"\"");

WriteLiteral(">\r\n                        ");

WriteLiteral("\r\n                        <label");

WriteLiteral(" for=\"custom-wage\"");

WriteLiteral(" class=\"block-label\"");

WriteLiteral(" data-target=\"custom-wage-panel\"");

WriteLiteral(">\r\n");

WriteLiteral("                            ");

            
            #line 49 "..\..\Views\VacancyPosting\VacancySummary.cshtml"
                       Write(Html.RadioButtonFor(model => model.WageType, WageType.Custom, new {id = "custom-wage", aria_controls = "wage-type-panel"}));

            
            #line default
            #line hidden
WriteLiteral("\r\n                            Custom wage\r\n                        </label>\r\n    " +
"                    ");

WriteLiteral("\r\n                        <label");

WriteLiteral(" for=\"national-minimum-wage\"");

WriteLiteral(" class=\"block-label\"");

WriteLiteral(">\r\n");

WriteLiteral("                            ");

            
            #line 54 "..\..\Views\VacancyPosting\VacancySummary.cshtml"
                       Write(Html.RadioButtonFor(model => model.WageType, WageType.NationalMinimumWage, new {id = "national-minimum-wage", aria_controls = "wage-type-panel"}));

            
            #line default
            #line hidden
WriteLiteral("\r\n                            National Minimum Wage\r\n                        </la" +
"bel>\r\n                        ");

WriteLiteral("\r\n                        <label");

WriteLiteral(" for=\"apprenticeship-minimum-wage\"");

WriteLiteral(" class=\"block-label\"");

WriteLiteral(">\r\n");

WriteLiteral("                            ");

            
            #line 59 "..\..\Views\VacancyPosting\VacancySummary.cshtml"
                       Write(Html.RadioButtonFor(model => model.WageType, WageType.ApprenticeshipMinimumWage, new {id = "apprenticeship-minimum-wage", aria_controls = "wage-type-panel"}));

            
            #line default
            #line hidden
WriteLiteral("\r\n                            National Minimum Wage for apprentices\r\n            " +
"            </label>\r\n");

WriteLiteral("                        ");

            
            #line 62 "..\..\Views\VacancyPosting\VacancySummary.cshtml"
                   Write(Html.ValidationMessageFor(m => m.WageType));

            
            #line default
            #line hidden
WriteLiteral("\r\n                    </div>\r\n                    <div");

WriteLiteral(" id=\"custom-wage-panel\"");

WriteLiteral(" class=\"toggle-content blocklabel-content\"");

WriteLiteral(">\r\n                        <fieldset");

WriteLiteral(" class=\"form-group inline-fixed\"");

WriteLiteral(">\r\n                            £\r\n");

WriteLiteral("                            ");

            
            #line 67 "..\..\Views\VacancyPosting\VacancySummary.cshtml"
                       Write(Html.FormTextFor(m => m.Wage, containerHtmlAttributes: new {@class = "form-group-compound"}, labelHtmlAttributes: new {style = "Display: none"}, controlHtmlAttributes: new {@class = "form-control-large", type = "tel", size = 12}));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("                            ");

            
            #line 68 "..\..\Views\VacancyPosting\VacancySummary.cshtml"
                       Write(Html.DropDownListFor(m => m.WageUnit, Model.WageUnits));

            
            #line default
            #line hidden
WriteLiteral("\r\n                        </fieldset>\r\n                    </div>\r\n              " +
"  </div>\r\n                <div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(">");

            
            #line 72 "..\..\Views\VacancyPosting\VacancySummary.cshtml"
                                   Write(Html.DisplayFor(m => m.WageComment, "Comment"));

            
            #line default
            #line hidden
WriteLiteral("</div>\r\n            </div>\r\n\r\n            <fieldset");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(">\r\n                <div");

WriteAttribute("class", Tuple.Create(" class=\"", 4389), Tuple.Create("\"", 4488)
, Tuple.Create(Tuple.Create("", 4397), Tuple.Create("form-group", 4397), true)
            
            #line 76 "..\..\Views\VacancyPosting\VacancySummary.cshtml"
, Tuple.Create(Tuple.Create(" ", 4407), Tuple.Create<System.Object, System.Int32>(HtmlExtensions.GetValidationCssClass(Html.GetValidationType(m => m.Duration))
            
            #line default
            #line hidden
, 4408), false)
);

WriteLiteral(">\r\n                    <a");

WriteAttribute("name", Tuple.Create(" name=\"", 4514), Tuple.Create("\"", 4572)
            
            #line 77 "..\..\Views\VacancyPosting\VacancySummary.cshtml"
, Tuple.Create(Tuple.Create("", 4521), Tuple.Create<System.Object, System.Int32>(Html.NameFor(m => m.Duration).ToString().ToLower()
            
            #line default
            #line hidden
, 4521), false)
);

WriteLiteral("></a>\r\n");

WriteLiteral("                    ");

            
            #line 78 "..\..\Views\VacancyPosting\VacancySummary.cshtml"
               Write(Html.LabelFor(m => m.Duration, new {@class = "form-label"}));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("                    ");

            
            #line 79 "..\..\Views\VacancyPosting\VacancySummary.cshtml"
               Write(Html.TextBoxFor(m => m.Duration, new {@class = "form-control-large form-control", type = "tel", size = 12}));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("                    ");

            
            #line 80 "..\..\Views\VacancyPosting\VacancySummary.cshtml"
               Write(Html.DropDownListFor(m => m.DurationType, Model.DurationTypes));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("                    ");

            
            #line 81 "..\..\Views\VacancyPosting\VacancySummary.cshtml"
               Write(Html.ValidationMessageWithSeverityFor(m => m.Duration, Html.GetValidationType(m => m.Duration)));

            
            #line default
            #line hidden
WriteLiteral("\r\n                </div>\r\n            </fieldset>\r\n            <fieldset");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(">\r\n");

WriteLiteral("                ");

            
            #line 85 "..\..\Views\VacancyPosting\VacancySummary.cshtml"
           Write(Html.DisplayFor(m => m.DurationComment, "Comment"));

            
            #line default
            #line hidden
WriteLiteral("\r\n            </fieldset>\r\n\r\n            <fieldset");

WriteAttribute("class", Tuple.Create(" class=\"", 5204), Tuple.Create("\"", 5330)
, Tuple.Create(Tuple.Create("", 5212), Tuple.Create("form-group", 5212), true)
, Tuple.Create(Tuple.Create(" ", 5222), Tuple.Create("inline-fixed", 5223), true)
, Tuple.Create(Tuple.Create(" ", 5235), Tuple.Create("date-input", 5236), true)
            
            #line 88 "..\..\Views\VacancyPosting\VacancySummary.cshtml"
, Tuple.Create(Tuple.Create(" ", 5246), Tuple.Create<System.Object, System.Int32>(HtmlExtensions.GetValidationCssClass(Html.GetValidationType(m => m.ClosingDate))
            
            #line default
            #line hidden
, 5247), false)
);

WriteLiteral(">\r\n                <a");

WriteAttribute("name", Tuple.Create(" name=\"", 5352), Tuple.Create("\"", 5413)
            
            #line 89 "..\..\Views\VacancyPosting\VacancySummary.cshtml"
, Tuple.Create(Tuple.Create("", 5359), Tuple.Create<System.Object, System.Int32>(Html.NameFor(m => m.ClosingDate).ToString().ToLower()
            
            #line default
            #line hidden
, 5359), false)
);

WriteLiteral("></a>\r\n                <legend");

WriteLiteral(" class=\"form-label\"");

WriteLiteral(">");

            
            #line 90 "..\..\Views\VacancyPosting\VacancySummary.cshtml"
                                      Write(Model.GetMetadata(m => m.ClosingDate).DisplayName);

            
            #line default
            #line hidden
WriteLiteral("</legend>\r\n");

WriteLiteral("                ");

            
            #line 91 "..\..\Views\VacancyPosting\VacancySummary.cshtml"
           Write(Html.EditorFor(m => m.ClosingDate));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("                ");

            
            #line 92 "..\..\Views\VacancyPosting\VacancySummary.cshtml"
           Write(Html.ValidationMessageWithSeverityFor(m => m.ClosingDate, Html.GetValidationType(m => m.ClosingDate)));

            
            #line default
            #line hidden
WriteLiteral("\r\n            </fieldset>\r\n            <div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(">");

            
            #line 94 "..\..\Views\VacancyPosting\VacancySummary.cshtml"
                               Write(Html.DisplayFor(m => m.ClosingDateComment, "Comment"));

            
            #line default
            #line hidden
WriteLiteral("</div>\r\n            <fieldset");

WriteAttribute("class", Tuple.Create(" class=\"", 5842), Tuple.Create("\"", 5974)
, Tuple.Create(Tuple.Create("", 5850), Tuple.Create("form-group", 5850), true)
, Tuple.Create(Tuple.Create(" ", 5860), Tuple.Create("inline-fixed", 5861), true)
, Tuple.Create(Tuple.Create(" ", 5873), Tuple.Create("date-input", 5874), true)
            
            #line 95 "..\..\Views\VacancyPosting\VacancySummary.cshtml"
, Tuple.Create(Tuple.Create(" ", 5884), Tuple.Create<System.Object, System.Int32>(HtmlExtensions.GetValidationCssClass(Html.GetValidationType(m => m.PossibleStartDate))
            
            #line default
            #line hidden
, 5885), false)
);

WriteLiteral(">\r\n                <a");

WriteAttribute("name", Tuple.Create(" name=\"", 5996), Tuple.Create("\"", 6063)
            
            #line 96 "..\..\Views\VacancyPosting\VacancySummary.cshtml"
, Tuple.Create(Tuple.Create("", 6003), Tuple.Create<System.Object, System.Int32>(Html.NameFor(m => m.PossibleStartDate).ToString().ToLower()
            
            #line default
            #line hidden
, 6003), false)
);

WriteLiteral("></a>\r\n                <legend");

WriteLiteral(" class=\"form-label\"");

WriteLiteral(">");

            
            #line 97 "..\..\Views\VacancyPosting\VacancySummary.cshtml"
                                      Write(Model.GetMetadata(m => m.PossibleStartDate).DisplayName);

            
            #line default
            #line hidden
WriteLiteral("</legend>\r\n");

WriteLiteral("                ");

            
            #line 98 "..\..\Views\VacancyPosting\VacancySummary.cshtml"
           Write(Html.EditorFor(m => m.PossibleStartDate));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("                ");

            
            #line 99 "..\..\Views\VacancyPosting\VacancySummary.cshtml"
           Write(Html.ValidationMessageWithSeverityFor(m => m.PossibleStartDate, Html.GetValidationType(m => m.PossibleStartDate)));

            
            #line default
            #line hidden
WriteLiteral("\r\n            </fieldset>\r\n            <div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(">");

            
            #line 101 "..\..\Views\VacancyPosting\VacancySummary.cshtml"
                               Write(Html.DisplayFor(m => m.PossibleStartDateComment, "Comment"));

            
            #line default
            #line hidden
WriteLiteral("</div>\r\n");

WriteLiteral("            ");

            
            #line 102 "..\..\Views\VacancyPosting\VacancySummary.cshtml"
       Write(Html.FormTextAreaFor(m => m.LongDescription, controlHtmlAttributes: new {@class = "width-all-1-1 form-textarea-large", type = "text", size = 12, rows = 22}));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("            ");

            
            #line 103 "..\..\Views\VacancyPosting\VacancySummary.cshtml"
       Write(Html.DisplayFor(m => m.LongDescriptionComment, "Comment"));

            
            #line default
            #line hidden
WriteLiteral("\r\n        </div>\r\n    </section>\r\n");

WriteLiteral("    <div");

WriteLiteral(" class=\"grid grid-1-2\"");

WriteLiteral(">\r\n        <button");

WriteLiteral(" id=\"vacancySummaryButton\"");

WriteLiteral(" type=\"submit\"");

WriteLiteral(" class=\"button\"");

WriteLiteral(" name=\"VacancySummary\"");

WriteAttribute("value", Tuple.Create(" value=\"", 6901), Tuple.Create("\"", 6925)
            
            #line 107 "..\..\Views\VacancyPosting\VacancySummary.cshtml"
                    , Tuple.Create(Tuple.Create("", 6909), Tuple.Create<System.Object, System.Int32>(saveButtonValue
            
            #line default
            #line hidden
, 6909), false)
);

WriteLiteral(">");

            
            #line 107 "..\..\Views\VacancyPosting\VacancySummary.cshtml"
                                                                                                                 Write(saveButtonText);

            
            #line default
            #line hidden
WriteLiteral("</button>\r\n        <button");

WriteLiteral(" id=\"vacancySummaryAndExit\"");

WriteLiteral(" type=\"submit\"");

WriteLiteral(" class=\"button-link\"");

WriteLiteral(" name=\"VacancySummary\"");

WriteLiteral(" value=\"VacancySummaryAndExit\"");

WriteLiteral(">Save and exit</button>\r\n    </div>\r\n");

            
            #line 110 "..\..\Views\VacancyPosting\VacancySummary.cshtml"
}
            
            #line default
            #line hidden
        }
    }
}
#pragma warning restore 1591
