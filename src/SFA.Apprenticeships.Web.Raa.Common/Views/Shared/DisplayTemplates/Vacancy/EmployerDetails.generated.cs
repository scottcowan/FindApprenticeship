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
    using SFA.Apprenticeships.Infrastructure.Presentation;
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
    public partial class EmployerDetails : System.Web.Mvc.WebViewPage<SFA.Apprenticeships.Web.Raa.Common.ViewModels.Provider.VacancyOwnerRelationshipViewModel>
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
                                   Write(Model.Employer.FullName);

            
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
                                   Write(Model.Employer.Address.Town);

            
            #line default
            #line hidden
WriteLiteral("</p>\r\n");

            
            #line 23 "..\..\Views\Shared\DisplayTemplates\Vacancy\EmployerDetails.cshtml"
            
            
            #line default
            #line hidden
            
            #line 23 "..\..\Views\Shared\DisplayTemplates\Vacancy\EmployerDetails.cshtml"
             if (Model.Employer.Address.County != "Please Select...")
            {

            
            #line default
            #line hidden
WriteLiteral("                <p");

WriteLiteral(" class=\"small-btm-margin\"");

WriteLiteral(">");

            
            #line 25 "..\..\Views\Shared\DisplayTemplates\Vacancy\EmployerDetails.cshtml"
                                       Write(Model.Employer.Address.County);

            
            #line default
            #line hidden
WriteLiteral("</p>\r\n");

            
            #line 26 "..\..\Views\Shared\DisplayTemplates\Vacancy\EmployerDetails.cshtml"
            }

            
            #line default
            #line hidden
WriteLiteral("            <p");

WriteLiteral(" class=\"small-btm-margin\"");

WriteLiteral(">");

            
            #line 27 "..\..\Views\Shared\DisplayTemplates\Vacancy\EmployerDetails.cshtml"
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

WriteLiteral("></div>\r\n\r\n");

            
            #line 34 "..\..\Views\Shared\DisplayTemplates\Vacancy\EmployerDetails.cshtml"
            
            
            #line default
            #line hidden
            
            #line 34 "..\..\Views\Shared\DisplayTemplates\Vacancy\EmployerDetails.cshtml"
              
                var postcodeForMap = Model.IsEmployerAddressValid ? (Model.Employer.Address.Postcode + ",+") : string.Empty;
            
            
            #line default
            #line hidden
WriteLiteral("\r\n\r\n            <iframe");

WriteLiteral(" width=\"700\"");

WriteLiteral(" height=\"250\"");

WriteLiteral(" frameborder=\"0\"");

WriteLiteral(" style=\"border: 0\"");

WriteAttribute("src", Tuple.Create(" src=\"", 1756), Tuple.Create("\"", 1890)
, Tuple.Create(Tuple.Create("", 1762), Tuple.Create("https://www.google.com/maps/embed/v1/place?q=", 1762), true)
            
            #line 38 "..\..\Views\Shared\DisplayTemplates\Vacancy\EmployerDetails.cshtml"
                                                 , Tuple.Create(Tuple.Create("", 1807), Tuple.Create<System.Object, System.Int32>(Html.Raw(postcodeForMap)
            
            #line default
            #line hidden
, 1807), false)
, Tuple.Create(Tuple.Create("", 1832), Tuple.Create("United+Kingdom&key=AIzaSyCusA_0x4bJEjU-_gLOFiXMSBXKZYtvHz8", 1832), true)
);

WriteLiteral("></iframe>\r\n\r\n            <p");

WriteLiteral(" class=\"nojs-notice\"");

WriteLiteral(">You must have JavaScript enabled to view a map of the location</p>\r\n        </di" +
"v>\r\n    </div>\r\n    <br />\r\n    <br />\r\n    <div");

WriteLiteral(" class=\"grid grid-1-1\"");

WriteLiteral(">\r\n        <div");

WriteLiteral(" class=\"blocklabel-single-container\"");

WriteLiteral(">\r\n            <div");

WriteLiteral(" class=\"hide-nojs\"");

