﻿namespace SFA.Apprenticeships.Domain.Interfaces.Repositories
{
    using System;
    using System.Collections.Generic;
    using Entities.Applications;

    public interface ITraineeshipApplicationReadRepository : IReadRepository<TraineeshipApplicationDetail>
    {
        TraineeshipApplicationDetail Get(Guid id, bool errorIfNotFound);

        TraineeshipApplicationDetail Get(int legacyApplicationId);

        IList<TraineeshipApplicationSummary> GetForCandidate(Guid candidateId);

        TraineeshipApplicationDetail GetForCandidate(Guid candidateId, int vacancyId, bool errorIfNotFound = false);

        IEnumerable<TraineeshipApplicationSummary> GetApplicationSummaries(int vacancyId);

        IEnumerable<Guid> GetApplicationsSubmittedOnOrBefore(DateTime dateApplied);

        int GetApplicationCount(int vacancyId);

        int GetNewApplicationCount(int vacancyId);
        
        int GetNewApplicationsCount(List<int> liveVacancyIds);
    }

    public interface ITraineeshipApplicationWriteRepository : IWriteRepository<TraineeshipApplicationDetail>
    {
        void UpdateApplicationNotes(Guid applicationId, string notes);
    }
}
