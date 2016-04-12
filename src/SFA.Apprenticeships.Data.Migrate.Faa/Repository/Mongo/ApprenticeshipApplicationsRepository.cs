﻿namespace SFA.Apprenticeships.Data.Migrate.Faa.Repository.Mongo
{
    using System;
    using System.Threading.Tasks;
    using Entities.Mongo;
    using Infrastructure.Repositories.Mongo.Common.Configuration;
    using MongoDB.Driver;
    using SFA.Infrastructure.Interfaces;

    public class ApprenticeshipApplicationsRepository
    {
        private readonly IMongoDatabase _database;

        public ApprenticeshipApplicationsRepository(IConfigurationService configurationService)
        {
            var connectionString = configurationService.Get<MongoConfiguration>().MetricsApplicationsDb;
            var databaseName = MongoUrl.Create(connectionString).DatabaseName;
            _database = new MongoClient(connectionString).GetDatabase(databaseName);
        }

        /// <summary>
        /// Returns all applications apart from those in the saved state
        /// </summary>
        /// <param name="lastId">Pass null or empty for the first page or the Id of the last item in the current page</param>
        public async Task<IAsyncCursor<ApprenticeshipApplication>> GetApprenticeshipApplicationsPageAsync(Guid? lastId)
        {
            //http://stackoverflow.com/questions/31675598/how-to-efficiently-page-batches-of-results-with-mongodb

            FilterDefinition<ApprenticeshipApplication> filter;
            var filterBuilder = Builders<ApprenticeshipApplication>.Filter;
            if (lastId == null || lastId == Guid.Empty)
            {
                filter = filterBuilder.Gte(a => a.Status, 10);
            }
            else
            {
                filter = filterBuilder.Gte(a => a.Status, 10) & filterBuilder.Gt(a => a.Id, lastId.Value);
            }

            var sort = Builders<ApprenticeshipApplication>.Sort.Ascending(a => a.Id);
            var options = new FindOptions<ApprenticeshipApplication>
            {
                Sort = sort,
                Limit = 5000
            };

            var cursor = _database.GetCollection<ApprenticeshipApplication>("apprenticeships").FindAsync(filter, options);
            return await cursor;
        }
    }
}