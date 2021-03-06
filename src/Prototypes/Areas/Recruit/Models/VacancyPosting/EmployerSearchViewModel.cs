﻿namespace SFA.Apprenticeships.Web.Recruit.ViewModels.VacancyPosting
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Common.ViewModels;
    using Constants.ViewModels;

    public enum EmployerFilterType
    {
        Undefined,
        Ern,
        NameAndLocation
    }

    public class EmployerSearchViewModel
    {
        public EmployerSearchViewModel()
        {
            EmployerResultsPage = new PageableViewModel<EmployerResultViewModel> { CurrentPage = 1 };
        }

        public EmployerSearchViewModel(EmployerSearchViewModel viewModel) : this()
        {
            ProviderSiteErn = viewModel.ProviderSiteErn;
            FilterType = viewModel.FilterType;
            Ern = viewModel.Ern;
            Name = viewModel.Name;
            Location = viewModel.Location;
            if (viewModel.EmployerResultsPage != null)
            {
                EmployerResultsPage.CurrentPage = viewModel.EmployerResultsPage.CurrentPage;
            }
        }

        public string ProviderSiteErn { get; set; }

        public EmployerFilterType FilterType { get; set; }

        [Display(Name = EmployerSearchViewModelMessages.Ern.LabelText)]
        public string Ern { get; set; }

        [Display(Name = EmployerSearchViewModelMessages.Name.LabelText)]
        public string Name { get; set; }

        [Display(Name = EmployerSearchViewModelMessages.Location.LabelText)]
        public string Location { get; set; }

        //TODO: Merge these properties
        public IEnumerable<EmployerResultViewModel> EmployerResults { get; set; }

        public PageableViewModel<EmployerResultViewModel> EmployerResultsPage { get; set; }

        public object RouteValues => new
        {
            ProviderSiteErn,
            FilterType,
            Ern,
            Name,
            Location
        };
    }
}