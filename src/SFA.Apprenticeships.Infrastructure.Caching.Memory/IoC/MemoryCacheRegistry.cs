﻿namespace SFA.Apprenticeships.Infrastructure.Caching.Memory.IoC
{
    using Application.Interfaces.Caching;
    using StructureMap.Configuration.DSL;

    public class MemoryCacheRegistry : Registry
    {
        public const string MemoryCacheName = "MemoryCacheService";

        public MemoryCacheRegistry()
        {
            For<ICacheService>().Singleton().Use<MemoryCacheService>().Name = MemoryCacheName;
        }
    }
}
