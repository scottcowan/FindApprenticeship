namespace SFA.Apprenticeships.Application.Interfaces.Api
{
    using DAS.RAA.Api.Client.V1;

    public interface IApiClientProvider
    {
        IApiClient GetApiClient();
    }
}