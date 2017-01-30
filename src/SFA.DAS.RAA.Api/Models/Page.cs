namespace SFA.DAS.RAA.Api.Models
{
    using System.ComponentModel.DataAnnotations;

    public abstract class Page
    {
        /// <summary>
        /// The total number of live vacancies available
        /// </summary>
        [Required]
        public int TotalCount { get; set; }

        /// <summary>
        /// The currently selected page
        /// </summary>
        [Required]
        public int CurrentPage { get; set; }

        /// <summary>
        /// The total number of pages of vacancies available
        /// </summary>
        [Required]
        public int TotalPages { get; set; }
    }
}