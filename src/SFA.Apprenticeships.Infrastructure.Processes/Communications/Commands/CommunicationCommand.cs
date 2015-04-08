﻿namespace SFA.Apprenticeships.Infrastructure.Processes.Communications.Commands
{
    using System.Collections.Generic;
    using System.Linq;
    using Application.Interfaces.Communications;
    using Domain.Interfaces.Messaging;

    public abstract class CommunicationCommand
    {
        private readonly IMessageBus _messageBus;

        protected CommunicationCommand(IMessageBus messageBus)
        {
            _messageBus = messageBus;
        }

        public abstract bool CanHandle(CommunicationRequest communicationRequest);

        public abstract void Handle(CommunicationRequest communicationRequest);

        protected void QueueEmailMessage(CommunicationRequest message)
        {
            var toEmail = message.Tokens.First(token => token.Key == CommunicationTokens.RecipientEmailAddress).Value;

            var request = new EmailRequest
            {
                ToEmail = toEmail,
                MessageType = message.MessageType,
                Tokens = GetChannelAgnosticTokens(message),
            };

            _messageBus.PublishMessage(request);
        }

        protected void QueueSmsMessage(CommunicationRequest message)
        {
            var toMobile = message.Tokens.First(token => token.Key == CommunicationTokens.CandidateMobileNumber).Value;

            var request = new SmsRequest
            {
                ToNumber = toMobile,
                MessageType = message.MessageType,
                Tokens = GetChannelAgnosticTokens(message),
            };

            _messageBus.PublishMessage(request);
        }

        private static IEnumerable<CommunicationToken> GetChannelAgnosticTokens(CommunicationRequest message)
        {
            return message.Tokens
                .Where(token => token.Key != CommunicationTokens.RecipientEmailAddress &&
                    token.Key != CommunicationTokens.CandidateMobileNumber);
        }
    }
}
