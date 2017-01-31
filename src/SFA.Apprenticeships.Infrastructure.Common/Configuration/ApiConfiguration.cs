namespace SFA.Apprenticeships.Infrastructure.Common.Configuration
{
    using System;

    public class ApiConfiguration
    {
        public string ApiBaseUrl { get; set; }

        public bool IsEnabled { get; set; }

        public Guid Salt { get; set; }
    }
}