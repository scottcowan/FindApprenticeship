﻿namespace SFA.Apprenticeships.Infrastructure.Monitor.MessageLossCheck.Tasks
{
    using System;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using Application.Candidate;
    using SFA.Infrastructure.Interfaces;
    using Domain.Interfaces.Messaging;
    using Monitor.Tasks;
    using Repository;

    public class CheckUnsentApprenticeshipApplicationMessages : IMonitorTask
    {
        private readonly ILogService _logger;
        private readonly IApprenticeshipApplicationDiagnosticsRepository _applicationDiagnosticsRepository;
        private readonly IServiceBus _serviceBus;

        public CheckUnsentApprenticeshipApplicationMessages(
            IApprenticeshipApplicationDiagnosticsRepository applicationDiagnosticsRepository,
            IServiceBus serviceBus,
            ILogService logger)
        {
            _applicationDiagnosticsRepository = applicationDiagnosticsRepository;
            _serviceBus = serviceBus;
            _logger = logger;
        }

        public string TaskName
        {
            get { return "Check Unsent Apprenticeship Application Messages"; }
        }

        public void Run()
        {
            var sb = new StringBuilder("The following actions were taken to resolve issues with apprenticeship applications:");
            sb.AppendLine();

            var applicationsToRequeue = _applicationDiagnosticsRepository.GetApplicationsForValidCandidatesWithUnsetLegacyId().ToList();

            foreach (var application in applicationsToRequeue)
            {
                var requeueingMessage = string.Format("Re-queuing create apprenticeship application message for application id: {0}", application.EntityId);
                _logger.Info(requeueingMessage);
                sb.AppendLine(requeueingMessage);

                var message = new SubmitApprenticeshipApplicationRequest
                {
                    ApplicationId = application.EntityId
                };

                _serviceBus.PublishMessage(message);

                var requeuedMessage = string.Format("Re-queued create apprenticeship application message for candidate id: {0}", application.EntityId);
                _logger.Info(requeuedMessage);
                sb.AppendLine(requeuedMessage);
            }

            if (!applicationsToRequeue.Any()) return;

            //Wait 5 seconds to allow messages to be processed. Nondeterministic of course
            Thread.Sleep(TimeSpan.FromSeconds(5));

            var applicationsForValidCandidatesWithUnsetLegacyId = _applicationDiagnosticsRepository.GetApplicationsForValidCandidatesWithUnsetLegacyId().ToList();
            if (applicationsForValidCandidatesWithUnsetLegacyId.Any())
            {
                sb.AppendLine("The actions taken did not resolve the following issues with apprenticeship applications:");
                applicationsForValidCandidatesWithUnsetLegacyId.ForEach(a => sb.AppendLine(string.Format("Application with id: {0} is associated with a valid candidate but has an unset legacy application id", a.EntityId)));
                _logger.Error(sb.ToString());
            }
            else
            {
                sb.AppendLine("The actions taken appear to have resolved the issues");
                _logger.Warn(sb.ToString());
            }
        }
    }
}