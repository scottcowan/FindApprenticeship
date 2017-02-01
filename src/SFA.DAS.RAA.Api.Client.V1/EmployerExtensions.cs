// Code generated by Microsoft (R) AutoRest Code Generator 0.17.0.0
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.

namespace SFA.DAS.RAA.Api.Client.V1
{
    using System.Threading.Tasks;
   using Models;

    /// <summary>
    /// Extension methods for Employer.
    /// </summary>
    public static partial class EmployerExtensions
    {
            /// <summary>
            /// Endpoint for linking an employer to a provider site.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='employerProviderSiteLinkRequest'>
            /// Defines the provider site to link to as well as additional employer
            /// information. Note that you can specify the employer identifier in either
            /// the URL or the POST body
            /// </param>
            /// <param name='edsUrn'>
            /// The employer's secondary identifier.
            /// </param>
            public static EmployerProviderSiteLink LinkEmployerByEdsUrn(this IEmployer operations, EmployerProviderSiteLinkRequest employerProviderSiteLinkRequest, int edsUrn)
            {
                return System.Threading.Tasks.Task.Factory.StartNew(s => ((IEmployer)s).LinkEmployerByEdsUrnAsync(employerProviderSiteLinkRequest, edsUrn), operations, System.Threading.CancellationToken.None, System.Threading.Tasks.TaskCreationOptions.None, System.Threading.Tasks.TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <summary>
            /// Endpoint for linking an employer to a provider site.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='employerProviderSiteLinkRequest'>
            /// Defines the provider site to link to as well as additional employer
            /// information. Note that you can specify the employer identifier in either
            /// the URL or the POST body
            /// </param>
            /// <param name='edsUrn'>
            /// The employer's secondary identifier.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async System.Threading.Tasks.Task<EmployerProviderSiteLink> LinkEmployerByEdsUrnAsync(this IEmployer operations, EmployerProviderSiteLinkRequest employerProviderSiteLinkRequest, int edsUrn, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
            {
                using (var _result = await operations.LinkEmployerByEdsUrnWithHttpMessagesAsync(employerProviderSiteLinkRequest, edsUrn, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

    }
}
