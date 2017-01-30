namespace SFA.DAS.RAA.Api.Models
{
    using System.ComponentModel.DataAnnotations;
    using Apprenticeships.Domain.Entities.Vacancies;

    /// <summary>
    /// Object containing all the wage information for a vacancy
    /// </summary>
    public class PublicWage
    {
        /// <summary>
        /// The basic type of the wage. Defines which additional properties will be set
        /// </summary>
        [Required]
        public WageType Type { get; set; }

        /// <summary>
        /// The fixed wage amount. Not set if the wage type is any other value
        /// </summary>
        public decimal? Amount { get; set; }

        /// <summary>
        /// The lowest possible value for a wage range. Not set if the wage type is any other value
        /// </summary>
        public decimal? AmountLowerBound { get; set; }

        /// <summary>
        /// The highest possible value for a wage range. Not set if the wage type is any other value
        /// </summary>
        public decimal? AmountUpperBound { get; set; }

        /// <summary>
        /// The formatted display text for the wage as defined by the type
        /// </summary>
        [Required]
        public string Text { get; set; }

        /// <summary>
        /// The specific time period a fixed or ranged wage is defined by. Weekly, Monthly or Yearly
        /// </summary>
        public WageUnit Unit { get; set; }

        /// <summary>
        /// The hours per week a candidate is expected to work to receive the defined wage
        /// </summary>
        public decimal? HoursPerWeek { get; set; }
    }
}