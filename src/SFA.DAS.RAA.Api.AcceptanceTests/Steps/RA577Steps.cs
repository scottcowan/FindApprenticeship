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
    using System.Collections.Generic;
    using System.Linq;
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

                    var apprenticeshipFrameworks = JsonConvert.DeserializeObject<IList<ApprenticeshipFramework>>(content);
                    ScenarioContext.Current.Add("apprenticeshipFrameworks", apprenticeshipFrameworks);
                }
            }
        }
    }
}
