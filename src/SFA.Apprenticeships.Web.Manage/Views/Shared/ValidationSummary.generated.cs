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
WriteLiteral("<div");

WriteLiteral(" id=\"validation-summary-errors\"");

WriteAttribute("class", Tuple.Create(" class=\'", 197), Tuple.Create("\'", 303)
            
            #line 6 "..\..\Views\Shared\ValidationSummary.cshtml"
, Tuple.Create(Tuple.Create("", 205), Tuple.Create<System.Object, System.Int32>(Model.HasErrors() ? "validation-summary-errors" : "validation-summary-valid"
            
            #line default
            #line hidden
, 205), false)
, Tuple.Create(Tuple.Create(" ", 284), Tuple.Create("panel", 285), true)
, Tuple.Create(Tuple.Create(" ", 290), Tuple.Create("panel-danger", 291), true)
);

WriteLiteral(" data-valmsg-summary=\"true\"");

WriteLiteral(">\r\n    <div");

WriteLiteral(" class=\"panel-body\"");

WriteLiteral(">\r\n        <ul>\r\n");

            
            #line 9 "..\..\Views\Shared\ValidationSummary.cshtml"
            
            
            #line default
            #line hidden
            
            #line 9 "..\..\Views\Shared\ValidationSummary.cshtml"
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
WriteLiteral("                            <li>");

            
            #line 20 "..\..\Views\Shared\ValidationSummary.cshtml"
                           Write(modelError.ErrorMessage);

            
            #line default
            #line hidden
WriteLiteral("</li>\r\n");

            
            #line 21 "..\..\Views\Shared\ValidationSummary.cshtml"
                        }
                        else
                        {

            
            #line default
            #line hidden
WriteLiteral("                            <li><a");

WriteAttribute("href", Tuple.Create(" href=\"", 1020), Tuple.Create("\"", 1051)
, Tuple.Create(Tuple.Create("", 1027), Tuple.Create("#", 1027), true)
            
            #line 24 "..\..\Views\Shared\ValidationSummary.cshtml"
, Tuple.Create(Tuple.Create("", 1028), Tuple.Create<System.Object, System.Int32>(@elementId.ToLower()
            
            #line default
            #line hidden
, 1028), false)
);

WriteLiteral(">");

            
            #line 24 "..\..\Views\Shared\ValidationSummary.cshtml"
                                                              Write(modelError.ErrorMessage);

            
            #line default
            #line hidden
WriteLiteral("</a></li>\r\n");

            
            #line 25 "..\..\Views\Shared\ValidationSummary.cshtml"
                        }
                    }
                }
            }

            
            #line default
            #line hidden
WriteLiteral("        </ul>\r\n    </div>\r\n</div>\r\n\r\n");

            
            #line 33 "..\..\Views\Shared\ValidationSummary.cshtml"
  
    var hasWarnings = Model.HasWarnings();

            
            #line default
            #line hidden
WriteLiteral("\r\n\r\n<div");

WriteLiteral(" id=\"validation-summary-warnings\"");

WriteAttribute("class", Tuple.Create(" class=\'", 1299), Tuple.Create("\'", 1402)
            
            #line 37 "..\..\Views\Shared\ValidationSummary.cshtml"
, Tuple.Create(Tuple.Create("", 1307), Tuple.Create<System.Object, System.Int32>(hasWarnings ? "validation-summary-warnings" : "validation-summary-valid"
            
            #line default
            #line hidden
, 1307), false)
, Tuple.Create(Tuple.Create(" ", 1382), Tuple.Create("panel", 1383), true)
, Tuple.Create(Tuple.Create(" ", 1388), Tuple.Create("panel-warning", 1389), true)
);

WriteLiteral(">\r\n    <div");

WriteLiteral(" class=\"panel-body\"");

WriteLiteral(">\r\n        <ul>\r\n");

            
            #line 40 "..\..\Views\Shared\ValidationSummary.cshtml"
            
            
            #line default
            #line hidden
            
            #line 40 "..\..\Views\Shared\ValidationSummary.cshtml"
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
WriteLiteral("                            <li>");

            
            #line 51 "..\..\Views\Shared\ValidationSummary.cshtml"
                           Write(modelError.ErrorMessage);

            
            #line default
            #line hidden
WriteLiteral("</li>\r\n");

            
            #line 52 "..\..\Views\Shared\ValidationSummary.cshtml"
                        }
                        else
                        {

            
            #line default
            #line hidden
WriteLiteral("                            <li><a");

WriteAttribute("href", Tuple.Create(" href=\"", 2218), Tuple.Create("\"", 2249)
, Tuple.Create(Tuple.Create("", 2225), Tuple.Create("#", 2225), true)
            
            #line 55 "..\..\Views\Shared\ValidationSummary.cshtml"
, Tuple.Create(Tuple.Create("", 2226), Tuple.Create<System.Object, System.Int32>(@elementId.ToLower()
            
            #line default
            #line hidden
, 2226), false)
);

WriteLiteral(">");

            
            #line 55 "..\..\Views\Shared\ValidationSummary.cshtml"
                                                              Write(modelError.ErrorMessage);

            
            #line default
            #line hidden
WriteLiteral("</a></li>\r\n");

            
            #line 56 "..\..\Views\Shared\ValidationSummary.cshtml"
                        }
                    }
                }
            }

            
            #line default
            #line hidden
WriteLiteral("        </ul>\r\n    </div>\r\n</div>");

        }
    }
}
#pragma warning restore 1591
