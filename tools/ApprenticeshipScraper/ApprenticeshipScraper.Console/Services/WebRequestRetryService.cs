﻿namespace ApprenticeshipScraper.CmdLine.Services
{
    using System;

    using Polly;

    public sealed class WebRequestRetryService : IRetryWebRequests
    {
        public T RetryWeb<T>(Func<T> action, Action<Exception> onError)
        {
            var policy = Policy.Handle<Exception>()
                .WaitAndRetry(
                    3,
                    retrytime => TimeSpan.FromSeconds(Math.Pow(2, retrytime)),
                    (exception, timespan) => { onError.Invoke(exception); });

            return policy.Execute(action);
        }
    }
}