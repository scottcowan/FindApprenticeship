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
    
    #line 2 "..\..\Views\VacancyPosting\VacancyRequirementsProspects.cshtml"
    using SFA.Apprenticeships.Domain.Entities.Vacancies.ProviderVacancies;
    
    #line default
    #line hidden
    using SFA.Apprenticeships.Infrastructure.Presentation;
    using SFA.Apprenticeships.Web.Common.Constants;
    using SFA.Apprenticeships.Web.Common.Framework;
    using SFA.Apprenticeships.Web.Common.Models.Common;
    using SFA.Apprenticeships.Web.Raa.Common.Views.Shared.DisplayTemplates;
    using SFA.Apprenticeships.Web.Raa.Common.Views.Shared.EditorTemplates;
    using SFA.Apprenticeships.Web.Recruit;
    
    #line 3 "..\..\Views\VacancyPosting\VacancyRequirementsProspects.cshtml"
    using SFA.Apprenticeships.Web.Recruit.Constants;
    
    #line default
    #line hidden
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/VacancyPosting/VacancyRequirementsProspects.cshtml")]
    public partial class VacancyRequirementsProspects : System.Web.Mvc.WebViewPage<SFA.Apprenticeships.Web.Raa.Common.ViewModels.Vacancy.VacancyRequirementsProspectsViewModel>
    {
        public VacancyRequirementsProspects()
        {
        }
        public override void Execute()
        {
            
            #line 4 "..\..\Views\VacancyPosting\VacancyRequirementsProspects.cshtml"
  
    ViewBag.Title = "Recruit an Apprentice - Enter vacancy requirements and prospects";

    var saveButtonText = Model.Status == ProviderVacancyStatuses.RejectedByQA ? "Save and return to Preview" : "Save and continue";

            
            #line default
            #line hidden
WriteLiteral("\r\n\r\n<h1");

WriteLiteral(" class=\"heading-xlarge\"");

WriteLiteral(">\r\n    Requirements and prospects\r\n</h1>\r\n\r\n");

            
            #line 14 "..\..\Views\VacancyPosting\VacancyRequirementsProspects.cshtml"
 using (Html.BeginRouteForm(RecruitmentRouteNames.VacancyRequirementsProspects, FormMethod.Post))
{
    
            
            #line default
            #line hidden
            
            #line 16 "..\..\Views\VacancyPosting\VacancyRequirementsProspects.cshtml"
Write(Html.AntiForgeryToken());

            
            #line default
            #line hidden
            
            #line 16 "..\..\Views\VacancyPosting\VacancyRequirementsProspects.cshtml"
                            
    
            
            #line default
            #line hidden
            
            #line 17 "..\..\Views\VacancyPosting\VacancyRequirementsProspects.cshtml"
Write(Html.Partial("ValidationSummary", ViewData.ModelState));

            
            #line default
            #line hidden
            
            #line 17 "..\..\Views\VacancyPosting\VacancyRequirementsProspects.cshtml"
                                                           

    
            
            #line default
            #line hidden
            
            #line 19 "..\..\Views\VacancyPosting\VacancyRequirementsProspects.cshtml"
Write(Html.HiddenFor(m => m.VacancyReferenceNumber));

            
            #line default
            #line hidden
            
            #line 19 "..\..\Views\VacancyPosting\VacancyRequirementsProspects.cshtml"
                                                  
    
            
            #line default
            #line hidden
            
            #line 20 "..\..\Views\VacancyPosting\VacancyRequirementsProspects.cshtml"
Write(Html.HiddenFor(model => model.Status));

            
            #line default
            #line hidden
            
            #line 20 "..\..\Views\VacancyPosting\VacancyRequirementsProspects.cshtml"
                                          


            
            #line default
            #line hidden
WriteLiteral("    <section>\r\n        <div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(">\r\n");

WriteLiteral("            ");

            
            #line 24 "..\..\Views\VacancyPosting\VacancyRequirementsProspects.cshtml"
       Write(Html.FormTextAreaFor(m => m.DesiredSkills, controlHtmlAttributes: new { @class = "width-all-1-1 form-textarea-medium", type = "text" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("            ");

            
            #line 25 "..\..\Views\VacancyPosting\VacancyRequirementsProspects.cshtml"
       Write(Html.DisplayFor(m => m.DesiredSkillsComment, "Comment"));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("            ");

            
            #line 26 "..\..\Views\VacancyPosting\VacancyRequirementsProspects.cshtml"
       Write(Html.FormTextAreaFor(m => m.PersonalQualities, controlHtmlAttributes: new { @class = "width-all-1-1 form-textarea-medium", type = "text" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("            ");

            
            #line 27 "..\..\Views\VacancyPosting\VacancyRequirementsProspects.cshtml"
       Write(Html.DisplayFor(m => m.PersonalQualitiesComment, "Comment"));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("            ");

            
            #line 28 "..\..\Views\VacancyPosting\VacancyRequirementsProspects.cshtml"
       Write(Html.FormTextAreaFor(m => m.DesiredQualifications, controlHtmlAttributes: new { @class = "width-all-1-1 form-textarea-medium", type = "text" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("            ");

            
            #line 29 "..\..\Views\VacancyPosting\VacancyRequirementsProspects.cshtml"
       Write(Html.DisplayFor(m => m.DesiredQualificationsComment, "Comment"));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("            ");

            
            #line 30 "..\..\Views\VacancyPosting\VacancyRequirementsProspects.cshtml"
       Write(Html.FormTextAreaFor(m => m.FutureProspects, controlHtmlAttributes: new { @class = "width-all-1-1 form-textarea-medium", type = "text" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("            ");

            
            #line 31 "..\..\Views\VacancyPosting\VacancyRequirementsProspects.cshtml"
       Write(Html.DisplayFor(m => m.FutureProspectsComment, "Comment"));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("            ");

            
            #line 32 "..\..\Views\VacancyPosting\VacancyRequirementsProspects.cshtml"
       Write(Html.FormTextAreaFor(m => m.ThingsToConsider, controlHtmlAttributes: new { @class = "width-all-1-1 form-textarea-medium", type = "text" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("            ");

            
            #line 33 "..\..\Views\VacancyPosting\VacancyRequirementsProspects.cshtml"
       Write(Html.DisplayFor(m => m.ThingsToConsiderComment, "Comment"));

            
            #line default
            #line hidden
WriteLiteral("\r\n        </div>\r\n    </section>\r\n");

WriteLiteral("    <div");

WriteLiteral(" class=\"grid grid-1-2\"");

WriteLiteral(">\r\n        <button");

WriteLiteral(" id=\"VacancyRequirementsProspectsButton\"");

WriteLiteral(" type=\"submit\"");

WriteLiteral(" class=\"button\"");

WriteLiteral(" name=\"VacancyRequirementsProspects\"");

WriteLiteral(" value=\"VacancyRequirementsProspects\"");

WriteLiteral(">");

            
            #line 37 "..\..\Views\VacancyPosting\VacancyRequirementsProspects.cshtml"
                                                                                                                                                         Write(saveButtonText);

            
            #line default
            #line hidden
WriteLiteral("</button>\r\n        <button");

WriteLiteral(" id=\"VacancyRequirementsProspectsAndExit\"");

WriteLiteral(" type=\"submit\"");

WriteLiteral(" class=\"button-link\"");

WriteLiteral(" name=\"VacancyRequirementsProspects\"");

WriteLiteral(" value=\"VacancyRequirementsProspectsAndExit\"");

WriteLiteral(">Save and exit</button>\r\n    </div>\r\n");

            
            #line 40 "..\..\Views\VacancyPosting\VacancyRequirementsProspects.cshtml"
}

            
            #line default
            #line hidden
        }
    }
}
#pragma warning restore 1591
