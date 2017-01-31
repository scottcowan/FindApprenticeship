namespace SFA.DAS.RAA.Api.Service.V1.IoC
{
    using Apprenticeships.Application.Interfaces.Providers;
    using Apprenticeships.Application.Interfaces.ReferenceData;
    using Apprenticeships.Application.Interfaces.Vacancy;
    using Apprenticeships.Application.Interfaces.VacancyPosting;
    using Provider;
    using ReferenceData;
    using StructureMap.Configuration.DSL;
    using Vacancy;
    using VacancyPosting;

    public class ApiServiceRegistry : Registry
    {
        public ApiServiceRegistry()
        {
            For<IProviderService>().Use<ApiProviderService>();
            For<IReferenceDataService>().Use<ApiReferenceDataService>();
            For<IVacancyManagementService>().Use<ApiVacancyManagementService>();
            For<IProviderService>().Use<ApiProviderService>();
            For<IVacancyPostingService>().Use<ApiVacancyPostingService>();
        }
    }
}