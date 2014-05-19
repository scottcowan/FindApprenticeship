﻿using SFA.Apprenticeships.Common.Interfaces.Services;
using SFA.Apprenticeships.Services.Common.Wcf;
using SFA.Apprenticeships.Services.ReferenceData.Abstract;
using SFA.Apprenticeships.Services.ReferenceData.Proxy;
using SFA.Apprenticeships.Services.ReferenceData.Service;
using StructureMap;

namespace SFA.Apprenticeships.Services.ReferenceData.DependencyResolution
{
    public static class DependencyResolver
    {
        public static IContainer LoadConfiguration(this IContainer container)
        {
            container.Configure(
                x =>
                {
                    x.For<IWcfService<IReferenceData>>().Use<WcfService<IReferenceData>>();
                    x.For<IReferenceDataService>().Use<ReferenceDataService>();
                });

            return container;
        }
    }
}
