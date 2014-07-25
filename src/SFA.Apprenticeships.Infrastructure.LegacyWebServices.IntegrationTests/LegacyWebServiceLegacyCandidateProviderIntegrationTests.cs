﻿namespace SFA.Apprenticeships.Infrastructure.LegacyWebServices.IntegrationTests
{
    using System;
    using Common.IoC;
    using Domain.Entities.Candidates;
    using Domain.Entities.Locations;
    using FluentAssertions;
    using IoC;
    using NUnit.Framework;
    using Application.Candidate.Strategies;
    using StructureMap;

    public class LegacyWebServiceLegacyCandidateProviderIntegrationTests
    {
        private ILegacyCandidateProvider _legacyCandidateProvider;

        [SetUp]
        public void SetUp()
        {
            ObjectFactory.Initialize(x =>
            {
                x.AddRegistry<CommonRegistry>();
                x.AddRegistry<LegacyWebServicesRegistry>();
            });

            _legacyCandidateProvider = ObjectFactory.GetInstance<ILegacyCandidateProvider>();
        }

        //TODO: Rea-dd test once CAP respond.
        [Ignore("Legacy service not responding as expected - re-add once fixed CAP end")]
        [Test]
        public void ShouldCreateCandidateUsingLegacyCandidateProvider()
        {
            var candidate = new Candidate()
            {
                EntityId = Guid.NewGuid(),
                RegistrationDetails = new RegistrationDetails()
                {
                    FirstName = "FirstName",
                    LastName = "LastName",
                    EmailAddress = string.Format("{0}@gmail.com", Guid.NewGuid()),
                    DateOfBirth = new DateTime(1980, 06, 15),
                    PhoneNumber = "01221234567",
                    Address = new Address()
                    {
                        AddressLine1 = "103 Crawley Drive",
                        AddressLine3 = "Hemel Hempstead",
                        AddressLine4 = "Hertfordhsire",
                        Postcode = "HP2 6AL",
                        AddressLine2= "Hemel Hempstead"
                    },
                }
            };

           var result = _legacyCandidateProvider.CreateCandidate(candidate);

            result.Should().BeGreaterThan(0);
        }
    }
}
