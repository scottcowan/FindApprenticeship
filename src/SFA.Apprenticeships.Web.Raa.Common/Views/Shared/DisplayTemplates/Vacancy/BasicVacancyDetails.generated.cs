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
    using SFA.Apprenticeships.Infrastructure.Presentation;
    using SFA.Apprenticeships.Web.Common.Constants;
    using SFA.Apprenticeships.Web.Common.Framework;
    using SFA.Apprenticeships.Web.Common.Models.Common;
    using SFA.Apprenticeships.Web.Raa.Common;
    
    #line 3 "..\..\Views\Shared\DisplayTemplates\Vacancy\BasicVacancyDetails.cshtml"
    using SFA.Apprenticeships.Web.Raa.Common.Constants.ViewModels;
    
    #line default
    #line hidden
    
    #line 4 "..\..\Views\Shared\DisplayTemplates\Vacancy\BasicVacancyDetails.cshtml"
    using SFA.Apprenticeships.Web.Raa.Common.Extensions;
    
    #line default
    #line hidden
    
    #line 5 "..\..\Views\Shared\DisplayTemplates\Vacancy\BasicVacancyDetails.cshtml"
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

            
            #line 7 "..\..\Views\Shared\DisplayTemplates\Vacancy\BasicVacancyDetails.cshtml"
  
    ViewBag.Title = "Recruit an Apprentice - Select framework and level";

    const string selected = "selected";

    var isApplicationThroughRAAYes = (Model.OfflineVacancy.HasValue && !Model.OfflineVacancy.Value) ? selected : null;
    var isApplicationThroughRAANo = (Model.OfflineVacancy.HasValue && Model.OfflineVacancy.Value) ? selected : null;


            
            #line default
            #line hidden
WriteLiteral("    <h1");

WriteLiteral(" class=\"heading-xlarge\"");

WriteLiteral(">\r\n        Enter basic vacancy details\r\n    </h1>\r\n");

            
            #line 18 "..\..\Views\Shared\DisplayTemplates\Vacancy\BasicVacancyDetails.cshtml"

    
            
            #line default
            #line hidden
            
            #line 19 "..\..\Views\Shared\DisplayTemplates\Vacancy\BasicVacancyDetails.cshtml"
Write(Html.AntiForgeryToken());

            
            #line default
            #line hidden
            
            #line 19 "..\..\Views\Shared\DisplayTemplates\Vacancy\BasicVacancyDetails.cshtml"
                            
    
            
            #line default
            #line hidden
            
            #line 20 "..\..\Views\Shared\DisplayTemplates\Vacancy\BasicVacancyDetails.cshtml"
Write(Html.HiddenFor(m => m.IsEmployerLocationMainApprenticeshipLocation));

            
            #line default
            #line hidden
            
            #line 20 "..\..\Views\Shared\DisplayTemplates\Vacancy\BasicVacancyDetails.cshtml"
                                                                        
    
            
            #line default
            #line hidden
            
            #line 21 "..\..\Views\Shared\DisplayTemplates\Vacancy\BasicVacancyDetails.cshtml"
Write(Html.HiddenFor(m => m.OfflineVacancyType));

            
            #line default
            #line hidden
            
            #line 21 "..\..\Views\Shared\DisplayTemplates\Vacancy\BasicVacancyDetails.cshtml"
                                              
    
            
            #line default
            #line hidden
            
            #line 22 "..\..\Views\Shared\DisplayTemplates\Vacancy\BasicVacancyDetails.cshtml"
Write(Html.HiddenFor(m => m.NumberOfPositions));

            
            #line default
            #line hidden
            
            #line 22 "..\..\Views\Shared\DisplayTemplates\Vacancy\BasicVacancyDetails.cshtml"
                                             
    
            
            #line default
            #line hidden
            
            #line 23 "..\..\Views\Shared\DisplayTemplates\Vacancy\BasicVacancyDetails.cshtml"
