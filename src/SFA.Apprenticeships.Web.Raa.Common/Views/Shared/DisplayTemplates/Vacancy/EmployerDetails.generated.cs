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
    
    #line 3 "..\..\Views\Shared\DisplayTemplates\Vacancy\EmployerDetails.cshtml"
    using SFA.Apprenticeships.Domain.Entities.Raa.Vacancies;
    
    #line default
    #line hidden
    using SFA.Apprenticeships.Infrastructure.Presentation;
    using SFA.Apprenticeships.Web.Common.Constants;
    using SFA.Apprenticeships.Web.Common.Framework;
    using SFA.Apprenticeships.Web.Common.Models.Common;
    using SFA.Apprenticeships.Web.Raa.Common;
    
    #line 4 "..\..\Views\Shared\DisplayTemplates\Vacancy\EmployerDetails.cshtml"
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

            
            #line 7 "..\..\Views\Shared\DisplayTemplates\Vacancy\EmployerDetails.cshtml"
Write(Html.Partial("ValidationSummary", ViewData.ModelState));

            
            #line default
            #line hidden
WriteLiteral("\r\n\r\n");

WriteLiteral("    ");

            
            #line 9 "..\..\Views\Shared\DisplayTemplates\Vacancy\EmployerDetails.cshtml"
Write(Html.HiddenFor(m => m.ProviderSiteId));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("    ");

            
            #line 10 "..\..\Views\Shared\DisplayTemplates\Vacancy\EmployerDetails.cshtml"
Write(Html.HiddenFor(m => m.Employer.EdsUrn));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("    ");

            
            #line 11 "..\..\Views\Shared\DisplayTemplates\Vacancy\EmployerDetails.cshtml"
Write(Html.HiddenFor(m => m.VacancyGuid));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("    ");

            
            #line 12 "..\..\Views\Shared\DisplayTemplates\Vacancy\EmployerDetails.cshtml"
Write(Html.HiddenFor(m => m.VacancyReferenceNumber));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("    ");

            
            #line 13 "..\..\Views\Shared\DisplayTemplates\Vacancy\EmployerDetails.cshtml"
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

            
            #line 18 "..\..\Views\Shared\DisplayTemplates\Vacancy\EmployerDetails.cshtml"
                                   Write(Model.Employer.FullName);

            
            #line default
            #line hidden
WriteLiteral("</p>\r\n            <h3");

WriteLiteral(" class=\"bold-small\"");

WriteLiteral(">Address</h3>\r\n            <p");

WriteLiteral(" class=\"small-btm-margin\"");

WriteLiteral(">");

            
            #line 20 "..\..\Views\Shared\DisplayTemplates\Vacancy\EmployerDetails.cshtml"
                                   Write(Model.Employer.Address.AddressLine1);

            
            #line default
            #line hidden
WriteLiteral("</p>\r\n            <p");

WriteLiteral(" class=\"small-btm-margin\"");

WriteLiteral(">");

            
            #line 21 "..\..\Views\Shared\DisplayTemplates\Vacancy\EmployerDetails.cshtml"
                                   Write(Model.Employer.Address.AddressLine2);

            
            #line default
            #line hidden
WriteLiteral("</p>\r\n            <p");

WriteLiteral(" class=\"small-btm-margin\"");

WriteLiteral(">");

            
            #line 22 "..\..\Views\Shared\DisplayTemplates\Vacancy\EmployerDetails.cshtml"
                                   Write(Model.Employer.Address.AddressLine3);

            
            #line default
            #line hidden
WriteLiteral("</p>\r\n            <p");

WriteLiteral(" class=\"small-btm-margin\"");

WriteLiteral(">");

            
            #line 23 "..\..\Views\Shared\DisplayTemplates\Vacancy\EmployerDetails.cshtml"
                                   Write(Model.Employer.Address.Town);

            
            #line default
            #line hidden
