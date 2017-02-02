﻿using TechTalk.SpecFlow;

namespace SFA.DAS.RAA.Api.AcceptanceTests.Steps
{
    using Apprenticeships.Domain.Entities.Raa.Reference;
    using Apprenticeships.Domain.Entities.Raa.Vacancies;
    using Apprenticeships.Domain.Entities.ReferenceData;
    using Apprenticeships.Infrastructure.Repositories.Sql.Schemas.Reference;
    using Apprenticeships.Infrastructure.Repositories.Sql.Schemas.Reference.Entities;
    using Constants;
    using Extensions;
    using Factories;
    using FluentAssertions;
    using Models;
    using Moq;
    using Newtonsoft.Json;
    using Ploeh.AutoFixture;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Threading.Tasks;
    using Standard = Apprenticeships.Infrastructure.Repositories.Sql.Schemas.Reference.Entities.Standard;

    [Binding]
    public class GetFrameworksAndStandardsSteps
    {
        [Given(@"On requesting for all frameworks")]
        public async Task GivenOnRequestingForAllFrameworks()
        {
            await GetAllFrameworks();
        }

        [Then(@"I see all the latest frameworks")]
        public void ThenISeeAllTheLatestFrameworks()
        {
            var occupations = ScenarioContext.Current.Get<List<ApprenticeshipOccupation>>("occupations");
            var responseCategories = ScenarioContext.Current.Get<List<Category>>("responseCategories");

            responseCategories.Should().NotBeNullOrEmpty();
            responseCategories.Count.Should().Be(occupations.Count);
            for (int i = 0; i < responseCategories.Count; i++)
            {
                var occupation = occupations[i];
                var responseCategory = responseCategories[i];
                responseCategory.Id.Should().Be(occupation.ApprenticeshipOccupationId);
                int statusAsInt = (int)responseCategory.Status;
                statusAsInt.Should().Be(occupation.ApprenticeshipOccupationStatusTypeId);
            }
        }

