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

namespace SFA.Apprenticeships.Web.Candidate.Views.Shared.EditorTemplates
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
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/Shared/EditorTemplates/AddressViewModel.cshtml")]
    public partial class AddressViewModel_ : System.Web.Mvc.WebViewPage<AddressViewModel>
    {
        public AddressViewModel_()
        {
        }
        public override void Execute()
        {
WriteLiteral("<div");

WriteLiteral(" id=\"address-lookup\"");

WriteLiteral(" class=\"hide-nojs\"");

WriteLiteral(">\r\n    <div");

WriteLiteral(" class=\"form-group form-group-compound\"");

WriteLiteral(">\r\n        <label");

WriteLiteral(" for=\"postcode-search\"");

WriteLiteral(" class=\"form-label\"");

WriteLiteral(">Enter your postcode or start typing address</label>\r\n        <span");

WriteLiteral(" class=\"form-hint\"");

WriteLiteral(">For example, WR2 6NJ</span>\r\n        <input");

WriteLiteral(" id=\"postcode-search\"");

WriteLiteral(" type=\"text\"");

WriteLiteral(" class=\"form-control form-control-1-3\"");

WriteLiteral(" autocorrect=\"off\"");

WriteLiteral(">\r\n        <span");

WriteLiteral(" id=\"addressesPopulated\"");

WriteLiteral(" class=\"visuallyhidden\"");

WriteLiteral(" aria-live=\"polite\"");

WriteLiteral("></span>\r\n    </div>\r\n    <div");

WriteLiteral(" id=\"address-manual\"");

WriteLiteral(" class=\"form-group form-group-compound\"");

WriteLiteral(">\r\n        <a");

WriteLiteral(" href=\"#\"");

WriteLiteral(" class=\"copy-19\"");

WriteLiteral(" id=\"enterAddressManually\"");

WriteLiteral(">Or enter address manually</a>\r\n        <span");

WriteLiteral(" class=\"toggle-content hide-nojs loading-text\"");

WriteLiteral(" id=\"addressLoading\"");

WriteLiteral(">Loading address...</span>\r\n    </div>\r\n</div>\r\n\r\n<div");

WriteLiteral(" id=\"addressManualWrapper\"");

WriteLiteral(">\r\n    <div");

WriteLiteral(" id=\"address-details\"");

WriteLiteral(" class=\"address-manual-input\"");

WriteLiteral(">\r\n");

WriteLiteral("        ");

            
            #line 18 "..\..\Views\Shared\EditorTemplates\AddressViewModel.cshtml"
   Write(Html.FormTextFor(m => m.AddressLine1, containerHtmlAttributes: new { @class = "form-group-compound address-item" }, controlHtmlAttributes: new { type = "text", autocorrect = "off" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("        ");

            
            #line 19 "..\..\Views\Shared\EditorTemplates\AddressViewModel.cshtml"
   Write(Html.FormTextFor(m => m.AddressLine2, containerHtmlAttributes: new { @class = "form-group-compound address-item" }, controlHtmlAttributes: new { type = "text", autocorrect = "off" }, labelHtmlAttributes: new { @class = "visuallyhidden" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("        ");

            
            #line 20 "..\..\Views\Shared\EditorTemplates\AddressViewModel.cshtml"
   Write(Html.FormTextFor(m => m.AddressLine3, containerHtmlAttributes: new { @class = "form-group-compound address-item" }, controlHtmlAttributes: new { type = "text", autocorrect = "off" }, labelHtmlAttributes: new { @class = "visuallyhidden" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("        ");

            
            #line 21 "..\..\Views\Shared\EditorTemplates\AddressViewModel.cshtml"
   Write(Html.FormTextFor(m => m.AddressLine4, containerHtmlAttributes: new { @class = "form-group-compound address-item" }, controlHtmlAttributes: new { type = "text", autocorrect = "off" }, labelHtmlAttributes: new { @class = "visuallyhidden" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("        ");

            
            #line 22 "..\..\Views\Shared\EditorTemplates\AddressViewModel.cshtml"
   Write(Html.FormTextFor(m => m.Postcode, containerHtmlAttributes: new { @class = "address-item" }, controlHtmlAttributes: new { @class = "form-control-large", type = "text", autocapitalize = "characters", autocorrect = "off" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("        ");

            
            #line 23 "..\..\Views\Shared\EditorTemplates\AddressViewModel.cshtml"
   Write(Html.HiddenFor(m => m.Uprn));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("        ");

            
            #line 24 "..\..\Views\Shared\EditorTemplates\AddressViewModel.cshtml"
   Write(Html.HiddenFor(m => m.GeoPoint.Latitude));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("        ");

            
            #line 25 "..\..\Views\Shared\EditorTemplates\AddressViewModel.cshtml"
   Write(Html.HiddenFor(m => m.GeoPoint.Longitude));

            
            #line default
            #line hidden
WriteLiteral("\r\n    </div>\r\n</div>\r\n\r\n");

        }
    }
}
#pragma warning restore 1591