WriteLiteral("</p>\r\n");

            
            #line 24 "..\..\Views\Shared\DisplayTemplates\Vacancy\EmployerDetails.cshtml"
            
            
            #line default
            #line hidden
            
            #line 24 "..\..\Views\Shared\DisplayTemplates\Vacancy\EmployerDetails.cshtml"
             if (Model.Employer.Address.County != "Please Select...")
            {

            
            #line default
            #line hidden
WriteLiteral("                <p");

WriteLiteral(" class=\"small-btm-margin\"");

WriteLiteral(">");

            
            #line 26 "..\..\Views\Shared\DisplayTemplates\Vacancy\EmployerDetails.cshtml"
                                       Write(Model.Employer.Address.County);

            
            #line default
            #line hidden
WriteLiteral("</p>\r\n");

            
            #line 27 "..\..\Views\Shared\DisplayTemplates\Vacancy\EmployerDetails.cshtml"
            }

            
            #line default
            #line hidden
WriteLiteral("            <p");

WriteLiteral(" class=\"small-btm-margin\"");

WriteLiteral(">");

            
            #line 28 "..\..\Views\Shared\DisplayTemplates\Vacancy\EmployerDetails.cshtml"
                                   Write(Model.Employer.Address.Postcode);

            
            #line default
            #line hidden
WriteLiteral("</p>\r\n        </div>\r\n    </div>\r\n    <br />\r\n    <br />\r\n    <div");

WriteLiteral(" class=\"grid grid-1-2 hide-print\"");

WriteLiteral(">\r\n        <div");

WriteLiteral(" class=\"ad-details__map\"");

WriteLiteral(">\r\n            <div");

WriteLiteral(" class=\"map-overlay\"");

WriteLiteral(" onClick=\"style.pointerEvents = \'none\'\"");

WriteLiteral("></div>\r\n\r\n");

            
            #line 37 "..\..\Views\Shared\DisplayTemplates\Vacancy\EmployerDetails.cshtml"
            
            
            #line default
            #line hidden
            
            #line 37 "..\..\Views\Shared\DisplayTemplates\Vacancy\EmployerDetails.cshtml"
              
                var postcodeForMap = Model.IsEmployerAddressValid ? (Model.Employer.Address.Postcode + ",+") : string.Empty;
            
            
            #line default
            #line hidden
WriteLiteral("\r\n\r\n            <iframe");

WriteLiteral(" width=\"700\"");

WriteLiteral(" height=\"250\"");

WriteLiteral(" frameborder=\"0\"");

WriteLiteral(" style=\"border: 0\"");

