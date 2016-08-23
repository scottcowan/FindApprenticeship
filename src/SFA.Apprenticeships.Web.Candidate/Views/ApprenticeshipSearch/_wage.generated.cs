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

namespace SFA.Apprenticeships.Web.Candidate.Views.ApprenticeshipSearch
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
    
    #line 1 "..\..\Views\ApprenticeshipSearch\_wage.cshtml"
    using SFA.Apprenticeships.Domain.Entities.Vacancies;
    
    #line default
    #line hidden
    using SFA.Apprenticeships.Infrastructure.Presentation;
    
    #line 2 "..\..\Views\ApprenticeshipSearch\_wage.cshtml"
    using SFA.Apprenticeships.Infrastructure.Presentation.Constants;
    
    #line default
    #line hidden
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
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/ApprenticeshipSearch/_wage.cshtml")]
    public partial class wage : System.Web.Mvc.WebViewPage<ApprenticeshipVacancyDetailViewModel>
    {
        public wage()
        {
        }
        public override void Execute()
        {
WriteLiteral("\r\n");

WriteLiteral("<div>\r\n    <h3");

WriteLiteral(" class=\"bold-small\"");

WriteLiteral(">");

            
            #line 7 "..\..\Views\ApprenticeshipSearch\_wage.cshtml"
                      Write(Model.WageUnit.GetHeaderDisplayText());

            
            #line default
            #line hidden
WriteLiteral("</h3>\r\n    <p");

WriteLiteral(" id=\"vacancy-wage\"");

WriteLiteral(">\r\n");

WriteLiteral("        ");

            
            #line 9 "..\..\Views\ApprenticeshipSearch\_wage.cshtml"
   Write(Model.Wage);

            
            #line default
            #line hidden
WriteLiteral("\r\n    </p>\r\n</div>\r\n\r\n");

            
            #line 13 "..\..\Views\ApprenticeshipSearch\_wage.cshtml"
 if (Model.WageType == WageType.ApprenticeshipMinimum)
{

            
            #line default
            #line hidden
WriteLiteral("    <details>\r\n        <summary>Wages explained</summary>\r\n        <div");

WriteLiteral(" class=\"detail-content\"");

WriteLiteral(">\r\n            The current National Minimum Wage (NMW) for apprentices is £");

            
            #line 18 "..\..\Views\ApprenticeshipSearch\_wage.cshtml"
                                                                   Write(Wages.ApprenticeMinimumWage);

            
            #line default
            #line hidden
WriteLiteral(@" per hour.<br />
            This rate applies to apprentices aged 16 to 18 and those aged 19 or over who are in their first year.<br />
            Apprentices must be paid at least the NMW for their age if they're aged 19 or over and have completed their first year.
        </div>
    </details>
");

            
            #line 23 "..\..\Views\ApprenticeshipSearch\_wage.cshtml"
}

            
            #line default
            #line hidden
WriteLiteral("\r\n");

            
            #line 25 "..\..\Views\ApprenticeshipSearch\_wage.cshtml"
 if (Model.WageType == WageType.NationalMinimum)
{

            
            #line default
            #line hidden
WriteLiteral("    <details>\r\n        <summary>Wages explained</summary>\r\n        <div");

WriteLiteral(" class=\"detail-content\"");

WriteLiteral(">\r\n            The current National Minimum Wage rates are £");

            
            #line 30 "..\..\Views\ApprenticeshipSearch\_wage.cshtml"
                                                    Write(Wages.Between18And20NationalMinimumWage);

            
            #line default
            #line hidden
WriteLiteral(" for 18 to 20 year-olds and £");

            
            #line 30 "..\..\Views\ApprenticeshipSearch\_wage.cshtml"
                                                                                                                         Write(Wages.Over21NationalMinimumWage);

            
            #line default
            #line hidden
WriteLiteral(" for anyone aged 21 and over.<br />\r\n            Apprentices are paid for their n" +
"ormal working hours and training that’s part of their apprenticeship (usually on" +
"e day per week).\r\n        </div>\r\n    </details>\r\n");

            
            #line 34 "..\..\Views\ApprenticeshipSearch\_wage.cshtml"
}

            
            #line default
            #line hidden
        }
    }
}
#pragma warning restore 1591
