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

namespace SFA.Apprenticeships.Web.Raa.Common.Views.Shared.DisplayTemplates
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
    using SFA.Apprenticeships.Web.Common.Constants;
    using SFA.Apprenticeships.Web.Common.Framework;
    using SFA.Apprenticeships.Web.Common.Models.Common;
    using SFA.Apprenticeships.Web.Raa.Common;
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/Shared/DisplayTemplates/DateTime.cshtml")]
    public partial class DateTime_ : System.Web.Mvc.WebViewPage<DateTime>
    {
        public DateTime_()
        {
        }
        public override void Execute()
        {
            
            #line 2 "..\..\Views\Shared\DisplayTemplates\DateTime.cshtml"
  
    var timeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById("GMT Standard Time");
    var dataTimeByZoneId = TimeZoneInfo.ConvertTime(Model.ToUniversalTime(), timeZoneInfo);

            
            #line default
            #line hidden
WriteLiteral("\r\n");

            
            #line 6 "..\..\Views\Shared\DisplayTemplates\DateTime.cshtml"
Write(dataTimeByZoneId.ToString("dd MMM yyyy"));

            
            #line default
            #line hidden
        }
    }
}
#pragma warning restore 1591
