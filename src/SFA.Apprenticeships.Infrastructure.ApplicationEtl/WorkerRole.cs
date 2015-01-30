namespace SFA.Apprenticeships.Infrastructure.ApplicationEtl
{
    using System;
    using System.Net;
    using System.Reflection;
    using System.ServiceModel;
    using System.Threading;
    using Azure.Common.IoC;
    using Caching.Azure.IoC;
    using Caching.Memory.IoC;
    using Common.Configuration;
    using Common.IoC;
    using Consumers;
    using EasyNetQ;
    using IoC;
    using LegacyWebServices.IoC;
    using Logging;
    using Logging.IoC;
    using Microsoft.WindowsAzure.ServiceRuntime;
    using NLog;
    using RabbitMq.Interfaces;
    using RabbitMq.IoC;
    using Repositories.Applications.IoC;
    using StructureMap;

    public class WorkerRole : RoleEntryPoint
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
        private ApplicationEtlControlQueueConsumer _applicationEtlControlQueueConsumer;

        public override void Run()
        {
            Logger.Debug("Application Etl Process Run Called");

            Initialise();

            while (true)
            {
                try
                {
                    _applicationEtlControlQueueConsumer.CheckScheduleQueue().Wait();
                }
                catch (CommunicationException ce)
                {
                    Logger.Warn("CommunicationException from ApplicationSchedulerConsumer", ce);
                }
                catch (TimeoutException te)
                {
                    Logger.Warn("TimeoutException from ApplicationSchedulerConsumer", te);
                }
                catch (Exception ex)
                {
                    Logger.Error("Exception from ApplicationSchedulerConsumer", ex);
                }

                Thread.Sleep(TimeSpan.FromMinutes(1));
            }
        }

        private void Initialise()
        {
            VersionLogging.SetVersion();

            try
            {
                var config = new ConfigurationManager();
                var useCacheSetting = config.TryGetAppSetting("UseCaching");
                bool useCache;
                bool.TryParse(useCacheSetting, out useCache);

#pragma warning disable 0618
                // TODO: AG: CRITICAL: NuGet package update on 2014-10-30.
                ObjectFactory.Initialize(x =>
                {
                    x.AddRegistry<CommonRegistry>();
                    x.AddRegistry<LoggingRegistry>();
                    x.AddRegistry<AzureCommonRegistry>();
                    x.AddRegistry<RabbitMqRegistry>();
                    x.AddRegistry<AzureCacheRegistry>();
                    x.AddRegistry<MemoryCacheRegistry>();
                    x.AddRegistry(new LegacyWebServicesRegistry(useCache));
                    x.AddRegistry<RabbitMqRegistry>();
                    x.AddRegistry<ApplicationEtlRegistry>();
                    x.AddRegistry<ApplicationRepositoryRegistry>();
                });
#pragma warning restore 0618

                Logger.Debug("Application Etl Process IoC initialized");

#pragma warning disable 618
                var subscriberBootstrapper = ObjectFactory.GetInstance<IBootstrapSubcribers>();
#pragma warning restore 618
                subscriberBootstrapper.LoadSubscribers(Assembly.GetAssembly(typeof(ApplicationStatusSummaryConsumerAsync)), "ApplicationEtl");
                Logger.Debug("Rabbit subscriptions setup complete");

#pragma warning disable 618
                _applicationEtlControlQueueConsumer = ObjectFactory.GetInstance<ApplicationEtlControlQueueConsumer>();
#pragma warning restore 618

                Logger.Debug("Application Etl Process setup complete");
            }
            catch (Exception ex)
            {
                Logger.Fatal("Application Etl Process failed to initialise", ex);
                throw;
            }
        }

        public override bool OnStart()
        {
            Logger.Debug("Application Etl Process OnStart called");

            // Set the maximum number of concurrent connections 
            ServicePointManager.DefaultConnectionLimit = 12;

            // For information on handling configuration changes
            // see the MSDN topic at http://go.microsoft.com/fwlink/?LinkId=166357.

            return base.OnStart();
        }

        public override void OnStop()
        {
            Logger.Debug("Application Etl Process OnStop called");

            // Stop consumers
#pragma warning disable 618
            ObjectFactory.GetInstance<ApplicationStatusSummaryPageConsumerAsync>().Stop();
            ObjectFactory.GetInstance<ApplicationStatusSummaryConsumerAsync>().Stop();
#pragma warning restore 618

            // Kill the bus which will kill any subscriptions
#pragma warning disable 0618
            // TODO: AG: CRITICAL: NuGet package update on 2014-10-30.
            ObjectFactory.GetInstance<IBus>().Advanced.Dispose();
#pragma warning restore 0618

            // Give it 5 seconds to finish processing any in flight subscriptions.
            Thread.Sleep(TimeSpan.FromSeconds(5));

            base.OnStop();
        }
    }
}
