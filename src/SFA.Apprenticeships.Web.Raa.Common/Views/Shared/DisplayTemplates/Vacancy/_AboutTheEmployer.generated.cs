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

namespace SFA.Apprenticeships.Web.Raa.Common.Views.Shared.DisplayTemplates.Vacancy
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
    
    #line 1 "..\..\Views\Shared\DisplayTemplates\Vacancy\_AboutTheEmployer.cshtml"
    using SFA.Apprenticeships.Web.Raa.Common.Extensions;
    
    #line default
    #line hidden
    
    #line 2 "..\..\Views\Shared\DisplayTemplates\Vacancy\_AboutTheEmployer.cshtml"
    using SFA.Apprenticeships.Web.Raa.Common.ViewModels.Vacancy;
    
    #line default
    #line hidden
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/Shared/DisplayTemplates/Vacancy/_AboutTheEmployer.cshtml")]
    public partial class AboutTheEmployer : System.Web.Mvc.WebViewPage<VacancyViewModel>
    {
        public AboutTheEmployer()
        {
        }
        public override void Execute()
        {
            
            #line 5 "..\..\Views\Shared\DisplayTemplates\Vacancy\_AboutTheEmployer.cshtml"
  
    var editableItemClass = ViewData["editableItemClass"];

            
            #line default
            #line hidden
WriteLiteral("\r\n\r\n<section");

WriteLiteral(" class=\"section-border\"");

WriteLiteral(" id=\"employer-info\"");

WriteLiteral(">\r\n    <h2");

WriteLiteral(" class=\"heading-large\"");

WriteLiteral(">About the employer</h2>\r\n    <div");

WriteLiteral(" class=\"grid-wrapper\"");

WriteLiteral(">\r\n        <div");

WriteLiteral(" class=\"grid\"");

WriteLiteral(">\r\n            <h3");

WriteLiteral(" class=\"bold-small\"");

WriteLiteral(">Employer</h3>\r\n            <p");

WriteLiteral(" id=\"vacancy-employer-name\"");

WriteAttribute("class", Tuple.Create(" class=\"", 471), Tuple.Create("\"", 598)
            
            #line 14 "..\..\Views\Shared\DisplayTemplates\Vacancy\_AboutTheEmployer.cshtml"
, Tuple.Create(Tuple.Create("", 479), Tuple.Create<System.Object, System.Int32>(string.IsNullOrEmpty(Model.NewVacancyViewModel.ProviderSiteEmployerLink.WebsiteUrl) ? "no-btm-margin" : string.Empty
            
            #line default
            #line hidden
, 479), false)
);

WriteLiteral(">");

            
            #line 14 "..\..\Views\Shared\DisplayTemplates\Vacancy\_AboutTheEmployer.cshtml"
                                                                                                                                                                     Write(Model.NewVacancyViewModel.ProviderSiteEmployerLink.Employer.Name);

            
            #line default
            #line hidden
WriteLiteral("</p>\r\n        </div>\r\n        <div");

WriteLiteral(" class=\"grid grid-2-3\"");

WriteLiteral(">\r\n            <div");

WriteLiteral(" class=\"inner-block-padr\"");

WriteLiteral(">\r\n                <div");

WriteAttribute("class", Tuple.Create(" class=\"", 788), Tuple.Create("\"", 814)
            
            #line 18 "..\..\Views\Shared\DisplayTemplates\Vacancy\_AboutTheEmployer.cshtml"
, Tuple.Create(Tuple.Create("", 796), Tuple.Create<System.Object, System.Int32>(editableItemClass
            
            #line default
            #line hidden
, 796), false)
);

WriteLiteral(">\r\n                    <h3");

WriteLiteral(" class=\"bold-small\"");

WriteLiteral(">\r\n                        Description\r\n");

WriteLiteral("                        ");

            
            #line 21 "..\..\Views\Shared\DisplayTemplates\Vacancy\_AboutTheEmployer.cshtml"
                   Write(Html.Partial(CommentViewModel.PartialIconView, Html.GetCommentViewModel(Model, m => m.NewVacancyViewModel.ProviderSiteEmployerLink.Description, Model.NewVacancyViewModel.EmployerDescriptionComment, Model.EmployerLink)));

            
            #line default
            #line hidden
WriteLiteral("\r\n                    </h3>\r\n                    <p");

WriteLiteral(" id=\"vacancy-employer-description\"");

WriteLiteral(" class=\"preserve-formatting\"");

WriteLiteral(">");

            
            #line 23 "..\..\Views\Shared\DisplayTemplates\Vacancy\_AboutTheEmployer.cshtml"
                                                                                Write(Html.Raw(Model.NewVacancyViewModel.ProviderSiteEmployerLink.Description));

            
            #line default
            #line hidden
WriteLiteral("</p>\r\n");

WriteLiteral("                    ");

            
            #line 24 "..\..\Views\Shared\DisplayTemplates\Vacancy\_AboutTheEmployer.cshtml"
               Write(Html.Partial(EditLinkViewModel.PartialView, Html.GetEditLinkViewModel(Model, m => m.NewVacancyViewModel.ProviderSiteEmployerLink.Description, Model.EmployerLink, Model.NewVacancyViewModel.EmployerDescriptionComment)));

            
            #line default
            #line hidden
WriteLiteral("\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n\r\n    <" +
"div");

WriteLiteral(" class=\"grid-wrapper\"");

WriteLiteral(">\r\n");

            
            #line 31 "..\..\Views\Shared\DisplayTemplates\Vacancy\_AboutTheEmployer.cshtml"
        
            
            #line default
            #line hidden
            
            #line 31 "..\..\Views\Shared\DisplayTemplates\Vacancy\_AboutTheEmployer.cshtml"
          
            var gridClass = "grid";
            if (Model.IsSingleLocation)
            {
                gridClass += " grid-1-2";
            }
        
            
            #line default
            #line hidden
WriteLiteral("\r\n        <div");

WriteAttribute("class", Tuple.Create(" class=\"", 1867), Tuple.Create("\"", 1885)
            
            #line 38 "..\..\Views\Shared\DisplayTemplates\Vacancy\_AboutTheEmployer.cshtml"
, Tuple.Create(Tuple.Create("", 1875), Tuple.Create<System.Object, System.Int32>(gridClass
            
            #line default
            #line hidden
, 1875), false)
);

WriteLiteral(">\r\n            <div");

WriteLiteral(" class=\"inner-block-padr\"");

WriteLiteral(">\r\n");

            
            #line 40 "..\..\Views\Shared\DisplayTemplates\Vacancy\_AboutTheEmployer.cshtml"
                
            
            #line default
            #line hidden
            
            #line 40 "..\..\Views\Shared\DisplayTemplates\Vacancy\_AboutTheEmployer.cshtml"
                 if (!string.IsNullOrEmpty(Model.NewVacancyViewModel.ProviderSiteEmployerLink.WebsiteUrl))
                {

            
            #line default
            #line hidden
WriteLiteral("                    <div");

WriteLiteral(" class=\"editable-item\"");

WriteLiteral(">\r\n                        <h3");

WriteLiteral(" class=\"bold-small\"");

WriteLiteral(">\r\n                            Website\r\n");

WriteLiteral("                            ");

            
            #line 45 "..\..\Views\Shared\DisplayTemplates\Vacancy\_AboutTheEmployer.cshtml"
                       Write(Html.Partial(CommentViewModel.PartialIconView, Html.GetCommentViewModel(Model, m => m.NewVacancyViewModel.ProviderSiteEmployerLink.WebsiteUrl, Model.NewVacancyViewModel.EmployerWebsiteUrlComment, Model.EmployerLink)));

            
            #line default
            #line hidden
WriteLiteral("\r\n                        </h3>\r\n                        <a");

WriteLiteral(" itemprop=\"url\"");

WriteAttribute("href", Tuple.Create(" href=\"", 2514), Tuple.Create("\"", 2583)
            
            #line 47 "..\..\Views\Shared\DisplayTemplates\Vacancy\_AboutTheEmployer.cshtml"
, Tuple.Create(Tuple.Create("", 2521), Tuple.Create<System.Object, System.Int32>(Model.NewVacancyViewModel.ProviderSiteEmployerLink.WebsiteUrl
            
            #line default
            #line hidden
, 2521), false)
);

WriteLiteral("\r\n                           id=\"vacancy-employer-website\"");

WriteLiteral("\r\n                           target=\"_blank\"");

WriteAttribute("title", Tuple.Create("\r\n                           title=\"", 2686), Tuple.Create("\"", 2795)
            
            #line 50 "..\..\Views\Shared\DisplayTemplates\Vacancy\_AboutTheEmployer.cshtml"
, Tuple.Create(Tuple.Create("", 2722), Tuple.Create<System.Object, System.Int32>(Model.NewVacancyViewModel.ProviderSiteEmployerLink.Employer.Name
            
            #line default
            #line hidden
, 2722), false)
, Tuple.Create(Tuple.Create(" ", 2787), Tuple.Create("Website", 2788), true)
);

WriteLiteral(" rel=\"external\"");

WriteLiteral(">");

            
            #line 50 "..\..\Views\Shared\DisplayTemplates\Vacancy\_AboutTheEmployer.cshtml"
                                                                                                                       Write(Model.NewVacancyViewModel.ProviderSiteEmployerLink.WebsiteUrl);

            
            #line default
            #line hidden
WriteLiteral("</a>\r\n");

WriteLiteral("                        ");

            
            #line 51 "..\..\Views\Shared\DisplayTemplates\Vacancy\_AboutTheEmployer.cshtml"
                   Write(Html.Partial(EditLinkViewModel.PartialView, Html.GetEditLinkViewModel(Model, m => m.NewVacancyViewModel.ProviderSiteEmployerLink.WebsiteUrl, Model.EmployerLink, Model.NewVacancyViewModel.EmployerWebsiteUrlComment)));

            
            #line default
            #line hidden
WriteLiteral("\r\n                    </div>\r\n");

            
            #line 53 "..\..\Views\Shared\DisplayTemplates\Vacancy\_AboutTheEmployer.cshtml"
                }

            
            #line default
            #line hidden
WriteLiteral("\r\n                <div>\r\n                    <div");

WriteLiteral(" class=\"inner-block-padr\"");

WriteLiteral(">\r\n");

            
            #line 57 "..\..\Views\Shared\DisplayTemplates\Vacancy\_AboutTheEmployer.cshtml"
                        
            
            #line default
            #line hidden
            
            #line 57 "..\..\Views\Shared\DisplayTemplates\Vacancy\_AboutTheEmployer.cshtml"
                         if (Model.NewVacancyViewModel.IsEmployerLocationMainApprenticeshipLocation == true)
                        {

            
            #line default
            #line hidden
WriteLiteral("                            <div");

WriteLiteral(" id=\"vacancy-address\"");

WriteLiteral(" itemscope");

WriteLiteral(" itemtype=\"http://schema.org/PostalAddress\"");

WriteLiteral(">\r\n                                <h3");

WriteLiteral(" class=\"bold-small\"");

WriteLiteral(">Address</h3>\r\n                                <div");

WriteLiteral(" itemprop=\"address\"");

WriteLiteral(">\r\n                                    <p");

WriteLiteral(" class=\"small-btm-margin\"");

WriteLiteral(" itemprop=\"streetAddress\"");

WriteLiteral(">");

            
            #line 62 "..\..\Views\Shared\DisplayTemplates\Vacancy\_AboutTheEmployer.cshtml"
                                                                                    Write(Model.NewVacancyViewModel.ProviderSiteEmployerLink.Employer.Address.AddressLine1);

            
            #line default
            #line hidden
WriteLiteral("</p>\r\n                                    <p");

WriteLiteral(" class=\"small-btm-margin\"");

WriteLiteral(" itemprop=\"streetAddress\"");

WriteLiteral(">");

            
            #line 63 "..\..\Views\Shared\DisplayTemplates\Vacancy\_AboutTheEmployer.cshtml"
                                                                                    Write(Model.NewVacancyViewModel.ProviderSiteEmployerLink.Employer.Address.AddressLine2);

            
            #line default
            #line hidden
WriteLiteral("</p>\r\n                                    <p");

WriteLiteral(" class=\"small-btm-margin\"");

WriteLiteral(" itemprop=\"addressLocality\"");

WriteLiteral(">");

            
            #line 64 "..\..\Views\Shared\DisplayTemplates\Vacancy\_AboutTheEmployer.cshtml"
                                                                                      Write(Model.NewVacancyViewModel.ProviderSiteEmployerLink.Employer.Address.AddressLine3);

            
            #line default
            #line hidden
WriteLiteral("</p>\r\n                                    <p");

WriteLiteral(" class=\"small-btm-margin\"");

WriteLiteral(" itemprop=\"addressRegion\"");

WriteLiteral(">");

            
            #line 65 "..\..\Views\Shared\DisplayTemplates\Vacancy\_AboutTheEmployer.cshtml"
                                                                                    Write(Model.NewVacancyViewModel.ProviderSiteEmployerLink.Employer.Address.AddressLine4);

            
            #line default
            #line hidden
WriteLiteral("</p>\r\n                                    <p");

WriteLiteral(" class=\"small-btm-margin\"");

WriteLiteral(" itemprop=\"postalCode\"");

WriteLiteral(">");

            
            #line 66 "..\..\Views\Shared\DisplayTemplates\Vacancy\_AboutTheEmployer.cshtml"
                                                                                 Write(Model.NewVacancyViewModel.ProviderSiteEmployerLink.Employer.Address.Postcode);

            
            #line default
            #line hidden
WriteLiteral("</p>\r\n                                </div>\r\n                            </div>\r" +
"\n");

            
            #line 69 "..\..\Views\Shared\DisplayTemplates\Vacancy\_AboutTheEmployer.cshtml"
                        }
                        else
                        {
                            if (Model.NewVacancyViewModel.LocationAddresses != null && Model.NewVacancyViewModel.LocationAddresses.Count() == 1)
                            {

            
            #line default
            #line hidden
WriteLiteral("                                <div");

WriteLiteral(" id=\"vacancy-address\"");

WriteLiteral(" class=\"editable-item\"");

WriteLiteral(" itemscope");

WriteLiteral(" itemtype=\"http://schema.org/PostalAddress\"");

WriteLiteral(">\r\n                                    <h3");

WriteLiteral(" class=\"bold-small\"");

WriteLiteral(">\r\n                                        Address\r\n");

WriteLiteral("                                        ");

            
            #line 77 "..\..\Views\Shared\DisplayTemplates\Vacancy\_AboutTheEmployer.cshtml"
                                   Write(Html.Partial(CommentViewModel.PartialIconView, Html.GetCommentViewModel(Model, m => m.NewVacancyViewModel.LocationAddresses, Model.NewVacancyViewModel.LocationAddressesComment, Model.LocationsLink)));

            
            #line default
            #line hidden
WriteLiteral("\r\n                                    </h3>\r\n                                    " +
"<div");

WriteLiteral(" itemprop=\"address\"");

WriteLiteral(">\r\n                                        <p");

WriteLiteral(" class=\"small-btm-margin\"");

WriteLiteral(" itemprop=\"streetAddress\"");

WriteLiteral(">");

            
            #line 80 "..\..\Views\Shared\DisplayTemplates\Vacancy\_AboutTheEmployer.cshtml"
                                                                                        Write(Model.NewVacancyViewModel.LocationAddresses.First().Address.AddressLine1);

            
            #line default
            #line hidden
WriteLiteral("</p>\r\n                                        <p");

WriteLiteral(" class=\"small-btm-margin\"");

WriteLiteral(" itemprop=\"streetAddress\"");

WriteLiteral(">");

            
            #line 81 "..\..\Views\Shared\DisplayTemplates\Vacancy\_AboutTheEmployer.cshtml"
                                                                                        Write(Model.NewVacancyViewModel.LocationAddresses.First().Address.AddressLine2);

            
            #line default
            #line hidden
WriteLiteral("</p>\r\n                                        <p");

WriteLiteral(" class=\"small-btm-margin\"");

WriteLiteral(" itemprop=\"addressLocality\"");

WriteLiteral(">");

            
            #line 82 "..\..\Views\Shared\DisplayTemplates\Vacancy\_AboutTheEmployer.cshtml"
                                                                                          Write(Model.NewVacancyViewModel.LocationAddresses.First().Address.AddressLine3);

            
            #line default
            #line hidden
WriteLiteral("</p>\r\n                                        <p");

WriteLiteral(" class=\"small-btm-margin\"");

WriteLiteral(" itemprop=\"addressRegion\"");

WriteLiteral(">");

            
            #line 83 "..\..\Views\Shared\DisplayTemplates\Vacancy\_AboutTheEmployer.cshtml"
                                                                                        Write(Model.NewVacancyViewModel.LocationAddresses.First().Address.AddressLine4);

            
            #line default
            #line hidden
WriteLiteral("</p>\r\n                                        <p");

WriteLiteral(" class=\"small-btm-margin\"");

WriteLiteral(" itemprop=\"postalCode\"");

WriteLiteral(">");

            
            #line 84 "..\..\Views\Shared\DisplayTemplates\Vacancy\_AboutTheEmployer.cshtml"
                                                                                     Write(Model.NewVacancyViewModel.LocationAddresses.First().Address.Postcode);

            
            #line default
            #line hidden
WriteLiteral("</p>\r\n                                    </div>\r\n\r\n");

WriteLiteral("                                    ");

            
            #line 87 "..\..\Views\Shared\DisplayTemplates\Vacancy\_AboutTheEmployer.cshtml"
                               Write(Html.Partial(EditLinkViewModel.PartialView, Html.GetEditLinkViewModel(Model, m => m.NewVacancyViewModel.LocationAddresses, Model.LocationsLink, Model.NewVacancyViewModel.EmployerWebsiteUrlComment)));

            
            #line default
            #line hidden
WriteLiteral("\r\n                                </div>\r\n");

            
            #line 89 "..\..\Views\Shared\DisplayTemplates\Vacancy\_AboutTheEmployer.cshtml"
                            }
                            else
                            {
                                var midIndex = (Model.NewVacancyViewModel.LocationAddresses.Count + 1) / 2;

            
            #line default
            #line hidden
WriteLiteral("                                <p></p>\r\n");

WriteLiteral("                                <div");

WriteLiteral(" id=\"vacancy-address\"");

WriteLiteral(" class=\"editable-item grid-wrapper\"");

WriteLiteral(" itemscope");

WriteLiteral(" itemtype=\"http://schema.org/PostalAddress\"");

WriteLiteral(">\r\n                                    <h3");

WriteLiteral(" class=\"bold-small\"");

WriteLiteral(">\r\n                                        Addresses\r\n");

WriteLiteral("                                        ");

            
            #line 97 "..\..\Views\Shared\DisplayTemplates\Vacancy\_AboutTheEmployer.cshtml"
                                   Write(Html.Partial(CommentViewModel.PartialIconView, Html.GetCommentViewModel(Model, m => m.NewVacancyViewModel.LocationAddresses, Model.NewVacancyViewModel.LocationAddressesComment, Model.LocationsLink)));

            
            #line default
            #line hidden
WriteLiteral("\r\n                                    </h3>\r\n                                    " +
"<div");

WriteLiteral(" class=\"grid grid-1-2\"");

WriteLiteral(">\r\n                                        <div");

WriteLiteral(" class=\"inner-block-padr\"");

WriteLiteral(">\r\n                                            <table");

WriteLiteral(" class=\"locations-table\"");

WriteLiteral(" id=\"leftLocationAddressesTable\"");

WriteLiteral(">\r\n                                                <colgroup>\r\n                  " +
"                                  <col");

WriteLiteral(" class=\"t50\"");

WriteLiteral(">\r\n                                                    <col");

WriteLiteral(" class=\"t35\"");

WriteLiteral(@">
                                                </colgroup>

                                                <thead>
                                                    <tr>
                                                        <th>
                                                            <span");

WriteLiteral(" class=\"heading-span\"");

WriteLiteral(">Location</span>\r\n                                                        </th>\r\n" +
"                                                        <th>\r\n                  " +
"                                          <span");

WriteLiteral(" class=\"heading-span\"");

WriteLiteral(@">Number of positions</span>
                                                        </th>
                                                    </tr>
                                                </thead>
                                                <tbody");

WriteLiteral(" id=\"location-addresses\"");

WriteLiteral(" data-bind=\"foreach: locationAddresses\"");

WriteLiteral(">\r\n");

            
            #line 118 "..\..\Views\Shared\DisplayTemplates\Vacancy\_AboutTheEmployer.cshtml"
                                                    
            
            #line default
            #line hidden
            
            #line 118 "..\..\Views\Shared\DisplayTemplates\Vacancy\_AboutTheEmployer.cshtml"
                                                     for (var i = 0; i < midIndex; i++)
                                                    {
                                                        var locationAddress = Model.NewVacancyViewModel.LocationAddresses[i];
                                                        
            
            #line default
            #line hidden
            
            #line 121 "..\..\Views\Shared\DisplayTemplates\Vacancy\_AboutTheEmployer.cshtml"
                                                   Write(Html.DisplayFor(m => locationAddress));

            
            #line default
            #line hidden
            
            #line 121 "..\..\Views\Shared\DisplayTemplates\Vacancy\_AboutTheEmployer.cshtml"
                                                                                              
                                                    }

            
            #line default
            #line hidden
WriteLiteral("\r\n                                                </tbody>\r\n                     " +
"                       </table>\r\n                                        </div>\r" +
"\n                                    </div>\r\n\r\n                                 " +
"   <div");

WriteLiteral(" class=\"grid grid-1-2\"");

WriteLiteral(">\r\n                                        <table");

WriteLiteral(" class=\"locations-table\"");

WriteLiteral(" id=\"rightLocationAddressesTable\"");

WriteLiteral(">\r\n                                            <colgroup>\r\n                      " +
"                          <col");

WriteLiteral(" class=\"t50\"");

WriteLiteral(">\r\n                                                <col");

WriteLiteral(" class=\"t35\"");

WriteLiteral(@">
                                            </colgroup>

                                            <thead>
                                                <tr>
                                                    <th>
                                                        <span");

WriteLiteral(" class=\"heading-span\"");

WriteLiteral(">Location</span>\r\n                                                    </th>\r\n    " +
"                                                <th>\r\n                          " +
"                              <span");

WriteLiteral(" class=\"heading-span\"");

WriteLiteral(">Number of positions</span>\r\n                                                    " +
"</th>\r\n                                                </tr>\r\n                  " +
"                          </thead>\r\n                                            " +
"<tbody");

WriteLiteral(" id=\"location-addresses\"");

WriteLiteral(" data-bind=\"foreach: locationAddresses\"");

WriteLiteral(">\r\n");

            
            #line 147 "..\..\Views\Shared\DisplayTemplates\Vacancy\_AboutTheEmployer.cshtml"
                                                
            
            #line default
            #line hidden
            
            #line 147 "..\..\Views\Shared\DisplayTemplates\Vacancy\_AboutTheEmployer.cshtml"
                                                 for (var i = midIndex; i < Model.NewVacancyViewModel.LocationAddresses.Count; i++)
                                                {
                                                    var locationAddress = Model.NewVacancyViewModel.LocationAddresses[i];
                                                    
            
            #line default
            #line hidden
            
            #line 150 "..\..\Views\Shared\DisplayTemplates\Vacancy\_AboutTheEmployer.cshtml"
                                               Write(Html.DisplayFor(m => locationAddress));

            
            #line default
            #line hidden
            
            #line 150 "..\..\Views\Shared\DisplayTemplates\Vacancy\_AboutTheEmployer.cshtml"
                                                                                          
                                                }

            
            #line default
            #line hidden
WriteLiteral("\r\n                                            </tbody>\r\n                         " +
"               </table>\r\n                                    </div>\r\n\r\n");

WriteLiteral("                                    ");

            
            #line 157 "..\..\Views\Shared\DisplayTemplates\Vacancy\_AboutTheEmployer.cshtml"
                               Write(Html.Partial(EditLinkViewModel.PartialView, Html.GetEditLinkViewModel(Model, m => m.NewVacancyViewModel.LocationAddresses, Model.LocationsLink, Model.NewVacancyViewModel.EmployerWebsiteUrlComment)));

            
            #line default
            #line hidden
WriteLiteral("\r\n                                </div>\r\n");

            
            #line 159 "..\..\Views\Shared\DisplayTemplates\Vacancy\_AboutTheEmployer.cshtml"
                            }
                            if (!string.IsNullOrWhiteSpace(Model.NewVacancyViewModel.AdditionalLocationInformation))
                            {

            
            #line default
            #line hidden
WriteLiteral("                                <div");

WriteLiteral(" class=\"editable-item\"");

WriteLiteral(">\r\n                                    <h3");

WriteLiteral(" class=\"bold-small\"");

WriteLiteral(">\r\n                                        Additional location information\r\n");

WriteLiteral("                                        ");

            
            #line 165 "..\..\Views\Shared\DisplayTemplates\Vacancy\_AboutTheEmployer.cshtml"
                                   Write(Html.Partial(CommentViewModel.PartialIconView, Html.GetCommentViewModel(Model, m => m.NewVacancyViewModel.AdditionalLocationInformation, Model.NewVacancyViewModel.AdditionalLocationInformationComment, Model.LocationsLink)));

            
            #line default
            #line hidden
WriteLiteral("\r\n                                    </h3>\r\n                                    " +
"<p");

WriteLiteral(" class=\"preserve-formatting\"");

WriteLiteral(">");

            
            #line 167 "..\..\Views\Shared\DisplayTemplates\Vacancy\_AboutTheEmployer.cshtml"
                                                              Write(Html.Raw(Model.NewVacancyViewModel.AdditionalLocationInformation));

            
            #line default
            #line hidden
WriteLiteral("</p>\r\n");

WriteLiteral("                                    ");

            
            #line 168 "..\..\Views\Shared\DisplayTemplates\Vacancy\_AboutTheEmployer.cshtml"
                               Write(Html.Partial(EditLinkViewModel.PartialView, Html.GetEditLinkViewModel(Model, m => m.NewVacancyViewModel.AdditionalLocationInformation, Model.LocationsLink, Model.NewVacancyViewModel.EmployerWebsiteUrlComment)));

            
            #line default
            #line hidden
WriteLiteral("\r\n                                </div>\r\n");

            
            #line 170 "..\..\Views\Shared\DisplayTemplates\Vacancy\_AboutTheEmployer.cshtml"
                            }
                        }

            
            #line default
            #line hidden
WriteLiteral("                    </div>\r\n                </div>\r\n            </div>\r\n        <" +
"/div>\r\n        <div");

WriteLiteral(" class=\"grid grid-1-2 hide-print\"");

WriteLiteral(">\r\n");

            
            #line 177 "..\..\Views\Shared\DisplayTemplates\Vacancy\_AboutTheEmployer.cshtml"
            
            
            #line default
            #line hidden
            
            #line 177 "..\..\Views\Shared\DisplayTemplates\Vacancy\_AboutTheEmployer.cshtml"
             if (Model.NewVacancyViewModel.IsEmployerLocationMainApprenticeshipLocation == true)
            {

            
            #line default
            #line hidden
WriteLiteral("                <div");

WriteLiteral(" id=\"vacancy-map\"");

WriteLiteral(" class=\"ad-details__map\"");

WriteLiteral(">\r\n                    <div");

WriteLiteral(" class=\"map-overlay\"");

WriteLiteral(" onclick=\" style.pointerEvents=\'none\' \"");

WriteLiteral("></div>\r\n                    <iframe");

WriteLiteral(" width=\"700\"");

WriteLiteral(" height=\"250\"");

WriteLiteral(" title=\"Map of location\"");

WriteLiteral(" style=\"border: 0\"");

WriteAttribute("src", Tuple.Create(" src=\"", 13092), Tuple.Create("\"", 13294)
, Tuple.Create(Tuple.Create("", 13098), Tuple.Create("https://www.google.com/maps/embed/v1/place?q=", 13098), true)
            
            #line 181 "..\..\Views\Shared\DisplayTemplates\Vacancy\_AboutTheEmployer.cshtml"
                                                                , Tuple.Create(Tuple.Create("", 13143), Tuple.Create<System.Object, System.Int32>(Html.Raw(Model.NewVacancyViewModel.ProviderSiteEmployerLink.Employer.Address.Postcode)
            
            #line default
            #line hidden
, 13143), false)
, Tuple.Create(Tuple.Create("", 13230), Tuple.Create(",+United+Kingdom&amp;key=AIzaSyCusA_0x4bJEjU-_gLOFiXMSBXKZYtvHz8", 13230), true)
);

WriteLiteral("></iframe>\r\n                    <p");

WriteLiteral(" class=\"nojs-notice\"");

WriteLiteral(">You must have JavaScript enabled to view a map of the location</p>\r\n            " +
"    </div>\r\n");

            
            #line 184 "..\..\Views\Shared\DisplayTemplates\Vacancy\_AboutTheEmployer.cshtml"
            }
            else if (Model.NewVacancyViewModel.LocationAddresses != null && Model.NewVacancyViewModel.LocationAddresses.Count == 1)
            {

            
            #line default
            #line hidden
WriteLiteral("                <div");

WriteLiteral(" id=\"vacancy-map\"");

WriteLiteral(" class=\"ad-details__map\"");

WriteLiteral(">\r\n                    <div");

WriteLiteral(" class=\"map-overlay\"");

WriteLiteral(" onclick=\" style.pointerEvents=\'none\' \"");

WriteLiteral("></div>\r\n                    <iframe");

WriteLiteral(" width=\"700\"");

WriteLiteral(" height=\"250\"");

WriteLiteral(" title=\"Map of location\"");

WriteLiteral(" style=\"border: 0\"");

WriteAttribute("src", Tuple.Create(" src=\"", 13855), Tuple.Create("\"", 14049)
, Tuple.Create(Tuple.Create("", 13861), Tuple.Create("https://www.google.com/maps/embed/v1/place?q=", 13861), true)
            
            #line 189 "..\..\Views\Shared\DisplayTemplates\Vacancy\_AboutTheEmployer.cshtml"
                                                                , Tuple.Create(Tuple.Create("", 13906), Tuple.Create<System.Object, System.Int32>(Html.Raw(Model.NewVacancyViewModel.LocationAddresses.First().Address.Postcode)
            
            #line default
            #line hidden
, 13906), false)
, Tuple.Create(Tuple.Create("", 13985), Tuple.Create(",+United+Kingdom&amp;key=AIzaSyCusA_0x4bJEjU-_gLOFiXMSBXKZYtvHz8", 13985), true)
);

WriteLiteral("></iframe>\r\n                    <p");

WriteLiteral(" class=\"nojs-notice\"");

WriteLiteral(">You must have JavaScript enabled to view a map of the location</p>\r\n            " +
"    </div>\r\n");

            
            #line 192 "..\..\Views\Shared\DisplayTemplates\Vacancy\_AboutTheEmployer.cshtml"
            }

            
            #line default
            #line hidden
WriteLiteral("        </div>\r\n    </div>\r\n</section>");

        }
    }
}
#pragma warning restore 1591