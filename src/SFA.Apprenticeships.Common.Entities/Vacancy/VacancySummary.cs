﻿using System;
using System.ComponentModel;
using SFA.Apprenticeships.Common.Entities.Attributes.Elasticsearch;
using SFA.Apprenticeships.Common.Entities.Elasticsearch;
using SFA.Apprenticeships.Common.Interfaces.Elasticsearch;
using SFA.Apprenticeships.Common.Interfaces.Enums;
using SFA.Apprenticeships.Common.Interfaces.Enums.Elasticsearch;

namespace SFA.Apprenticeships.Common.Entities.Vacancy
{
    [ElasticsearchMapping(Document = "vacancy", Index = "legacy")]
    public class VacancySummary : VacancyId
    {
        public VacancySummary()
        {
            Location = new GeoPoint();
        }

        [Description("ApprenticeshipFramework")]
        public string Framework { get; set; }

        [Description("VacancyTitle")]
        [ElasticsearchIndex(Name = "fulltitle", Index = ElasticsearchIndexType.NotAnalyzed)]
        public string Title { get; set; }

        [Description("VacancyType")]
        [ElasticsearchType("string")]
        public VacancyType TypeOfVacancy { get; set; }

        [Description("CreatedDateTime")]
        [ElasticsearchType(Name = "date", Format = "dateOptionalTime")]
        public DateTime Created { get; set; }

        [Description("ClosingDate")]
        [ElasticsearchType(Name = "date", Format = "dateOptionalTime")]
        public DateTime ClosingDate { get; set; }

        [Description("EmployerName")]
        public string EmployerName { get; set; }

        [Description("LearningProviderName")]
        public string ProviderName { get; set; }

        [Description("NumberOfPositions")]
        [ElasticsearchIndex(Index = ElasticsearchIndexType.NotIndexed)]
        public int NumberOfPositions { get; set; }

        [Description("ShortDescription")]
        public string Description { get; set; }

        [Description("AddressLine1")]
        public string AddressLine1 { get; set; }

        [Description("AddressLine2")]
        public string AddressLine2 { get; set; }

        [Description("AddressLine3")]
        public string AddressLine3 { get; set; }

        [Description("AddressLine4")]
        public string AddressLine4 { get; set; }

        [Description("AddressLine5")]
        public string AddressLine5 { get; set; }

        [Description("Town")]
        public string Town { get; set; }

        [Description("County")]
        public string County { get; set; }

        [Description("PostCode")]
        public string PostCode { get; set; }

        [Description("LocalAuthority")]
        public string LocalAuthority { get; set; }

        [ElasticsearchType("geo_point")]
        public IGeoPoint Location { get; set; }

        [Description("VacancyLocationType")]
        [ElasticsearchType("string")]
        public VacancyLocationType TypeOfLocation { get; set; }

        [Description("VacancyUrl")]
        [ElasticsearchIndex(Index = ElasticsearchIndexType.NotIndexed)]
        public string VacancyUrl { get; set; }
    }
}