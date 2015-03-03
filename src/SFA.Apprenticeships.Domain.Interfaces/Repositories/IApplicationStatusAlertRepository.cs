﻿namespace SFA.Apprenticeships.Domain.Interfaces.Repositories
{
    using System;
    using System.Collections.Generic;
    using Entities.Communication;

    public interface IApplicationStatusAlertRepository
    {
        void Save(ApplicationStatusAlert alert);

        void Delete(ApplicationStatusAlert alert);

        List<ApplicationStatusAlert> Get(Guid applicationId);

        Dictionary<Guid, List<ApplicationStatusAlert>> GetCandidatesDailyDigest();
    }
}