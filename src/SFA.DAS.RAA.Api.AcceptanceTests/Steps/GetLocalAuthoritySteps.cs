namespace SFA.DAS.RAA.Api.AcceptanceTests.Steps
{
    using System;
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
    public class GetLocalAuthoritiesSteps
    {
        [Given(@"I request all local authorities")]
        public async Task GivenIRequestAllLocalAuthorities()
        {
            const string localAuthoritiesUri = UriFormats.GetLocalAuthoritiesUri;

            var localAuthorities = new Fixture().CreateMany<LocalAuthority>(3).ToList();

            ScenarioContext.Current.Add("localAuthorities", localAuthorities);

            RaaMockFactory.GetMockGetOpenConnection().Setup(
                m => m.Query<LocalAuthority>(ReferenceRepository.GetLocalAuthoritiesSql, null, null, null))
                .Returns(localAuthorities);

            var httpClient = FeatureContext.Current.TestServer().HttpClient;
            httpClient.SetAuthorization();

            using (var response = await httpClient.GetAsync(localAuthoritiesUri))
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

                    var responseLocalAuthorities = JsonConvert.DeserializeObject<IList<LocalAuthority>>(content);
                    ScenarioContext.Current.Add("responseLocalAuthorities", responseLocalAuthorities);
                }
            }
        }
        
        [Then(@"I see all local authority information")]
        public void ThenISeeAllLocalAuthorityInformation()
        {
            var localAuthorities = ScenarioContext.Current.Get<List<LocalAuthority>>("localAuthorities");
            var responseVacancySummaries = ScenarioContext.Current.Get<IList<LocalAuthority>>("responseLocalAuthorities");

            responseVacancySummaries.Should().NotBeNullOrEmpty();
            responseVacancySummaries.Count.Should().Be(localAuthorities.Count);
        }

        [Given(@"I request the local authority with id: (.*)")]
        public async Task GivenIRequestTheLocalAuthorityWithId(int localAuthorityId)
        {
            var localAuthorityUri = string.Format(UriFormats.LocalAuthorityIdUriFormat, localAuthorityId);
            await GetLocalAuthority(localAuthorityUri);
        }

        [Given(@"I request the local authority with code: (.*)")]
        public async Task GivenIRequestTheLocalAuthorityWithCode(string localAuthorityCode)
        {
            var localAuthorityUri = string.Format(UriFormats.LocalAuthorityCodeUriFormat, localAuthorityCode);
            await GetLocalAuthority(localAuthorityUri);
        }

        [Then(@"I see the information for the local authority with id: (.*)")]
        public void ThenISeeTheInformationForTheLocalAuthorityWithId(int localAuthorityId)
        {
            var localAuthorityUri = string.Format(UriFormats.LocalAuthorityIdUriFormat, localAuthorityId);
            var localAuthorityWithId = ScenarioContext.Current.Get<LocalAuthority>("localAuthorityWithId");
            var responseLocalAuthority = ScenarioContext.Current.Get<LocalAuthority>(localAuthorityUri);

            responseLocalAuthority.Should().NotBeNull();
            responseLocalAuthority.Equals(localAuthorityWithId).Should().BeTrue();
        }

        [Then(@"I see the information for the local authority with code: (.*)")]
        public void ThenISeeTheInformationForTheLocalAuthorityWithCode(string localAuthorityCode)
        {
            var localAuthorityUri = string.Format(UriFormats.LocalAuthorityCodeUriFormat, localAuthorityCode);
            var localAuthorityWithCode = ScenarioContext.Current.Get<LocalAuthority>("localAuthorityWithCode");
            var responseLocalAuthority = ScenarioContext.Current.Get<LocalAuthority>(localAuthorityUri);

            responseLocalAuthority.Should().NotBeNull();
            responseLocalAuthority.Equals(localAuthorityWithCode).Should().BeTrue();
        }

        [Then(@"I do not see the information for the local authority with id: (.*)")]
        public void ThenIDoNotSeeTheInformationForTheLocalAuthorityWithId(int localAuthorityId)
        {
            var localAuthorityUri = string.Format(UriFormats.LocalAuthorityIdUriFormat, localAuthorityId);
            var responseLocalAuthority = ScenarioContext.Current.Get<LocalAuthority>(localAuthorityUri);
            responseLocalAuthority.Should().BeNull();
        }

        [Then(@"I do not see the information for the local authority with code: (.*)")]
        public void ThenIDoNotSeeTheInformationForTheLocalAuthorityWithCode(string localAuthorityCode)
        {
            var localAuthorityUri = string.Format(UriFormats.LocalAuthorityCodeUriFormat, localAuthorityCode);
            var responseLocalAuthority = ScenarioContext.Current.Get<LocalAuthority>(localAuthorityUri);
            responseLocalAuthority.Should().BeNull();
        }

        private async Task GetLocalAuthority(string localAuthorityUri)
        {
            var localAuthorityWithId = new Fixture().Build<LocalAuthority>().With(c => c.LocalAuthorityId, 160).Create();
            var localAuthorityWithCode = new Fixture().Build<LocalAuthority>().With(c => c.CodeName, "41UD").Create();

            ScenarioContext.Current.Add("localAuthorityWithId", localAuthorityWithId);
            ScenarioContext.Current.Add("localAuthorityWithCode", localAuthorityWithCode);
            
            RaaMockFactory.GetMockGetOpenConnection().Setup(
                m => m.Query(ReferenceRepository.GetLocalAuthorityByIdSql, It.IsAny<Func<LocalAuthority, County, LocalAuthority>>(), It.IsAny<object>(), "CountyId", null, null))
                .Returns(new List<LocalAuthority>());

            RaaMockFactory.GetMockGetOpenConnection().Setup(
                m => m.Query(ReferenceRepository.GetLocalAuthorityByCodeSql, It.IsAny<Func<LocalAuthority, County, LocalAuthority>>(), It.IsAny<object>(), "CountyId", null, null))
                .Returns(new List<LocalAuthority>());

            RaaMockFactory.GetMockGetOpenConnection().Setup(
                m => m.Query(ReferenceRepository.GetLocalAuthorityByIdSql, It.IsAny<Func<LocalAuthority, County, LocalAuthority>>(), It.Is<object>(o => o.GetHashCode() == new { localAuthorityId = localAuthorityWithId.LocalAuthorityId }.GetHashCode()), "CountyId", null, null))
                .Returns(new [] { localAuthorityWithId });

            RaaMockFactory.GetMockGetOpenConnection().Setup(
                m => m.Query(ReferenceRepository.GetLocalAuthorityByCodeSql, It.IsAny<Func<LocalAuthority, County, LocalAuthority>>(), It.Is<object>(o => o.GetHashCode() == new { localAuthorityCode = localAuthorityWithCode.CodeName }.GetHashCode()), "CountyId", null, null))
                .Returns(new [] { localAuthorityWithCode });

            var httpClient = FeatureContext.Current.TestServer().HttpClient;
            httpClient.SetAuthorization();

            using (var response = await httpClient.GetAsync(localAuthorityUri))
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

                    var responseLocalAuthority = JsonConvert.DeserializeObject<LocalAuthority>(content);
                    if (responseLocalAuthority != null && new LocalAuthority().Equals(responseLocalAuthority))
                    {
                        responseLocalAuthority = null;
                    }
                    ScenarioContext.Current.Add(localAuthorityUri, responseLocalAuthority);
                }
            }
        }
    }
}