WriteLiteral(">\r\n                <div");

WriteLiteral(" class=\"form-group inline clearfix blocklabel-single\"");

WriteLiteral(">\r\n                    <a");

WriteAttribute("name", Tuple.Create(" name=\"", 2279), Tuple.Create("\"", 2373)
            
            #line 49 "..\..\Views\Shared\DisplayTemplates\Vacancy\EmployerDetails.cshtml"
, Tuple.Create(Tuple.Create("", 2286), Tuple.Create<System.Object, System.Int32>(Html.NameFor(m => m.IsEmployerLocationMainApprenticeshipLocation).ToString().ToLower()
            
            #line default
            #line hidden
, 2286), false)
);

WriteLiteral("></a>\r\n                    <h4");

WriteLiteral(" class=\"bold-small\"");

WriteLiteral(">Is this address the vacancy location?</h4>\r\n");

            
            #line 51 "..\..\Views\Shared\DisplayTemplates\Vacancy\EmployerDetails.cshtml"
                    
            
            #line default
            #line hidden
            
            #line 51 "..\..\Views\Shared\DisplayTemplates\Vacancy\EmployerDetails.cshtml"
                     if (Model.IsEmployerAddressValid)
                    {

            
            #line default
            #line hidden
WriteLiteral("                        <label");

WriteLiteral(" data-target=\"location-type-main-location-panel\"");

WriteLiteral(" for=\"location-type-main-location\"");

WriteAttribute("class", Tuple.Create(" class=\"", 2659), Tuple.Create("\"", 2731)
, Tuple.Create(Tuple.Create("", 2667), Tuple.Create("block-label", 2667), true)
            
            #line 53 "..\..\Views\Shared\DisplayTemplates\Vacancy\EmployerDetails.cshtml"
                                                   , Tuple.Create(Tuple.Create(" ", 2678), Tuple.Create<System.Object, System.Int32>(Model.IsEmployerLocationMainApprenticeshipLocation
            
            #line default
            #line hidden
, 2679), false)
, Tuple.Create(Tuple.Create(" ", 2730), Tuple.Create("", 2730), true)
);

WriteLiteral(">\r\n");

WriteLiteral("                            ");

            
            #line 54 "..\..\Views\Shared\DisplayTemplates\Vacancy\EmployerDetails.cshtml"
                       Write(Html.RadioButtonFor(m => m.IsEmployerLocationMainApprenticeshipLocation, true, new { id = "location-type-main-location", aria_controls = "location-type-main-location-panel" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                            Yes, this will be the vacancy location\r\n           " +
"             </label>\r\n");

WriteLiteral("                        <label");

WriteLiteral(" data-target=\"location-type-different-location-panel\"");

WriteLiteral(" for=\"location-type-different-location\"");

WriteAttribute("class", Tuple.Create(" class=\"", 3165), Tuple.Create("\"", 3237)
, Tuple.Create(Tuple.Create("", 3173), Tuple.Create("block-label", 3173), true)
            
            #line 57 "..\..\Views\Shared\DisplayTemplates\Vacancy\EmployerDetails.cshtml"
                                                             , Tuple.Create(Tuple.Create(" ", 3184), Tuple.Create<System.Object, System.Int32>(Model.IsEmployerLocationMainApprenticeshipLocation
            
            #line default
            #line hidden
, 3185), false)
, Tuple.Create(Tuple.Create(" ", 3236), Tuple.Create("", 3236), true)
);

WriteLiteral(">\r\n");

WriteLiteral("                            ");

            
            #line 58 "..\..\Views\Shared\DisplayTemplates\Vacancy\EmployerDetails.cshtml"
                       Write(Html.RadioButtonFor(m => m.IsEmployerLocationMainApprenticeshipLocation, false, new { id = "location-type-different-location", aria_controls = "location-type-different-location-panel" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                            No, I need to add a different location\r\n           " +
"             </label>\r\n");

WriteLiteral("                        <br />\r\n");

WriteLiteral("                        <br />\r\n");

WriteLiteral("                        <div");

WriteLiteral(" id=\"location-type-main-location-panel\"");

WriteLiteral(" class=\"toggle-content blocklabel-content location\"");

WriteLiteral(">\r\n");

WriteLiteral("                            ");

            
            #line 64 "..\..\Views\Shared\DisplayTemplates\Vacancy\EmployerDetails.cshtml"
                       Write(Html.FormTextFor(model => model.NumberOfPositions, controlHtmlAttributes: new { type = "text", @class = "form-control-small", @maxlength = "5", size = 12, id = "NumberOfPositionsJS", Name = "NumberOfPositionsJS" }, labelHtmlAttributes: new { @class = "bold-small" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("                            ");

            
            #line 65 "..\..\Views\Shared\DisplayTemplates\Vacancy\EmployerDetails.cshtml"
                       Write(Html.EditorFor(m => m.NumberOfPositionsComment, "Comment", Html.GetLabelFor(m => m.NumberOfPositionsComment)));

            
            #line default
            #line hidden
WriteLiteral("\r\n                        </div>\r\n");

WriteLiteral("                        <a");

WriteAttribute("name", Tuple.Create(" name=\"", 4240), Tuple.Create("\"", 4309)
            
            #line 67 "..\..\Views\Shared\DisplayTemplates\Vacancy\EmployerDetails.cshtml"
, Tuple.Create(Tuple.Create("", 4247), Tuple.Create<System.Object, System.Int32>(Html.NameFor(m => m.IsAnonymousEmployer).ToString().ToLower()
            
            #line default
            #line hidden
, 4247), false)
);

WriteLiteral("></a>\r\n");

WriteLiteral("                        <h4");

WriteLiteral(" class=\"bold-small\"");

WriteLiteral(">Will the employer\'s name and address be shown in this vacancy?</h4>\r\n");

WriteLiteral("                        <label");

WriteLiteral(" data-target=\"is-non-anonymous-employer-panel\"");

WriteLiteral(" for=\"is-non-anonymous-employer\"");

WriteAttribute("class", Tuple.Create(" class=\"", 4541), Tuple.Create("\"", 4588)
, Tuple.Create(Tuple.Create("", 4549), Tuple.Create("block-label", 4549), true)
            
            #line 69 "..\..\Views\Shared\DisplayTemplates\Vacancy\EmployerDetails.cshtml"
                                               , Tuple.Create(Tuple.Create(" ", 4560), Tuple.Create<System.Object, System.Int32>(Model.IsAnonymousEmployer
            
            #line default
            #line hidden
, 4561), false)
, Tuple.Create(Tuple.Create(" ", 4587), Tuple.Create("", 4587), true)
);

WriteLiteral(">\r\n");

WriteLiteral("                            ");

            
            #line 70 "..\..\Views\Shared\DisplayTemplates\Vacancy\EmployerDetails.cshtml"
                       Write(Html.RadioButtonFor(m => m.IsAnonymousEmployer, false, new { id = "is-non-anonymous-employer", aria_controls = "is-non-anonymous-employer-panel" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                            Yes\r\n                        </label>\r\n");

WriteLiteral("                        <label");

WriteLiteral(" data-target=\"is-anonymous-employer-panel\"");

WriteLiteral(" for=\"is-anonymous-employer\"");

WriteAttribute("class", Tuple.Create(" class=\"", 4937), Tuple.Create("\"", 4984)
, Tuple.Create(Tuple.Create("", 4945), Tuple.Create("block-label", 4945), true)
            
            #line 73 "..\..\Views\Shared\DisplayTemplates\Vacancy\EmployerDetails.cshtml"
                                       , Tuple.Create(Tuple.Create(" ", 4956), Tuple.Create<System.Object, System.Int32>(Model.IsAnonymousEmployer
            
            #line default
            #line hidden
, 4957), false)
, Tuple.Create(Tuple.Create(" ", 4983), Tuple.Create("", 4983), true)
);

WriteLiteral(">\r\n");

WriteLiteral("                            ");

            
            #line 74 "..\..\Views\Shared\DisplayTemplates\Vacancy\EmployerDetails.cshtml"
                       Write(Html.RadioButtonFor(m => m.IsAnonymousEmployer, true, new { id = "is-anonymous-employer", aria_controls = "is-anonymous-employer-panel" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                            No, the employer wants to remain anonymous\r\n       " +
"                 </label>\r\n");

            
            #line 77 "..\..\Views\Shared\DisplayTemplates\Vacancy\EmployerDetails.cshtml"
                    }
                    else
                    {

            
            #line default
            #line hidden
WriteLiteral("                        <label");

WriteLiteral(" data-target=\"location-type-different-location-panel\"");

WriteLiteral(" for=\"location-type-different-location\"");

WriteAttribute("class", Tuple.Create(" class=\"", 5457), Tuple.Create("\"", 5529)
, Tuple.Create(Tuple.Create("", 5465), Tuple.Create("block-label", 5465), true)
            
            #line 80 "..\..\Views\Shared\DisplayTemplates\Vacancy\EmployerDetails.cshtml"
                                                             , Tuple.Create(Tuple.Create(" ", 5476), Tuple.Create<System.Object, System.Int32>(Model.IsEmployerLocationMainApprenticeshipLocation
            
            #line default
            #line hidden
, 5477), false)
, Tuple.Create(Tuple.Create(" ", 5528), Tuple.Create("", 5528), true)
);

WriteLiteral(">\r\n");

WriteLiteral("                            ");

            
            #line 81 "..\..\Views\Shared\DisplayTemplates\Vacancy\EmployerDetails.cshtml"
                       Write(Html.RadioButtonFor(m => m.IsEmployerLocationMainApprenticeshipLocation, false, new { id = "location-type-different-location", aria_controls = "location-type-different-location-panel" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                            Yes, but I need to complete the full address\r\n     " +
"                   </label>\r\n");

            
            #line 84 "..\..\Views\Shared\DisplayTemplates\Vacancy\EmployerDetails.cshtml"
                    }

            
            #line default
            #line hidden
WriteLiteral("                </div>\r\n            </div>\r\n        </div>\r\n        <noscript>\r\n " +
"           <div");

WriteLiteral(" class=\"blocklabel-single-container\"");

WriteLiteral(">\r\n                <div");

WriteLiteral(" class=\"form-group inline clearfix blocklabel-single\"");

WriteLiteral(">\r\n                    <a");

WriteAttribute("name", Tuple.Create(" name=\"", 6114), Tuple.Create("\"", 6208)
            
            #line 91 "..\..\Views\Shared\DisplayTemplates\Vacancy\EmployerDetails.cshtml"
, Tuple.Create(Tuple.Create("", 6121), Tuple.Create<System.Object, System.Int32>(Html.NameFor(m => m.IsEmployerLocationMainApprenticeshipLocation).ToString().ToLower()
            
            #line default
            #line hidden
, 6121), false)
);

WriteLiteral("></a>\r\n                    <h4");

WriteLiteral(" class=\"bold-small\"");

WriteLiteral(">Is this address the vacancy location?</h4>\r\n\r\n                    <label");

WriteLiteral(" data-target=\"location-type-main-location-panel\"");

WriteLiteral(" for=\"location-type-main-location\"");

WriteAttribute("class", Tuple.Create(" class=\"", 6413), Tuple.Create("\"", 6485)
, Tuple.Create(Tuple.Create("", 6421), Tuple.Create("block-label", 6421), true)
            
            #line 94 "..\..\Views\Shared\DisplayTemplates\Vacancy\EmployerDetails.cshtml"
                                               , Tuple.Create(Tuple.Create(" ", 6432), Tuple.Create<System.Object, System.Int32>(Model.IsEmployerLocationMainApprenticeshipLocation
            
            #line default
            #line hidden
, 6433), false)
, Tuple.Create(Tuple.Create(" ", 6484), Tuple.Create("", 6484), true)
);

WriteLiteral(">\r\n");

WriteLiteral("                        ");

            
            #line 95 "..\..\Views\Shared\DisplayTemplates\Vacancy\EmployerDetails.cshtml"
                   Write(Html.RadioButtonFor(m => m.IsEmployerLocationMainApprenticeshipLocation, true, new { id = "location-type-main-location", aria_controls = "location-type-main-location-panel" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                        Yes, this will be the vacancy location\r\n               " +
"     </label>\r\n                    <label");

WriteLiteral(" data-target=\"location-type-different-location-panel\"");

WriteLiteral(" for=\"location-type-different-location\"");

WriteAttribute("class", Tuple.Create(" class=\"", 6903), Tuple.Create("\"", 6975)
, Tuple.Create(Tuple.Create("", 6911), Tuple.Create("block-label", 6911), true)
            
            #line 98 "..\..\Views\Shared\DisplayTemplates\Vacancy\EmployerDetails.cshtml"
                                                         , Tuple.Create(Tuple.Create(" ", 6922), Tuple.Create<System.Object, System.Int32>(Model.IsEmployerLocationMainApprenticeshipLocation
            
            #line default
            #line hidden
, 6923), false)
, Tuple.Create(Tuple.Create(" ", 6974), Tuple.Create("", 6974), true)
);

WriteLiteral(">\r\n");

WriteLiteral("                        ");

            
            #line 99 "..\..\Views\Shared\DisplayTemplates\Vacancy\EmployerDetails.cshtml"
                   Write(Html.RadioButtonFor(m => m.IsEmployerLocationMainApprenticeshipLocation, false, new { id = "location-type-different-location", aria_controls = "location-type-different-location-panel" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                        No, I need to add a different location\r\n               " +
"     </label>\r\n                </div>\r\n                <div");

WriteLiteral(" class=\"form-group inline clearfix blocklabel-single\"");

WriteLiteral(">\r\n                    <a");

WriteAttribute("name", Tuple.Create(" name=\"", 7408), Tuple.Create("\"", 7477)
            
            #line 104 "..\..\Views\Shared\DisplayTemplates\Vacancy\EmployerDetails.cshtml"
, Tuple.Create(Tuple.Create("", 7415), Tuple.Create<System.Object, System.Int32>(Html.NameFor(m => m.IsAnonymousEmployer).ToString().ToLower()
            
            #line default
            #line hidden
, 7415), false)
);

WriteLiteral("></a>\r\n                    <h4");

WriteLiteral(" class=\"bold-small\"");

WriteLiteral(">Will the employer\'s name and address be shown in this vacancy?</h4>\r\n\r\n         " +
"           <label");

WriteLiteral(" data-target=\"is-anonymous-employer\"");

WriteLiteral(" for=\"is-anonymous-employer\"");

WriteAttribute("class", Tuple.Create(" class=\"", 7689), Tuple.Create("\"", 7736)
, Tuple.Create(Tuple.Create("", 7697), Tuple.Create("block-label", 7697), true)
            
            #line 107 "..\..\Views\Shared\DisplayTemplates\Vacancy\EmployerDetails.cshtml"
                             , Tuple.Create(Tuple.Create(" ", 7708), Tuple.Create<System.Object, System.Int32>(Model.IsAnonymousEmployer
            
            #line default
            #line hidden
, 7709), false)
, Tuple.Create(Tuple.Create(" ", 7735), Tuple.Create("", 7735), true)
);

WriteLiteral(">\r\n");

WriteLiteral("                        ");

            
            #line 108 "..\..\Views\Shared\DisplayTemplates\Vacancy\EmployerDetails.cshtml"
                   Write(Html.RadioButtonFor(m => m.IsAnonymousEmployer, false, new { id = "anonymous-employer", aria_controls = "anonymous-employer" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                        Yes\r\n                    </label>\r\n                    " +
"<label");

WriteLiteral(" data-target=\"is-non-anonymous-employer\"");

WriteLiteral(" for=\"is-non-anonymous-employer\"");

WriteAttribute("class", Tuple.Create(" class=\"", 8051), Tuple.Create("\"", 8098)
, Tuple.Create(Tuple.Create("", 8059), Tuple.Create("block-label", 8059), true)
            
            #line 111 "..\..\Views\Shared\DisplayTemplates\Vacancy\EmployerDetails.cshtml"
                                     , Tuple.Create(Tuple.Create(" ", 8070), Tuple.Create<System.Object, System.Int32>(Model.IsAnonymousEmployer
            
            #line default
            #line hidden
, 8071), false)
, Tuple.Create(Tuple.Create(" ", 8097), Tuple.Create("", 8097), true)
);

WriteLiteral(">\r\n");

WriteLiteral("                        ");

            
            #line 112 "..\..\Views\Shared\DisplayTemplates\Vacancy\EmployerDetails.cshtml"
                   Write(Html.RadioButtonFor(m => m.IsAnonymousEmployer, true, new { id = "non-anonymous-employer", aria_controls = "non-anonymous-employer" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                        No, the employer wants to remain anonymous\r\n           " +
"         </label>\r\n                </div>\r\n                <div");

WriteLiteral(" id=\"location-type-main-location-panel\"");

WriteLiteral(" class=\"toggle-content blocklabel-content location\"");

WriteLiteral(">\r\n");

            
            #line 117 "..\..\Views\Shared\DisplayTemplates\Vacancy\EmployerDetails.cshtml"
                    
            
            #line default
            #line hidden
            
            #line 117 "..\..\Views\Shared\DisplayTemplates\Vacancy\EmployerDetails.cshtml"
                      
                        var className = "form-group";
                        if (ViewData.ModelState.Keys.Contains("NumberOfPositions"))
                        {
                            className += " input-validation-error";
                        }
                    
            
            #line default
            #line hidden
WriteLiteral("\r\n                    <div");

WriteAttribute("class", Tuple.Create(" class=\"", 8832), Tuple.Create("\"", 8850)
            
            #line 124 "..\..\Views\Shared\DisplayTemplates\Vacancy\EmployerDetails.cshtml"
, Tuple.Create(Tuple.Create("", 8840), Tuple.Create<System.Object, System.Int32>(className
            
            #line default
            #line hidden
, 8840), false)
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

            
            #line 127 "..\..\Views\Shared\DisplayTemplates\Vacancy\EmployerDetails.cshtml"
                   Write(Html.ValidationMessage("NumberOfPositions"));

            
            #line default
            #line hidden
WriteLiteral("\r\n                    </div>\r\n");

WriteLiteral("                    ");

            
            #line 129 "..\..\Views\Shared\DisplayTemplates\Vacancy\EmployerDetails.cshtml"
               Write(Html.EditorFor(m => m.NumberOfPositionsComment, "Comment", Html.GetLabelFor(m => m.NumberOfPositionsComment)));

            
            #line default
            #line hidden
WriteLiteral("\r\n                </div>\r\n            </div>\r\n        </noscript>\r\n    </div>\r\n\r\n" +
"    <div");

WriteLiteral(" id=\"is-non-anonymous-employer-panel\"");

WriteLiteral(" class=\"toggle-content blocklabel-content non-anonymous\"");

WriteLiteral(">\r\n        <div");

WriteLiteral(" class=\"grid grid-1-1\"");

WriteLiteral(">\r\n");

WriteLiteral("            ");

            
            #line 137 "..\..\Views\Shared\DisplayTemplates\Vacancy\EmployerDetails.cshtml"
       Write(Html.FormTextFor(model => model.EmployerWebsiteUrl, controlHtmlAttributes: new { type = "text", @class = "form-control-1-1"}, labelHtmlAttributes: new { @class = "bold-small" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("            ");

            
            #line 138 "..\..\Views\Shared\DisplayTemplates\Vacancy\EmployerDetails.cshtml"
       Write(Html.EditorFor(m => m.EmployerWebsiteUrlComment, "Comment", Html.GetLabelFor(m => m.EmployerWebsiteUrlComment)));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("            ");

            
            #line 139 "..\..\Views\Shared\DisplayTemplates\Vacancy\EmployerDetails.cshtml"
       Write(Html.FormTextAreaFor(m => m.EmployerDescription, controlHtmlAttributes: new { @class = "width-all-1-1", type = "text", size = 12, style = "height: 200px;"}, labelHtmlAttributes: new { @class = "bold-small" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("            ");

            
            #line 140 "..\..\Views\Shared\DisplayTemplates\Vacancy\EmployerDetails.cshtml"
       Write(Html.EditorFor(m => m.EmployerDescriptionComment, "Comment", Html.GetLabelFor(m => m.EmployerDescriptionComment)));

            
            #line default
            #line hidden
WriteLiteral("\r\n        </div>\r\n    </div>\r\n    <div");

WriteLiteral(" id=\"is-anonymous-employer-panel\"");

WriteLiteral(" class=\"toggle-content blocklabel-content anonymous\"");

WriteLiteral(">\r\n        <div");

WriteLiteral(" class=\"grid grid-1-1\"");

WriteLiteral(">\r\n            <div");

WriteLiteral(" class=\"hgroup-medium\"");

WriteLiteral(">\r\n                <p");

WriteLiteral(" class=\"subtitle font-small\"");

WriteLiteral(@">A brief description of the employer will be needed to replace their name. For example, car manufacturer or clothing retailer. The employer's address will not be visible to candidates. Only the employer's town or city will be shown.</p>
            </div>
");

WriteLiteral("            ");

            
            #line 148 "..\..\Views\Shared\DisplayTemplates\Vacancy\EmployerDetails.cshtml"
       Write(Html.FormTextAreaFor(model => model.AnonymousEmployerDescription, controlHtmlAttributes: new { type = "text", @class = "form-control-1-1", data_val_length_max = "40",rows=1 }, labelHtmlAttributes: new { @class = "bold-small" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("            ");

            
            #line 149 "..\..\Views\Shared\DisplayTemplates\Vacancy\EmployerDetails.cshtml"
       Write(Html.EditorFor(m => m.AnonymousEmployerDescriptionComment, "Comment", Html.GetLabelFor(m => m.AnonymousEmployerDescriptionComment)));

            
            #line default
            #line hidden
WriteLiteral("            \r\n");

WriteLiteral("            ");

            
            #line 150 "..\..\Views\Shared\DisplayTemplates\Vacancy\EmployerDetails.cshtml"
       Write(Html.FormTextAreaFor(m => m.AnonymousEmployerReason, controlHtmlAttributes: new { @class = "width-all-1-1", type = "text", size = 12, style = "height: 200px;", data_val_length_max = "240" }, labelHtmlAttributes: new { @class = "bold-small" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("            ");

            
            #line 151 "..\..\Views\Shared\DisplayTemplates\Vacancy\EmployerDetails.cshtml"
       Write(Html.EditorFor(m => m.AnonymousEmployerReasonComment, "Comment", Html.GetLabelFor(m => m.AnonymousEmployerReasonComment)));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("            ");

            
            #line 152 "..\..\Views\Shared\DisplayTemplates\Vacancy\EmployerDetails.cshtml"
       Write(Html.FormTextAreaFor(m => m.AnonymousAboutTheEmployerDescription, controlHtmlAttributes: new { @class = "width-all-1-1", type = "text", size = 12, style = "height: 200px;"}, labelHtmlAttributes: new { @class = "bold-small" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("            ");

            
            #line 153 "..\..\Views\Shared\DisplayTemplates\Vacancy\EmployerDetails.cshtml"
       Write(Html.EditorFor(m => m.AnonymousAboutTheEmployerDescriptionComment, "Comment", Html.GetLabelFor(m => m.AnonymousAboutTheEmployerDescriptionComment)));

            
            #line default
            #line hidden
WriteLiteral("\r\n        </div>\r\n    </div>\r\n</div>");

        }
    }
}
#pragma warning restore 1591
