﻿namespace SFA.Apprenticeships.Web.Candidate.Providers
{
    using System;
    using ViewModels.Applications;

    public interface IApplicationProvider
    {
        ApplicationViewModel GetApplicationViewModel(int vacancyId, Guid candidateId);

        ApplicationViewModel MergeApplicationViewModel(int vacancyId, ApplicationViewModel userApplicationViewModel);

        void SaveApplication(ApplicationViewModel applicationViewModel);
    }
}
