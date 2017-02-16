using System;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA.Api.AcceptanceTests.Steps
{
    using System.Collections.Generic;
    using System.Net;
    using System.Net.Http;
    using System.Text;
    using System.Threading.Tasks;
    using Apprenticeships.Domain.Entities.Raa.Vacancies;
    using Builders;
    using Constants;
    using Extensions;
    using FluentAssertions;
    using KellermanSoftware.CompareNetObjects;
    using MockProviders;
    using Models;
    using Newtonsoft.Json;
    using UnitTests.Factories;
    using VacancyLocationType = Apprenticeships.Domain.Entities.Raa.Vacancies.VacancyLocationType;

    [Binding]
    public class CreateVacancySteps
    {
        private const int ProviderSiteId = 24;

        private VacancyBuilder _vacancyBuilder;

        [Given(@"I am creating a vacancy")]
        public void GivenIAmCreatingAVacancy()
        {
            _vacancyBuilder = new VacancyBuilder();
        }

        #region Builder methods

        [When(@"I specify a location type of (.*)")]
        public void WhenISpecifyALocationTypeOfSpecificLocation(VacancyLocationType vacancyLocationType)
        {
            _vacancyBuilder.VacancyLocationType = vacancyLocationType;
        }

        [When(@"I specify vacancy owner relationship with id: (.*)")]
        public void WhenISpecifyVacancyOwnerRelationshipWithId(int vacancyOwnerRelationshipId)
        {
            _vacancyBuilder.VacancyOwnerRelationshipId = vacancyOwnerRelationshipId;
        }

        [When(@"I specify the vacancy has (.*) positions")]
        public void WhenISpecifyTheVacancyHasPositions(int positions)
        {
            _vacancyBuilder.NumberOfPositions = positions;
        }

        [When(@"I specify the vacancy status is (.*)")]
        public void WhenISpecifyTheVacancyStatusIs(VacancyStatus vacancyStatus)
        {
            _vacancyBuilder.VacancyStatus = vacancyStatus;
        }

        [When(@"I specify contract owner with id: (.*)")]
        public void WhenISpecifyContractOwnerWithId(int contractOwnerId)
        {
            _vacancyBuilder.ContractOwnerId = contractOwnerId;
        }

        [When(@"I specify (.*) as the vacancy title")]
        public void WhenISpecifyAsTheVacancyTitle(string title)
        {
            _vacancyBuilder.Title = title;
        }

        [When(@"I specify (.*) as the short description")]
        public void WhenISpecifyAsTheShortDescription(string shortDescription)
        {
            _vacancyBuilder.ShortDescription = shortDescription;
        }

        [When(@"I specify (.*) as the offline URL with (.*) as the offline application instructions")]
        public void WhenISpecifyAsTheOfflineUrlWithAsTheOfflineApplicationInstructions(string offlineApplicationUrl, string offlineApplicationInstructions)
        {
            _vacancyBuilder.OfflineApplicationUrl = offlineApplicationUrl;
            _vacancyBuilder.OfflineApplicationInstructions = offlineApplicationInstructions;
        }

        #endregion

        [When(@"I POST the vacancy to the API")]
        public async Task WhenIPostTheVacancyToTheApi()
        {
            VacancyMockProvider.MockVacancyOwnerRelationships();
            VacancyMockProvider.MockEmployer();
            VacancyMockProvider.MockProviderSite();
            VacancyMockProvider.MockVacancyCreation();

            await CreateVacancy(_vacancyBuilder.Build());
        }

        [Then(@"I see that the vacancy's status is (.*)")]
        public void ThenISeeThatTheVacancySStatusIs(VacancyStatus vacancyStatus)
        {
            var responseVacancy = ScenarioContext.Current.Get<Vacancy>("responseVacancy");
            responseVacancy.Status.Should().Be(vacancyStatus);
        }

        [Then(@"I see created vacancy matches the posted vacancy")]
        public void ThenISeeCreatedVacancyMatchesThePostedVacancy()
        {
            var responseVacancy = ScenarioContext.Current.Get<Vacancy>("responseVacancy");
            responseVacancy.Should().NotBeNull();
            responseVacancy.VacancyId.Should().NotBe(0);
            responseVacancy.VacancyReferenceNumber.Should().NotBe(0);
            responseVacancy.VacancySource.Should().Be(VacancySource.Api);
            var expectedVacancy = ScenarioContext.Current.Get<Vacancy>("requestVacancy");
            expectedVacancy.Status = responseVacancy.Status;
            expectedVacancy.VacancyId = responseVacancy.VacancyId;
            expectedVacancy.VacancyReferenceNumber = responseVacancy.VacancyReferenceNumber;
            expectedVacancy.VacancyGuid = responseVacancy.VacancyGuid;
            expectedVacancy.VacancySource = VacancySource.Api;
            expectedVacancy.ContractOwnerId = RaaApiUserFactory.SkillsFundingAgencyProviderId;
            expectedVacancy.OriginalContractOwnerId = RaaApiUserFactory.SkillsFundingAgencyProviderId;
            expectedVacancy.VacancyManagerId = ProviderSiteId;
            expectedVacancy.DeliveryOrganisationId = ProviderSiteId;
            expectedVacancy.Wage = responseVacancy.Wage;
            expectedVacancy.EditedInRaa = responseVacancy.EditedInRaa;
            expectedVacancy.EmployerWebsiteUrl = responseVacancy.EmployerWebsiteUrl;
            expectedVacancy.EmployerDescription = responseVacancy.EmployerDescription;
            expectedVacancy.Address = responseVacancy.Address;
            expectedVacancy.VacancyLocations = new List<VacancyLocation>();
            expectedVacancy.IsMultiLocation = false;

            var compareLogic = new CompareLogic();
            var result = compareLogic.Compare(responseVacancy, expectedVacancy);
            result.AreEqual.Should().BeTrue();
            Equals(responseVacancy, expectedVacancy).Should().BeTrue();
        }

        [Then(@"I do not see created vacancy")]
        public void ThenIDoNotSeeCreatedVacancy()
        {
            var responseVacancy = ScenarioContext.Current.Get<Vacancy>("responseVacancy");
            responseVacancy.Should().BeNull();
            var expectedVacancy = ScenarioContext.Current.Get<Vacancy>("requestVacancy");
            Equals(responseVacancy, expectedVacancy).Should().BeFalse();
        }

        private static async Task CreateVacancy(Vacancy vacancy)
        {
            const string createVacancyUri = UriFormats.CreateVacancyUri;

            var httpClient = FeatureContext.Current.TestServer().HttpClient;
            httpClient.SetAuthorization();

            ScenarioContext.Current.Add("requestVacancy", vacancy);

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
    }
}
