using TechTalk.SpecFlow;

namespace SFA.DAS.RAA.Api.AcceptanceTests.Steps
{
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using System.Net;
    using System.Threading.Tasks;
    using Api.Models;
    using Apprenticeships.Domain.Entities.Raa.Vacancies;
    using Apprenticeships.Infrastructure.Repositories.Sql.Schemas.Vacancy;
    using Comparers;
    using Constants;
    using Extensions;
    using Factories;
    using FluentAssertions;
    using Models;
    using Moq;
    using Newtonsoft.Json;
    using Ploeh.AutoFixture;
    using DbVacancySummary = Apprenticeships.Infrastructure.Repositories.Sql.Schemas.Vacancy.Entities.VacancySummary;

    [Binding]
    public class GetVacancySummarySteps
    {
        [When(@"I request page (.*) of the list of (.*) live vacancy summaries with page size: (.*)")]
        public async Task WhenIRequestPageOfTheListOfLiveVacancySummaries(int page, int totalCount, int pageSize)
        {
            var vacancySummariesUri = string.Format(UriFormats.PublicVacancySummariesUriFormat, page, pageSize);
            await GetVacancySummaries(vacancySummariesUri, page, totalCount, pageSize);
        }

        [Then(@"I see (.*) vacancy summaries on page (.*) from a total of (.*) and (.*) total pages")]
        public void ThenISeeVacancySummariesAndTotalPages(int expectedCount, int expectedPage, int expectedTotalCount, int expectedPageCount)
        {
            var vacancySummaries = ScenarioContext.Current.Get<List<DbVacancySummary>>("vacancySummaries");
            var responseVacancySummaries = ScenarioContext.Current.Get<VacancySummariesPage>("responseVacancySummaries");

            responseVacancySummaries.Should().NotBeNull();
            responseVacancySummaries.VacancySummaries.Should().NotBeNullOrEmpty();
            responseVacancySummaries.VacancySummaries.Count.Should().Be(expectedCount);
            responseVacancySummaries.TotalCount.Should().Be(expectedTotalCount);
            responseVacancySummaries.CurrentPage.Should().Be(expectedPage);
            responseVacancySummaries.TotalPages.Should().Be(expectedPageCount);

            var comparer = new DbPublicVacancySummaryComparer();
            for (var i = 0; i < vacancySummaries.Count; i++)
            {
                var vacancySummary = vacancySummaries[i];
                var responseVacancySummary = responseVacancySummaries.VacancySummaries[i];

                vacancySummary.Should().NotBeNull();
                responseVacancySummary.Should().NotBeNull();

                comparer.Equals(vacancySummary, responseVacancySummary).Should().BeTrue();
            }
        }

        private static async Task GetVacancySummaries(string vacancySummariesUri, int page, int totalCount, int pageSize)
        {
            var vacancySummaries = new Fixture().Build<DbVacancySummary>()
                .With(v => v.TotalResultCount, totalCount)
                .With(v => v.VacancyStatusId, VacancyStatus.Live)
                .CreateMany(pageSize).ToList();

            ScenarioContext.Current.Add("vacancySummaries", vacancySummaries);

            RaaMockFactory.GetMockGetOpenConnection().Setup(
                    m => m.QueryAsync<DbVacancySummary>(It.Is<string>(s => s.StartsWith(VacancySummaryRepository.CoreQuery)), It.IsAny<object>(), It.IsAny<int?>(), It.IsAny<CommandType?>()))
                .Returns(Task.FromResult((IList<DbVacancySummary>)new List<DbVacancySummary>(vacancySummaries)));

            var httpClient = FeatureContext.Current.TestServer().HttpClient;
            httpClient.SetAuthorization();

            using (var response = await httpClient.GetAsync(vacancySummariesUri))
            {
                ScenarioContext.Current.Add(ScenarioContextKeys.HttpResponseStatusCode, response.StatusCode);
                using (var httpContent = response.Content)
                {
                    var content = await httpContent.ReadAsStringAsync();
                    if (response.StatusCode != HttpStatusCode.OK)
                    {
                        var responseMessage = JsonConvert.DeserializeObject<ResponseMessage>(content);
                        ScenarioContext.Current.Add(ScenarioContextKeys.HttpResponseMessage, responseMessage);
                    }

                    var responseVacancySummaries = JsonConvert.DeserializeObject<VacancySummariesPage>(content);
                    ScenarioContext.Current.Add("responseVacancySummaries", responseVacancySummaries);
                }
            }
        }
    }
}
