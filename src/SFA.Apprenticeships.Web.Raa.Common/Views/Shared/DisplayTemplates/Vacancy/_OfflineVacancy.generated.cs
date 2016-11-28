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
    
    #line 1 "..\..\Views\Shared\DisplayTemplates\Vacancy\_OfflineVacancy.cshtml"
    using SFA.Apprenticeships.Domain.Entities.Raa.Vacancies;
    
    #line default
    #line hidden
    using SFA.Apprenticeships.Infrastructure.Presentation;
    using SFA.Apprenticeships.Web.Common.Constants;
    using SFA.Apprenticeships.Web.Common.Framework;
    using SFA.Apprenticeships.Web.Common.Models.Common;
    using SFA.Apprenticeships.Web.Raa.Common;
    
    #line 2 "..\..\Views\Shared\DisplayTemplates\Vacancy\_OfflineVacancy.cshtml"
    using SFA.Apprenticeships.Web.Raa.Common.Extensions;
    
    #line default
    #line hidden
    
    #line 3 "..\..\Views\Shared\DisplayTemplates\Vacancy\_OfflineVacancy.cshtml"
    using SFA.Apprenticeships.Web.Raa.Common.ViewModels.Vacancy;
    
    #line default
    #line hidden
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/Shared/DisplayTemplates/Vacancy/_OfflineVacancy.cshtml")]
    public partial class OfflineVacancy : System.Web.Mvc.WebViewPage<VacancyViewModel>
    {
        public OfflineVacancy()
        {
        }
        public override void Execute()
        {
            
            #line 6 "..\..\Views\Shared\DisplayTemplates\Vacancy\_OfflineVacancy.cshtml"
  
    var editableItemClass = ViewData["editableItemClass"];

            
            #line default
            #line hidden
WriteLiteral("\r\n\r\n");

            
            #line 10 "..\..\Views\Shared\DisplayTemplates\Vacancy\_OfflineVacancy.cshtml"
 if (Model.NewVacancyViewModel.OfflineVacancy.Value)
{

            
            #line default
            #line hidden
WriteLiteral("    <section");

WriteLiteral(" class=\"section-border\"");

WriteLiteral(" id=\"offline-vacancy\"");

WriteLiteral(" style=\"\"");

WriteLiteral(">\r\n        <div");

WriteAttribute("class", Tuple.Create(" class=\"", 407), Tuple.Create("\"", 433)
            
            #line 13 "..\..\Views\Shared\DisplayTemplates\Vacancy\_OfflineVacancy.cshtml"
, Tuple.Create(Tuple.Create("", 415), Tuple.Create<System.Object, System.Int32>(editableItemClass
            
            #line default
            #line hidden
, 415), false)
);

WriteLiteral(">\r\n            <h2");

WriteLiteral(" class=\"heading-large\"");

WriteLiteral(">\r\n                Employer\'s application instructions\r\n");

WriteLiteral("                ");

            
            #line 16 "..\..\Views\Shared\DisplayTemplates\Vacancy\_OfflineVacancy.cshtml"
           Write(Html.Partial(CommentViewModel.PartialIconView, Html.GetCommentViewModel(Model, m => m.NewVacancyViewModel.OfflineApplicationInstructions, Model.NewVacancyViewModel.OfflineApplicationInstructionsComment, Model.BasicDetailsLink)));

            
            #line default
            #line hidden
WriteLiteral("\r\n            </h2>\r\n            <p");

WriteLiteral(" id=\"application-instructions\"");

WriteAttribute("class", Tuple.Create(" class=\"", 839), Tuple.Create("\"", 936)
            
            #line 18 "..\..\Views\Shared\DisplayTemplates\Vacancy\_OfflineVacancy.cshtml"
, Tuple.Create(Tuple.Create("", 847), Tuple.Create<System.Object, System.Int32>(Model.NewVacancyViewModel.OfflineApplicationInstructions.GetPreserveFormattingCssClass()
            
            #line default
            #line hidden
, 847), false)
);

WriteLiteral(">");

            
            #line 18 "..\..\Views\Shared\DisplayTemplates\Vacancy\_OfflineVacancy.cshtml"
                                                                                                                                          Write(Model.NewVacancyViewModel.OfflineApplicationInstructions);

            
            #line default
            #line hidden
WriteLiteral("</p>\r\n");

WriteLiteral("            ");

            
            #line 19 "..\..\Views\Shared\DisplayTemplates\Vacancy\_OfflineVacancy.cshtml"
       Write(Html.Partial(EditLinkViewModel.PartialView, Html.GetEditLinkViewModel(Model, m => m.NewVacancyViewModel.OfflineApplicationInstructions, Model.BasicDetailsLink, Model.NewVacancyViewModel.OfflineApplicationInstructionsComment)));

            
            #line default
            #line hidden
WriteLiteral("\r\n        </div>\r\n        <div");

WriteAttribute("class", Tuple.Create(" class=\"", 1269), Tuple.Create("\"", 1304)
            
            #line 21 "..\..\Views\Shared\DisplayTemplates\Vacancy\_OfflineVacancy.cshtml"
, Tuple.Create(Tuple.Create("", 1277), Tuple.Create<System.Object, System.Int32>(editableItemClass
            
            #line default
            #line hidden
, 1277), false)
, Tuple.Create(Tuple.Create(" ", 1295), Tuple.Create("grid-row", 1296), true)
);

WriteLiteral(">\r\n            <p");

WriteLiteral(" class=\"sfa-no-bottom-margin\"");

WriteLiteral(">This apprenticeship requires you to apply through the employer\'s website.</p>\r\n");

            
            #line 23 "..\..\Views\Shared\DisplayTemplates\Vacancy\_OfflineVacancy.cshtml"
            
            
            #line default
            #line hidden
            
            #line 23 "..\..\Views\Shared\DisplayTemplates\Vacancy\_OfflineVacancy.cshtml"
             if (Model.NewVacancyViewModel.OfflineVacancyType == OfflineVacancyType.MultiUrl && Model.NewVacancyViewModel.LocationAddresses != null && Model.NewVacancyViewModel.LocationAddresses.Count > 1)
            {
                var midIndex = (Model.NewVacancyViewModel.LocationAddresses.Count + 1) / 2;

            
            #line default
            #line hidden
WriteLiteral("                <div");

WriteLiteral(" class=\"column-one-half\"");

WriteLiteral(">\r\n                    <div");

WriteLiteral(" class=\"inner-block-padr\"");

WriteLiteral(">\r\n                        <table>\r\n                            <thead>\r\n        " +
"                        <tr>\r\n                                    <th>\r\n        " +
"                                <span");

WriteLiteral(" class=\"heading-span\"");

WriteLiteral(">Location</span>\r\n                                    </th>\r\n                    " +
"            </tr>\r\n                            </thead>\r\n                       " +
"     <tbody>\r\n");

            
            #line 37 "..\..\Views\Shared\DisplayTemplates\Vacancy\_OfflineVacancy.cshtml"
                                
            
            #line default
            #line hidden
            
            #line 37 "..\..\Views\Shared\DisplayTemplates\Vacancy\_OfflineVacancy.cshtml"
                                 for (var i = 0; i < midIndex; i++)
                                {
                                    var locationAddress = Model.NewVacancyViewModel.LocationAddresses[i];

            
            #line default
            #line hidden
WriteLiteral("                                    <tr>\r\n                                       " +
" <td");

WriteLiteral(" class=\"location-address\"");

WriteLiteral(">\r\n");

WriteLiteral("                                            ");

            
            #line 42 "..\..\Views\Shared\DisplayTemplates\Vacancy\_OfflineVacancy.cshtml"
                                       Write(locationAddress.Address.AddressLine1);

            
            #line default
            #line hidden
WriteLiteral("\r\n");

            
            #line 43 "..\..\Views\Shared\DisplayTemplates\Vacancy\_OfflineVacancy.cshtml"
                                            
            
            #line default
            #line hidden
            
            #line 43 "..\..\Views\Shared\DisplayTemplates\Vacancy\_OfflineVacancy.cshtml"
                                             if (!string.IsNullOrWhiteSpace(@locationAddress.Address.AddressLine2))
                                            {

            
            #line default
            #line hidden
WriteLiteral("                                                <br />\r\n");

            
            #line 46 "..\..\Views\Shared\DisplayTemplates\Vacancy\_OfflineVacancy.cshtml"
                                                
            
            #line default
            #line hidden
            
            #line 46 "..\..\Views\Shared\DisplayTemplates\Vacancy\_OfflineVacancy.cshtml"
                                           Write(locationAddress.Address.AddressLine2);

            
            #line default
            #line hidden
            
            #line 46 "..\..\Views\Shared\DisplayTemplates\Vacancy\_OfflineVacancy.cshtml"
                                                                                     
                                            }

            
            #line default
            #line hidden
WriteLiteral("                                            <br />\r\n");

WriteLiteral("                                            ");

            
            #line 49 "..\..\Views\Shared\DisplayTemplates\Vacancy\_OfflineVacancy.cshtml"
                                       Write(locationAddress.Address.AddressLine4);

            
            #line default
            #line hidden
WriteLiteral(" ");

            
            #line 49 "..\..\Views\Shared\DisplayTemplates\Vacancy\_OfflineVacancy.cshtml"
                                                                             Write(locationAddress.Address.Postcode);

            
            #line default
            #line hidden
WriteLiteral("\r\n                                            <br/>\r\n                            " +
"                <a");

WriteAttribute("id", Tuple.Create(" id=", 3263), Tuple.Create("", 3342)
            
            #line 51 "..\..\Views\Shared\DisplayTemplates\Vacancy\_OfflineVacancy.cshtml"
, Tuple.Create(Tuple.Create("", 3267), Tuple.Create<System.Object, System.Int32>("newvacancyviewmodel_locationaddresses_" + i + "__offlineapplicationurl"
            
            #line default
            #line hidden
, 3267), false)
);

WriteLiteral(" rel=\"external\"");

WriteAttribute("href", Tuple.Create(" href=\"", 3357), Tuple.Create("\"", 3402)
            
            #line 51 "..\..\Views\Shared\DisplayTemplates\Vacancy\_OfflineVacancy.cshtml"
                                                                   , Tuple.Create(Tuple.Create("", 3364), Tuple.Create<System.Object, System.Int32>(locationAddress.OfflineApplicationUrl
            
            #line default
            #line hidden
, 3364), false)
);

WriteLiteral(" target=\"_blank\"");

WriteLiteral(">");

            
            #line 51 "..\..\Views\Shared\DisplayTemplates\Vacancy\_OfflineVacancy.cshtml"
                                                                                                                                                                                                      Write(locationAddress.OfflineApplicationUrl);

            
            #line default
            #line hidden
WriteLiteral("</a>\r\n                                        </td>\r\n                            " +
"        </tr>\r\n");

            
            #line 54 "..\..\Views\Shared\DisplayTemplates\Vacancy\_OfflineVacancy.cshtml"
                                }

            
            #line default
            #line hidden
WriteLiteral("                            </tbody>\r\n                        </table>\r\n         " +
"           </div>\r\n                </div>\r\n");

            
            #line 59 "..\..\Views\Shared\DisplayTemplates\Vacancy\_OfflineVacancy.cshtml"


            
            #line default
            #line hidden
WriteLiteral("                <div");

WriteLiteral(" class=\"column-one-half\"");

WriteLiteral(">\r\n                    <table>\r\n                        <thead>\r\n                " +
"            <tr>\r\n                                <th>\r\n                        " +
"            <span");

WriteLiteral(" class=\"heading-span\"");

WriteLiteral(">Location</span>\r\n                                </th>\r\n                        " +
"    </tr>\r\n                        </thead>\r\n                        <tbody>\r\n");

            
            #line 70 "..\..\Views\Shared\DisplayTemplates\Vacancy\_OfflineVacancy.cshtml"
                            
            
            #line default
            #line hidden
            
            #line 70 "..\..\Views\Shared\DisplayTemplates\Vacancy\_OfflineVacancy.cshtml"
                             for (var i = midIndex; i < Model.NewVacancyViewModel.LocationAddresses.Count; i++)
                            {
                                var locationAddress = Model.NewVacancyViewModel.LocationAddresses[i];

            
            #line default
            #line hidden
WriteLiteral("                                <tr>\r\n                                    <td");

WriteLiteral(" class=\"location-address\"");

WriteLiteral(">\r\n");

WriteLiteral("                                        ");

            
            #line 75 "..\..\Views\Shared\DisplayTemplates\Vacancy\_OfflineVacancy.cshtml"
                                   Write(locationAddress.Address.AddressLine1);

            
            #line default
            #line hidden
WriteLiteral("\r\n");

            
            #line 76 "..\..\Views\Shared\DisplayTemplates\Vacancy\_OfflineVacancy.cshtml"
                                        
            
            #line default
            #line hidden
            
            #line 76 "..\..\Views\Shared\DisplayTemplates\Vacancy\_OfflineVacancy.cshtml"
                                         if (!string.IsNullOrWhiteSpace(@locationAddress.Address.AddressLine2))
                                        {

            
            #line default
            #line hidden
WriteLiteral("                                            <br />\r\n");

            
            #line 79 "..\..\Views\Shared\DisplayTemplates\Vacancy\_OfflineVacancy.cshtml"
                                                
            
            #line default
            #line hidden
            
            #line 79 "..\..\Views\Shared\DisplayTemplates\Vacancy\_OfflineVacancy.cshtml"
                                           Write(locationAddress.Address.AddressLine2);

            
            #line default
            #line hidden
            
            #line 79 "..\..\Views\Shared\DisplayTemplates\Vacancy\_OfflineVacancy.cshtml"
                                                                                     
                                        }

            
            #line default
            #line hidden
WriteLiteral("                                        <br />\r\n");

WriteLiteral("                                        ");

            
            #line 82 "..\..\Views\Shared\DisplayTemplates\Vacancy\_OfflineVacancy.cshtml"
                                   Write(locationAddress.Address.AddressLine4);

            
            #line default
            #line hidden
WriteLiteral(" ");

            
            #line 82 "..\..\Views\Shared\DisplayTemplates\Vacancy\_OfflineVacancy.cshtml"
                                                                         Write(locationAddress.Address.Postcode);

            
            #line default
            #line hidden
WriteLiteral("\r\n                                        <br />\r\n                               " +
"         <a");

WriteAttribute("id", Tuple.Create(" id=", 5137), Tuple.Create("", 5216)
            
            #line 84 "..\..\Views\Shared\DisplayTemplates\Vacancy\_OfflineVacancy.cshtml"
, Tuple.Create(Tuple.Create("", 5141), Tuple.Create<System.Object, System.Int32>("newvacancyviewmodel_locationaddresses_" + i + "__offlineapplicationurl"
            
            #line default
            #line hidden
, 5141), false)
);

WriteLiteral(" rel=\"external\"");

WriteAttribute("href", Tuple.Create(" href=\"", 5231), Tuple.Create("\"", 5276)
            
            #line 84 "..\..\Views\Shared\DisplayTemplates\Vacancy\_OfflineVacancy.cshtml"
                                                               , Tuple.Create(Tuple.Create("", 5238), Tuple.Create<System.Object, System.Int32>(locationAddress.OfflineApplicationUrl
            
            #line default
            #line hidden
, 5238), false)
);

WriteLiteral(" target=\"_blank\"");

WriteLiteral(">");

            
            #line 84 "..\..\Views\Shared\DisplayTemplates\Vacancy\_OfflineVacancy.cshtml"
                                                                                                                                                                                                  Write(locationAddress.OfflineApplicationUrl);

            
            #line default
            #line hidden
WriteLiteral("</a>\r\n                                    </td>\r\n                                " +
"</tr>\r\n");

            
            #line 87 "..\..\Views\Shared\DisplayTemplates\Vacancy\_OfflineVacancy.cshtml"
                            }

            
            #line default
            #line hidden
WriteLiteral("                        </tbody>\r\n                    </table>\r\n                <" +
"/div>\r\n");

            
            #line 91 "..\..\Views\Shared\DisplayTemplates\Vacancy\_OfflineVacancy.cshtml"
            }
            else
            {

            
            #line default
            #line hidden
WriteLiteral("                <p>\r\n                    <a");

WriteLiteral(" id=\"external-employer-website\"");

WriteLiteral(" rel=\"external\"");

WriteAttribute("href", Tuple.Create(" href=\"", 5676), Tuple.Create("\"", 5731)
            
            #line 95 "..\..\Views\Shared\DisplayTemplates\Vacancy\_OfflineVacancy.cshtml"
, Tuple.Create(Tuple.Create("", 5683), Tuple.Create<System.Object, System.Int32>(Model.NewVacancyViewModel.OfflineApplicationUrl
            
            #line default
            #line hidden
, 5683), false)
);

WriteLiteral(" target=\"_blank\"");

WriteLiteral(">");

            
            #line 95 "..\..\Views\Shared\DisplayTemplates\Vacancy\_OfflineVacancy.cshtml"
                                                                                                                                        Write(Model.NewVacancyViewModel.OfflineApplicationUrl);

            
            #line default
            #line hidden
WriteLiteral("</a>\r\n                </p>\r\n");

            
            #line 97 "..\..\Views\Shared\DisplayTemplates\Vacancy\_OfflineVacancy.cshtml"
            }

            
            #line default
            #line hidden
WriteLiteral("            <div");

WriteLiteral(" style=\"clear: both\"");

WriteLiteral(">\r\n");

WriteLiteral("                ");

            
            #line 99 "..\..\Views\Shared\DisplayTemplates\Vacancy\_OfflineVacancy.cshtml"
           Write(Html.Partial(CommentViewModel.PartialIconView, Html.GetCommentViewModel(Model, m => m.NewVacancyViewModel.OfflineApplicationUrl, Model.NewVacancyViewModel.OfflineApplicationUrlComment, Model.BasicDetailsLink)));

            
            #line default
            #line hidden
WriteLiteral("\r\n            </div>\r\n");

WriteLiteral("            ");

            
            #line 101 "..\..\Views\Shared\DisplayTemplates\Vacancy\_OfflineVacancy.cshtml"
       Write(Html.Partial(EditLinkViewModel.PartialView, Html.GetEditLinkViewModel(Model, m => m.NewVacancyViewModel.OfflineApplicationUrl, Model.BasicDetailsLink, Model.NewVacancyViewModel.OfflineApplicationUrlComment)));

            
            #line default
            #line hidden
WriteLiteral("\r\n        </div>\r\n    </section>\r\n");

            
            #line 104 "..\..\Views\Shared\DisplayTemplates\Vacancy\_OfflineVacancy.cshtml"
}
            
            #line default
            #line hidden
        }
    }
}
#pragma warning restore 1591
