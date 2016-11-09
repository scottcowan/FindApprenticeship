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

namespace SFA.Apprenticeships.Web.Candidate.Views.Home
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
    using SFA.Apprenticeships.Web.Common.Views.Shared.DisplayTemplates;
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/Home/Privacy.cshtml")]
    public partial class Privacy : System.Web.Mvc.WebViewPage<dynamic>
    {
        public Privacy()
        {
        }
        public override void Execute()
        {
            
            #line 1 "..\..\Views\Home\Privacy.cshtml"
  
    ViewBag.Title = "Privacy and cookies - Find an apprenticeship";
    Layout = "~/Views/Shared/_Layout.cshtml";

            
            #line default
            #line hidden
WriteLiteral("\r\n\r\n<div");

WriteLiteral(" class=\"hgroup\"");

WriteLiteral(">\r\n    <h1");

WriteLiteral(" id=\"h1header\"");

WriteLiteral(" class=\"heading-xlarge\"");

WriteLiteral(">Privacy and cookies</h1>\r\n</div>\r\n\r\n<section");

WriteLiteral(" class=\"text\"");

WriteLiteral(">\r\n    <h2");

WriteLiteral(" class=\"heading-large\"");

WriteLiteral(">Privacy</h2>\r\n    <p>\r\n        This service is run by the Skills Funding Agency " +
"(“SFA”). We’ll handle the information you give to us according to the\r\n        <" +
"a");

WriteLiteral(" href=\"https://www.gov.uk/government/publications/sfa-privacy-notice\"");

WriteLiteral(" rel=\"external\"");

WriteLiteral(" target=\"_blank\"");

WriteLiteral(@">Skills Funding Agency personal information charter</a>.
    </p>
    <p>When you register on the service, the personal information you give us will be used:</p>
    <ul>
        <li>so you can apply for an apprenticeship or traineeship</li>
        <li>to match you to apprenticeships/traineeships</li>
        <li>to help provide career support through the National Careers Service</li>
        <li>for administration and research purposes</li>
    </ul>
</section>

<section");

WriteLiteral(" class=\"text\"");

WriteLiteral(">\r\n    <h2");

WriteLiteral(" class=\"heading-medium\"");

WriteLiteral(@">How long we hold your data</h2>
    <p>If you haven’t signed in for 12 months or activated your account within 30 days of registering we’ll delete your account and remove your personal details. You’ll need to register again to use the service.</p>
</section>

<section");

WriteLiteral(" class=\"text\"");

WriteLiteral(">\r\n    <h2");

WriteLiteral(" class=\"heading-large\"");

WriteLiteral(@">Cookies</h2>
    <p>This service puts small files (known as ‘cookies’) on to your computer. Most websites do this. These cookies are used to:</p>
    <ul>
        <li>help us understand how you use the service, so we can improve it</li>
        <li>remember what notifications you’ve seen so you’re not shown them again</li>
        <li>temporarily store the information you enter (eg, your postcode)</li>
    </ul>
    <p>The cookies aren’t used to identify you personally. They’re put on to your computer to make the service work better for you. You can edit or delete the cookies.</p>
    <p>Find out how to <a");

WriteLiteral(" rel=\"external\"");

WriteLiteral(" target=\"_blank\"");

WriteLiteral(" href=\"http://www.aboutcookies.org/\"");

WriteLiteral(">edit and delete cookies</a>.</p>\r\n</section>\r\n\r\n<section");

WriteLiteral(" class=\"text\"");

WriteLiteral(">\r\n    <h2");

WriteLiteral(" class=\"heading-medium\"");

WriteLiteral(@">Webtrends analytics cookie</h2>
    <p>We use Webtrends to collect information about how you use the service. This information helps us to make improvements.</p>
    <p>The Webtrends analytics cookie collects and stores information about:</p>
    <ul>
        <li>the pages you visit</li>
        <li>how long you spend on each page</li>
        <li>how you got to the service</li>
        <li>what you click on while you’re using the service</li>
    </ul>
    <p>Webtrends isn’t allowed to use or share our analytics data with anyone, but you can <a");

WriteAttribute("href", Tuple.Create(" href=\"", 2748), Tuple.Create("\"", 2796)
            
            #line 52 "..\..\Views\Home\Privacy.cshtml"
                    , Tuple.Create(Tuple.Create("", 2755), Tuple.Create<System.Object, System.Int32>(Url.RouteUrl(RouteNames.WebTrendsOptOut)
            
            #line default
            #line hidden
, 2755), false)
);

WriteLiteral(">opt out</a> if you wish.</p>\r\n    <table>\r\n        <colgroup>\r\n            <col");

WriteLiteral(" class=\"t20\"");

WriteLiteral(" />\r\n            <col");

WriteLiteral(" class=\"t60\"");

WriteLiteral(" />\r\n            <col");

WriteLiteral(" class=\"t20\"");

WriteLiteral(@" />
            <col />
        </colgroup>
        <thead>
            <tr>
                <th>
                    Name
                </th>
                <th>
                    Purpose
                </th>
                <th>
                    Expires
                </th>
            </tr>
        </thead>
        <tr>
            <td>
                WT_FPC
            </td>
            <td>
                Measures the number and volume of visitors
            </td>
            <td>
                2 years
            </td>
        </tr>
        <tr>
            <td>
                ACOOKIE
            </td>
            <td>
                Measures the number and volume of visitors
            </td>
            <td>
                10 years
            </td>
        </tr>
        <tr>
            <td>
                WEBTRENDS_ID
            </td>
            <td>
                Measures the number and volume of visitors
            </td>
            <td>
                10 years
            </td>
        </tr>
        <tr>
            <td>
                WTLOPTOUT
            </td>
            <td>
                Specifies that you have opted out of Webtrends analytics collection
            </td>
            <td>
               5 years
            </td>
        </tr>
    </table>
</section>

<section");

WriteLiteral(" class=\"text\"");

WriteLiteral(">\r\n    <h2");

WriteLiteral(" class=\"heading-medium\"");

WriteLiteral(">Google cookies</h2>\r\n    <p>We use Google Maps to display the location of appren" +
"ticeships/traineeships. Google stores two cookies on your computer for this serv" +
"ice.</p>\r\n    <table>\r\n        <colgroup>\r\n            <col");

WriteLiteral(" class=\"t20\"");

WriteLiteral(" />\r\n            <col");

WriteLiteral(" class=\"t60\"");

WriteLiteral(" />\r\n            <col");

WriteLiteral(" class=\"t20\"");

WriteLiteral(@" />
            <col />
        </colgroup>
        <thead>
            <tr>
                <th>
                    Name
                </th>
                <th>
                    Purpose
                </th>
                <th>
                    Expires
                </th>
            </tr>
        </thead>
        <tr>
            <td>
                PREF
            </td>
            <td>
                Allows Google to remember preferences such as language and layout.
            </td>
            <td>
                1 year
            </td>
        </tr>
        <tr>
            <td>
                NID
            </td>
            <td>
                Allows Google to customise adverts on its own websites.
            </td>
            <td>
                6 months
            </td>
        </tr>
    </table>
</section>

<section");

WriteLiteral(" class=\"text\"");

WriteLiteral(">\r\n    <h2");

WriteLiteral(" class=\"heading-medium\"");

WriteLiteral(">CloudFlare cookies</h2>\r\n    <p>We use CloudFlare cookies to support the assets " +
"of this service.</p>\r\n    <table>\r\n        <colgroup>\r\n            <col");

WriteLiteral(" class=\"t20\"");

WriteLiteral(" />\r\n            <col");

WriteLiteral(" class=\"t60\"");

WriteLiteral(" />\r\n            <col");

WriteLiteral(" class=\"t20\"");

WriteLiteral(@" />
            <col />
        </colgroup>
        <thead>
            <tr>
                <th>
                    Name
                </th>
                <th>
                    Purpose
                </th>
                <th>
                    Expires
                </th>
            </tr>
        </thead>
        <tr>
            <td>
                __cfduid
            </td>
            <td>
                Used to override security restrictions the user’s IP address may have.
            </td>
            <td>
                2 years
            </td>
        </tr>
        <tr>
            <td>
                _ga
            </td>
            <td>
                Allows Google to uniquely identify you as a visitor.
            </td>
            <td>
                2 years
            </td>
        </tr>
        <tr>
            <td>
                _gat
            </td>
            <td>
                Helps reduce congestion if there are too many visitors at any time. 
            </td>
            <td>
                10 minutes
            </td>
        </tr>
    </table>
</section>

<section");

WriteLiteral(" class=\"text\"");

WriteLiteral(">\r\n    <h2");

WriteLiteral(" class=\"heading-medium\"");

WriteLiteral(">Session cookies</h2>\r\n    <p>We store session cookies on your computer to help k" +
"eep your information secure while you use the service.</p>\r\n    <table>\r\n       " +
" <colgroup>\r\n            <col");

WriteLiteral(" class=\"t20\"");

WriteLiteral(" />\r\n            <col");

WriteLiteral(" class=\"t60\"");

WriteLiteral(" />\r\n            <col");

WriteLiteral(" class=\"t20\"");

WriteLiteral(" />\r\n            <col />\r\n        </colgroup>\r\n        <thead>\r\n            <tr>\r" +
"\n                <th>\r\n                    Name\r\n                </th>\r\n        " +
"        <th>\r\n                    Purpose\r\n                </th>\r\n              " +
"  <th>\r\n                    Expires\r\n                </th>\r\n            </tr>\r\n " +
"       </thead>\r\n        <tr>\r\n            <td>\r\n                User.Data\r\n    " +
"        </td>\r\n            <td>\r\n                Stores the session id and setti" +
"ngs of a signed in user that are lost when the session ends.\r\n            </td>\r" +
"\n            <td>\r\n                Session\r\n            </td>\r\n        </tr>\r\n  " +
"      <tr>\r\n            <td>\r\n                User.Context\r\n            </td>\r\n " +
"           <td>\r\n                Stores the email address and full name of a sig" +
"ned in user.\r\n            </td>\r\n            <td>\r\n                Session\r\n    " +
"        </td>\r\n        </tr>\r\n        <tr>\r\n            <td>\r\n                Us" +
"er.Auth\r\n            </td>\r\n            <td>\r\n                Stores encrypted i" +
"nformation that is used by the server to identify the signed in user.\r\n         " +
"   </td>\r\n            <td>\r\n                2 hours\r\n            </td>\r\n        " +
"</tr>\r\n        <tr>\r\n            <td>\r\n                NAS.SearchResultsDetails\r" +
"\n            </td>\r\n            <td>\r\n                Stores settings used to cu" +
"stomise the display of search results for your user.\r\n            </td>\r\n       " +
"     <td>\r\n                Session\r\n            </td>\r\n        </tr>\r\n    </tabl" +
"e>\r\n</section>\r\n\r\n<section");

WriteLiteral(" class=\"text\"");

WriteLiteral(">\r\n    <h2");

WriteLiteral(" class=\"heading-medium\"");

WriteLiteral(@">Introductory message cookies</h2>
    <p>When you first use the service, you may see pop-up ‘welcome’ or ‘help’ messages. Once you’ve seen one of these, we store a cookie on your computer so it knows not to show it to you again.</p>
    <table>
        <colgroup>
            <col");

WriteLiteral(" class=\"t20\"");

WriteLiteral(" />\r\n            <col");

WriteLiteral(" class=\"t60\"");

WriteLiteral(" />\r\n            <col");

WriteLiteral(" class=\"t20\"");

WriteLiteral(@" />
            <col />
        </colgroup>
        <thead>
            <tr>
                <th>
                    Name
                </th>
                <th>
                    Purpose
                </th>
                <th>
                    Expires
                </th>
            </tr>
        </thead>
        <tr>
            <td>
                NAS.DisplayEuCookieDirective
            </td>
            <td>
                Saves a message to let us know you've seen our cookie message.
            </td>
            <td>
                12 months
            </td>
        </tr>
        <tr>
            <td>
                NAS.CookieDetection
            </td>
            <td>
                Determines whether the user has cookies enabled.
            </td>
            <td>
                12 months
            </td>
        </tr>
        <tr>
            <td>
                NAS.Help
            </td>
            <td>
                Saves a message to let us know you've seen our help guides.
            </td>
            <td>
                12 months
            </td>
        </tr>
    </table>
</section>

<section");

WriteLiteral(" class=\"text\"");

WriteLiteral(">\r\n    <h2");

WriteLiteral(" class=\"heading-medium\"");

WriteLiteral(@">Dismissable message cookies</h2>
    <p>We will make you aware of planned outages with pop-up messages. These messages can be dismissed and, when dismissed we store a cookie on your computer so it knows not to show it to you again.</p>
    <table>
        <colgroup>
            <col");

WriteLiteral(" class=\"t20\"");

WriteLiteral(" />\r\n            <col");

WriteLiteral(" class=\"t60\"");

WriteLiteral(" />\r\n            <col");

WriteLiteral(" class=\"t20\"");

WriteLiteral(@" />
            <col />
        </colgroup>
        <thead>
            <tr>
                <th>
                    Name
                </th>
                <th>
                    Purpose
                </th>
                <th>
                    Expires
                </th>
            </tr>
        </thead>
        <tr>
            <td>
                NAS.DismissPlannedOutageMessage
            </td>
            <td>
                Lets us know that you don't want to see our planned outage message.
            </td>
            <td>
                18 hours
            </td>
        </tr>
    </table>
</section>");

        }
    }
}
#pragma warning restore 1591
