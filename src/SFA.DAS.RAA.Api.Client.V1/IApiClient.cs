// Code generated by Microsoft (R) AutoRest Code Generator 0.17.0.0
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.

namespace SFA.DAS.RAA.Api.Client.V1
{
    using Models;

    /// <summary>
    /// ##Getting started##
    /// The following Swagger test area will help you understand how to call
    /// the Recruit an Apprentice REST API.
    /// 
    /// All calls follow the standard HTTP protocol and require only an API
    /// key for identification purposes.
    /// 
    /// The API key will be supplied by an administrator and should be passed
    /// as a header parameter in each request.
    /// 
    /// The format is: `Authorization: bearer YOUR_API_KEY`
    /// </summary>
    public partial interface IApiClient : System.IDisposable
    {
        /// <summary>
        /// The base URI of the service.
        /// </summary>
        System.Uri BaseUri { get; set; }

        /// <summary>
        /// Gets or sets json serialization settings.
        /// </summary>
        Newtonsoft.Json.JsonSerializerSettings SerializationSettings { get; }

        /// <summary>
        /// Gets or sets json deserialization settings.
        /// </summary>
        Newtonsoft.Json.JsonSerializerSettings DeserializationSettings { get; }

        /// <summary>
        /// Subscription credentials which uniquely identify client
        /// subscription.
        /// </summary>
        Microsoft.Rest.ServiceClientCredentials Credentials { get; }


        /// <summary>
        /// Gets the IEmployer.
        /// </summary>
        IEmployer Employer { get; }

        /// <summary>
        /// Gets the IPublicVacancyOperations.
        /// </summary>
        IPublicVacancyOperations PublicVacancyOperations { get; }

        /// <summary>
        /// Gets the IPublicVacancySummaryOperations.
        /// </summary>
        IPublicVacancySummaryOperations PublicVacancySummaryOperations { get; }

        /// <summary>
        /// Gets the IReference.
        /// </summary>
        IReference Reference { get; }

        /// <summary>
        /// Gets the IVacancyOperations.
        /// </summary>
        IVacancyOperations VacancyOperations { get; }

        /// <summary>
        /// Gets the IVacancyManagement.
        /// </summary>
        IVacancyManagement VacancyManagement { get; }

        /// <summary>
        /// Gets the IVacancySummaryOperations.
        /// </summary>
        IVacancySummaryOperations VacancySummaryOperations { get; }

    }
}
