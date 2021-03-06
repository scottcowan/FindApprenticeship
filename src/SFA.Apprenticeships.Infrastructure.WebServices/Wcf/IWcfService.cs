﻿namespace SFA.Apprenticeships.Infrastructure.WebServices.Wcf
{
    using System;

    public interface IWcfService<T>
    {
        void Use(Action<T> action);
        void Use(string endpointConfigurationName, string endpointAddress, Action<T> action);
        void Use(string endpointConfigurationName, Action<T> action);
    }
}
