﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34209
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SFA.Apprenticeships.Web.Candidate.Views.ApprenticeshipApplication.DisplayTemplates
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
    using SFA.Apprenticeships.Web.Candidate.ViewModels.Candidate;
    using SFA.Apprenticeships.Web.Candidate.ViewModels.Locations;
    using SFA.Apprenticeships.Web.Candidate.ViewModels.Login;
    using SFA.Apprenticeships.Web.Candidate.ViewModels.Register;
    using SFA.Apprenticeships.Web.Candidate.ViewModels.VacancySearch;
    using SFA.Apprenticeships.Web.Common.Constants;
    using SFA.Apprenticeships.Web.Common.Framework;
    using SFA.Apprenticeships.Web.Common.Models.Common;
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/ApprenticeshipApplication/DisplayTemplates/QualificationsViewModel.cshtml" +
        "")]
    public partial class QualificationsViewModel_ : System.Web.Mvc.WebViewPage<IEnumerable<QualificationsViewModel>>
    {
        public QualificationsViewModel_()
        {
        }
        public override void Execute()
        {
WriteLiteral("<section");

WriteLiteral(" id=\"applyQualifications\"");

WriteLiteral(" class=\"section-border\"");

WriteLiteral(">\r\n    <h2");

WriteLiteral(" class=\"heading-large\"");

WriteLiteral(">\r\n        Qualifications\r\n");

            
            #line 6 "..\..\Views\ApprenticeshipApplication\DisplayTemplates\QualificationsViewModel.cshtml"
        
            
            #line default
            #line hidden
            
            #line 6 "..\..\Views\ApprenticeshipApplication\DisplayTemplates\QualificationsViewModel.cshtml"
         if (ViewBag.VacancyId != null)
        {

            
            #line default
            #line hidden
WriteLiteral("            <a");

WriteLiteral(" class=\"icon-with-text\"");

WriteAttribute("href", Tuple.Create(" href=\"", 251), Tuple.Create("\"", 362)
            
            #line 8 "..\..\Views\ApprenticeshipApplication\DisplayTemplates\QualificationsViewModel.cshtml"
, Tuple.Create(Tuple.Create("", 258), Tuple.Create<System.Object, System.Int32>(Url.RouteUrl(CandidateRouteNames.ApprenticeshipApply, new {id = ViewBag.VacancyId})
            
            #line default
            #line hidden
, 258), false)
, Tuple.Create(Tuple.Create("", 342), Tuple.Create("#applyQualifications", 342), true)
);

WriteLiteral(">\r\n                <i");

WriteLiteral(" class=\"the-icon fa fa-pencil\"");

WriteLiteral("></i><span");

WriteLiteral(" class=\"the-text\"");

WriteLiteral(">Edit section</span>\r\n            </a>\r\n");

            
            #line 11 "..\..\Views\ApprenticeshipApplication\DisplayTemplates\QualificationsViewModel.cshtml"
        }

            
            #line default
            #line hidden
WriteLiteral("    </h2>\r\n\r\n");

            
            #line 14 "..\..\Views\ApprenticeshipApplication\DisplayTemplates\QualificationsViewModel.cshtml"
    
            
            #line default
            #line hidden
            
            #line 14 "..\..\Views\ApprenticeshipApplication\DisplayTemplates\QualificationsViewModel.cshtml"
     if (!Model.Any())
    {

            
            #line default
            #line hidden
WriteLiteral("        <p");

WriteLiteral(" id=\"no-qualifications\"");

WriteLiteral(">I don\'t have any qualifications</p>\r\n");

            
            #line 17 "..\..\Views\ApprenticeshipApplication\DisplayTemplates\QualificationsViewModel.cshtml"
    }

            
            #line default
            #line hidden
WriteLiteral("\r\n");

            
            #line 19 "..\..\Views\ApprenticeshipApplication\DisplayTemplates\QualificationsViewModel.cshtml"
    
            
            #line default
            #line hidden
            
            #line 19 "..\..\Views\ApprenticeshipApplication\DisplayTemplates\QualificationsViewModel.cshtml"
     foreach (var group in Model.GroupBy(item => item.QualificationType))
    {

            
            #line default
            #line hidden
WriteLiteral("        <div");

WriteLiteral(" class=\"hgroup-small\"");

WriteLiteral(">\r\n            <h3");

WriteLiteral(" class=\"heading-small\"");

WriteLiteral(">");

            
            #line 22 "..\..\Views\ApprenticeshipApplication\DisplayTemplates\QualificationsViewModel.cshtml"
                                 Write(Html.Encode(group.Key));

            
            #line default
            #line hidden
WriteLiteral("</h3>\r\n        </div>\r\n");

WriteLiteral("        <table");

WriteLiteral(" class=\"grid-3-4\"");

WriteLiteral(">\r\n            <colgroup>\r\n                <col");

WriteLiteral(" class=\"t40\"");

WriteLiteral(">\r\n                <col");

WriteLiteral(" class=\"t25\"");

WriteLiteral(">\r\n                <col");

WriteLiteral(" class=\"t15\"");

WriteLiteral(">\r\n                <col>\r\n            </colgroup>\r\n            <thead>\r\n         " +
"       <tr>\r\n                    <th>\r\n                        <span");

WriteLiteral(" class=\"heading-span\"");

WriteLiteral(">Subject</span>\r\n                    </th>\r\n                    <th>\r\n           " +
"             <span");

WriteLiteral(" class=\"heading-span\"");

WriteLiteral(">Grade</span>\r\n                    </th>\r\n                    <th>\r\n             " +
"           <span");

WriteLiteral(" class=\"heading-span\"");

WriteLiteral(">Year</span>\r\n                    </th>\r\n                </tr>\r\n            </the" +
"ad>\r\n            <tbody>\r\n");

            
            #line 45 "..\..\Views\ApprenticeshipApplication\DisplayTemplates\QualificationsViewModel.cshtml"
                
            
            #line default
            #line hidden
            
            #line 45 "..\..\Views\ApprenticeshipApplication\DisplayTemplates\QualificationsViewModel.cshtml"
                 foreach (QualificationsViewModel item in group)
                {

            
            #line default
            #line hidden
WriteLiteral("                    <tr>\r\n                        <td>\r\n                         " +
"   <input");

WriteLiteral(" class=\"form-control qual-input-edit form-prepopped\"");

WriteLiteral(" type=\"text\"");

WriteAttribute("value", Tuple.Create(" value=\"", 1732), Tuple.Create("\"", 1753)
            
            #line 49 "..\..\Views\ApprenticeshipApplication\DisplayTemplates\QualificationsViewModel.cshtml"
                          , Tuple.Create(Tuple.Create("", 1740), Tuple.Create<System.Object, System.Int32>(item.Subject
            
            #line default
            #line hidden
, 1740), false)
);

WriteLiteral(" readonly>\r\n                        </td>\r\n                        <td>\r\n        " +
"                    <input");

WriteLiteral(" class=\"form-control qual-input-edit form-prepopped\"");

WriteLiteral(" type=\"text\"");

WriteAttribute("value", Tuple.Create(" value=\"", 1925), Tuple.Create("\"", 1984)
            
            #line 52 "..\..\Views\ApprenticeshipApplication\DisplayTemplates\QualificationsViewModel.cshtml"
                          , Tuple.Create(Tuple.Create("", 1933), Tuple.Create<System.Object, System.Int32>(Html.GetDisplayGrade(item.Grade, item.IsPredicted)
            
            #line default
            #line hidden
, 1933), false)
);

WriteLiteral(" readonly>\r\n                        </td>\r\n                        <td>\r\n        " +
"                    <input");

WriteLiteral(" class=\"form-control qual-input-edit form-prepopped\"");

WriteLiteral(" type=\"text\"");

WriteAttribute("value", Tuple.Create(" value=\"", 2156), Tuple.Create("\"", 2174)
            
            #line 55 "..\..\Views\ApprenticeshipApplication\DisplayTemplates\QualificationsViewModel.cshtml"
                          , Tuple.Create(Tuple.Create("", 2164), Tuple.Create<System.Object, System.Int32>(item.Year
            
            #line default
            #line hidden
, 2164), false)
);

WriteLiteral(" readonly>\r\n                        </td>\r\n                    </tr>\r\n");

            
            #line 58 "..\..\Views\ApprenticeshipApplication\DisplayTemplates\QualificationsViewModel.cshtml"
                }

            
            #line default
            #line hidden
WriteLiteral("            </tbody>\r\n        </table>\r\n");

            
            #line 61 "..\..\Views\ApprenticeshipApplication\DisplayTemplates\QualificationsViewModel.cshtml"
    }

            
            #line default
            #line hidden
WriteLiteral("\r\n</section>");

        }
    }
}
#pragma warning restore 1591