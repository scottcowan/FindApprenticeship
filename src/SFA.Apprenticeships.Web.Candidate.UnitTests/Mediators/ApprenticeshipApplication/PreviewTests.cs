﻿namespace SFA.Apprenticeships.Web.Candidate.UnitTests.Mediators.ApprenticeshipApplication
{
    using System;
    using Candidate.Mediators;
    using Candidate.Providers;
    using Candidate.ViewModels.Applications;
    using Common.Providers;
    using Domain.Interfaces.Configuration;
    using Moq;
    using NUnit.Framework;

    [TestFixture]
    public class PreviewTests : TestsBase
    {
        private const int ValidVacancyId = 1;
        private const int InvalidVacancyId = 99999;

        [Test]
        public void HasError()
        {
            var mediator = GetMediator();

            var response = mediator.Preview(Guid.NewGuid(), InvalidVacancyId);

            response.AssertCode(Codes.ApprenticeshipApplication.Preview.HasError, false);
        }

        [Test]
        public void Ok()
        {
            var mediator = GetMediator();

            var response = mediator.Preview(Guid.NewGuid(), ValidVacancyId);

            response.AssertCode(Codes.ApprenticeshipApplication.Preview.Ok, true);
        }

        private static IApprenticeshipApplicationMediator GetMediator()
        {
            var apprenticeshipApplicationProvider = new Mock<IApprenticeshipApplicationProvider>();
            apprenticeshipApplicationProvider.Setup(p => p.GetApplicationViewModel(It.IsAny<Guid>(), ValidVacancyId)).Returns(new ApprenticeshipApplicationViewModel());
            apprenticeshipApplicationProvider.Setup(p => p.GetApplicationViewModel(It.IsAny<Guid>(), InvalidVacancyId)).Returns(new ApprenticeshipApplicationViewModel("Vacancy not found"));
            var configurationManager = new Mock<IConfigurationManager>();
            var userDataProvider = new Mock<IUserDataProvider>();
            var mediator = GetMediator(apprenticeshipApplicationProvider.Object, configurationManager.Object, userDataProvider.Object);
            return mediator;
        }
    }
}