Write(Html.HiddenFor(m => m.ComeFromPreview));

            
            #line default
            #line hidden
            
            #line 23 "..\..\Views\Shared\DisplayTemplates\Vacancy\BasicVacancyDetails.cshtml"
                                           
    
            
            #line default
            #line hidden
            
            #line 24 "..\..\Views\Shared\DisplayTemplates\Vacancy\BasicVacancyDetails.cshtml"
Write(Html.HiddenFor(m => m.VacancySource));

            
            #line default
            #line hidden
            
            #line 24 "..\..\Views\Shared\DisplayTemplates\Vacancy\BasicVacancyDetails.cshtml"
                                         
    
            
            #line default
            #line hidden
            
            #line 25 "..\..\Views\Shared\DisplayTemplates\Vacancy\BasicVacancyDetails.cshtml"
Write(Html.Partial("ValidationSummary", ViewData.ModelState));

            
            #line default
            #line hidden
            
            #line 25 "..\..\Views\Shared\DisplayTemplates\Vacancy\BasicVacancyDetails.cshtml"
                                                           

    
            
            #line default
            #line hidden
            
            #line 27 "..\..\Views\Shared\DisplayTemplates\Vacancy\BasicVacancyDetails.cshtml"
Write(Html.FormTextAreaFor(m => m.Title, controlHtmlAttributes: new {type = "text", size = 12, @class = "width-all-1-1 form-textarea-small"}));

            
            #line default
            #line hidden
            
            #line 27 "..\..\Views\Shared\DisplayTemplates\Vacancy\BasicVacancyDetails.cshtml"
                                                                                                                                            
    
            
            #line default
            #line hidden
            
            #line 28 "..\..\Views\Shared\DisplayTemplates\Vacancy\BasicVacancyDetails.cshtml"
Write(Html.EditorFor(m => m.TitleComment, "Comment", Html.GetLabelFor(m => m.TitleComment)));

            
            #line default
            #line hidden
            
            #line 28 "..\..\Views\Shared\DisplayTemplates\Vacancy\BasicVacancyDetails.cshtml"
                                                                                          
    
            
            #line default
            #line hidden
            
            #line 29 "..\..\Views\Shared\DisplayTemplates\Vacancy\BasicVacancyDetails.cshtml"
Write(Html.ValidationMessageFor(m => m.TitleComment));

            
            #line default
            #line hidden
            
            #line 29 "..\..\Views\Shared\DisplayTemplates\Vacancy\BasicVacancyDetails.cshtml"
                                                   

    
            
            #line default
            #line hidden
            
            #line 31 "..\..\Views\Shared\DisplayTemplates\Vacancy\BasicVacancyDetails.cshtml"
Write(Html.FormTextAreaFor(m => m.ShortDescription, controlHtmlAttributes: new {type = "text", size = 12, @class = "width-all-1-1 form-textarea-medium"}));

            
            #line default
            #line hidden
            
            #line 31 "..\..\Views\Shared\DisplayTemplates\Vacancy\BasicVacancyDetails.cshtml"
                                                                                                                                                        
    
            
            #line default
            #line hidden
            
            #line 32 "..\..\Views\Shared\DisplayTemplates\Vacancy\BasicVacancyDetails.cshtml"
Write(Html.EditorFor(m => m.ShortDescriptionComment, "Comment", Html.GetLabelFor(m => m.ShortDescriptionComment)));

            
            #line default
            #line hidden
            
            #line 32 "..\..\Views\Shared\DisplayTemplates\Vacancy\BasicVacancyDetails.cshtml"
                                                                                                                
    
            
            #line default
            #line hidden
            
            #line 33 "..\..\Views\Shared\DisplayTemplates\Vacancy\BasicVacancyDetails.cshtml"
Write(Html.ValidationMessageFor(m => m.ShortDescriptionComment));

            
            #line default
            #line hidden
            
            #line 33 "..\..\Views\Shared\DisplayTemplates\Vacancy\BasicVacancyDetails.cshtml"
                                                              


            
            #line default
            #line hidden
WriteLiteral("    <div");

