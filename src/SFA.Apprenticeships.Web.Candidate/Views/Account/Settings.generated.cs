﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.0
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SFA.Apprenticeships.Web.Candidate.Views.Account
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
    using SFA.Apprenticeships.Web.Candidate;
    using SFA.Apprenticeships.Web.Candidate.Constants;
    using SFA.Apprenticeships.Web.Candidate.Constants.ViewModels;
    using SFA.Apprenticeships.Web.Candidate.Helpers;
    using SFA.Apprenticeships.Web.Candidate.ViewModels;
    
    #line 1 "..\..\Views\Account\Settings.cshtml"
    using SFA.Apprenticeships.Web.Candidate.ViewModels.Account;
    
    #line default
    #line hidden
    using SFA.Apprenticeships.Web.Candidate.ViewModels.Candidate;
    using SFA.Apprenticeships.Web.Candidate.ViewModels.Locations;
    using SFA.Apprenticeships.Web.Candidate.ViewModels.Login;
    using SFA.Apprenticeships.Web.Candidate.ViewModels.Register;
    using SFA.Apprenticeships.Web.Candidate.ViewModels.VacancySearch;
    using SFA.Apprenticeships.Web.Common.Constants;
    using SFA.Apprenticeships.Web.Common.Framework;
    using SFA.Apprenticeships.Web.Common.Models.Common;
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/Account/Settings.cshtml")]
    public partial class Settings : System.Web.Mvc.WebViewPage<SettingsViewModel>
    {
        public Settings()
        {
        }
        public override void Execute()
        {
WriteLiteral("\r\n");

            
            #line 5 "..\..\Views\Account\Settings.cshtml"
  
    ViewBag.Title = "Settings - Find an apprenticeship";
    Layout = "~/Views/Shared/_Layout.cshtml";

            
            #line default
            #line hidden
WriteLiteral("\r\n<div");

WriteLiteral(" class=\"grid-wrapper\"");

WriteLiteral(">\r\n    <div");

WriteLiteral(" class=\"grid grid-1-2\"");

WriteLiteral(">\r\n        <h1");

WriteLiteral(" class=\"heading-xlarge\"");

WriteLiteral(">Settings</h1>\r\n    </div>\r\n    <div");

WriteLiteral(" class=\"grid grid-1-2\"");

WriteLiteral(">\r\n");

WriteLiteral("        ");

            
            #line 14 "..\..\Views\Account\Settings.cshtml"
   Write(Html.RouteLink("Find an apprenticeship", CandidateRouteNames.ApprenticeshipSearch, null, new { id = "find-apprenticeship-link", @class = "page-link small-btm-margin" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n\r\n");

            
            #line 16 "..\..\Views\Account\Settings.cshtml"
        
            
            #line default
            #line hidden
            
            #line 16 "..\..\Views\Account\Settings.cshtml"
         if (Model.TraineeshipFeature.ShowTraineeshipsLink)
        {
            
            
            #line default
            #line hidden
            
            #line 18 "..\..\Views\Account\Settings.cshtml"
       Write(Html.RouteLink("Find a traineeship", CandidateRouteNames.TraineeshipSearch, null, new { id = "find-traineeship-link", @class = "page-link small-btm-margin" }));

            
            #line default
            #line hidden
            
            #line 18 "..\..\Views\Account\Settings.cshtml"
                                                                                                                                                                           
        }

            
            #line default
            #line hidden
WriteLiteral("    </div>\r\n</div>\r\n\r\n");

            
            #line 23 "..\..\Views\Account\Settings.cshtml"
 using (Html.BeginRouteForm(CandidateRouteNames.Settings, FormMethod.Post))
{
    
            
            #line default
            #line hidden
            
            #line 25 "..\..\Views\Account\Settings.cshtml"
Write(Html.AntiForgeryToken());

            
            #line default
            #line hidden
            
            #line 25 "..\..\Views\Account\Settings.cshtml"
                            
    
            
            #line default
            #line hidden
            
            #line 26 "..\..\Views\Account\Settings.cshtml"
Write(Html.Partial("ValidationSummary", ViewData.ModelState));

            
            #line default
            #line hidden
            
            #line 26 "..\..\Views\Account\Settings.cshtml"
                                                           


            
            #line default
            #line hidden
WriteLiteral("    <fieldset>\r\n\r\n");

            
            #line 30 "..\..\Views\Account\Settings.cshtml"
        
            
            #line default
            #line hidden
            
            #line 30 "..\..\Views\Account\Settings.cshtml"
          
            var yourAccountTabClass = Model.Mode == SettingsViewModel.SettingsMode.YourAccount ? " active" : "";
            var savedSearchesTabClass = Model.Mode == SettingsViewModel.SettingsMode.SavedSearches ? " active" : "";
        
            
            #line default
            #line hidden
WriteLiteral("\r\n\r\n        <nav");

WriteLiteral(" class=\"tabbed-nav\"");

WriteLiteral(">\r\n");

WriteLiteral("            ");

            
            #line 36 "..\..\Views\Account\Settings.cshtml"
       Write(Html.RouteLink("Your account", CandidateRouteNames.Settings, null, new { @id = "your-account-tab-control", @class = "tabbed-tab" + yourAccountTabClass, tab = "#tab1" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("            ");

            
            #line 37 "..\..\Views\Account\Settings.cshtml"
       Write(Html.RouteLink("Saved searches", CandidateRouteNames.SavedSearchesSettings, null, new { @id = "saved-searches-tab-control", @class = "tabbed-tab" + savedSearchesTabClass, tab = "#tab2" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n        </nav>\r\n\r\n");

WriteLiteral("        ");

            
            #line 40 "..\..\Views\Account\Settings.cshtml"
   Write(Html.HiddenFor(m => m.Mode));

            
            #line default
            #line hidden
WriteLiteral("\r\n\r\n        <div");

WriteAttribute("class", Tuple.Create(" class=\"", 1755), Tuple.Create("\"", 1798)
, Tuple.Create(Tuple.Create("", 1763), Tuple.Create("tabbed-content", 1763), true)
            
            #line 42 "..\..\Views\Account\Settings.cshtml"
, Tuple.Create(Tuple.Create(" ", 1777), Tuple.Create<System.Object, System.Int32>(yourAccountTabClass
            
            #line default
            #line hidden
, 1778), false)
);

WriteLiteral(">\r\n\r\n            <legend");

WriteLiteral(" class=\"heading-large\"");

WriteLiteral(">Personal details</legend>\r\n\r\n            <div");

WriteLiteral(" class=\"panel-indent\"");

WriteLiteral(">\r\n                <p");

WriteLiteral(" class=\"text\"");

WriteLiteral(">Any changes you make will be seen on draft or new applications. Submitted applic" +
"ations will continue to show your old details.</p>\r\n            </div>\r\n\r\n");

WriteLiteral("            ");

            
            #line 50 "..\..\Views\Account\Settings.cshtml"
       Write(Html.FormTextFor(m => m.Firstname, containerHtmlAttributes: new { @class = "form-group-compound" }, controlHtmlAttributes: new { type = "text", autocorrect = "off" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("            ");

            
            #line 51 "..\..\Views\Account\Settings.cshtml"
       Write(Html.FormTextFor(m => m.Lastname, controlHtmlAttributes: new { type = "text", autocorrect = "off" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("            ");

            
            #line 52 "..\..\Views\Account\Settings.cshtml"
       Write(Html.EditorFor(r => r.DateOfBirth));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("            ");

            
            #line 53 "..\..\Views\Account\Settings.cshtml"
       Write(Html.EditorFor(a => a.Address, new { AnalyticsDSCUri = "/settings/findaddress" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("            ");

            
            #line 54 "..\..\Views\Account\Settings.cshtml"
       Write(Html.FormTextFor(m => m.PhoneNumber, controlHtmlAttributes: new { @class = "form-control", type = "tel" }, verified: Model.VerifiedMobile));

            
            #line default
            #line hidden
WriteLiteral("\r\n\r\n            <div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(">\r\n                <p");

WriteLiteral(" class=\"form-label\"");

WriteLiteral(">Email</p>\r\n                <span");

WriteLiteral(" class=\"form-prepopped\"");

WriteLiteral(" id=\"settings-username\"");

WriteLiteral(">");

            
            #line 58 "..\..\Views\Account\Settings.cshtml"
                                                               Write(Model.Username);

            
            #line default
            #line hidden
WriteLiteral("</span>\r\n                <a");

WriteLiteral(" id=\"settings-change-username\"");

WriteLiteral(" class=\"inl-block\"");

WriteAttribute("href", Tuple.Create(" href=\"", 2942), Tuple.Create("\"", 2986)
            
            #line 59 "..\..\Views\Account\Settings.cshtml"
, Tuple.Create(Tuple.Create("", 2949), Tuple.Create<System.Object, System.Int32>(Url.RouteUrl(RouteNames.UpdateEmail)
            
            #line default
            #line hidden
, 2949), false)
);

WriteLiteral(">Change email address</a>\r\n            </div>\r\n\r\n");

            
            #line 62 "..\..\Views\Account\Settings.cshtml"
            
            
            #line default
            #line hidden
            
            #line 62 "..\..\Views\Account\Settings.cshtml"
             if (!string.IsNullOrWhiteSpace(Model.PendingUsername))
            {

            
            #line default
            #line hidden
WriteLiteral("                <div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(">\r\n                    <p");

WriteLiteral(" class=\"form-label\"");

WriteLiteral(">Pending Email Update</p>\r\n                    <span");

WriteLiteral(" class=\"form-prepopped\"");

WriteLiteral(" id=\"settings-pending-username\"");

WriteLiteral(">");

            
            #line 66 "..\..\Views\Account\Settings.cshtml"
                                                                           Write(Model.PendingUsername);

            
            #line default
            #line hidden
WriteLiteral("</span>\r\n                    <a");

WriteLiteral(" id=\"settings-confirm-username\"");

WriteLiteral(" class=\"inl-block\"");

WriteAttribute("href", Tuple.Create(" href=\"", 3412), Tuple.Create("\"", 3463)
            
            #line 67 "..\..\Views\Account\Settings.cshtml"
, Tuple.Create(Tuple.Create("", 3419), Tuple.Create<System.Object, System.Int32>(Url.RouteUrl(RouteNames.VerifyUpdatedEmail)
            
            #line default
            #line hidden
, 3419), false)
);

WriteLiteral(">Verify new email address</a>\r\n                </div>\r\n");

            
            #line 69 "..\..\Views\Account\Settings.cshtml"
            }

            
            #line default
            #line hidden
WriteLiteral("            \r\n            <details>\r\n                <summary");

WriteLiteral(" id=\"equality-diversity-summary-link\"");

WriteLiteral(">Your equality and diversity information</summary>\r\n                <div");

WriteLiteral(" class=\"detail-content\"");

WriteLiteral(">\r\n");

WriteLiteral("                    ");

            
            #line 74 "..\..\Views\Account\Settings.cshtml"
               Write(Html.EditorFor(m => Model.MonitoringInformation, "MonitoringInformation/_gender"));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("                    ");

            
            #line 75 "..\..\Views\Account\Settings.cshtml"
               Write(Html.EditorFor(m => Model.MonitoringInformation, "MonitoringInformation/_disability"));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("                    ");

            
            #line 76 "..\..\Views\Account\Settings.cshtml"
               Write(Html.EditorFor(m => Model.MonitoringInformation, "MonitoringInformation/_ethnicity"));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("                    ");

            
            #line 77 "..\..\Views\Account\Settings.cshtml"
               Write(Html.EditorFor(m => Model.MonitoringInformation, "MonitoringInformation/_why"));

            
            #line default
            #line hidden
WriteLiteral("\r\n                </div>\r\n            </details>\r\n\r\n            <div");

WriteLiteral(" id=\"accountSettings2\"");

WriteLiteral(">\r\n                <h3");

WriteLiteral(" class=\"heading-large\"");

WriteLiteral(">How we contact you</h3>\r\n                <div");

WriteLiteral(" class=\"text para-btm-margin\"");

WriteLiteral(">\r\n                    <p");

WriteLiteral(" class=\"small-btm-margin\"");

WriteLiteral(">\r\n                        Choose to be notified by <i");

WriteLiteral(" class=\"fa fa-envelope-o no-right-margin\"");

WriteLiteral("></i> email or <i");

WriteLiteral(" class=\"icon-sms\"");

WriteLiteral("></i> text when:\r\n                    </p>\r\n                    <div");

WriteLiteral(" class=\"display-table\"");

WriteLiteral(">\r\n                        <div");

WriteLiteral(" class=\"display-table__row va-bottom\"");

WriteLiteral(">\r\n                            <a");

WriteLiteral(" href=\"#\"");

WriteLiteral(" id=\"emailToggle\"");

WriteLiteral(" title=\"Email notifications\"");

WriteLiteral(" class=\"display-table__cell ta-center font-black\"");

WriteLiteral(">\r\n                                <span");

WriteLiteral(" class=\"notification-pulltop\"");

WriteLiteral("><i");

WriteLiteral(" class=\"fa fa-envelope-o no-right-margin\"");

WriteLiteral("></i></span>\r\n                            </a>\r\n                            <a");

WriteLiteral(" href=\"#\"");

WriteLiteral(" id=\"textToggle\"");

WriteLiteral(" title=\"Text notifications\"");

WriteLiteral(" class=\"display-table__cell ta-center\"");

WriteLiteral(">\r\n                                <i");

WriteLiteral(" class=\"icon-sms\"");

WriteLiteral("></i>\r\n                            </a>\r\n                            <span");

WriteLiteral(" class=\"display-table__cell ta-left\"");

WriteLiteral(">\r\n                            </span>\r\n                        </div>\r\n         " +
"               <div");

WriteLiteral(" class=\"display-table__row\"");

WriteLiteral(">\r\n                            <span");

WriteLiteral(" class=\"display-table__cell ta-center\"");

WriteLiteral(">\r\n");

WriteLiteral("                                ");

            
            #line 100 "..\..\Views\Account\Settings.cshtml"
                           Write(Html.FormUnvalidatedCheckBoxFor(m => m.EnableApplicationStatusChangeAlertsViaEmail,
                                    controlHtmlAttributes: new { @class = "no-margins email-input", aria_labelledby = "appStatusLabel", title = "Email notifications when the status of one of your applications changes" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                            </span>\r\n                            <span");

WriteLiteral(" class=\"display-table__cell ta-center\"");

WriteLiteral(">\r\n");

WriteLiteral("                                ");

            
            #line 104 "..\..\Views\Account\Settings.cshtml"
                           Write(Html.FormUnvalidatedCheckBoxFor(m => m.EnableApplicationStatusChangeAlertsViaText,
                                    controlHtmlAttributes: new { @class = "no-margins text-input", aria_labelledby = "appStatusLabel", title = "Text notifications when the status of one of your applications changes" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                            </span>\r\n                            <span");

WriteLiteral(" class=\"display-table__cell ta-left\"");

WriteLiteral(" id=\"appStatusLabel\"");

WriteLiteral(">\r\n                                the status of one of your applications changes" +
"\r\n                            </span>\r\n                        </div>\r\n         " +
"               <div");

WriteLiteral(" class=\"display-table__row\"");

WriteLiteral(">\r\n                            <span");

WriteLiteral(" class=\"display-table__cell ta-center\"");

WriteLiteral(">\r\n");

WriteLiteral("                                ");

            
            #line 113 "..\..\Views\Account\Settings.cshtml"
                           Write(Html.FormUnvalidatedCheckBoxFor(m => m.EnableExpiringApplicationAlertsViaEmail,
                                    controlHtmlAttributes: new { @class = "no-margins email-input", aria_labelledby = "closingDateStatusLabel", title = "Email notifications when an apprenticeship is approaching its closing date" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                            </span>\r\n                            <span");

WriteLiteral(" class=\"display-table__cell ta-center\"");

WriteLiteral(">\r\n");

WriteLiteral("                                ");

            
            #line 117 "..\..\Views\Account\Settings.cshtml"
                           Write(Html.FormUnvalidatedCheckBoxFor(m => m.EnableExpiringApplicationAlertsViaText,
                                    controlHtmlAttributes: new { @class = "no-margins text-input", aria_labelledby = "closingDateStatusLabel", title = "Text notifications when an apprenticeship is approaching its closing date" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                            </span>\r\n                            <span");

WriteLiteral(" class=\"display-table__cell ta-left\"");

WriteLiteral(" id=\"closingDateStatusLabel\"");

WriteLiteral(">\r\n                                an apprenticeship is approaching its closing d" +
"ate\r\n                            </span>\r\n                        </div>\r\n      " +
"                  <div");

WriteLiteral(" class=\"display-table__row\"");

WriteLiteral(">\r\n                            <span");

WriteLiteral(" class=\"display-table__cell ta-center\"");

WriteLiteral(">\r\n");

WriteLiteral("                                ");

            
            #line 126 "..\..\Views\Account\Settings.cshtml"
                           Write(Html.FormUnvalidatedCheckBoxFor(m => m.EnableMarketingViaEmail,
                                    controlHtmlAttributes: new { @class = "no-margins email-input", aria_labelledby = "marketingUpdatesStatusLabel", title = "Email notifications when we send you updates on news and information" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                            </span>\r\n                            <span");

WriteLiteral(" class=\"display-table__cell ta-center\"");

WriteLiteral(">\r\n");

WriteLiteral("                                ");

            
            #line 130 "..\..\Views\Account\Settings.cshtml"
                           Write(Html.FormUnvalidatedCheckBoxFor(m => m.EnableMarketingViaText,
                                    controlHtmlAttributes: new { @class = "no-margins text-input", aria_labelledby = "marketingUpdatesStatusLabel", title = "Text notifications when we send you updates on news and information" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                            </span>\r\n                            <span");

WriteLiteral(" class=\"display-table__cell ta-left\"");

WriteLiteral(" id=\"marketingUpdatesStatusLabel\"");

WriteLiteral(">\r\n                                we send you updates on news and information\r\n " +
"                           </span>\r\n                        </div>\r\n            " +
"        </div>\r\n                </div>\r\n            </div>\r\n            <div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(">\r\n                <button");

WriteLiteral(" id=\"update-details-button\"");

WriteLiteral(" class=\"button\"");

WriteLiteral(">Save settings</button>\r\n            </div>\r\n        </div>\r\n\r\n        <div");

WriteAttribute("class", Tuple.Create(" class=\"", 9206), Tuple.Create("\"", 9251)
, Tuple.Create(Tuple.Create("", 9214), Tuple.Create("tabbed-content", 9214), true)
            
            #line 145 "..\..\Views\Account\Settings.cshtml"
, Tuple.Create(Tuple.Create(" ", 9228), Tuple.Create<System.Object, System.Int32>(savedSearchesTabClass
            
            #line default
            #line hidden
, 9229), false)
);

WriteLiteral(">\r\n            <h2");

WriteLiteral(" class=\"heading-large\"");

WriteLiteral(" id=\"savedSearchHeading\"");

WriteLiteral(">Saved searches</h2>\r\n            <div");

WriteLiteral(" class=\"form-group form-group-compound\"");

WriteLiteral(">\r\n                <p");

WriteLiteral(" class=\"form-label\"");

WriteLiteral(">Receive notifications?</p>\r\n                <span");

WriteLiteral(" class=\"form-hint text\"");

WriteLiteral(">If you don\'t select an option you won\'t receive notifications</span>\r\n");

WriteLiteral("                ");

            
            #line 150 "..\..\Views\Account\Settings.cshtml"
           Write(Html.FormUnvalidatedCheckBoxFor(m => m.EnableSavedSearchAlertsViaEmail, labelHtmlAttributes: new { @class = "block-label allowSavedComms" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

            
            #line 151 "..\..\Views\Account\Settings.cshtml"
                
            
            #line default
            #line hidden
            
            #line 151 "..\..\Views\Account\Settings.cshtml"
                 if (Model.SmsEnabled)
                {
                    
            
            #line default
            #line hidden
            
            #line 153 "..\..\Views\Account\Settings.cshtml"
               Write(Html.FormUnvalidatedCheckBoxFor(m => m.EnableSavedSearchAlertsViaText, labelHtmlAttributes: new { @class = "block-label allowSavedComms" }));

            
            #line default
            #line hidden
            
            #line 153 "..\..\Views\Account\Settings.cshtml"
                                                                                                                                                                
                }

            
            #line default
            #line hidden
WriteLiteral("            </div>\r\n\r\n            <div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(" id=\"savedSearch\"");

WriteLiteral(">\r\n");

            
            #line 158 "..\..\Views\Account\Settings.cshtml"
                
            
            #line default
            #line hidden
            
            #line 158 "..\..\Views\Account\Settings.cshtml"
                  
                    var noSavedSearchesTextStyle = (Model.SavedSearches != null && Model.SavedSearches.Count > 0) ? "style=\"display: none\"" : "";
                
            
            #line default
            #line hidden
WriteLiteral("\r\n\r\n                <p");

WriteLiteral(" class=\"savedInitalText text\"");

WriteLiteral(" id=\"noSavedSearchesText\"");

WriteLiteral(" ");

            
            #line 162 "..\..\Views\Account\Settings.cshtml"
                                                                    Write(Html.Raw(noSavedSearchesTextStyle));

            
            #line default
            #line hidden
WriteLiteral(">\r\n                    You currently don\'t have any active saved searches. If you" +
" <a");

WriteAttribute("href", Tuple.Create(" href=\"", 10435), Tuple.Create("\"", 10497)
            
            #line 163 "..\..\Views\Account\Settings.cshtml"
       , Tuple.Create(Tuple.Create("", 10442), Tuple.Create<System.Object, System.Int32>(Url.RouteUrl(CandidateRouteNames.ApprenticeshipSearch)
            
            #line default
            #line hidden
, 10442), false)
);

WriteLiteral(">set up a saved search</a> we can alert you when we find a suitable apprenticeshi" +
"p.\r\n                </p>\r\n\r\n");

            
            #line 166 "..\..\Views\Account\Settings.cshtml"
                
            
            #line default
            #line hidden
            
            #line 166 "..\..\Views\Account\Settings.cshtml"
                 if (Model.SavedSearches != null)
                {

            
            #line default
            #line hidden
WriteLiteral("                        <div");

WriteLiteral(" id=\"savedSearches\"");

WriteLiteral(" class=\"toggle-content text\"");

WriteLiteral(" style=\"display: block;\"");

WriteLiteral(">\r\n");

            
            #line 169 "..\..\Views\Account\Settings.cshtml"
                        
            
            #line default
            #line hidden
            
            #line 169 "..\..\Views\Account\Settings.cshtml"
                         for (var i = 0; i < Model.SavedSearches.Count; i++)
                        {
                            var index = i;
                            var savedSearch = Model.SavedSearches[i];
                            var checkedListItemClass = savedSearch.AlertsEnabled ? "class=\"selected\"" : "";


            
            #line default
            #line hidden
WriteLiteral("                            <div");

WriteLiteral(" class=\"para-btm-margin saved-search\"");

WriteAttribute("id", Tuple.Create(" id=\"", 11181), Tuple.Create("\"", 11201)
            
            #line 175 "..\..\Views\Account\Settings.cshtml"
, Tuple.Create(Tuple.Create("", 11186), Tuple.Create<System.Object, System.Int32>(savedSearch.Id
            
            #line default
            #line hidden
, 11186), false)
);

WriteLiteral(">\r\n                                <a");

WriteAttribute("href", Tuple.Create(" href=\"", 11239), Tuple.Create("\"", 11284)
            
            #line 176 "..\..\Views\Account\Settings.cshtml"
, Tuple.Create(Tuple.Create("", 11246), Tuple.Create<System.Object, System.Int32>(Html.Raw(savedSearch.SearchUrl.Value)
            
            #line default
            #line hidden
, 11246), false)
);

WriteLiteral(" title=\"Run search\"");

WriteLiteral(">");

            
            #line 176 "..\..\Views\Account\Settings.cshtml"
                                                                                               Write(savedSearch.Name);

            
            #line default
            #line hidden
WriteLiteral("</a>\r\n");

            
            #line 177 "..\..\Views\Account\Settings.cshtml"
                                
            
            #line default
            #line hidden
            
            #line 177 "..\..\Views\Account\Settings.cshtml"
                                 if (savedSearch.DateProcessed.HasValue)
                                {

            
            #line default
            #line hidden
WriteLiteral("                                    <span");

WriteLiteral(" class=\"inl-block font-xsmall\"");

WriteLiteral(">(Last alert: ");

            
            #line 179 "..\..\Views\Account\Settings.cshtml"
                                                                                Write(savedSearch.DateProcessed.Value.ToFriendlyDaysAgo());

            
            #line default
            #line hidden
WriteLiteral(")</span>\r\n");

            
            #line 180 "..\..\Views\Account\Settings.cshtml"
                                }

            
            #line default
            #line hidden
WriteLiteral("                                <ul");

WriteLiteral(" class=\"list-text\"");

WriteLiteral(">\r\n");

            
            #line 182 "..\..\Views\Account\Settings.cshtml"
                                    
            
            #line default
            #line hidden
            
            #line 182 "..\..\Views\Account\Settings.cshtml"
                                     if (!string.IsNullOrEmpty(savedSearch.SubCategoriesFullNames))
                                    {

            
            #line default
            #line hidden
WriteLiteral("                                        <li><b>Sub-categories:</b> ");

            
            #line 184 "..\..\Views\Account\Settings.cshtml"
                                                              Write(savedSearch.SubCategoriesFullNames);

            
            #line default
            #line hidden
WriteLiteral("</li>\r\n");

            
            #line 185 "..\..\Views\Account\Settings.cshtml"
                                    }

            
            #line default
            #line hidden
WriteLiteral("                                    ");

            
            #line 186 "..\..\Views\Account\Settings.cshtml"
                                     if (savedSearch.ApprenticeshipLevel != "All")
                                    {

            
            #line default
            #line hidden
WriteLiteral("                                        <li><b>Apprenticeship level:</b> ");

            
            #line 188 "..\..\Views\Account\Settings.cshtml"
                                                                    Write(savedSearch.ApprenticeshipLevel);

            
            #line default
            #line hidden
WriteLiteral("</li>\r\n");

            
            #line 189 "..\..\Views\Account\Settings.cshtml"
                                    }

            
            #line default
            #line hidden
WriteLiteral("                                    <li ");

            
            #line 190 "..\..\Views\Account\Settings.cshtml"
                                   Write(Html.Raw(checkedListItemClass));

            
            #line default
            #line hidden
WriteLiteral(">\r\n");

WriteLiteral("                                        ");

            
            #line 191 "..\..\Views\Account\Settings.cshtml"
                                   Write(Html.HiddenFor(m => m.SavedSearches[index].Id));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("                                        ");

            
            #line 192 "..\..\Views\Account\Settings.cshtml"
                                   Write(Html.FormUnvalidatedCheckBoxFor(m => m.SavedSearches[index].AlertsEnabled, controlHtmlAttributes: new { @class = "no-left-margin" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                                    </li>\r\n                                    " +
"<li>\r\n                                        <a");

WriteAttribute("href", Tuple.Create(" href=\"", 12702), Tuple.Create("\"", 12790)
            
            #line 195 "..\..\Views\Account\Settings.cshtml"
, Tuple.Create(Tuple.Create("", 12709), Tuple.Create<System.Object, System.Int32>(Url.Action("DeleteSavedSearch", new {id = savedSearch.Id, isJavascript = false})
            
            #line default
            #line hidden
, 12709), false)
);

WriteAttribute("id", Tuple.Create(" id=\"", 12791), Tuple.Create("\"", 12811)
            
            #line 195 "..\..\Views\Account\Settings.cshtml"
                                                       , Tuple.Create(Tuple.Create("", 12796), Tuple.Create<System.Object, System.Int32>(savedSearch.Id
            
            #line default
            #line hidden
, 12796), false)
);

WriteLiteral(" class=\"link-unimp icon-black delete-saved-search-link\"");

WriteLiteral(">\r\n                                            <i");

WriteLiteral(" class=\"fa fa-times-circle\"");

WriteLiteral("></i>Delete saved search\r\n                                        </a>\r\n         " +
"                           </li>\r\n                                </ul>\r\n       " +
"                     </div>\r\n");

            
            #line 201 "..\..\Views\Account\Settings.cshtml"
                        }

            
            #line default
            #line hidden
WriteLiteral("                    </div>\r\n");

            
            #line 203 "..\..\Views\Account\Settings.cshtml"
                }

            
            #line default
            #line hidden
WriteLiteral("\r\n                <div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(">\r\n                    <button");

WriteLiteral(" id=\"update-details-button\"");

WriteLiteral(" class=\"button\"");

WriteLiteral(">Save settings</button>\r\n                </div>\r\n            </div>\r\n        </di" +
"v>\r\n    </fieldset>\r\n");

            
            #line 211 "..\..\Views\Account\Settings.cshtml"
}

            
            #line default
            #line hidden
WriteLiteral("\r\n");

DefineSection("scripts", () => {

WriteLiteral("\r\n    <script>\r\n        $(function () {\r\n            $(\"#find-addresses\").address" +
"Lookup({\r\n                url: \'");

            
            #line 218 "..\..\Views\Account\Settings.cshtml"
                 Write(Url.Action("Addresses", "Location"));

            
            #line default
            #line hidden
WriteLiteral("\',\r\n                selectlist: \'#address-select\'\r\n            });\r\n\r\n           " +
" $(\".delete-saved-search-link\").on(\'click\', function () {\r\n                var $" +
"this = $(this),\r\n                    $href = $this.attr(\'href\').replace(\"isJavas" +
"cript=False\", \"isJavascript=true\").replace(\"isJavascript=false\", \"isJavascript=t" +
"rue\"),\r\n                    $id = $this.attr(\'id\');\r\n\r\n                $.ajax({\r" +
"\n                    url: $href,\r\n                    complete: function (result" +
") {\r\n\r\n                        if (result.status == 200) {\r\n                    " +
"        $(\"#\" + $id).hide();\r\n\r\n                            if ($(\".saved-search" +
":visible\").length == 0) {\r\n                                $(\"#noSavedSearchesTe" +
"xt\").show();\r\n                            }\r\n                        }\r\n        " +
"            }\r\n                });\r\n\r\n                return false;\r\n           " +
" });\r\n\r\n            $(\'#emailToggle\').on(\'click\', function () {\r\n               " +
" var theTable = $(this).closest(\'.display-table\');\r\n\r\n                if (theTab" +
"le.find(\'.email-input:checked\').length == 3) {\r\n                    theTable.fin" +
"d(\'.email-input:checked\').click();\r\n                } else {\r\n                  " +
"  theTable.find(\'.email-input:not(:checked)\').click();\r\n                }\r\n\r\n   " +
"             $(this).blur();\r\n\r\n                return false;\r\n\r\n            });" +
"\r\n\r\n            $(\'#textToggle\').on(\'click\', function () {\r\n                var " +
"theTable = $(this).closest(\'.display-table\');\r\n\r\n                if (theTable.fi" +
"nd(\'.text-input:checked\').length == 3) {\r\n                    theTable.find(\'.te" +
"xt-input:checked\').click();\r\n                } else {\r\n                    theTa" +
"ble.find(\'.text-input:not(:checked)\').click();\r\n                }\r\n\r\n           " +
"     $(this).blur();\r\n\r\n                return false;\r\n\r\n            });\r\n\r\n    " +
"        if ($(\'#disability-support-yes\').is(\':checked\')) {\r\n                $(\'#" +
"equality-diversity-summary-link\').click();\r\n            }\r\n\r\n        });\r\n    </" +
"script>\r\n");

});

        }
    }
}
#pragma warning restore 1591
