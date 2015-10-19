﻿namespace SFA.Apprenticeship.Api.AvmsCompatability.ServiceContracts.Version50
{
    using System.ServiceModel;
    using AvmsCompatability;
    using FaultContracts.Version50;
    using MessageContracts.Version50;

    [ServiceContract(Namespace=CommonNamespaces.ExternalInterfaces)]
    public interface IApplicationTracking
    {
        [OperationContract]
        [FaultContract(typeof(SystemFaultContract))]
        SubmitApplicationTrackingResponse Submit( SubmitApplicationTrackingRequest request );
    }
}