WriteAttribute("class", Tuple.Create(" class=\"", 1696), Tuple.Create("\"", 1839)
, Tuple.Create(Tuple.Create("", 1704), Tuple.Create("form-group", 1704), true)
            
            #line 35 "..\..\Views\Shared\DisplayTemplates\Vacancy\BasicVacancyDetails.cshtml"
, Tuple.Create(Tuple.Create(" ", 1714), Tuple.Create<System.Object, System.Int32>(SFA.Apprenticeships.Web.Common.Framework.HtmlExtensions.GetValidationCssClass(Html.GetValidationType(m => m.VacancyType))
            
            #line default
            #line hidden
, 1715), false)
);

WriteLiteral(">\r\n        <a");

WriteAttribute("name", Tuple.Create(" name=\"", 1853), Tuple.Create("\"", 1914)
            
            #line 36 "..\..\Views\Shared\DisplayTemplates\Vacancy\BasicVacancyDetails.cshtml"
, Tuple.Create(Tuple.Create("", 1860), Tuple.Create<System.Object, System.Int32>(Html.NameFor(m => m.VacancyType).ToString().ToLower()
            
            #line default
            #line hidden
, 1860), false)
);

WriteLiteral("></a>\r\n        <label");

WriteLiteral(" class=\"form-label\"");

WriteLiteral(">Vacancy type</label>\r\n        ");

WriteLiteral("\r\n        <label");

WriteLiteral(" for=\"vacancy-type-apprenticeship\"");

WriteLiteral(" class=\"block-label\"");

WriteLiteral(">\r\n");

WriteLiteral("            ");

            
            #line 40 "..\..\Views\Shared\DisplayTemplates\Vacancy\BasicVacancyDetails.cshtml"
       Write(Html.RadioButtonFor(model => model.VacancyType, VacancyType.Apprenticeship, new { id = "vacancy-type-apprenticeship", aria_labelledby = "vacancy-type-label" }));

            
            #line default
            #line hidden
WriteLiteral(" Apprenticeship\r\n        </label>\r\n        ");

WriteLiteral("\r\n        <label");

WriteLiteral(" for=\"vacancy-type-traineeship\"");

WriteLiteral(" class=\"block-label\"");

WriteLiteral(">\r\n");

WriteLiteral("            ");

            
            #line 44 "..\..\Views\Shared\DisplayTemplates\Vacancy\BasicVacancyDetails.cshtml"
       Write(Html.RadioButtonFor(model => model.VacancyType, VacancyType.Traineeship, new { id = "vacancy-type-traineeship", aria_labelledby = "vacancy-type-label" }));

            
            #line default
            #line hidden
WriteLiteral(" Traineeship\r\n        </label>\r\n");

WriteLiteral("        ");

            
            #line 46 "..\..\Views\Shared\DisplayTemplates\Vacancy\BasicVacancyDetails.cshtml"
   Write(Html.ValidationMessageFor(m => m.VacancyType));

            
            #line default
            #line hidden
WriteLiteral("\r\n    </div>\r\n");

            
            #line 48 "..\..\Views\Shared\DisplayTemplates\Vacancy\BasicVacancyDetails.cshtml"


            
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

            
            #line 57 "..\..\Views\Shared\DisplayTemplates\Vacancy\BasicVacancyDetails.cshtml"
                                                                                                     Write(isApplicationThroughRAAYes);

            
            #line default
            #line hidden
WriteLiteral(">\r\n");

WriteLiteral("                    ");

            
            #line 58 "..\..\Views\Shared\DisplayTemplates\Vacancy\BasicVacancyDetails.cshtml"
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

            
            #line 62 "..\..\Views\Shared\DisplayTemplates\Vacancy\BasicVacancyDetails.cshtml"
                                                                                                       Write(isApplicationThroughRAANo);

            
            #line default
            #line hidden
WriteLiteral(">\r\n");

WriteLiteral("                    ");

            
            #line 63 "..\..\Views\Shared\DisplayTemplates\Vacancy\BasicVacancyDetails.cshtml"
               Write(Html.RadioButtonFor(model => model.OfflineVacancy, true, new {id = "apprenticeship-offline-vacancy", aria_labelledby = "apprenticeship-vacancy-management-type-label", aria_controls = "offline-panel"}));

            
            #line default
            #line hidden
