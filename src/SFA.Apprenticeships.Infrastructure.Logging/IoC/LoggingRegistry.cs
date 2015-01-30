﻿namespace SFA.Apprenticeships.Infrastructure.Logging.IoC
{
    using Application.Interfaces.Logging;
    using Logging;
    using StructureMap.Configuration.DSL;

    public class LoggingRegistry : Registry
    {
        public LoggingRegistry()
        {
            For<ILogService>().Use<NLogLogService>();
        }
    }
}
