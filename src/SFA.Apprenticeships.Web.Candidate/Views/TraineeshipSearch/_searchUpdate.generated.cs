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

namespace SFA.Apprenticeships.Web.Candidate.Views.TraineeshipSearch
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
    using SFA.Apprenticeships.Infrastructure.Presentation;
    using SFA.Apprenticeships.Web.Candidate;
    using SFA.Apprenticeships.Web.Candidate.Constants;
    using SFA.Apprenticeships.Web.Candidate.Constants.ViewModels;
    using SFA.Apprenticeships.Web.Candidate.Helpers;
    using SFA.Apprenticeships.Web.Candidate.ViewModels;
    using SFA.Apprenticeships.Web.Candidate.ViewModels.Candidate;
    using SFA.Apprenticeships.Web.Candidate.ViewModels.Login;
    using SFA.Apprenticeships.Web.Candidate.ViewModels.Register;
    using SFA.Apprenticeships.Web.Candidate.ViewModels.VacancySearch;
    using SFA.Apprenticeships.Web.Common.Constants;
    using SFA.Apprenticeships.Web.Common.Framework;
    using SFA.Apprenticeships.Web.Common.Models.Common;
    using SFA.Apprenticeships.Web.Common.ViewModels.Locations;
    using SFA.Apprenticeships.Web.Common.Views.Shared.DisplayTemplates;
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/TraineeshipSearch/_searchUpdate.cshtml")]
    public partial class searchUpdate : System.Web.Mvc.WebViewPage<TraineeshipSearchViewModel>
    {
        public searchUpdate()
        {
        }
        public override void Execute()
        {
WriteLiteral("<section");

WriteLiteral(" class=\"column-one-third\"");

WriteLiteral(">\r\n    <div>\r\n        <fieldset");

WriteLiteral(" class=\"search-filter\"");

WriteLiteral(">\r\n\r\n            <legend");

WriteLiteral(" class=\"heading-medium mob-collpanel-trigger\"");

WriteLiteral(" id=\"editSearchToggle\"");

WriteLiteral(">Edit search</legend>\r\n            <div");

WriteLiteral(" class=\"mob-collpanel toggle-content--mob\"");

WriteLiteral(" id=\"editSearchPanel\"");

WriteLiteral(">\r\n\r\n                <div");

WriteLiteral(" class=\"para-btm-margin\"");

WriteLiteral(">\r\n");

WriteLiteral("                    ");

            
            #line 11 "..\..\Views\TraineeshipSearch\_searchUpdate.cshtml"
               Write(Html.FormTextFor(m=>m.ReferenceNumber, "Reference number"));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("                    ");

            
            #line 12 "..\..\Views\TraineeshipSearch\_searchUpdate.cshtml"
               Write(Html.FormTextFor(m => m.Location, hintText: "", containerHtmlAttributes: new {@class = "small-btm-margin"}));

            
            #line default
            #line hidden
WriteLiteral("\r\n                    <a");

WriteLiteral(" href=\"#\"");

WriteLiteral(" class=\"geolocater inl-block hide-nojs \"");

WriteLiteral(" id=\"getLocation\"");

WriteLiteral(">Use current location</a>\r\n                </div>\r\n                \r\n");

            
            #line 16 "..\..\Views\TraineeshipSearch\_searchUpdate.cshtml"
                
            
            #line default
            #line hidden
            
            #line 16 "..\..\Views\TraineeshipSearch\_searchUpdate.cshtml"
                  
                    var open = Model.LocationSearches.Any() ? "open " : "";
                    var hidden = Model.LocationSearches.Any() ? "" : "hidden ";
                
            
            #line default
            #line hidden
WriteLiteral("\r\n                <details ");

            
            #line 20 "..\..\Views\TraineeshipSearch\_searchUpdate.cshtml"
                     Write(open);

            
            #line default
            #line hidden
WriteLiteral(" class=\"");

            
            #line 20 "..\..\Views\TraineeshipSearch\_searchUpdate.cshtml"
                                    Write(open);

            
            #line default
            #line hidden
            
            #line 20 "..\..\Views\TraineeshipSearch\_searchUpdate.cshtml"
                                           Write(hidden);

            
            #line default
            #line hidden
WriteLiteral("form-group form-group-compound\" id=\"locationSuggestions\">\r\n                    <s" +
"ummary");

WriteLiteral(" tabindex=\"0\"");

WriteLiteral(" aria-describedby=\"locSuggestionsAria\"");

WriteLiteral(">Did you mean:</summary>\r\n                    <p");

WriteLiteral(" class=\"visuallyhidden\"");

WriteLiteral(" aria-live=\"polite\"");

WriteLiteral(" id=\"locSuggestionsAria\"");

WriteLiteral("></p>\r\n                    <div");

WriteLiteral(" class=\"detail-content panel-indent\"");

WriteLiteral(">\r\n                        <ul");

WriteLiteral(" id=\"location-suggestions\"");

WriteLiteral(" class=\"list-text list-max-11\"");

WriteLiteral(">\r\n");

            
            #line 25 "..\..\Views\TraineeshipSearch\_searchUpdate.cshtml"
                            
            
            #line default
            #line hidden
            
            #line 25 "..\..\Views\TraineeshipSearch\_searchUpdate.cshtml"
                             foreach (var locationSearch in Model.LocationSearches)
                            {

            
            #line default
            #line hidden
WriteLiteral("                                <li><a");

WriteAttribute("href", Tuple.Create(" href=\"", 1551), Tuple.Create("\"", 1627)
            
            #line 27 "..\..\Views\TraineeshipSearch\_searchUpdate.cshtml"
, Tuple.Create(Tuple.Create("", 1558), Tuple.Create<System.Object, System.Int32>(Url.RouteUrl(CandidateRouteNames.TraineeshipResults, locationSearch)
            
            #line default
            #line hidden
, 1558), false)
);

WriteLiteral(">");

            
            #line 27 "..\..\Views\TraineeshipSearch\_searchUpdate.cshtml"
                                                                                                               Write(locationSearch.Location);

            
            #line default
            #line hidden
WriteLiteral("</a></li>\r\n");

            
            #line 28 "..\..\Views\TraineeshipSearch\_searchUpdate.cshtml"
                            }

            
            #line default
            #line hidden
WriteLiteral("                        </ul>\r\n                    </div>\r\n                </deta" +
"ils>\r\n\r\n                <div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(">\r\n                    <label");

WriteLiteral(" for=\"loc-within\"");

WriteLiteral(" class=\"form-label\"");

WriteLiteral(">Within</label>\r\n");

WriteLiteral("                    ");

            
            #line 35 "..\..\Views\TraineeshipSearch\_searchUpdate.cshtml"
               Write(Html.DropDownListFor(m => m.WithinDistance, Model.Distances, new { @id = "loc-within", @name = "WithinDistance" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                </div>\r\n                <div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(">\r\n                    <button");

WriteLiteral(" class=\"button no-btm-margin\"");

WriteLiteral(" id=\"search-button\"");

WriteLiteral(" name=\"SearchAction\"");

WriteLiteral(" value=\"Search\"");

WriteLiteral(">Update results</button>\r\n                </div>\r\n                <div");

WriteLiteral(" class=\"form-group map-container hide-nojs\"");

WriteLiteral(">\r\n                    <div");

WriteLiteral(" id=\"map-canvas\"");

WriteLiteral(" style=\"width: 100%; height: 250px\"");

WriteLiteral("></div>\r\n                </div>\r\n\r\n");

WriteLiteral("                ");

            
            #line 44 "..\..\Views\TraineeshipSearch\_searchUpdate.cshtml"
           Write(Html.HiddenFor(m => m.Latitude));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("                ");

            
            #line 45 "..\..\Views\TraineeshipSearch\_searchUpdate.cshtml"
           Write(Html.HiddenFor(m => m.Longitude));

            
            #line default
            #line hidden
WriteLiteral("\r\n                ");

WriteLiteral("\r\n                <input");

WriteLiteral(" id=\"Hash\"");

WriteLiteral(" name=\"Hash\"");

WriteLiteral(" type=\"hidden\"");

WriteAttribute("value", Tuple.Create(" value=\"", 2789), Tuple.Create("\"", 2819)
            
            #line 47 "..\..\Views\TraineeshipSearch\_searchUpdate.cshtml"
, Tuple.Create(Tuple.Create("", 2797), Tuple.Create<System.Object, System.Int32>(Model.LatLonLocHash()
            
            #line default
            #line hidden
, 2797), false)
);

WriteLiteral(" />\r\n\r\n            </div>\r\n        </fieldset>\r\n    </div>\r\n    \r\n\r\n</section>");

        }
    }
}
#pragma warning restore 1591
