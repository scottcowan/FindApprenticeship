﻿namespace SFA.Apprenticeships.Infrastructure.Communication.IntegrationTests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Application.Interfaces.Messaging;

    public static class TokenGenerator
    {

        private const string TestActivationCode = "ABC123";
        private const string TestToEmail = "valtechnas@gmail.com";

        public static IEnumerable<CommunicationToken> CreateActivationEmailTokens()
        {
            return new[]
            {
                new CommunicationToken(CommunicationTokens.CandidateFirstName, "FirstName"),
                new CommunicationToken(CommunicationTokens.ActivationCode, TestActivationCode),
                new CommunicationToken(CommunicationTokens.Username, TestToEmail),
                new CommunicationToken(CommunicationTokens.ActivationCodeExpiryDays, " 30 days")
            };
        }

        public static IEnumerable<CommunicationToken> CreateAccountUnlockCodeTokens()
        {
            return new[]
            {
                new CommunicationToken(CommunicationTokens.CandidateFirstName, "FirstName"),
                new CommunicationToken(CommunicationTokens.Username, TestToEmail),
                new CommunicationToken(CommunicationTokens.AccountUnlockCode, TestActivationCode),
                new CommunicationToken(CommunicationTokens.AccountUnlockCodeExpiryDays, " 1 day")
            };
        }

        public static IEnumerable<CommunicationToken> CreatePasswordResetConfirmationTokens()
        {
            return new[]
            {
                new CommunicationToken(CommunicationTokens.CandidateFirstName, "FirstName"),
                new CommunicationToken(CommunicationTokens.Username, TestToEmail)
            };
        }

        public static IEnumerable<CommunicationToken> CreatePasswordResetTokens()
        {
            return new[]
            {
                new CommunicationToken(CommunicationTokens.CandidateFirstName, "FirstName"),
                new CommunicationToken(CommunicationTokens.Username, TestToEmail),
                new CommunicationToken(CommunicationTokens.PasswordResetCode, TestActivationCode),
                new CommunicationToken(CommunicationTokens.PasswordResetCodeExpiryDays, "1 day")
            };
        }

        public static IEnumerable<CommunicationToken> CreateApprenticeshipApplicationSubmittedTokens()
        {
            return new[]
            {
                new CommunicationToken(CommunicationTokens.CandidateFirstName, "FirstName"),
                new CommunicationToken(CommunicationTokens.ApplicationVacancyTitle,
                    "Application Vacancy Title"),
                new CommunicationToken(CommunicationTokens.ApplicationVacancyReference,
                    "Application Vacancy Reference")
            };
        }

        public static IEnumerable<CommunicationToken> CreateTraineeshipApplicationSubmittedTokens()
        {
            return new[]
            {
                new CommunicationToken(CommunicationTokens.CandidateFirstName, "FirstName"),
                new CommunicationToken(CommunicationTokens.ApplicationVacancyTitle,
                    "Application Vacancy Title"),
                new CommunicationToken(CommunicationTokens.ApplicationVacancyReference,
                    "Application Vacancy Reference"),
                new CommunicationToken(CommunicationTokens.ProviderContact,
                    "Provider Contact")
            };
        }

        public static IEnumerable<CommunicationToken> CreateVacanciesAboutToExpireTokens(int numOfVacancies)
        {
            var tokens = new List<CommunicationToken>
            {
                new CommunicationToken(CommunicationTokens.TotalItems, Convert.ToString(numOfVacancies))
            };

            tokens.AddRange(Enumerable.Range(1, numOfVacancies).Select(i =>
                new CommunicationToken((CommunicationTokens)Enum.Parse(typeof(CommunicationTokens), "Item" + i),
                    string.Format("Application Vacancy Title {0}|Employer name {0}|15 Jan 15", i))));

            return tokens;
        }
    }
}