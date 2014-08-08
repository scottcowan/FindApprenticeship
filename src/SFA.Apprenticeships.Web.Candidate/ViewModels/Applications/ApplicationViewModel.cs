﻿namespace SFA.Apprenticeships.Web.Candidate.ViewModels.Applications
{
    using System;
    using Candidate;
    using Domain.Entities.Applications;
    using VacancySearch;

    [Serializable]
    public enum ApplicationAction
    {
        Preview,
        Save
    }

    [Serializable]
    public class ApplicationViewModel
    {
        public VacancyDetailViewModel VacancyDetail { get; set; } //TODO Make this the summary info
        public CandidateViewModel Candidate { get; set; }
        public ApplicationStatuses Status { get; set; }
        public DateTime? DateUpdated { get; set; }
        public Guid ApplicationViewId { get; set; }
        public ApplicationAction ApplicationAction { get; set; }
    }
}