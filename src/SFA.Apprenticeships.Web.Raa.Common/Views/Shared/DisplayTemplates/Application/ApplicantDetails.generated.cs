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
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/Shared/DisplayTemplates/Application/ApplicantDetails.cshtml")]
    public partial class ApplicantDetails : System.Web.Mvc.WebViewPage<SFA.Apprenticeships.Web.Raa.Common.ViewModels.Application.ApplicantDetailsViewModel>
    {
        public ApplicantDetails()
        {
        }
        public override void Execute()
        {
WriteLiteral("<section");

WriteLiteral(" class=\"inner-block-padr\"");

WriteLiteral(">\r\n    <div");

WriteLiteral(" class=\"panel-indent\"");

WriteLiteral(">\r\n        <ul");

WriteLiteral(" class=\"list-text\"");

WriteLiteral(">\r\n            <li>");

            
            #line 6 "..\..\Views\Shared\DisplayTemplates\Application\ApplicantDetails.cshtml"
           Write(Model.Name);

            
            #line default
            #line hidden
WriteLiteral("</li>\r\n        </ul>\r\n        <ul");

WriteLiteral(" class=\"list-text\"");

WriteLiteral(">\r\n            <li>");

            
            #line 9 "..\..\Views\Shared\DisplayTemplates\Application\ApplicantDetails.cshtml"
           Write(Model.Address.AddressLine1);

            
            #line default
            #line hidden
WriteLiteral("</li>\r\n            <li>");

            
            #line 10 "..\..\Views\Shared\DisplayTemplates\Application\ApplicantDetails.cshtml"
           Write(Model.Address.AddressLine2);

            
            #line default
            #line hidden
WriteLiteral("</li>\r\n            <li>");

            
            #line 11 "..\..\Views\Shared\DisplayTemplates\Application\ApplicantDetails.cshtml"
           Write(Model.Address.AddressLine3);

            
            #line default
            #line hidden
WriteLiteral("</li>\r\n            <li>");

            
            #line 12 "..\..\Views\Shared\DisplayTemplates\Application\ApplicantDetails.cshtml"
           Write(Model.Address.AddressLine4);

            
            #line default
            #line hidden
WriteLiteral("</li>\r\n            <li>");

            
            #line 13 "..\..\Views\Shared\DisplayTemplates\Application\ApplicantDetails.cshtml"
           Write(Model.Address.Postcode);

            
            #line default
            #line hidden
WriteLiteral("</li>\r\n        </ul>\r\n        <ul");

WriteLiteral(" class=\"list-text\"");

WriteLiteral(">\r\n            <li>");

            
            #line 16 "..\..\Views\Shared\DisplayTemplates\Application\ApplicantDetails.cshtml"
           Write(Model.PhoneNumber);

            
            #line default
            #line hidden
WriteLiteral("</li>\r\n            <li>\r\n                <a");

WriteAttribute("href", Tuple.Create(" href=\"", 645), Tuple.Create("\"", 671)
            
            #line 18 "..\..\Views\Shared\DisplayTemplates\Application\ApplicantDetails.cshtml"
, Tuple.Create(Tuple.Create("", 652), Tuple.Create<System.Object, System.Int32>(Model.EmailAddress
            
            #line default
            #line hidden
, 652), false)
);

WriteLiteral(">");

            
            #line 18 "..\..\Views\Shared\DisplayTemplates\Application\ApplicantDetails.cshtml"
                                         Write(Model.EmailAddress);

            
            #line default
            #line hidden
WriteLiteral("</a>\r\n            </li>\r\n        </ul>\r\n    </div>\r\n</section>");

        }
    }
}
#pragma warning restore 1591