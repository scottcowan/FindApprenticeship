﻿namespace SFA.Apprenticeships.Infrastructure.LegacyWebServices.IntegrationTests
{
    using System.Linq;
    using Application.Vacancy;
    using Application.VacancyEtl;
    using Common.IoC;
    using Domain.Entities.Exceptions;
    using Domain.Entities.Vacancies.Apprenticeships;
    using FluentAssertions;
    using IoC;
    using NUnit.Framework;
    using StructureMap;

    [TestFixture]
    public class GatewayVacancyDataProviderIntegrationTests
    {
        [SetUp]
        public void SetUp()
        {
#pragma warning disable 0618
            // TODO: AG: CRITICAL: NuGet package update on 2014-10-30.
            ObjectFactory.Initialize(x =>
            {
                x.AddRegistry<CommonRegistry>();
                x.AddRegistry<LegacyWebServicesRegistry>();
            });

            _vacancyDataProvider = ObjectFactory.GetInstance<IVacancyDataProvider<ApprenticeshipVacancyDetail>>();
            _vacancyIndexDataProvider = ObjectFactory.GetInstance<IVacancyIndexDataProvider>();
#pragma warning restore 0618
        }

        private IVacancyDataProvider<ApprenticeshipVacancyDetail> _vacancyDataProvider;
        private IVacancyIndexDataProvider _vacancyIndexDataProvider;

        [Test, Category("Integration"), Category("SmokeTests")]
        [ExpectedException(typeof(CustomException))]
        public void ShouldNotReturnVacancyDetailsForInvalidVacancyId()
        {
            var result = _vacancyDataProvider.GetVacancyDetails(-123);

            result.Should().BeNull();
        }

        [Test, Category("Integration"), Category("SmokeTests")]
        public void ShouldReturnVacancyDetailsForValidVacancyId()
        {
            var response = _vacancyIndexDataProvider.GetVacancySummaries(1);

            var firstOrDefault = response.ApprenticeshipSummaries.FirstOrDefault();

            if (firstOrDefault == null) return;

            var firstVacancyId = firstOrDefault.Id;
            var result = _vacancyDataProvider.GetVacancyDetails(firstVacancyId);
            result.Should().NotBeNull();
        }
    }
}