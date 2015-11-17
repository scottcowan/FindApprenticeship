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
    
    #line 2 "..\..\Views\Vacancy\BasicDetails.cshtml"
    using SFA.Apprenticeships.Domain.Entities.Vacancies.ProviderVacancies;
    
    #line default
    #line hidden
    
    #line 3 "..\..\Views\Vacancy\BasicDetails.cshtml"
    using SFA.Apprenticeships.Domain.Entities.Vacancies.ProviderVacancies.Apprenticeship;
    
    #line default
    #line hidden
    using SFA.Apprenticeships.Web.Common.Constants;
    using SFA.Apprenticeships.Web.Common.Framework;
    using SFA.Apprenticeships.Web.Common.Models.Common;
    using SFA.Apprenticeships.Web.Manage;
    
    #line 4 "..\..\Views\Vacancy\BasicDetails.cshtml"
    using SFA.Apprenticeships.Web.Manage.Constants;
    
    #line default
    #line hidden
    
    #line 5 "..\..\Views\Vacancy\BasicDetails.cshtml"
    using SFA.Apprenticeships.Web.Manage.Views.Shared.EditorTemplates;
    
    #line default
    #line hidden
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/Vacancy/BasicDetails.cshtml")]
    public partial class BasicDetails : System.Web.Mvc.WebViewPage<SFA.Apprenticeships.Web.Raa.Common.ViewModels.Vacancy.NewVacancyViewModel>
    {
        public BasicDetails()
        {
        }
        public override void Execute()
        {
            
            #line 6 "..\..\Views\Vacancy\BasicDetails.cshtml"
  
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

            
            #line 22 "..\..\Views\Vacancy\BasicDetails.cshtml"
 using (Html.BeginRouteForm(ManagementRouteNames.BasicDetails, FormMethod.Post))
{
    
            
            #line default
            #line hidden
            
            #line 24 "..\..\Views\Vacancy\BasicDetails.cshtml"
Write(Html.AntiForgeryToken());

            
            #line default
            #line hidden
            
            #line 24 "..\..\Views\Vacancy\BasicDetails.cshtml"
                            
    
            
            #line default
            #line hidden
            
            #line 25 "..\..\Views\Vacancy\BasicDetails.cshtml"
Write(Html.Partial("ValidationSummary", ViewData.ModelState));

            
            #line default
            #line hidden
            
            #line 25 "..\..\Views\Vacancy\BasicDetails.cshtml"
                                                           

    
            
            #line default
            #line hidden
            
            #line 27 "..\..\Views\Vacancy\BasicDetails.cshtml"
Write(Html.FormTextAreaFor(m => m.Title, controlHtmlAttributes: new { type = "text", size = 12, @class = "width-all-1-1 form-textarea-small" }));

            
            #line default
            #line hidden
            
            #line 27 "..\..\Views\Vacancy\BasicDetails.cshtml"
                                                                                                                                              
    
            
            #line default
            #line hidden
            
            #line 28 "..\..\Views\Vacancy\BasicDetails.cshtml"
Write(Html.EditorFor(m => m.TitleComment, "Comment"));

            
            #line default
            #line hidden
            
            #line 28 "..\..\Views\Vacancy\BasicDetails.cshtml"
                                                   
    
            
            #line default
            #line hidden
            
            #line 29 "..\..\Views\Vacancy\BasicDetails.cshtml"
Write(Html.ValidationMessageFor(m => m.TitleComment));

            
            #line default
            #line hidden
            
            #line 29 "..\..\Views\Vacancy\BasicDetails.cshtml"
                                                   

    
            
            #line default
            #line hidden
            
            #line 31 "..\..\Views\Vacancy\BasicDetails.cshtml"
Write(Html.FormTextAreaFor(m => m.ShortDescription, controlHtmlAttributes: new { type = "text", size = 12, @class = "width-all-1-1 form-textarea-medium" }));

            
            #line default
            #line hidden
            
            #line 31 "..\..\Views\Vacancy\BasicDetails.cshtml"
                                                                                                                                                          
    
            
            #line default
            #line hidden
            
            #line 32 "..\..\Views\Vacancy\BasicDetails.cshtml"
Write(Html.EditorFor(m => m.ShortDescriptionComment, "Comment"));

            
            #line default
            #line hidden
            
            #line 32 "..\..\Views\Vacancy\BasicDetails.cshtml"
                                                              
    
            
            #line default
            #line hidden
            
            #line 33 "..\..\Views\Vacancy\BasicDetails.cshtml"
Write(Html.ValidationMessageFor(m => m.ShortDescriptionComment));

            
            #line default
            #line hidden
            
            #line 33 "..\..\Views\Vacancy\BasicDetails.cshtml"
                                                              


            
            #line default
            #line hidden
WriteLiteral("    <div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(">\r\n        <div");

WriteLiteral(" class=\"blocklabel-single-container\"");

WriteLiteral(">\r\n            <div");

WriteAttribute("class", Tuple.Create(" class=\"", 1717), Tuple.Create("\"", 1864)
, Tuple.Create(Tuple.Create("", 1725), Tuple.Create("form-group", 1725), true)
            
            #line 37 "..\..\Views\Vacancy\BasicDetails.cshtml"
, Tuple.Create(Tuple.Create(" ", 1735), Tuple.Create<System.Object, System.Int32>(HtmlExtensions.GetValidationCssClass(Html.GetValidationType(m => m.TrainingType))
            
            #line default
            #line hidden
, 1736), false)
, Tuple.Create(Tuple.Create(" ", 1820), Tuple.Create("inline", 1821), true)
, Tuple.Create(Tuple.Create(" ", 1827), Tuple.Create("clearfix", 1828), true)
, Tuple.Create(Tuple.Create(" ", 1836), Tuple.Create("blocklabel-single", 1837), true)
, Tuple.Create(Tuple.Create(" ", 1854), Tuple.Create("hide-nojs", 1855), true)
);

WriteLiteral(">\r\n                <a");

WriteAttribute("name", Tuple.Create(" name=\"", 1886), Tuple.Create("\"", 1948)
            
            #line 38 "..\..\Views\Vacancy\BasicDetails.cshtml"
, Tuple.Create(Tuple.Create("", 1893), Tuple.Create<System.Object, System.Int32>(Html.NameFor(m => m.TrainingType).ToString().ToLower()
            
            #line default
            #line hidden
, 1893), false)
);

WriteLiteral("></a>\r\n                <label");

WriteLiteral(" class=\"form-label\"");

WriteLiteral(">Apprenticeship type</label>\r\n                ");

WriteLiteral("\r\n                <label");

WriteLiteral(" data-target=\"training-type-frameworks-panel\"");

WriteLiteral(" for=\"training-type-frameworks\"");

WriteAttribute("class", Tuple.Create(" class=\"", 2190), Tuple.Create("\"", 2229)
, Tuple.Create(Tuple.Create("", 2198), Tuple.Create("block-label", 2198), true)
            
            #line 41 "..\..\Views\Vacancy\BasicDetails.cshtml"
                                     , Tuple.Create(Tuple.Create(" ", 2209), Tuple.Create<System.Object, System.Int32>(frameworksSelected
            
            #line default
            #line hidden
, 2210), false)
);

WriteLiteral(">\r\n");

WriteLiteral("                    ");

            
            #line 42 "..\..\Views\Vacancy\BasicDetails.cshtml"
               Write(Html.RadioButtonFor(model => model.TrainingType, TrainingType.Frameworks, new {id = "training-type-frameworks", aria_controls = "training-type-frameworks-panel"}));

            
            #line default
            #line hidden
WriteLiteral("\r\n                    Frameworks\r\n                </label>\r\n                ");

WriteLiteral("\r\n                <label");

WriteLiteral(" data-target=\"training-type-standards-panel\"");

WriteLiteral(" for=\"training-type-standards\"");

WriteAttribute("class", Tuple.Create(" class=\"", 2637), Tuple.Create("\"", 2675)
, Tuple.Create(Tuple.Create("", 2645), Tuple.Create("block-label", 2645), true)
            
            #line 46 "..\..\Views\Vacancy\BasicDetails.cshtml"
                                   , Tuple.Create(Tuple.Create(" ", 2656), Tuple.Create<System.Object, System.Int32>(standardsSelected
            
            #line default
            #line hidden
, 2657), false)
);

WriteLiteral(">\r\n");

WriteLiteral("                    ");

            
            #line 47 "..\..\Views\Vacancy\BasicDetails.cshtml"
               Write(Html.RadioButtonFor(model => model.TrainingType, TrainingType.Standards, new {id = "training-type-standards", aria_controls = "training-type-standards-panel"}));

            
            #line default
            #line hidden
WriteLiteral("\r\n                    Standards\r\n                </label>\r\n");

WriteLiteral("                ");

            
            #line 50 "..\..\Views\Vacancy\BasicDetails.cshtml"
           Write(Html.ValidationMessageFor(m => m.TrainingType));

            
            #line default
            #line hidden
WriteLiteral("\r\n            </div>\r\n\r\n            <div");

WriteLiteral(" id=\"training-type-frameworks-panel\"");

WriteLiteral(" class=\"toggle-content blocklabel-content\"");

WriteLiteral(">\r\n                <div");

WriteAttribute("class", Tuple.Create(" class=\"", 3122), Tuple.Create("\"", 3230)
, Tuple.Create(Tuple.Create("", 3130), Tuple.Create("form-group", 3130), true)
            
            #line 54 "..\..\Views\Vacancy\BasicDetails.cshtml"
, Tuple.Create(Tuple.Create(" ", 3140), Tuple.Create<System.Object, System.Int32>(HtmlExtensions.GetValidationCssClass(Html.GetValidationType(m => m.FrameworkCodeName))
            
            #line default
            #line hidden
, 3141), false)
);

WriteLiteral(">\r\n                    <a");

WriteAttribute("name", Tuple.Create(" name=\"", 3256), Tuple.Create("\"", 3323)
            
            #line 55 "..\..\Views\Vacancy\BasicDetails.cshtml"
, Tuple.Create(Tuple.Create("", 3263), Tuple.Create<System.Object, System.Int32>(Html.NameFor(m => m.FrameworkCodeName).ToString().ToLower()
            
            #line default
            #line hidden
, 3263), false)
);

WriteLiteral("></a>\r\n                    <label");

WriteAttribute("for", Tuple.Create(" for=\"", 3357), Tuple.Create("\"", 3402)
            
            #line 56 "..\..\Views\Vacancy\BasicDetails.cshtml"
, Tuple.Create(Tuple.Create("", 3363), Tuple.Create<System.Object, System.Int32>(Html.NameFor(m => m.FrameworkCodeName)
            
            #line default
            #line hidden
, 3363), false)
);

WriteLiteral(" class=\"form-label\"");

WriteLiteral(">Apprenticeship framework</label>\r\n");

WriteLiteral("                    ");

            
            #line 57 "..\..\Views\Vacancy\BasicDetails.cshtml"
               Write(Html.DropDownListFor(m => m.FrameworkCodeName, Model.SectorsAndFrameworks, new {@class = "para-btm-margin chosen-select", style = "min-width: 50%;"}));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("                    ");

            
            #line 58 "..\..\Views\Vacancy\BasicDetails.cshtml"
               Write(Html.ValidationMessageFor(m => m.FrameworkCodeName));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("                    ");

            
            #line 59 "..\..\Views\Vacancy\BasicDetails.cshtml"
               Write(Html.EditorFor(m => m.FrameworkCodeNameComment, "Comment"));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("                    ");

            
            #line 60 "..\..\Views\Vacancy\BasicDetails.cshtml"
               Write(Html.ValidationMessageFor(m => m.FrameworkCodeNameComment));

            
            #line default
            #line hidden
WriteLiteral("\r\n                </div>\r\n\r\n                <div");

WriteAttribute("class", Tuple.Create(" class=\"", 3911), Tuple.Create("\"", 4021)
, Tuple.Create(Tuple.Create("", 3919), Tuple.Create("form-group", 3919), true)
            
            #line 63 "..\..\Views\Vacancy\BasicDetails.cshtml"
, Tuple.Create(Tuple.Create(" ", 3929), Tuple.Create<System.Object, System.Int32>(HtmlExtensions.GetValidationCssClass(Html.GetValidationType(m => m.ApprenticeshipLevel))
            
            #line default
            #line hidden
, 3930), false)
);

WriteLiteral(">\r\n                    <a");

WriteAttribute("name", Tuple.Create(" name=\"", 4047), Tuple.Create("\"", 4116)
            
            #line 64 "..\..\Views\Vacancy\BasicDetails.cshtml"
, Tuple.Create(Tuple.Create("", 4054), Tuple.Create<System.Object, System.Int32>(Html.NameFor(m => m.ApprenticeshipLevel).ToString().ToLower()
            
            #line default
            #line hidden
, 4054), false)
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

            
            #line 69 "..\..\Views\Vacancy\BasicDetails.cshtml"
                       Write(Html.RadioButtonFor(model => model.ApprenticeshipLevel, ApprenticeshipLevel.Intermediate, new {id = "apprenticeship-level-intermediate", aria_labelledby = "apprenticeship-level-label"}));

            
            #line default
            #line hidden
WriteLiteral(" Intermediate\r\n                        </label>\r\n");

WriteLiteral("                        ");

            
            #line 71 "..\..\Views\Vacancy\BasicDetails.cshtml"
                   Write(Html.EditorFor(m => m.ApprenticeshipLevelComment, "Comment"));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("                        ");

            
            #line 72 "..\..\Views\Vacancy\BasicDetails.cshtml"
                   Write(Html.ValidationMessageFor(m => m.ApprenticeshipLevelComment));

            
            #line default
            #line hidden
WriteLiteral("\r\n                    </div>\r\n\r\n                    <div");

WriteLiteral(" class=\"small-btm-margin clearfix\"");

WriteLiteral(">\r\n                        ");

WriteLiteral("\r\n                        <label");

WriteLiteral(" for=\"apprenticeship-level-advanced\"");

WriteLiteral(" class=\"block-label\"");

WriteLiteral(">\r\n");

WriteLiteral("                            ");

            
            #line 78 "..\..\Views\Vacancy\BasicDetails.cshtml"
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

            
            #line 85 "..\..\Views\Vacancy\BasicDetails.cshtml"
                       Write(Html.RadioButtonFor(model => model.ApprenticeshipLevel, ApprenticeshipLevel.Higher, new {id = "apprenticeship-level-higher", aria_labelledby = "apprenticeship-level-label"}));

            
            #line default
            #line hidden
WriteLiteral(" Higher\r\n                        </label>\r\n                    </div>\r\n\r\n        " +
"            <div");

WriteLiteral(" class=\"small-btm-margin clearfix\"");

WriteLiteral(">\r\n                        ");

WriteLiteral("\r\n                        <label");

WriteLiteral(" for=\"apprenticeship-level-degree\"");

WriteLiteral(" class=\"block-label\"");

WriteLiteral(">\r\n");

WriteLiteral("                            ");

            
            #line 92 "..\..\Views\Vacancy\BasicDetails.cshtml"
                       Write(Html.RadioButtonFor(model => model.ApprenticeshipLevel, ApprenticeshipLevel.Degree, new {id = "apprenticeship-level-degree", aria_labelledby = "apprenticeship-level-label"}));

            
            #line default
            #line hidden
WriteLiteral(" Degree\r\n                        </label>\r\n                    </div>\r\n");

WriteLiteral("                    ");

            
            #line 95 "..\..\Views\Vacancy\BasicDetails.cshtml"
               Write(Html.ValidationMessageFor(m => m.ApprenticeshipLevel));

            
            #line default
            #line hidden
WriteLiteral("\r\n                </div>\r\n            </div>\r\n\r\n            <div");

WriteLiteral(" id=\"training-type-standards-panel\"");

WriteLiteral(" class=\"toggle-content blocklabel-content\"");

WriteLiteral(">\r\n                <div");

WriteAttribute("class", Tuple.Create(" class=\"", 6626), Tuple.Create("\"", 6727)
, Tuple.Create(Tuple.Create("", 6634), Tuple.Create("form-group", 6634), true)
            
            #line 100 "..\..\Views\Vacancy\BasicDetails.cshtml"
, Tuple.Create(Tuple.Create(" ", 6644), Tuple.Create<System.Object, System.Int32>(HtmlExtensions.GetValidationCssClass(Html.GetValidationType(m => m.StandardId))
            
            #line default
            #line hidden
, 6645), false)
);

WriteLiteral(">\r\n                    <a");

WriteAttribute("name", Tuple.Create(" name=\"", 6753), Tuple.Create("\"", 6813)
            
            #line 101 "..\..\Views\Vacancy\BasicDetails.cshtml"
, Tuple.Create(Tuple.Create("", 6760), Tuple.Create<System.Object, System.Int32>(Html.NameFor(m => m.StandardId).ToString().ToLower()
            
            #line default
            #line hidden
, 6760), false)
);

WriteLiteral("></a>\r\n                    <label");

WriteAttribute("for", Tuple.Create(" for=\"", 6847), Tuple.Create("\"", 6885)
            
            #line 102 "..\..\Views\Vacancy\BasicDetails.cshtml"
, Tuple.Create(Tuple.Create("", 6853), Tuple.Create<System.Object, System.Int32>(Html.NameFor(m => m.StandardId)
            
            #line default
            #line hidden
, 6853), false)
);

WriteLiteral(" class=\"form-label\"");

WriteLiteral(">Apprenticeship standard</label>\r\n                    <select");

WriteAttribute("name", Tuple.Create(" name=\"", 6966), Tuple.Create("\"", 7005)
            
            #line 103 "..\..\Views\Vacancy\BasicDetails.cshtml"
, Tuple.Create(Tuple.Create("", 6973), Tuple.Create<System.Object, System.Int32>(Html.NameFor(m => m.StandardId)
            
            #line default
            #line hidden
, 6973), false)
);

WriteAttribute("id", Tuple.Create(" id=\"", 7006), Tuple.Create("\"", 7043)
            
            #line 103 "..\..\Views\Vacancy\BasicDetails.cshtml"
, Tuple.Create(Tuple.Create("", 7011), Tuple.Create<System.Object, System.Int32>(Html.NameFor(m => m.StandardId)
            
            #line default
            #line hidden
, 7011), false)
);

WriteLiteral(" class=\"para-btm-margin chosen-select\"");

WriteLiteral(" style=\"min-width: 50%;\"");

WriteLiteral(">\r\n                        <option");

WriteLiteral(" value=\"\"");

WriteLiteral(">Choose from the list of standards</option>\r\n");

            
            #line 105 "..\..\Views\Vacancy\BasicDetails.cshtml"
                        
            
            #line default
            #line hidden
            
            #line 105 "..\..\Views\Vacancy\BasicDetails.cshtml"
                         foreach (var standardGroup in Model.Standards.GroupBy(s => s.Sector))
                        {

            
            #line default
            #line hidden
WriteLiteral("                            <optgroup");

WriteAttribute("label", Tuple.Create(" label=\"", 7354), Tuple.Create("\"", 7380)
            
            #line 107 "..\..\Views\Vacancy\BasicDetails.cshtml"
, Tuple.Create(Tuple.Create("", 7362), Tuple.Create<System.Object, System.Int32>(standardGroup.Key
            
            #line default
            #line hidden
, 7362), false)
);

WriteLiteral(">\r\n");

            
            #line 108 "..\..\Views\Vacancy\BasicDetails.cshtml"
                                
            
            #line default
            #line hidden
            
            #line 108 "..\..\Views\Vacancy\BasicDetails.cshtml"
                                 foreach (var standard in standardGroup)
                                {

            
            #line default
            #line hidden
WriteLiteral("                                    <option");

WriteAttribute("value", Tuple.Create(" value=\"", 7536), Tuple.Create("\"", 7556)
            
            #line 110 "..\..\Views\Vacancy\BasicDetails.cshtml"
, Tuple.Create(Tuple.Create("", 7544), Tuple.Create<System.Object, System.Int32>(standard.Id
            
            #line default
            #line hidden
, 7544), false)
);

WriteLiteral(" ");

            
            #line 110 "..\..\Views\Vacancy\BasicDetails.cshtml"
                                                             Write(standard.Id == Model.StandardId ? "selected" : "");

            
            #line default
            #line hidden
WriteLiteral(" data-apprenticeship-level=\"");

            
            #line 110 "..\..\Views\Vacancy\BasicDetails.cshtml"
                                                                                                                                            Write(standard.ApprenticeshipLevel);

            
            #line default
            #line hidden
WriteLiteral("\">\r\n");

WriteLiteral("                                        ");

            
            #line 111 "..\..\Views\Vacancy\BasicDetails.cshtml"
                                   Write(standard.Name);

            
            #line default
            #line hidden
WriteLiteral("\r\n                                    </option>\r\n");

            
            #line 113 "..\..\Views\Vacancy\BasicDetails.cshtml"
                                }

            
            #line default
            #line hidden
WriteLiteral("                            </optgroup>\r\n");

            
            #line 115 "..\..\Views\Vacancy\BasicDetails.cshtml"
                        }

            
            #line default
            #line hidden
WriteLiteral("                    </select>\r\n\r\n");

WriteLiteral("                    ");

            
            #line 118 "..\..\Views\Vacancy\BasicDetails.cshtml"
               Write(Html.ValidationMessageFor(m => m.StandardId));

            
            #line default
            #line hidden
WriteLiteral("\r\n                </div>\r\n\r\n                <div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(">\r\n                    <label");

WriteLiteral(" class=\"form-label\"");

WriteLiteral(">Apprenticeship level</label>\r\n                    <p");

WriteLiteral(" id=\"apprenticeship-level-name\"");

WriteLiteral(">");

            
            #line 123 "..\..\Views\Vacancy\BasicDetails.cshtml"
                                                 Write(Html.DisplayFor(m => m.ApprenticeshipLevel));

            
            #line default
            #line hidden
WriteLiteral("</p>\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n");

            
            #line 128 "..\..\Views\Vacancy\BasicDetails.cshtml"


            
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

            
            #line 138 "..\..\Views\Vacancy\BasicDetails.cshtml"
                                                                                                     Write(isApplicationThroughRAAYes);

            
            #line default
            #line hidden
WriteLiteral(">\r\n");

WriteLiteral("                    ");

            
            #line 139 "..\..\Views\Vacancy\BasicDetails.cshtml"
               Write(Html.RadioButtonFor(model => model.OfflineVacancy, false, new { id = "apprenticeship-online-vacancy", aria_labelledby = "apprenticeship-vacancy-management-type-label" }));

            
            #line default
            #line hidden
WriteLiteral(" Yes\r\n                </label>\r\n\r\n                ");

WriteLiteral("\r\n                <label");

WriteLiteral(" for=\"apprenticeship-offline-vacancy\"");

WriteLiteral(" class=\"block-label\"");

WriteLiteral(" data-target=\"offline-panel\"");

WriteLiteral(" ");

            
            #line 143 "..\..\Views\Vacancy\BasicDetails.cshtml"
                                                                                                       Write(isApplicationThroughRAANo);

            
            #line default
            #line hidden
WriteLiteral(">\r\n");

WriteLiteral("                    ");

            
            #line 144 "..\..\Views\Vacancy\BasicDetails.cshtml"
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

            
            #line 150 "..\..\Views\Vacancy\BasicDetails.cshtml"
               Write(Html.FormTextFor(m => m.OfflineApplicationUrl, controlHtmlAttributes: new { @class = "width-all-1-1", type = "text", size = 12, id = "apprenticeship-offline-application-url" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("                    ");

            
            #line 151 "..\..\Views\Vacancy\BasicDetails.cshtml"
               Write(Html.EditorFor(m => m.OfflineApplicationUrlComment, "Comment"));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("                    ");

            
            #line 152 "..\..\Views\Vacancy\BasicDetails.cshtml"
               Write(Html.ValidationMessageFor(m => m.OfflineApplicationUrlComment));

            
            #line default
            #line hidden
WriteLiteral("\r\n                </div>\r\n                <div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(">\r\n                    ");

WriteLiteral("\r\n");

WriteLiteral("                    ");

            
            #line 156 "..\..\Views\Vacancy\BasicDetails.cshtml"
               Write(Html.FormTextAreaFor(m => m.OfflineApplicationInstructions, controlHtmlAttributes: new { type = "text", size = 12, @class = "width-all-1-1 form-textarea-medium", id = "apprenticheship-offline-application-instructions" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("                    ");

            
            #line 157 "..\..\Views\Vacancy\BasicDetails.cshtml"
               Write(Html.EditorFor(m => m.OfflineApplicationInstructionsComment, "Comment"));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("                    ");

            
            #line 158 "..\..\Views\Vacancy\BasicDetails.cshtml"
               Write(Html.ValidationMessageFor(m => m.OfflineApplicationInstructionsComment));

            
            #line default
            #line hidden
WriteLiteral("\r\n                    <br />\r\n                </div>\r\n            </div>\r\n       " +
" </div>\r\n    </div>\r\n");

            
            #line 164 "..\..\Views\Vacancy\BasicDetails.cshtml"

    
            
            #line default
            #line hidden
            
            #line 165 "..\..\Views\Vacancy\BasicDetails.cshtml"
Write(Html.HiddenFor(model => model.VacancyReferenceNumber));

            
            #line default
            #line hidden
            
            #line 165 "..\..\Views\Vacancy\BasicDetails.cshtml"
                                                          
    
            
            #line default
            #line hidden
            
            #line 166 "..\..\Views\Vacancy\BasicDetails.cshtml"
Write(Html.HiddenFor(model => model.Ukprn));

            
            #line default
            #line hidden
            
            #line 166 "..\..\Views\Vacancy\BasicDetails.cshtml"
                                         
    
            
            #line default
            #line hidden
            
            #line 167 "..\..\Views\Vacancy\BasicDetails.cshtml"
Write(Html.HiddenFor(model => model.ProviderSiteEmployerLink.ProviderSiteErn));

            
            #line default
            #line hidden
            
            #line 167 "..\..\Views\Vacancy\BasicDetails.cshtml"
                                                                            
    
            
            #line default
            #line hidden
            
            #line 168 "..\..\Views\Vacancy\BasicDetails.cshtml"
Write(Html.HiddenFor(model => model.ProviderSiteEmployerLink.Employer.Ern));

            
            #line default
            #line hidden
            
            #line 168 "..\..\Views\Vacancy\BasicDetails.cshtml"
                                                                         ;
    
            
            #line default
            #line hidden
            
            #line 169 "..\..\Views\Vacancy\BasicDetails.cshtml"
Write(Html.HiddenFor(model => model.VacancyGuid));

            
            #line default
            #line hidden
            
            #line 169 "..\..\Views\Vacancy\BasicDetails.cshtml"
                                               


            
            #line default
            #line hidden
WriteLiteral("    <div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(">\r\n        <button");

WriteLiteral(" type=\"submit\"");

WriteLiteral(" class=\"button\"");

WriteLiteral(">Save</button>\r\n    </div>\r\n");

            
            #line 174 "..\..\Views\Vacancy\BasicDetails.cshtml"
}

            
            #line default
            #line hidden
WriteLiteral("\r\n");

DefineSection("scripts", () => {

WriteLiteral("\r\n    <script>\r\n        $(\"#");

            
            #line 179 "..\..\Views\Vacancy\BasicDetails.cshtml"
       Write(Html.NameFor(m => m.StandardId));

            
            #line default
            #line hidden
WriteLiteral("\").change(function () {\r\n            var apprenticeshipLevel = $(\"#");

            
            #line 180 "..\..\Views\Vacancy\BasicDetails.cshtml"
                                     Write(Html.NameFor(m => m.StandardId));

            
            #line default
            #line hidden
WriteLiteral(" option:selected\").attr(\"data-apprenticeship-level\");\r\n            if (apprentice" +
"shipLevel === \"");

            
            #line 181 "..\..\Views\Vacancy\BasicDetails.cshtml"
                                    Write(ApprenticeshipLevel.FoundationDegree.ToString());

            
            #line default
            #line hidden
WriteLiteral("\" || apprenticeshipLevel === \"");

            
            #line 181 "..\..\Views\Vacancy\BasicDetails.cshtml"
                                                                                                                  Write(ApprenticeshipLevel.Masters.ToString());

            
            #line default
            #line hidden
WriteLiteral("\") {\r\n                apprenticeshipLevel = \"");

            
            #line 182 "..\..\Views\Vacancy\BasicDetails.cshtml"
                                  Write(ApprenticeshipLevel.Degree.ToString());

            
            #line default
            #line hidden
WriteLiteral("\";\r\n            }\r\n            $(\"#apprenticeship-level-name\").text(apprenticeshi" +
"pLevel);\r\n        });\r\n    </script>\r\n");

});

WriteLiteral("\r\n");

        }
    }
}
#pragma warning restore 1591