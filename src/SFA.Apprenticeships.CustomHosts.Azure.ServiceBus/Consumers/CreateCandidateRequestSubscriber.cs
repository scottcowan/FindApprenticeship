﻿namespace SFA.Apprenticeships.CustomHosts.Azure.ServiceBus.Consumers
{
    using System;
    using Application.Candidate;
    using Domain.Interfaces.Messaging;

    public class CreateCandidateRequestSubscriber : IServiceBusSubscriber<CreateCandidateRequest>
    {
        [ServiceBusTopicSubscription(TopicName = "candidate-create", SubscriptionName = "create")]
        public ServiceBusMessageResult Consume(CreateCandidateRequest message)
        {
            Console.WriteLine("CREATE: CreateCandidateRequest: {0}", message.CandidateId);

            return ServiceBusMessageResult.Complete();
        }
    }
}