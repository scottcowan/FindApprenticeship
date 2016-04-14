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
    
    #line 2 "..\..\Views\Shared\DisplayTemplates\Vacancy\EmployerDetails.cshtml"
    using System.Web.Mvc.Html;
    
    #line default
    #line hidden
    using System.Web.Optimization;
    using System.Web.Routing;
    using System.Web.Security;
    using System.Web.UI;
    using System.Web.WebPages;
    using SFA.Apprenticeships.Web.Common.Constants;
    using SFA.Apprenticeships.Web.Common.Framework;
    using SFA.Apprenticeships.Web.Common.Models.Common;
    using SFA.Apprenticeships.Web.Raa.Common;
    
    #line 3 "..\..\Views\Shared\DisplayTemplates\Vacancy\EmployerDetails.cshtml"
    using SFA.Apprenticeships.Web.Raa.Common.Extensions;
    
    #line default
    #line hidden
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/Shared/DisplayTemplates/Vacancy/EmployerDetails.cshtml")]
    public partial class EmployerDetails : System.Web.Mvc.WebViewPage<SFA.Apprenticeships.Web.Raa.Common.ViewModels.Provider.VacancyPartyViewModel>
    {
        public EmployerDetails()
        {
        }
        public override void Execute()
        {
WriteLiteral("\r\n<div");

WriteLiteral(" class=\"grid-wrapper\"");

WriteLiteral(">\r\n");

WriteLiteral("    ");

            
            #line 6 "..\..\Views\Shared\DisplayTemplates\Vacancy\EmployerDetails.cshtml"
Write(Html.Partial("ValidationSummary", ViewData.ModelState));

            
            #line default
            #line hidden
WriteLiteral("\r\n\r\n");

WriteLiteral("    ");

            
            #line 8 "..\..\Views\Shared\DisplayTemplates\Vacancy\EmployerDetails.cshtml"
Write(Html.HiddenFor(m => m.ProviderSiteId));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("    ");

            
            #line 9 "..\..\Views\Shared\DisplayTemplates\Vacancy\EmployerDetails.cshtml"
Write(Html.HiddenFor(m => m.Employer.EdsUrn));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("    ");

            
            #line 10 "..\..\Views\Shared\DisplayTemplates\Vacancy\EmployerDetails.cshtml"
Write(Html.HiddenFor(m => m.VacancyGuid));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("    ");

            
            #line 11 "..\..\Views\Shared\DisplayTemplates\Vacancy\EmployerDetails.cshtml"
Write(Html.HiddenFor(m => m.VacancyReferenceNumber));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("    ");

            
            #line 12 "..\..\Views\Shared\DisplayTemplates\Vacancy\EmployerDetails.cshtml"
Write(Html.HiddenFor(m => m.ComeFromPreview));

            
            #line default
            #line hidden
WriteLiteral("\r\n\r\n    <div");

WriteLiteral(" class=\"grid grid-1-2\"");

WriteLiteral(">\r\n        <div");

WriteLiteral(" class=\"inner-block-padr\"");

WriteLiteral(">\r\n            <h3");

WriteLiteral(" class=\"bold-small\"");

WriteLiteral(">Employer</h3>\r\n            <p");

WriteLiteral(" class=\"small-btm-margin\"");

WriteLiteral(">");

            
            #line 17 "..\..\Views\Shared\DisplayTemplates\Vacancy\EmployerDetails.cshtml"
                                   Write(Model.Employer.Name);

            
            #line default
            #line hidden
WriteLiteral("</p>\r\n            <h3");

WriteLiteral(" class=\"bold-small\"");

WriteLiteral(">Address</h3>\r\n            <p");

WriteLiteral(" class=\"small-btm-margin\"");

WriteLiteral(">");

            
            #line 19 "..\..\Views\Shared\DisplayTemplates\Vacancy\EmployerDetails.cshtml"
                                   Write(Model.Employer.Address.AddressLine1);

            
            #line default
            #line hidden
WriteLiteral("</p>\r\n            <p");

WriteLiteral(" class=\"small-btm-margin\"");

WriteLiteral(">");

            
            #line 20 "..\..\Views\Shared\DisplayTemplates\Vacancy\EmployerDetails.cshtml"
                                   Write(Model.Employer.Address.AddressLine2);

            
            #line default
            #line hidden
WriteLiteral("</p>\r\n            <p");

WriteLiteral(" class=\"small-btm-margin\"");

WriteLiteral(">");

            
            #line 21 "..\..\Views\Shared\DisplayTemplates\Vacancy\EmployerDetails.cshtml"
                                   Write(Model.Employer.Address.AddressLine3);

            
            #line default
            #line hidden
WriteLiteral("</p>\r\n            <p");

WriteLiteral(" class=\"small-btm-margin\"");

WriteLiteral(">");

            
            #line 22 "..\..\Views\Shared\DisplayTemplates\Vacancy\EmployerDetails.cshtml"
                                   Write(Model.Employer.Address.AddressLine4);

            
            #line default
            #line hidden
WriteLiteral("</p>\r\n            <p");

WriteLiteral(" class=\"small-btm-margin\"");

WriteLiteral(">");

            
            #line 23 "..\..\Views\Shared\DisplayTemplates\Vacancy\EmployerDetails.cshtml"
                                   Write(Model.Employer.Address.Postcode);

            
            #line default
            #line hidden
WriteLiteral("</p>\r\n        </div>\r\n    </div>\r\n    <div");

WriteLiteral(" class=\"grid grid-1-2 hide-print\"");

WriteLiteral(">\r\n        <div");

WriteLiteral(" class=\"ad-details__map\"");

WriteLiteral(">\r\n            <div");

WriteLiteral(" class=\"map-overlay\"");

WriteLiteral(" onClick=\"style.pointerEvents = \'none\'\"");

WriteLiteral("></div>\r\n            <iframe");

WriteLiteral(" width=\"700\"");

WriteLiteral(" height=\"250\"");

WriteLiteral(" frameborder=\"0\"");

WriteLiteral(" style=\"border: 0\"");

WriteAttribute("src", Tuple.Create(" src=\"", 1406), Tuple.Create("\"", 1549)
, Tuple.Create(Tuple.Create("", 1412), Tuple.Create("https://www.google.com/maps/embed/v1/place?q=", 1412), true)
            
            #line 29 "..\..\Views\Shared\DisplayTemplates\Vacancy\EmployerDetails.cshtml"
                                                 , Tuple.Create(Tuple.Create("", 1457), Tuple.Create<System.Object, System.Int32>(Model.Employer.Address.Postcode
            
            #line default
            #line hidden
, 1457), false)
, Tuple.Create(Tuple.Create("", 1489), Tuple.Create(",+United+Kingdom&key=AIzaSyCusA_0x4bJEjU-_gLOFiXMSBXKZYtvHz8", 1489), true)
);

WriteLiteral("></iframe>\r\n            <p");

WriteLiteral(" class=\"nojs-notice\"");

WriteLiteral(">You must have JavaScript enabled to view a map of the location</p>\r\n        </di" +
"v>\r\n    </div>\r\n\r\n    <div");

WriteLiteral(" class=\"grid grid-1-1\"");

WriteLiteral(">\r\n        <div");

WriteLiteral(" class=\"blocklabel-single-container\"");

WriteLiteral(">\r\n            <div");

WriteLiteral(" class=\"hide-nojs\"");

WriteLiteral(">\r\n                <div");

WriteLiteral(" class=\"form-group inline clearfix blocklabel-single\"");

WriteLiteral(">\r\n                    <a");

WriteAttribute("name", Tuple.Create(" name=\"", 1914), Tuple.Create("\"", 2008)
            
            #line 38 "..\..\Views\Shared\DisplayTemplates\Vacancy\EmployerDetails.cshtml"
, Tuple.Create(Tuple.Create("", 1921), Tuple.Create<System.Object, System.Int32>(Html.NameFor(m => m.IsEmployerLocationMainApprenticeshipLocation).ToString().ToLower()
            
            #line default
            #line hidden
, 1921), false)
);

WriteLiteral("></a>\r\n                    <h4");

WriteLiteral(" class=\"bold-small\"");

WriteLiteral(">Is this address the vacancy location?</h4>\r\n\r\n                    <label");

WriteLiteral(" data-target=\"location-type-main-location-panel\"");

WriteLiteral(" for=\"location-type-main-location\"");

WriteAttribute("class", Tuple.Create(" class=\"", 2213), Tuple.Create("\"", 2285)
, Tuple.Create(Tuple.Create("", 2221), Tuple.Create("block-label", 2221), true)
            
            #line 41 "..\..\Views\Shared\DisplayTemplates\Vacancy\EmployerDetails.cshtml"
                                               , Tuple.Create(Tuple.Create(" ", 2232), Tuple.Create<System.Object, System.Int32>(Model.IsEmployerLocationMainApprenticeshipLocation
            
            #line default
            #line hidden
, 2233), false)
, Tuple.Create(Tuple.Create(" ", 2284), Tuple.Create("", 2284), true)
);

WriteLiteral(">\r\n");

WriteLiteral("                        ");

            
            #line 42 "..\..\Views\Shared\DisplayTemplates\Vacancy\EmployerDetails.cshtml"
                   Write(Html.RadioButtonFor(m => m.IsEmployerLocationMainApprenticeshipLocation, true, new { id = "location-type-main-location", aria_controls = "location-type-main-location-panel" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                        Yes, this will be the vacancy location\r\n               " +
"     </label>\r\n                    <label");

WriteLiteral(" data-target=\"location-type-different-location-panel\"");

WriteLiteral(" for=\"location-type-different-location\"");

WriteAttribute("class", Tuple.Create(" class=\"", 2703), Tuple.Create("\"", 2775)
, Tuple.Create(Tuple.Create("", 2711), Tuple.Create("block-label", 2711), true)
            
            #line 45 "..\..\Views\Shared\DisplayTemplates\Vacancy\EmployerDetails.cshtml"
                                                         , Tuple.Create(Tuple.Create(" ", 2722), Tuple.Create<System.Object, System.Int32>(Model.IsEmployerLocationMainApprenticeshipLocation
            
            #line default
            #line hidden
, 2723), false)
, Tuple.Create(Tuple.Create(" ", 2774), Tuple.Create("", 2774), true)
);

WriteLiteral(">\r\n");

WriteLiteral("                        ");

            
            #line 46 "..\..\Views\Shared\DisplayTemplates\Vacancy\EmployerDetails.cshtml"
                   Write(Html.RadioButtonFor(m => m.IsEmployerLocationMainApprenticeshipLocation, false, new { id = "location-type-different-location", aria_controls = "location-type-different-location-panel" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                        No, I need to add a different location\r\n               " +
"     </label>\r\n                </div>\r\n                <div");

WriteLiteral(" id=\"location-type-main-location-panel\"");

WriteLiteral(" class=\"toggle-content blocklabel-content location\"");

WriteLiteral(">\r\n");

WriteLiteral("                    ");

            
            #line 51 "..\..\Views\Shared\DisplayTemplates\Vacancy\EmployerDetails.cshtml"
               Write(Html.FormTextFor(model => model.NumberOfPositions, controlHtmlAttributes: new { type = "text", @class = "form-control-small", @maxlength = "5", size = 12, id = "NumberOfPositionsJS", Name = "NumberOfPositionsJS" }, labelHtmlAttributes: new { @class = "bold-small" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("                    ");

            
            #line 52 "..\..\Views\Shared\DisplayTemplates\Vacancy\EmployerDetails.cshtml"
               Write(Html.EditorFor(m => m.NumberOfPositionsComment, "Comment", Html.GetLabelFor(m => m.NumberOfPositionsComment)));

            
            #line default
            #line hidden
WriteLiteral("\r\n                </div>\r\n            </div>\r\n        </div>\r\n        <noscript>\r" +
"\n            <div");

WriteLiteral(" class=\"blocklabel-single-container\"");

WriteLiteral(">\r\n                <div");

WriteLiteral(" class=\"form-group inline clearfix blocklabel-single\"");

WriteLiteral(">\r\n                    <a");

WriteAttribute("name", Tuple.Create(" name=\"", 3877), Tuple.Create("\"", 3971)
            
            #line 59 "..\..\Views\Shared\DisplayTemplates\Vacancy\EmployerDetails.cshtml"
, Tuple.Create(Tuple.Create("", 3884), Tuple.Create<System.Object, System.Int32>(Html.NameFor(m => m.IsEmployerLocationMainApprenticeshipLocation).ToString().ToLower()
            
            #line default
            #line hidden
, 3884), false)
);

WriteLiteral("></a>\r\n                    <h4");

WriteLiteral(" class=\"bold-small\"");

WriteLiteral(">Is this address the vacancy location?</h4>\r\n\r\n                    <label");

WriteLiteral(" data-target=\"location-type-main-location-panel\"");

WriteLiteral(" for=\"location-type-main-location\"");

WriteAttribute("class", Tuple.Create(" class=\"", 4176), Tuple.Create("\"", 4248)
, Tuple.Create(Tuple.Create("", 4184), Tuple.Create("block-label", 4184), true)
            
            #line 62 "..\..\Views\Shared\DisplayTemplates\Vacancy\EmployerDetails.cshtml"
                                               , Tuple.Create(Tuple.Create(" ", 4195), Tuple.Create<System.Object, System.Int32>(Model.IsEmployerLocationMainApprenticeshipLocation
            
            #line default
            #line hidden
, 4196), false)
, Tuple.Create(Tuple.Create(" ", 4247), Tuple.Create("", 4247), true)
);

WriteLiteral(">\r\n");

WriteLiteral("                        ");

            
            #line 63 "..\..\Views\Shared\DisplayTemplates\Vacancy\EmployerDetails.cshtml"
                   Write(Html.RadioButtonFor(m => m.IsEmployerLocationMainApprenticeshipLocation, true, new { id = "location-type-main-location", aria_controls = "location-type-main-location-panel" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                        Yes, this will be the vacancy location\r\n               " +
"     </label>\r\n                    <label");

WriteLiteral(" data-target=\"location-type-different-location-panel\"");

WriteLiteral(" for=\"location-type-different-location\"");

WriteAttribute("class", Tuple.Create(" class=\"", 4666), Tuple.Create("\"", 4738)
, Tuple.Create(Tuple.Create("", 4674), Tuple.Create("block-label", 4674), true)
            
            #line 66 "..\..\Views\Shared\DisplayTemplates\Vacancy\EmployerDetails.cshtml"
                                                         , Tuple.Create(Tuple.Create(" ", 4685), Tuple.Create<System.Object, System.Int32>(Model.IsEmployerLocationMainApprenticeshipLocation
            
            #line default
            #line hidden
, 4686), false)
, Tuple.Create(Tuple.Create(" ", 4737), Tuple.Create("", 4737), true)
);

WriteLiteral(">\r\n");

WriteLiteral("                        ");

            
            #line 67 "..\..\Views\Shared\DisplayTemplates\Vacancy\EmployerDetails.cshtml"
                   Write(Html.RadioButtonFor(m => m.IsEmployerLocationMainApprenticeshipLocation, false, new { id = "location-type-different-location", aria_controls = "location-type-different-location-panel" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                        No, I need to add a different location\r\n               " +
"     </label>\r\n                </div>\r\n                <div");

WriteLiteral(" id=\"location-type-main-location-panel\"");

WriteLiteral(" class=\"toggle-content blocklabel-content location\"");

WriteLiteral(">\r\n");

            
            #line 72 "..\..\Views\Shared\DisplayTemplates\Vacancy\EmployerDetails.cshtml"
                    
            
            #line default
            #line hidden
            
            #line 72 "..\..\Views\Shared\DisplayTemplates\Vacancy\EmployerDetails.cshtml"
                      
                        var className = "form-group";
                        if (ViewData.ModelState.Keys.Contains("NumberOfPositions"))
                        {
                            className += " input-validation-error";
                        }
                    
            
            #line default
            #line hidden
WriteLiteral("\r\n                    <div");

WriteAttribute("class", Tuple.Create(" class=\"", 5520), Tuple.Create("\"", 5538)
            
            #line 79 "..\..\Views\Shared\DisplayTemplates\Vacancy\EmployerDetails.cshtml"
, Tuple.Create(Tuple.Create("", 5528), Tuple.Create<System.Object, System.Int32>(className
            
            #line default
            #line hidden
, 5528), false)
);

WriteLiteral(">\r\n                        <h4");

WriteLiteral(" class=\"bold-small\"");

WriteLiteral(">If this is the vacancy location, how many positions will be available?</h4>\r\n   " +
"                     <input");

WriteLiteral(" name=\"NumberOfPositions\"");

WriteLiteral(" class=\"form-control-small form-control\"");

WriteLiteral(" id=\"NumberOfPositions\"");

WriteLiteral(" maxlength=\"5\"");

WriteLiteral(" size=\"12\"");

WriteLiteral(" type=\"text\"");

WriteLiteral("> positions\r\n");

WriteLiteral("                        ");

            
            #line 82 "..\..\Views\Shared\DisplayTemplates\Vacancy\EmployerDetails.cshtml"
                   Write(Html.ValidationMessage("NumberOfPositions"));

            
            #line default
            #line hidden
WriteLiteral("\r\n                    </div>\r\n");

WriteLiteral("                    ");

            
            #line 84 "..\..\Views\Shared\DisplayTemplates\Vacancy\EmployerDetails.cshtml"
               Write(Html.EditorFor(m => m.NumberOfPositionsComment, "Comment", Html.GetLabelFor(m => m.NumberOfPositionsComment)));

            
            #line default
            #line hidden
WriteLiteral("\r\n                </div>\r\n            </div>\r\n        </noscript>\r\n    </div>\r\n\r\n" +
"    <div");

WriteLiteral(" class=\"grid grid-1-1\"");

WriteLiteral(">\r\n");

WriteLiteral("        ");

            
            #line 91 "..\..\Views\Shared\DisplayTemplates\Vacancy\EmployerDetails.cshtml"
   Write(Html.FormTextFor(model => model.EmployerWebsiteUrl, controlHtmlAttributes: new { type = "text", @class = "form-control-1-1" }, labelHtmlAttributes: new { @class = "bold-small" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("        ");

            
            #line 92 "..\..\Views\Shared\DisplayTemplates\Vacancy\EmployerDetails.cshtml"
   Write(Html.EditorFor(m => m.EmployerWebsiteUrlComment, "Comment", Html.GetLabelFor(m => m.EmployerWebsiteUrlComment)));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("        ");

            
            #line 93 "..\..\Views\Shared\DisplayTemplates\Vacancy\EmployerDetails.cshtml"
   Write(Html.FormTextAreaFor(m => m.EmployerDescription, controlHtmlAttributes: new {@class = "width-all-1-1", type = "text", size = 12, style = "height: 200px;"}, labelHtmlAttributes: new {@class = "bold-small"}));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("        ");

            
            #line 94 "..\..\Views\Shared\DisplayTemplates\Vacancy\EmployerDetails.cshtml"
   Write(Html.EditorFor(m => m.EmployerDescriptionComment, "Comment", Html.GetLabelFor(m => m.EmployerDescriptionComment)));

            
            #line default
            #line hidden
WriteLiteral("\r\n    </div>\r\n</div>");

        }
    }
}
#pragma warning restore 1591