using System.Collections.Generic;
using SFA.Apprenticeships.Domain.Entities.Raa.Vacancies;
using SFA.Apprenticeships.Domain.Raa.Interfaces.Repositories.Models;
using SFA.DAS.RAA.Api.AcceptanceTests.Constants;

namespace SFA.DAS.RAA.Api.AcceptanceTests.Builders
{
    public class VacancySummaryBuilder
    {
        public string SearchQuery { get; set; }
        public int? Page { get; set; }
        public int? TotalCount { get; set; }
        public int? PageSize { get; set; }

        public VacancySearchMode? SearchMode { get; set; }
        public VacancyType VacancyType { get; set; }
        public VacancySummaryOrderByColumn OrderBy { get; set; }
        public Order Order { get; set; }
        public VacanciesSummaryFilterTypes Status { get; set; }


        public string BuildUrl()
        {
            var url = UriFormats.VacancySummariesUriFormat;

            var queryString = new List<string>
            {
                $"page={Page ?? 1}",
                $"pageSize={PageSize ?? 50}"
            };

            if (!string.IsNullOrEmpty(SearchQuery)) queryString.Add($"searchString={System.Web.HttpUtility.UrlEncode(SearchQuery)}");
            if (!string.IsNullOrEmpty(SearchQuery)) queryString.Add($"searchMode={SearchMode.ToString()}");
            if (!string.IsNullOrEmpty(SearchQuery)) queryString.Add($"vacancyType={VacancyType.ToString()}");
            if (!string.IsNullOrEmpty(SearchQuery)) queryString.Add($"orderBy={OrderBy.ToString()}");
            if (!string.IsNullOrEmpty(SearchQuery)) queryString.Add($"order={Order.ToString()}");

            url += "?" + string.Join("&", queryString);

            return url;
        }
    }
}
