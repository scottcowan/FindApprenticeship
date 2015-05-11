﻿namespace SFA.Apprenticeships.Application.Candidates.Strategies
{
    using Domain.Entities.Candidates;
    using Domain.Entities.Users;
    using Domain.Interfaces.Configuration;
    using Domain.Interfaces.Repositories;
    using Interfaces.Logging;

    public class SetPendingDeletionStrategy : HousekeepingStrategy
    {
        private readonly IUserWriteRepository _userWriteRepository;
        private readonly IAuditRepository _auditRepository;
        private readonly ILogService _logService;

        public SetPendingDeletionStrategy(IConfigurationService configurationService, IUserWriteRepository userWriteRepository, IAuditRepository auditRepository, ILogService logService)
            : base(configurationService)
        {
            _userWriteRepository = userWriteRepository;
            _auditRepository = auditRepository;
            _logService = logService;
        }

        protected override bool DoHandle(User user, Candidate candidate)
        {
            if (user.Status != UserStatuses.PendingActivation) return false;

            var housekeepingCyclesSinceCreation = GetHousekeepingCyclesSinceCreation(user);

            if (housekeepingCyclesSinceCreation >= Configuration.SetPendingDeletionAfterCycles)
            {
                _logService.Info("Setting User: {0} Status to PendingDeletion", user.EntityId);

                _auditRepository.Audit(user, AuditEventTypes.SetCandidateStatusPendingDeletion);

                user.Status = UserStatuses.PendingDeletion;
                _userWriteRepository.Save(user);

                _logService.Info("Set User: {0} Status to PendingDeletion", user.EntityId);

                return true;
            }

            return false;
        }
    }
}