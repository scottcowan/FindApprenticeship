namespace SFA.Apprenticeships.Web.Candidate.Attributes
{
    using Application.Interfaces;
    using Common.Configuration;
    using System.Web.Mvc;

    public class SiteRootRedirect : ActionFilterAttribute
    {
        public IConfigurationService ConfigurationService { get; set; }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            var redirectUrl = ConfigurationService.Get<CommonWebConfiguration>().SiteRootRedirectUrl;

            if (!string.IsNullOrEmpty(redirectUrl))
            {
                filterContext.Result = new RedirectResult(redirectUrl);
            }

            base.OnActionExecuted(filterContext);
        }
    }
}