﻿namespace SFA.Apprenticeships.Application.Candidate.Strategies
{
    using System;
    using System.Collections.Generic;
    using Domain.Entities.Applications;

    public interface IGetCandidateApplicationsStrategy
    {
        IList<ApprenticeshipApplicationSummary> GetApplications(Guid candidateId);
    }
}
