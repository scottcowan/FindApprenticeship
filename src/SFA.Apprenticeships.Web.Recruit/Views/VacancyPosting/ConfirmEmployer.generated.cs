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
    
    #line 3 "..\..\Views\VacancyPosting\ConfirmEmployer.cshtml"
    using SFA.Apprenticeships.Domain.Entities.Vacancies.ProviderVacancies;
    
    #line default
    #line hidden
    using SFA.Apprenticeships.Web.Common.Constants;
    using SFA.Apprenticeships.Web.Common.Framework;
    using SFA.Apprenticeships.Web.Common.Models.Common;
    using SFA.Apprenticeships.Web.Raa.Common.Views.Shared.DisplayTemplates;
    using SFA.Apprenticeships.Web.Raa.Common.Views.Shared.EditorTemplates;
    using SFA.Apprenticeships.Web.Recruit;
    
    #line 4 "..\..\Views\VacancyPosting\ConfirmEmployer.cshtml"
    using SFA.Apprenticeships.Web.Recruit.Constants;
    
    #line default
    #line hidden
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/VacancyPosting/ConfirmEmployer.cshtml")]
    public partial class ConfirmEmployer : System.Web.Mvc.WebViewPage<SFA.Apprenticeships.Web.Raa.Common.ViewModels.Provider.ProviderSiteEmployerLinkViewModel>
    {
        public ConfirmEmployer()
        {
        }
        public override void Execute()
        {
WriteLiteral("\r\n");

            
            #line 6 "..\..\Views\VacancyPosting\ConfirmEmployer.cshtml"
  
    ViewBag.Title = "Recruit an Apprentice - Check employer description";

    var saveButtonText = (Model.Status == ProviderVacancyStatuses.RejectedByQA || Model.ComeFromPreview) && 
        Model.IsEmployerLocationMainApprenticeshipLocation.HasValue &&
        Model.IsEmployerLocationMainApprenticeshipLocation.Value == true ? "Save and return to Preview" : "Save and continue";

            
            #line default
            #line hidden
WriteLiteral("\r\n\r\n<div");

WriteLiteral(" class=\"grid-wrapper\"");

WriteLiteral(">\r\n    <div");

WriteLiteral(" class=\"hgroup\"");

WriteLiteral(">\r\n        <h1");

WriteLiteral(" class=\"heading-xlarge\"");

WriteLiteral(">\r\n            Check employer description\r\n        </h1>\r\n    </div>\r\n</div>\r\n<di" +
"v");

WriteLiteral(" class=\"grid-wrapper\"");

WriteLiteral(">\r\n");

            
            #line 22 "..\..\Views\VacancyPosting\ConfirmEmployer.cshtml"
    
            
            #line default
            #line hidden
            
            #line 22 "..\..\Views\VacancyPosting\ConfirmEmployer.cshtml"
     using (Html.BeginRouteForm(RecruitmentRouteNames.ComfirmEmployer, FormMethod.Post))
    {   
        
            
            #line default
            #line hidden
            
            #line 24 "..\..\Views\VacancyPosting\ConfirmEmployer.cshtml"
   Write(Html.Partial("ValidationSummary", ViewData.ModelState));

            
            #line default
            #line hidden
            
            #line 24 "..\..\Views\VacancyPosting\ConfirmEmployer.cshtml"
                                                               

        
            
            #line default
            #line hidden
            
            #line 26 "..\..\Views\VacancyPosting\ConfirmEmployer.cshtml"
   Write(Html.HiddenFor(m => m.ProviderSiteErn));

            
            #line default
            #line hidden
            
            #line 26 "..\..\Views\VacancyPosting\ConfirmEmployer.cshtml"
                                               
        
            
            #line default
            #line hidden
            
            #line 27 "..\..\Views\VacancyPosting\ConfirmEmployer.cshtml"
   Write(Html.HiddenFor(m => m.Employer.Ern));

            
            #line default
            #line hidden
            
            #line 27 "..\..\Views\VacancyPosting\ConfirmEmployer.cshtml"
                                            
        
            
            #line default
            #line hidden
            
            #line 28 "..\..\Views\VacancyPosting\ConfirmEmployer.cshtml"
   Write(Html.HiddenFor(m => m.VacancyGuid));

            
            #line default
            #line hidden
            
            #line 28 "..\..\Views\VacancyPosting\ConfirmEmployer.cshtml"
                                           
        
            
            #line default
            #line hidden
            
            #line 29 "..\..\Views\VacancyPosting\ConfirmEmployer.cshtml"
   Write(Html.HiddenFor(m => m.VacancyReferenceNumber));

            
            #line default
            #line hidden
            
            #line 29 "..\..\Views\VacancyPosting\ConfirmEmployer.cshtml"
                                                      
        
            
            #line default
            #line hidden
            
            #line 30 "..\..\Views\VacancyPosting\ConfirmEmployer.cshtml"
   Write(Html.HiddenFor(m => m.ComeFromPreview));

            
            #line default
            #line hidden
            
            #line 30 "..\..\Views\VacancyPosting\ConfirmEmployer.cshtml"
                                               


            
            #line default
            #line hidden
WriteLiteral("        <div");

WriteLiteral(" class=\"grid grid-1-2\"");

WriteLiteral(">\r\n            <div");

WriteLiteral(" class=\"inner-block-padr\"");

WriteLiteral(">\r\n                <h3");

WriteLiteral(" class=\"bold-small\"");

WriteLiteral(">Employer</h3>\r\n                <p");

WriteLiteral(" class=\"small-btm-margin\"");

WriteLiteral(">");

            
            #line 35 "..\..\Views\VacancyPosting\ConfirmEmployer.cshtml"
                                       Write(Model.Employer.Name);

            
            #line default
            #line hidden
WriteLiteral("</p>\r\n                <h3");

WriteLiteral(" class=\"bold-small\"");

WriteLiteral(">Address</h3>\r\n                <p");

WriteLiteral(" class=\"small-btm-margin\"");

WriteLiteral(">");

            
            #line 37 "..\..\Views\VacancyPosting\ConfirmEmployer.cshtml"
                                       Write(Model.Employer.Address.AddressLine1);

            
            #line default
            #line hidden
WriteLiteral("</p>\r\n                <p");

WriteLiteral(" class=\"small-btm-margin\"");

WriteLiteral(">");

            
            #line 38 "..\..\Views\VacancyPosting\ConfirmEmployer.cshtml"
                                       Write(Model.Employer.Address.AddressLine2);

            
            #line default
            #line hidden
WriteLiteral("</p>\r\n                <p");

WriteLiteral(" class=\"small-btm-margin\"");

WriteLiteral(">");

            
            #line 39 "..\..\Views\VacancyPosting\ConfirmEmployer.cshtml"
                                       Write(Model.Employer.Address.AddressLine3);

            
            #line default
            #line hidden
WriteLiteral("</p>\r\n                <p");

WriteLiteral(" class=\"small-btm-margin\"");

WriteLiteral(">");

            
            #line 40 "..\..\Views\VacancyPosting\ConfirmEmployer.cshtml"
                                       Write(Model.Employer.Address.AddressLine4);

            
            #line default
            #line hidden
WriteLiteral("</p>\r\n                <p");

WriteLiteral(" class=\"small-btm-margin\"");

WriteLiteral(">");

            
            #line 41 "..\..\Views\VacancyPosting\ConfirmEmployer.cshtml"
                                       Write(Model.Employer.Address.Postcode);

            
            #line default
            #line hidden
WriteLiteral("</p>\r\n            </div>\r\n        </div>\r\n");

WriteLiteral("        <div");

WriteLiteral(" class=\"grid grid-1-2 hide-print\"");

WriteLiteral(">\r\n            <div");

WriteLiteral(" class=\"ad-details__map\"");

WriteLiteral(">\r\n                <div");

WriteLiteral(" class=\"map-overlay\"");

WriteLiteral(" onClick=\"style.pointerEvents = \'none\'\"");

WriteLiteral("></div>\r\n                <iframe");

WriteLiteral(" width=\"700\"");

WriteLiteral(" height=\"250\"");

WriteLiteral(" frameborder=\"0\"");

WriteLiteral(" style=\"border: 0\"");

WriteAttribute("src", Tuple.Create(" src=\"", 2208), Tuple.Create("\"", 2351)
, Tuple.Create(Tuple.Create("", 2214), Tuple.Create("https://www.google.com/maps/embed/v1/place?q=", 2214), true)
            
            #line 47 "..\..\Views\VacancyPosting\ConfirmEmployer.cshtml"
                                                     , Tuple.Create(Tuple.Create("", 2259), Tuple.Create<System.Object, System.Int32>(Model.Employer.Address.Postcode
            
            #line default
            #line hidden
, 2259), false)
, Tuple.Create(Tuple.Create("", 2291), Tuple.Create(",+United+Kingdom&key=AIzaSyCusA_0x4bJEjU-_gLOFiXMSBXKZYtvHz8", 2291), true)
);

WriteLiteral("></iframe>\r\n                <p");

WriteLiteral(" class=\"nojs-notice\"");

WriteLiteral(">You must have JavaScript enabled to view a map of the location</p>\r\n            " +
"</div>\r\n        </div>\r\n");

            
            #line 51 "..\..\Views\VacancyPosting\ConfirmEmployer.cshtml"


            
            #line default
            #line hidden
WriteLiteral("        <div");

WriteLiteral(" class=\"grid grid-1-1\"");

WriteLiteral(">\r\n");

            
            #line 53 "..\..\Views\VacancyPosting\ConfirmEmployer.cshtml"
            
            
            #line default
            #line hidden
            
            #line 53 "..\..\Views\VacancyPosting\ConfirmEmployer.cshtml"
              Html.RenderPartial("_apprenticeshipLocationSelectorJS", Model);
            
            #line default
            #line hidden
WriteLiteral("\r\n");

            
            #line 54 "..\..\Views\VacancyPosting\ConfirmEmployer.cshtml"
            
            
            #line default
            #line hidden
            
            #line 54 "..\..\Views\VacancyPosting\ConfirmEmployer.cshtml"
              Html.RenderPartial("_apprenticeshipLocationSelectorNonJS", Model);
            
            #line default
            #line hidden
WriteLiteral("\r\n        </div>\r\n");

            
            #line 56 "..\..\Views\VacancyPosting\ConfirmEmployer.cshtml"


            
            #line default
            #line hidden
WriteLiteral("        <div");

WriteLiteral(" class=\"grid grid-1-1\"");

WriteLiteral(">\r\n");

WriteLiteral("            ");

            
            #line 58 "..\..\Views\VacancyPosting\ConfirmEmployer.cshtml"
       Write(Html.FormTextFor(model => model.WebsiteUrl, controlHtmlAttributes: new {type = "text", @class = "form-control-1-1"}, labelHtmlAttributes: new {@class = "bold-small"}));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("            ");

            
            #line 59 "..\..\Views\VacancyPosting\ConfirmEmployer.cshtml"
       Write(Html.DisplayFor(m => m.WebsiteUrlComment, "Comment"));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("            ");

            
            #line 60 "..\..\Views\VacancyPosting\ConfirmEmployer.cshtml"
       Write(Html.FormTextAreaFor(m => m.Description, controlHtmlAttributes: new {@class = "width-all-1-1", type = "text", size = 12, style = "height: 200px;"}, labelHtmlAttributes: new {@class = "bold-small"}));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("            ");

            
            #line 61 "..\..\Views\VacancyPosting\ConfirmEmployer.cshtml"
       Write(Html.DisplayFor(m => m.DescriptionComment, "Comment"));

            
            #line default
            #line hidden
WriteLiteral("\r\n            <button");

WriteLiteral(" class=\"button\"");

WriteLiteral(" id=\"confirmEmployer\"");

WriteLiteral(" name=\"ConfirmEmployer\"");

WriteLiteral(" value=\"ConfirmEmployer\"");

WriteLiteral(">");

            
            #line 62 "..\..\Views\VacancyPosting\ConfirmEmployer.cshtml"
                                                                                                  Write(saveButtonText);

            
            #line default
            #line hidden
WriteLiteral("</button>\r\n");

WriteLiteral("            ");

            
            #line 63 "..\..\Views\VacancyPosting\ConfirmEmployer.cshtml"
       Write(Html.RouteLink("Choose a different employer", RecruitmentRouteNames.SelectExistingEmployer, new { providerSiteErn = Model.ProviderSiteErn, vacancyGuid = Model.VacancyGuid, comeFromPreview = Model.ComeFromPreview}, null));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

            
            #line 64 "..\..\Views\VacancyPosting\ConfirmEmployer.cshtml"
            
            
            #line default
            #line hidden
            
            #line 64 "..\..\Views\VacancyPosting\ConfirmEmployer.cshtml"
             if (Model.ComeFromPreview)
            {
                
            
            #line default
            #line hidden
            
            #line 66 "..\..\Views\VacancyPosting\ConfirmEmployer.cshtml"
           Write(Html.RouteLink("Cancel", RecruitmentRouteNames.PreviewVacancy, new { vacancyReferenceNumber = Model.VacancyReferenceNumber }));

            
            #line default
            #line hidden
            
            #line 66 "..\..\Views\VacancyPosting\ConfirmEmployer.cshtml"
                                                                                                                                              
            }

            
            #line default
            #line hidden
WriteLiteral("        </div>\r\n");

            
            #line 69 "..\..\Views\VacancyPosting\ConfirmEmployer.cshtml"
   }

            
            #line default
            #line hidden
WriteLiteral("</div>\r\n\r\n");

DefineSection("scripts", () => {

WriteLiteral("\r\n    <script");

WriteLiteral(" type=\"text/javascript\"");

WriteLiteral(">\r\n        var comeFromPreview = \"");

            
            #line 74 "..\..\Views\VacancyPosting\ConfirmEmployer.cshtml"
                          Write(Model.ComeFromPreview.ToString());

            
            #line default
            #line hidden
WriteLiteral(@""";

        $(""#NumberOfPositionsJS"").attr(""id"", ""NumberOfPositions"").attr(""Name"", ""NumberOfPositions"");
        $(""#location-type-main-location"").on('click', function () {
            if (comeFromPreview === ""True"") {
                $(""#confirmEmployer"").text(""Save and return to Preview"");
            }
        });

        $(""#location-type-different-location"").on('click', function () {
            $(""#confirmEmployer"").text(""Save and continue"");
        });
    </script>

    ");

WriteLiteral("\r\n");

});

        }
    }
}
#pragma warning restore 1591
