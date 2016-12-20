﻿namespace SFA.Apprenticeships.Application.Location.IoC
{
    using StructureMap.Configuration.DSL;
    using StructureMap.Graph;

    public class LocationServiceRegistry : Registry
    {
        public LocationServiceRegistry()
        {
            Scan(
                scan =>
                {
                    scan.TheCallingAssembly();
                    scan.WithDefaultConventions();
                });
        }
    }
}