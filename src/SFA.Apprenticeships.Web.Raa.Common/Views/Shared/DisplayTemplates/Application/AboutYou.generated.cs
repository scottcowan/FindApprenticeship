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
WriteLiteral("\r\n<h2");

WriteLiteral(" class=\"heading-large\"");

WriteLiteral(">About you</h2>\r\n<h3");

WriteLiteral(" class=\"heading-small\"");

WriteLiteral(">What are your main strengths?</h3>\r\n<p>");

            
            #line 6 "..\..\Views\Shared\DisplayTemplates\Application\AboutYou.cshtml"
Write(Model.Strengths ?? "-");

            
            #line default
            #line hidden
WriteLiteral("</p>\r\n\r\n<h3");

WriteLiteral(" class=\"heading-small\"");

WriteLiteral(">What skills would you like to improve during this apprenticeship?</h3>\r\n<p>");

            
            #line 9 "..\..\Views\Shared\DisplayTemplates\Application\AboutYou.cshtml"
Write(Model.Improvements ?? "-");

            
            #line default
            #line hidden
WriteLiteral("</p>\r\n\r\n<h3");

WriteLiteral(" class=\"heading-small\"");

WriteLiteral(">What are your hobbies and interests?</h3>\r\n<p>");

            
            #line 12 "..\..\Views\Shared\DisplayTemplates\Application\AboutYou.cshtml"
Write(Model.HobbiesAndInterests ?? "-");

            
            #line default
            #line hidden
WriteLiteral("</p>\r\n\r\n<hr/>");

        }
    }
}
#pragma warning restore 1591
