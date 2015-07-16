﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34014
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
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/TraineeshipSearch/Results.cshtml")]
    public partial class Results : System.Web.Mvc.WebViewPage<TraineeshipSearchResponseViewModel>
    {
        public Results()
        {
        }
        public override void Execute()
        {
            
            #line 3 "..\..\Views\TraineeshipSearch\Results.cshtml"
  
    ViewBag.Title = "Results - Find a traineeship";
    Layout = "~/Views/Shared/_Layout.cshtml";

            
            #line default
            #line hidden
WriteLiteral("\r\n\r\n");

DefineSection("metatags", () => {

WriteLiteral("\r\n    ");

WriteLiteral("\r\n    <meta");

WriteLiteral(" name=\"WT.oss_r\"");

WriteAttribute("content", Tuple.Create(" content=\"", 269), Tuple.Create("\"", 295)
            
            #line 11 "..\..\Views\TraineeshipSearch\Results.cshtml"
, Tuple.Create(Tuple.Create("", 279), Tuple.Create<System.Object, System.Int32>(Model.TotalHits
            
            #line default
            #line hidden
, 279), false)
);

WriteLiteral(" />\r\n");

});

WriteLiteral("\r\n<div");

WriteLiteral(" class=\"search-results-wrapper grid-wrapper\"");

WriteLiteral(">\r\n    <div");

WriteLiteral(" class=\"hgroup\"");

WriteLiteral(">\r\n        <h1");

WriteLiteral(" class=\"heading-xlarge\"");

WriteLiteral(">Search results</h1>\r\n        <div");

WriteLiteral(" id=\"vacancy-result-summary\"");

WriteLiteral(">\r\n            <p");

WriteLiteral(" class=\"small-btm-margin\"");

WriteLiteral(">We\'ve found <b");

WriteLiteral(" id=\"total-hits-count\"");

WriteLiteral(" class=\"bold-medium\"");

WriteLiteral(">");

            
            #line 18 "..\..\Views\TraineeshipSearch\Results.cshtml"
                                                                                            Write(Model.TotalHits);

            
            #line default
            #line hidden
WriteLiteral("</b> traineeships in your selected area.</p>\r\n        </div>\r\n    </div>\r\n\r\n");

            
            #line 22 "..\..\Views\TraineeshipSearch\Results.cshtml"
    
            
            #line default
            #line hidden
            
            #line 22 "..\..\Views\TraineeshipSearch\Results.cshtml"
     using (Html.BeginRouteForm(CandidateRouteNames.TraineeshipResults, FormMethod.Get))
    {
        Html.Partial("ValidationSummary", ViewData.ModelState);
        Html.RenderPartial("_searchUpdate", Model.VacancySearch);

            
            #line default
            #line hidden
WriteLiteral("        <section");

WriteLiteral(" class=\"grid grid-2-3\"");

WriteLiteral(">\r\n            <div");

WriteLiteral(" id=\"pagedList\"");

WriteLiteral(">\r\n");

            
            #line 28 "..\..\Views\TraineeshipSearch\Results.cshtml"
                
            
            #line default
            #line hidden
            
            #line 28 "..\..\Views\TraineeshipSearch\Results.cshtml"
                   Html.RenderPartial("_searchResults", Model); 
            
            #line default
            #line hidden
WriteLiteral("\r\n            </div>\r\n        </section>\r\n");

            
            #line 31 "..\..\Views\TraineeshipSearch\Results.cshtml"
    }

            
            #line default
            #line hidden
WriteLiteral("</div>\r\n\r\n<div");

WriteLiteral(" class=\"saving-prompt toggle-content hide-nojs\"");

WriteLiteral(" id=\"ajaxLoading\"");

WriteLiteral(">\r\n    Loading\r\n</div>\r\n\r\n");

DefineSection("scripts", () => {

WriteLiteral("\r\n\r\n");

WriteLiteral("    ");

            
            #line 41 "..\..\Views\TraineeshipSearch\Results.cshtml"
Write(Scripts.Render("~/bundles/nas/locationsearch"));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("    ");

            
            #line 42 "..\..\Views\TraineeshipSearch\Results.cshtml"
Write(Scripts.Render("~/bundles/nas/geoLocater"));

            
            #line default
            #line hidden
WriteLiteral("\r\n\r\n\r\n    <script>\r\n        var searchUrl = \'");

            
            #line 46 "..\..\Views\TraineeshipSearch\Results.cshtml"
                    Write(Url.RouteUrl(CandidateRouteNames.TraineeshipResults));

            
            #line default
            #line hidden
WriteLiteral("\';\r\n        var locationUrl = \'");

            
            #line 47 "..\..\Views\TraineeshipSearch\Results.cshtml"
                      Write(Url.Action("location", "Location"));

            
            #line default
            #line hidden
WriteLiteral("\';\r\n    </script>\r\n");

WriteLiteral("    ");

            
            #line 49 "..\..\Views\TraineeshipSearch\Results.cshtml"
Write(Scripts.Render("~/bundles/nas/results"));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

});

        }
    }
}
#pragma warning restore 1591
