﻿using System;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA.Api.AcceptanceTests.Steps
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Text;
    using System.Threading.Tasks;
    using Apprenticeships.Domain.Entities.Raa.Vacancies;
    using Apprenticeships.Infrastructure.Repositories.Sql.Schemas.dbo;
    using Apprenticeships.Infrastructure.Repositories.Sql.Schemas.dbo.Entities;
    using Apprenticeships.Infrastructure.Repositories.Sql.Schemas.Provider;
    using Apprenticeships.Infrastructure.Repositories.Sql.Schemas.Provider.Entities;
    using Apprenticeships.Infrastructure.Repositories.Sql.Schemas.Vacancy;
    using Builders;
    using Constants;
    using Extensions;
    using Factories;
    using FluentAssertions;
    using KellermanSoftware.CompareNetObjects;
    using MockProviders;
    using Models;
    using Moq;
    using Newtonsoft.Json;
    using Ploeh.AutoFixture;
    using UnitTests.Factories;
    using DbVacancy = Apprenticeships.Infrastructure.Repositories.Sql.Schemas.Vacancy.Entities.Vacancy;
    using VacancyLocationType = Apprenticeships.Domain.Entities.Raa.Vacancies.VacancyLocationType;
    using VacancyOwnerRelationship = Apprenticeships.Infrastructure.Repositories.Sql.Schemas.dbo.Entities.VacancyOwnerRelationship;

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
        public void ThenISeeThatTheVacancySStatusIs(string vacancyStatusString)
        {
            var vacancyStatus = (VacancyStatus)Enum.Parse(typeof(VacancyStatus), vacancyStatusString);
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
