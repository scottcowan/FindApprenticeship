﻿using SFA.Apprenticeships.Infrastructure.Common.Helpers;

namespace SFA.Apprenticeships.Infrastructure.Elasticsearch.Service
{
    using System;
    using System.Net;
    using Newtonsoft.Json;
    using RestSharp;
    using RestSharp.Extensions;
    using SFA.Apprenticeships.Application.Interfaces.Search;
    using SFA.Apprenticeships.Infrastructure.Elasticsearch.Entities.Attributes;
    using SFA.Apprenticeships.Infrastructure.Elasticsearch.Interfaces;
    using SFA.Apprenticeships.Infrastructure.Elasticsearch.Mapping;

    public class IndexingService<TSource> : IIndexingService<TSource>
    {
        private readonly IElasticsearchService _elasticsearchService;
        
        public readonly ElasticsearchMappingAttribute Mapping;

        public IndexingService(IElasticsearchService elasticsearchService)
        {
            if (elasticsearchService == null)
            {
                throw new ArgumentNullException("elasticsearchService");
            }

            _elasticsearchService = elasticsearchService;
            Mapping = GetMappingAttribute();
            Setup();
        }

        /// <summary>
        /// Checks the mappings on the es database to verify the database is setup.
        /// If not, creates the index and mappings.
        /// </summary>
        private void Setup()
        {
            var mappings = ElasticsearchMapping.Create<TSource>();
            var attribute = GetMappingAttribute();

            var rs = _elasticsearchService.Execute(Method.PUT, attribute.Index);
            if (rs.StatusCode != HttpStatusCode.OK)
            {
                if (!rs.Content.Contains("IndexAlreadyExistsException"))
                {
                    throw new ApplicationException(
                        string.Format("Elasticsearch service returned code '{0}' when writing index. Content: {1}", rs.StatusCode, rs.Content));
                }
            }

            rs = _elasticsearchService.Execute(attribute.Index, attribute.Document, "_mapping", mappings);
            if (rs.StatusCode != HttpStatusCode.OK)
            {
                throw new ApplicationException(
                    string.Format("Elasticsearch service returned code '{0}' when writing mappings. Content: {1}", rs.StatusCode, rs.Content));
            }
        }

        public void Index(string id, TSource objectToIndex)
        {
            var json = JsonConvert.SerializeObject(objectToIndex, new EnumToStringConverter());

            var rs =
                _elasticsearchService.Execute(
                    Mapping.Index,
                    Mapping.Document,
                    id,
                    json);

            if (rs.StatusCode != HttpStatusCode.OK)
            {
                // TODO::High::Log error
            }
        }

        private static ElasticsearchMappingAttribute GetMappingAttribute()
        {
            // look for the elasticsearch mapping attribute on the class T
            // find the index and document properties to form the es command
            var mapping = typeof(TSource).GetAttribute<ElasticsearchMappingAttribute>();
            if (mapping == null || string.IsNullOrEmpty(mapping.Document) || string.IsNullOrEmpty(mapping.Index))
            {
                throw
                    new ArgumentException(
                        "The generic type must have the ElasticsearchMapping attribute applied with Document and Index properties.");
            }

            return mapping;
        }
    }
}
