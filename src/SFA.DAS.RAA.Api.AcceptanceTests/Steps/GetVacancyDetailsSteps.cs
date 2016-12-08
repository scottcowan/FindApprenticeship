﻿namespace SFA.DAS.RAA.Api.AcceptanceTests.Steps
{
    using System;
    using System.Net;
    using Constants;
    using Extensions;
    using FluentAssertions;
    using Models;
    using Newtonsoft.Json;
    using Ploeh.AutoFixture;
    using RestSharp;
    using TechTalk.SpecFlow;

    [Binding]
    public class GetVacancyDetailsSteps
    {
        [When(@"I request the vacancy details for the vacancy with id: (.*)")]
        public void WhenIRequestTheVacancyDetailsForTheVacancyWithId(int vacancyId)
        {
            var testServer = FeatureContext.Current.TestServer();

            var vacancy = new Fixture().Build<Vacancy>().With(v => v.VacancyId, vacancyId);
            ScenarioContext.Current.Add($"vacancyId: {vacancyId}", vacancy);

            var vacancyUri = $"/vacancy/?id={vacancyId}";
            var request = new RestRequest(vacancyUri, Method.GET);
            Guid apiKey;
            if (ScenarioContext.Current.TryGetValue(ScenarioContextKeys.ApiKey, out apiKey))
            {
                ScenarioContext.Current.Remove(ScenarioContextKeys.ApiKey);
                request.AddHeader(HttpRequestHeader.Authorization.ToString(), apiKey.ToString());
            }
            var client = ScenarioContext.Current.Get<IRestClient>();

            var response = client.Execute(request);
            ScenarioContext.Current.Add(ScenarioContextKeys.HttpResponseStatusCode, response.StatusCode);

            var responseVacancy = JsonConvert.DeserializeObject<Vacancy>(response.Content);
            ScenarioContext.Current.Add(vacancyUri, responseVacancy);
        }

        [Then(@"I see the vacancy details for the vacancy with id: (.*)")]
        public void ThenISeeTheVacancyDetailsForTheVacancyWithId(int vacancyId)
        {
            var vacancy = ScenarioContext.Current.Get<Vacancy>($"vacancyId: {vacancyId}");
            var vacancyUri = $"/vacancy/?id={vacancyId}";
            var responseVacancy = ScenarioContext.Current.Get<Vacancy>(vacancyUri);

            vacancy.Should().NotBeNull();
            responseVacancy.Should().NotBeNull();
            vacancy.Equals(responseVacancy).Should().BeTrue();
        }
    }
}
