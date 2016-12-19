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

namespace SFA.Apprenticeships.Web.Manage.Views.Shared
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    
    #line 1 "..\..\Views\Shared\ValidationSummary.cshtml"
    using System.Linq;
    
    #line default
    #line hidden
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
    
    #line 2 "..\..\Views\Shared\ValidationSummary.cshtml"
    using SFA.Apprenticeships.Web.Common.Validators;
    
    #line default
    #line hidden
    
    #line 3 "..\..\Views\Shared\ValidationSummary.cshtml"
    using SFA.Apprenticeships.Web.Common.Validators.Extensions;
    
    #line default
    #line hidden
    using SFA.Apprenticeships.Web.Manage;
    using SFA.Apprenticeships.Web.Raa.Common.Views.Shared.DisplayTemplates;
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/Shared/ValidationSummary.cshtml")]
    public partial class ValidationSummary : System.Web.Mvc.WebViewPage<ModelStateDictionary>
    {
        public ValidationSummary()
        {
        }
        public override void Execute()
        {
            
            #line 6 "..\..\Views\Shared\ValidationSummary.cshtml"
  
var hasWarnings = Model.HasWarnings();

            
            #line default
            #line hidden
WriteLiteral("\r\n\r\n<div");

WriteLiteral(" id=\"error-summary\"");

WriteAttribute("class", Tuple.Create(" class=\"", 234), Tuple.Create("\"", 295)
, Tuple.Create(Tuple.Create("", 242), Tuple.Create("error-summary", 242), true)
            
            #line 10 "..\..\Views\Shared\ValidationSummary.cshtml"
, Tuple.Create(Tuple.Create(" ", 255), Tuple.Create<System.Object, System.Int32>(!Model.HasErrors() ? "sfa-hide" : ""
            
            #line default
            #line hidden
, 256), false)
);

WriteLiteral(" role=\"group\"");

WriteLiteral(" aria-labelledby=\"error-summary-heading-example-1\"");

WriteLiteral(" tabindex=\"-1\"");

WriteLiteral(">\r\n\r\n    <h1");

WriteLiteral(" class=\"heading-medium error-summary-heading\"");

WriteLiteral(" id=\"error-summary-heading-example-1\"");

WriteLiteral(">\r\n        Please fix these errors\r\n    </h1>\r\n\r\n    <!--<p>\r\n        Optional de" +
"scription of the errors and how to correct them\r\n    </p>-->\r\n\r\n    <ul");

WriteLiteral(" class=\"error-summary-list\"");

WriteLiteral(">\r\n");

            
            #line 21 "..\..\Views\Shared\ValidationSummary.cshtml"
        
            
            #line default
            #line hidden
            
            #line 21 "..\..\Views\Shared\ValidationSummary.cshtml"
         foreach (var modelKey in Model.Keys)
        {
            var modelState = Model[modelKey];

            var elementId = ViewData.TemplateInfo.GetFullHtmlFieldId(modelKey);
            foreach (var modelError in modelState.Errors)
            {
                if (modelError.GetType() == typeof(ModelError))
                {
                    if (elementId == string.Empty)
                    {

            
            #line default
            #line hidden
WriteLiteral("                        <li>");

            
            #line 32 "..\..\Views\Shared\ValidationSummary.cshtml"
                       Write(modelError.ErrorMessage);

            
            #line default
            #line hidden
WriteLiteral("</li>\r\n");

            
            #line 33 "..\..\Views\Shared\ValidationSummary.cshtml"
                    }
                    else
                    {

            
            #line default
            #line hidden
WriteLiteral("                        <li><a");

WriteAttribute("href", Tuple.Create(" href=\"", 1231), Tuple.Create("\"", 1262)
, Tuple.Create(Tuple.Create("", 1238), Tuple.Create("#", 1238), true)
            
            #line 36 "..\..\Views\Shared\ValidationSummary.cshtml"
, Tuple.Create(Tuple.Create("", 1239), Tuple.Create<System.Object, System.Int32>(@elementId.ToLower()
            
            #line default
            #line hidden
, 1239), false)
);

WriteLiteral(">");

            
            #line 36 "..\..\Views\Shared\ValidationSummary.cshtml"
                                                          Write(modelError.ErrorMessage);

            
            #line default
            #line hidden
WriteLiteral("</a></li>\r\n");

            
            #line 37 "..\..\Views\Shared\ValidationSummary.cshtml"
                    }
                }
            }
        }

            
            #line default
            #line hidden
WriteLiteral("    </ul>\r\n\r\n</div>\r\n\r\n<div");

WriteLiteral(" id=\"warning-summary \"");

WriteAttribute("class", Tuple.Create(" class=\"", 1416), Tuple.Create("\"", 1473)
, Tuple.Create(Tuple.Create("", 1424), Tuple.Create("warning-summary", 1424), true)
            
            #line 45 "..\..\Views\Shared\ValidationSummary.cshtml"
, Tuple.Create(Tuple.Create(" ", 1439), Tuple.Create<System.Object, System.Int32>(!hasWarnings ? "sfa-hide" : ""
            
            #line default
            #line hidden
, 1440), false)
);

WriteLiteral(" role=\"group\"");

WriteLiteral(" aria-labelledby=\"error-summary-heading-example-1\"");

WriteLiteral(" tabindex=\"-1\"");

WriteLiteral(">\r\n\r\n    <h1");

WriteLiteral(" class=\"heading-medium error-summary-heading\"");

WriteLiteral(" id=\"error-summary-heading-example-1\"");

WriteLiteral(">\r\n        Please fix these errors\r\n    </h1>\r\n\r\n    <!--<p>\r\n        Optional de" +
"scription of the errors and how to correct them\r\n    </p>-->\r\n\r\n    <ul");

WriteLiteral(" class=\"error-summary-list\"");

WriteLiteral(">\r\n");

            
            #line 56 "..\..\Views\Shared\ValidationSummary.cshtml"
        
            
            #line default
            #line hidden
            
            #line 56 "..\..\Views\Shared\ValidationSummary.cshtml"
         foreach (var modelKey in Model.Keys)
        {
            var modelState = Model[modelKey];
            var elementId = ViewData.TemplateInfo.GetFullHtmlFieldId(modelKey);

            var anyError = modelState.Errors.Any(modelError => modelError.GetType() == typeof(ModelError));
            foreach (var modelError in modelState.Errors)
            {
                if (modelError.GetType() == typeof(ModelWarning) && !anyError)
                {
                    if (elementId == string.Empty)
                    {

            
            #line default
            #line hidden
WriteLiteral("                        <li>");

            
            #line 68 "..\..\Views\Shared\ValidationSummary.cshtml"
                       Write(modelError.ErrorMessage);

            
            #line default
            #line hidden
WriteLiteral("</li>\r\n");

            
            #line 69 "..\..\Views\Shared\ValidationSummary.cshtml"
                    }
                    else
                    {

            
            #line default
            #line hidden
WriteLiteral("                        <li><a");

WriteAttribute("href", Tuple.Create(" href=\"", 2533), Tuple.Create("\"", 2564)
, Tuple.Create(Tuple.Create("", 2540), Tuple.Create("#", 2540), true)
            
            #line 72 "..\..\Views\Shared\ValidationSummary.cshtml"
, Tuple.Create(Tuple.Create("", 2541), Tuple.Create<System.Object, System.Int32>(@elementId.ToLower()
            
            #line default
            #line hidden
, 2541), false)
);

WriteLiteral(">");

            
            #line 72 "..\..\Views\Shared\ValidationSummary.cshtml"
                                                          Write(modelError.ErrorMessage);

            
            #line default
            #line hidden
WriteLiteral("</a></li>\r\n");

            
            #line 73 "..\..\Views\Shared\ValidationSummary.cshtml"
                    }
                }
            }
        }

            
            #line default
            #line hidden
WriteLiteral("    </ul>\r\n</div>\r\n\r\n\r\n");

            
            #line 81 "..\..\Views\Shared\ValidationSummary.cshtml"
Write(Html.Hidden("acceptWarnings", hasWarnings));

            
            #line default
            #line hidden
        }
    }
}
#pragma warning restore 1591
