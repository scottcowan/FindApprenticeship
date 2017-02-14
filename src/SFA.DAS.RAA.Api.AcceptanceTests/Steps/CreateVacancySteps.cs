using System;
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
    using Constants;
    using Extensions;
    using Factories;
    using FluentAssertions;
    using KellermanSoftware.CompareNetObjects;
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
            
            var vorOwned = new Fixture().Build<VacancyOwnerRelationship>()
                .With(vor => vor.VacancyOwnerRelationshipId, vorOwnedId)
                .With(vor => vor.ProviderSiteID, 24)
                .Create();

            var employer = new Fixture().Build<Employer>()
                .With(e => e.EmployerId, vorOwned.EmployerId)
                .Create();

            var providerSite = new Fixture().Build<ProviderSite>()
                .With(ps => ps.ProviderSiteId, ProviderSiteId)
                .Create();

            var providerSiteRelationship = new Fixture().Build<ProviderSiteRelationship>()
                .With(psr => psr.ProviderId, RaaApiUserFactory.SkillsFundingAgencyProviderId)
                .With(psr => psr.ProviderSiteId, providerSite.ProviderSiteId)
                .With(psr => psr.ProviderSiteRelationShipTypeId, 1)
                .Create();

            RaaMockFactory.GetMockGetOpenConnection()
                .Setup(
                    m =>
                        m.Query<VacancyOwnerRelationship>(
                            It.Is<string>(s => s.StartsWith(VacancyOwnerRelationshipRepository.SelectByIdsSql)),
                            It.Is<object>(o => o.GetPropertyValue<int[]>("VacancyOwnerRelationshipIds")[0] == vorOwnedId),
                            null, null))
                .Returns(new[] {vorOwned});

            RaaMockFactory.GetMockGetOpenConnection().Setup(
                m => m.Query<ProviderSite>(It.Is<string>(s => s.StartsWith(ProviderSiteRepository.SelectByProviderIdSql)), It.Is<object>(o => o.GetPropertyValue<int>("providerId") == RaaApiUserFactory.SkillsFundingAgencyProviderId), null, null))
                .Returns(new[] { providerSite });

            RaaMockFactory.GetMockGetOpenConnection().Setup(
                m => m.Query<ProviderSiteRelationship>(It.Is<string>(s => s.StartsWith(ProviderSiteRepository.SelectProviderSiteRelationshipsByProviderSiteIdsSql)), It.Is<object>(o => o.GetPropertyValue<IEnumerable<int>>("providerSiteIds").Contains(ProviderSiteId)), null, null))
                .Returns(new[] { providerSiteRelationship });

            RaaMockFactory.GetMockGetOpenConnection().Setup(
                m => m.Query<int>(ReferenceNumberRepository.GetNextVacancyReferenceNumberSql, null, null, null))
                .Returns(new [] {450987});

            RaaMockFactory.GetMockGetOpenConnection().Setup(m => m.Insert(It.IsAny<DbVacancy>(), null)).Returns(3453).Callback<DbVacancy, int?>(
                (v, ct) =>
                {
                    RaaMockFactory.GetMockGetOpenConnection()
                        .Setup(
                            m =>
                                m.Query<DbVacancy>(VacancyRepository.SelectByIdSql,
                                    It.Is<object>(o => o.GetHashCode() == new {vacancyId = 3453}.GetHashCode()), null,
                                    null))
                        .Returns(new[] {v});
                });

            RaaMockFactory.GetMockGetOpenConnection().Setup(
                m => m.Query<Employer>(It.Is<string>(s => s.StartsWith(EmployerRepository.BasicQuery)), It.Is<object>(o => o.GetHashCode() == new {vorOwned.EmployerId }.GetHashCode()), null, null))
                .Returns(new[] { employer });

            RaaMockFactory.GetMockGetOpenConnection().Setup(
                m => m.Query<Employer>(It.Is<string>(s => s.StartsWith(EmployerRepository.BasicQuery)), It.Is<object>(o => o.GetHashCode() == new {employer.EdsUrn }.GetHashCode()), null, null))
                .Returns(new[] { employer });

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
                VacancyGuid = Guid.NewGuid(),
                VacancyLocationType = vacancyLocationType,
                VacancyOwnerRelationshipId = vacancyOwnerRelationshipId,
                NumberOfPositions = positions,
                ContractOwnerId = RaaApiUserFactory.SkillsFundingAgencyProviderId,
                Status = VacancyStatus.Live
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
