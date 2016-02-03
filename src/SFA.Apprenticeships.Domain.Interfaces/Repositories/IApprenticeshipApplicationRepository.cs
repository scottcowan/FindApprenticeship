﻿namespace SFA.Apprenticeships.Domain.Interfaces.Repositories
{
    using System;
    using System.Collections.Generic;
    using Entities.Applications;

    public interface IApprenticeshipApplicationReadRepository : IReadRepository<ApprenticeshipApplicationDetail, Guid>
    {
        ApprenticeshipApplicationDetail Get(Guid id, bool errorIfNotFound);

        ApprenticeshipApplicationDetail Get(int legacyApplicationId, bool errorIfMultipleFound);

        IList<ApprenticeshipApplicationSummary> GetForCandidate(Guid candidateId);

        ApprenticeshipApplicationDetail GetForCandidate(Guid candidateId, int vacancyId, bool errorIfNotFound = false);

        IEnumerable<ApprenticeshipApplicationSummary> GetApplicationSummaries(int vacancyId);

        IList<ApprenticeshipApplicationSummary> GetSubmittedApplicationSummaries(int vacancyId);

        IEnumerable<Guid> GetDraftApplicationsForExpiredVacancies(DateTime vacancyExpiryDate);

        IEnumerable<Guid> GetApplicationsSubmittedOnOrBefore(DateTime dateApplied);

        int GetApplicationCount(int vacancyId);

        int GetNewApplicationCount(int vacancyId);
    }

    public interface IApprenticeshipApplicationWriteRepository : IWriteRepository<ApprenticeshipApplicationDetail, Guid> {
        void ExpireOrWithdrawForCandidate(Guid value, int vacancyId);
        void UpdateApplicationNotes(Guid applicationId, string notes);
    }
}
