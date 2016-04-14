﻿namespace SFA.Apprenticeships.Infrastructure.Repositories.Providers.IoC
{
    using SFA.Infrastructure.Interfaces;
    using Domain.Interfaces.Repositories;
    using Mappers;
    using StructureMap.Configuration.DSL;

    public class ProviderRepositoryRegistry : Registry
    {
        public ProviderRepositoryRegistry()
        {
            For<IMapper>().Use<ProviderMappers>().Name = "ProviderMappers";
            For<IProviderReadRepository>().Use<ProviderRepository>().Ctor<IMapper>().Named("ProviderMappers");
            For<IProviderWriteRepository>().Use<ProviderRepository>().Ctor<IMapper>().Named("ProviderMappers");
            For<IProviderSiteReadRepository>().Use<ProviderSiteRepository>().Ctor<IMapper>().Named("ProviderMappers");
            For<IProviderSiteWriteRepository>().Use<ProviderSiteRepository>().Ctor<IMapper>().Named("ProviderMappers");
            For<IProviderSiteEmployerLinkReadRepository>().Use<ProviderSiteEmployerLinkRepository>().Ctor<IMapper>().Named("ProviderMappers");
            For<IProviderSiteEmployerLinkWriteRepository>().Use<ProviderSiteEmployerLinkRepository>().Ctor<IMapper>().Named("ProviderMappers");
        }
    }
}