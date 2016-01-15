﻿namespace SFA.Apprenticeships.Infrastructure.Common.IoC
{
    using SFA.Infrastructure.Interfaces;
    using SFA.Infrastructure.Azure.Configuration;
    using Caching.Memory.IoC;
    using Configuration;
    using DateTime;
    using SFA.Infrastructure.Configuration;
    using SFA.Infrastructure.Interfaces.Caching;
    using StructureMap.Configuration.DSL;

    public class CommonRegistry : Registry
    {
        public CommonRegistry() : this(new CacheConfiguration(), string.Empty) { }

        public CommonRegistry(CacheConfiguration cacheConfiguration, string configurationStorageConnectionString)
        {
            For<IConfigurationManager>().Singleton().Use<ConfigurationManager>();
            For<IConfigurationService>().Singleton()
                .Use<AzureBlobConfigurationService>()
                .Ctor<string>("configurationStorageConnectionString").Is(configurationStorageConnectionString)
                .Name = "ConfigurationService";
            For<IDateTimeService>().Use<DateTimeService>();

            if (cacheConfiguration.UseCache)
            {
                For<IConfigurationService>()
                    .Singleton()
                    .Use<CachedConfigurationService>()
                    .Ctor<IConfigurationService>()
                    .Named("ConfigurationService")
                    .Ctor<ICacheService>()
                    .Named(MemoryCacheRegistry.MemoryCacheName);
            }
        }
    }
}
