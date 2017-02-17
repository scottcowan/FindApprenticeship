using TechTalk.SpecFlow;

namespace SFA.DAS.RAA.Api.AcceptanceTests.Steps
{
    using Apprenticeships.Domain.Entities.Raa.Reference;
    using Apprenticeships.Infrastructure.EmployerDataService.EmployerDataService;
    using Constants;
    using Extensions;
    using Factories;
    using Models;
    using Moq;
    using Newtonsoft.Json;
    using Ploeh.AutoFixture;
    using System;
    using System.Net;
    using System.Threading.Tasks;

    [Binding]
    public class GetLinkEmployerSteps
    {
        [Given(@"On requesting for an employer by edsurn: (.*)")]
        public async Task GivenOnRequestingForAnEmployerByEdsurn(int employerEdsUrn)
        {
            var requestUri = string.Format(UriFormats.GetEmployerByEdsUriUri, employerEdsUrn);
            await GetEmployerByEdsUrn(requestUri);
        }

        private async Task GetEmployerByEdsUrn(string requestUri)
        {
            //throw new System.NotImplementedException();
            var EndpointConfigurationName = "EmployerDataService";

            const string edsurn = "130180483";

            var employerWithEdsUrn = new Fixture().Build<DetailedEmployerStructure>()
                .With(e => e.URN, edsurn)
                .Create();

            RaaMockFactory.GetMockEmployerLookupSoapService().Setup(m =>
            m.Use("EmployerDataService",
            It.IsAny<Func<EmployerLookupSoap, DetailedEmployerStructure>>())).Returns(employerWithEdsUrn);

            //RaaMockFactory.GetMockEmployerLookupSoapService().Setup(m =>
            //            m.Use("EmployerDataService",
            //            client => client.Fetch(Convert.ToInt32(edsurn), false, "MarkG.75jgh38thds"))).Returns(employerWithEdsUrn);

            ScenarioContext.Current.Add("employerWithEdsUrn", employerWithEdsUrn);
            var httpClient = FeatureContext.Current.TestServer().HttpClient;
            httpClient.SetAuthorization();
            using (var response = await httpClient.GetAsync(requestUri))
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

                    var responseFramework =
                        JsonConvert.DeserializeObject<Framework>(content);
                    //if (responseFramework != null && new Framework().Equals(responseFramework))
                    //{
                    //    responseFramework = null;
                    //}
                    //ScenarioContext.Current.Add(requestUri, responseFramework);
                }
            }
        }

        [Then(@"I see the employer: (.*)")]
        public void ThenISeeTheEmployer(int employerEdsUrn)
        {
            var requestUri = string.Format(UriFormats.GetEmployerByEdsUriUri, employerEdsUrn);
        }

    }
}
