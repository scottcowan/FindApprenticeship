﻿using System.Linq;

namespace SFA.Apprenticeships.Infrastructure.IntegrationTests.Raa
{
    using Application.ReferenceData;

    using Common.IoC;
    using Domain.Entities.ReferenceData;
    using FluentAssertions;
    using Infrastructure.Raa.IoC;
    using Logging.IoC;
    using NUnit.Framework;
    using Repositories.Sql.Configuration;
    using Repositories.Sql.IoC;
    using Application.Interfaces;
    using StructureMap;

    [TestFixture]
    public class ReferenceDataProviderTests
    {
        private IReferenceDataProvider _referenceDataProvider;

        [SetUp]
        public void SetUp()
        {
            var container = new Container(x =>
            {
                x.AddRegistry<CommonRegistry>();
                x.AddRegistry<LoggingRegistry>();
            });

            var configurationService = container.GetInstance<IConfigurationService>();
            var sqlConfiguration = configurationService.Get<SqlConfiguration>();

            container = new Container(x =>
            {
                x.AddRegistry<LoggingRegistry>();
                x.AddRegistry<SourceRegistry>();
                x.AddRegistry(new RepositoriesRegistry(sqlConfiguration));
                x.AddRegistry<RaaRegistry>();
            });
            
            _referenceDataProvider = container.GetInstance<IReferenceDataProvider>();
        }


        [Test, Category("Integration")]
        public void ReturnsCategoryDataFromFrameworksService()
        {
            var categories = _referenceDataProvider.GetCategories();
            categories.Count().Should().BeGreaterThan(0);

            foreach (Category category in categories)
            {
                category.SubCategories.Count().Should().BeGreaterThan(0);
            }
        }

    }
}
