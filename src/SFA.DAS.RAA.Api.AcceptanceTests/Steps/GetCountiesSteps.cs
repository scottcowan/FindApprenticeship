namespace SFA.DAS.RAA.Api.AcceptanceTests.Steps
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Threading.Tasks;
    using Apprenticeships.Domain.Entities.Raa.Reference;
    using Apprenticeships.Domain.Entities.Raa.Vacancies;
    using Apprenticeships.Infrastructure.Repositories.Sql.Schemas.Reference;
    using Comparers;
    using Constants;
    using Extensions;
    using Factories;
    using FluentAssertions;
    using Models;
    using Newtonsoft.Json;
    using Ploeh.AutoFixture;
    using TechTalk.SpecFlow;

    [Binding]
    public class GetCountiesSteps
    {
        [Given(@"I request all counties")]
        public async Task GivenIRequestAllCounties()
        {
            const string getCountiesUri = UriFormats.GetCountiesUri;

            var counties = new Fixture().CreateMany<County>(3).ToList();

            ScenarioContext.Current.Add("counties", counties);

            RaaMockFactory.GetMockGetOpenConnection().Setup(
                m => m.Query<County>(ReferenceRepository.GetCountiesSql, null, null, null))
                .Returns(counties);

            var httpClient = FeatureContext.Current.TestServer().HttpClient;
            httpClient.SetAuthorization();

            using (var response = await httpClient.GetAsync(getCountiesUri))
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

                    var responseCounties = JsonConvert.DeserializeObject<IList<County>>(content);
                    ScenarioContext.Current.Add("responseCounties", responseCounties);
                }
            }
        }
        
        [Then(@"I see all county information")]
        public void ThenISeeAllCountyInformation()
        {
            var counties = ScenarioContext.Current.Get<List<County>>("counties");
            var responseVacancySummaries = ScenarioContext.Current.Get<IList<County>>("responseCounties");

            responseVacancySummaries.Should().NotBeNullOrEmpty();
            responseVacancySummaries.Count.Should().Be(counties.Count);
        }
    }
}
