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
    
    #line 6 "..\..\Views\Shared\DisplayTemplates\Vacancy\_WorkingWeekAndWage.cshtml"
    using HtmlExtensions = SFA.Apprenticeships.Web.Common.Framework.HtmlExtensions;
    
    #line default
    #line hidden
    
    #line 1 "..\..\Views\Shared\DisplayTemplates\Vacancy\_WorkingWeekAndWage.cshtml"
    using SFA.Apprenticeships.Domain.Entities.Raa.Vacancies;
    
    #line default
    #line hidden
    
    #line 2 "..\..\Views\Shared\DisplayTemplates\Vacancy\_WorkingWeekAndWage.cshtml"
    using SFA.Apprenticeships.Domain.Entities.Vacancies;
    
    #line default
    #line hidden
    using SFA.Apprenticeships.Infrastructure.Presentation;
    using SFA.Apprenticeships.Web.Common.Constants;
    using SFA.Apprenticeships.Web.Common.Framework;
    using SFA.Apprenticeships.Web.Common.Models.Common;
    
    #line 3 "..\..\Views\Shared\DisplayTemplates\Vacancy\_WorkingWeekAndWage.cshtml"
    using SFA.Apprenticeships.Web.Common.ViewModels;
    
    #line default
    #line hidden
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
            
            #line 9 "..\..\Views\Shared\DisplayTemplates\Vacancy\_WorkingWeekAndWage.cshtml"
  
    var editableItemClass = ViewData["editableItemClass"];

            
            #line default
            #line hidden
WriteLiteral("\r\n\r\n<div");

WriteAttribute("class", Tuple.Create(" class=\"", 459), Tuple.Create("\"", 485)
            
            #line 13 "..\..\Views\Shared\DisplayTemplates\Vacancy\_WorkingWeekAndWage.cshtml"
, Tuple.Create(Tuple.Create("", 467), Tuple.Create<System.Object, System.Int32>(editableItemClass
            
            #line default
            #line hidden
, 467), false)
);

WriteLiteral(">\r\n    <h3");

WriteLiteral(" class=\"bold-small\"");

WriteLiteral(">\r\n");

            
            #line 15 "..\..\Views\Shared\DisplayTemplates\Vacancy\_WorkingWeekAndWage.cshtml"
        
            
            #line default
            #line hidden
            
            #line 15 "..\..\Views\Shared\DisplayTemplates\Vacancy\_WorkingWeekAndWage.cshtml"
         if (Model.VacancyType == SFA.Apprenticeships.Domain.Entities.Raa.Vacancies.VacancyType.Traineeship)
        {

            
            #line default
            #line hidden
WriteLiteral("            <span>Weekly hours</span>\r\n");

            
            #line 18 "..\..\Views\Shared\DisplayTemplates\Vacancy\_WorkingWeekAndWage.cshtml"
        }
        else
        {

            
            #line default
            #line hidden
WriteLiteral("            <span>Working week</span>\r\n");

            
            #line 22 "..\..\Views\Shared\DisplayTemplates\Vacancy\_WorkingWeekAndWage.cshtml"
            
            
            #line default
            #line hidden
            
            #line 22 "..\..\Views\Shared\DisplayTemplates\Vacancy\_WorkingWeekAndWage.cshtml"
       Write(Html.Partial(ValidationResultViewModel.PartialView, Html.GetValidationResultViewModel(Model, m => m.FurtherVacancyDetailsViewModel.WorkingWeek, ViewData.ModelState, Model.SummaryLink, Model.FurtherVacancyDetailsViewModel.WorkingWeekComment)));

            
            #line default
            #line hidden
            
            #line 22 "..\..\Views\Shared\DisplayTemplates\Vacancy\_WorkingWeekAndWage.cshtml"
                                                                                                                                                                                                                                                              
        }

            
            #line default
            #line hidden
WriteLiteral("    </h3>\r\n    <p");

WriteLiteral(" id=\"vacancy-working-week\"");

WriteLiteral(" itemprop=\"workHours\"");

WriteAttribute("class", Tuple.Create(" class=\"", 1084), Tuple.Create("\"", 1173)
            
            #line 25 "..\..\Views\Shared\DisplayTemplates\Vacancy\_WorkingWeekAndWage.cshtml"
, Tuple.Create(Tuple.Create("", 1092), Tuple.Create<System.Object, System.Int32>(Model.FurtherVacancyDetailsViewModel.WorkingWeek.GetPreserveFormattingCssClass()
            
            #line default
            #line hidden
, 1092), false)
);

WriteLiteral(">");

            
            #line 25 "..\..\Views\Shared\DisplayTemplates\Vacancy\_WorkingWeekAndWage.cshtml"
                                                                                                                                            Write(SFA.Apprenticeships.Web.Common.Framework.HtmlExtensions.EscapeHtmlEncoding(Html, Model.FurtherVacancyDetailsViewModel.WorkingWeek));

            
            #line default
            #line hidden
