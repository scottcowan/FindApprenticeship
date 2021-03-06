﻿namespace SFA.Apprenticeships.Infrastructure.Repositories.Sql.IoC
{
    using Common;
    using Configuration;
    using Domain.Interfaces.Repositories;
    using Domain.Raa.Interfaces.Reporting;
    using Domain.Raa.Interfaces.Repositories;
    using Reporting;
    using Schemas.dbo;
    using Schemas.Provider;
    using Schemas.Reference;
    using Schemas.UserProfile;
    using Application.Interfaces;
    using StructureMap.Configuration.DSL;

    public class RepositoriesRegistry : Registry
    {
        public RepositoriesRegistry(SqlConfiguration configuration)
        {
            //Common
            For<IGetOpenConnection>().Use<GetOpenConnectionFromConnectionString>().Ctor<string>("connectionString").Is(configuration.ReportingConnectionString).Name = "ReportingConnectionString";
            For<IGetOpenConnection>().Use<GetOpenConnectionFromConnectionString>().Ctor<string>("connectionString").Is(configuration.ConnectionString);

            //Mappers
            For<IMapper>().Singleton().Use<ReferenceMappers>().Name = "ReferenceMappers";
            For<IMapper>().Singleton().Use<ProviderUserMappers>().Name = "ProviderUserMappers";
            For<IMapper>().Singleton().Use<AgencyUserMappers>().Name = "AgencyUserMappers";

            //Repositories
            For<IReferenceRepository>().Use<ReferenceRepository>().Ctor<IMapper>().Named("ReferenceMappers");
            For<IProviderUserReadRepository>().Use<ProviderUserRepository>().Ctor<IMapper>().Named("ProviderUserMappers");
            For<IProviderUserWriteRepository>().Use<ProviderUserRepository>().Ctor<IMapper>().Named("ProviderUserMappers");
            For<IAgencyUserReadRepository>().Use<AgencyUserRepository>().Ctor<IMapper>().Named("AgencyUserMappers");
            For<IAgencyUserWriteRepository>().Use<AgencyUserRepository>().Ctor<IMapper>().Named("AgencyUserMappers");
            For<IReportingRepository>().Use<ReportingRepository>().Ctor<IGetOpenConnection>().Named("ReportingConnectionString");
            For<IReferenceNumberRepository>().Use<ReferenceNumberRepository>();
            For<IApiUserRepository>().Use<ApiUserRepository>();
        }
    }
}
