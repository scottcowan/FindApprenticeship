﻿namespace SFA.Apprenticeships.Web.Manage.IoC
{
    using System.Web;
    using Application.Communication;
    using Application.Communication.Strategies;
    using Application.Interfaces.Communications;
    using Application.Interfaces.Organisations;
    using Application.Interfaces.Users;
    using Application.Organisation;
    using Application.UserAccount;
    using Application.UserAccount.Strategies.ProviderUserAccount;
    using Common.Configuration;
    using Domain.Interfaces.Configuration;
    using Infrastructure.Common.IoC;
    using Infrastructure.Logging.IoC;
    using Mediators.AgencyUser;
    using Providers;
    using StructureMap;
    using StructureMap.Configuration.DSL;

    public class ManagementWebRegistry : Registry
    {
        public ManagementWebRegistry()
        {
            For<HttpContextBase>().Use(ctx => new HttpContextWrapper(HttpContext.Current));

            RegisterCodeGenerators();
            RegisterServices();
            RegisterStrategies();
            RegisterProviders();
            RegisterMediators();
        }

        private void RegisterCodeGenerators()
        {
            For<ICodeGenerator>().Use<RandomCodeGenerator>().Name = "RandomCodeGenerator";
            For<ICodeGenerator>().Use<StaticCodeGenerator>().Name = "StaticCodeGenerator";
        }

        private void RegisterProviders()
        {
            For<ILegacyProviderProvider>().Use<StubLegacyProviderProvider>();
            For<IAgencyUserProvider>().Use<AgencyUserProvider>();
        }

        private void RegisterServices()
        {
            For<IOrganisationService>().Use<OrganisationService>();
            For<IProviderCommunicationService>().Use<ProviderCommunicationService>();
        }

        private void RegisterStrategies()
        {
            var settingsContainer = new Container(x =>
            {
                x.AddRegistry<LoggingRegistry>();
                x.AddRegistry<CommonRegistry>();
            });

            var configurationService = settingsContainer.GetInstance<IConfigurationService>();
            var codeGenerator = configurationService.Get<WebConfiguration>().CodeGenerator;

            For<ISendProviderUserCommunicationStrategy>().Use<QueueProviderUserCommunicationStrategy>();
            For<ISendEmailVerificationCodeStrategy>().Use<SendEmailVerificationCodeStrategy>()
                .Ctor<ICodeGenerator>().Named(codeGenerator);
            For<IResendEmailVerificationCodeStrategy>().Use<ResendEmailVerificationCodeStrategy>();
        }

        private void RegisterMediators()
        {
            For<IAgencyUserMediator>().Use<AgencyUserMediator>();
        }
    }
}