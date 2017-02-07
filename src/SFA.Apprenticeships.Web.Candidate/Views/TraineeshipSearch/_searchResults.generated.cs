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
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/TraineeshipSearch/_searchResults.cshtml")]
    public partial class searchResults : System.Web.Mvc.WebViewPage<TraineeshipSearchResponseViewModel>
    {
        public searchResults()
        {
        }
        public override void Execute()
        {
            
            #line 3 "..\..\Views\TraineeshipSearch\_searchResults.cshtml"
 if (Model.TotalHits == 0)
{

            
            #line default
            #line hidden
WriteLiteral("    <p");

WriteLiteral(" id=\"search-no-results-title\"");

WriteLiteral(">There are currently no traineeships that match your search.</p>\r\n");

WriteLiteral("    <p>Try editing your search:</p>\r\n");

WriteLiteral("    <ul");

WriteLiteral(" id=\"search-no-results\"");

WriteLiteral(" class=\"list list-bullet\"");

WriteLiteral(">\r\n        <li>using a different reference number</li>\r\n        <li>expanding you" +
"r search location</li>\r\n    </ul>\r\n");

            
            #line 11 "..\..\Views\TraineeshipSearch\_searchResults.cshtml"
}
else
{

            
            #line default
            #line hidden
WriteLiteral("    <fieldset>\r\n        <legend");

WriteLiteral(" class=\"visuallyhidden\"");

WriteLiteral(">Search items</legend>\r\n        <div");

WriteLiteral(" class=\"grid-row\"");

WriteLiteral(">\r\n            <div");

WriteLiteral(" class=\"column-full sfa-align-right-tablet\"");

WriteLiteral(">\r\n                    <div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(">\r\n                        <label");

WriteLiteral(" for=\"sort-results\"");

WriteLiteral(" class=\"heading-medium sfa-medium-right-margin\"");

WriteLiteral(">Sort results</label>\r\n");

WriteLiteral("                        ");

            
            #line 20 "..\..\Views\TraineeshipSearch\_searchResults.cshtml"
                   Write(Html.DropDownList("sortType", Model.SortTypes, new { @id = "sort-results", @class = "form-control form-control-auto" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                        <noscript>\r\n                            <button");

WriteLiteral(" class=\"button show-nojs\"");

WriteLiteral(" name=\"SearchAction\"");

WriteLiteral(" value=\"Sort\"");

WriteLiteral(">Sort</button>\r\n                        </noscript>  \r\n                        <i" +
"nput");

WriteLiteral(" id=\"SearchAction\"");

WriteLiteral(" name=\"SearchAction\"");

WriteLiteral(" value=\"Search\"");

WriteLiteral(" type=\"hidden\"");

WriteLiteral(" />\r\n                    </div>\r\n            </div>\r\n        </div>\r\n    </fields" +
"et>\r\n");

            
            #line 29 "..\..\Views\TraineeshipSearch\_searchResults.cshtml"


            
            #line default
            #line hidden
WriteLiteral("    <ul");

WriteLiteral(" class=\"search-results\"");

WriteLiteral(">\r\n");

            
            #line 31 "..\..\Views\TraineeshipSearch\_searchResults.cshtml"
        
            
            #line default
            #line hidden
            
            #line 31 "..\..\Views\TraineeshipSearch\_searchResults.cshtml"
         if (Model.Vacancies != null)
        {
            var itemPosition = 1 + (Model.PageSize * Model.PrevPage);
            foreach (var vacancy in Model.Vacancies)
            {
                var webTrendItemPositionTracker = "Webtrends.multiTrack({ element: this, argsa: ['DCS.dcsuri', '/traineeships/results/itemposition/" + vacancy.Id + "', 'WT.dl', '99', 'WT.ti', 'Traineeships Search – Item Position Clicked', 'DCSext.ipos', '" + itemPosition + "'] })";
                var escapedVacancyTitle = HtmlExtensions.EscapeHtmlEncoding(Html, vacancy.Title).ToString();

            
            #line default
            #line hidden
WriteLiteral("                    <li");

WriteLiteral(" class=\"search-result sfa-section-bordered\"");

WriteLiteral(">\r\n                            <h2");

WriteLiteral(" class=\"heading-medium vacancy-title-link\"");

WriteLiteral(">");

            
            #line 39 "..\..\Views\TraineeshipSearch\_searchResults.cshtml"
                                                                     Write(Html.ActionLink(@vacancy.Title, "DetailsWithDistance", new { id = vacancy.Id, distance = vacancy.DistanceAsString }, new { @class = "vacancy-link", data_vacancy_id = vacancy.Id, onclick = webTrendItemPositionTracker, data_lat = vacancy.Location.Latitude, data_lon = vacancy.Location.Longitude }));

            
            #line default
            #line hidden
WriteLiteral(@"</h2>
                           new
                           {
                               data_vacancy_id = vacancy.Id,
                               onclick = webTrendItemPositionTracker,
                               data_lat = vacancy.Location.Latitude,
                               data_lon = vacancy.Location.Longitude
                           })
                        </h2>
");

WriteLiteral("                                <span");

WriteAttribute("id", Tuple.Create(" id=\"", 2746), Tuple.Create("\"", 2774)
, Tuple.Create(Tuple.Create("", 2751), Tuple.Create("posted-date-", 2751), true)
            
            #line 48 "..\..\Views\TraineeshipSearch\_searchResults.cshtml"
, Tuple.Create(Tuple.Create("", 2763), Tuple.Create<System.Object, System.Int32>(vacancy.Id
            
            #line default
            #line hidden
, 2763), false)
);

WriteLiteral(">\r\n                                    (Added ");

            
            #line 49 "..\..\Views\TraineeshipSearch\_searchResults.cshtml"
                                      Write(vacancy.PostedDate.ToFriendlyDaysAgo());

            
            #line default
            #line hidden
WriteLiteral("\r\n                                </span>\r\n");

WriteLiteral("                            </li>\r\n");

WriteLiteral("                            <li");

WriteLiteral(" class=\"font-xsmall secondary-text\"");

WriteLiteral(">\r\n                                (Added ");

            
            #line 53 "..\..\Views\TraineeshipSearch\_searchResults.cshtml"
                                  Write(vacancy.PostedDate.ToFriendlyDaysAgo());

            
            #line default
            #line hidden
WriteLiteral("\r\n                                <span");

WriteAttribute("id", Tuple.Create(" id=\"", 3124), Tuple.Create("\"", 3160)
, Tuple.Create(Tuple.Create("", 3129), Tuple.Create("number-of-positions-", 3129), true)
            
            #line 54 "..\..\Views\TraineeshipSearch\_searchResults.cshtml"
, Tuple.Create(Tuple.Create("", 3149), Tuple.Create<System.Object, System.Int32>(vacancy.Id
            
            #line default
            #line hidden
, 3149), false)
);

WriteLiteral(" class=\"hidden-subcategory\"");

WriteLiteral(">\r\n");

            
            #line 55 "..\..\Views\TraineeshipSearch\_searchResults.cshtml"
                                    
            
            #line default
            #line hidden
            
            #line 55 "..\..\Views\TraineeshipSearch\_searchResults.cshtml"
                                     if (vacancy.NumberOfPositions == 1)
                                    {

            
            #line default
            #line hidden
WriteLiteral("                                        <span>- 1 position available)</span>\r\n");

            
            #line 58 "..\..\Views\TraineeshipSearch\_searchResults.cshtml"
                                    }
                                    else
                                    {

            
            #line default
            #line hidden
WriteLiteral("                                        <span>- ");

            
            #line 61 "..\..\Views\TraineeshipSearch\_searchResults.cshtml"
                                           Write(vacancy.NumberOfPositions);

            
            #line default
            #line hidden
WriteLiteral(" positions available)</span>\r\n");

            
            #line 62 "..\..\Views\TraineeshipSearch\_searchResults.cshtml"
                                    }

            
            #line default
            #line hidden
WriteLiteral("                                </span>\r\n                            </li>\r\n");

WriteLiteral("                        </ul>\r\n");

WriteLiteral("                    <p");

WriteAttribute("class", Tuple.Create(" class=\"", 3774), Tuple.Create("\"", 3834)
            
            #line 66 "..\..\Views\TraineeshipSearch\_searchResults.cshtml"
, Tuple.Create(Tuple.Create("", 3782), Tuple.Create<System.Object, System.Int32>(vacancy.Description.GetPreserveFormattingCssClass()
            
            #line default
            #line hidden
, 3782), false)
);

WriteLiteral(">");

            
            #line 66 "..\..\Views\TraineeshipSearch\_searchResults.cshtml"
                                                                               Write(vacancy.Description);

            
            #line default
            #line hidden
WriteLiteral("</p>\r\n");

WriteLiteral("                        <div");

WriteLiteral(" class=\"grid-row\"");

WriteLiteral(">\r\n                            <div");

WriteLiteral(" class=\"column-two-thirds\"");

WriteLiteral(">\r\n                                <ul");

WriteLiteral(" class=\"list sfa-no-margins vacancy-details-list\"");

WriteLiteral(">\r\n                                <li>\r\n                                        " +
"<span");

WriteLiteral(" class=\"bold-small\"");

WriteLiteral(">Distance:</span> <span");

WriteLiteral(" id=\"distance-value\"");

WriteLiteral(" class=\"distance-value\"");

WriteLiteral(">");

            
            #line 71 "..\..\Views\TraineeshipSearch\_searchResults.cshtml"
                                                                                                                              Write(vacancy.DistanceAsString);

            
            #line default
            #line hidden
WriteLiteral("</span> miles\r\n                                        <a");

WriteLiteral(" href=\"#\"");

WriteLiteral(" class=\"summary-style hide-nojs journey-trigger\"");

WriteLiteral(">Journey time</a>\r\n                                    <div");

WriteLiteral(" class=\"detail-content toggle-content hide-nojs\"");

WriteLiteral(">\r\n                                            <select");

WriteLiteral(" class=\"form-control select-mode\"");

WriteLiteral(" name=\"\"");

WriteLiteral(">\r\n                                            <option");

WriteLiteral(" value=\"DRIVING\"");

WriteLiteral(">Driving</option>\r\n                                            <option");

WriteLiteral(" value=\"TRANSIT\"");

WriteLiteral(">Bus/Train</option>\r\n                                            <option");

WriteLiteral(" value=\"WALKING\"");

WriteLiteral(">Walking</option>\r\n                                            <option");

WriteLiteral(" value=\"BICYCLING\"");

WriteLiteral(">Cycling</option>\r\n                                        </select>\r\n\r\n         " +
"                               <span");

WriteLiteral(" class=\"journey-time\"");

WriteLiteral("></span>\r\n                                    </div>\r\n                           " +
"     </li>\r\n                                    <li><span");

WriteLiteral(" class=\"bold-small\"");

WriteLiteral(">Closing date:</span> <span");

WriteLiteral(" id=\"closing-date-value\"");

WriteLiteral(" class=\"closing-date-value\"");

WriteLiteral(" data-date=\"");

            
            #line 84 "..\..\Views\TraineeshipSearch\_searchResults.cshtml"
                                                                                                                                                     Write(vacancy.ClosingDate.ToString("u"));

            
            #line default
            #line hidden
WriteLiteral("\"");

WriteLiteral(">");

            
            #line 84 "..\..\Views\TraineeshipSearch\_searchResults.cshtml"
                                                                                                                                                                                         Write(vacancy.ClosingDate.ToFriendlyClosingWeek());

            
            #line default
            #line hidden
WriteLiteral("</span></li>\r\n                                    <li><span");

WriteLiteral(" class=\"bold-small\"");

WriteLiteral(">Possible start date:</span><span");

WriteLiteral(" id=\"start-date-value\"");

WriteLiteral(" class=\"start-date-value\"");

WriteLiteral(">");

            
            #line 85 "..\..\Views\TraineeshipSearch\_searchResults.cshtml"
                                                                                                                                            Write(Html.DisplayFor(m => vacancy.StartDate, "Date"));

            
            #line default
            #line hidden
WriteLiteral("</span></li>\r\n                                    <li");

WriteLiteral(" class=\"sfa-hide-tablet\"");

WriteLiteral(">\r\n                                        <a");

WriteLiteral(" href=\"#1\"");

WriteLiteral(" style=\"margin-left: 0;\"");

WriteLiteral(" class=\"summary-style mob-map-trigger map-closed\"");

WriteLiteral(">Show/hide map</a>\r\n                                    </li>\r\n                  " +
"          </ul>\r\n                        </div>\r\n                            <di" +
"v");

WriteLiteral(" class=\"column-one-third map-container hide-nojs sfa-small-bottom-margin toggle-c" +
"ontent--mob\"");

WriteLiteral(">\r\n                            <a");

WriteAttribute("href", Tuple.Create(" href=\"", 6065), Tuple.Create("\"", 6175)
, Tuple.Create(Tuple.Create("", 6072), Tuple.Create("https://www.google.com/maps/dir/LocationLatLon/\'", 6072), true)
            
            #line 92 "..\..\Views\TraineeshipSearch\_searchResults.cshtml"
     , Tuple.Create(Tuple.Create("", 6120), Tuple.Create<System.Object, System.Int32>(vacancy.Location.Latitude
            
            #line default
            #line hidden
, 6120), false)
, Tuple.Create(Tuple.Create("", 6146), Tuple.Create(",", 6146), true)
            
            #line 92 "..\..\Views\TraineeshipSearch\_searchResults.cshtml"
                                , Tuple.Create(Tuple.Create("", 6147), Tuple.Create<System.Object, System.Int32>(vacancy.Location.Longitude
            
            #line default
            #line hidden
, 6147), false)
, Tuple.Create(Tuple.Create("", 6174), Tuple.Create("\'", 6174), true)
);

WriteLiteral(" target=\"_blank\"");

WriteLiteral(" rel=\"external\"");

WriteLiteral(" class=\"map-links fake-link font-xxsmall view-googlemaps\"");

WriteLiteral(">Open map</a>\r\n                                <div");

WriteLiteral(" class=\"map-placeholder\"");

WriteLiteral("></div>\r\n                                <img");

WriteLiteral(" class=\"static-map\"");

WriteAttribute("src", Tuple.Create(" src=\"", 6403), Tuple.Create("\"", 6437)
            
            #line 94 "..\..\Views\TraineeshipSearch\_searchResults.cshtml"
, Tuple.Create(Tuple.Create("", 6409), Tuple.Create<System.Object, System.Int32>(vacancy.GoogleStaticMapsUrl
            
            #line default
            #line hidden
, 6409), false)
);

WriteLiteral(" />\r\n                        </div>\r\n                    </div>\r\n");

WriteLiteral("                </li>\r\n");

            
            #line 98 "..\..\Views\TraineeshipSearch\_searchResults.cshtml"
                itemPosition++;
            }
        }

            
            #line default
            #line hidden
WriteLiteral("    </ul>\r\n");

            
            #line 102 "..\..\Views\TraineeshipSearch\_searchResults.cshtml"

    Html.RenderPartial("_pagination", Model);

    if (Model.TotalHits > 5)
    {

            
            #line default
            #line hidden
WriteLiteral("        <div");

WriteLiteral(" class=\"form-group sfa-medium-top-margin\"");

WriteLiteral(">\r\n            <label");

WriteLiteral(" for=\"results-per-page\"");

WriteLiteral(" class=\"heading-small inline\"");

WriteLiteral(">Display results</label>\r\n");

WriteLiteral("            ");

            
            #line 109 "..\..\Views\TraineeshipSearch\_searchResults.cshtml"
       Write(Html.DropDownList("resultsPerPage", Model.ResultsPerPageSelectList, new { @id = "results-per-page", @class = "form-control form-control-auto" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n            <noscript>\r\n                <button");

WriteLiteral(" class=\"button show-nojs\"");

WriteLiteral(" name=\"ChangeResultsPerPageAction\"");

WriteLiteral(" value=\"ResultsPerPage\"");

WriteLiteral(">View</button>\r\n            </noscript>\r\n        </div>\r\n");

            
            #line 114 "..\..\Views\TraineeshipSearch\_searchResults.cshtml"
    }
}

            
            #line default
            #line hidden
        }
    }
}
#pragma warning restore 1591
