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
    using SFA.Apprenticeships.Infrastructure.Presentation;
    using SFA.Apprenticeships.Web.Candidate;
    using SFA.Apprenticeships.Web.Candidate.Constants;
    using SFA.Apprenticeships.Web.Candidate.Constants.ViewModels;
    
    #line 1 "..\..\Views\ApprenticeshipSearch\_pagination.cshtml"
    using SFA.Apprenticeships.Web.Candidate.Extensions;
    
    #line default
    #line hidden
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
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/ApprenticeshipSearch/_pagination.cshtml")]
    public partial class pagination : System.Web.Mvc.WebViewPage<ApprenticeshipSearchResponseViewModel>
    {
        public pagination()
        {
        }
        public override void Execute()
        {
            
            #line 4 "..\..\Views\ApprenticeshipSearch\_pagination.cshtml"
  
    var pages = Model.Pages;
    var prevLink = Model.VacancySearch.PageNumber > 1 ? Url.ApprenticeshipSearchViewModelRouteUrl(CandidateRouteNames.ApprenticeshipResults, new ApprenticeshipSearchViewModel(Model.VacancySearch) { PageNumber = Model.PrevPage, LocationType = Model.VacancySearch.LocationType, SearchAction = SearchAction.Sort }) : "#";
    var nextLink = Model.VacancySearch.PageNumber < pages ? Url.ApprenticeshipSearchViewModelRouteUrl(CandidateRouteNames.ApprenticeshipResults, new ApprenticeshipSearchViewModel(Model.VacancySearch) { PageNumber = Model.NextPage, LocationType = Model.VacancySearch.LocationType, SearchAction = SearchAction.Sort }) : "#";

            
            #line default
            #line hidden
WriteLiteral("\r\n\r\n");

            
            #line 10 "..\..\Views\ApprenticeshipSearch\_pagination.cshtml"
 if (Model.TotalLocalHits > 0 || Model.TotalNationalHits > 0 )
{

            
            #line default
            #line hidden
WriteLiteral("    <div");

WriteLiteral(" class=\"page-navigation grid-row\"");

WriteLiteral(">\r\n        <a");

WriteAttribute("href", Tuple.Create(" href=\"", 905), Tuple.Create("\"", 921)
            
            #line 13 "..\..\Views\ApprenticeshipSearch\_pagination.cshtml"
, Tuple.Create(Tuple.Create("", 912), Tuple.Create<System.Object, System.Int32>(prevLink
            
            #line default
            #line hidden
, 912), false)
);

WriteAttribute("style", Tuple.Create("\r\n           style=\"", 922), Tuple.Create("\"", 1015)
, Tuple.Create(Tuple.Create("", 942), Tuple.Create("visibility:", 942), true)
            
            #line 14 "..\..\Views\ApprenticeshipSearch\_pagination.cshtml"
, Tuple.Create(Tuple.Create(" ", 953), Tuple.Create<System.Object, System.Int32>(Model.VacancySearch.PageNumber == 1 ? "hidden" : "visible"
            
            #line default
            #line hidden
, 954), false)
);

WriteLiteral(" class=\"page-navigation__btn previous column-one-half\"");

WriteLiteral(">\r\n            <i");

WriteLiteral(" class=\"arrow-button fa fa-angle-left\"");

WriteLiteral("></i>\r\n            <span");

WriteLiteral(" class=\"description\"");

WriteLiteral(">Previous <span");

WriteLiteral(" class=\"sfa-hide-mobile\"");

WriteLiteral(">page</span></span>\r\n            <span");

WriteLiteral(" class=\"counter\"");

WriteLiteral(">");

            
            #line 17 "..\..\Views\ApprenticeshipSearch\_pagination.cshtml"
                             Write(Model.PrevPage);

            
            #line default
            #line hidden
WriteLiteral(" of ");

            
            #line 17 "..\..\Views\ApprenticeshipSearch\_pagination.cshtml"
                                                Write(pages);

            
            #line default
            #line hidden
WriteLiteral("</span>\r\n        </a>\r\n        <a");

WriteAttribute("href", Tuple.Create(" href=\"", 1321), Tuple.Create("\"", 1337)
            
            #line 19 "..\..\Views\ApprenticeshipSearch\_pagination.cshtml"
, Tuple.Create(Tuple.Create("", 1328), Tuple.Create<System.Object, System.Int32>(nextLink
            
            #line default
            #line hidden
, 1328), false)
);

WriteAttribute("style", Tuple.Create("\r\n           style=\"", 1338), Tuple.Create("\"", 1435)
, Tuple.Create(Tuple.Create("", 1358), Tuple.Create("visibility:", 1358), true)
            
            #line 20 "..\..\Views\ApprenticeshipSearch\_pagination.cshtml"
, Tuple.Create(Tuple.Create(" ", 1369), Tuple.Create<System.Object, System.Int32>(Model.VacancySearch.PageNumber == pages ? "hidden" : "visible"
            
            #line default
            #line hidden
, 1370), false)
);

WriteLiteral(" class=\"page-navigation__btn next column-one-half\"");

WriteLiteral(">\r\n            <i");

WriteLiteral(" class=\"arrow-button fa fa-angle-right\"");

WriteLiteral("></i>\r\n            <span");

WriteLiteral(" class=\"description\"");

WriteLiteral(">Next <span");

WriteLiteral(" class=\"sfa-hide-mobile\"");

WriteLiteral(">page</span></span>\r\n            <span");

WriteLiteral(" class=\"counter\"");

WriteLiteral(">");

            
            #line 23 "..\..\Views\ApprenticeshipSearch\_pagination.cshtml"
                             Write(Model.NextPage);

            
            #line default
            #line hidden
WriteLiteral(" of ");

            
            #line 23 "..\..\Views\ApprenticeshipSearch\_pagination.cshtml"
                                                Write(pages);

            
            #line default
            #line hidden
WriteLiteral("</span>\r\n        </a>\r\n    </div>\r\n");

            
            #line 26 "..\..\Views\ApprenticeshipSearch\_pagination.cshtml"
}
            
            #line default
            #line hidden
        }
    }
}
#pragma warning restore 1591
