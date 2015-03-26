﻿namespace SFA.Apprenticeships.Infrastructure.Processes.Vacancies
{
    using System.Threading.Tasks;
    using Application.Applications;
    using Application.Applications.Entities;
    using Configuration;
    using Domain.Interfaces.Caching;
    using Domain.Interfaces.Configuration;
    using EasyNetQ.AutoSubscribe;
    using Extensions;

    public class VacancyStatusSummaryConsumerAsync : IConsumeAsync<VacancyStatusSummary>
    {
        private readonly ICacheService _cacheService;
        private readonly IApplicationStatusProcessor _applicationStatusProcessor;
        private readonly bool _enableVacancyStatusPropagation;

        public VacancyStatusSummaryConsumerAsync(ICacheService cacheService, IApplicationStatusProcessor applicationStatusProcessor, 
            IConfigurationService configurationService)
        {
            _cacheService = cacheService;
            _applicationStatusProcessor = applicationStatusProcessor;
            _enableVacancyStatusPropagation = configurationService.Get<ProcessConfiguration>(ProcessConfiguration.ConfigurationName).EnableVacancyStatusPropagation;
        }

        [SubscriptionConfiguration(PrefetchCount = 20)]
        [AutoSubscriberConsumer(SubscriptionId = "VacancyStatusSummaryConsumerAsync")]
        public Task Consume(VacancyStatusSummary message)
        {
            return Task.Run(() =>
            {
                if (!_enableVacancyStatusPropagation) return;

                var cachedSummaryUpdate = _cacheService.Get<VacancyStatusSummary>(message.CacheKey());

                if (cachedSummaryUpdate != null)
                {
                    return; // this vacancy has already been processed so return to prevent endless reprocessing
                }

                _cacheService.PutObject(message.CacheKey(), message, message.CacheDuration());

                _applicationStatusProcessor.ProcessApplicationStatuses(message);
            });
        }
    }
}
