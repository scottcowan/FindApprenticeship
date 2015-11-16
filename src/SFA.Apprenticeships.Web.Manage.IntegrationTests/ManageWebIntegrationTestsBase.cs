﻿namespace SFA.Apprenticeships.Web.Manage.IntegrationTests
{
    using System.Security.Principal;
    using System.Threading;
    using Domain.Interfaces.Configuration;
    using Infrastructure.Mongo.Common.Configuration;
    using Infrastructure.Repositories.Vacancies.Entities;
    using IoC;
    using MongoDB.Driver;
    using NUnit.Framework;
    using StructureMap;

    public class ManageWebIntegrationTestsBase
    {
        protected MongoConfiguration MongoConfiguration;
        protected IContainer Container;
        protected MongoCollection<MongoApprenticeshipVacancy> Collection;
        protected string QaUserName = "qaUserName";

        [SetUp]
        public void SetUpContainer()
        {
            Container = IoC.Initialize();

            var configurationManager = Container.GetInstance<IConfigurationService>();
            MongoConfiguration = configurationManager.Get<MongoConfiguration>();

            Thread.CurrentPrincipal = new GenericPrincipal(new GenericIdentity(QaUserName), null);
        }

        [TearDown]
        public void TearDown()
        {
            if (Collection != null)
                Collection.RemoveAll();
        }
    }
}