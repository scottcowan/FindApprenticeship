﻿namespace SFA.WebProxy.Logging
{
    using System;
    using System.IO;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using Configuration;
    using Models;

    public class FileProxyLogging : IProxyLogging
    {
        private readonly IConfiguration _configuration;

        public FileProxyLogging(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void LogRequest(HttpRequestMessage request, string requestContent, RouteIdentifier routeIdentifier)
        {
            if (_configuration.IsLoggingEnabled)
            {
                using (var logStream = File.CreateText(GetFilePath(routeIdentifier, "request")))
                {
                    logStream.WriteLine(request.RequestUri);
                    var headers = request.GetHeadersLoggingString();
                    logStream.WriteLine(headers);
                    logStream.WriteLine(requestContent);
                }
            }
        }

        public void LogResponseContent(HttpResponseMessage httpResponseMessage, RouteIdentifier routeIdentifier)
        {
            if (_configuration.IsLoggingEnabled)
            {
                var httpContent = httpResponseMessage.Content.ReadAsStreamAsync().Result;
                using (var logStream = File.OpenWrite(GetFilePath(routeIdentifier, "response_")))
                {
                    httpContent.CopyTo(logStream);
                }
            }
        }

        public void LogResponseCancelled(Route route, HttpRequestHeaders httpRequestHeaders, HttpContentHeaders contentHeaders, AggregateException aggregateException)
        {
            LogResponseError("Request to " + route.Uri + " was cancelled", httpRequestHeaders, contentHeaders, aggregateException, route.Identifier);
        }

        public void LogResponseFaulted(Route route, HttpRequestHeaders httpRequestHeaders, HttpContentHeaders contentHeaders, AggregateException aggregateException)
        {
            LogResponseError("Request to " + route.Uri + " faulted", httpRequestHeaders, contentHeaders, aggregateException, route.Identifier);
        }

        public void LogResponseError(string message, HttpRequestHeaders httpRequestHeaders, HttpContentHeaders contentHeaders, AggregateException aggregateException, RouteIdentifier routeIdentifier)
        {
            if (_configuration.IsLoggingEnabled)
            {
                using (var logStream = File.CreateText(GetFilePath(routeIdentifier, "request")))
                {
                    logStream.WriteLine(message);
                    var headers = httpRequestHeaders.GetHeadersLoggingString(contentHeaders);
                    logStream.WriteLine(headers);
                    var exceptionString = aggregateException.GetLoggingString();
                    logStream.WriteLine(exceptionString);
                }
            }
        }

        private string GetFilePath(RouteIdentifier routeIdentifier, string additionalIdentifier)
        {
            var dateTime = routeIdentifier.DateTime;
            var datePath = dateTime.ToString("yyyy-MM-dd");
            var timePath = dateTime.ToString("hh-mm-ss");

            var path = $"{_configuration.FileProxyLoggingRootPath}\\{datePath}\\{additionalIdentifier}{routeIdentifier.Name}";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            var filePath = $"{path}\\{timePath}_{routeIdentifier.Id}.log";

            return filePath;
        }
    }
}