WriteLiteral("</p>\r\n");

            
            #line 26 "..\..\Views\Shared\DisplayTemplates\Vacancy\_WorkingWeekAndWage.cshtml"
    
            
            #line default
            #line hidden
            
            #line 26 "..\..\Views\Shared\DisplayTemplates\Vacancy\_WorkingWeekAndWage.cshtml"
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

            
            #line 29 "..\..\Views\Shared\DisplayTemplates\Vacancy\_WorkingWeekAndWage.cshtml"
                                                      Write(Model.FurtherVacancyDetailsViewModel.Wage.HoursPerWeek);

            
            #line default
            #line hidden
WriteLiteral("</p>\r\n");

            
            #line 30 "..\..\Views\Shared\DisplayTemplates\Vacancy\_WorkingWeekAndWage.cshtml"
        if (Model.FurtherVacancyDetailsViewModel.Wage.HoursPerWeek > 40)
        {

            
            #line default
            #line hidden
WriteLiteral("            <p>(the hours are based on the candidate being over 18)</p>\r\n");

            
            #line 33 "..\..\Views\Shared\DisplayTemplates\Vacancy\_WorkingWeekAndWage.cshtml"
        }
    }

            
            #line default
            #line hidden
WriteLiteral("    ");

            
            #line 35 "..\..\Views\Shared\DisplayTemplates\Vacancy\_WorkingWeekAndWage.cshtml"
Write(Html.Partial(EditLinkViewModel.PartialView, Html.GetEditLinkViewModel(Model, m => m.FurtherVacancyDetailsViewModel.WorkingWeek, Model.SummaryLink, Model.FurtherVacancyDetailsViewModel.WorkingWeekComment)));

            
            #line default
            #line hidden