WriteLiteral(" Candidates will apply through an external website\r\n                </label>\r\n");

WriteLiteral("                ");

            
            #line 65 "..\..\Views\Shared\DisplayTemplates\Vacancy\BasicVacancyDetails.cshtml"
           Write(Html.ValidationMessageFor(m => m.OfflineVacancy));

            
            #line default
            #line hidden
WriteLiteral("\r\n            </div>\r\n            <div");

WriteLiteral(" class=\"hide-js\"");

WriteLiteral(">Only answer if the vacancy applications will be managed through an external webs" +
"ite:</div>\r\n            <div");

WriteLiteral(" id=\"offline-panel\"");

WriteLiteral(" class=\"toggle-content panel-indent blocklabel-content\"");

WriteLiteral(">\r\n                <a");

WriteAttribute("name", Tuple.Create(" name=\"", 4342), Tuple.Create("\"", 4413)
            
            #line 69 "..\..\Views\Shared\DisplayTemplates\Vacancy\BasicVacancyDetails.cshtml"
, Tuple.Create(Tuple.Create("", 4349), Tuple.Create<System.Object, System.Int32>(Html.NameFor(m => m.OfflineApplicationUrl).ToString().ToLower()
            
            #line default
            #line hidden
, 4349), false)
);

WriteLiteral("></a>\r\n                <div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(">\r\n");

            
            #line 71 "..\..\Views\Shared\DisplayTemplates\Vacancy\BasicVacancyDetails.cshtml"
                    
            
            #line default
            #line hidden
            
            #line 71 "..\..\Views\Shared\DisplayTemplates\Vacancy\BasicVacancyDetails.cshtml"
                      
                        var hideOfflineLinks = Model.IsEmployerLocationMainApprenticeshipLocation == true || Model.LocationAddresses == null || Model.LocationAddresses.Count <= 1;
                        var offlineMultiUrlParaStyle = hideOfflineLinks || Model.OfflineVacancyType == OfflineVacancyType.MultiUrl ? "display: none;" : null;
                        var offlineSingleUrlParaStyle = hideOfflineLinks || Model.OfflineVacancyType != OfflineVacancyType.MultiUrl ? "display: none;" : null;
                        var offlineMultiUrlDivStyle = Model.OfflineVacancyType == OfflineVacancyType.MultiUrl ? null : "display: none;";
                        var offlineSingleUrlDivStyle = hideOfflineLinks || Model.OfflineVacancyType != OfflineVacancyType.MultiUrl ? null: "display: none;";
                    
            
            #line default
            #line hidden
WriteLiteral("\r\n\r\n                    <div");

WriteLiteral(" id=\"multiple-offline-application-urls-div\"");

WriteAttribute("style", Tuple.Create(" style=\"", 5375), Tuple.Create("\"", 5407)
            
            #line 79 "..\..\Views\Shared\DisplayTemplates\Vacancy\BasicVacancyDetails.cshtml"
, Tuple.Create(Tuple.Create("", 5383), Tuple.Create<System.Object, System.Int32>(offlineMultiUrlDivStyle
            
            #line default
            #line hidden
, 5383), false)
);

WriteLiteral(">\r\n");

WriteLiteral("                        ");

            
            #line 80 "..\..\Views\Shared\DisplayTemplates\Vacancy\BasicVacancyDetails.cshtml"
                   Write(Html.LabelFor(m => m.OfflineApplicationUrl));

            
            #line default
            #line hidden
WriteLiteral("\r\n                        <p");

WriteLiteral(" id=\"single-offline-application-url-para\"");

WriteLiteral(" class=\"inline-text\"");

WriteAttribute("style", Tuple.Create(" style=\"", 5568), Tuple.Create("\"", 5602)
            
            #line 81 "..\..\Views\Shared\DisplayTemplates\Vacancy\BasicVacancyDetails.cshtml"
               , Tuple.Create(Tuple.Create("", 5576), Tuple.Create<System.Object, System.Int32>(offlineSingleUrlParaStyle
            
            #line default
            #line hidden
, 5576), false)
);

WriteLiteral(">Alternatively, <button");

WriteLiteral(" id=\"single-offline-application-url-button\"");

WriteLiteral(" type=\"submit\"");

WriteLiteral(" class=\"button-link no-autosave no-validation\"");

WriteAttribute("name", Tuple.Create(" name=\"", 5729), Tuple.Create("\"", 5769)
            
            #line 81 "..\..\Views\Shared\DisplayTemplates\Vacancy\BasicVacancyDetails.cshtml"
                                                                                                                                                                               , Tuple.Create(Tuple.Create("", 5736), Tuple.Create<System.Object, System.Int32>(ViewData["OfflineUrlButtonName"]
            
            #line default
            #line hidden
, 5736), false)
);

WriteLiteral(" value=\"SingleOfflineApplicationUrl\"");

WriteLiteral(">");

            
            #line 81 "..\..\Views\Shared\DisplayTemplates\Vacancy\BasicVacancyDetails.cshtml"
                                                                                                                                                                                                                                                                                                                                 Write(NewVacancyViewModelMessages.SingleOfflineUrlButtonText);

            
            #line default
            #line hidden
WriteLiteral("</button></p>\r\n                        <table");

WriteLiteral(" id=\"multiple-offline-application-urls-table\"");

WriteLiteral(">\r\n                            <colgroup>\r\n                                <col");

WriteLiteral(" class=\"t30\"");

WriteLiteral(">\r\n                                <col");

WriteLiteral(" class=\"t20\"");

WriteLiteral(">\r\n                                <col");

WriteLiteral(" class=\"t50\"");

WriteLiteral(@">
                            </colgroup>
                            <thead>
                                <tr>
                                    <th>Location</th>
                                    <th>Number of positions</th>
                                    <th></th>
                                </tr>
                            </thead>
                            <tbody");

WriteLiteral(" id=\"location-addresses\"");

WriteLiteral(">\r\n");

            
            #line 96 "..\..\Views\Shared\DisplayTemplates\Vacancy\BasicVacancyDetails.cshtml"
                                
            
            #line default
            #line hidden
            
            #line 96 "..\..\Views\Shared\DisplayTemplates\Vacancy\BasicVacancyDetails.cshtml"
                                 if (Model.LocationAddresses != null)
                                {
                                    for (var i = 0; i < Model.LocationAddresses.Count; i++)
                                    {
                                        var locationAddress = Model.LocationAddresses[i];

            
            #line default
            #line hidden
WriteLiteral("                                        <tr>\r\n                                   " +
"         <td");

WriteLiteral(" class=\"location-address\"");

WriteLiteral(">\r\n");

WriteLiteral("                                                ");

            
            #line 103 "..\..\Views\Shared\DisplayTemplates\Vacancy\BasicVacancyDetails.cshtml"
                                           Write(locationAddress.Address.AddressLine1);

            
            #line default
            #line hidden
WriteLiteral("\r\n");

            
            #line 104 "..\..\Views\Shared\DisplayTemplates\Vacancy\BasicVacancyDetails.cshtml"
                                                
            
            #line default
            #line hidden
            
            #line 104 "..\..\Views\Shared\DisplayTemplates\Vacancy\BasicVacancyDetails.cshtml"
                                                 if (!string.IsNullOrWhiteSpace(@locationAddress.Address.AddressLine2))
                                                {

            
            #line default
            #line hidden
WriteLiteral("                                                    <br />\r\n");

            
            #line 107 "..\..\Views\Shared\DisplayTemplates\Vacancy\BasicVacancyDetails.cshtml"
                                                    
            
            #line default
            #line hidden
            
            #line 107 "..\..\Views\Shared\DisplayTemplates\Vacancy\BasicVacancyDetails.cshtml"
                                               Write(locationAddress.Address.AddressLine2);

            
            #line default
            #line hidden
            
            #line 107 "..\..\Views\Shared\DisplayTemplates\Vacancy\BasicVacancyDetails.cshtml"
                                                                                         
                                                }

            
            #line default
            #line hidden
WriteLiteral("                                                <br />");

            
            #line 109 "..\..\Views\Shared\DisplayTemplates\Vacancy\BasicVacancyDetails.cshtml"
                                                 Write(locationAddress.Address.AddressLine4);

            
            #line default
            #line hidden
WriteLiteral(" ");

            
            #line 109 "..\..\Views\Shared\DisplayTemplates\Vacancy\BasicVacancyDetails.cshtml"
                                                                                       Write(locationAddress.Address.Postcode);

            
            #line default
            #line hidden
WriteLiteral("\r\n                                            </td>\r\n                            " +
"                <td");

WriteLiteral(" class=\"location-positions\"");

WriteLiteral(">\r\n");

WriteLiteral("                                                ");

            
            #line 112 "..\..\Views\Shared\DisplayTemplates\Vacancy\BasicVacancyDetails.cshtml"
                                           Write(locationAddress.NumberOfPositions);

            
            #line default
            #line hidden
WriteLiteral("\r\n                                            </td>\r\n                            " +
"                <td");

WriteLiteral(" class=\"location-offline-urls\"");

WriteLiteral(">\r\n                                                <div");

WriteAttribute("class", Tuple.Create(" class=\"", 8003), Tuple.Create("\"", 8180)
, Tuple.Create(Tuple.Create("", 8011), Tuple.Create("form-group", 8011), true)
            
            #line 115 "..\..\Views\Shared\DisplayTemplates\Vacancy\BasicVacancyDetails.cshtml"
, Tuple.Create(Tuple.Create(" ", 8021), Tuple.Create<System.Object, System.Int32>(SFA.Apprenticeships.Web.Common.Framework.HtmlExtensions.GetValidationCssClass(Html.GetValidationType("LocationAddresses[" + i + "].OfflineApplicationUrl"))
            
            #line default
            #line hidden
, 8022), false)
);

WriteLiteral(" style=\"margin-bottom: 0\"");

WriteLiteral(">\r\n");

WriteLiteral("                                                    ");

            
            #line 116 "..\..\Views\Shared\DisplayTemplates\Vacancy\BasicVacancyDetails.cshtml"
                                               Write(Html.Hidden("LocationAddresses[" + i + "].VacancyLocationId", locationAddress.VacancyLocationId));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("                                                    ");

            
            #line 117 "..\..\Views\Shared\DisplayTemplates\Vacancy\BasicVacancyDetails.cshtml"
                                               Write(Html.Hidden("LocationAddresses[" + i + "].NumberOfPositions", locationAddress.NumberOfPositions));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("                                                    ");

            
            #line 118 "..\..\Views\Shared\DisplayTemplates\Vacancy\BasicVacancyDetails.cshtml"
                                               Write(Html.TextBoxFor(m => Model.LocationAddresses[i].OfflineApplicationUrl, new { @id = "locationaddresses_" + i + "__offlineapplicationurl", @class = "width-all-1-1 form-control", type = "text", size = 12 }));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("                                                    ");

            
            #line 119 "..\..\Views\Shared\DisplayTemplates\Vacancy\BasicVacancyDetails.cshtml"
                                               Write(Html.ValidationMessage("LocationAddresses[" + i + "].OfflineApplicationUrl"));

            
            #line default
            #line hidden
WriteLiteral("\r\n                                                </div>\r\n                       " +
"                     </td>\r\n                                        </tr>\r\n");

            
            #line 123 "..\..\Views\Shared\DisplayTemplates\Vacancy\BasicVacancyDetails.cshtml"
                                    }
                                }

            
            #line default
            #line hidden
WriteLiteral("                            </tbody>\r\n                        </table>\r\n         " +
"           </div>\r\n\r\n                    <div");

WriteLiteral(" id=\"single-offline-application-url-div\"");

WriteAttribute("style", Tuple.Create(" style=\"", 9294), Tuple.Create("\"", 9327)
            
            #line 129 "..\..\Views\Shared\DisplayTemplates\Vacancy\BasicVacancyDetails.cshtml"
, Tuple.Create(Tuple.Create("", 9302), Tuple.Create<System.Object, System.Int32>(offlineSingleUrlDivStyle
            
            #line default
            #line hidden
, 9302), false)
);

WriteAttribute("class", Tuple.Create(" class=\"", 9328), Tuple.Create("\"", 9481)
, Tuple.Create(Tuple.Create("", 9336), Tuple.Create("form-group", 9336), true)
            
            #line 129 "..\..\Views\Shared\DisplayTemplates\Vacancy\BasicVacancyDetails.cshtml"
                                     , Tuple.Create(Tuple.Create(" ", 9346), Tuple.Create<System.Object, System.Int32>(SFA.Apprenticeships.Web.Common.Framework.HtmlExtensions.GetValidationCssClass(Html.GetValidationType(m => m.OfflineApplicationUrl))
            
            #line default
            #line hidden
, 9347), false)
);

WriteLiteral(">\r\n");

WriteLiteral("                        ");

            
            #line 130 "..\..\Views\Shared\DisplayTemplates\Vacancy\BasicVacancyDetails.cshtml"
                   Write(Html.LabelFor(m => m.OfflineApplicationUrl));

            
            #line default
            #line hidden
WriteLiteral("\r\n                        <p");

WriteLiteral(" id=\"multiple-offline-application-urls-para\"");

WriteLiteral(" class=\"inline-text\"");

WriteAttribute("style", Tuple.Create(" style=\"", 9645), Tuple.Create("\"", 9678)
            
            #line 131 "..\..\Views\Shared\DisplayTemplates\Vacancy\BasicVacancyDetails.cshtml"
                  , Tuple.Create(Tuple.Create("", 9653), Tuple.Create<System.Object, System.Int32>(offlineMultiUrlParaStyle
            
            #line default
            #line hidden
, 9653), false)
);

WriteLiteral(">Alternatively, you can <button");

WriteLiteral(" id=\"multiple-offline-application-urls-button\"");

WriteLiteral(" type=\"submit\"");

WriteLiteral(" class=\"button-link no-autosave no-validation\"");

WriteAttribute("name", Tuple.Create(" name=\"", 9816), Tuple.Create("\"", 9856)
            
            #line 131 "..\..\Views\Shared\DisplayTemplates\Vacancy\BasicVacancyDetails.cshtml"
                                                                                                                                                                                            , Tuple.Create(Tuple.Create("", 9823), Tuple.Create<System.Object, System.Int32>(ViewData["OfflineUrlButtonName"]
            
            #line default
            #line hidden
, 9823), false)
);

WriteLiteral(" value=\"MultipleOfflineApplicationUrls\"");

WriteLiteral(">");

            
            #line 131 "..\..\Views\Shared\DisplayTemplates\Vacancy\BasicVacancyDetails.cshtml"
                                                                                                                                                                                                                                                                                                                                                 Write(NewVacancyViewModelMessages.MultiOfflineUrlsButtonText);

            
            #line default
            #line hidden
WriteLiteral("</button></p>\r\n");

WriteLiteral("                        ");

            
            #line 132 "..\..\Views\Shared\DisplayTemplates\Vacancy\BasicVacancyDetails.cshtml"
                   Write(Html.TextBoxFor(m => m.OfflineApplicationUrl, new {@class = "width-all-1-1 form-control", type = "text", size = 12, id = "apprenticeship-offline-application-url"}));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("                        ");

            
            #line 133 "..\..\Views\Shared\DisplayTemplates\Vacancy\BasicVacancyDetails.cshtml"
                   Write(Html.ValidationMessageFor(m => m.OfflineApplicationUrl));

            
            #line default
            #line hidden
WriteLiteral("\r\n                    </div>\r\n\r\n");

WriteLiteral("                    ");

            
            #line 136 "..\..\Views\Shared\DisplayTemplates\Vacancy\BasicVacancyDetails.cshtml"
               Write(Html.EditorFor(m => m.OfflineApplicationUrlComment, "Comment", Html.GetLabelFor(m => m.OfflineApplicationUrlComment)));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("                    ");

            
            #line 137 "..\..\Views\Shared\DisplayTemplates\Vacancy\BasicVacancyDetails.cshtml"
               Write(Html.ValidationMessageFor(m => m.OfflineApplicationUrlComment));

            
            #line default
            #line hidden
WriteLiteral("\r\n                </div>\r\n                <div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(">\r\n                    ");

WriteLiteral("\r\n");

WriteLiteral("                    ");

            
            #line 141 "..\..\Views\Shared\DisplayTemplates\Vacancy\BasicVacancyDetails.cshtml"
               Write(Html.FormTextAreaFor(m => m.OfflineApplicationInstructions, controlHtmlAttributes: new {type = "text", size = 12, @class = "width-all-1-1 form-textarea-medium", id = "apprenticheship-offline-application-instructions"}));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("                    ");

            
            #line 142 "..\..\Views\Shared\DisplayTemplates\Vacancy\BasicVacancyDetails.cshtml"
               Write(Html.EditorFor(m => m.OfflineApplicationInstructionsComment, "Comment", Html.GetLabelFor(m => m.OfflineApplicationInstructionsComment)));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("                    ");

            
            #line 143 "..\..\Views\Shared\DisplayTemplates\Vacancy\BasicVacancyDetails.cshtml"
               Write(Html.ValidationMessageFor(m => m.OfflineApplicationInstructionsComment));

            
            #line default
            #line hidden
WriteLiteral("\r\n                    <br/>\r\n                </div>\r\n            </div>\r\n        " +
"</div>\r\n    </div>\r\n");

            
            #line 149 "..\..\Views\Shared\DisplayTemplates\Vacancy\BasicVacancyDetails.cshtml"

    
            
            #line default
            #line hidden
            
            #line 150 "..\..\Views\Shared\DisplayTemplates\Vacancy\BasicVacancyDetails.cshtml"
Write(Html.HiddenFor(model => model.VacancyReferenceNumber));

            
            #line default
            #line hidden
            
            #line 150 "..\..\Views\Shared\DisplayTemplates\Vacancy\BasicVacancyDetails.cshtml"
                                                          
    
            
            #line default
            #line hidden
            
            #line 151 "..\..\Views\Shared\DisplayTemplates\Vacancy\BasicVacancyDetails.cshtml"
Write(Html.HiddenFor(model => model.Ukprn));

            
            #line default
            #line hidden
            
            #line 151 "..\..\Views\Shared\DisplayTemplates\Vacancy\BasicVacancyDetails.cshtml"
                                         
    
            
            #line default
            #line hidden
            
            #line 152 "..\..\Views\Shared\DisplayTemplates\Vacancy\BasicVacancyDetails.cshtml"
Write(Html.HiddenFor(model => model.VacancyOwnerRelationship.VacancyOwnerRelationshipId));

            
            #line default
            #line hidden
            
            #line 152 "..\..\Views\Shared\DisplayTemplates\Vacancy\BasicVacancyDetails.cshtml"
                                                                                       
    
            
            #line default
            #line hidden
            
            #line 153 "..\..\Views\Shared\DisplayTemplates\Vacancy\BasicVacancyDetails.cshtml"
Write(Html.HiddenFor(model => model.VacancyGuid));

            
            #line default
            #line hidden
            
            #line 153 "..\..\Views\Shared\DisplayTemplates\Vacancy\BasicVacancyDetails.cshtml"
                                               
    
            
            #line default
            #line hidden
            
            #line 154 "..\..\Views\Shared\DisplayTemplates\Vacancy\BasicVacancyDetails.cshtml"
Write(Html.HiddenFor(model => model.Status));

            
            #line default
            #line hidden
            
            #line 154 "..\..\Views\Shared\DisplayTemplates\Vacancy\BasicVacancyDetails.cshtml"
                                          

            
            #line default
            #line hidden
        }
    }
}
#pragma warning restore 1591
