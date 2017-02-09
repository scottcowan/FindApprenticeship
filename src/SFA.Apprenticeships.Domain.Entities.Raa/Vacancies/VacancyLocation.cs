namespace SFA.Apprenticeships.Domain.Entities.Raa.Vacancies
{
    using Locations;

    public class VacancyLocation
    {
        public int VacancyLocationId { get; set; }
        public int VacancyId { get; set; }
        public PostalAddress Address { get; set; }
        public int NumberOfPositions { get; set; }
        public string LocalAuthorityCode { get; set; }
        public string EmployersWebsite { get; set; }

        public VacancyLocation Clone()
        {
            return new VacancyLocation
            {
                VacancyLocationId = VacancyLocationId,
                VacancyId = VacancyId,
                Address = Address.Clone(),
                NumberOfPositions = NumberOfPositions,
                LocalAuthorityCode = LocalAuthorityCode,
                EmployersWebsite = EmployersWebsite
            };
        }
    }
}