WriteLiteral("\r\n</div>\r\n\r\n");

            
            #line 38 "..\..\Views\Shared\DisplayTemplates\Vacancy\_WorkingWeekAndWage.cshtml"
 if (Model.VacancyType == SFA.Apprenticeships.Domain.Entities.Raa.Vacancies.VacancyType.Apprenticeship)
{

            
            #line default
            #line hidden
WriteLiteral("    <div");

WriteAttribute("class", Tuple.Create(" class=\"", 2198), Tuple.Create("\"", 2224)
            
            #line 40 "..\..\Views\Shared\DisplayTemplates\Vacancy\_WorkingWeekAndWage.cshtml"
, Tuple.Create(Tuple.Create("", 2206), Tuple.Create<System.Object, System.Int32>(editableItemClass
            
            #line default
            #line hidden
, 2206), false)
);

WriteLiteral(">\r\n        <h3");

WriteLiteral(" class=\"bold-small\"");

WriteLiteral(">\r\n");

            
            #line 42 "..\..\Views\Shared\DisplayTemplates\Vacancy\_WorkingWeekAndWage.cshtml"
            
            
            #line default
            #line hidden
            
            #line 42 "..\..\Views\Shared\DisplayTemplates\Vacancy\_WorkingWeekAndWage.cshtml"
             if (Model.FurtherVacancyDetailsViewModel.Wage.Classification == WageClassification.Custom)
            {

            
            #line default
            #line hidden
WriteLiteral("                <span");

WriteLiteral(" id=\"furthervacancydetailsviewmodel_wage_amount\"");

WriteLiteral(">\r\n");

WriteLiteral("                    ");

            
            #line 45 "..\..\Views\Shared\DisplayTemplates\Vacancy\_WorkingWeekAndWage.cshtml"
               Write(Model.FurtherVacancyDetailsViewModel.Wage.Unit.GetHeaderDisplayText());

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("                    ");

            
            #line 46 "..\..\Views\Shared\DisplayTemplates\Vacancy\_WorkingWeekAndWage.cshtml"
               Write(Html.Partial(ValidationResultViewModel.PartialView, Html.GetValidationResultViewModel(Model, m => m.FurtherVacancyDetailsViewModel.Wage.Type, ViewData.ModelState, Model.SummaryLink, Model.FurtherVacancyDetailsViewModel.WageComment)));

            
            #line default
            #line hidden
WriteLiteral("\r\n                </span>\r\n");

            
            #line 48 "..\..\Views\Shared\DisplayTemplates\Vacancy\_WorkingWeekAndWage.cshtml"
            }
            else
            {

            
            #line default
            #line hidden
WriteLiteral("                <span>\r\n                    Weekly wage\r\n");

WriteLiteral("                    ");

            
            #line 53 "..\..\Views\Shared\DisplayTemplates\Vacancy\_WorkingWeekAndWage.cshtml"
               Write(Html.Partial(ValidationResultViewModel.PartialView, Html.GetValidationResultViewModel(Model, m => m.FurtherVacancyDetailsViewModel.Wage.Type, ViewData.ModelState, Model.SummaryLink, Model.FurtherVacancyDetailsViewModel.WageComment)));

            
            #line default
            #line hidden
WriteLiteral("\r\n                </span>\r\n");

            
            #line 55 "..\..\Views\Shared\DisplayTemplates\Vacancy\_WorkingWeekAndWage.cshtml"
            }

            
            #line default
            #line hidden
WriteLiteral("        </h3>\r\n        <p");

WriteLiteral(" id=\"vacancy-wage\"");

WriteLiteral(">");

            
            #line 57 "..\..\Views\Shared\DisplayTemplates\Vacancy\_WorkingWeekAndWage.cshtml"
                        Write(WagePresenter.GetDisplayAmount(Model.FurtherVacancyDetailsViewModel.Wage.Type, Model.FurtherVacancyDetailsViewModel.Wage.Amount, Model.FurtherVacancyDetailsViewModel.Wage.AmountLowerBound, Model.FurtherVacancyDetailsViewModel.Wage.AmountUpperBound, Model.FurtherVacancyDetailsViewModel.Wage.Text, Model.FurtherVacancyDetailsViewModel.Wage.HoursPerWeek, Model.FurtherVacancyDetailsViewModel.VacancyDatesViewModel.PossibleStartDate.Date));

            
            #line default
            #line hidden
WriteLiteral("</p>\r\n");

            
            #line 58 "..\..\Views\Shared\DisplayTemplates\Vacancy\_WorkingWeekAndWage.cshtml"
        
            
            #line default
            #line hidden
            
            #line 58 "..\..\Views\Shared\DisplayTemplates\Vacancy\_WorkingWeekAndWage.cshtml"
         if (Model.FurtherVacancyDetailsViewModel.Wage.Classification == WageClassification.PresetText
            && Model.IsManageReviewerView)
        {

            
            #line default
            #line hidden
WriteLiteral("            <div");

WriteLiteral(" class=\"wage-reason-display\"");

WriteLiteral(">");

            
            #line 61 "..\..\Views\Shared\DisplayTemplates\Vacancy\_WorkingWeekAndWage.cshtml"
                                        Write(Model.FurtherVacancyDetailsViewModel.Wage.WageTypeReason);

            
            #line default
            #line hidden
WriteLiteral("</div>\r\n");

            
            #line 62 "..\..\Views\Shared\DisplayTemplates\Vacancy\_WorkingWeekAndWage.cshtml"
        }

            
            #line default
            #line hidden
WriteLiteral("        ");

            
            #line 63 "..\..\Views\Shared\DisplayTemplates\Vacancy\_WorkingWeekAndWage.cshtml"
   Write(Html.Partial(EditLinkViewModel.PartialView, Html.GetEditLinkViewModel(Model, m => m.FurtherVacancyDetailsViewModel.Wage.Type, Model.SummaryLink, Model.FurtherVacancyDetailsViewModel.WageComment)));

            
            #line default
            #line hidden
WriteLiteral("\r\n    </div>\r\n");

            
            #line 65 "..\..\Views\Shared\DisplayTemplates\Vacancy\_WorkingWeekAndWage.cshtml"

    var possibleStartDate = Model.FurtherVacancyDetailsViewModel.VacancyDatesViewModel.PossibleStartDate.Date;

    if (Model.FurtherVacancyDetailsViewModel.Wage.Type == WageType.ApprenticeshipMinimum)
    {
        
            
            #line default
            #line hidden
            
            #line 70 "..\..\Views\Shared\DisplayTemplates\Vacancy\_WorkingWeekAndWage.cshtml"
   Write(Html.Partial("_ApprenticeMinimumWageExplained", possibleStartDate));

            
            #line default
            #line hidden
            
            #line 70 "..\..\Views\Shared\DisplayTemplates\Vacancy\_WorkingWeekAndWage.cshtml"
                                                                           
    }

    if (Model.FurtherVacancyDetailsViewModel.Wage.Type == WageType.NationalMinimum)
    {
        
            
            #line default
            #line hidden
            
            #line 75 "..\..\Views\Shared\DisplayTemplates\Vacancy\_WorkingWeekAndWage.cshtml"
   Write(Html.Partial("_NationalMinimumWageExplained", possibleStartDate));

            
            #line default
            #line hidden
            
            #line 75 "..\..\Views\Shared\DisplayTemplates\Vacancy\_WorkingWeekAndWage.cshtml"
                                                                         
    }
}
            
            #line default
            #line hidden
        }
    }
}
#pragma warning restore 1591
