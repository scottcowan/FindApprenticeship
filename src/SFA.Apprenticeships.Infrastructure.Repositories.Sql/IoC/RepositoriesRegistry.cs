﻿namespace SFA.Apprenticeships.Infrastructure.Repositories.Sql.IoC
{
    using Common;
    using Configuration;
    using Domain.Raa.Interfaces.Repositories;
    using Schemas.Provider;
    using Schemas.Reference;
    using Schemas.UserProfile;
    using SFA.Infrastructure.Interfaces;
    using StructureMap.Configuration.DSL;

    public class RepositoriesRegistry : Registry
    {
        public RepositoriesRegistry(SqlConfiguration configuration)
        {
            //Common
            For<IGetOpenConnection>().Use<GetOpenConnectionFromConnectionString>().Ctor<string>("connectionString").Is(configuration.ConnectionString);

            //Mappers
            For<IMapper>().Use<ReferenceMappers>().Name = "ReferenceMappers";
            For<IMapper>().Use<ProviderUserMappers>().Name = "ProviderUserMappers";
            For<IMapper>().Use<AgencyUserMappers>().Name = "AgencyUserMappers";

            //Repositories
            For<IReferenceRepository>().Use<ReferenceRepository>().Ctor<IMapper>().Named("ReferenceMappers");
            For<IProviderUserReadRepository>().Use<ProviderUserRepository>().Ctor<IMapper>().Named("ProviderUserMappers");
            For<IProviderUserWriteRepository>().Use<ProviderUserRepository>().Ctor<IMapper>().Named("ProviderUserMappers");
            For<IAgencyUserReadRepository>().Use<AgencyUserRepository>().Ctor<IMapper>().Named("AgencyUserMappers");
            For<IAgencyUserWriteRepository>().Use<AgencyUserRepository>().Ctor<IMapper>().Named("AgencyUserMappers");
        }
    }
}