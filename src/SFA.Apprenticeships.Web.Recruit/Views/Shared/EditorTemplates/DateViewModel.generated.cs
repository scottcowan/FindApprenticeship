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

namespace SFA.Apprenticeships.Web.Recruit.Views.Shared.EditorTemplates
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
    using SFA.Apprenticeships.Web.Common.Constants;
    using SFA.Apprenticeships.Web.Common.Framework;
    using SFA.Apprenticeships.Web.Common.Models.Common;
    using SFA.Apprenticeships.Web.Raa.Common.Views.Shared.DisplayTemplates;
    using SFA.Apprenticeships.Web.Raa.Common.Views.Shared.EditorTemplates;
    using SFA.Apprenticeships.Web.Recruit;
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/Shared/EditorTemplates/DateViewModel.cshtml")]
    public partial class DateViewModel_ : System.Web.Mvc.WebViewPage<SFA.Apprenticeships.Web.Common.ViewModels.DateViewModel>
    {
        public DateViewModel_()
        {
        }
        public override void Execute()
        {
            
            #line 2 "..\..\Views\Shared\EditorTemplates\DateViewModel.cshtml"
Write(Html.FormTextFor(m => m.Day, containerHtmlAttributes: new { @class = "form-group-compound" }, labelHtmlAttributes: new { @class = "form-hint" }, controlHtmlAttributes: new { @class = "form-control-xsmall", type = "tel", maxlength = "2", pattern = "[0-9]*" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

            
            #line 3 "..\..\Views\Shared\EditorTemplates\DateViewModel.cshtml"
Write(Html.FormTextFor(m => m.Month, containerHtmlAttributes: new { @class = "form-group-compound" }, labelHtmlAttributes: new { @class = "form-hint" }, controlHtmlAttributes: new { @class = "form-control-xsmall", type = "tel", maxlength = "2", pattern = "[0-9]*" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

            
            #line 4 "..\..\Views\Shared\EditorTemplates\DateViewModel.cshtml"
Write(Html.FormTextFor(m => m.Year, containerHtmlAttributes: new { @class = "form-group-compound" }, labelHtmlAttributes: new { @class = "form-hint" }, controlHtmlAttributes: new { @class = "form-control-small", type = "tel", maxlength = "4", pattern = "[0-9]*" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

        }
    }
}
#pragma warning restore 1591
