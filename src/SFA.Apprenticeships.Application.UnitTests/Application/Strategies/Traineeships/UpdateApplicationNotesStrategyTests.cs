﻿namespace SFA.Apprenticeships.Application.UnitTests.Application.Strategies.Traineeships
{
    using System;
    using Domain.Interfaces.Messaging;
    using Domain.Interfaces.Repositories;
    using Moq;
    using NUnit.Framework;
    using SFA.Apprenticeships.Application.Application.Entities;
    using SFA.Apprenticeships.Application.Application.Strategies.Traineeships;

    [TestFixture]
    public class UpdateApplicationNotesStrategyTests
    {
        private Mock<ITraineeshipApplicationWriteRepository> _mockTraineeshipApplicationWriteRepository;
        private Mock<IServiceBus> _mockServiceBus;

        private UpdateApplicationNotesStrategy _updateApplicationNotesStrategy;

        [SetUp]
        public void SetUp()
        {
            _mockTraineeshipApplicationWriteRepository = new Mock<ITraineeshipApplicationWriteRepository>();
            _mockServiceBus = new Mock<IServiceBus>();

            _updateApplicationNotesStrategy = new UpdateApplicationNotesStrategy(_mockTraineeshipApplicationWriteRepository.Object, _mockServiceBus.Object);
        }

        [TestCase(true)]
        [TestCase(false)]
        public void UpdateApplicationNotes_PostMessage(bool publishUpdate)
        {
            var applicationId = Guid.NewGuid();

            _updateApplicationNotesStrategy.UpdateApplicationNotes(applicationId, "Note", publishUpdate);

            if (publishUpdate)
            {
                _mockServiceBus.Verify(
                    sb =>
                        sb.PublishMessage(It.Is<TraineeshipApplicationUpdate>(m => m.ApplicationGuid == applicationId)), Times.Once);
            }
            else
            {
                _mockServiceBus.Verify(
                    sb =>
                        sb.PublishMessage(It.Is<TraineeshipApplicationUpdate>(m => m.ApplicationGuid == applicationId)), Times.Never);
            }
        }
    }
}