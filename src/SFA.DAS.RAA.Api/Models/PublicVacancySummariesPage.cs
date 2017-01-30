namespace SFA.DAS.RAA.Api.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Contains a page of live vacancy summaries along with metadata about the page
    /// </summary>
    public class PublicVacancySummariesPage : Page
    {
        /// <summary>
        /// The currently requested page of live vacancy summaries
        /// </summary>
        [Required]
        public IList<PublicVacancySummary> VacancySummaries { get; set; }
    }
}