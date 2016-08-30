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
    
    #line 1 "..\..\Views\Shared\DisplayTemplates\Vacancy\_WorkingWeekAndWage.cshtml"
    using SFA.Apprenticeships.Domain.Entities.Raa.Vacancies;
    
    #line default
    #line hidden
    
    #line 2 "..\..\Views\Shared\DisplayTemplates\Vacancy\_WorkingWeekAndWage.cshtml"
    using SFA.Apprenticeships.Domain.Entities.Vacancies;
    
    #line default
    #line hidden
    using SFA.Apprenticeships.Infrastructure.Presentation;
    
    #line 3 "..\..\Views\Shared\DisplayTemplates\Vacancy\_WorkingWeekAndWage.cshtml"
    using SFA.Apprenticeships.Infrastructure.Presentation.Constants;
    
    #line default
    #line hidden
    using SFA.Apprenticeships.Web.Common.Constants;
    using SFA.Apprenticeships.Web.Common.Framework;
    using SFA.Apprenticeships.Web.Common.Models.Common;
    using SFA.Apprenticeships.Web.Raa.Common;
    
    #line 4 "..\..\Views\Shared\DisplayTemplates\Vacancy\_WorkingWeekAndWage.cshtml"
    using SFA.Apprenticeships.Web.Raa.Common.Extensions;
    
    #line default
    #line hidden
    
    #line 5 "..\..\Views\Shared\DisplayTemplates\Vacancy\_WorkingWeekAndWage.cshtml"
    using SFA.Apprenticeships.Web.Raa.Common.ViewModels.Vacancy;
    
    #line default
    #line hidden
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/Shared/DisplayTemplates/Vacancy/_WorkingWeekAndWage.cshtml")]
    public partial class WorkingWeekAndWage : System.Web.Mvc.WebViewPage<VacancyViewModel>
    {
        public WorkingWeekAndWage()
        {
        }
        public override void Execute()
        {
            
            #line 8 "..\..\Views\Shared\DisplayTemplates\Vacancy\_WorkingWeekAndWage.cshtml"
  
    var editableItemClass = ViewData["editableItemClass"];

            
            #line default
            #line hidden
WriteLiteral("\r\n\r\n<div");

WriteAttribute("class", Tuple.Create(" class=\"", 394), Tuple.Create("\"", 420)
            
            #line 12 "..\..\Views\Shared\DisplayTemplates\Vacancy\_WorkingWeekAndWage.cshtml"
, Tuple.Create(Tuple.Create("", 402), Tuple.Create<System.Object, System.Int32>(editableItemClass
            
            #line default
            #line hidden
, 402), false)
);

WriteLiteral(">\r\n    <h3");

WriteLiteral(" class=\"bold-small\"");

WriteLiteral(">\r\n");

            
            #line 14 "..\..\Views\Shared\DisplayTemplates\Vacancy\_WorkingWeekAndWage.cshtml"
        
            
            #line default
            #line hidden
            
            #line 14 "..\..\Views\Shared\DisplayTemplates\Vacancy\_WorkingWeekAndWage.cshtml"
         if (Model.VacancyType == SFA.Apprenticeships.Domain.Entities.Raa.Vacancies.VacancyType.Traineeship)
        {

            
            #line default
            #line hidden
WriteLiteral("            <span>Weekly hours</span>\r\n");

            
            #line 17 "..\..\Views\Shared\DisplayTemplates\Vacancy\_WorkingWeekAndWage.cshtml"
        }
        else
        {

            
            #line default
            #line hidden
WriteLiteral("            <span>Working week</span>\r\n");

            
            #line 21 "..\..\Views\Shared\DisplayTemplates\Vacancy\_WorkingWeekAndWage.cshtml"
            
            
            #line default
            #line hidden
            
            #line 21 "..\..\Views\Shared\DisplayTemplates\Vacancy\_WorkingWeekAndWage.cshtml"
       Write(Html.Partial(ValidationResultViewModel.PartialView, Html.GetValidationResultViewModel(Model, m => m.FurtherVacancyDetailsViewModel.WorkingWeek, ViewData.ModelState, Model.SummaryLink, Model.FurtherVacancyDetailsViewModel.WorkingWeekComment)));

            
            #line default
            #line hidden
            
            #line 21 "..\..\Views\Shared\DisplayTemplates\Vacancy\_WorkingWeekAndWage.cshtml"
                                                                                                                                                                                                                                                              
        }

            
            #line default
            #line hidden
WriteLiteral("    </h3>\r\n    <p");

WriteLiteral(" id=\"vacancy-working-week\"");

WriteLiteral(" itemprop=\"workHours\"");

WriteAttribute("class", Tuple.Create(" class=\"", 1019), Tuple.Create("\"", 1108)
            
            #line 24 "..\..\Views\Shared\DisplayTemplates\Vacancy\_WorkingWeekAndWage.cshtml"
, Tuple.Create(Tuple.Create("", 1027), Tuple.Create<System.Object, System.Int32>(Model.FurtherVacancyDetailsViewModel.WorkingWeek.GetPreserveFormattingCssClass()
            
            #line default
            #line hidden
, 1027), false)
);

WriteLiteral(">");

            
            #line 24 "..\..\Views\Shared\DisplayTemplates\Vacancy\_WorkingWeekAndWage.cshtml"
                                                                                                                                           Write(Model.FurtherVacancyDetailsViewModel.WorkingWeek);

            
            #line default
            #line hidden
WriteLiteral("</p>\r\n");

            
            #line 25 "..\..\Views\Shared\DisplayTemplates\Vacancy\_WorkingWeekAndWage.cshtml"
    
            
            #line default
            #line hidden
            
            #line 25 "..\..\Views\Shared\DisplayTemplates\Vacancy\_WorkingWeekAndWage.cshtml"
     if (Model.VacancyType == SFA.Apprenticeships.Domain.Entities.Raa.Vacancies.VacancyType.Apprenticeship && Model.FurtherVacancyDetailsViewModel.Wage.HoursPerWeek.HasValue)
    {

            
            #line default
            #line hidden
WriteLiteral("        <a");

WriteLiteral(" name=\"furthervacancydetailsviewmodel_hoursperweek\"");

WriteLiteral("></a>\r\n");

WriteLiteral("        <p");

WriteLiteral(" id=\"total-hours-per-week\"");

WriteLiteral(">Total hours per week: ");

            
            #line 28 "..\..\Views\Shared\DisplayTemplates\Vacancy\_WorkingWeekAndWage.cshtml"
                                                      Write(Model.FurtherVacancyDetailsViewModel.Wage.HoursPerWeek);

            
            #line default
            #line hidden
WriteLiteral("</p>\r\n");

            
            #line 29 "..\..\Views\Shared\DisplayTemplates\Vacancy\_WorkingWeekAndWage.cshtml"
        if (Model.FurtherVacancyDetailsViewModel.Wage.HoursPerWeek > 40)
        {

            
            #line default
            #line hidden
WriteLiteral("            <p>(the hours are based on the candidate being over 18)</p>\r\n");

            
            #line 32 "..\..\Views\Shared\DisplayTemplates\Vacancy\_WorkingWeekAndWage.cshtml"
        }
    }

            
            #line default
            #line hidden
WriteLiteral("    ");

            
            #line 34 "..\..\Views\Shared\DisplayTemplates\Vacancy\_WorkingWeekAndWage.cshtml"
Write(Html.Partial(EditLinkViewModel.PartialView, Html.GetEditLinkViewModel(Model, m => m.FurtherVacancyDetailsViewModel.WorkingWeek, Model.SummaryLink, Model.FurtherVacancyDetailsViewModel.WorkingWeekComment)));

            
            #line default
            #line hidden
WriteLiteral("\r\n</div>\r\n\r\n");

            
            #line 37 "..\..\Views\Shared\DisplayTemplates\Vacancy\_WorkingWeekAndWage.cshtml"
 if (Model.VacancyType == SFA.Apprenticeships.Domain.Entities.Raa.Vacancies.VacancyType.Apprenticeship)
{

            
            #line default
            #line hidden
WriteLiteral("    <div");

WriteAttribute("class", Tuple.Create(" class=\"", 2049), Tuple.Create("\"", 2075)
            
            #line 39 "..\..\Views\Shared\DisplayTemplates\Vacancy\_WorkingWeekAndWage.cshtml"
, Tuple.Create(Tuple.Create("", 2057), Tuple.Create<System.Object, System.Int32>(editableItemClass
            
            #line default
            #line hidden
, 2057), false)
);

WriteLiteral(">\r\n        <h3");

WriteLiteral(" class=\"bold-small\"");

WriteLiteral(">\r\n");

            
            #line 41 "..\..\Views\Shared\DisplayTemplates\Vacancy\_WorkingWeekAndWage.cshtml"
            
            
            #line default
            #line hidden
            
            #line 41 "..\..\Views\Shared\DisplayTemplates\Vacancy\_WorkingWeekAndWage.cshtml"
             if (Model.FurtherVacancyDetailsViewModel.Wage.Type == WageType.Custom)
            {

            
            #line default
            #line hidden
WriteLiteral("                <span>\r\n");

WriteLiteral("                    ");

            
            #line 44 "..\..\Views\Shared\DisplayTemplates\Vacancy\_WorkingWeekAndWage.cshtml"
               Write(Model.FurtherVacancyDetailsViewModel.Wage.Unit.GetHeaderDisplayText());

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("                    ");

            
            #line 45 "..\..\Views\Shared\DisplayTemplates\Vacancy\_WorkingWeekAndWage.cshtml"
               Write(Html.Partial(ValidationResultViewModel.PartialView, Html.GetValidationResultViewModel(Model, m => m.FurtherVacancyDetailsViewModel.Wage.Type, ViewData.ModelState, Model.SummaryLink, Model.FurtherVacancyDetailsViewModel.WageComment)));

            
            #line default
            #line hidden
WriteLiteral("\r\n                </span>\r\n");

            
            #line 47 "..\..\Views\Shared\DisplayTemplates\Vacancy\_WorkingWeekAndWage.cshtml"
            }
            else
            {

            
            #line default
            #line hidden
WriteLiteral("                <span>\r\n                    Weekly wage\r\n");

WriteLiteral("                    ");

            
            #line 52 "..\..\Views\Shared\DisplayTemplates\Vacancy\_WorkingWeekAndWage.cshtml"
               Write(Html.Partial(ValidationResultViewModel.PartialView, Html.GetValidationResultViewModel(Model, m => m.FurtherVacancyDetailsViewModel.Wage.Type, ViewData.ModelState, Model.SummaryLink, Model.FurtherVacancyDetailsViewModel.WageComment)));

            
            #line default
            #line hidden
WriteLiteral("\r\n                </span>\r\n");

            
            #line 54 "..\..\Views\Shared\DisplayTemplates\Vacancy\_WorkingWeekAndWage.cshtml"
            }

            
            #line default
            #line hidden
WriteLiteral("        </h3>\r\n        <p");

WriteLiteral(" id=\"vacancy-wage\"");

WriteLiteral(">");

            
            #line 56 "..\..\Views\Shared\DisplayTemplates\Vacancy\_WorkingWeekAndWage.cshtml"
                        Write(Model.FurtherVacancyDetailsViewModel.Wage.WageDisplayText);

            
            #line default
            #line hidden
WriteLiteral("</p>\r\n");

WriteLiteral("        ");

            
            #line 57 "..\..\Views\Shared\DisplayTemplates\Vacancy\_WorkingWeekAndWage.cshtml"
   Write(Html.Partial(EditLinkViewModel.PartialView, Html.GetEditLinkViewModel(Model, m => m.FurtherVacancyDetailsViewModel.Wage.Type, Model.SummaryLink, Model.FurtherVacancyDetailsViewModel.WageComment)));

            
            #line default
            #line hidden
WriteLiteral("\r\n    </div>\r\n");

            
            #line 59 "..\..\Views\Shared\DisplayTemplates\Vacancy\_WorkingWeekAndWage.cshtml"

    if (Model.FurtherVacancyDetailsViewModel.Wage.Type == WageType.ApprenticeshipMinimum)
    {

            
            #line default
            #line hidden
WriteLiteral("        <details>\r\n            <summary>Wages explained</summary>\r\n            <d" +
"iv");

WriteLiteral(" class=\"detail-content\"");

WriteLiteral(">\r\n                The current National Minimum Wage (NMW) for apprentices is £");

            
            #line 65 "..\..\Views\Shared\DisplayTemplates\Vacancy\_WorkingWeekAndWage.cshtml"
                                                                       Write(Wages.ApprenticeMinimumWage);

            
            #line default
            #line hidden
WriteLiteral(@" per hour.<br />
                This rate applies to apprentices aged 16 to 18 and those aged 19 or over who are in their first year.<br />
                Apprentices must be paid at least the NMW for their age if they're aged 19 or over and have completed their first year.
            </div>
        </details>
");

            
            #line 70 "..\..\Views\Shared\DisplayTemplates\Vacancy\_WorkingWeekAndWage.cshtml"
    }

    if (Model.FurtherVacancyDetailsViewModel.Wage.Type == WageType.NationalMinimum)
    {

            
            #line default
            #line hidden
WriteLiteral("        <details>\r\n            <summary>Wages explained</summary>\r\n            <d" +
"iv");

WriteLiteral(" class=\"detail-content\"");

WriteLiteral(">\r\n                The current National Minimum Wage rates are £");

            
            #line 77 "..\..\Views\Shared\DisplayTemplates\Vacancy\_WorkingWeekAndWage.cshtml"
                                                        Write(Wages.Between18And20NationalMinimumWage);

            
            #line default
            #line hidden
WriteLiteral(" for 18 to 20 year-olds and £");

            
            #line 77 "..\..\Views\Shared\DisplayTemplates\Vacancy\_WorkingWeekAndWage.cshtml"
                                                                                                                             Write(Wages.Over21NationalMinimumWage);

            
            #line default
            #line hidden
WriteLiteral(" for anyone aged 21 and over.<br />\r\n                Apprentices are paid for the" +
"ir normal working hours and training that’s part of their apprenticeship (usuall" +
"y one day per week).\r\n            </div>\r\n        </details>\r\n");

            
            #line 81 "..\..\Views\Shared\DisplayTemplates\Vacancy\_WorkingWeekAndWage.cshtml"
    }
}
            
            #line default
            #line hidden
        }
    }
}
#pragma warning restore 1591
