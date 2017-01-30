using TechTalk.SpecFlow;

namespace SFA.DAS.RAA.Api.AcceptanceTests.Steps
{
    using Apprenticeships.Domain.Entities.ReferenceData;
    using Apprenticeships.Infrastructure.Repositories.Sql.Schemas.Reference;
    using Apprenticeships.Infrastructure.Repositories.Sql.Schemas.Reference.Entities;
    using Constants;
    using Extensions;
    using Factories;
    using Models;
    using Newtonsoft.Json;
    using Ploeh.AutoFixture;
    using System.Net;
    using System.Threading.Tasks;

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
            //var vacancy = ScenarioContext.Current.Get<Apprenticeships.Infrastructure.Repositories.Sql.Schemas.Vacancy.Entities.Vacancy>($"vacancyId: {vacancyId}");
            var framework = ScenarioContext.Current.Get<Category>($"");
            var frameworks = ScenarioContext.Current.Get<Category>();
            //var vacancyUri = string.Format(UriFormats.VacancyIdUriFormat, vacancyId);
            //var responseVacancy = ScenarioContext.Current.Get<Vacancy>(vacancyUri);

            //vacancy.Should().NotBeNull();
            //responseVacancy.Should().NotBeNull();

            //var comparer = new DbVacancyComparer();
            //comparer.Equals(vacancy, responseVacancy).Should().BeTrue();
            var test = frameworks;
        }

        private async Task GetAllFrameworks()
        {
            var framework1 = new Fixture().Build<ApprenticeshipOccupation>()
                .With(v => v.CodeName, "990")
                .With(v => v.FullName, "Test Framework")
                .With(v => v.ShortName, "990")
                .With(v => v.ApprenticeshipOccupationId, 01)
                .Create();

            var framework2 = new Fixture().Build<ApprenticeshipOccupation>()
                .With(v => v.CodeName, "996")
                .With(v => v.FullName, "Another Test Framework")
                .With(v => v.ShortName, "996")
                .With(v => v.ApprenticeshipOccupationId, 02)
                .Create();

            ScenarioContext.Current.Add($"framework1 : {framework1.CodeName}", framework1);
            ScenarioContext.Current.Add($"framework2 : {framework2.CodeName}", framework2);

            //ScenarioContext.Current.Add($"framework1 : {framework1.FullName}", framework1);
            //ScenarioContext.Current.Add($"framework2 : {framework2.FullName}", framework2);

            //ScenarioContext.Current.Add($"framework1 : {framework1.ShortName}", framework1);
            //ScenarioContext.Current.Add($"framework2 : {framework2.ShortName}", framework2);

            //ScenarioContext.Current.Add($"framework1 : {framework1.ApprenticeshipOccupationId}", framework1);
            //ScenarioContext.Current.Add($"framework2 : {framework2.ApprenticeshipOccupationId}", framework2);

            RaaMockFactory.GetMockGetOpenConnection().Setup(
                m => m.Query<ApprenticeshipOccupation>(ReferenceRepository.FrameworkSql, null, null, null))
                .Returns(new[] { framework1, framework2 });

            var httpClient = FeatureContext.Current.TestServer().HttpClient;

            string requestUri = "/frameworks";
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

                    //var responseCategory = JsonConvert.DeserializeObject<Category>(content);
                    //if (responseCategory != null && new VacancyComparer().Equals(responseCategory, new Category()))
                    //{
                    //    responseCategory = null;
                    //}
                    ScenarioContext.Current.Add(requestUri, response);
                }
            }
        }
    }
}
