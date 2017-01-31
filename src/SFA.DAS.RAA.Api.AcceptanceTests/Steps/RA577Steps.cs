using TechTalk.SpecFlow;

namespace SFA.DAS.RAA.Api.AcceptanceTests.Steps
{
    using Apprenticeships.Domain.Entities.Raa.Vacancies;
    using Apprenticeships.Infrastructure.Repositories.Sql.Schemas.Reference;
    using Apprenticeships.Infrastructure.Repositories.Sql.Schemas.Reference.Entities;
    using Constants;
    using Extensions;
    using Factories;
    using FluentAssertions;
    using Models;
    using Newtonsoft.Json;
    using Ploeh.AutoFixture;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Threading.Tasks;
    using Standard = Apprenticeships.Infrastructure.Repositories.Sql.Schemas.Reference.Entities.Standard;

    [Binding]
    public class RA577Steps
    {
        [Given(@"On requesting for all frameworks")]
        public async Task GivenOnRequestingForAllFrameworks()
        {
            await GetAllFrameworks();
        }

        [Then(@"I see all the latest frameworks")]
        public void ThenISeeAllTheLatestFrameworks()
        {
            var frameworks = ScenarioContext.Current.Get<List<ApprenticeshipFramework>>("frameworks");
            var responseframeworks = ScenarioContext.Current.Get<IList<ApprenticeshipFramework>>("responseFrameworks");

            responseframeworks.Should().NotBeNullOrEmpty();
            responseframeworks.Count.Should().Be(frameworks.Count);
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

                    var responseFrameworks = JsonConvert.DeserializeObject<IList<ApprenticeshipFramework>>(content);
                    ScenarioContext.Current.Add("responseFrameworks", responseFrameworks);
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

            var sectors = new Fixture().CreateMany<StandardSector>(3).ToList();
            var occupations = new Fixture().CreateMany<ApprenticeshipOccupation>(3).ToList();
            var educationLevelWithId1 = new Fixture().Build<EducationLevel>().With(c => c.EducationLevelId, 1)
                .With(c => c.CodeName, "2")
                .Create();
            var standardsWithId1 = new Fixture().Build<Standard>()
                .With(s => s.EducationLevelId, 1)
                .Create();
            var educationLevelWithId2 = new Fixture().Build<EducationLevel>().With(c => c.EducationLevelId, 2)
                .With(c => c.CodeName, "2")
                .Create();
            var standardsWithId2 = new Fixture().Build<Standard>()
                .With(s => s.EducationLevelId, 2).Create();

            var standards = new List<Standard>();
            var educationLevels = new List<EducationLevel>();
            standards.Add(standardsWithId1);
            standards.Add(standardsWithId2);
            educationLevels.Add(educationLevelWithId1);
            educationLevels.Add(educationLevelWithId2);
            //standards.Add(standardsWithId);
            //educationLevels.Add(educationLevelWithId);
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
                m => m.Query<Apprenticeships.Infrastructure.Repositories.Sql.Schemas.Reference.Entities.Standard>(ReferenceRepository.GetStandardSql, null, null, null))
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

                    var responseFrameworks = JsonConvert.DeserializeObject<IList<StandardSubjectAreaTierOne>>(content);
                    ScenarioContext.Current.Add("responseFrameworks", responseFrameworks);
                }
            }
        }

        [Then(@"I see all the latest standards")]
        public void ThenISeeAllTheLatestStandards()
        {
            ScenarioContext.Current.Pending();
        }
    }
}
