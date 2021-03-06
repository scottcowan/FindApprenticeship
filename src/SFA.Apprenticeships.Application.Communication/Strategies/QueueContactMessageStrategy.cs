﻿namespace SFA.Apprenticeships.Application.Communication.Strategies
{
    using System;
    using System.Collections.Generic;
    using Interfaces.Communications;
    using Domain.Interfaces.Messaging;

    public class QueueContactMessageStrategy : ISendContactMessageStrategy
    {
        private readonly IServiceBus _serviceBus;

        public QueueContactMessageStrategy(IServiceBus serviceBus)
        {
            _serviceBus = serviceBus;
        }

        public void Send(Guid? userId, MessageTypes messageType, IEnumerable<CommunicationToken> tokens)
        {
            var request = new CommunicationRequest
            {
                EntityId = userId,
                MessageType = messageType,
                Tokens = tokens
            };

            _serviceBus.PublishMessage(request);
        }
    }
}
