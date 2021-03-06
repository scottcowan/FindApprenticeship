﻿namespace SFA.Apprenticeships.Web.Raa.Common.ViewModels.Provider
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;
    using Web.Common.ViewModels.Locations;
    using Constants.ViewModels;
    using Domain.Entities.Raa.Parties;
    using FluentValidation.Attributes;
    using Validators.Provider;

    [Validator(typeof(ProviderSiteViewModelClientValidator))]
    public class ProviderSiteViewModel
    {
        public int ProviderSiteId { get; set; }

        public int ProviderId { get; set; }

        [Display(Name = ProviderSiteViewModelMessages.EdsUrn.LabelText)]
        public string EdsUrn { get; set; }

        [Display(Name = ProviderSiteViewModelMessages.FullName.LabelText)]
        public string FullName { get; set; }

        [Display(Name = ProviderSiteViewModelMessages.TradingName.LabelText)]
        public string TradingName { get; set; }

        [Display(Name = ProviderSiteViewModelMessages.DisplayName.LabelText)]
        public string DisplayName => $"{FullName}, {Address.Town}";

        [AllowHtml]
        [Display(Name = ProviderSiteViewModelMessages.EmployerDescription.LabelText)]
        public string EmployerDescription { get; set; }

        [AllowHtml]
        [Display(Name = ProviderSiteViewModelMessages.CandidateDescription.LabelText)]
        public string CandidateDescription { get; set; }

        [Display(Name = ProviderSiteViewModelMessages.ContactDetailsForEmployer.LabelText)]
        public string ContactDetailsForEmployer { get; set; }

        [Display(Name = ProviderSiteViewModelMessages.ContactDetailsForCandidate.LabelText)]
        public string ContactDetailsForCandidate { get; set; }

        public AddressViewModel Address { get; set; }

        [Display(Name = ProviderSiteViewModelMessages.WebPage.LabelText)]
        public string WebPage { get; set; }

        [Display(Name = ProviderSiteViewModelMessages.TrainingProviderStatus.LabelText)]
        public EmployerTrainingProviderStatuses TrainingProviderStatus { get; set; }

        public IList<ProviderSiteRelationshipViewModel> ProviderSiteRelationships { get; set; }

        [Display(Name = ProviderSiteViewModelMessages.ProviderUkprn.LabelText)]
        public string ProviderUkprn { get; set; }

        [Display(Name = ProviderSiteViewModelMessages.ProviderSiteRelationshipType.LabelText)]
        public ProviderSiteRelationshipTypes ProviderSiteRelationshipType { get; set; }
    }
}