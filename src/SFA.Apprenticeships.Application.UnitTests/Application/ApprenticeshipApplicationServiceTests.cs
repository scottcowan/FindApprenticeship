﻿namespace SFA.Apprenticeships.Application.UnitTests.Application
{
    using System;
    using Apprenticeships.Application.Application;
    using Apprenticeships.Application.Application.Strategies.Apprenticeships;
    using Apprenticeships.Application.Applications.Entities;
    using Apprenticeships.Application.Applications.Strategies;
    using Domain.Entities.Applications;
    using Domain.Entities.Vacancies;
    using Domain.Entities.Vacancies.Apprenticeships;
    using Domain.Interfaces.Repositories;
    using FluentAssertions;
    using Moq;
    using NUnit.Framework;

    [TestFixture]
    public class ApprenticeshipApplicationServiceTests
    {
        private Mock<IApprenticeshipApplicationReadRepository> _mockApprenticeshipApplicationReadRepository;
        private Mock<IReferenceNumberRepository> _mockReferenceNumberRepository;
        private Mock<IGetApplicationForReviewStrategy> _mockGetApplicationForReviewStrategy;
        private Mock<IUpdateApplicationNotesStrategy> _mockUpdateApplicationNotesStrategy;
        private Mock<IApplicationStatusUpdateStrategy> _mockApplicationStatusUpdateStrategy;

        private ApprenticeshipApplicationService _apprenticeshipApplicationService;

        [SetUp]
        public void SetUp()
        {
            _mockApprenticeshipApplicationReadRepository = new Mock<IApprenticeshipApplicationReadRepository>();
            _mockReferenceNumberRepository = new Mock<IReferenceNumberRepository>();
            _mockGetApplicationForReviewStrategy = new Mock<IGetApplicationForReviewStrategy>();
            _mockUpdateApplicationNotesStrategy = new Mock<IUpdateApplicationNotesStrategy>();
            _mockApplicationStatusUpdateStrategy = new Mock<IApplicationStatusUpdateStrategy>();

            _apprenticeshipApplicationService = new ApprenticeshipApplicationService(
                _mockApprenticeshipApplicationReadRepository.Object,
                _mockReferenceNumberRepository.Object,
                _mockGetApplicationForReviewStrategy.Object,
                _mockUpdateApplicationNotesStrategy.Object,
                _mockApplicationStatusUpdateStrategy.Object);
        }

        [TestCase(ApplicationStatuses.Successful)]
        [TestCase(ApplicationStatuses.Unsuccessful)]
        public void ShouldSetSuccessfulOutcome(ApplicationStatuses applicationStatus)
        {
            // Arrange.
            var applicationId = Guid.NewGuid();
            const int nextLegacyApplicationId = 2;

            var apprenticeshipApplicationDetail = new ApprenticeshipApplicationDetail
            {
                VacancyStatus = VacancyStatuses.Live,
                Vacancy = new ApprenticeshipSummary
                {
                    ClosingDate = DateTime.Today.AddDays(90)
                }
            };

            _mockApprenticeshipApplicationReadRepository.Setup(mock =>
                mock.Get(applicationId)).Returns(apprenticeshipApplicationDetail);

            var actualApplicationStatusSummary = default(ApplicationStatusSummary);

            _mockReferenceNumberRepository.Setup(mock =>
                mock.GetNextLegacyApplicationId())
                .Returns(nextLegacyApplicationId);

            _mockApplicationStatusUpdateStrategy.Setup(mock =>
                mock.Update(apprenticeshipApplicationDetail, It.IsAny<ApplicationStatusSummary>()))
                .Callback<ApprenticeshipApplicationDetail, ApplicationStatusSummary>(
                    (aad, ass) =>
                    {
                        actualApplicationStatusSummary = ass;
                    });

            // Act.
            switch (applicationStatus)
            {
                case ApplicationStatuses.Successful:
                    _apprenticeshipApplicationService.SetSuccessfulDecision(applicationId);
                    break;

                case ApplicationStatuses.Unsuccessful:
                    _apprenticeshipApplicationService.SetUnsuccessfulDecision(applicationId);
                    break;
            }

            // Assert.
            _mockApplicationStatusUpdateStrategy.Verify(mock => mock.Update(apprenticeshipApplicationDetail, It.IsAny<ApplicationStatusSummary>()), Times.Once);

            actualApplicationStatusSummary.Should().NotBeNull();

            actualApplicationStatusSummary.ShouldBeEquivalentTo(new ApplicationStatusSummary
            {
                ApplicationId = Guid.Empty,
                ApplicationStatus = applicationStatus,
                LegacyApplicationId = nextLegacyApplicationId,
                LegacyCandidateId = 0,
                LegacyVacancyId = 0,
                VacancyStatus = apprenticeshipApplicationDetail.VacancyStatus,
                ClosingDate = apprenticeshipApplicationDetail.Vacancy.ClosingDate
            });
        }
    }
}