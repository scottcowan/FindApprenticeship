namespace SFA.DAS.RAA.Api.AcceptanceTests.Steps
{
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Text;
    using System.Threading.Tasks;
    using Api.Models;
    using Apprenticeships.Domain.Entities.Raa.Reference;
    using Apprenticeships.Infrastructure.Repositories.Sql.Schemas.dbo;
    using Apprenticeships.Infrastructure.Repositories.Sql.Schemas.dbo.Entities;
    using Apprenticeships.Infrastructure.Repositories.Sql.Schemas.Provider;
    using Apprenticeships.Infrastructure.Repositories.Sql.Schemas.Provider.Entities;
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
    using UnitTests.Factories;

    [Binding]
    public class LinkEmployerSteps
    {
        [When(@"I request to link employer identified with EDSURN: (.*) to provider site identified with EDSURN: (.*) with description: (.*) and website: (.*)")]
        public async Task WhenIRequestToLinkEmployerIdentifiedWithEdsUrnToProviderSiteIdentifiedWithEdsUrn(int employerEdsUrn, int providerSiteEdsUrn, string description, string website)
        {
            var employer = new Fixture().Build<Employer>()
                .With(e => e.EdsUrn, employerEdsUrn)
                .Create();

            var providerSite = new Fixture().Build<ProviderSite>()
                .With(ps => ps.EdsUrn, providerSiteEdsUrn.ToString())
                .Create();

            var providerSiteRelationship = new Fixture().Build<ProviderSiteRelationship>()
                .With(psr => psr.ProviderId, RaaApiUserFactory.SkillsFundingAgencyProviderId)
                .With(psr => psr.ProviderSiteId, providerSite.ProviderSiteId)
                .With(psr => psr.ProviderSiteRelationShipTypeId, 1)
                .Create();

            ScenarioContext.Current.Add($"employer_{employerEdsUrn}", employer);
            ScenarioContext.Current.Add($"providerSite_{providerSiteEdsUrn}", providerSite);
            ScenarioContext.Current.Add("providerSiteRelationship", providerSite);

            RaaMockFactory.GetMockGetOpenConnection().Setup(
                m => m.Query<Employer>(It.Is<string>(s => s.StartsWith(EmployerRepository.BasicQuery)), It.Is<object>(o => o.GetHashCode() == new { EdsUrn = employerEdsUrn }.GetHashCode()), null, null))
                .Returns(new[] { employer });

            RaaMockFactory.GetMockGetOpenConnection().Setup(
                m => m.Query<ProviderSite>(It.Is<string>(s => s.StartsWith(ProviderSiteRepository.SelectByEdsUrnSql)), It.Is<object>(o => o.GetHashCode() == new { edsUrn = providerSiteEdsUrn.ToString() }.GetHashCode()), null, null))
                .Returns(new[] { providerSite });

            RaaMockFactory.GetMockGetOpenConnection().Setup(
                m => m.Query<ProviderSite>(It.Is<string>(s => s.StartsWith(ProviderSiteRepository.SelectByProviderIdSql)), It.IsAny<object>(), null, null))
                .Returns(new[] { providerSite });

            RaaMockFactory.GetMockGetOpenConnection().Setup(
                m => m.Query<ProviderSiteRelationship>(It.Is<string>(s => s.StartsWith(ProviderSiteRepository.SelectProviderSiteRelationshipsByProviderSiteIdsSql)), It.IsAny<object>(), null, null))
                .Returns(new[] { providerSiteRelationship });

            RaaMockFactory.GetMockGetOpenConnection().Setup(
                m => m.Insert(It.IsAny<VacancyOwnerRelationship>(), null)).Callback<VacancyOwnerRelationship, int?>(
                (vor, ct) =>
                {
                    RaaMockFactory.GetMockGetOpenConnection().Setup(
                        m => m.Query<VacancyOwnerRelationship>(It.Is<string>(s => s.StartsWith(VacancyOwnerRelationshipRepository.SelectByIdsSql)), It.IsAny<object>(), null, null))
                        .Returns(new[] {vor});
                })
                .Returns(42);

            var linkEmployerUri = employerEdsUrn == 0 ? UriFormats.LinkEmployerUri : string.Format(UriFormats.LinkEmployerEdsUrnUriFormat, employerEdsUrn);

            var employerProviderSiteLink = new EmployerProviderSiteLinkRequest
            {
                ProviderSiteEdsUrn = providerSiteEdsUrn == 0 ? (int?)null : providerSiteEdsUrn,
                EmployerDescription = description == "null" ? null : description,
                EmployerWebsiteUrl = website == "null" ? null : website
            };

            var httpClient = FeatureContext.Current.TestServer().HttpClient;
            httpClient.SetAuthorization();

            using (var response = await httpClient.PostAsync(linkEmployerUri, new StringContent(JsonConvert.SerializeObject(employerProviderSiteLink), Encoding.UTF8, "application/json")))
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

                    var responseEmployerProviderSiteLink = JsonConvert.DeserializeObject<EmployerProviderSiteLink>(content);
                    if (Equals(responseEmployerProviderSiteLink, new EmployerProviderSiteLink()))
                    {
                        responseEmployerProviderSiteLink = null;
                    }
                    ScenarioContext.Current.Add(linkEmployerUri, responseEmployerProviderSiteLink);
                }
            }
        }

        [Then(@"I see the employer link for the employer identified with EDSURN: (.*) and the provider site identified with EDSURN: (.*) with description: (.*) and website: (.*)")]
        public void ThenISeeTheEmployerLinkForTheEmployerIdentifiedWithEdsUrnAndTheProviderSiteIdentifiedWithEdsUrn(int employerEdsUrn, int providerSiteEdsUrn, string description, string website)
        {
            var linkEmployerUri = employerEdsUrn == 0 ? UriFormats.LinkEmployerUri : string.Format(UriFormats.LinkEmployerEdsUrnUriFormat, employerEdsUrn);
            var responseEmployerProviderSiteLink = ScenarioContext.Current.Get<EmployerProviderSiteLink>(linkEmployerUri);
            responseEmployerProviderSiteLink.Should().NotBeNull();

            var employer =  ScenarioContext.Current.Get<Employer>($"employer_{employerEdsUrn}");
            var providerSite = ScenarioContext.Current.Get<ProviderSite>($"providerSite_{providerSiteEdsUrn}");

            var expectedLink = new EmployerProviderSiteLink
            {
                EmployerProviderSiteLinkId = 42,
                EmployerId = employer.EmployerId,
                EmployerEdsUrn = employerEdsUrn,
                ProviderSiteId = providerSite.ProviderSiteId,
                ProviderSiteEdsUrn = providerSiteEdsUrn,
                EmployerDescription = description,
                EmployerWebsiteUrl = website
            };

            responseEmployerProviderSiteLink.Equals(expectedLink).Should().BeTrue();
        }


        [Then(@"I do not see the employer link for the employer identified with EDSURN: (.*) and the provider site identified with EDSURN: (.*)")]
        public void ThenIDoNotSeeTheEmployerLinkForTheEmployerIdentifiedWithEdsUrnAndTheProviderSiteIdentifiedWithEdsUrn(int employerEdsUrn, int providerSiteEdsUrn)
        {
            var linkEmployerUri = employerEdsUrn == 0 ? UriFormats.LinkEmployerUri : string.Format(UriFormats.LinkEmployerEdsUrnUriFormat, employerEdsUrn);
            var responseEmployerProviderSiteLink = ScenarioContext.Current.Get<EmployerProviderSiteLinkRequest>(linkEmployerUri);
            responseEmployerProviderSiteLink.Should().BeNull();
        }
    }
}
