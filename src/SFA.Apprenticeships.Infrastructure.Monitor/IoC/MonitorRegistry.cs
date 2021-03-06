﻿namespace SFA.Apprenticeships.Infrastructure.Monitor.IoC
{
    using Consumers;
    using Infrastructure.Repositories.Mongo.Common;
    using Provider;
    using Repositories;
    using StructureMap.Configuration.DSL;
    using Tasks;

    public class MonitorRegistry : Registry
    {
        public MonitorRegistry()
        {
            For<MonitorControlQueueConsumer>().Use<MonitorControlQueueConsumer>();
            For<IMonitorTasksRunner>().Use<MonitorTasksRunner>();

            For<IMonitorTasksRunner>().Use<MonitorTasksRunner>()
                .EnumerableOf<IMonitorTask>()
                .Contains(x =>
                {
                    x.Type<CheckUserRepository>();
                    x.Type<CheckApprenticeshipApplicationRepository>();
                    x.Type<CheckTraineeshipApplicationRepository>();
                    x.Type<CheckCandidateRepository>();
                    x.Type<CheckVacancySearch>();
                    x.Type<CheckLocationLookup>();
                    x.Type<CheckPostcodeService>();
                    x.Type<CheckUserDirectory>();
                    x.Type<CheckAzureServiceBus>();
                    x.Type<CheckMongoReplicaSets>();
                    x.Type<CheckElasticsearchCluster>();
                    x.Type<CheckElasticsearchAliases>();
                    x.Type<CheckLogstashLogs>();
                    //x.Type<CheckUnsentCandidateMessages>();
                });

            For<IDailyMetricsTasksRunner>().Use<DailyMetricsTasksRunner>()
                .EnumerableOf<IDailyMetricsTask>()
                .Contains(x => x.Type<SendDailyMetricsEmail>());

            For<IMongoAdminClient>().Use<MongoAdminClient>();
            For<IApprenticeshipMetricsRepository>().Use<ApprenticeshipMetricsRepository>();
            For<IExpiringDraftsMetricsRepository>().Use<ExpiringDraftsMetricsRepository>();
            For<IApplicationStatusAlertsMetricsRepository>().Use<ApplicationStatusAlertsMetricsRepository>();
            For<ITraineeshipMetricsRepository>().Use<TraineeshipMetricsRepository>();
            For<IUserMetricsRepository>().Use<UserMetricsRepository>();
            For<ICandidateDiagnosticsRepository>().Use<CandidateDiagnosticsRepository>();
            For<ISavedSearchAlertMetricsRepository>().Use<SavedSearchAlertMetricsRepository>();
            For<IContactMessagesMetricsRepository>().Use<ContactMessagesMetricsRepository>();
            For<ISavedSearchesMetricsRepository>().Use<SavedSearchesMetricsRepository>();
            For<ICandidateMetricsRepository>().Use<CandidateMetricsRepository>();
            For<IAuditMetricsRepository>().Use<AuditMetricsRepository>();

            For<IVacancyMetricsProvider>().Use<VacancyMetricsProvider>();
        }
    }
}