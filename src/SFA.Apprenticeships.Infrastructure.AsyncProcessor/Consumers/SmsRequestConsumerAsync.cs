﻿namespace SFA.Apprenticeships.Infrastructure.AsyncProcessor.Consumers
{
    using System;
    using System.Threading.Tasks;
    using Application.Interfaces.Communications;
    using Application.Interfaces.Logging;
    using Domain.Interfaces.Messaging;
    using EasyNetQ.AutoSubscribe;
    using Newtonsoft.Json;

    public class SmsRequestConsumerAsync : IConsumeAsync<SmsRequest>
    {
        private readonly ILogService _logger;
        private readonly IMessageBus _messageBus;
        private readonly ISmsDispatcher _dispatcher;

        public SmsRequestConsumerAsync(
            ILogService logger,
            IMessageBus messageBus,
            ISmsDispatcher dispatcher)
        {
            _logger = logger;
            _messageBus = messageBus;
            _dispatcher = dispatcher;
        }

        [SubscriptionConfiguration(PrefetchCount = 20)]
        [AutoSubscriberConsumer(SubscriptionId = "SmsRequestConsumerAsync")]
        public Task Consume(SmsRequest request)
        {
            return Task.Run(() =>
            {
                if (request.ProcessTime.HasValue && request.ProcessTime > DateTime.Now)
                {
                    try
                    {
                        _messageBus.PublishMessage(request);
                        return;
                    }
                    catch
                    {
                        _logger.Error("Failed to re-queue SMS request: {0}", JsonConvert.SerializeObject(request, Formatting.None));
                        throw;
                    }
                }

                SendSms(request);
            });
        }

        private void SendSms(SmsRequest request)
        {
            try
            {
                _dispatcher.SendSms(request);
            }
            catch (Exception)
            {
                Requeue(request);
            }
        }

        private void Requeue(SmsRequest request)
        {
            request.ProcessTime = request.ProcessTime.HasValue ? DateTime.Now.AddMinutes(5) : DateTime.Now.AddSeconds(30);

            _messageBus.PublishMessage(request);
        }
    }
}
