﻿namespace SFA.Apprenticeships.Application.Candidate.Strategies
{
    using Domain.Entities.Applications;

    public interface ISaveApplicationStrategy
    {
        ApprenticeshipApplicationDetail SaveApplication(ApprenticeshipApplicationDetail apprenticeshipApplication);
    }
}