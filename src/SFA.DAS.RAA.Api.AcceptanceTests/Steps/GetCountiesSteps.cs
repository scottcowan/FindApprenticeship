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
    using Moq;
    using Newtonsoft.Json;
    using Ploeh.AutoFixture;
    using TechTalk.SpecFlow;

    [Binding]
    public class GetCountiesSteps
    {
        [Given(@"I request all counties")]
        public async Task GivenIRequestAllCounties()
        {
            const string countiesUri = UriFormats.GetCountiesUri;

            var counties = new Fixture().CreateMany<County>(3).ToList();

            ScenarioContext.Current.Add("counties", counties);

            RaaMockFactory.GetMockGetOpenConnection().Setup(
                m => m.Query<County>(ReferenceRepository.GetCountiesSql, null, null, null))
                .Returns(counties);

            var httpClient = FeatureContext.Current.TestServer().HttpClient;
            httpClient.SetAuthorization();

            using (var response = await httpClient.GetAsync(countiesUri))
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

        [Given(@"I request the county with id: (.*)")]
        public async Task GivenIRequestTheCountyWithId(int countyId)
        {
            var countyUri = string.Format(UriFormats.CountyIdUriFormat, countyId);
            await GetCounty(countyUri);
        }

        [Given(@"I request the county with code: (.*)")]
        public async Task GivenIRequestTheCountyWithCode(string countyCode)
        {
            var countyUri = string.Format(UriFormats.CountyCodeUriFormat, countyCode);
            await GetCounty(countyUri);
        }

        [Then(@"I see the information for the county with id: (.*)")]
        public void ThenISeeTheInformationForTheCountyWithId(int countyId)
        {
            var countyUri = string.Format(UriFormats.CountyIdUriFormat, countyId);
            var countyWithId = ScenarioContext.Current.Get<County>("countyWithId");
            var responseCounty = ScenarioContext.Current.Get<County>(countyUri);

            responseCounty.Should().NotBeNull();
            responseCounty.Equals(countyWithId).Should().BeTrue();
        }

        [Then(@"I see the information for the county with code: (.*)")]
        public void ThenISeeTheInformationForTheCountyWithCode(string countyCode)
        {
            var countyUri = string.Format(UriFormats.CountyCodeUriFormat, countyCode);
            var countyWithCode = ScenarioContext.Current.Get<County>("countyWithCode");
            var responseCounty = ScenarioContext.Current.Get<County>(countyUri);

            responseCounty.Should().NotBeNull();
            responseCounty.Equals(countyWithCode).Should().BeTrue();
        }

        private async Task GetCounty(string countyUri)
        {
            var countyWithId = new Fixture().Build<County>().With(c => c.CountyId, 4).Create();
            var countyWithCode = new Fixture().Build<County>().With(c => c.CodeName, "DER").Create();

            ScenarioContext.Current.Add("countyWithId", countyWithId);
            ScenarioContext.Current.Add("countyWithCode", countyWithCode);

            RaaMockFactory.GetMockGetOpenConnection().Setup(
                m => m.Query<County>(It.Is<string>(sql => sql.StartsWith("SELECT * FROM dbo.County")), It.Is<object>(o => o.GetHashCode() == new { countyId = 4 }.GetHashCode()), null, null))
                .Returns(new [] { countyWithId });

            RaaMockFactory.GetMockGetOpenConnection().Setup(
                m => m.Query<County>(It.Is<string>(sql => sql.StartsWith("SELECT * FROM dbo.County")), It.Is<object>(o => o.GetHashCode() == new { countyCode = "DER" }.GetHashCode()), null, null))
                .Returns(new [] { countyWithCode });

            var httpClient = FeatureContext.Current.TestServer().HttpClient;
            httpClient.SetAuthorization();

            using (var response = await httpClient.GetAsync(countyUri))
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

                    var responseCounty = JsonConvert.DeserializeObject<County>(content);
                    ScenarioContext.Current.Add(countyUri, responseCounty);
                }
            }
        }
    }
}
