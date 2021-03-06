﻿namespace SFA.Apprenticeships.Data.Migrate.Faa.Entities.Mongo
{
    using System;
    using MongoDB.Bson.Serialization.Attributes;

    [BsonIgnoreExtraElements]
    public class Candidate : CandidateSummary
    {
        public Candidate()
        {
            CommunicationPreferences = new CommunicationPreferences();
        }

        public DateTime DateCreated { get; set; }

        public DateTime? DateUpdated { get; set; }

        public RegistrationDetails RegistrationDetails { get; set; }

        public ApplicationTemplate ApplicationTemplate { get; set; }

        public CommunicationPreferences CommunicationPreferences { get; set; }

        public MonitoringInformation MonitoringInformation { get; set; }
    }
}