        private async Task GetAllFrameworks()
        {
            const string requestUri = UriFormats.GetFrameworksUri;

            var frameworks = new Fixture().CreateMany<ApprenticeshipFramework>(3).ToList();

            var occupations = new Fixture().CreateMany<ApprenticeshipOccupation>(3).ToList();

            ScenarioContext.Current.Add("frameworks", frameworks);
            ScenarioContext.Current.Add("occupations", occupations);

            RaaMockFactory.GetMockGetOpenConnection().Setup(
                m => m.Query<ApprenticeshipFramework>(ReferenceRepository.GetFrameworkSql, null, null, null))
                .Returns(frameworks);

            RaaMockFactory.GetMockGetOpenConnection().Setup(
                m => m.Query<ApprenticeshipOccupation>(ReferenceRepository.GetOccupationSql, null, null, null))
                .Returns(occupations);

            var httpClient = FeatureContext.Current.TestServer().HttpClient;

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
                    var responseCategories = JsonConvert.DeserializeObject<IList<Category>>(content);
                    ScenarioContext.Current.Add("responseCategories", responseCategories);
                }
            }
        }

        [Given(@"On requesting for all standards")]
        public async Task GivenOnRequestingForAllStandards()
        {
            await GetAllStandards();
        }

        private async Task GetAllStandards()
        {
            const string requestUri = UriFormats.GetStandardssUri;

            var occupations = new Fixture().Build<ApprenticeshipOccupation>()
                .With(o => o.ApprenticeshipOccupationId, 5)
                .CreateMany(1).ToList();

            var sectorWithId1 = new Fixture().Build<StandardSector>()
                .With(ss => ss.StandardSectorId, 1)
                .With(ss => ss.ApprenticeshipOccupationId, 5)
                .Create();
            var sectorWithId2 = new Fixture().Build<StandardSector>()
                .With(ss => ss.StandardSectorId, 2)
                .With(ss => ss.ApprenticeshipOccupationId, 5)
                .Create();

            var standardsWithId1 = new Fixture().Build<Standard>()
                .With(s => s.EducationLevelId, 1)
                .With(s => s.StandardSectorId, 1)
                .Create();
            var standardsWithId2 = new Fixture().Build<Standard>()
                .With(s => s.EducationLevelId, 2)
                .With(s => s.StandardSectorId, 2)
                .Create();

            var educationLevelWithId1 = new Fixture().Build<EducationLevel>().With(c => c.EducationLevelId, 1)
                .With(c => c.CodeName, "2")
                .Create();
            var educationLevelWithId2 = new Fixture().Build<EducationLevel>().With(c => c.EducationLevelId, 2)
                .With(c => c.CodeName, "2")
                .Create();

            var standards = new List<Standard>();
            var educationLevels = new List<EducationLevel>();
            var sectors = new List<StandardSector>();
            standards.Add(standardsWithId1);
            standards.Add(standardsWithId2);
            educationLevels.Add(educationLevelWithId1);
            educationLevels.Add(educationLevelWithId2);
            sectors.Add(sectorWithId1);
            sectors.Add(sectorWithId2);
            ScenarioContext.Current.Add("sectors", sectors);
            ScenarioContext.Current.Add("occupations", occupations);
            ScenarioContext.Current.Add("standards", standards);
            ScenarioContext.Current.Add("educationLevels", educationLevels);

            RaaMockFactory.GetMockGetOpenConnection().Setup(
                m => m.Query<ApprenticeshipOccupation>(ReferenceRepository.GetOccupationSql, null, null, null))
                .Returns(occupations);

            RaaMockFactory.GetMockGetOpenConnection().Setup(
                m => m.Query<StandardSector>(ReferenceRepository.GetSectorSql, null, null, null))
                .Returns(sectors);

            RaaMockFactory.GetMockGetOpenConnection().Setup(
                m => m.Query<Standard>(ReferenceRepository.GetStandardSql, null, null, null))
                .Returns(standards);

            RaaMockFactory.GetMockGetOpenConnection().Setup(
                m => m.Query<EducationLevel>(ReferenceRepository.GetEducationLevelSql, null, null, null))
                .Returns(educationLevels);

            var httpClient = FeatureContext.Current.TestServer().HttpClient;

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

                    var responseStandardSubjectAreaTierOnes =
                        JsonConvert.DeserializeObject<IList<StandardSubjectAreaTierOne>>(content);
                    ScenarioContext.Current.Add("responseStandardSubjectAreaTierOnes",
                        responseStandardSubjectAreaTierOnes);
                }
            }
        }

        [Then(@"I see all the latest standards")]
        public void ThenISeeAllTheLatestStandards()
        {
            var occupations = ScenarioContext.Current.Get<List<ApprenticeshipOccupation>>("occupations");
            var sectors = ScenarioContext.Current.Get<List<StandardSector>>("sectors");
            var responseStandardSubjectAreaTierOnes =
                ScenarioContext.Current.Get<IList<StandardSubjectAreaTierOne>>("responseStandardSubjectAreaTierOnes");

            responseStandardSubjectAreaTierOnes.Should().NotBeNullOrEmpty();
            responseStandardSubjectAreaTierOnes.Count.Should().Be(occupations.Count);
            for (int i = 0; i < responseStandardSubjectAreaTierOnes.Count; i++)
            {
                var occupation = occupations[i];
                var standardSubjectAreaTierOne = responseStandardSubjectAreaTierOnes[i];
                //Ideally do a full compare
                standardSubjectAreaTierOne.Id.Should().Be(occupation.ApprenticeshipOccupationId);
                var ssat1Sectors = standardSubjectAreaTierOne.Sectors.ToList();
                ssat1Sectors.Count.Should().Be(sectors.Count);
                foreach (var ssat1Sector in ssat1Sectors)
                {
                    ssat1Sector.Standards.Count().Should().Be(1);
                    ssat1Sector.ApprenticeshipOccupationId.Should().Be(occupation.ApprenticeshipOccupationId);
                }
            }
        }

        [Given(@"I request the framework with id: (.*)")]
        public async Task GivenIRequestTheFrameworkWithId(int frameworkId)
        {
            var requestUri = string.Format(UriFormats.GetFrameworksByIdUri, frameworkId);
            await GetFrameworkById(requestUri);
        }

        private async Task GetFrameworkById(string requestUri)
        {
            var framework = new Fixture().Build<ApprenticeshipFramework>()
                .With(f => f.ApprenticeshipFrameworkId, 2)
                .With(f => f.ApprenticeshipFrameworkStatusTypeId, 1)
                .With(f => f.ApprenticeshipOccupationId, 1)
                .Create();

            var occupation = new Fixture().Build<ApprenticeshipOccupation>()
                .With(o => o.ApprenticeshipOccupationId, 1)
                .With(o => o.CodeName, "CodeName1")
                .Create();

            ScenarioContext.Current.Add("framework", framework);
            ScenarioContext.Current.Add("occupation", occupation);

            RaaMockFactory.GetMockGetOpenConnection().Setup(
                m => m.Query<ApprenticeshipFramework>(ReferenceRepository.GetFrameworkByIdSql,
                It.Is<object>(o => o.GetHashCode() == new { frameworkId = framework.ApprenticeshipFrameworkId }.GetHashCode()), null, null))
                .Returns(new[] { framework });

            RaaMockFactory.GetMockGetOpenConnection().Setup(
                m => m.Query<ApprenticeshipOccupation>(ReferenceRepository.GetOccupationByIdSql,
                It.Is<object>(o => o.GetHashCode() == new { occupationId = occupation.ApprenticeshipOccupationId }.GetHashCode()), null, null))
                .Returns(new[] { occupation });

            var httpClient = FeatureContext.Current.TestServer().HttpClient;

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
                    ScenarioContext.Current.Add("responseFramework",
                        responseFramework);
                }
            }
        }

        [Then(@"The response status is : NotFound")]
        public void ThenTheResponseStatusIsNotFound()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"I do not see the information for the framework with id:(.*)")]
        public void ThenIDoNotSeeTheInformationForTheFrameworkWithId(int p0)
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"I see the information for the framework with id: (.*)")]
        public void ThenISeeTheInformationForTheFrameworkWithId(int p0)
        {
            var occupations = ScenarioContext.Current.Get<List<ApprenticeshipOccupation>>("occupations");
            var responseFramework = ScenarioContext.Current.Get<Framework>("responseFramework");
            responseFramework.Should().NotBeNull();
        }



    }
}
