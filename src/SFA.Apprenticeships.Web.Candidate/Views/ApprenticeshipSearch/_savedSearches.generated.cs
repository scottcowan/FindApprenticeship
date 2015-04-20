﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18444
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
    
    #line 1 "..\..\Views\ApprenticeshipSearch\_savedSearches.cshtml"
    using SFA.Apprenticeships.Domain.Entities.Vacancies.Apprenticeships;
    
    #line default
    #line hidden
    using SFA.Apprenticeships.Web.Candidate;
    using SFA.Apprenticeships.Web.Candidate.Constants;
    using SFA.Apprenticeships.Web.Candidate.Constants.ViewModels;
    using SFA.Apprenticeships.Web.Candidate.Helpers;
    using SFA.Apprenticeships.Web.Candidate.ViewModels;
    using SFA.Apprenticeships.Web.Candidate.ViewModels.Candidate;
    using SFA.Apprenticeships.Web.Candidate.ViewModels.Locations;
    using SFA.Apprenticeships.Web.Candidate.ViewModels.Login;
    using SFA.Apprenticeships.Web.Candidate.ViewModels.Register;
    using SFA.Apprenticeships.Web.Candidate.ViewModels.VacancySearch;
    using SFA.Apprenticeships.Web.Common.Constants;
    using SFA.Apprenticeships.Web.Common.Framework;
    using SFA.Apprenticeships.Web.Common.Models.Common;
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/ApprenticeshipSearch/_savedSearches.cshtml")]
    public partial class savedSearches : System.Web.Mvc.WebViewPage<ApprenticeshipSearchViewModel>
    {
        public savedSearches()
        {
        }
        public override void Execute()
        {
WriteLiteral("\r\n");

            
            #line 5 "..\..\Views\ApprenticeshipSearch\_savedSearches.cshtml"
  
    var divClass = Model.SearchMode == ApprenticeshipSearchMode.SavedSearches ? "active" : "";

            
            #line default
            #line hidden
WriteLiteral("\r\n\r\n<div");

WriteLiteral(" id=\"saved-searches\"");

WriteAttribute("class", Tuple.Create(" class=\"", 241), Tuple.Create("\"", 278)
, Tuple.Create(Tuple.Create("", 249), Tuple.Create("tabbed-element", 249), true)
, Tuple.Create(Tuple.Create(" ", 263), Tuple.Create("tab3", 264), true)
            
            #line 9 "..\..\Views\ApprenticeshipSearch\_savedSearches.cshtml"
, Tuple.Create(Tuple.Create(" ", 268), Tuple.Create<System.Object, System.Int32>(divClass
            
            #line default
            #line hidden
, 269), false)
);

WriteLiteral(">\r\n");

            
            #line 10 "..\..\Views\ApprenticeshipSearch\_savedSearches.cshtml"
    
            
            #line default
            #line hidden
            
            #line 10 "..\..\Views\ApprenticeshipSearch\_savedSearches.cshtml"
     if (Model.SavedSearches != null && Model.SavedSearches.Any())
    {


            
            #line default
            #line hidden
WriteLiteral("        <ul");

WriteLiteral(" id=\"saved-searches-list\"");

WriteLiteral(" class=\"list-text list-checkradio\"");

WriteLiteral(">\r\n");

            
            #line 14 "..\..\Views\ApprenticeshipSearch\_savedSearches.cshtml"
            
            
            #line default
            #line hidden
            
            #line 14 "..\..\Views\ApprenticeshipSearch\_savedSearches.cshtml"
             foreach (var savedSearch in Model.SavedSearches)
            {

            
            #line default
            #line hidden
WriteLiteral("                <li>\r\n                    <input");

WriteLiteral(" type=\"radio\"");

WriteLiteral(" name=\"SavedSearchId\"");

WriteAttribute("id", Tuple.Create(" id=\"", 592), Tuple.Create("\"", 625)
, Tuple.Create(Tuple.Create("", 597), Tuple.Create("saved-search-", 597), true)
            
            #line 17 "..\..\Views\ApprenticeshipSearch\_savedSearches.cshtml"
, Tuple.Create(Tuple.Create("", 610), Tuple.Create<System.Object, System.Int32>(savedSearch.Id
            
            #line default
            #line hidden
, 610), false)
);

WriteAttribute("value", Tuple.Create(" value=\"", 626), Tuple.Create("\"", 649)
            
            #line 17 "..\..\Views\ApprenticeshipSearch\_savedSearches.cshtml"
                       , Tuple.Create(Tuple.Create("", 634), Tuple.Create<System.Object, System.Int32>(savedSearch.Id
            
            #line default
            #line hidden
, 634), false)
);

WriteLiteral(">\r\n                    <div>\r\n                        <label");

WriteAttribute("id", Tuple.Create(" id=\"", 710), Tuple.Create("\"", 749)
, Tuple.Create(Tuple.Create("", 715), Tuple.Create("saved-search-label-", 715), true)
            
            #line 19 "..\..\Views\ApprenticeshipSearch\_savedSearches.cshtml"
, Tuple.Create(Tuple.Create("", 734), Tuple.Create<System.Object, System.Int32>(savedSearch.Id
            
            #line default
            #line hidden
, 734), false)
);

WriteAttribute("for", Tuple.Create(" for=\"", 750), Tuple.Create("\"", 784)
, Tuple.Create(Tuple.Create("", 756), Tuple.Create("saved-search-", 756), true)
            
            #line 19 "..\..\Views\ApprenticeshipSearch\_savedSearches.cshtml"
          , Tuple.Create(Tuple.Create("", 769), Tuple.Create<System.Object, System.Int32>(savedSearch.Id
            
            #line default
            #line hidden
, 769), false)
);

WriteLiteral(">");

            
            #line 19 "..\..\Views\ApprenticeshipSearch\_savedSearches.cshtml"
                                                                                                     Write(savedSearch.Name);

            
            #line default
            #line hidden
WriteLiteral("</label>\r\n");

            
            #line 20 "..\..\Views\ApprenticeshipSearch\_savedSearches.cshtml"
                        
            
            #line default
            #line hidden
            
            #line 20 "..\..\Views\ApprenticeshipSearch\_savedSearches.cshtml"
                         if (savedSearch.DateProcessed.HasValue)
                        {

            
            #line default
            #line hidden
WriteLiteral("                            <span");

WriteLiteral(" class=\"inl-block font-xsmall\"");

WriteLiteral(">(New matches: ");

            
            #line 22 "..\..\Views\ApprenticeshipSearch\_savedSearches.cshtml"
                                                                         Write(savedSearch.DateProcessed.Value.ToFriendlyDaysAgo());

            
            #line default
            #line hidden
WriteLiteral(")</span>\r\n");

            
            #line 23 "..\..\Views\ApprenticeshipSearch\_savedSearches.cshtml"
                        }

            
            #line default
            #line hidden
WriteLiteral("                    </div>\r\n                    \r\n");

            
            #line 26 "..\..\Views\ApprenticeshipSearch\_savedSearches.cshtml"
                    
            
            #line default
            #line hidden
            
            #line 26 "..\..\Views\ApprenticeshipSearch\_savedSearches.cshtml"
                     if (savedSearch.ApprenticeshipLevel != "All")
                    {

            
            #line default
            #line hidden
WriteLiteral("                        <p");

WriteLiteral(" class=\"font-xsmall no-btm-margin\"");

WriteLiteral(">\r\n                            <b>Apprenticeship level:</b> <span");

WriteAttribute("id", Tuple.Create(" id=\"", 1339), Tuple.Create("\"", 1393)
, Tuple.Create(Tuple.Create("", 1344), Tuple.Create("saved-search-apprenticeship-level-", 1344), true)
            
            #line 29 "..\..\Views\ApprenticeshipSearch\_savedSearches.cshtml"
                     , Tuple.Create(Tuple.Create("", 1378), Tuple.Create<System.Object, System.Int32>(savedSearch.Id
            
            #line default
            #line hidden
, 1378), false)
);

WriteLiteral(">");

            
            #line 29 "..\..\Views\ApprenticeshipSearch\_savedSearches.cshtml"
                                                                                                                 Write(savedSearch.ApprenticeshipLevel);

            
            #line default
            #line hidden
WriteLiteral("</span>\r\n                        </p>\r\n");

            
            #line 31 "..\..\Views\ApprenticeshipSearch\_savedSearches.cshtml"
                    }

            
            #line default
            #line hidden
WriteLiteral("                    \r\n");

            
            #line 33 "..\..\Views\ApprenticeshipSearch\_savedSearches.cshtml"
                    
            
            #line default
            #line hidden
            
            #line 33 "..\..\Views\ApprenticeshipSearch\_savedSearches.cshtml"
                     if (!string.IsNullOrWhiteSpace(savedSearch.SubCategoriesFullNames))
                    {

            
            #line default
            #line hidden
WriteLiteral("                        <p");

WriteLiteral(" class=\"font-xsmall no-btm-margin\"");

WriteLiteral(">\r\n                            <b>Sub-categories:</b> <span");

WriteAttribute("id", Tuple.Create(" id=\"", 1743), Tuple.Create("\"", 1790)
, Tuple.Create(Tuple.Create("", 1748), Tuple.Create("saved-search-subcategories-", 1748), true)
            
            #line 36 "..\..\Views\ApprenticeshipSearch\_savedSearches.cshtml"
        , Tuple.Create(Tuple.Create("", 1775), Tuple.Create<System.Object, System.Int32>(savedSearch.Id
            
            #line default
            #line hidden
, 1775), false)
);

WriteLiteral(">");

            
            #line 36 "..\..\Views\ApprenticeshipSearch\_savedSearches.cshtml"
                                                                                                    Write(savedSearch.SubCategoriesFullNames);

            
            #line default
            #line hidden
WriteLiteral("</span>\r\n                        </p>\r\n");

            
            #line 38 "..\..\Views\ApprenticeshipSearch\_savedSearches.cshtml"
                    }

            
            #line default
            #line hidden
WriteLiteral("                </li>\r\n");

            
            #line 40 "..\..\Views\ApprenticeshipSearch\_savedSearches.cshtml"
            }

            
            #line default
            #line hidden
WriteLiteral("        </ul>\r\n");

            
            #line 42 "..\..\Views\ApprenticeshipSearch\_savedSearches.cshtml"
    }
    else
    {

            
            #line default
            #line hidden
WriteLiteral("        <p");

WriteLiteral(" class=\"text\"");

WriteLiteral(" id=\"saved-searches-prompt\"");

WriteLiteral(">\r\n            You can run your saved searches from here. When you search using k" +
"eyword or category, you can save this search by clicking “Receive alerts for thi" +
"s search” on the results page.\r\n        </p>\r\n");

            
            #line 48 "..\..\Views\ApprenticeshipSearch\_savedSearches.cshtml"
    }

            
            #line default
            #line hidden
WriteLiteral("</div>");

        }
    }
}
#pragma warning restore 1591
