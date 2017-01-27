namespace SFA.DAS.RAA.Api.Models
{
    using System.Collections.Generic;

    public class PublicVacancySummariesPage : Page
    {
        public IList<PublicVacancySummary> PublicVacancySummaries { get; set; }
    }
}