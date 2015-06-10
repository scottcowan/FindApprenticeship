namespace SFA.Apprenticeships.Application.Communications.Housekeeping
{
    using System.Diagnostics;
    using System.Linq;
    using Domain.Interfaces.Messaging;
    using Interfaces.Logging;

    public class RootCommunicationHousekeeper : IRootCommunicationHousekeeper
    {
        private readonly ILogService _logService;
        private readonly IMessageBus _messageBus;

        private readonly IApplicationStatusAlertCommunicationHousekeeper _applicationStatusAlertCommunicationHousekeeper;
        private readonly IExpiringDraftApplicationAlertCommunicationHousekeeper _expiringDraftApplicationAlertCommunicationHousekeeper;
        private readonly ISavedSearchAlertCommunicationHousekeeper _savedSearchAlertCommunicationHousekeeper;

        public RootCommunicationHousekeeper(
            ILogService logService,
            IMessageBus messageBus,
            IApplicationStatusAlertCommunicationHousekeeper applicationStatusAlertCommunicationHousekeeper,
            IExpiringDraftApplicationAlertCommunicationHousekeeper expiringDraftApplicationAlertCommunicationHousekeeper,
            ISavedSearchAlertCommunicationHousekeeper savedSearchAlertCommunicationHousekeeper)
        {
            _logService = logService;
            _messageBus = messageBus;

            _applicationStatusAlertCommunicationHousekeeper = applicationStatusAlertCommunicationHousekeeper;
            _expiringDraftApplicationAlertCommunicationHousekeeper = expiringDraftApplicationAlertCommunicationHousekeeper;
            _savedSearchAlertCommunicationHousekeeper = savedSearchAlertCommunicationHousekeeper;

            _applicationStatusAlertCommunicationHousekeeper.Successor = _expiringDraftApplicationAlertCommunicationHousekeeper;
            _expiringDraftApplicationAlertCommunicationHousekeeper.Successor = _savedSearchAlertCommunicationHousekeeper;
            _savedSearchAlertCommunicationHousekeeper.Successor = null;
        }

        public int QueueHousekeepingRequests()
        {
            var stopwatch = new Stopwatch();
            
            stopwatch.Start();

            // TODO: AG: US794: consider finer-grained logging or using MongoDB log to determine query performance.
            var requests =
                _applicationStatusAlertCommunicationHousekeeper.GetHousekeepingRequests()
                    .Union(_expiringDraftApplicationAlertCommunicationHousekeeper.GetHousekeepingRequests()
                        .Union(_savedSearchAlertCommunicationHousekeeper.GetHousekeepingRequests()));

            var message = string.Format("Querying communications for housekeeping took {0}", stopwatch.Elapsed);
            var count = 0;

            foreach (var request in requests)
            {
                _messageBus.PublishMessage(request);
                count++;
            }

            stopwatch.Stop();

            message += string.Format(". Queuing {0} communications for housekeeping took {1}", count, stopwatch.Elapsed);

            if (stopwatch.ElapsedMilliseconds > 60000)
            {
                _logService.Warn(message);
            }
            else
            {
                _logService.Info(message);
            }

            return count;
        }

        public void Handle(CommunicationHousekeepingRequest request)
        {
            _applicationStatusAlertCommunicationHousekeeper.Handle(request);
        }
    }
}