namespace SFA.Apprenticeships.Web.Manage.Providers
{
    using System;
    using System.Security.Claims;
    using Application.Interfaces;
    using Application.Interfaces.Api;
    using Application.Interfaces.Users;
    using DAS.RAA.Api.Client.V1;
    using Domain.Entities.Exceptions;
    using Domain.Entities.Raa.RaaApi;
    using Domain.Raa.Interfaces.Repositories;
    using Infrastructure.Common.Configuration;
    using Microsoft.Rest;
    using ClaimTypes = Domain.Entities.Raa.ClaimTypes;

    public class ApiClientProvider : IApiClientProvider
    {
        private readonly IConfigurationService _configurationService;
        private readonly ICurrentUserService _currentUserService;
        private readonly IUserProfileService _userProfileService;
        private readonly IRaaApiUserRepository _raaApiUserRepository;
        private readonly ILogService _logService;

        public ApiClientProvider(IConfigurationService configurationService, ICurrentUserService currentUserService, IUserProfileService userProfileService, IRaaApiUserRepository raaApiUserRepository, ILogService logService)
        {
            _configurationService = configurationService;
            _currentUserService = currentUserService;
            _userProfileService = userProfileService;
            _raaApiUserRepository = raaApiUserRepository;
            _logService = logService;
        }

        public IApiClient GetApiClient()
        {
            var baseUrl = _configurationService.Get<ApiConfiguration>().ApiBaseUrl;
            var apiKey = _currentUserService.GetClaimValue(ClaimTypes.RaaApiKey);
            if (string.IsNullOrEmpty(apiKey))
            {
                var agencyUser = _userProfileService.GetAgencyUser(_currentUserService.CurrentUserName);
                var apiUser = _raaApiUserRepository.GetUserByReferencedEntityGuid(agencyUser.AgencyUserGuid);
                if (apiUser == null || ReferenceEquals(apiUser, RaaApiUser.UnknownApiUser))
                {
                    var message = $"No RAA API key found for current principal {_currentUserService.CurrentUserName}";
                    _logService.Error(message);
                    throw new CustomException(message);
                }
                apiKey = apiUser.PrimaryApiKey.ToString();
                _currentUserService.AddClaim(new Claim(ClaimTypes.RaaApiKey, apiKey));
            }
            var apiClient = new ApiClient(new Uri(baseUrl), new TokenCredentials(apiKey, "bearer"));
            return apiClient;
        }

        public bool IsEnabled()
        {
            return _configurationService.Get<ApiConfiguration>().IsEnabled;
        }
    }
}