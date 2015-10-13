﻿namespace SFA.Apprenticeships.Web.Recruit.ViewModels.Provider
{
    using System.ComponentModel.DataAnnotations;
    using Constants.ViewModels;
    using FluentValidation.Attributes;
    using Vacancy;
    using Validators.Provider;

    [Validator(typeof(ProviderSiteEmployerLinkViewModelValidator))]
    public class ProviderSiteEmployerLinkViewModel
    {
        public string ProviderSiteErn { get; set; }
        [Display(Name = ProviderSiteEmployerLinkViewModelMessages.Description.LabelText)]
        public string Description { get; set; }
        public string WebsiteUrl { get; set; }
        public bool IsWebsiteUrlWellFormed { get; set; }
        public EmployerViewModel Employer { get; set; }
    }
}