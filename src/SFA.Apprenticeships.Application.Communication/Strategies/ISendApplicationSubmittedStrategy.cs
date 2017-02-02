namespace SFA.Apprenticeships.Application.Communication.Strategies
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Interfaces.Communications;

    public interface ISendApplicationSubmittedStrategy
    {
        Task Send(Guid candidateId, IEnumerable<CommunicationToken> tokens);
    }
}
