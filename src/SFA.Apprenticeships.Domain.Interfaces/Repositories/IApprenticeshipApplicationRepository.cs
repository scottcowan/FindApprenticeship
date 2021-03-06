﻿namespace SFA.Apprenticeships.Domain.Interfaces.Repositories
{
    using System;
    using System.Collections.Generic;
    using Entities.Applications;

    public interface IApprenticeshipApplicationReadRepository : IReadRepository<ApprenticeshipApplicationDetail>
    {
        ApprenticeshipApplicationDetail Get(Guid id, bool errorIfNotFound);

        ApprenticeshipApplicationDetail Get(int legacyApplicationId, bool errorIfMultipleFound);

        IList<ApprenticeshipApplicationSummary> GetForCandidate(Guid candidateId);

        ApprenticeshipApplicationDetail GetForCandidate(Guid candidateId, int vacancyId, bool errorIfNotFound = false);

        IEnumerable<ApprenticeshipApplicationSummary> GetApplicationSummaries(int vacancyId);

        IEnumerable<ApprenticeshipApplicationSummary> GetSubmittedApplicationSummaries(int vacancyId);

        IEnumerable<Guid> GetDraftApplicationsForExpiredVacancies(DateTime vacancyExpiryDate);

        IEnumerable<Guid> GetApplicationsSubmittedOnOrBefore(DateTime dateApplied);
    }
    
    public interface IApprenticeshipApplicationWriteRepository : IWriteRepository<ApprenticeshipApplicationDetail> {
        void ExpireOrWithdrawForCandidate(Guid value, int vacancyId);
        void UpdateApplicationNotes(Guid applicationId, string notes);
        bool UpdateApplicationStatus(ApprenticeshipApplicationDetail entity, ApplicationStatuses updatedStatus, bool ignoreOwnershipCheck);
    }

    public interface IApprenticeshipApplicationStatsRepository
    {
        IReadOnlyDictionary<int, IApplicationCounts> GetCountsForVacancyIds(IEnumerable<int> vacancyIds);
    }
}
