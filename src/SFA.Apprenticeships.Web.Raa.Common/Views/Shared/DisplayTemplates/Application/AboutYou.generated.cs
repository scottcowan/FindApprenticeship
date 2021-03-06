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

namespace SFA.Apprenticeships.Web.Raa.Common.Views.Shared.DisplayTemplates.Application
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
    using SFA.Apprenticeships.Web.Raa.Common;
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/Shared/DisplayTemplates/Application/AboutYou.cshtml")]
    public partial class AboutYou : System.Web.Mvc.WebViewPage<SFA.Apprenticeships.Web.Raa.Common.ViewModels.Application.AboutYouViewModel>
    {
        public AboutYou()
        {
        }
        public override void Execute()
        {
WriteLiteral("<fieldset");

WriteLiteral(" class=\"fieldset-with-border\"");

WriteLiteral(">\r\n    <legend");

WriteLiteral(" class=\"heading-large\"");

WriteLiteral(">\r\n        About you\r\n    </legend>\r\n    <div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(">\r\n        <label");

WriteLiteral(" for=\"strengths\"");

WriteLiteral(" class=\"form-label\"");

WriteLiteral(">What are your main strengths?</label>\r\n        <span");

WriteLiteral(" class=\"form-prepopped\"");

WriteLiteral(" id=\"strengths\"");

WriteLiteral(">");

            
            #line 9 "..\..\Views\Shared\DisplayTemplates\Application\AboutYou.cshtml"
                                                Write(Model.Strengths ?? "-");

            
            #line default
            #line hidden
WriteLiteral("</span>\r\n    </div>\r\n    <div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(">\r\n        <label");

WriteLiteral(" for=\"improvements\"");

WriteLiteral(" class=\"form-label\"");

WriteLiteral(">What skills would you like to improve during this apprenticeship?</label>\r\n     " +
"   <span");

WriteLiteral(" class=\"form-prepopped\"");

WriteLiteral(" id=\"improvements\"");

WriteLiteral(">");

            
            #line 13 "..\..\Views\Shared\DisplayTemplates\Application\AboutYou.cshtml"
                                                   Write(Model.Improvements ?? "-");

            
            #line default
            #line hidden
WriteLiteral("</span>\r\n    </div>\r\n    <div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(">\r\n        <label");

WriteLiteral(" for=\"hobbies-and-interests\"");

WriteLiteral(" class=\"form-label\"");

WriteLiteral(">What are your hobbies and interests?</label>\r\n        <span");

WriteLiteral(" class=\"form-prepopped\"");

WriteLiteral(" id=\"hobbies-and-interests\"");

WriteLiteral(">");

            
            #line 17 "..\..\Views\Shared\DisplayTemplates\Application\AboutYou.cshtml"
                                                            Write(Model.HobbiesAndInterests ?? "-");

            
            #line default
            #line hidden
WriteLiteral("</span>\r\n    </div>\r\n</fieldset>");

        }
    }
}
#pragma warning restore 1591
