﻿namespace SFA.Apprenticeships.Infrastructure.Repositories.Sql.Schemas.Vacancy.IoC
{
    using Domain.Raa.Interfaces.Repositories;
    using SFA.Infrastructure.Interfaces;
    using Vacancy;
    using StructureMap.Configuration.DSL;

    public class VacancyRepositoryRegistry : Registry
    {
        public VacancyRepositoryRegistry()
        {
            // Apprenticeships.
            For<IMapper>().Use<Sql.Schemas.Vacancy.VacancyMappers>().Name = "VacancyMappers";

            For<IVacancyReadRepository>()
                .Use<VacancyRepository>()
                .Ctor<IMapper>()
                .Named("VacancyMappers");

            For<IVacancyWriteRepository>()
                .Use<VacancyRepository>()
                .Ctor<IMapper>()
                .Named("VacancyMappers");

            For<IVacancyLocationReadRepository>()
                .Use<VacancyLocationRepository>()
                .Ctor<IMapper>()
                .Named("VacancyMappers");

            For<IVacancyLocationWriteRepository>()
                .Use<VacancyLocationRepository>()
                .Ctor<IMapper>()
                .Named("VacancyMappers");
        }
    }
}