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

namespace SFA.Apprenticeships.Web.Common.Views.Shared
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
    
    #line 1 "..\..\Views\Shared\_ApprenticeMinimumWageExplained.cshtml"
    using SFA.Apprenticeships.Domain.Entities.Raa.Vacancies.Constants;
    
    #line default
    #line hidden
    using SFA.Apprenticeships.Web.Common;
    using SFA.Apprenticeships.Web.Common.Constants;
    using SFA.Apprenticeships.Web.Common.Framework;
    using SFA.Apprenticeships.Web.Common.Models.Common;
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/Shared/_ApprenticeMinimumWageExplained.cshtml")]
    public partial class ApprenticeMinimumWageExplained : System.Web.Mvc.WebViewPage<DateTime>
    {
        public ApprenticeMinimumWageExplained()
        {
        }
        public override void Execute()
        {
WriteLiteral("<details>\r\n    <summary><span");

WriteLiteral(" class=\"summary\"");

WriteLiteral(">Wages explained</span></summary>\r\n    <div");

WriteLiteral(" class=\"panel panel-border-narrow\"");

WriteLiteral(">\r\n");

            
            #line 7 "..\..\Views\Shared\_ApprenticeMinimumWageExplained.cshtml"
        
            
            #line default
            #line hidden
            
            #line 7 "..\..\Views\Shared\_ApprenticeMinimumWageExplained.cshtml"
         if (Model < Wages.Ranges[0].ValidTo) //Special case for the run up to the change
        {

            
            #line default
            #line hidden
WriteLiteral("            <p>\r\n                The current National Minimum Wage (NMW) for appr" +
"entices is £");

            
            #line 10 "..\..\Views\Shared\_ApprenticeMinimumWageExplained.cshtml"
                                                                       Write(Wages.Ranges[0].ApprenticeMinimumWage);

            
            #line default
            #line hidden
WriteLiteral(" per hour. This will increase to £");

            
            #line 10 "..\..\Views\Shared\_ApprenticeMinimumWageExplained.cshtml"
                                                                                                                                               Write(Wages.Ranges[1].ApprenticeMinimumWage);

            
            #line default
            #line hidden
WriteLiteral(@" on the 1 Oct 2016. This rate applies to apprentices aged 16 to 18 and those aged 19 or over who are in their first year. Apprentices must be paid at least the NMW for their age if they're aged 19 or over and have completed their first year
            </p>
");

            
            #line 12 "..\..\Views\Shared\_ApprenticeMinimumWageExplained.cshtml"
        }
        else
        {

            
            #line default
            #line hidden
WriteLiteral("            <p>\r\n                The current National Minimum Wage for an apprent" +
"ice is £");

            
            #line 16 "..\..\Views\Shared\_ApprenticeMinimumWageExplained.cshtml"
                                                                   Write(Wages.GetWageRangeFor(Model).ApprenticeMinimumWage);

            
            #line default
            #line hidden
WriteLiteral(@" an hour. This rate applies to apprentices under 19 and those aged 19 or over who are in their first year.<br />
                Apprentices must be paid at least the minimum wage rate for their age if they are aged 19 or over and have completed their first year.<br />
                The minimum wage rates are £");

            
            #line 18 "..\..\Views\Shared\_ApprenticeMinimumWageExplained.cshtml"
                                       Write(Wages.GetWageRangeFor(Model).Between18And20NationalMinimumWage);

            
            #line default
            #line hidden
WriteLiteral(" an hour for 18-20 year olds and £");

            
            #line 18 "..\..\Views\Shared\_ApprenticeMinimumWageExplained.cshtml"
                                                                                                                                        Write(Wages.GetWageRangeFor(Model).Over21NationalMinimumWage);

            
            #line default
            #line hidden
WriteLiteral(" for anyone aged 21 and over.<br />\r\n                Apprentices are paid for the" +
"ir normal working hours and training that’s part of their apprenticeship (usuall" +
"y one day per week).\r\n            </p>\r\n");

            
            #line 21 "..\..\Views\Shared\_ApprenticeMinimumWageExplained.cshtml"
        }

            
            #line default
            #line hidden
WriteLiteral("    </div>\r\n</details>");

        }
    }
}
#pragma warning restore 1591
