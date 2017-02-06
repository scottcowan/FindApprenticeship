using System;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA.Api.AcceptanceTests.Steps
{
    using System.Net;
    using System.Net.Http;
    using System.Text;
    using System.Threading.Tasks;
    using Apprenticeships.Domain.Entities.Raa.Vacancies;
    using Constants;
    using Extensions;
    using FluentAssertions;
    using Models;
    using Newtonsoft.Json;

    [Binding]
    public class CreateVacancySteps
    {
        [When(@"I request to create a (.*) vacancy for employer identified with EDSURN: (.*) and provider site identified with EDSURN: (.*) with description: (.*) and website: (.*)")]
        public void WhenIRequestToCreateAVacancyForEmployerAndProviderSite(string vacancyLocationTypeString, int employerEdsUrn, int providerSiteEdsUrn, string description, string website)
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"I see the (.*) vacancy for employer identified with EDSURN: (.*) and provider site identified with EDSURN: (.*) with description: (.*) and website: (.*)")]
        public void ThenISeeTheVacancyForEmployerAndProviderSite(string vacancyLocationTypeString, int employerEdsUrn, int providerSiteEdsUrn, string description, string website)
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"I request to create a (.*) vacancy for vacancy owner relationship with id: (.*) and (.*) positions")]
        public async Task WhenIRequestToCreateASpecificLocationVacancyForVacancyOwnerRelationshipWithIdAndPositions(string vacancyLocationTypeString, int vacancyOwnerRelationshipId, int positions)
        {
            var vacancy = GetVacancy(vacancyLocationTypeString, vacancyOwnerRelationshipId, positions);

            const string createVacancyUri = UriFormats.CreateVacancyUri;

            var httpClient = FeatureContext.Current.TestServer().HttpClient;
            httpClient.SetAuthorization();

            using (var response = await httpClient.PostAsync(createVacancyUri, new StringContent(JsonConvert.SerializeObject(vacancy), Encoding.UTF8, "application/json")))
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

                    var responseVacancy = JsonConvert.DeserializeObject<Vacancy>(content);
                    if (Equals(responseVacancy, new Vacancy()))
                    {
                        responseVacancy = null;
                    }
                    ScenarioContext.Current.Add("responseVacancy", responseVacancy);
                }
            }
        }

        private static Vacancy GetVacancy(string vacancyLocationTypeString, int vacancyOwnerRelationshipId, int positions)
        {
            var vacancyLocationType = (VacancyLocationType) Enum.Parse(typeof(VacancyLocationType), vacancyLocationTypeString);

            var vacancy = new Vacancy
            {
                VacancyLocationType = vacancyLocationType,
                VacancyOwnerRelationshipId = vacancyOwnerRelationshipId,
                NumberOfPositions = positions
            };
            return vacancy;
        }

        [Then(@"I see the (.*) vacancy for vacancy owner relationship with id: (.*) and (.*) positions")]
        public void ThenISeeTheSpecificLocationVacancyForVacancyOwnerRelationshipWithIdAndPositions(string vacancyLocationTypeString, int vacancyOwnerRelationshipId, int positions)
        {
            var responseVacancy = ScenarioContext.Current.Get<Vacancy>("responseVacancy");
            responseVacancy.Should().NotBeNull();
            responseVacancy.VacancyId.Should().NotBe(0);
            responseVacancy.VacancyReferenceNumber.Should().NotBe(0);
            var expectedVacancy = GetVacancy(vacancyLocationTypeString, vacancyOwnerRelationshipId, positions);
            expectedVacancy.Status = VacancyStatus.Draft;
            responseVacancy.Equals(expectedVacancy).Should().BeTrue();
        }

        [Then(@"I do not see the (.*) vacancy for vacancy owner relationship with id: (.*) and (.*) positions")]
        public void ThenIDoNotSeeTheSpecificLocationVacancyForVacancyOwnerRelationshipWithIdAndPositions(string vacancyLocationTypeString, int vacancyOwnerRelationshipId, int positions)
        {
            var responseVacancy = ScenarioContext.Current.Get<Vacancy>("responseVacancy");
            responseVacancy.Should().BeNull();
            var expectedVacancy = GetVacancy(vacancyLocationTypeString, vacancyOwnerRelationshipId, positions);
            responseVacancy.Equals(expectedVacancy).Should().BeFalse();
        }

        [Then(@"I see that the vacancy's status is (.*)")]
        public void ThenISeeThatTheVacancySStatusIs(string vacancyStatusString)
        {
            var vacancyStatus = (VacancyStatus) Enum.Parse(typeof(VacancyStatus), vacancyStatusString);
            var responseVacancy = ScenarioContext.Current.Get<Vacancy>("responseVacancy");
            responseVacancy.Status.Should().Be(vacancyStatus);
        }
    }
}
