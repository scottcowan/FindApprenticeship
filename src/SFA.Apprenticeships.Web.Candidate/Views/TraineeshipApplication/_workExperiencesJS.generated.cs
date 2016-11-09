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

namespace SFA.Apprenticeships.Web.Candidate.Views.TraineeshipApplication
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
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/TraineeshipApplication/_workExperiencesJS.cshtml")]
    public partial class workExperiencesJS : System.Web.Mvc.WebViewPage<SFA.Apprenticeships.Web.Candidate.ViewModels.Applications.TraineeshipApplicationViewModel>
    {
        public workExperiencesJS()
        {
        }
        public override void Execute()
        {
WriteLiteral("<div");

WriteLiteral(" class=\"hide-nojs\"");

WriteLiteral(" data-enter-action=\"#addWorkBtn\"");

WriteLiteral(" data-bind=\"visible: selectedSection() === \'applyWorkExperience\', stopBinding: tr" +
"ue\"");

WriteLiteral(">\r\n\r\n    <fieldset");

WriteLiteral(" id=\"applyWorkExperience\"");

WriteLiteral(" class=\"fieldset-with-border\"");

WriteLiteral(">\r\n        <legend");

WriteLiteral(" class=\"heading-large\"");

WriteLiteral(">Work experience</legend>\r\n        <p");

WriteLiteral(" class=\"hide-nojs form-label text\"");

WriteLiteral(" id=\"workExpQuestion\"");

WriteLiteral(">Do you have any work experience?</p>\r\n        <p");

WriteLiteral(" class=\"form-hint text\"");

WriteLiteral(">\r\n            Please include any work, whether paid or voluntary\r\n        </p>\r\n" +
"        <div");

WriteLiteral(" class=\"hide-nojs\"");

WriteLiteral(">\r\n            <div");

WriteLiteral(" class=\"form-group inline clearfix\"");

WriteLiteral(">\r\n                <label");

WriteLiteral(" data-target=\"workexperience-panel\"");

WriteLiteral(" for=\"workexp-yes\"");

WriteLiteral(" class=\"block-label\"");

WriteLiteral(" data-bind=\"css: {selected: showWorkExperience()}\"");

WriteLiteral(">\r\n");

WriteLiteral("                    ");

            
            #line 14 "..\..\Views\TraineeshipApplication\_workExperiencesJS.cshtml"
               Write(Html.RadioButtonFor(m => m.Candidate.HasWorkExperience, true, new { id = "workexp-yes", data_bind = "attr:{'checked': hasWorkExperience() }", aria_controls = "workexperience-panel", aria_expanded = "false", aria_labelledby = "workExpQuestion" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                    Yes\r\n                </label>\r\n                <label");

WriteLiteral(" for=\"workexp-no\"");

WriteLiteral(" class=\"block-label\"");

WriteLiteral(" data-bind=\"css: {selected: !showWorkExperience()}\"");

WriteLiteral(">\r\n");

WriteLiteral("                    ");

            
            #line 18 "..\..\Views\TraineeshipApplication\_workExperiencesJS.cshtml"
               Write(Html.RadioButtonFor(m => m.Candidate.HasWorkExperience, false, new { id = "workexp-no", data_bind = "attr:{'checked': hasNoWorkExperience() }", aria_labelledby = "workExpQuestion" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                    No\r\n                </label>\r\n            </div>\r\n         " +
"   <div");

WriteLiteral(" id=\"workexperience-panel\"");

WriteLiteral(" class=\"toggle-content\"");

WriteLiteral(" data-bind=\"style: {\'display\': workExperienceStatus() }\"");

WriteLiteral(" aria-hidden=\"true\"");

WriteLiteral(">\r\n                <div");

WriteLiteral(" id=\"workexperience-apply\"");

WriteLiteral(" class=\"clearfix\"");

WriteLiteral(">\r\n                    <div");

WriteLiteral(" class=\"form-group form-group-compound\"");

WriteLiteral(" data-bind=\"parentvalElement: employer\"");

WriteLiteral(">\r\n                        <label");

WriteLiteral(" for=\"work-employer\"");

WriteLiteral(" class=\"form-label\"");

WriteLiteral(">Employer</label>\r\n                        <input");

WriteLiteral(" type=\"text\"");

WriteLiteral(" class=\"form-control\"");

WriteLiteral(" id=\"work-employer\"");

WriteLiteral(" data-bind=\"value: employer\"");

WriteLiteral(" maxlength=\"50\"");

WriteLiteral(">\r\n                    </div>\r\n                    <div");

WriteLiteral(" class=\"form-group form-group-compound\"");

WriteLiteral(" data-bind=\"parentvalElement: jobTitle\"");

WriteLiteral(">\r\n                        <label");

WriteLiteral(" for=\"work-title\"");

WriteLiteral(" class=\"form-label\"");

WriteLiteral(">Job title</label>\r\n                        <input");

WriteLiteral(" type=\"text\"");

WriteLiteral(" class=\"form-control\"");

WriteLiteral(" id=\"work-title\"");

WriteLiteral(" data-bind=\"value: jobTitle\"");

WriteLiteral(" maxlength=\"50\"");

WriteLiteral(">\r\n                    </div>\r\n                    <div");

WriteLiteral(" class=\"form-group form-group-compound\"");

WriteLiteral(" data-bind=\"parentvalElement: mainDuties\"");

WriteLiteral(">\r\n                        <label");

WriteLiteral(" for=\"work-role\"");

WriteLiteral(" class=\"form-label\"");

WriteLiteral(">Main duties</label>\r\n                        <textarea");

WriteLiteral(" rows=\"3\"");

WriteLiteral(" class=\"form-control\"");

WriteLiteral(" id=\"work-role\"");

WriteLiteral(" data-val-length-max=\"200\"");

WriteLiteral(" data-bind=\"value: mainDuties\"");

WriteLiteral("></textarea>\r\n                        <span");

WriteLiteral(" class=\"form-hint\"");

WriteLiteral("><span");

WriteLiteral(" class=\"maxchar-count\"");

WriteLiteral(">200</span> <span");

WriteLiteral(" class=\"maxchar-text\"");

WriteLiteral("> characters remaining</span></span>\r\n                        <span");

WriteLiteral(" class=\"visuallyhidden aria-limit\"");

WriteLiteral(" aria-live=\"polite\"");

WriteLiteral("></span>\r\n                    </div>\r\n                    <div");

WriteLiteral(" class=\"form-group inline-fixed validation-message-parent\"");

WriteLiteral(">\r\n                        <div");

WriteLiteral(" class=\"form-group error-wrapper vert-align-top no-btm-margin\"");

WriteLiteral(">\r\n                            <label");

WriteLiteral(" for=\"work-from\"");

WriteLiteral(" class=\"form-label\"");

WriteLiteral(">Started</label>\r\n                            <div");

WriteLiteral(" class=\"form-group no-btm-margin\"");

WriteLiteral(">\r\n                                <span");

WriteLiteral(" class=\"form-hint\"");

WriteLiteral(">Month</span>\r\n\r\n                                <select");

WriteLiteral(" id=\"work-from\"");

WriteLiteral(" data-bind=\"options: months, optionsText: \'monthName\', optionsValue: \'monthNumber" +
"\',value: fromMonth\"");

WriteLiteral("></select>\r\n\r\n                            </div>\r\n                            <di" +
"v");

WriteLiteral(" class=\"form-group no-btm-margin\"");

WriteLiteral(" data-bind=\"parentvalElement: fromYear\"");

WriteLiteral(">\r\n                                <label");

WriteLiteral(" for=\"work-from-year\"");

WriteLiteral(" class=\"form-hint\"");

WriteLiteral(">Year</label>\r\n                                <input");

WriteLiteral(" type=\"tel\"");

WriteLiteral(" class=\"form-control form-control-small\"");

WriteLiteral(" pattern=\"[0-9]*\"");

WriteLiteral(" maxlength=\"4\"");

WriteLiteral("\r\n                                       id=\"work-from-year\"");

WriteLiteral(" data-bind=\"value: fromYear\"");

WriteLiteral(">\r\n                            </div>\r\n                        </div>\r\n          " +
"              <div");

WriteLiteral(" class=\"form-group error-wrapper vert-align-top no-btm-margin\"");

WriteLiteral(">\r\n                            <label");

WriteLiteral(" for=\"work-to\"");

WriteLiteral(" class=\"form-label\"");

WriteLiteral(">Finished</label>\r\n                            <div");

WriteLiteral(" class=\"form-group no-btm-margin\"");

WriteLiteral(">\r\n                                <span");

WriteLiteral(" class=\"form-hint\"");

WriteLiteral(">Month</span>\r\n\r\n                                <select");

WriteLiteral(" id=\"work-to\"");

WriteLiteral(" data-bind=\"options: months, optionsText: \'monthName\', optionsValue: \'monthNumber" +
"\',value: toMonth,attr:{\'disabled\':toDateReadonly() }\"");

WriteLiteral("></select>\r\n\r\n                            </div>\r\n                            <di" +
"v");

WriteLiteral(" class=\"form-group no-btm-margin\"");

WriteLiteral(" data-bind=\"parentvalElement: toYear\"");

WriteLiteral(">\r\n                                <label");

WriteLiteral(" for=\"work-to-year\"");

WriteLiteral(" class=\"form-hint\"");

WriteLiteral(">Year</label>\r\n                                <input");

WriteLiteral(" type=\"tel\"");

WriteLiteral(" class=\"form-control form-control-small\"");

WriteLiteral(" pattern=\"[0-9]*\"");

WriteLiteral(" maxlength=\"4\"");

WriteLiteral("\r\n                                       id=\"work-to-year\"");

WriteLiteral(" data-bind=\"value: toYear, attr:{\'disabled\':toDateReadonly() }\"");

WriteLiteral(" />\r\n                            </div>\r\n                            <div");

WriteLiteral(" class=\"form-group no-btm-margin\"");

WriteLiteral(">\r\n                                <input");

WriteLiteral(" id=\"work-current\"");

WriteLiteral(" type=\"checkbox\"");

WriteLiteral(" data-bind=\"checked: isCurrentEmployment\"");

WriteLiteral(" />\r\n                                <label");

WriteLiteral(" for=\"work-current\"");

WriteLiteral(">Current</label>\r\n                            </div>\r\n                        </d" +
"iv>\r\n                        <div");

WriteLiteral(" class=\"validation-message-container\"");

WriteLiteral("></div>\r\n                    </div>\r\n                    <div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(">\r\n                        <a");

WriteLiteral(" role=\"button\"");

WriteLiteral(" href=\"#\"");

WriteLiteral(" class=\"button\"");

WriteLiteral(" id=\"addWorkBtn\"");

WriteLiteral(" data-bind=\"click: addWorkExperience\"");

WriteLiteral(">Save this work experience</a>\r\n                        <span");

WriteLiteral(" class=\"visuallyhidden\"");

WriteLiteral(" aria-live=\"polite\"");

WriteLiteral(" id=\"workAddConfirmText\"");

WriteLiteral("></span>\r\n                    </div>\r\n                </div>\r\n\r\n                <" +
"div");

WriteLiteral(" id=\"work-experience-summary\"");

WriteLiteral(" data-bind=\"foreach: workExperiences\"");

WriteLiteral(">\r\n                    <div");

WriteLiteral(" class=\"grid-3-4\"");

WriteLiteral(">\r\n                        <div");

WriteLiteral(" id=\"work-history-item\"");

WriteLiteral(" class=\"grid-row work-history-item\"");

WriteLiteral(">\r\n                            <div");

WriteLiteral(" class=\"work-controls\"");

WriteLiteral(">\r\n                                <div");

WriteLiteral(" class=\"work-edit ta-center\"");

WriteLiteral(">\r\n\r\n                                    <a");

WriteLiteral(" href=\"#\"");

WriteLiteral(" class=\"fake-link cell-span\"");

WriteLiteral(" data-bind=\"if: showEditButton, click: $parent.editWorkExperience\"");

WriteLiteral(">Edit</a>\r\n                                    <a");

WriteLiteral(" href=\"#\"");

WriteLiteral(" class=\"fake-link cell-span\"");

WriteLiteral(" data-bind=\"ifnot: showEditButton,click: $parent.saveWorkExperience\"");

WriteLiteral(">Save</a>\r\n                                </div>\r\n                              " +
"  <div");

WriteLiteral(" class=\"work-delete ta-center\"");

WriteLiteral(">\r\n                                    <span");

WriteLiteral(" class=\"cell-span\"");

WriteLiteral(">\r\n                                        <i");

WriteLiteral(" class=\"copy-16 fa fa-times-circle icon-black remove-work-experience-link\"");

WriteLiteral(" data-bind=\"click: $parent.removeWorkExperience\"");

WriteLiteral("></i>\r\n                                        <i");

WriteLiteral(" class=\"visuallyhidden\"");

WriteLiteral(">Remove</i>\r\n                                    </span>\r\n                       " +
"         </div>\r\n                            </div>\r\n                           " +
" <div");

WriteLiteral(" class=\"column-one-half\"");

WriteLiteral(">\r\n                                <table");

WriteLiteral(" class=\"table-no-btm-border table-compound\"");

WriteLiteral(">\r\n                                    <colgroup>\r\n                              " +
"          <col");

WriteLiteral(" class=\"t100\"");

WriteLiteral(@">
                                        <col>
                                    </colgroup>
                                    <thead>
                                        <tr>
                                            <th>
                                                <span");

WriteLiteral(" class=\"heading-span\"");

WriteLiteral(@">Work experience</span>
                                            </th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <tr>
                                            <td>
                                                <div");

WriteLiteral(" class=\"form-group form-group-compound inline-float width-all-49\"");

WriteLiteral(" data-bind=\"visible: !showEditButton()\"");

WriteLiteral(">\r\n                                                    <input");

WriteLiteral(" type=\"text\"");

WriteLiteral(" title=\"Employer\"");

WriteLiteral(" class=\"form-control\"");

WriteLiteral(" data-bind=\"value: itemEmployer, attr:{\'name\':\'Candidate.WorkExperience[\' + $inde" +
"x() +\'].Employer\'}\"");

WriteLiteral(" maxlength=\"50\"");

WriteLiteral(" />\r\n                                                </div>\r\n                    " +
"                            <span");

WriteLiteral(" class=\"cell-span employer-name-span\"");

WriteLiteral(" data-bind=\"visible: showEditButton, text: itemEmployer, attr:{\'id\':\'candidate_wo" +
"rkexperience_\'+ $index() + \'__employer\'}\"");

WriteLiteral("></span>\r\n                                                <span");

WriteLiteral(" class=\"cell-span work-hyphen\"");

WriteLiteral(" data-bind=\"visible: showEditButton\"");

WriteLiteral(">-</span>\r\n                                                <div");

WriteLiteral(" class=\"form-group form-group-compound inline-float width-all-49 no-right-margin\"" +
"");

WriteLiteral(" data-bind=\"visible: !showEditButton()\"");

WriteLiteral(">\r\n                                                    <input");

WriteLiteral(" type=\"text\"");

WriteLiteral(" title=\"Job title\"");

WriteLiteral(" class=\"form-control\"");

WriteLiteral(" data-bind=\"value: itemJobTitle, attr:{\'name\':\'Candidate.WorkExperience[\' + $inde" +
"x() +\'].JobTitle\'}\"");

WriteLiteral(" maxlength=\"50\"");

WriteLiteral(" />\r\n                                                </div>\r\n                    " +
"                            <span");

WriteLiteral(" class=\"cell-span job-title-span\"");

WriteLiteral(" data-bind=\"visible: showEditButton, text: itemJobTitle, attr:{\'id\':\'candidate_wo" +
"rkexperience_\'+ $index() + \'__jobtitle\'}\"");

WriteLiteral("></span>\r\n                                                <div></div>\r\n          " +
"                                      <textarea");

WriteLiteral(" title=\"Main duties\"");

WriteLiteral(" class=\"form-control\"");

WriteLiteral(" rows=\"3\"");

WriteLiteral(" data-bind=\"value: itemMainDuties, visible: !showEditButton(),attr:{\'name\':\'Candi" +
"date.WorkExperience[\' + $index() +\'].Description\'}\"");

WriteLiteral("></textarea>\r\n                                                <span");

WriteLiteral(" class=\"cell-span main-duties-span prewrap\"");

WriteLiteral(" data-bind=\"visible: showEditButton, text: itemMainDuties, attr:{\'id\':\'candidate_" +
"workexperience_\'+ $index() + \'__description\'}\"");

WriteLiteral(@"></span>
                                            </td>
                                        </tr>
                                    </tbody>
                                </table>
                            </div>
                            <div");

WriteLiteral(" class=\"column-one-half\"");

WriteLiteral(">\r\n                                <table");

WriteLiteral(" class=\"table-no-btm-border table-compound\"");

WriteLiteral(">\r\n                                    <colgroup>\r\n                              " +
"          <col");

WriteLiteral(" class=\"t30\"");

WriteLiteral(">\r\n                                        <col");

WriteLiteral(" class=\"t30\"");

WriteLiteral(">\r\n                                        <col");

WriteLiteral(" class=\"t25\"");

WriteLiteral(">\r\n                                        <col");

WriteLiteral(" class=\"t15\"");

WriteLiteral(@">
                                        <col>
                                    </colgroup>
                                    <thead>
                                        <tr>
                                            <th>
                                                <span");

WriteLiteral(" class=\"heading-span\"");

WriteLiteral(">Started</span>\r\n                                            </th>\r\n             " +
"                               <th>\r\n                                           " +
"     <span");

WriteLiteral(" class=\"heading-span\"");

WriteLiteral(@">Finished</span>
                                            </th>
                                            <th></th>
                                            <th></th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <tr>
                                            <td");

WriteLiteral(" class=\"validation-message-parent\"");

WriteLiteral(">\r\n                                                <div");

WriteLiteral(" class=\"form-group form-group-compound\"");

WriteLiteral(" data-bind=\"visible: !showEditButton()\"");

WriteLiteral(">\r\n                                                    <select");

WriteLiteral(" title=\"From month\"");

WriteLiteral(" data-bind=\"options: $parent.months, optionsText: \'monthName\', optionsValue: \'mon" +
"thNumber\',value: itemFromMonth, attr:{\'name\':\'Candidate.WorkExperience[\' + $inde" +
"x() +\'].FromMonth\'} \"");

WriteLiteral("></select>\r\n\r\n                                                </div>\r\n           " +
"                                     <div");

WriteLiteral(" class=\"form-group form-group-compound\"");

WriteLiteral(" data-bind=\"visible: !showEditButton()\"");

WriteLiteral(">\r\n                                                    <input");

WriteLiteral(" title=\"From year\"");

WriteLiteral(" type=\"text\"");

WriteLiteral(" class=\"form-control\"");

WriteLiteral(" data-bind=\"value: itemFromYear, attr:{\'name\':\'Candidate.WorkExperience[\' + $inde" +
"x() +\'].FromYear\'}\"");

WriteLiteral(" pattern=\"[0-9]*\"");

WriteLiteral(" maxlength=\"4\"");

WriteLiteral(">\r\n\r\n                                                </div>\r\n\r\n                  " +
"                              <span");

WriteLiteral(" class=\"cell-span\"");

WriteLiteral(" data-bind=\"visible: showEditButton, text: getMonthLabel(itemFromMonth()), attr:{" +
"\'id\':\'candidate_workexperience_\'+ $index() + \'__frommonth\'}\"");

WriteLiteral("></span>\r\n                                                <span");

WriteLiteral(" class=\"cell-span\"");

WriteLiteral(" data-bind=\"visible: showEditButton, text: itemFromYear, attr:{\'id\':\'candidate_wo" +
"rkexperience_\'+ $index() + \'__fromyear\'}\"");

WriteLiteral("></span>\r\n                                                <div");

WriteLiteral(" class=\"validation-message-container\"");

WriteLiteral("></div>\r\n                                            </td>\r\n                     " +
"                       <td");

WriteLiteral(" class=\"validation-message-parent\"");

WriteLiteral(">\r\n                                                <div");

WriteLiteral(" class=\"form-group form-group-compound\"");

WriteLiteral(" data-bind=\"visible: !showEditButton()\"");

WriteLiteral(">\r\n                                                    <select");

WriteLiteral(" title=\"To month\"");

WriteLiteral(" data-bind=\"options: $parent.months, optionsText: \'monthName\', optionsValue: \'mon" +
"thNumber\',value: itemToMonth, attr:{\'disabled\': toItemDateReadonly,\'name\':\'Candi" +
"date.WorkExperience[\' + $index() +\'].ToMonth\'}\"");

WriteLiteral("></select>\r\n\r\n                                                </div>\r\n           " +
"                                     <div");

WriteLiteral(" class=\"form-group form-group-compound\"");

WriteLiteral(" data-bind=\"visible: !showEditButton()\"");

WriteLiteral(">\r\n                                                    <input");

WriteLiteral(" title=\"To year\"");

WriteLiteral(" type=\"text\"");

WriteLiteral(" class=\"form-control\"");

WriteLiteral(" data-bind=\"value: itemToYear, attr:{\'disabled\': toItemDateReadonly, \'name\':\'Cand" +
"idate.WorkExperience[\' + $index() +\'].ToYear\'}\"");

WriteLiteral(" pattern=\"[0-9]*\"");

WriteLiteral(" maxlength=\"4\"");

WriteLiteral(">\r\n\r\n                                                </div>\r\n                    " +
"                            <div");

WriteLiteral(" class=\"form-group form-group-compound\"");

WriteLiteral(" data-bind=\"visible: !showEditButton()\"");

WriteLiteral(">\r\n                                                    <label>\r\n                 " +
"                                       <input");

WriteLiteral(" title=\"Current\"");

WriteLiteral(" type=\"checkbox\"");

WriteLiteral(" data-bind=\"checked: itemIsCurrentEmployment\"");

WriteLiteral(" /> Current\r\n                                                    </label>\r\n      " +
"                                          </div>\r\n                              " +
"                  <span");

WriteLiteral(" class=\"cell-span\"");

WriteLiteral(" data-bind=\"visible: showEditButton, text: itemToYear() <= 1 || itemToYear() === " +
"null ? \'Current\' : getMonthLabel(itemToMonth()), attr:{\'id\':\'candidate_workexper" +
"ience_\'+ $index() + \'__tomonth\'}\"");

WriteLiteral("></span>\r\n                                                <span");

WriteLiteral(" class=\"cell-span\"");

WriteLiteral(" data-bind=\"visible: showEditButton, text: itemToYear() <= 1 || itemToYear() === " +
"null ? \'\' : itemToYear , attr:{\'id\':\'candidate_workexperience_\'+ $index() + \'__t" +
"oyear\'}\"");

WriteLiteral("></span>\r\n                                                <div");

WriteLiteral(" class=\"validation-message-container\"");

WriteLiteral(@"></div>
                                            </td>
                                            <td></td>
                                            <td></td>
                                        </tr>
                                    </tbody>
                                </table>
                            </div>
                        </div>
                    </div>
                </div>

            </div>
        </div>

    </fieldset>

</div>

");

        }
    }
}
#pragma warning restore 1591
