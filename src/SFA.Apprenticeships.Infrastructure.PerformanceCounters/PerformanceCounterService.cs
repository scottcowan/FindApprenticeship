﻿namespace SFA.Apprenticeships.Infrastructure.PerformanceCounters
{
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using CuttingEdge.Conditions;

    public class PerformanceCounterService : IPerformanceCounterService
    {
        private const string PerformanceCounterCategory = "SFA.Apprenticeships.Web.Candidate";
        private const string CandidateRegistrationCounter = "CandidateRegistration";
        private const string ApplicationSubmissionCounter = "ApplicationSubmission";
        private const string VacancySearchCounter = "VacancySearch";
        
        public void IncrementCandidateRegistrationCounter()
        {
            IncrementCounter(CandidateRegistrationCounter);
        }

        public void IncrementApplicationSubmissionCounter()
        {
            IncrementCounter(ApplicationSubmissionCounter);
        }

        public void IncrementVacancySearchPerformanceCounter()
        {
            IncrementCounter(VacancySearchCounter);
        }

        private void IncrementCounter(string performanceCounterName)
        {
            using (var counter = new PerformanceCounter(PerformanceCounterCategory, performanceCounterName, false))
            {
                counter.Increment();
            }
        }
    }
}