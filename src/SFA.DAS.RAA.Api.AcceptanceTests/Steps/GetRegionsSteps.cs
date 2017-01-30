namespace SFA.DAS.RAA.Api.AcceptanceTests.Steps
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Threading.Tasks;
    using Apprenticeships.Domain.Entities.Raa.Reference;
    using Apprenticeships.Infrastructure.Repositories.Sql.Schemas.Reference;
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
    public class GetRegionsSteps
    {
        [Given(@"I request all regions")]
        public async Task GivenIRequestAllRegions()
        {
            const string regionsUri = UriFormats.GetRegionsUri;

            var regions = new Fixture().CreateMany<Region>(3).ToList();

            ScenarioContext.Current.Add("regions", regions);

            RaaMockFactory.GetMockGetOpenConnection().Setup(
                m => m.Query<Region>(ReferenceRepository.GetRegionsSql, null, null, null))
                .Returns(regions);

            var httpClient = FeatureContext.Current.TestServer().HttpClient;
            httpClient.SetAuthorization();

            using (var response = await httpClient.GetAsync(regionsUri))
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

                    var responseRegions = JsonConvert.DeserializeObject<IList<Region>>(content);
                    ScenarioContext.Current.Add("responseRegions", responseRegions);
                }
            }
        }
        
        [Then(@"I see all region information")]
        public void ThenISeeAllRegionInformation()
        {
            var regions = ScenarioContext.Current.Get<List<Region>>("regions");
            var responseVacancySummaries = ScenarioContext.Current.Get<IList<Region>>("responseRegions");

            responseVacancySummaries.Should().NotBeNullOrEmpty();
            responseVacancySummaries.Count.Should().Be(regions.Count);
        }

        [Given(@"I request the region with id: (.*)")]
        public async Task GivenIRequestTheRegionWithId(int regionId)
        {
            var regionUri = string.Format(UriFormats.RegionIdUriFormat, regionId);
            await GetRegion(regionUri);
        }

        [Given(@"I request the region with code: (.*)")]
        public async Task GivenIRequestTheRegionWithCode(string regionCode)
        {
            var regionUri = string.Format(UriFormats.RegionCodeUriFormat, regionCode);
            await GetRegion(regionUri);
        }

        [Then(@"I see the information for the region with id: (.*)")]
        public void ThenISeeTheInformationForTheRegionWithId(int regionId)
        {
            var regionUri = string.Format(UriFormats.RegionIdUriFormat, regionId);
            var regionWithId = ScenarioContext.Current.Get<Region>("regionWithId");
            var responseRegion = ScenarioContext.Current.Get<Region>(regionUri);

            responseRegion.Should().NotBeNull();
            responseRegion.Equals(regionWithId).Should().BeTrue();
        }

        [Then(@"I see the information for the region with code: (.*)")]
        public void ThenISeeTheInformationForTheRegionWithCode(string regionCode)
        {
            var regionUri = string.Format(UriFormats.RegionCodeUriFormat, regionCode);
            var regionWithCode = ScenarioContext.Current.Get<Region>("regionWithCode");
            var responseRegion = ScenarioContext.Current.Get<Region>(regionUri);

            responseRegion.Should().NotBeNull();
            responseRegion.Equals(regionWithCode).Should().BeTrue();
        }

        [Then(@"I do not see the information for the region with id: (.*)")]
        public void ThenIDoNotSeeTheInformationForTheRegionWithId(int regionId)
        {
            var regionUri = string.Format(UriFormats.RegionIdUriFormat, regionId);
            var responseRegion = ScenarioContext.Current.Get<Region>(regionUri);
            responseRegion.Should().BeNull();
        }

        [Then(@"I do not see the information for the region with code: (.*)")]
        public void ThenIDoNotSeeTheInformationForTheRegionWithCode(string regionCode)
        {
            var regionUri = string.Format(UriFormats.RegionCodeUriFormat, regionCode);
            var responseRegion = ScenarioContext.Current.Get<Region>(regionUri);
            responseRegion.Should().BeNull();
        }

        private async Task GetRegion(string regionUri)
        {
            var regionWithId = new Fixture().Build<Region>().With(c => c.RegionId, 1007).Create();
            var regionWithCode = new Fixture().Build<Region>().With(c => c.CodeName, "WM").Create();

            ScenarioContext.Current.Add("regionWithId", regionWithId);
            ScenarioContext.Current.Add("regionWithCode", regionWithCode);

            RaaMockFactory.GetMockGetOpenConnection().Setup(
                m => m.Query<Region>(ReferenceRepository.GetRegionByIdSql, It.IsAny<object>(), null, null))
                .Returns(new List<Region>());

            RaaMockFactory.GetMockGetOpenConnection().Setup(
                m => m.Query<Region>(ReferenceRepository.GetRegionByCodeSql, It.IsAny<object>(), null, null))
                .Returns(new List<Region>());

            RaaMockFactory.GetMockGetOpenConnection().Setup(
                m => m.Query<Region>(ReferenceRepository.GetRegionByIdSql, It.Is<object>(o => o.GetHashCode() == new { regionId = regionWithId.RegionId }.GetHashCode()), null, null))
                .Returns(new [] { regionWithId });

            RaaMockFactory.GetMockGetOpenConnection().Setup(
                m => m.Query<Region>(ReferenceRepository.GetRegionByCodeSql, It.Is<object>(o => o.GetHashCode() == new { regionCode = regionWithCode.CodeName }.GetHashCode()), null, null))
                .Returns(new [] { regionWithCode });

            var httpClient = FeatureContext.Current.TestServer().HttpClient;
            httpClient.SetAuthorization();

            using (var response = await httpClient.GetAsync(regionUri))
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

                    var responseRegion = JsonConvert.DeserializeObject<Region>(content);
                    if (responseRegion != null && new Region().Equals(responseRegion))
                    {
                        responseRegion = null;
                    }
                    ScenarioContext.Current.Add(regionUri, responseRegion);
                }
            }
        }
    }
}
