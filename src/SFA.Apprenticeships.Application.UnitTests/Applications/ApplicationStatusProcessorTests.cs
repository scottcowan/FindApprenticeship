﻿namespace SFA.Apprenticeships.Application.UnitTests.Applications
{
    using System;
    using ApplicationUpdate;
    using ApplicationUpdate.Entities;
    using ApplicationUpdate.Strategies;
    using Domain.Entities.Applications;
    using Domain.Entities.Vacancies;
    using Domain.Interfaces.Messaging;
    using Domain.Interfaces.Repositories;
    using FizzWare.NBuilder;
    using Interfaces.Logging;
    using Moq;
    using NUnit.Framework;

    [TestFixture]
    public class ApplicationStatusProcessorTests
    {
        private ApplicationStatusProcessor _applicationStatusProcessor;
        private Mock<IApplicationStatusUpdateStrategy> _applicationStatusUpdateStrategy;
        private Mock<ILegacyApplicationStatusesProvider> _legacyApplicationStatusProvider;
        private Mock<IApprenticeshipApplicationReadRepository> _apprenticeshipApplicationReadMock;
        private Mock<ITraineeshipApplicationReadRepository> _traineeshipApplicationReadMock;
        private Mock<IMessageBus> _bus;
        private Mock<ILogService> _logger;

        public void SetUp()
        {
            _legacyApplicationStatusProvider = new Mock<ILegacyApplicationStatusesProvider>();
            _apprenticeshipApplicationReadMock = new Mock<IApprenticeshipApplicationReadRepository>();
            _traineeshipApplicationReadMock = new Mock<ITraineeshipApplicationReadRepository>();
            _applicationStatusUpdateStrategy = new Mock<IApplicationStatusUpdateStrategy>();
            _bus = new Mock<IMessageBus>();
            _logger = new Mock<ILogService>();
            _applicationStatusProcessor = new ApplicationStatusProcessor(_legacyApplicationStatusProvider.Object,
                _apprenticeshipApplicationReadMock.Object, _traineeshipApplicationReadMock.Object,
                _applicationStatusUpdateStrategy.Object, _bus.Object, _logger.Object);
        }

        [Test]
        public void ShouldQueueApplicationStatusSummaryForEachApplication()
        {
            //Would never get back from both app and trn but just checking right things are called
            var apprenticeshipApplicationSummaries = Builder<ApprenticeshipApplicationSummary>.CreateListOfSize(4).All().With(x=> x.LegacyVacancyId = 123).Build();
            var traineeshipApplicationSummaries = Builder<TraineeshipApplicationSummary>.CreateListOfSize(3).All().With(x => x.LegacyVacancyId = 123).Build();

            _bus.Setup(x => x.PublishMessage(It.IsAny<ApplicationStatusSummary>()));

            _apprenticeshipApplicationReadMock.Setup(
                x => x.GetApplicationSummaries(It.IsAny<int>()))
                .Returns(apprenticeshipApplicationSummaries);

            _traineeshipApplicationReadMock.Setup(
                x => x.GetApplicationSummaries(It.IsAny<int>()))
                .Returns(traineeshipApplicationSummaries);

            var closingDate = DateTime.Now.AddMonths(-2);
            _applicationStatusProcessor.ProcessApplicationStatuses(123, VacancyStatuses.Expired, closingDate);

            _apprenticeshipApplicationReadMock.Verify(
                x =>
                    x.GetApplicationSummaries(
                        It.Is<int>(id => id == 123)), Times.Once);

            _traineeshipApplicationReadMock.Verify(
                x =>
                    x.GetApplicationSummaries(
                        It.Is<int>(id => id == 123)), Times.Once);

            _bus.Verify(
                x =>
                    x.PublishMessage(
                        It.Is<ApplicationStatusSummary>(
                            ass =>
                                ass.LegacyVacancyId == 123 && ass.ClosingDate == closingDate &&
                                ass.VacancyStatus == VacancyStatuses.Expired)), Times.Exactly(7));
        }

    }
}