WriteAttribute("src", Tuple.Create(" src=\"", 1838), Tuple.Create("\"", 1972)
, Tuple.Create(Tuple.Create("", 1844), Tuple.Create("https://www.google.com/maps/embed/v1/place?q=", 1844), true)
            
            #line 41 "..\..\Views\Shared\DisplayTemplates\Vacancy\EmployerDetails.cshtml"
                                                 , Tuple.Create(Tuple.Create("", 1889), Tuple.Create<System.Object, System.Int32>(Html.Raw(postcodeForMap)
            
            #line default
            #line hidden
, 1889), false)
, Tuple.Create(Tuple.Create("", 1914), Tuple.Create("United+Kingdom&key=AIzaSyCusA_0x4bJEjU-_gLOFiXMSBXKZYtvHz8", 1914), true)
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

WriteAttribute("name", Tuple.Create(" name=\"", 2361), Tuple.Create("\"", 2441)
            
            #line 52 "..\..\Views\Shared\DisplayTemplates\Vacancy\EmployerDetails.cshtml"
, Tuple.Create(Tuple.Create("", 2368), Tuple.Create<System.Object, System.Int32>(Html.NameFor(m => m.EmployerApprenticeshipLocation).ToString().ToLower()
            
            #line default
            #line hidden
, 2368), false)
);

WriteLiteral("></a>\r\n                    <h4");

WriteLiteral(" class=\"bold-small\"");

WriteLiteral(">Vacancy location options</h4>\r\n");

            
            #line 54 "..\..\Views\Shared\DisplayTemplates\Vacancy\EmployerDetails.cshtml"
                    
            
            #line default
            #line hidden
            
            #line 54 "..\..\Views\Shared\DisplayTemplates\Vacancy\EmployerDetails.cshtml"
                     if (Model.IsEmployerAddressValid)
                    {

            
            #line default
            #line hidden
WriteLiteral("                        <label");

WriteLiteral(" data-target=\"location-type-main-location-panel\"");

WriteLiteral(" for=\"location-type-main-location\"");

WriteAttribute("class", Tuple.Create(" class=\"", 2714), Tuple.Create("\"", 2772)
, Tuple.Create(Tuple.Create("", 2722), Tuple.Create("block-label", 2722), true)
            
            #line 56 "..\..\Views\Shared\DisplayTemplates\Vacancy\EmployerDetails.cshtml"
                                                   , Tuple.Create(Tuple.Create(" ", 2733), Tuple.Create<System.Object, System.Int32>(Model.EmployerApprenticeshipLocation
            
            #line default
            #line hidden
, 2734), false)
, Tuple.Create(Tuple.Create(" ", 2771), Tuple.Create("", 2771), true)
);

WriteLiteral(">\r\n");

WriteLiteral("                            ");

            
            #line 57 "..\..\Views\Shared\DisplayTemplates\Vacancy\EmployerDetails.cshtml"
                       Write(Html.RadioButtonFor(m => m.EmployerApprenticeshipLocation, VacancyLocationOption.Main , new { id = "location-type-main-location", aria_controls = "location-type-main-location-panel" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                            Use the main employer address\r\n                    " +
"    </label>\r\n");

WriteLiteral("                        <br />\r\n");

WriteLiteral("                        <div");

WriteLiteral(" id=\"location-type-main-location-panel\"");

WriteLiteral(" class=\"toggle-content blocklabel-content location left-grey-border\"");

WriteLiteral(">\r\n");

WriteLiteral("                            ");

            
            #line 62 "..\..\Views\Shared\DisplayTemplates\Vacancy\EmployerDetails.cshtml"
                       Write(Html.FormTextFor(model => model.NumberOfPositions, controlHtmlAttributes: new { type = "text", @class = "form-control-small", @maxlength = "5", size = 12, id = "NumberOfPositionsJS", Name = "NumberOfPositionsJS" }, labelHtmlAttributes: new { @class = "bold-small" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("                            ");

            
            #line 63 "..\..\Views\Shared\DisplayTemplates\Vacancy\EmployerDetails.cshtml"
                       Write(Html.EditorFor(m => m.NumberOfPositionsComment, "Comment", Html.GetLabelFor(m => m.NumberOfPositionsComment)));

            
            #line default
            #line hidden
WriteLiteral("                            \r\n                        </div>                     " +
"   \r\n");

WriteLiteral("                        <label");

WriteLiteral(" data-target=\"location-type-different-location-panel\"");

WriteLiteral(" for=\"location-type-different-location\"");

WriteAttribute("class", Tuple.Create(" class=\"", 3897), Tuple.Create("\"", 3955)
, Tuple.Create(Tuple.Create("", 3905), Tuple.Create("block-label", 3905), true)
            
            #line 65 "..\..\Views\Shared\DisplayTemplates\Vacancy\EmployerDetails.cshtml"
                                                             , Tuple.Create(Tuple.Create(" ", 3916), Tuple.Create<System.Object, System.Int32>(Model.EmployerApprenticeshipLocation
            
            #line default
            #line hidden
, 3917), false)
, Tuple.Create(Tuple.Create(" ", 3954), Tuple.Create("", 3954), true)
);

WriteLiteral(">\r\n");

WriteLiteral("                            ");

            
            #line 66 "..\..\Views\Shared\DisplayTemplates\Vacancy\EmployerDetails.cshtml"
                       Write(Html.RadioButtonFor(m => m.EmployerApprenticeshipLocation, VacancyLocationOption.Different , new { id = "location-type-different-location", aria_controls = "location-type-different-location-panel" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                            Add different location(s)\r\n                        " +
"</label>\r\n");

WriteLiteral("                        <br />\r\n");

WriteLiteral("                        <label");

WriteLiteral(" data-target=\"location-nation-wide-vacancy-panel\"");

WriteLiteral(" for=\"location-nation-wide-vacancy\"");

WriteAttribute("class", Tuple.Create(" class=\"", 4424), Tuple.Create("\"", 4482)
, Tuple.Create(Tuple.Create("", 4432), Tuple.Create("block-label", 4432), true)
            
            #line 70 "..\..\Views\Shared\DisplayTemplates\Vacancy\EmployerDetails.cshtml"
                                                     , Tuple.Create(Tuple.Create(" ", 4443), Tuple.Create<System.Object, System.Int32>(Model.EmployerApprenticeshipLocation
            
            #line default
            #line hidden
, 4444), false)
, Tuple.Create(Tuple.Create(" ", 4481), Tuple.Create("", 4481), true)
);

WriteLiteral(">\r\n");

WriteLiteral("                            ");

            
            #line 71 "..\..\Views\Shared\DisplayTemplates\Vacancy\EmployerDetails.cshtml"
                       Write(Html.RadioButtonFor(m => m.EmployerApprenticeshipLocation, VacancyLocationOption.NationWide , new { id = "location-nation-wide-vacancy", aria_controls = "location-nation-wide-vacancy-panel" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                            Set as a nationwide vacancy\r\n                      " +
"  </label>\r\n");

WriteLiteral("                        <div");

WriteLiteral(" id=\"location-nation-wide-vacancy-panel\"");

WriteLiteral(" class=\"toggle-content blocklabel-content nationwide left-grey-border\"");

WriteLiteral(">\r\n");

WriteLiteral("                            ");

            
            #line 75 "..\..\Views\Shared\DisplayTemplates\Vacancy\EmployerDetails.cshtml"
                       Write(Html.FormTextFor(model => model.NumberOfPositionsForNationWide, controlHtmlAttributes: new { type = "text", @class = "form-control-small", @maxlength = "5", size = 12, id = "NumberOfPositionsJS", Name = "NumberOfPositionsJS" }, labelHtmlAttributes: new { @class = "bold-small" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("                            ");

            
            #line 76 "..\..\Views\Shared\DisplayTemplates\Vacancy\EmployerDetails.cshtml"
                       Write(Html.EditorFor(m => m.NumberOfPositionsForNationWideComment, "Comment", Html.GetLabelFor(m => m.NumberOfPositionsForNationWideComment)));

            
            #line default
            #line hidden
WriteLiteral("\r\n                        </div>\r\n");

            
            #line 78 "..\..\Views\Shared\DisplayTemplates\Vacancy\EmployerDetails.cshtml"
                    }
                    else
                    {

            
            #line default
            #line hidden
WriteLiteral("                        <label");

WriteLiteral(" data-target=\"location-type-different-location-panel\"");

WriteLiteral(" for=\"location-type-different-location\"");

WriteAttribute("class", Tuple.Create(" class=\"", 5643), Tuple.Create("\"", 5701)
, Tuple.Create(Tuple.Create("", 5651), Tuple.Create("block-label", 5651), true)
            
            #line 81 "..\..\Views\Shared\DisplayTemplates\Vacancy\EmployerDetails.cshtml"
                                                             , Tuple.Create(Tuple.Create(" ", 5662), Tuple.Create<System.Object, System.Int32>(Model.EmployerApprenticeshipLocation
            
            #line default
            #line hidden
, 5663), false)
, Tuple.Create(Tuple.Create(" ", 5700), Tuple.Create("", 5700), true)
);

WriteLiteral(">\r\n");

WriteLiteral("                            ");

            
            #line 82 "..\..\Views\Shared\DisplayTemplates\Vacancy\EmployerDetails.cshtml"
                       Write(Html.RadioButtonFor(m => m.EmployerApprenticeshipLocation, false, new { id = "location-type-different-location", aria_controls = "location-type-different-location-panel" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                            Yes, but I need to complete the full address\r\n     " +
"                   </label>\r\n");

            
            #line 85 "..\..\Views\Shared\DisplayTemplates\Vacancy\EmployerDetails.cshtml"
                    }

            
            #line default
            #line hidden
WriteLiteral("                </div>\r\n            </div>\r\n        </div>\r\n\r\n        <div");

WriteLiteral(" class=\"blocklabel-single-container\"");

WriteLiteral(">\r\n            <div");

WriteLiteral(" class=\"hide-nojs\"");

WriteLiteral(">\r\n                <div");

WriteLiteral(" class=\"form-group inline clearfix blocklabel-single\"");

WriteLiteral(">\r\n                    <a");

WriteAttribute("name", Tuple.Create(" name=\"", 6287), Tuple.Create("\"", 6356)
            
            #line 93 "..\..\Views\Shared\DisplayTemplates\Vacancy\EmployerDetails.cshtml"
, Tuple.Create(Tuple.Create("", 6294), Tuple.Create<System.Object, System.Int32>(Html.NameFor(m => m.IsAnonymousEmployer).ToString().ToLower()
            
            #line default
            #line hidden
, 6294), false)
);

WriteLiteral("></a>\r\n                    <h4");

WriteLiteral(" class=\"bold-small\"");

WriteLiteral(">Will the employer\'s name and address be shown in this vacancy?</h4>\r\n           " +
"         <label");

WriteLiteral(" data-target=\"is-non-anonymous-employer-panel\"");

WriteLiteral(" for=\"is-non-anonymous-employer\"");

WriteAttribute("class", Tuple.Create(" class=\"", 6580), Tuple.Create("\"", 6627)
, Tuple.Create(Tuple.Create("", 6588), Tuple.Create("block-label", 6588), true)
            
            #line 95 "..\..\Views\Shared\DisplayTemplates\Vacancy\EmployerDetails.cshtml"
                                           , Tuple.Create(Tuple.Create(" ", 6599), Tuple.Create<System.Object, System.Int32>(Model.IsAnonymousEmployer
            
            #line default
            #line hidden
, 6600), false)
, Tuple.Create(Tuple.Create(" ", 6626), Tuple.Create("", 6626), true)
);

WriteLiteral(">\r\n");

WriteLiteral("                        ");

            
            #line 96 "..\..\Views\Shared\DisplayTemplates\Vacancy\EmployerDetails.cshtml"
                   Write(Html.RadioButtonFor(m => m.IsAnonymousEmployer, false, new { id = "is-non-anonymous-employer", aria_controls = "is-non-anonymous-employer-panel" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                        Yes\r\n                    </label>\r\n                    " +
"<label");

WriteLiteral(" data-target=\"is-anonymous-employer-panel\"");

WriteLiteral(" for=\"is-anonymous-employer\"");

WriteAttribute("class", Tuple.Create(" class=\"", 6960), Tuple.Create("\"", 7007)
, Tuple.Create(Tuple.Create("", 6968), Tuple.Create("block-label", 6968), true)
            
            #line 99 "..\..\Views\Shared\DisplayTemplates\Vacancy\EmployerDetails.cshtml"
                                   , Tuple.Create(Tuple.Create(" ", 6979), Tuple.Create<System.Object, System.Int32>(Model.IsAnonymousEmployer
            
            #line default
            #line hidden
, 6980), false)
, Tuple.Create(Tuple.Create(" ", 7006), Tuple.Create("", 7006), true)
);

WriteLiteral(">\r\n");

WriteLiteral("                        ");

            
            #line 100 "..\..\Views\Shared\DisplayTemplates\Vacancy\EmployerDetails.cshtml"
                   Write(Html.RadioButtonFor(m => m.IsAnonymousEmployer, true, new { id = "is-anonymous-employer", aria_controls = "is-anonymous-employer-panel" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                        No, the employer wants to remain anonymous\r\n           " +
"         </label>\r\n                </div>\r\n            </div>\r\n        </div>\r\n\r" +
"\n        <noscript>\r\n            <div");

WriteLiteral(" class=\"blocklabel-single-container\"");

WriteLiteral(">\r\n                <div");

WriteLiteral(" class=\"form-group inline clearfix blocklabel-single\"");

WriteLiteral(">\r\n                    <a");

WriteAttribute("name", Tuple.Create(" name=\"", 7509), Tuple.Create("\"", 7589)
            
            #line 110 "..\..\Views\Shared\DisplayTemplates\Vacancy\EmployerDetails.cshtml"
, Tuple.Create(Tuple.Create("", 7516), Tuple.Create<System.Object, System.Int32>(Html.NameFor(m => m.EmployerApprenticeshipLocation).ToString().ToLower()
            
            #line default
            #line hidden
, 7516), false)
);

WriteLiteral("></a>\r\n                    <h4");

WriteLiteral(" class=\"bold-small\"");

WriteLiteral(">Is this address the vacancy location?</h4>\r\n\r\n                    <label");

WriteLiteral(" data-target=\"location-type-main-location-panel\"");

WriteLiteral(" for=\"location-type-main-location\"");

WriteAttribute("class", Tuple.Create(" class=\"", 7794), Tuple.Create("\"", 7852)
, Tuple.Create(Tuple.Create("", 7802), Tuple.Create("block-label", 7802), true)
            
            #line 113 "..\..\Views\Shared\DisplayTemplates\Vacancy\EmployerDetails.cshtml"
                                               , Tuple.Create(Tuple.Create(" ", 7813), Tuple.Create<System.Object, System.Int32>(Model.EmployerApprenticeshipLocation
            
            #line default
            #line hidden
, 7814), false)
, Tuple.Create(Tuple.Create(" ", 7851), Tuple.Create("", 7851), true)
);

WriteLiteral(">\r\n");

WriteLiteral("                        ");

            
            #line 114 "..\..\Views\Shared\DisplayTemplates\Vacancy\EmployerDetails.cshtml"
                   Write(Html.RadioButtonFor(m => m.EmployerApprenticeshipLocation, true, new { id = "location-type-main-location", aria_controls = "location-type-main-location-panel" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                        Yes, this will be the vacancy location\r\n               " +
"     </label>\r\n                    <label");

WriteLiteral(" data-target=\"location-type-different-location-panel\"");

WriteLiteral(" for=\"location-type-different-location\"");

WriteAttribute("class", Tuple.Create(" class=\"", 8256), Tuple.Create("\"", 8314)
, Tuple.Create(Tuple.Create("", 8264), Tuple.Create("block-label", 8264), true)
            
            #line 117 "..\..\Views\Shared\DisplayTemplates\Vacancy\EmployerDetails.cshtml"
                                                         , Tuple.Create(Tuple.Create(" ", 8275), Tuple.Create<System.Object, System.Int32>(Model.EmployerApprenticeshipLocation
            
            #line default
            #line hidden
, 8276), false)
, Tuple.Create(Tuple.Create(" ", 8313), Tuple.Create("", 8313), true)
);

WriteLiteral(">\r\n");

WriteLiteral("                        ");

            
            #line 118 "..\..\Views\Shared\DisplayTemplates\Vacancy\EmployerDetails.cshtml"
                   Write(Html.RadioButtonFor(m => m.EmployerApprenticeshipLocation, false, new { id = "location-type-different-location", aria_controls = "location-type-different-location-panel" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                        No, I need to add a different location\r\n               " +
"     </label>\r\n                </div>\r\n                <div");

WriteLiteral(" class=\"form-group inline clearfix blocklabel-single\"");

WriteLiteral(">\r\n                    <a");

WriteAttribute("name", Tuple.Create(" name=\"", 8733), Tuple.Create("\"", 8802)
            
            #line 123 "..\..\Views\Shared\DisplayTemplates\Vacancy\EmployerDetails.cshtml"
, Tuple.Create(Tuple.Create("", 8740), Tuple.Create<System.Object, System.Int32>(Html.NameFor(m => m.IsAnonymousEmployer).ToString().ToLower()
            
            #line default
            #line hidden
, 8740), false)
);

WriteLiteral("></a>\r\n                    <h4");

WriteLiteral(" class=\"bold-small\"");

WriteLiteral(">Will the employer\'s name and address be shown in this vacancy?</h4>\r\n\r\n         " +
"           <label");

WriteLiteral(" data-target=\"is-anonymous-employer\"");

WriteLiteral(" for=\"is-anonymous-employer\"");

WriteAttribute("class", Tuple.Create(" class=\"", 9014), Tuple.Create("\"", 9061)
, Tuple.Create(Tuple.Create("", 9022), Tuple.Create("block-label", 9022), true)
            
            #line 126 "..\..\Views\Shared\DisplayTemplates\Vacancy\EmployerDetails.cshtml"
                             , Tuple.Create(Tuple.Create(" ", 9033), Tuple.Create<System.Object, System.Int32>(Model.IsAnonymousEmployer
            
            #line default
            #line hidden
, 9034), false)
, Tuple.Create(Tuple.Create(" ", 9060), Tuple.Create("", 9060), true)
);

WriteLiteral(">\r\n");

WriteLiteral("                        ");

            
            #line 127 "..\..\Views\Shared\DisplayTemplates\Vacancy\EmployerDetails.cshtml"
                   Write(Html.RadioButtonFor(m => m.IsAnonymousEmployer, false, new { id = "anonymous-employer", aria_controls = "anonymous-employer" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                        Yes\r\n                    </label>\r\n                    " +
"<label");

WriteLiteral(" data-target=\"is-non-anonymous-employer\"");

WriteLiteral(" for=\"is-non-anonymous-employer\"");

WriteAttribute("class", Tuple.Create(" class=\"", 9376), Tuple.Create("\"", 9423)
, Tuple.Create(Tuple.Create("", 9384), Tuple.Create("block-label", 9384), true)
            
            #line 130 "..\..\Views\Shared\DisplayTemplates\Vacancy\EmployerDetails.cshtml"
                                     , Tuple.Create(Tuple.Create(" ", 9395), Tuple.Create<System.Object, System.Int32>(Model.IsAnonymousEmployer
            
            #line default
            #line hidden
, 9396), false)
, Tuple.Create(Tuple.Create(" ", 9422), Tuple.Create("", 9422), true)
);

WriteLiteral(">\r\n");

WriteLiteral("                        ");

            
            #line 131 "..\..\Views\Shared\DisplayTemplates\Vacancy\EmployerDetails.cshtml"
                   Write(Html.RadioButtonFor(m => m.IsAnonymousEmployer, true, new { id = "non-anonymous-employer", aria_controls = "non-anonymous-employer" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                        No, the employer wants to remain anonymous\r\n           " +
"         </label>\r\n                </div>\r\n                <div");

WriteLiteral(" id=\"location-type-main-location-panel\"");

WriteLiteral(" class=\"toggle-content blocklabel-content location\"");

WriteLiteral(">\r\n");

            
            #line 136 "..\..\Views\Shared\DisplayTemplates\Vacancy\EmployerDetails.cshtml"
                    
            
            #line default
            #line hidden
            
            #line 136 "..\..\Views\Shared\DisplayTemplates\Vacancy\EmployerDetails.cshtml"
                      
                        var className = "form-group";
                        if (ViewData.ModelState.Keys.Contains("NumberOfPositions"))
                        {
                            className += " input-validation-error";
                        }
                    
            
            #line default
            #line hidden
WriteLiteral("\r\n                    <div");

WriteAttribute("class", Tuple.Create(" class=\"", 10157), Tuple.Create("\"", 10175)
            
            #line 143 "..\..\Views\Shared\DisplayTemplates\Vacancy\EmployerDetails.cshtml"
, Tuple.Create(Tuple.Create("", 10165), Tuple.Create<System.Object, System.Int32>(className
            
            #line default
            #line hidden
, 10165), false)
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

            
            #line 146 "..\..\Views\Shared\DisplayTemplates\Vacancy\EmployerDetails.cshtml"
                   Write(Html.ValidationMessage("NumberOfPositions"));

            
            #line default
            #line hidden
WriteLiteral("\r\n                    </div>\r\n");

WriteLiteral("                    ");

            
            #line 148 "..\..\Views\Shared\DisplayTemplates\Vacancy\EmployerDetails.cshtml"
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

            
            #line 156 "..\..\Views\Shared\DisplayTemplates\Vacancy\EmployerDetails.cshtml"
       Write(Html.FormTextFor(model => model.EmployerWebsiteUrl, controlHtmlAttributes: new { type = "text", @class = "form-control-1-1" }, labelHtmlAttributes: new { @class = "bold-small" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("            ");

            
            #line 157 "..\..\Views\Shared\DisplayTemplates\Vacancy\EmployerDetails.cshtml"
       Write(Html.EditorFor(m => m.EmployerWebsiteUrlComment, "Comment", Html.GetLabelFor(m => m.EmployerWebsiteUrlComment)));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("            ");

            
            #line 158 "..\..\Views\Shared\DisplayTemplates\Vacancy\EmployerDetails.cshtml"
       Write(Html.FormTextAreaFor(m => m.EmployerDescription, controlHtmlAttributes: new { @class = "width-all-1-1", type = "text", size = 12, style = "height: 200px;" }, labelHtmlAttributes: new { @class = "bold-small" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("            ");

            
            #line 159 "..\..\Views\Shared\DisplayTemplates\Vacancy\EmployerDetails.cshtml"
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

            
            #line 167 "..\..\Views\Shared\DisplayTemplates\Vacancy\EmployerDetails.cshtml"
       Write(Html.FormTextAreaFor(model => model.AnonymousEmployerDescription, controlHtmlAttributes: new { type = "text", @class = "form-control-1-1", data_val_length_max = "40", rows = 1 }, labelHtmlAttributes: new { @class = "bold-small" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("            ");

            
            #line 168 "..\..\Views\Shared\DisplayTemplates\Vacancy\EmployerDetails.cshtml"
       Write(Html.EditorFor(m => m.AnonymousEmployerDescriptionComment, "Comment", Html.GetLabelFor(m => m.AnonymousEmployerDescriptionComment)));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("            ");

            
            #line 169 "..\..\Views\Shared\DisplayTemplates\Vacancy\EmployerDetails.cshtml"
       Write(Html.FormTextAreaFor(m => m.AnonymousEmployerReason, controlHtmlAttributes: new { @class = "width-all-1-1", type = "text", size = 12, style = "height: 200px;", data_val_length_max = "240" }, labelHtmlAttributes: new { @class = "bold-small" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("            ");

            
            #line 170 "..\..\Views\Shared\DisplayTemplates\Vacancy\EmployerDetails.cshtml"
       Write(Html.EditorFor(m => m.AnonymousEmployerReasonComment, "Comment", Html.GetLabelFor(m => m.AnonymousEmployerReasonComment)));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("            ");

            
            #line 171 "..\..\Views\Shared\DisplayTemplates\Vacancy\EmployerDetails.cshtml"
       Write(Html.FormTextAreaFor(m => m.AnonymousAboutTheEmployer, controlHtmlAttributes: new { @class = "width-all-1-1", type = "text", size = 12, style = "height: 200px;" }, labelHtmlAttributes: new { @class = "bold-small" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("            ");

            
            #line 172 "..\..\Views\Shared\DisplayTemplates\Vacancy\EmployerDetails.cshtml"
       Write(Html.EditorFor(m => m.AnonymousAboutTheEmployerComment, "Comment", Html.GetLabelFor(m => m.AnonymousAboutTheEmployerComment)));

            
            #line default
            #line hidden
WriteLiteral("\r\n        </div>\r\n    </div>\r\n</div>");

        }
    }
}
#pragma warning restore 1591
