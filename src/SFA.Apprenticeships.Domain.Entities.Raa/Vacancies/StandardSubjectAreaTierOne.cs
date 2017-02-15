namespace SFA.Apprenticeships.Domain.Entities.Raa.Vacancies
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// StandardSubjectAreaTierOne instance
    /// </summary>
    public class StandardSubjectAreaTierOne
    {
        /// <summary>
        /// StandardSubjectAreaTierOne's  identifier
        /// </summary>
        [Required]
        public int Id { get; set; }

        /// <summary>
        /// StandardSubjectAreaTierOne's Name
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// StandardSubjectAreaTierOne's list of Sectors.
        /// </summary>
        public IEnumerable<Sector> Sectors { get; set; }

        protected bool Equals(StandardSubjectAreaTierOne other)
        {
            return Id == other.Id && string.Equals(Name, other.Name) && Equals(Sectors, other.Sectors);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((StandardSubjectAreaTierOne)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = Id;
                hashCode = (hashCode * 397) ^ (Name != null ? Name.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Sectors != null ? Sectors.GetHashCode() : 0);
                return hashCode;
            }
        }
    }
}