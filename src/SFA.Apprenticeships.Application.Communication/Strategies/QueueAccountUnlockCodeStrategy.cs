﻿namespace SFA.Apprenticeships.Application.Communication.Strategies
{
    using System;
    using System.Collections.Generic;
    using Domain.Interfaces.Messaging;
    using Domain.Interfaces.Repositories;
    using Interfaces.Messaging;

    public class QueueAccountUnlockCodeStrategy : ISendAccountUnlockCodeStrategy
    {
        private readonly IMessageBus _messageBus;
        private readonly ICandidateReadRepository _candidateReadRepository;

        public QueueAccountUnlockCodeStrategy(IMessageBus messageBus, ICandidateReadRepository candidateReadRepository)
        {
            _messageBus = messageBus;
            _candidateReadRepository = candidateReadRepository;
        }

        public void Send(Guid candidateId, IEnumerable<KeyValuePair<CommunicationTokens, string>> tokens)
        {
            var candidate = _candidateReadRepository.Get(candidateId);

            //todo: change to CommunicationRequest
            var request = new EmailRequest
            {
                ToEmail = candidate.RegistrationDetails.EmailAddress,
                MessageType = MessageTypes.SendAccountUnlockCode,
                Tokens = tokens,
            };

            _messageBus.PublishMessage(request);
        }
    }
}
