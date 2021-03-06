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

namespace SFA.Apprenticeships.Web.Candidate.Views.Shared.DisplayTemplates.Application
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
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/Shared/DisplayTemplates/Application/TrainingCourses.cshtml")]
    public partial class TrainingCourses : System.Web.Mvc.WebViewPage<IEnumerable<TrainingCourseViewModel>>
    {
        public TrainingCourses()
        {
        }
        public override void Execute()
        {
WriteLiteral("<section");

WriteLiteral(" class=\"section-border\"");

WriteLiteral(">\r\n    <h2");

WriteLiteral(" class=\"heading-large\"");

WriteLiteral(">\r\n        Training courses\r\n");

            
            #line 6 "..\..\Views\Shared\DisplayTemplates\Application\TrainingCourses.cshtml"
        
            
            #line default
            #line hidden
            
            #line 6 "..\..\Views\Shared\DisplayTemplates\Application\TrainingCourses.cshtml"
         if (ViewBag.VacancyId != null)
        {

            
            #line default
            #line hidden
WriteLiteral("            <a");

WriteLiteral(" class=\"icon-with-text\"");

WriteAttribute("href", Tuple.Create(" href=\"", 228), Tuple.Create("\"", 340)
            
            #line 8 "..\..\Views\Shared\DisplayTemplates\Application\TrainingCourses.cshtml"
, Tuple.Create(Tuple.Create("", 235), Tuple.Create<System.Object, System.Int32>(Url.RouteUrl(CandidateRouteNames.ApprenticeshipApply, new {id = ViewBag.VacancyId})
            
            #line default
            #line hidden
, 235), false)
, Tuple.Create(Tuple.Create("", 319), Tuple.Create("#applyTrainingCourses", 319), true)
);

WriteLiteral(">\r\n                <i");

WriteLiteral(" class=\"the-icon fa fa-pencil\"");

WriteLiteral("></i><span");

WriteLiteral(" class=\"the-text\"");

WriteLiteral(">Edit section</span>\r\n            </a>\r\n");

            
            #line 11 "..\..\Views\Shared\DisplayTemplates\Application\TrainingCourses.cshtml"
        }

            
            #line default
            #line hidden
WriteLiteral("    </h2>\r\n\r\n");

            
            #line 14 "..\..\Views\Shared\DisplayTemplates\Application\TrainingCourses.cshtml"
    
            
            #line default
            #line hidden
            
            #line 14 "..\..\Views\Shared\DisplayTemplates\Application\TrainingCourses.cshtml"
     if (!Model.Any())
    {

            
            #line default
            #line hidden
WriteLiteral("        <p");

WriteLiteral(" id=\"no-training-history\"");

WriteLiteral(">I have not been on any training courses</p>\r\n");

            
            #line 17 "..\..\Views\Shared\DisplayTemplates\Application\TrainingCourses.cshtml"
    }

            
            #line default
            #line hidden
WriteLiteral("\r\n");

            
            #line 19 "..\..\Views\Shared\DisplayTemplates\Application\TrainingCourses.cshtml"
    
            
            #line default
            #line hidden
            
            #line 19 "..\..\Views\Shared\DisplayTemplates\Application\TrainingCourses.cshtml"
     foreach (var each in Model)
    {

            
            #line default
            #line hidden
WriteLiteral("        <div");

WriteLiteral(" class=\"grid-3-4 nobreak-print\"");

WriteLiteral(">\r\n            <div");

WriteLiteral(" class=\"grid-wrapper training-history-item\"");

WriteLiteral(">\r\n\r\n                <div");

WriteLiteral(" class=\"grid grid-1-2\"");

WriteLiteral(">\r\n                    <table");

WriteLiteral(" class=\"table-no-btm-border table-compound\"");

WriteLiteral(@">
                        <colgroup>
                            <col>
                            <col>
                        </colgroup>
                        <thead>
                            <tr>
                                <th>
                                    <span");

WriteLiteral(" class=\"heading-span\"");

WriteLiteral(@">Training course</span>
                                </th>
                            </tr>
                        </thead>
                        <tbody>
                            <tr>
                                <td>
                                    <span");

WriteLiteral(" class=\"form-prepopped cell-span\"");

WriteLiteral(">");

            
            #line 40 "..\..\Views\Shared\DisplayTemplates\Application\TrainingCourses.cshtml"
                                                                      Write(each.Provider);

            
            #line default
            #line hidden
WriteLiteral("</span>\r\n                                    <span");

WriteLiteral(" class=\"form-prepopped cell-span training-hyphen\"");

WriteLiteral(">-</span>\r\n                                    <span");

WriteLiteral(" class=\"form-prepopped cell-span\"");

WriteLiteral(">");

            
            #line 42 "..\..\Views\Shared\DisplayTemplates\Application\TrainingCourses.cshtml"
                                                                      Write(each.Title);

            
            #line default
            #line hidden
WriteLiteral("</span>\r\n                                </td>\r\n                            </tr>" +
"\r\n                        </tbody>\r\n                    </table>\r\n              " +
"  </div>\r\n                <div");

WriteLiteral(" class=\"grid grid-1-2\"");

WriteLiteral(">\r\n                    <table");

WriteLiteral(" class=\"table-no-btm-border table-compound\"");

WriteLiteral(">\r\n                        <colgroup>\r\n                            <col");

WriteLiteral(" class=\"t30\"");

WriteLiteral(">\r\n                            <col");

WriteLiteral(" class=\"t30\"");

WriteLiteral(">\r\n                            <col");

WriteLiteral(" class=\"t25\"");

WriteLiteral(">\r\n                            <col");

WriteLiteral(" class=\"t15\"");

WriteLiteral(">\r\n                            <col>\r\n                        </colgroup>\r\n      " +
"                  <thead>\r\n                            <tr>\r\n                   " +
"             <th>\r\n                                    <span");

WriteLiteral(" class=\"heading-span\"");

WriteLiteral(">From</span>\r\n                                </th>\r\n                            " +
"    <th>\r\n                                    <span");

WriteLiteral(" class=\"heading-span\"");

WriteLiteral(@">To</span>
                                </th>
                                <th></th>
                                <th></th>
                            </tr>
                        </thead>
                        <tbody>
                            <tr>
                                <td>
                                    <span");

WriteLiteral(" class=\"form-prepopped cell-span\"");

WriteLiteral(">");

            
            #line 72 "..\..\Views\Shared\DisplayTemplates\Application\TrainingCourses.cshtml"
                                                                      Write(QualificationPresenter.GetMonthYearLabel(each.FromMonth, each.FromYear));

            
            #line default
            #line hidden
WriteLiteral("</span>\r\n                                </td>\r\n                                <" +
"td>\r\n                                    <span");

WriteLiteral(" class=\"form-prepopped cell-span\"");

WriteLiteral(">");

            
            #line 75 "..\..\Views\Shared\DisplayTemplates\Application\TrainingCourses.cshtml"
                                                                      Write(QualificationPresenter.GetMonthYearLabel(each.ToMonth, each.ToYear));

            
            #line default
            #line hidden
WriteLiteral(@"</span>
                                </td>
                                <td></td>
                                <td></td>
                            </tr>
                        </tbody>
                    </table>
                </div>
            </div>
        </div>
");

            
            #line 85 "..\..\Views\Shared\DisplayTemplates\Application\TrainingCourses.cshtml"
    }

            
            #line default
            #line hidden
WriteLiteral("</section>");

        }
    }
}
#pragma warning restore 1591
