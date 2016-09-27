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
    
    #line 1 "..\..\Views\Shared\DisplayTemplates\Vacancy\_TrainingProvider.cshtml"
    using SFA.Apprenticeships.Domain.Entities.Raa.Vacancies;
    
    #line default
    #line hidden
    using SFA.Apprenticeships.Infrastructure.Presentation;
    using SFA.Apprenticeships.Web.Common.Constants;
    using SFA.Apprenticeships.Web.Common.Framework;
    using SFA.Apprenticeships.Web.Common.Models.Common;
    using SFA.Apprenticeships.Web.Raa.Common;
    
    #line 2 "..\..\Views\Shared\DisplayTemplates\Vacancy\_TrainingProvider.cshtml"
    using SFA.Apprenticeships.Web.Raa.Common.Extensions;
    
    #line default
    #line hidden
    
    #line 3 "..\..\Views\Shared\DisplayTemplates\Vacancy\_TrainingProvider.cshtml"
    using SFA.Apprenticeships.Web.Raa.Common.ViewModels.Vacancy;
    
    #line default
    #line hidden
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/Shared/DisplayTemplates/Vacancy/_TrainingProvider.cshtml")]
    public partial class TrainingProvider : System.Web.Mvc.WebViewPage<VacancyViewModel>
    {
        public TrainingProvider()
        {
        }
        public override void Execute()
        {
            
            #line 6 "..\..\Views\Shared\DisplayTemplates\Vacancy\_TrainingProvider.cshtml"
  
    var editableItemClass = ViewData["editableItemClass"];

            
            #line default
            #line hidden
WriteLiteral("\r\n\r\n");

            
            #line 10 "..\..\Views\Shared\DisplayTemplates\Vacancy\_TrainingProvider.cshtml"
 if (Model.VacancyType == VacancyType.Apprenticeship)
{

            
            #line default
            #line hidden
WriteLiteral("    <section");

WriteLiteral(" class=\"section-border grid-wrapper\"");

WriteLiteral(" id=\"provider-info\"");

WriteLiteral(">\r\n        <h2");

WriteLiteral(" class=\"heading-large\"");

WriteLiteral(">Training provider</h2>\r\n        <div");

WriteLiteral(" class=\"grid grid-2-3\"");

WriteLiteral(">\r\n            <div");

WriteLiteral(" class=\"inner-block-padr\"");

WriteLiteral(">\r\n                <div");

WriteLiteral(" class=\"text\"");

WriteLiteral(">\r\n                    <div");

WriteAttribute("class", Tuple.Create(" class=\"", 597), Tuple.Create("\"", 623)
            
            #line 17 "..\..\Views\Shared\DisplayTemplates\Vacancy\_TrainingProvider.cshtml"
, Tuple.Create(Tuple.Create("", 605), Tuple.Create<System.Object, System.Int32>(editableItemClass
            
            #line default
            #line hidden
, 605), false)
);

WriteLiteral(">\r\n");

            
            #line 18 "..\..\Views\Shared\DisplayTemplates\Vacancy\_TrainingProvider.cshtml"
                        
            
            #line default
            #line hidden
            
            #line 18 "..\..\Views\Shared\DisplayTemplates\Vacancy\_TrainingProvider.cshtml"
                         if (!Model.IsCandidateView)
                        {

            
            #line default
            #line hidden
WriteLiteral("                            <h3");

WriteLiteral(" class=\"heading-small\"");

WriteLiteral(">\r\n                                Training to be provided\r\n");

WriteLiteral("                                ");

            
            #line 22 "..\..\Views\Shared\DisplayTemplates\Vacancy\_TrainingProvider.cshtml"
                           Write(Html.Partial(CommentViewModel.PartialIconView, Html.GetCommentViewModel(Model, m => m.TrainingDetailsViewModel.TrainingProvided, Model.TrainingDetailsViewModel.TrainingProvidedComment, Model.TrainingDetailsLink)));

            
            #line default
            #line hidden
WriteLiteral("\r\n                            </h3>\r\n");

            
            #line 24 "..\..\Views\Shared\DisplayTemplates\Vacancy\_TrainingProvider.cshtml"
                        }

            
            #line default
            #line hidden
WriteLiteral("                        ");

            
            #line 25 "..\..\Views\Shared\DisplayTemplates\Vacancy\_TrainingProvider.cshtml"
                         if (string.IsNullOrEmpty(Model.TrainingDetailsViewModel.TrainingProvided))
                        {

            
            #line default
            #line hidden
WriteLiteral("                            <span>None specified. This message will not appear on" +
" the vacancy when it goes live</span>\r\n");

            
            #line 28 "..\..\Views\Shared\DisplayTemplates\Vacancy\_TrainingProvider.cshtml"
                        }
                        else
                        {

            
            #line default
            #line hidden
WriteLiteral("                            <p");

WriteLiteral(" id=\"vacancy-training-to-be-provided\"");

WriteAttribute("class", Tuple.Create(" class=\"", 1529), Tuple.Create("\"", 1617)
            
            #line 31 "..\..\Views\Shared\DisplayTemplates\Vacancy\_TrainingProvider.cshtml"
, Tuple.Create(Tuple.Create("", 1537), Tuple.Create<System.Object, System.Int32>(Model.TrainingDetailsViewModel.TrainingProvided.GetPreserveFormattingCssClass()
            
            #line default
            #line hidden
, 1537), false)
);

WriteLiteral(">");

            
            #line 31 "..\..\Views\Shared\DisplayTemplates\Vacancy\_TrainingProvider.cshtml"
                                                                                                                                                        Write(Html.Raw(SFA.Apprenticeships.Web.Common.Framework.HtmlExtensions.HtmlRawEscaped(Model.TrainingDetailsViewModel.TrainingProvided)));

            
            #line default
            #line hidden
WriteLiteral("</p>\r\n");

            
            #line 32 "..\..\Views\Shared\DisplayTemplates\Vacancy\_TrainingProvider.cshtml"
                        }

            
            #line default
            #line hidden
WriteLiteral("                        ");

            
            #line 33 "..\..\Views\Shared\DisplayTemplates\Vacancy\_TrainingProvider.cshtml"
                   Write(Html.Partial(EditLinkViewModel.PartialView, Html.GetEditLinkViewModel(Model, m => m.TrainingDetailsViewModel.TrainingProvided, Model.TrainingDetailsLink, Model.TrainingDetailsViewModel.TrainingProvidedComment)));

            
            #line default
            #line hidden
WriteLiteral("\r\n                    </div>\r\n                    <div");

WriteAttribute("class", Tuple.Create(" class=\"", 2071), Tuple.Create("\"", 2097)
            
            #line 35 "..\..\Views\Shared\DisplayTemplates\Vacancy\_TrainingProvider.cshtml"
, Tuple.Create(Tuple.Create("", 2079), Tuple.Create<System.Object, System.Int32>(editableItemClass
            
            #line default
            #line hidden
, 2079), false)
);

WriteLiteral(">\r\n");

            
            #line 36 "..\..\Views\Shared\DisplayTemplates\Vacancy\_TrainingProvider.cshtml"
                        
            
            #line default
            #line hidden
            
            #line 36 "..\..\Views\Shared\DisplayTemplates\Vacancy\_TrainingProvider.cshtml"
                         if (Model.TrainingDetailsViewModel.TrainingType == TrainingType.Frameworks)
                        {

            
            #line default
            #line hidden
WriteLiteral("                            <h3");

WriteLiteral(" class=\"heading-small\"");

WriteLiteral(">\r\n                                Apprenticeship framework\r\n");

WriteLiteral("                                ");

            
            #line 40 "..\..\Views\Shared\DisplayTemplates\Vacancy\_TrainingProvider.cshtml"
                           Write(Html.Partial(CommentViewModel.PartialIconView, Html.GetCommentViewModel(Model, m => m.TrainingDetailsViewModel.FrameworkCodeName, Model.TrainingDetailsViewModel.FrameworkCodeNameComment, Model.TrainingDetailsLink)));

            
            #line default
            #line hidden
WriteLiteral("\r\n                            </h3>\r\n");

WriteLiteral("                            <p");

WriteLiteral(" id=\"vacancy-framework\"");

WriteLiteral(">");

            
            #line 42 "..\..\Views\Shared\DisplayTemplates\Vacancy\_TrainingProvider.cshtml"
                                                 Write(Html.Raw(Model.FrameworkName));

            
            #line default
            #line hidden
WriteLiteral("</p>\r\n");

            
            #line 43 "..\..\Views\Shared\DisplayTemplates\Vacancy\_TrainingProvider.cshtml"
                            
            
            #line default
            #line hidden
            
            #line 43 "..\..\Views\Shared\DisplayTemplates\Vacancy\_TrainingProvider.cshtml"
                       Write(Html.Partial(EditLinkViewModel.PartialView, Html.GetEditLinkViewModel(Model, m => m.TrainingDetailsViewModel.FrameworkCodeName, Model.TrainingDetailsLink, Model.TrainingDetailsViewModel.FrameworkCodeNameComment)));

            
            #line default
            #line hidden
            
            #line 43 "..\..\Views\Shared\DisplayTemplates\Vacancy\_TrainingProvider.cshtml"
                                                                                                                                                                                                                                                 
                        }

            
            #line default
            #line hidden
WriteLiteral("                        ");

            
            #line 45 "..\..\Views\Shared\DisplayTemplates\Vacancy\_TrainingProvider.cshtml"
                         if (Model.TrainingDetailsViewModel.TrainingType == TrainingType.Standards)
                        {

            
            #line default
            #line hidden
WriteLiteral("                            <h3");

WriteLiteral(" class=\"heading-small\"");

WriteLiteral(">\r\n                                Apprenticeship standard\r\n");

WriteLiteral("                                ");

            
            #line 49 "..\..\Views\Shared\DisplayTemplates\Vacancy\_TrainingProvider.cshtml"
                           Write(Html.Partial(CommentViewModel.PartialIconView, Html.GetCommentViewModel(Model, m => m.TrainingDetailsViewModel.StandardId, Model.TrainingDetailsViewModel.StandardIdComment, Model.TrainingDetailsLink)));

            
            #line default
            #line hidden
WriteLiteral("\r\n                            </h3>\r\n");

WriteLiteral("                            <p");

WriteLiteral(" id=\"vacancy-standard\"");

WriteLiteral(">");

            
            #line 51 "..\..\Views\Shared\DisplayTemplates\Vacancy\_TrainingProvider.cshtml"
                                                Write(Html.Raw(Model.StandardName));

            
            #line default
            #line hidden
WriteLiteral("</p>\r\n");

            
            #line 52 "..\..\Views\Shared\DisplayTemplates\Vacancy\_TrainingProvider.cshtml"
                            
            
            #line default
            #line hidden
            
            #line 52 "..\..\Views\Shared\DisplayTemplates\Vacancy\_TrainingProvider.cshtml"
                       Write(Html.Partial(EditLinkViewModel.PartialView, Html.GetEditLinkViewModel(Model, m => m.TrainingDetailsViewModel.StandardId, Model.TrainingDetailsLink, Model.TrainingDetailsViewModel.StandardIdComment)));

            
            #line default
            #line hidden
            
            #line 52 "..\..\Views\Shared\DisplayTemplates\Vacancy\_TrainingProvider.cshtml"
                                                                                                                                                                                                                                   
                        }

            
            #line default
            #line hidden
WriteLiteral("                    </div>\r\n                </div>\r\n            </div>\r\n        <" +
"/div>\r\n        <div");

WriteLiteral(" class=\"grid grid-1-3\"");

WriteLiteral(">\r\n            <div");

WriteLiteral(" class=\"text\"");

WriteLiteral(">\r\n                <h3");

WriteLiteral(" class=\"bold-small\"");

WriteLiteral(">Training provider</h3>\r\n                <p");

WriteLiteral(" id=\"vacancy-provider-name\"");

WriteLiteral(">");

            
            #line 61 "..\..\Views\Shared\DisplayTemplates\Vacancy\_TrainingProvider.cshtml"
                                         Write(Model.Provider.ProviderName);

            
            #line default
            #line hidden
WriteLiteral("</p>\r\n            </div>\r\n\r\n            <div");

WriteAttribute("class", Tuple.Create(" class=\"", 4181), Tuple.Create("\"", 4212)
, Tuple.Create(Tuple.Create("", 4189), Tuple.Create("text", 4189), true)
            
            #line 64 "..\..\Views\Shared\DisplayTemplates\Vacancy\_TrainingProvider.cshtml"
, Tuple.Create(Tuple.Create(" ", 4193), Tuple.Create<System.Object, System.Int32>(editableItemClass
            
            #line default
            #line hidden
, 4194), false)
);

WriteLiteral(">\r\n                <h3");

WriteLiteral(" class=\"bold-small\"");

WriteLiteral(">\r\n                    Contact\r\n");

WriteLiteral("                    ");

            
            #line 67 "..\..\Views\Shared\DisplayTemplates\Vacancy\_TrainingProvider.cshtml"
               Write(Html.Partial(CommentViewModel.PartialIconView, Html.GetCommentViewModel(Model, m => m.TrainingDetailsViewModel.ContactName, Model.TrainingDetailsViewModel.ContactDetailsComment, Model.TrainingDetailsLink)));

            
            #line default
            #line hidden
WriteLiteral("\r\n                </h3>\r\n");

            
            #line 69 "..\..\Views\Shared\DisplayTemplates\Vacancy\_TrainingProvider.cshtml"
                
            
            #line default
            #line hidden
            
            #line 69 "..\..\Views\Shared\DisplayTemplates\Vacancy\_TrainingProvider.cshtml"
                 if (string.IsNullOrEmpty(Model.TrainingDetailsViewModel.ContactName) && string.IsNullOrEmpty(Model.TrainingDetailsViewModel.ContactNumber) && string.IsNullOrEmpty(Model.TrainingDetailsViewModel.ContactEmail))
                {

            
            #line default
            #line hidden
WriteLiteral("                    <span>None specified. This message will not appear on the vac" +
"ancy when it goes live</span>\r\n");

            
            #line 72 "..\..\Views\Shared\DisplayTemplates\Vacancy\_TrainingProvider.cshtml"
                }
                else
                {

            
            #line default
            #line hidden
WriteLiteral("                    <p");

WriteLiteral(" class=\"small-btm-margin\"");

WriteLiteral(">");

            
            #line 75 "..\..\Views\Shared\DisplayTemplates\Vacancy\_TrainingProvider.cshtml"
                                           Write(Model.TrainingDetailsViewModel.ContactName);

            
            #line default
            #line hidden
WriteLiteral("</p>\r\n");

WriteLiteral("                    <p");

WriteLiteral(" class=\"small-btm-margin\"");

WriteLiteral(">");

            
            #line 76 "..\..\Views\Shared\DisplayTemplates\Vacancy\_TrainingProvider.cshtml"
                                           Write(Model.TrainingDetailsViewModel.ContactNumber);

            
            #line default
            #line hidden
WriteLiteral("</p>\r\n");

WriteLiteral("                    <p");

WriteLiteral(" class=\"small-btm-margin\"");

WriteLiteral(">");

            
            #line 77 "..\..\Views\Shared\DisplayTemplates\Vacancy\_TrainingProvider.cshtml"
                                           Write(Model.TrainingDetailsViewModel.ContactEmail);

            
            #line default
            #line hidden
WriteLiteral("</p>\r\n");

            
            #line 78 "..\..\Views\Shared\DisplayTemplates\Vacancy\_TrainingProvider.cshtml"
                }

            
            #line default
            #line hidden
WriteLiteral("                ");

            
            #line 79 "..\..\Views\Shared\DisplayTemplates\Vacancy\_TrainingProvider.cshtml"
           Write(Html.Partial(EditLinkViewModel.PartialView, Html.GetEditLinkViewModel(Model, m => m.TrainingDetailsViewModel.ContactName, Model.TrainingDetailsLink, Model.TrainingDetailsViewModel.ContactDetailsComment)));

            
            #line default
            #line hidden
WriteLiteral("\r\n            </div>\r\n        </div>\r\n    </section>\r\n");

            
            #line 83 "..\..\Views\Shared\DisplayTemplates\Vacancy\_TrainingProvider.cshtml"
}
            
            #line default
            #line hidden
        }
    }
}
#pragma warning restore 1591
