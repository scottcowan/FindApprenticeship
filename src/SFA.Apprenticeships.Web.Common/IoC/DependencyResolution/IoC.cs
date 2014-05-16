using SFA.Apprenticeships.Common.Caching;
using SFA.Apprenticeships.Common.Configuration;
using SFA.Apprenticeships.Services.Common.ActiveDirectory;
using SFA.Apprenticeships.Services.ReferenceData.DependencyResolution;
using SFA.Apprenticeships.Web.Common.Providers;
using StructureMap;
using StructureMap.Graph;

namespace SFA.Apprenticeships.Web.Common.IoC.DependencyResolution
{
    /// <summary>
    /// IoC Container
    /// </summary>
    public static class IoC
    {
        public static IContainer Initialize()
        {
            var container = ObjectFactory.Container;
            ObjectFactory.Initialize(
                x => x.Scan(
                    scan =>
                    {
                        scan.TheCallingAssembly();
                        scan.WithDefaultConventions();
                    }));

            container.LoadCommonConfiguration();
            container.LoadConfiguration();
            container.LoadWebConfiguration();

            return container;
        }

        private static IContainer LoadWebConfiguration(this IContainer container)
        {
            container.Configure(
                x =>
                {
                    x.For<IActiveDirectoryConfiguration>().Singleton().Use(ActiveDirectoryConfigurationSection.Instance);

                    // Use cache decorated provider.
                    x.For<IReferenceDataProvider>().Use<LegacyReferenceDataProvider>()
                        .DecorateWith((ctx, provider) => new CacheLegacyReferenceDataProvider(ctx.GetInstance<ICacheClient>(), provider));

                });

            return container;
        }

        private static IContainer LoadCommonConfiguration(this IContainer container)
        {
            container.Configure(
                x =>
                {
                    x.For<ICacheClient>().Singleton().Use<MemoryCacheClient>();

                    x.For<IConfigurationManager>().Singleton().Use<ConfigurationManager>()
                        .Ctor<string>("configFileAppSettingKey").Is(ConfigurationManager.ConfigurationFileAppSetting);

                });

            return container;
        }
    }
}