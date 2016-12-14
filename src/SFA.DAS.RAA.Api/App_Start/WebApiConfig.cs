﻿namespace SFA.DAS.RAA.Api
{
    using System.Web.Http;
    using System.Web.Http.ExceptionHandling;
    using Attributes;
    using FluentValidation.WebApi;
    using Handlers;

    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            config.EnableSystemDiagnosticsTracing();
            config.Services.Add(typeof(IExceptionLogger), new AiExceptionLogger());
            config.Services.Replace(typeof(IExceptionHandler), new GlobalExceptionHandler());
            config.Filters.Add(new ValidateModelStateFilter());

            // configure FluentValidation model validator provider
            FluentValidationModelValidatorProvider.Configure(config);

            // Web API routes
            config.MapHttpAttributeRoutes();
        }
    }
}
