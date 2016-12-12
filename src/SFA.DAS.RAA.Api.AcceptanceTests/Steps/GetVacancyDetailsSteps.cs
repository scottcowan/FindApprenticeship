﻿namespace SFA.DAS.RAA.Api.AcceptanceTests.Steps
{
    using System.Net.Http.Headers;
    using Apprenticeships.Domain.Entities.Raa.Vacancies;
    using Apprenticeships.Infrastructure.Repositories.Sql.Schemas.Vacancy;
    using Comparers;
    using Constants;
    using Extensions;
    using Factories;
    using FluentAssertions;
    using Moq;
    using Newtonsoft.Json;
    using Ploeh.AutoFixture;
    using TechTalk.SpecFlow;
    using UnitTests.Factories;
    using DbVacancy = Apprenticeships.Infrastructure.Repositories.Sql.Schemas.Vacancy.Entities.Vacancy;

    [Binding]
    public class GetVacancyDetailsSteps
    {
        [When(@"I request the vacancy details for the vacancy with id: (.*)")]
        public void WhenIRequestTheVacancyDetailsForTheVacancyWithId(int vacancyId)
        {
            var vacancy1 = new Fixture().Build<DbVacancy>()
                .With(v => v.VacancyId, vacancyId)
                .With(v => v.VacancyStatusId, (int)VacancyStatus.Live)
                .With(v => v.ContractOwnerID, RaaApiUserFactory.SkillsFundingAgencyProviderId)
                .Create();
            var vacancy2 = new Fixture().Build<DbVacancy>()
                .With(v => v.VacancyId, vacancyId)
                .With(v => v.VacancyStatusId, (int)VacancyStatus.Live)
                .With(v => v.ContractOwnerID, -1)
                .Create();

            ScenarioContext.Current.Add("vacancyId: 1", vacancy1);
            ScenarioContext.Current.Add("vacancyId: 2", vacancy2);

            RaaMockFactory.GetMockGetOpenConnection().Setup(
                m => m.Query<DbVacancy>(VacancyRepository.SelectByIdSql, It.Is<object>(o => o.GetHashCode() == new { vacancyId = 1 }.GetHashCode()), null, null))
                .Returns(new [] { vacancy1 });

            RaaMockFactory.GetMockGetOpenConnection().Setup(
                m => m.Query<DbVacancy>(VacancyRepository.SelectByIdSql, It.Is<object>(o => o.GetHashCode() == new { vacancyId = 2 }.GetHashCode()), null, null))
                .Returns(new [] { vacancy2 });

            var httpClient = FeatureContext.Current.TestServer().HttpClient;

            var vacancyUri = string.Format(UriFormats.VacancyUriFormat, vacancyId);

            if (ScenarioContext.Current.ContainsKey(ScenarioContextKeys.ApiKey))
            {
                var apiKey = ScenarioContext.Current[ScenarioContextKeys.ApiKey].ToString();
                ScenarioContext.Current.Remove(ScenarioContextKeys.ApiKey);
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", apiKey);
            }

            using (var response = httpClient.GetAsync(vacancyUri).Result)
            {
                ScenarioContext.Current.Add(ScenarioContextKeys.HttpResponseStatusCode, response.StatusCode);
                using (var httpContent = response.Content)
                {
                    var content = httpContent.ReadAsStringAsync().Result;
                    var responseVacancy = JsonConvert.DeserializeObject<Vacancy>(content);
                    ScenarioContext.Current.Add(vacancyUri, responseVacancy);
                }
            }
        }

        [Then(@"I see the vacancy details for the vacancy with id: (.*)")]
        public void ThenISeeTheVacancyDetailsForTheVacancyWithId(int vacancyId)
        {
            var vacancy = ScenarioContext.Current.Get<DbVacancy>($"vacancyId: {vacancyId}");
            var vacancyUri = string.Format(UriFormats.VacancyUriFormat, vacancyId);
            var responseVacancy = ScenarioContext.Current.Get<Vacancy>(vacancyUri);

            vacancy.Should().NotBeNull();
            responseVacancy.Should().NotBeNull();

            var comparer = new DbVacancyComparer();
            comparer.Equals(vacancy, responseVacancy).Should().BeTrue();
        }

        [Then(@"I do not see the vacancy details for the vacancy with id: (.*)")]
        public void ThenIDoNotSeeTheVacancyDetailsForTheVacancyWithId(int vacancyId)
        {
            var vacancy = ScenarioContext.Current.Get<DbVacancy>($"vacancyId: {vacancyId}");
            var vacancyUri = string.Format(UriFormats.VacancyUriFormat, vacancyId);
            var responseVacancy = ScenarioContext.Current.Get<Vacancy>(vacancyUri);

            vacancy.Should().NotBeNull();
            responseVacancy.Should().BeNull();
        }
    }
}
