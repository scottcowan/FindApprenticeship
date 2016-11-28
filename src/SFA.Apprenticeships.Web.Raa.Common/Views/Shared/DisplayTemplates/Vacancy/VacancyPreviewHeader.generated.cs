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
    
    #line 7 "..\..\Views\Shared\DisplayTemplates\Vacancy\VacancyPreviewHeader.cshtml"
    using HtmlExtensions = SFA.Apprenticeships.Web.Common.Framework.HtmlExtensions;
    
    #line default
    #line hidden
    
    #line 3 "..\..\Views\Shared\DisplayTemplates\Vacancy\VacancyPreviewHeader.cshtml"
    using SFA.Apprenticeships.Domain.Entities.Raa.Vacancies;
    
    #line default
    #line hidden
    
    #line 4 "..\..\Views\Shared\DisplayTemplates\Vacancy\VacancyPreviewHeader.cshtml"
    using SFA.Apprenticeships.Infrastructure.Presentation;
    
    #line default
    #line hidden
    using SFA.Apprenticeships.Web.Common.Constants;
    using SFA.Apprenticeships.Web.Common.Framework;
    using SFA.Apprenticeships.Web.Common.Models.Common;
    using SFA.Apprenticeships.Web.Raa.Common;
    
    #line 5 "..\..\Views\Shared\DisplayTemplates\Vacancy\VacancyPreviewHeader.cshtml"
    using SFA.Apprenticeships.Web.Raa.Common.Extensions;
    
    #line default
    #line hidden
    
    #line 6 "..\..\Views\Shared\DisplayTemplates\Vacancy\VacancyPreviewHeader.cshtml"
    using SFA.Apprenticeships.Web.Raa.Common.ViewModels.Vacancy;
    
    #line default
    #line hidden
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/Shared/DisplayTemplates/Vacancy/VacancyPreviewHeader.cshtml")]
    public partial class VacancyPreviewHeader : System.Web.Mvc.WebViewPage<VacancyViewModel>
    {
        public VacancyPreviewHeader()
        {
        }
        public override void Execute()
        {
WriteLiteral("\r\n");

            
            #line 9 "..\..\Views\Shared\DisplayTemplates\Vacancy\VacancyPreviewHeader.cshtml"
  
    var editableItemClass = Model.IsEditable ? "editable-item" : "";

            
            #line default
            #line hidden
WriteLiteral("\r\n\r\n<section>\r\n    <div");

WriteLiteral(" class=\"grid-row\"");

WriteLiteral(">\r\n        <div");

WriteLiteral(" class=\"column-two-thirds\"");

WriteLiteral(">\r\n            <h1");

WriteLiteral(" id=\"heading\"");

WriteLiteral(" class=\"heading-xlarge\"");

WriteLiteral(">\r\n");

            
            #line 17 "..\..\Views\Shared\DisplayTemplates\Vacancy\VacancyPreviewHeader.cshtml"
                
            
            #line default
            #line hidden
            
            #line 17 "..\..\Views\Shared\DisplayTemplates\Vacancy\VacancyPreviewHeader.cshtml"
                 if (Model.VacancyType == VacancyType.Traineeship)
                {

            
            #line default
            #line hidden
WriteLiteral("                    <span>Opportunity preview</span>\r\n");

            
            #line 20 "..\..\Views\Shared\DisplayTemplates\Vacancy\VacancyPreviewHeader.cshtml"
                }
                else
                {

            
            #line default
            #line hidden
WriteLiteral("                    <span>Vacancy preview</span>\r\n");

            
            #line 24 "..\..\Views\Shared\DisplayTemplates\Vacancy\VacancyPreviewHeader.cshtml"
                }

            
            #line default
            #line hidden
WriteLiteral("            </h1>\r\n        </div>\r\n        <div");

WriteLiteral(" class=\"column-one-third\"");

WriteLiteral(" style=\"float: right\"");

WriteLiteral(">            \r\n");

            
            #line 28 "..\..\Views\Shared\DisplayTemplates\Vacancy\VacancyPreviewHeader.cshtml"
            
            
            #line default
            #line hidden
            
            #line 28 "..\..\Views\Shared\DisplayTemplates\Vacancy\VacancyPreviewHeader.cshtml"
             if (Model.Mode == VacancyViewModel.BulkUploadMode)
            {
                
            
            #line default
            #line hidden
            
            #line 30 "..\..\Views\Shared\DisplayTemplates\Vacancy\VacancyPreviewHeader.cshtml"
           Write(Html.Partial("DisplayTemplates/_BulkUploadVacancyLinks", new VacancyLinksViewModel(Model.VacancyReferenceNumber, Model.Status, Model.ApplicationCount, Model.VacancyType, Model.ApplicationPendingDecisionCount)));

            
            #line default
            #line hidden
            
            #line 30 "..\..\Views\Shared\DisplayTemplates\Vacancy\VacancyPreviewHeader.cshtml"
                                                                                                                                                                                                                                  
            }
            else
            {
                
            
            #line default
            #line hidden
            
            #line 34 "..\..\Views\Shared\DisplayTemplates\Vacancy\VacancyPreviewHeader.cshtml"
           Write(Html.Partial(ContactDetailsAndVacancyHistoryViewModel.PartialView, Model.ContactDetailsAndVacancyHistory ?? ContactDetailsAndVacancyHistoryViewModel.EmptyContactDetailsAndVacancyHistory));

            
            #line default
            #line hidden
            
            #line 34 "..\..\Views\Shared\DisplayTemplates\Vacancy\VacancyPreviewHeader.cshtml"
                                                                                                                                                                                                           
                
            
            #line default
            #line hidden
            
            #line 35 "..\..\Views\Shared\DisplayTemplates\Vacancy\VacancyPreviewHeader.cshtml"
           Write(Html.Partial(VacancyLinksViewModel.PartialView, new VacancyLinksViewModel(Model.VacancyReferenceNumber, Model.Status, Model.ApplicationCount, Model.VacancyType, Model.ApplicationPendingDecisionCount)));

            
            #line default
            #line hidden
            
            #line 35 "..\..\Views\Shared\DisplayTemplates\Vacancy\VacancyPreviewHeader.cshtml"
                                                                                                                                                                                                                         
            }

            
            #line default
            #line hidden
WriteLiteral("        </div>\r\n        <div");

WriteLiteral(" class=\"column-two-thirds\"");

WriteLiteral(" style=\"clear: left\"");

WriteLiteral(">\r\n            <div");

WriteAttribute("class", Tuple.Create(" class=\"", 1819), Tuple.Create("\"", 1857)
, Tuple.Create(Tuple.Create("", 1827), Tuple.Create("hgroup", 1827), true)
, Tuple.Create(Tuple.Create(" ", 1833), Tuple.Create("text", 1834), true)
            
            #line 39 "..\..\Views\Shared\DisplayTemplates\Vacancy\VacancyPreviewHeader.cshtml"
, Tuple.Create(Tuple.Create(" ", 1838), Tuple.Create<System.Object, System.Int32>(editableItemClass
            
            #line default
            #line hidden
, 1839), false)
);

WriteLiteral(">\r\n                <h1");

WriteLiteral(" class=\"heading-xlarge\"");

WriteLiteral(" id=\"vacancy-title\"");

WriteLiteral(" itemprop=\"title\"");

WriteLiteral(">\r\n");

WriteLiteral("                    ");

            
            #line 41 "..\..\Views\Shared\DisplayTemplates\Vacancy\VacancyPreviewHeader.cshtml"
               Write(HtmlExtensions.EscapeHtmlEncoding(Html, Model.VacancyType.GetTitle(Model.NewVacancyViewModel.Title)));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("                    ");

            
            #line 42 "..\..\Views\Shared\DisplayTemplates\Vacancy\VacancyPreviewHeader.cshtml"
               Write(Html.Partial(CommentViewModel.PartialIconView, Html.GetCommentViewModel(Model, m => m.NewVacancyViewModel.Title, Model.NewVacancyViewModel.TitleComment, Model.BasicDetailsLink)));

            
            #line default
            #line hidden
WriteLiteral("\r\n                    <p");

WriteLiteral(" class=\"heading-secondary \"");

WriteLiteral(" id=\"vacancy-subtitle-employer-name\"");

WriteLiteral(" itemprop=\"hiringOrganization\"");

WriteLiteral(">");

            
            #line 43 "..\..\Views\Shared\DisplayTemplates\Vacancy\VacancyPreviewHeader.cshtml"
                                                                                                               Write(Model.NewVacancyViewModel.VacancyOwnerRelationship.Employer.FullName);

            
            #line default
            #line hidden
WriteLiteral("</p>\r\n                </h1>\r\n");

            
            #line 45 "..\..\Views\Shared\DisplayTemplates\Vacancy\VacancyPreviewHeader.cshtml"
                
            
            #line default
            #line hidden
            
            #line 45 "..\..\Views\Shared\DisplayTemplates\Vacancy\VacancyPreviewHeader.cshtml"
                 if (Model.IsManageReviewerView && Model.NewVacancyViewModel.VacancyOwnerRelationship.IsAnonymousEmployer != null
                && Model.NewVacancyViewModel.VacancyOwnerRelationship.IsAnonymousEmployer.Value)
                {

            
            #line default
            #line hidden
WriteLiteral("                    <p");

WriteLiteral(" class=\"subtitle\"");

WriteLiteral(" id=\"vacancy-subtitle-employer-name\"");

WriteLiteral(" itemprop=\"hiringOrganization\"");

WriteLiteral(">");

            
            #line 48 "..\..\Views\Shared\DisplayTemplates\Vacancy\VacancyPreviewHeader.cshtml"
                                                                                                     Write(Model.NewVacancyViewModel.VacancyOwnerRelationship.Employer.FullName);

            
            #line default
            #line hidden
WriteLiteral(" (");

            
            #line 48 "..\..\Views\Shared\DisplayTemplates\Vacancy\VacancyPreviewHeader.cshtml"
                                                                                                                                                                            Write(Model.NewVacancyViewModel.VacancyOwnerRelationship.OriginalFullName);

            
            #line default
            #line hidden
WriteLiteral(" - Set as Anonymous)</p>\r\n");

            
            #line 49 "..\..\Views\Shared\DisplayTemplates\Vacancy\VacancyPreviewHeader.cshtml"
                }
                else
                {
                }

            
            #line default
            #line hidden
WriteLiteral("                ");

            
            #line 53 "..\..\Views\Shared\DisplayTemplates\Vacancy\VacancyPreviewHeader.cshtml"
           Write(Html.Partial(EditLinkViewModel.PartialView, Html.GetEditLinkViewModel(Model, m => m.NewVacancyViewModel.Title, Model.BasicDetailsLink, Model.NewVacancyViewModel.TitleComment)));

            
            #line default
            #line hidden
WriteLiteral("\r\n            </div>\r\n        </div>\r\n    </div>\r\n</section>\r\n\r\n\r\n\r\n\r\n\r\n<section>" +
"\r\n    <div");

WriteLiteral(" class=\"grid-row\"");

WriteLiteral(">\r\n        <div");

WriteLiteral(" class=\"column-two-thirds\"");

WriteLiteral(">\r\n            <div");

WriteLiteral(" class=\"inner-block-padr\"");

WriteLiteral(">\r\n                <div");

WriteAttribute("class", Tuple.Create(" class=\"", 3485), Tuple.Create("\"", 3511)
            
            #line 67 "..\..\Views\Shared\DisplayTemplates\Vacancy\VacancyPreviewHeader.cshtml"
, Tuple.Create(Tuple.Create("", 3493), Tuple.Create<System.Object, System.Int32>(editableItemClass
            
            #line default
            #line hidden
, 3493), false)
);

WriteLiteral(">\r\n                    <h3");

WriteLiteral(" class=\"bold-small\"");

WriteLiteral(">\r\n");

            
            #line 69 "..\..\Views\Shared\DisplayTemplates\Vacancy\VacancyPreviewHeader.cshtml"
                        
            
            #line default
            #line hidden
            
            #line 69 "..\..\Views\Shared\DisplayTemplates\Vacancy\VacancyPreviewHeader.cshtml"
                         if (Model.VacancyType == VacancyType.Traineeship)
                        {

            
            #line default
            #line hidden
WriteLiteral("                            <span>Summary</span>\r\n");

            
            #line 72 "..\..\Views\Shared\DisplayTemplates\Vacancy\VacancyPreviewHeader.cshtml"
                        }
                        else
                        {

            
            #line default
            #line hidden
WriteLiteral("                            <span>Brief overview of the role</span>\r\n");

            
            #line 76 "..\..\Views\Shared\DisplayTemplates\Vacancy\VacancyPreviewHeader.cshtml"
                        }

            
            #line default
            #line hidden
WriteLiteral("                        ");

            
            #line 77 "..\..\Views\Shared\DisplayTemplates\Vacancy\VacancyPreviewHeader.cshtml"
                   Write(Html.Partial(CommentViewModel.PartialIconView, Html.GetCommentViewModel(Model, m => m.NewVacancyViewModel.ShortDescription, Model.NewVacancyViewModel.ShortDescriptionComment, Model.BasicDetailsLink)));

            
            #line default
            #line hidden
WriteLiteral("\r\n                    </h3>\r\n                    <div");

WriteLiteral(" class=\"text\"");

WriteLiteral(" itemprop=\"description\"");

WriteLiteral(">\r\n                        <p");

WriteLiteral(" id=\"vacancy-description\"");

WriteAttribute("class", Tuple.Create(" class=\"", 4260), Tuple.Create("\"", 4343)
            
            #line 80 "..\..\Views\Shared\DisplayTemplates\Vacancy\VacancyPreviewHeader.cshtml"
, Tuple.Create(Tuple.Create("", 4268), Tuple.Create<System.Object, System.Int32>(Model.NewVacancyViewModel.ShortDescription.GetPreserveFormattingCssClass()
            
            #line default
            #line hidden
, 4268), false)
);

WriteLiteral(">");

            
            #line 80 "..\..\Views\Shared\DisplayTemplates\Vacancy\VacancyPreviewHeader.cshtml"
                                                                                                                                    Write(SFA.Apprenticeships.Web.Common.Framework.HtmlExtensions.EscapeHtmlEncoding(Html, Model.NewVacancyViewModel.ShortDescription));

            
            #line default
            #line hidden
WriteLiteral("</p>\r\n");

WriteLiteral("                        ");

            
            #line 81 "..\..\Views\Shared\DisplayTemplates\Vacancy\VacancyPreviewHeader.cshtml"
                   Write(Html.Partial(ApplicationsLinkViewModel.PartialView, new ApplicationsLinkViewModel(Model.VacancyType, Model.VacancyReferenceNumber, Model.ApplicationCount)));

            
            #line default
            #line hidden
WriteLiteral("\r\n                    </div>\r\n");

WriteLiteral("                    ");

            
            #line 83 "..\..\Views\Shared\DisplayTemplates\Vacancy\VacancyPreviewHeader.cshtml"
               Write(Html.Partial(EditLinkViewModel.PartialView, Html.GetEditLinkViewModel(Model, m => m.NewVacancyViewModel.ShortDescription, Model.BasicDetailsLink, Model.NewVacancyViewModel.ShortDescriptionComment)));

            
            #line default
            #line hidden
WriteLiteral("\r\n                </div>\r\n            </div>\r\n        </div>\r\n        <div");

WriteLiteral(" class=\"column-one-third\"");

WriteLiteral(">\r\n            <div");

WriteAttribute("class", Tuple.Create(" class=\"", 5024), Tuple.Create("\"", 5050)
            
            #line 88 "..\..\Views\Shared\DisplayTemplates\Vacancy\VacancyPreviewHeader.cshtml"
, Tuple.Create(Tuple.Create("", 5032), Tuple.Create<System.Object, System.Int32>(editableItemClass
            
            #line default
            #line hidden
, 5032), false)
);

WriteLiteral(">\r\n                <h3");

WriteLiteral(" class=\"bold-small\"");

WriteLiteral(">\r\n                    Closing date\r\n");

WriteLiteral("                    ");

            
            #line 91 "..\..\Views\Shared\DisplayTemplates\Vacancy\VacancyPreviewHeader.cshtml"
               Write(Html.Partial(ValidationResultViewModel.PartialView, Html.GetValidationResultViewModel(Model, m => m.FurtherVacancyDetailsViewModel.VacancyDatesViewModel.ClosingDate, ViewData.ModelState, Model.SummaryLink, Model.FurtherVacancyDetailsViewModel.VacancyDatesViewModel.ClosingDateComment)));

            
            #line default
            #line hidden
WriteLiteral("\r\n                </h3>\r\n                <p");

WriteLiteral(" id=\"vacancy-closing-date\"");

WriteLiteral(">");

            
            #line 93 "..\..\Views\Shared\DisplayTemplates\Vacancy\VacancyPreviewHeader.cshtml"
                                        Write(Model.FurtherVacancyDetailsViewModel.VacancyDatesViewModel.ClosingDate.Date.ToFriendlyClosingToday());

            
            #line default
            #line hidden
WriteLiteral("</p>\r\n");

WriteLiteral("                ");

            
            #line 94 "..\..\Views\Shared\DisplayTemplates\Vacancy\VacancyPreviewHeader.cshtml"
           Write(Html.Partial(EditLinkViewModel.PartialView, Html.GetEditLinkViewModel(Model, m => m.FurtherVacancyDetailsViewModel.VacancyDatesViewModel.ClosingDate, Model.SummaryLink, Model.FurtherVacancyDetailsViewModel.VacancyDatesViewModel.ClosingDateComment)));

            
            #line default
            #line hidden
WriteLiteral("\r\n            </div>\r\n        </div>\r\n    </div>\r\n</section>");

        }
    }
}
#pragma warning restore 1591
