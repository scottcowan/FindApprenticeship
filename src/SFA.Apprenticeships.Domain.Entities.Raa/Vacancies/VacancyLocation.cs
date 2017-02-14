namespace SFA.Apprenticeships.Domain.Entities.Raa.Vacancies
{
    using Locations;

    /// <summary>
    /// Properties for a location of a vacancy. Used when creating a vacancy with multiple locations or where the location is different to the employer's location
    /// </summary>
    public class VacancyLocation
    {
        /// <summary>
        /// The primary identifier of this vacancy location. Automatically generated when vacancy is created
        /// </summary>
        public int VacancyLocationId { get; set; }
        /// <summary>
        /// The primary identifier of the vacancy this location is for
        /// </summary>
        public int VacancyId { get; set; }
        /// <summary>
        /// The address of this location
        /// </summary>
        public PostalAddress Address { get; set; }
        /// <summary>
        /// The number of positions available at this location
        /// </summary>
        public int NumberOfPositions { get; set; }
        /// <summary>
        /// Only used for offline vacancies. If set, this is the URL of the website a candidate can apply for this vacancy on
        /// </summary>
        public string EmployersWebsite { get; set; }

        public VacancyLocation Clone()
        {
            return new VacancyLocation
            {
                VacancyLocationId = VacancyLocationId,
                VacancyId = VacancyId,
                Address = Address.Clone(),
                NumberOfPositions = NumberOfPositions,
                EmployersWebsite = EmployersWebsite
            };
        }
    }
}