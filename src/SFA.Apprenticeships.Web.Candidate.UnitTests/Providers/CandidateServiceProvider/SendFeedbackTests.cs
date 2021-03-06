﻿namespace SFA.Apprenticeships.Web.Candidate.UnitTests.Providers.CandidateServiceProvider
{
    using System;
    using SFA.Infrastructure.Interfaces;
    using Application.Interfaces.Candidates;
    using Candidate.Providers;
    using Candidate.ViewModels.Home;
    using Domain.Entities.Communication;
    using FluentAssertions;
    using Moq;
    using NUnit.Framework;

    using SFA.Apprenticeships.Application.Interfaces;

    [TestFixture]
    [Parallelizable]
    public class SendFeedbackTests
    {
        private Mock<ICandidateService> _candidateServiceMock;
        private Mock<IMapper> _mapperMock;

        [SetUp]
        public void SetUp()
        {
            _candidateServiceMock = new Mock<ICandidateService>();
            _mapperMock = new Mock<IMapper>();
        }

        [Test]
        public void SendMessageOk()
        {
            var candidateId = Guid.NewGuid();

            var candidateServiceProvider = new CandidateServiceProvider(
                _candidateServiceMock.Object, null, null, null, _mapperMock.Object, null, null);

            _mapperMock.Setup(m => m.Map<FeedbackViewModel, ContactMessage>(It.IsAny<FeedbackViewModel>()))
                .Returns(new ContactMessage());

            var result = candidateServiceProvider.SendFeedback(candidateId, new FeedbackViewModel());

            result.Should().BeTrue();
            _candidateServiceMock.Verify(cs => cs.SubmitContactMessage(It.Is<ContactMessage>(cm => cm.UserId == candidateId)));
        }

        [Test]
        public void SendMessageFail()
        {
            var candidateId = Guid.NewGuid();

            var candidateServiceProvider = new CandidateServiceProvider(
                _candidateServiceMock.Object, null, null, null, _mapperMock.Object, null, null);

            _mapperMock.Setup(m => m.Map<FeedbackViewModel, ContactMessage>(It.IsAny<FeedbackViewModel>()))
                .Returns(new ContactMessage());

            _candidateServiceMock.Setup(cs => cs.SubmitContactMessage(It.IsAny<ContactMessage>()))
                .Throws<ArgumentException>();

            var result = candidateServiceProvider.SendFeedback(candidateId, new FeedbackViewModel());

            result.Should().BeFalse();
        }
    }
}