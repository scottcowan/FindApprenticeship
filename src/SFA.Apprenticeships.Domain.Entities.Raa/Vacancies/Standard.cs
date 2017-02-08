namespace SFA.Apprenticeships.Domain.Entities.Raa.Vacancies
{
    using Reference;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Standard instance
    /// </summary>
    public class Standard
    {
        /// <summary>
        /// Standard's Identifier
        /// </summary>
        [Required]
        public int Id { get; set; }

        /// <summary>
        /// Standard's sector id
        /// </summary>
        [Required]
        public int ApprenticeshipSectorId { get; set; }

        /// <summary>
        /// Standard's Name
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Standard's Apprenticeship level
        /// </summary>
        [Required]
        public ApprenticeshipLevel ApprenticeshipLevel { get; set; }

        /// <summary>
        /// Standard's Status
        /// </summary>
        [Required]
        public FrameworkStatusType Status { get; set; }

        /// <summary>
        /// Standard's Larscode
        /// </summary>
        [Required]
        public int LarsCode { get; set; }

        protected bool Equals(Standard other)
        {
            return Id == other.Id && ApprenticeshipSectorId == other.ApprenticeshipSectorId && string.Equals(Name, other.Name) && ApprenticeshipLevel == other.ApprenticeshipLevel && Status == other.Status;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Standard)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = Id;
                hashCode = (hashCode * 397) ^ ApprenticeshipSectorId;
                hashCode = (hashCode * 397) ^ (Name != null ? Name.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (int)ApprenticeshipLevel;
                hashCode = (hashCode * 397) ^ (int)Status;
                return hashCode;
            }
        }
    }
}