﻿namespace SFA.Apprenticeships.Application.Services.Communication.Strategies.Interfaces
{
    using System.Collections.Generic;
    using Application.Interfaces.Communications;

    public interface ISendEmployerEnquiryStrategy
    {
        void SendMessageToHelpdesk(MessageTypes messageType, IEnumerable<CommunicationToken> tokens);
        void SendMessageToApplicant(MessageTypes messageType, IEnumerable<CommunicationToken> tokens);
    }
}