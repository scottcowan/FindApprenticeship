﻿namespace SFA.Apprenticeships.Web.Recruit.Mediators.Report
{
    public class ReportMediatorCodes
    {
        public static class ValidateApplicationsReceivedParameters
        {
            public const string Ok = "ReportMediatorCodes.ValidateApplicationsReceivedParameters.Ok";
            public const string ValidationError = "ReportMediatorCodes.ValidateApplicationsReceivedParameters.ValidationError";
        }

        public static class GetApplicationsReceived
        {
            public const string Ok = "ReportMediatorCodes.GetApplicationsReceived.Ok";
            public const string ValidationError = "ReportMediatorCodes.GetApplicationsReceived.Error";
        }

        public static class ValidateCandidatesWithApplicationsParameters
        {
            public const string Ok = "ReportMediatorCodes.ValidateCandidatesWithApplicationsParameters.Ok";
            public const string ValidationError = "ReportMediatorCodes.ValidateCandidatesWithApplicationsParameters.ValidationError";
        }

        public static class GetCandidatesWithApplications
        {
            public const string Ok = "ReportMediatorCodes.GetCandidatesWithApplications.Ok";
            public const string ValidationError = "ReportMediatorCodes.GetCandidatesWithApplications.ValidationError";
        }
    }
}
