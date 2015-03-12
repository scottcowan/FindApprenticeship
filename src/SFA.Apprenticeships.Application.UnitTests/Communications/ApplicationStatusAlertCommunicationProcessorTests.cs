﻿namespace SFA.Apprenticeships.Application.UnitTests.Communications
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Domain.Entities.Communication;
    using Domain.Entities.UnitTests.Builder;
    using Domain.Entities.Users;
    using Domain.Interfaces.Messaging;
    using Domain.Interfaces.Repositories;
    using Interfaces.Communications;
    using Moq;
    using NUnit.Framework;
    using Ploeh.AutoFixture;

    [TestFixture]
    public class ApplicationStatusAlertCommunicationProcessorTests
    {
        [Test]
        public void ShouldSendOneEmailPerCandidate()
        {
            var alerts = GetAlertCandidatesDailyDigest(2, 1);
            var drafts = GetExpiringDraftsCandidatesDailyDigest(2, 2);
            
            //Ensure the alerts and drafts share one candidate
            var candidateId = alerts.Keys.First();
            var draft = drafts.First();

            drafts.Remove(draft.Key);
            drafts[candidateId] = draft.Value;

            var applicationStatusAlertRepository = new Mock<IApplicationStatusAlertRepository>();

            applicationStatusAlertRepository.Setup(x => x.GetCandidatesDailyDigest()).Returns(alerts);

            var expiringDraftRepository = new Mock<IExpiringApprenticeshipApplicationDraftRepository>();

            expiringDraftRepository.Setup(r => r.GetCandidatesDailyDigest()).Returns(drafts);

            var candidateReadRepository = new Mock<ICandidateReadRepository>();
            var candidate = new CandidateBuilder(Guid.NewGuid()).AllowEmail(true).Build();

            candidateReadRepository.Setup(x => x.Get(It.IsAny<Guid>())).Returns(candidate);

            var userReadRepository = new Mock<IUserReadRepository>();
            var user = new UserBuilder(Guid.NewGuid()).WithStatus(UserStatuses.Active).Build();

            userReadRepository.Setup(x => x.Get(It.IsAny<Guid>())).Returns(user);

            var messageBus = new Mock<IMessageBus>();
            var processor = new CommunicationProcessorBuilder()
                .With(applicationStatusAlertRepository)
                .With(expiringDraftRepository)
                .With(candidateReadRepository)
                .With(userReadRepository)
                .With(messageBus)
                .Build();

            var batchId = Guid.NewGuid();

            processor.SendDailyDigests(batchId);
            messageBus.Verify(mb => mb.PublishMessage(It.IsAny<CommunicationRequest>()), Times.Exactly(3));
        }

        [Test]
        public void AllowNeitherEmailNorSmsShouldNotSendMessageAndDeleteAlerts()
        {
            var applicationStatusAlertRepository = new Mock<IApplicationStatusAlertRepository>();
            
            applicationStatusAlertRepository.Setup(x => x.GetCandidatesDailyDigest()).Returns(GetAlertCandidatesDailyDigest(2, 2));
            
            var candidateReadRepository = new Mock<ICandidateReadRepository>();
            var candidate = new CandidateBuilder(Guid.NewGuid()).AllowEmail(false).AllowMobile(false).Build();
            
            candidateReadRepository.Setup(x => x.Get(It.IsAny<Guid>())).Returns(candidate);

            var userReadRepository = new Mock<IUserReadRepository>();
            var user = new UserBuilder(candidate.EntityId).WithStatus(UserStatuses.Active).Build();

            userReadRepository.Setup(x => x.Get(It.IsAny<Guid>())).Returns(user);

            var processor = new CommunicationProcessorBuilder()
                .With(applicationStatusAlertRepository).With(candidateReadRepository).With(userReadRepository).Build();

            var batchId = Guid.NewGuid();
            
            processor.SendDailyDigests(batchId);

            applicationStatusAlertRepository.Verify(x => x.GetCandidatesDailyDigest(), Times.Once);
            candidateReadRepository.Verify(x => x.Get(It.IsAny<Guid>()), Times.Exactly(2));
            userReadRepository.Verify(x => x.Get(It.IsAny<Guid>()), Times.Exactly(2));
            applicationStatusAlertRepository.Verify(x => x.Delete(It.IsAny<ApplicationStatusAlert>()), Times.Exactly(4));
        }

        private static Dictionary<Guid, List<ApplicationStatusAlert>> GetAlertCandidatesDailyDigest(int noOfcandidates, int noOfAlerts)
        {
            var digest = new Dictionary<Guid, List<ApplicationStatusAlert>>();

            for (var i = 0; i < noOfcandidates; i++)
            {
                var candidateId = Guid.NewGuid();
                var alerts = new Fixture().Build<ApplicationStatusAlert>()
                    .With(asa => asa.CandidateId, candidateId)
                    .CreateMany(noOfAlerts).ToList();
                digest.Add(candidateId, alerts);
            }

            return digest;
        }

        private static Dictionary<Guid, List<ExpiringApprenticeshipApplicationDraft>> GetExpiringDraftsCandidatesDailyDigest(int noOfcandidates, int noOfAlerts)
        {
            var digest = new Dictionary<Guid, List<ExpiringApprenticeshipApplicationDraft>>();

            for (var i = 0; i < noOfcandidates; i++)
            {
                var candidateId = Guid.NewGuid();
                var alerts = new Fixture().Build<ExpiringApprenticeshipApplicationDraft>()
                    .With(asa => asa.CandidateId, candidateId)
                    .CreateMany(noOfAlerts).ToList();
                digest.Add(candidateId, alerts);
            }

            return digest;
        }
    }
}