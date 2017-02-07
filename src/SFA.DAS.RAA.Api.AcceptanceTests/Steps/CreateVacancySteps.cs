using System;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA.Api.AcceptanceTests.Steps
{
    using System.Collections.Generic;
    using System.Dynamic;
    using System.Net;
    using System.Net.Http;
    using System.Text;
    using System.Threading.Tasks;
    using Apprenticeships.Domain.Entities.Raa.Parties;
    using Apprenticeships.Domain.Entities.Raa.Vacancies;
    using Apprenticeships.Infrastructure.Repositories.Sql.Schemas.dbo;
    using Constants;
    using Extensions;
    using Factories;
    using FluentAssertions;
    using Models;
    using Moq;
    using Newtonsoft.Json;
    using Ploeh.AutoFixture;
    using VacancyOwnerRelationship = Apprenticeships.Infrastructure.Repositories.Sql.Schemas.dbo.Entities.VacancyOwnerRelationship;

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
        public async Task WhenIRequestToCreateASpecificLocationVacancyForVacancyOwnerRelationshipWithIdAndPositions(VacancyLocationType vacancyLocationType, int vacancyOwnerRelationshipId, int positions)
        {
            const int vorOwnedId = 42;
            const int providerSiteId = 24;

            var vorOwned = new Fixture().Build<VacancyOwnerRelationship>()
                .With(vor => vor.VacancyOwnerRelationshipId, vorOwnedId)
                .With(vor => vor.ProviderSiteID, 24)
                .Create();

            RaaMockFactory.GetMockGetOpenConnection()
                .Setup(
                    m =>
                        m.Query<VacancyOwnerRelationship>(
                            It.Is<string>(s => s.StartsWith(VacancyOwnerRelationshipRepository.SelectByIdsSql)),
                            It.Is<object>(o => o.GetPropertyValue<int[]>("VacancyOwnerRelationshipIds")[0] == vorOwnedId), null, null))
                .Returns(new[] {vorOwned});

            var vacancy = GetVacancy(vacancyLocationType, vacancyOwnerRelationshipId, positions);

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

        private static Vacancy GetVacancy(VacancyLocationType vacancyLocationType, int vacancyOwnerRelationshipId, int positions)
        {
            var vacancy = new Vacancy
            {
                VacancyLocationType = vacancyLocationType,
                VacancyOwnerRelationshipId = vacancyOwnerRelationshipId,
                NumberOfPositions = positions
            };
            return vacancy;
        }

        [Then(@"I see the (.*) vacancy for vacancy owner relationship with id: (.*) and (.*) positions")]
        public void ThenISeeTheSpecificLocationVacancyForVacancyOwnerRelationshipWithIdAndPositions(VacancyLocationType vacancyLocationType, int vacancyOwnerRelationshipId, int positions)
        {
            var responseVacancy = ScenarioContext.Current.Get<Vacancy>("responseVacancy");
            responseVacancy.Should().NotBeNull();
            responseVacancy.VacancyId.Should().NotBe(0);
            responseVacancy.VacancyReferenceNumber.Should().NotBe(0);
            responseVacancy.VacancySource.Should().Be(VacancySource.Api);
            var expectedVacancy = GetVacancy(vacancyLocationType, vacancyOwnerRelationshipId, positions);
            expectedVacancy.Status = VacancyStatus.Draft;
            expectedVacancy.VacancyId = responseVacancy.VacancyId;
            expectedVacancy.VacancyReferenceNumber = responseVacancy.VacancyReferenceNumber;
            expectedVacancy.VacancySource = responseVacancy.VacancySource;
            Equals(responseVacancy, expectedVacancy).Should().BeTrue();
        }

        [Then(@"I do not see the (.*) vacancy for vacancy owner relationship with id: (.*) and (.*) positions")]
        public void ThenIDoNotSeeTheSpecificLocationVacancyForVacancyOwnerRelationshipWithIdAndPositions(VacancyLocationType vacancyLocationType, int vacancyOwnerRelationshipId, int positions)
        {
            var responseVacancy = ScenarioContext.Current.Get<Vacancy>("responseVacancy");
            responseVacancy.Should().BeNull();
            var expectedVacancy = GetVacancy(vacancyLocationType, vacancyOwnerRelationshipId, positions);
            Equals(responseVacancy, expectedVacancy).Should().BeFalse();
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
