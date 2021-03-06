﻿namespace SFA.Apprenticeships.Web.Raa.Common.ViewModels.Candidate
{
    using System;
    using Domain.Raa.Interfaces.Repositories.Models;

    public class CandidateApplicationsSearchViewModel : OrderedPageableSearchViewModel
    {
        public const string OrderByFieldVacancyTitle = "VacancyTitle";
        public const string OrderByFieldEmployer = "Employer";
        public const string OrderByFieldSubmitted = "Submitted";
        public const string OrderByFieldStatus = "Status";

        public CandidateApplicationsSearchViewModel() : base(OrderByFieldSubmitted, Order.Descending)
        {
            
        }

        public CandidateApplicationsSearchViewModel(Guid candidateGuid) : this()
        {
            CandidateGuid = candidateGuid;
        }

        protected CandidateApplicationsSearchViewModel(CandidateApplicationsSearchViewModel viewModel) : base(viewModel)
        {
            CandidateGuid = viewModel.CandidateGuid;
        }

        public CandidateApplicationsSearchViewModel(CandidateApplicationsSearchViewModel viewModel, string orderByField, Order order) : base(viewModel, orderByField, order)
        {
            CandidateGuid = viewModel.CandidateGuid;
        }

        public CandidateApplicationsSearchViewModel(CandidateApplicationsSearchViewModel viewModel, int currentPage) : base(viewModel, currentPage)
        {
            CandidateGuid = viewModel.CandidateGuid;
        }

        public Guid CandidateGuid { get; set; }

        public override object RouteValues => new
        {
            CandidateGuid,
            OrderByField,
            Order,
            PageSize,
            CurrentPage
        };
    }
}