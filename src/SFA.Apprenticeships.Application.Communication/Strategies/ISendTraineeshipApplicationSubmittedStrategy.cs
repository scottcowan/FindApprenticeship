namespace SFA.Apprenticeships.Application.Communication.Strategies
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Interfaces.Communications;

    public interface ISendTraineeshipApplicationSubmittedStrategy
    {
        Task Send(Guid candidateId, IEnumerable<CommunicationToken> tokens);
    }
}
