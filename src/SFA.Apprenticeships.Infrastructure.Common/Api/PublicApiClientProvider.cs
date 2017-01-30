namespace SFA.Apprenticeships.Web.Raa.Common.Providers
{
    using System;
    using Application.Interfaces;
    using Application.Interfaces.Api;
    using DAS.RAA.Api.Client.V1;
    using Infrastructure.Common.Configuration;
    using Microsoft.Rest;

    public class ApiClientProvider : IApiClientProvider
    {
        private readonly IConfigurationService _configurationService;

        public ApiClientProvider(IConfigurationService configurationService)
        {
            _configurationService = configurationService;
        }

        public IApiClient GetApiClient()
        {
            var baseUrl = _configurationService.Get<ApiConfiguration>().ApiBaseUrl;
            var apiClient = new ApiClient(new Uri(baseUrl), new TokenCredentials("", "bearer"));
            return apiClient;
        }
    }
}