using System.Net;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SFA.Apprenticeships.Domain.Entities.Raa.Vacancies;
using SFA.Apprenticeships.Domain.Raa.Interfaces.Repositories.Models;
using SFA.DAS.RAA.Api.AcceptanceTests.Builders;
using SFA.DAS.RAA.Api.AcceptanceTests.Constants;
using SFA.DAS.RAA.Api.AcceptanceTests.Contexts;
using SFA.DAS.RAA.Api.AcceptanceTests.Extensions;
using SFA.DAS.RAA.Api.AcceptanceTests.MockProviders;
using SFA.DAS.RAA.Api.AcceptanceTests.Models;
using SFA.DAS.RAA.Api.Models;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA.Api.AcceptanceTests.Steps
{
    [Binding]
    public class GetVacancySummarySteps
    {
        private readonly VacancySummaryContext _context;
        private readonly VacancySummaryBuilder _builder;

        public GetVacancySummarySteps(VacancySummaryContext context, VacancySummaryBuilder builder)
        {
            _context = context;
            _builder = builder;
        }

        [Given(@"There are (.*) vacancy summaries in the database")]
        public void GivenThereAreVacancySummariesInTheDatabase(int totalCount)
        {
            _builder.TotalCount = totalCount;
        }

        [When(@"I request page (.*) of the vacancy summaries with page size: (.*)")]
        public async Task WhenIRequestPageOfTheListOfVacancySummaries(int page, int pageSize)
        {
            _builder.Page = page;
            _builder.PageSize = pageSize;

            await GetVacancySummaries(_builder.BuildUrl(), _builder);
        }

        [When(@"I filter the results with the query '(.*)'")]
        public void WhenIFilterTheResultsWithTheQuery(string searchQuery)
        {
            _builder.SearchQuery = searchQuery;
        }

        [When(@"I search all fields")]
        public void WhenISearchAllFields()
        {
            _builder.SearchMode = VacancySearchMode.All;
        }

        [When(@"I only search the (.*) field")]
        public void WhenISeearchField(VacancySearchMode field)
        {
            _builder.SearchMode = field;
        }

        [When(@"I filter the results to the (.*) vacancy type")]
        public void WhenIFilterTheResultsToTheVacancyType(VacancyType type)
        {
            _builder.VacancyType = type;
        }

        [When(@"The results are ordered by (.*), (.*)")]
        public void WhenTheResultsAreOrderedBy(Order order, VacancySummaryOrderByColumn orderedBy)
        {
            _builder.Order = order;
            _builder.OrderBy = orderedBy;
        }

        [When(@"I filter the results to (.*) status")]
        public void WhenIFilterTheResultsToStatus(VacanciesSummaryFilterTypes status)
        {
            _builder.Status = status;
        }

        public async Task GetVacancySummaries(string vacancySummariesUri, VacancySummaryBuilder builder)
        {
            VacancySummaryMockProvider.MockAssortedVacancySummaries(builder.TotalCount ?? 50, builder.PageSize ?? 50);
            VacancySummaryMockProvider.MockProviderSites();

            var httpClient = FeatureContext.Current.TestServer().HttpClient;
            httpClient.SetAuthorization();

            using (var response = await httpClient.GetAsync(vacancySummariesUri))
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

                    var responseVacancySummaries = JsonConvert.DeserializeObject<VacancySummariesPage>(content);
                    ScenarioContext.Current.Add("responseVacancySummaries", responseVacancySummaries);
                }
            }
        }
    }
}
