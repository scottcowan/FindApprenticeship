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

namespace SFA.Apprenticeships.Web.Recruit.Views.VacancyPosting
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
    
    #line 2 "..\..\Views\VacancyPosting\PreviewVacancy.cshtml"
    using SFA.Apprenticeships.Web.Common.Validators.Extensions;
    
    #line default
    #line hidden
    using SFA.Apprenticeships.Web.Recruit;
    
    #line 3 "..\..\Views\VacancyPosting\PreviewVacancy.cshtml"
    using SFA.Apprenticeships.Web.Recruit.Constants;
    
    #line default
    #line hidden
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/VacancyPosting/PreviewVacancy.cshtml")]
    public partial class PreviewVacancy : System.Web.Mvc.WebViewPage<SFA.Apprenticeships.Web.Recruit.ViewModels.Vacancy.VacancyViewModel>
    {
        public PreviewVacancy()
        {
        }
        public override void Execute()
        {
            
            #line 4 "..\..\Views\VacancyPosting\PreviewVacancy.cshtml"
  
    ViewBag.Title = "Recruit an Apprentice - Preview vacancy";

            
            #line default
            #line hidden
WriteLiteral("\r\n\r\n<div>\r\n    <div");

WriteLiteral(" class=\"grid-wrapper\"");

WriteLiteral(">\r\n        <div");

WriteLiteral(" class=\"grid grid-2-3\"");

WriteLiteral(">\r\n            <div");

WriteLiteral(" class=\"hgroup text\"");

WriteLiteral(">\r\n                <h1");

WriteLiteral(" class=\"heading-xlarge\"");

WriteLiteral(" id=\"vacancy-title\"");

WriteLiteral(" itemprop=\"title\"");

WriteLiteral(">");

            
            #line 12 "..\..\Views\VacancyPosting\PreviewVacancy.cshtml"
                                                                          Write(Model.NewVacancyViewModel.Title);

            
            #line default
            #line hidden
WriteLiteral(" (Preview)</h1>\r\n                <p");

WriteLiteral(" class=\"subtitle\"");

WriteLiteral(" id=\"vacancy-subtitle-employer-name\"");

WriteLiteral(" itemprop=\"hiringOrganization\"");

WriteLiteral(">");

            
            #line 13 "..\..\Views\VacancyPosting\PreviewVacancy.cshtml"
                                                                                                 Write(Model.NewVacancyViewModel.ProviderSiteEmployerLink.Employer.Name);

            
            #line default
            #line hidden
WriteLiteral("</p>\r\n            </div>\r\n        </div>\r\n        <div");

WriteLiteral(" class=\"grid grid-1-3\"");

WriteLiteral(">\r\n            <p");

WriteLiteral(" class=\"page-link hide-nojs\"");

WriteLiteral(">\r\n                <a");

WriteLiteral(" class=\"print-trigger\"");

WriteLiteral(" href=\"\"");

WriteLiteral("><i");

WriteLiteral(" class=\"fa fa-print\"");

WriteLiteral("></i>Print this page</a>\r\n            </p>\r\n        </div>\r\n    </div>\r\n\r\n       " +
" <section");

WriteLiteral(" class=\"grid-wrapper\"");

WriteLiteral(">\r\n            <div");

WriteLiteral(" class=\"grid grid-2-3\"");

WriteLiteral(">\r\n                <div");

WriteLiteral(" class=\"inner-block-padr\"");

WriteLiteral(">\r\n                    <div");

WriteLiteral(" class=\"text\"");

WriteLiteral(" itemprop=\"description\"");

WriteLiteral(">\r\n                        <p");

WriteLiteral(" id=\"vacancy-description\"");

WriteLiteral(">");

            
            #line 27 "..\..\Views\VacancyPosting\PreviewVacancy.cshtml"
                                               Write(Model.NewVacancyViewModel.ShortDescription);

            
            #line default
            #line hidden
WriteLiteral("</p>\r\n                    </div>\r\n                </div>\r\n            </div>\r\n   " +
"         <div");

WriteLiteral(" class=\"grid grid-1-3\"");

WriteLiteral(">\r\n                <p");

WriteLiteral(" id=\"vacancy-closing-date\"");

WriteLiteral(" class=\"copy-16\"");

WriteLiteral(">Closing date: ");

            
            #line 32 "..\..\Views\VacancyPosting\PreviewVacancy.cshtml"
                                                                      Write(Model.VacancySummaryViewModel.ClosingDate.Date.ToFriendlyClosingToday());

            
            #line default
            #line hidden
WriteLiteral("</p>\r\n            </div>\r\n        </section>\r\n        <section");

WriteLiteral(" class=\"section-border grid-wrapper\"");

WriteLiteral(" id=\"vacancy-info\"");

WriteLiteral(">\r\n            <h2");

WriteLiteral(" class=\"heading-large\"");

WriteLiteral(">Apprenticeship summary</h2>\r\n            <div");

WriteLiteral(" class=\"grid grid-1-3\"");

WriteLiteral(">\r\n                <div");

WriteLiteral(" class=\"inner-block-padr\"");

WriteLiteral(">\r\n\r\n                    <h3");

WriteLiteral(" class=\"bold-small\"");

WriteLiteral(">\r\n");

WriteLiteral("                        ");

            
            #line 41 "..\..\Views\VacancyPosting\PreviewVacancy.cshtml"
                   Write(Model.VacancySummaryViewModel.WageUnitDisplayText);

            
            #line default
            #line hidden
WriteLiteral(" wage <i");

WriteLiteral(" class=\"fa fa-check the-icon\"");

WriteLiteral(" style=\"color: green;\"");

WriteLiteral("></i>\r\n                    </h3>\r\n                    \r\n                    <p");

WriteLiteral(" id=\"vacancy-wage\"");

WriteLiteral(">");

            
            #line 44 "..\..\Views\VacancyPosting\PreviewVacancy.cshtml"
                                    Write(Model.VacancySummaryViewModel.Wage);

            
            #line default
            #line hidden
WriteLiteral("</p>\r\n\r\n                    <h3");

WriteLiteral(" class=\"bold-small\"");

WriteLiteral(">Working week <i");

WriteLiteral(" class=\"fa fa-check the-icon\"");

WriteLiteral(" style=\"color: green;\"");

WriteLiteral("></i></h3>\r\n                    <p");

WriteLiteral(" id=\"vacancy-working-week\"");

WriteLiteral(" itemprop=\"workHours\"");

WriteLiteral(">");

            
            #line 47 "..\..\Views\VacancyPosting\PreviewVacancy.cshtml"
                                                                 Write(Model.VacancySummaryViewModel.WorkingWeek);

            
            #line default
            #line hidden
WriteLiteral("<br/>Total hours per week: ");

            
            #line 47 "..\..\Views\VacancyPosting\PreviewVacancy.cshtml"
                                                                                                                                      Write(Model.VacancySummaryViewModel.HoursPerWeek);

            
            #line default
            #line hidden
WriteLiteral("</p>\r\n                    <h3");

WriteLiteral(" class=\"bold-small\"");

WriteLiteral(">\r\n                        Apprenticeship duration\r\n");

            
            #line 50 "..\..\Views\VacancyPosting\PreviewVacancy.cshtml"
                        
            
            #line default
            #line hidden
            
            #line 50 "..\..\Views\VacancyPosting\PreviewVacancy.cshtml"
                         if (ViewData.ModelState.HasWarningsFor("Duration"))
                        {
                            var message = ViewData.ModelState.WarningMessageFor("Duration");

            
            #line default
            #line hidden
WriteLiteral("                            <i");

WriteLiteral(" class=\"fa fa-flag the-icon\"");

WriteLiteral(" style=\"color: red;\"");

WriteAttribute("title", Tuple.Create(" title=\"", 2767), Tuple.Create("\"", 2783)
            
            #line 53 "..\..\Views\VacancyPosting\PreviewVacancy.cshtml"
      , Tuple.Create(Tuple.Create("", 2775), Tuple.Create<System.Object, System.Int32>(message
            
            #line default
            #line hidden
, 2775), false)
);

WriteLiteral("></i>\r\n");

            
            #line 54 "..\..\Views\VacancyPosting\PreviewVacancy.cshtml"
                        }
                        else
                        {

            
            #line default
            #line hidden
WriteLiteral("                            <i");

WriteLiteral(" class=\"fa fa-check the-icon\"");

WriteLiteral(" style=\"color: green;\"");

WriteLiteral("></i>\r\n");

            
            #line 58 "..\..\Views\VacancyPosting\PreviewVacancy.cshtml"
                        }

            
            #line default
            #line hidden
WriteLiteral("                    </h3>\r\n                    \r\n                    <p");

WriteLiteral(" id=\"vacancy-expected-duration\"");

WriteLiteral(">");

            
            #line 61 "..\..\Views\VacancyPosting\PreviewVacancy.cshtml"
                                                 Write(Model.VacancySummaryViewModel.Duration);

            
            #line default
            #line hidden
WriteLiteral(" ");

            
            #line 61 "..\..\Views\VacancyPosting\PreviewVacancy.cshtml"
                                                                                         Write(Model.VacancySummaryViewModel.DurationTypeDisplayText);

            
            #line default
            #line hidden
WriteLiteral("</p>\r\n                    <h3");

WriteLiteral(" class=\"bold-small\"");

WriteLiteral(">Possible start date</h3>\r\n                    <p");

WriteLiteral(" id=\"vacancy-start-date\"");

WriteLiteral(">");

            
            #line 63 "..\..\Views\VacancyPosting\PreviewVacancy.cshtml"
                                          Write(Html.DisplayFor(m => Model.VacancySummaryViewModel.PossibleStartDate.Date));

            
            #line default
            #line hidden
WriteLiteral("</p>\r\n                    <h3");

WriteLiteral(" class=\"bold-small\"");

WriteLiteral(">Apprenticeship level</h3>\r\n                    <p");

WriteLiteral(" id=\"vacancy-type\"");

WriteLiteral(" itemprop=\"employmentType\"");

WriteLiteral(">");

            
            #line 65 "..\..\Views\VacancyPosting\PreviewVacancy.cshtml"
                                                              Write(Model.NewVacancyViewModel.ApprenticeshipLevel);

            
            #line default
            #line hidden
WriteLiteral(" Level Apprenticeship</p>\r\n\r\n                    <h3");

WriteLiteral(" class=\"bold-small\"");

WriteLiteral(">Reference number</h3>\r\n                    <p");

WriteLiteral(" id=\"vacancy-reference-id\"");

WriteLiteral(">");

            
            #line 68 "..\..\Views\VacancyPosting\PreviewVacancy.cshtml"
                                            Write(Model.VacancyReferenceNumber);

            
            #line default
            #line hidden
WriteLiteral("</p>\r\n                </div>\r\n            </div>\r\n            <div");

WriteLiteral(" class=\"grid grid-2-3\"");

WriteLiteral(">\r\n                <div");

WriteLiteral(" class=\"text\"");

WriteLiteral(" itemprop=\"responsibilities\"");

WriteLiteral(">\r\n                    <p");

WriteLiteral(" id=\"vacancy-full-descrpition\"");

WriteLiteral(">");

            
            #line 73 "..\..\Views\VacancyPosting\PreviewVacancy.cshtml"
                                                Write(Html.Raw(Model.VacancySummaryViewModel.LongDescription));

            
            #line default
            #line hidden
WriteLiteral("</p>\r\n                </div>\r\n            </div>\r\n\r\n        </section>\r\n        <" +
"section");

WriteLiteral(" class=\"section-border grid-wrapper\"");

WriteLiteral(" id=\"course-info\"");

WriteLiteral(">\r\n            <h2");

WriteLiteral(" class=\"heading-large\"");

WriteLiteral(">Requirements and prospects</h2>\r\n            <div");

WriteLiteral(" class=\"grid grid-1-2\"");

WriteLiteral(">\r\n                <div");

WriteLiteral(" class=\"inner-block-padr\"");

WriteLiteral(">\r\n                    <div");

WriteLiteral(" class=\"text\"");

WriteLiteral(">\r\n");

            
            #line 83 "..\..\Views\VacancyPosting\PreviewVacancy.cshtml"
                        
            
            #line default
            #line hidden
            
            #line 83 "..\..\Views\VacancyPosting\PreviewVacancy.cshtml"
                         if (!string.IsNullOrWhiteSpace(Model.VacancyRequirementsProspectsViewModel.DesiredSkills))
                        {

            
            #line default
            #line hidden
WriteLiteral("                            <h3");

WriteLiteral(" class=\"heading-small\"");

WriteLiteral(">Desired skills</h3>\r\n");

WriteLiteral("                            <p");

WriteLiteral(" id=\"vacancy-skills-required\"");

WriteLiteral(" itemprop=\"skills\"");

WriteLiteral(">");

            
            #line 86 "..\..\Views\VacancyPosting\PreviewVacancy.cshtml"
                                                                         Write(Html.Raw(Model.VacancyRequirementsProspectsViewModel.DesiredSkills));

            
            #line default
            #line hidden
WriteLiteral("</p>\r\n");

            
            #line 87 "..\..\Views\VacancyPosting\PreviewVacancy.cshtml"
                        }

            
            #line default
            #line hidden
WriteLiteral("                        ");

            
            #line 88 "..\..\Views\VacancyPosting\PreviewVacancy.cshtml"
                         if (!string.IsNullOrWhiteSpace(Model.VacancyRequirementsProspectsViewModel.PersonalQualities))
                        {

            
            #line default
            #line hidden
WriteLiteral("                            <h3");

WriteLiteral(" class=\"heading-small\"");

WriteLiteral(">Personal qualities</h3>\r\n");

WriteLiteral("                            <p");

WriteLiteral(" id=\"vacancy-qualities-required\"");

WriteLiteral(" itemprop=\"qualities\"");

WriteLiteral(">");

            
            #line 91 "..\..\Views\VacancyPosting\PreviewVacancy.cshtml"
                                                                               Write(Html.Raw(Model.VacancyRequirementsProspectsViewModel.PersonalQualities));

            
            #line default
            #line hidden
WriteLiteral("</p>\r\n");

            
            #line 92 "..\..\Views\VacancyPosting\PreviewVacancy.cshtml"
                        }

            
            #line default
            #line hidden
WriteLiteral("                        ");

            
            #line 93 "..\..\Views\VacancyPosting\PreviewVacancy.cshtml"
                         if (!string.IsNullOrWhiteSpace(Model.VacancyRequirementsProspectsViewModel.DesiredQualifications))
                        {

            
            #line default
            #line hidden
WriteLiteral("                            <h3");

WriteLiteral(" class=\"heading-small\"");

WriteLiteral(">Qualifications required</h3>\r\n");

WriteLiteral("                            <p");

WriteLiteral(" id=\"vacancy-qualifications-required\"");

WriteLiteral(" itemprop=\"qualifications\"");

WriteLiteral(">");

            
            #line 96 "..\..\Views\VacancyPosting\PreviewVacancy.cshtml"
                                                                                         Write(Html.Raw(Model.VacancyRequirementsProspectsViewModel.DesiredQualifications));

            
            #line default
            #line hidden
WriteLiteral("</p>\r\n");

            
            #line 97 "..\..\Views\VacancyPosting\PreviewVacancy.cshtml"
                        }

            
            #line default
            #line hidden
WriteLiteral("\r\n                    </div>\r\n                </div>\r\n            </div>\r\n       " +
"     <div");

WriteLiteral(" class=\"grid grid-1-2\"");

WriteLiteral(">\r\n                <div");

WriteLiteral(" class=\"text\"");

WriteLiteral(">\r\n");

            
            #line 104 "..\..\Views\VacancyPosting\PreviewVacancy.cshtml"
                    
            
            #line default
            #line hidden
            
            #line 104 "..\..\Views\VacancyPosting\PreviewVacancy.cshtml"
                     if (!string.IsNullOrWhiteSpace(Model.VacancyRequirementsProspectsViewModel.FutureProspects))
                    {

            
            #line default
            #line hidden
WriteLiteral("                        <h3");

WriteLiteral(" class=\"heading-small\"");

WriteLiteral(">Future prospects</h3>\r\n");

WriteLiteral("                        <p");

WriteLiteral(" id=\"vacancy-future-prospects\"");

WriteLiteral(" itemprop=\"incentives\"");

WriteLiteral(">");

            
            #line 107 "..\..\Views\VacancyPosting\PreviewVacancy.cshtml"
                                                                          Write(Html.Raw(Model.VacancyRequirementsProspectsViewModel.FutureProspects));

            
            #line default
            #line hidden
WriteLiteral("</p>\r\n");

            
            #line 108 "..\..\Views\VacancyPosting\PreviewVacancy.cshtml"
                    }

            
            #line default
            #line hidden
WriteLiteral("                    ");

            
            #line 109 "..\..\Views\VacancyPosting\PreviewVacancy.cshtml"
                     if (!string.IsNullOrWhiteSpace(Model.VacancyRequirementsProspectsViewModel.ThingsToConsider))
                    {

            
            #line default
            #line hidden
WriteLiteral("                        <h3");

WriteLiteral(" class=\"heading-small\"");

WriteLiteral(">Things to consider</h3>\r\n");

WriteLiteral("                        <p");

WriteLiteral(" id=\"vacancy-reality-check\"");

WriteLiteral(" itemprop=\"incentives\"");

WriteLiteral(">");

            
            #line 112 "..\..\Views\VacancyPosting\PreviewVacancy.cshtml"
                                                                       Write(Html.Raw(Model.VacancyRequirementsProspectsViewModel.ThingsToConsider));

            
            #line default
            #line hidden
WriteLiteral("</p>\r\n");

            
            #line 113 "..\..\Views\VacancyPosting\PreviewVacancy.cshtml"
                    }

            
            #line default
            #line hidden
WriteLiteral("                </div>\r\n            </div>\r\n        </section>\r\n        <section");

WriteLiteral(" class=\"section-border\"");

WriteLiteral(" id=\"employer-info\"");

WriteLiteral(">\r\n            <h2");

WriteLiteral(" class=\"heading-large\"");

WriteLiteral(">About the employer</h2>\r\n            <div");

WriteLiteral(" class=\"grid-wrapper\"");

WriteLiteral(">\r\n                <div");

WriteLiteral(" class=\"grid grid-2-3\"");

WriteLiteral(">\r\n                    <div");

WriteLiteral(" class=\"inner-block-padr\"");

WriteLiteral(">\r\n                        <div");

WriteLiteral(" class=\"text\"");

WriteLiteral(">\r\n                            <p");

WriteLiteral(" id=\"vacancy-employer-description\"");

WriteLiteral(">");

            
            #line 123 "..\..\Views\VacancyPosting\PreviewVacancy.cshtml"
                                                            Write(Html.Raw(Model.NewVacancyViewModel.ProviderSiteEmployerLink.Description));

            
            #line default
            #line hidden
WriteLiteral("</p>\r\n                        </div>\r\n                    </div>\r\n               " +
" </div>\r\n            </div>\r\n            <div");

WriteLiteral(" class=\"grid-wrapper\"");

WriteLiteral(">\r\n                <div");

WriteLiteral(" class=\"grid grid-1-2\"");

WriteLiteral(">\r\n                    <div");

WriteLiteral(" class=\"inner-block-padr\"");

WriteLiteral(">\r\n                        <div");

WriteLiteral(" class=\"text\"");

WriteLiteral(">\r\n                            <h3");

WriteLiteral(" class=\"bold-small\"");

WriteLiteral(">Employer</h3>\r\n                            <p");

WriteLiteral(" id=\"vacancy-employer-name\"");

WriteAttribute("class", Tuple.Create(" class=\"", 7458), Tuple.Create("\"", 7585)
            
            #line 133 "..\..\Views\VacancyPosting\PreviewVacancy.cshtml"
, Tuple.Create(Tuple.Create("", 7466), Tuple.Create<System.Object, System.Int32>(string.IsNullOrEmpty(Model.NewVacancyViewModel.ProviderSiteEmployerLink.WebsiteUrl) ? "no-btm-margin" : string.Empty
            
            #line default
            #line hidden
, 7466), false)
);

WriteLiteral(">");

            
            #line 133 "..\..\Views\VacancyPosting\PreviewVacancy.cshtml"
                                                                                                                                                                                     Write(Model.NewVacancyViewModel.ProviderSiteEmployerLink.Employer.Name);

            
            #line default
            #line hidden
WriteLiteral("</p>\r\n");

            
            #line 134 "..\..\Views\VacancyPosting\PreviewVacancy.cshtml"
                            
            
            #line default
            #line hidden
            
            #line 134 "..\..\Views\VacancyPosting\PreviewVacancy.cshtml"
                             if (string.IsNullOrEmpty(Model.NewVacancyViewModel.ProviderSiteEmployerLink.WebsiteUrl))
                            {

            
            #line default
            #line hidden
WriteLiteral("                                <p>\r\n                                    <a");

WriteLiteral(" itemprop=\"url\"");

WriteAttribute("href", Tuple.Create(" href=\"", 7898), Tuple.Create("\"", 7967)
            
            #line 137 "..\..\Views\VacancyPosting\PreviewVacancy.cshtml"
, Tuple.Create(Tuple.Create("", 7905), Tuple.Create<System.Object, System.Int32>(Model.NewVacancyViewModel.ProviderSiteEmployerLink.WebsiteUrl
            
            #line default
            #line hidden
, 7905), false)
);

WriteLiteral("\r\n                                       id=\"vacancy-employer-website\"");

WriteLiteral("\r\n                                       target=\"_blank\"");

WriteAttribute("title", Tuple.Create("\r\n                                       title=\"", 8094), Tuple.Create("\"", 8215)
            
            #line 140 "..\..\Views\VacancyPosting\PreviewVacancy.cshtml"
, Tuple.Create(Tuple.Create("", 8142), Tuple.Create<System.Object, System.Int32>(Model.NewVacancyViewModel.ProviderSiteEmployerLink.Employer.Name
            
            #line default
            #line hidden
, 8142), false)
, Tuple.Create(Tuple.Create(" ", 8207), Tuple.Create("Website", 8208), true)
);

WriteLiteral(" rel=\"external\"");

WriteLiteral(">");

            
            #line 140 "..\..\Views\VacancyPosting\PreviewVacancy.cshtml"
                                                                                                                                   Write(Model.NewVacancyViewModel.ProviderSiteEmployerLink.WebsiteUrl);

            
            #line default
            #line hidden
WriteLiteral("</a>\r\n                                </p>\r\n");

            
            #line 142 "..\..\Views\VacancyPosting\PreviewVacancy.cshtml"
                            }

            
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

            
            #line 146 "..\..\Views\VacancyPosting\PreviewVacancy.cshtml"
                                                                                    Write(Model.NewVacancyViewModel.ProviderSiteEmployerLink.Employer.Address.AddressLine1);

            
            #line default
            #line hidden
WriteLiteral("</p>\r\n                                    <p");

WriteLiteral(" class=\"small-btm-margin\"");

WriteLiteral(" itemprop=\"streetAddress\"");

WriteLiteral(">");

            
            #line 147 "..\..\Views\VacancyPosting\PreviewVacancy.cshtml"
                                                                                    Write(Model.NewVacancyViewModel.ProviderSiteEmployerLink.Employer.Address.AddressLine2);

            
            #line default
            #line hidden
WriteLiteral("</p>\r\n                                    <p");

WriteLiteral(" class=\"small-btm-margin\"");

WriteLiteral(" itemprop=\"addressLocality\"");

WriteLiteral(">");

            
            #line 148 "..\..\Views\VacancyPosting\PreviewVacancy.cshtml"
                                                                                      Write(Model.NewVacancyViewModel.ProviderSiteEmployerLink.Employer.Address.AddressLine3);

            
            #line default
            #line hidden
WriteLiteral("</p>\r\n                                    <p");

WriteLiteral(" class=\"small-btm-margin\"");

WriteLiteral(" itemprop=\"addressRegion\"");

WriteLiteral(">");

            
            #line 149 "..\..\Views\VacancyPosting\PreviewVacancy.cshtml"
                                                                                    Write(Model.NewVacancyViewModel.ProviderSiteEmployerLink.Employer.Address.AddressLine4);

            
            #line default
            #line hidden
WriteLiteral("</p>\r\n                                    <p");

WriteLiteral(" class=\"small-btm-margin\"");

WriteLiteral(" itemprop=\"postalCode\"");

WriteLiteral(">");

            
            #line 150 "..\..\Views\VacancyPosting\PreviewVacancy.cshtml"
                                                                                 Write(Model.NewVacancyViewModel.ProviderSiteEmployerLink.Employer.Address.Postcode);

            
            #line default
            #line hidden
WriteLiteral("</p>\r\n                                </div>\r\n                            </div>\r" +
"\n                        </div>\r\n                    </div>\r\n                </d" +
"iv>\r\n                <div");

WriteLiteral(" class=\"grid grid-1-2 hide-print\"");

WriteLiteral(">\r\n                    <div");

WriteLiteral(" id=\"vacancy-map\"");

WriteLiteral(" class=\"ad-details__map\"");

WriteLiteral(">\r\n                        <div");

WriteLiteral(" class=\"map-overlay\"");

WriteLiteral(" onclick=\" style.pointerEvents = \'none\' \"");

WriteLiteral("></div>\r\n                        <iframe");

WriteLiteral(" width=\"700\"");

WriteLiteral(" height=\"250\"");

WriteLiteral(" title=\"Map of location\"");

WriteLiteral(" style=\"border: 0\"");

WriteAttribute("src", Tuple.Create(" src=\"", 9960), Tuple.Create("\"", 10162)
, Tuple.Create(Tuple.Create("", 9966), Tuple.Create("https://www.google.com/maps/embed/v1/place?q=", 9966), true)
            
            #line 159 "..\..\Views\VacancyPosting\PreviewVacancy.cshtml"
                                                                    , Tuple.Create(Tuple.Create("", 10011), Tuple.Create<System.Object, System.Int32>(Html.Raw(Model.NewVacancyViewModel.ProviderSiteEmployerLink.Employer.Address.Postcode)
            
            #line default
            #line hidden
, 10011), false)
, Tuple.Create(Tuple.Create("", 10098), Tuple.Create(",+United+Kingdom&amp;key=AIzaSyCusA_0x4bJEjU-_gLOFiXMSBXKZYtvHz8", 10098), true)
);

WriteLiteral("></iframe>\r\n                        <p");

WriteLiteral(" class=\"nojs-notice\"");

WriteLiteral(">You must have JavaScript enabled to view a map of the location</p>\r\n            " +
"        </div>\r\n                </div>\r\n            </div>\r\n        </section>\r\n" +
"\r\n");

            
            #line 166 "..\..\Views\VacancyPosting\PreviewVacancy.cshtml"
        
            
            #line default
            #line hidden
            
            #line 166 "..\..\Views\VacancyPosting\PreviewVacancy.cshtml"
         if (Model.NewVacancyViewModel.OfflineVacancy)
        {

            
            #line default
            #line hidden
WriteLiteral("            <section");

WriteLiteral(" class=\"section-border\"");

WriteLiteral(" id=\"offline-vacancy\"");

WriteLiteral(" style=\"\"");

WriteLiteral(">\r\n                <h2");

WriteLiteral(" class=\"heading-large\"");

WriteLiteral(">Employer\'s application instructions</h2>\r\n                <div");

WriteLiteral(" class=\"text\"");

WriteLiteral(">\r\n                    <p");

WriteLiteral(" id=\"application-instructions\"");

WriteLiteral(">\r\n");

WriteLiteral("                        ");

            
            #line 172 "..\..\Views\VacancyPosting\PreviewVacancy.cshtml"
                   Write(Model.NewVacancyViewModel.OfflineApplicationInstructions);

            
            #line default
            #line hidden
WriteLiteral("\r\n                    </p>\r\n                </div>\r\n                <div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(">\r\n                    <p");

WriteLiteral(" class=\"no-btm-margin\"");

WriteLiteral(">This apprenticeship requires you to apply through the employer\'s website.</p>\r\n " +
"                   <a");

WriteLiteral(" id=\"external-employer-website\"");

WriteLiteral(" rel=\"external\"");

WriteAttribute("href", Tuple.Create(" href=\"", 11069), Tuple.Create("\"", 11124)
            
            #line 177 "..\..\Views\VacancyPosting\PreviewVacancy.cshtml"
, Tuple.Create(Tuple.Create("", 11076), Tuple.Create<System.Object, System.Int32>(Model.NewVacancyViewModel.OfflineApplicationUrl
            
            #line default
            #line hidden
, 11076), false)
);

WriteLiteral(" target=\"_blank\"");

WriteLiteral(">");

            
            #line 177 "..\..\Views\VacancyPosting\PreviewVacancy.cshtml"
                                                                                                                                        Write(Model.NewVacancyViewModel.OfflineApplicationUrl);

            
            #line default
            #line hidden
WriteLiteral("</a>\r\n                    <i");

WriteLiteral(" class=\"fa fa-check the-icon\"");

WriteLiteral(" style=\"color: green;\"");

WriteLiteral("></i>\r\n                </div>\r\n            </section>\r\n");

            
            #line 181 "..\..\Views\VacancyPosting\PreviewVacancy.cshtml"
        }

            
            #line default
            #line hidden
WriteLiteral("        \r\n        <section");

WriteLiteral(" class=\"section-border grid-wrapper\"");

WriteLiteral(" id=\"provider-info\"");

WriteLiteral(">\r\n            <h2");

WriteLiteral(" class=\"heading-large\"");

WriteLiteral(">Training provider</h2>\r\n            <div");

WriteLiteral(" class=\"grid grid-2-3\"");

WriteLiteral(">\r\n                <div");

WriteLiteral(" class=\"inner-block-padr\"");

WriteLiteral(">\r\n                    <div");

WriteLiteral(" class=\"text\"");

WriteLiteral(">\r\n");

            
            #line 188 "..\..\Views\VacancyPosting\PreviewVacancy.cshtml"
                        
            
            #line default
            #line hidden
            
            #line 188 "..\..\Views\VacancyPosting\PreviewVacancy.cshtml"
                         if (!string.IsNullOrWhiteSpace(Model.ProviderSite.CandidateDescription))
                        {

            
            #line default
            #line hidden
WriteLiteral("                            <p");

WriteLiteral(" id=\"vacancy-training-to-be-provided\"");

WriteLiteral(">");

            
            #line 190 "..\..\Views\VacancyPosting\PreviewVacancy.cshtml"
                                                               Write(Html.Raw(Model.ProviderSite.CandidateDescription));

            
            #line default
            #line hidden
WriteLiteral("</p>\r\n");

            
            #line 191 "..\..\Views\VacancyPosting\PreviewVacancy.cshtml"
                        }

            
            #line default
            #line hidden
WriteLiteral("                        <h3");

WriteLiteral(" class=\"heading-small\"");

WriteLiteral(">Apprenticeship framework</h3>\r\n                        <p");

WriteLiteral(" id=\"vacancy-framework\"");

WriteLiteral(">");

            
            #line 193 "..\..\Views\VacancyPosting\PreviewVacancy.cshtml"
                                             Write(Html.Raw(Model.FrameworkName));

            
            #line default
            #line hidden
WriteLiteral("</p>\r\n                        <p");

WriteLiteral(" id=\"vacancy-provider-sector-pass-rate\"");

WriteLiteral(">The training provider does not yet have a sector success rate for this type of a" +
"pprenticeship training.</p>\r\n                    </div>\r\n                </div>\r" +
"\n            </div>\r\n            <div");

WriteLiteral(" class=\"grid grid-1-3\"");

WriteLiteral(">\r\n                <div");

WriteLiteral(" class=\"text\"");

WriteLiteral(">\r\n                    <h3");

WriteLiteral(" class=\"bold-small\"");

WriteLiteral(">Training provider</h3>\r\n                    <p");

WriteLiteral(" id=\"vacancy-provider-name\"");

WriteLiteral(">");

            
            #line 201 "..\..\Views\VacancyPosting\PreviewVacancy.cshtml"
                                             Write(Model.ProviderSite.Name);

            
            #line default
            #line hidden
WriteLiteral("</p>\r\n                </div>\r\n\r\n");

            
            #line 204 "..\..\Views\VacancyPosting\PreviewVacancy.cshtml"
                
            
            #line default
            #line hidden
            
            #line 204 "..\..\Views\VacancyPosting\PreviewVacancy.cshtml"
                 if (!string.IsNullOrWhiteSpace(Model.ProviderSite.ContactDetailsForCandidate))
                {

            
            #line default
            #line hidden
WriteLiteral("                    <div");

WriteLiteral(" class=\"text\"");

WriteLiteral(">\r\n                        <h3");

WriteLiteral(" class=\"bold-small\"");

WriteLiteral(">Contact</h3>\r\n                        <p");

WriteLiteral(" id=\"vacancy-provider-contact\"");

WriteLiteral(">");

            
            #line 208 "..\..\Views\VacancyPosting\PreviewVacancy.cshtml"
                                                    Write(Model.ProviderSite.ContactDetailsForCandidate);

            
            #line default
            #line hidden
WriteLiteral("</p>\r\n                    </div>\r\n");

            
            #line 210 "..\..\Views\VacancyPosting\PreviewVacancy.cshtml"
                }

            
            #line default
            #line hidden
WriteLiteral("            </div>\r\n\r\n        </section>\r\n\r\n");

            
            #line 215 "..\..\Views\VacancyPosting\PreviewVacancy.cshtml"
 using (Html.BeginRouteForm(RecruitmentRouteNames.VacancySubmitted, FormMethod.Get))
{
    
            
            #line default
            #line hidden
            
            #line 217 "..\..\Views\VacancyPosting\PreviewVacancy.cshtml"
Write(Html.HiddenFor(m => m.VacancyReferenceNumber));

            
            #line default
            #line hidden
            
            #line 217 "..\..\Views\VacancyPosting\PreviewVacancy.cshtml"
                                                  


            
            #line default
            #line hidden
WriteLiteral("    <section>\r\n        <div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(">\r\n            <button");

WriteLiteral(" type=\"submit\"");

WriteLiteral(" class=\"button\"");

WriteLiteral(">Submit for approval</button>\r\n            <a");

WriteLiteral(" id=\"dashboardLink\"");

WriteAttribute("href", Tuple.Create(" href=\"", 13272), Tuple.Create("\"", 13331)
            
            #line 222 "..\..\Views\VacancyPosting\PreviewVacancy.cshtml"
, Tuple.Create(Tuple.Create("", 13279), Tuple.Create<System.Object, System.Int32>(Url.RouteUrl(RecruitmentRouteNames.RecruitmentHome)
            
            #line default
            #line hidden
, 13279), false)
);

WriteLiteral(">Return to dashboard</a>\r\n        </div>\r\n    </section>\r\n");

            
            #line 225 "..\..\Views\VacancyPosting\PreviewVacancy.cshtml"
}

            
            #line default
            #line hidden
WriteLiteral("</div>");

        }
    }
}
#pragma warning restore 1591
