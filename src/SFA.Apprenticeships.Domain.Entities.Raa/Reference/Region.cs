namespace SFA.Apprenticeships.Domain.Entities.Raa.Reference
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// The information related to a UK region
    /// </summary>
    public class Region
    {
        /// <summary>
        /// The region's primary identifier
        /// </summary>
        [Required]
        public int RegionId { get; set; }

        /// <summary>
        /// The region's code identifier
        /// </summary>
        [Required]
        public string CodeName { get; set; }

        /// <summary>
        /// The shortened name of the region. Usually the same as the code
        /// </summary>
        [Required]
        public string ShortName { get; set; }

        /// <summary>
        /// The region's full name
        /// </summary>
        [Required]
        public string FullName { get; set; }

        protected bool Equals(Region other)
        {
            return RegionId == other.RegionId && string.Equals(CodeName, other.CodeName) && string.Equals(ShortName, other.ShortName) && string.Equals(FullName, other.FullName);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Region) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = RegionId;
                hashCode = (hashCode * 397) ^ (CodeName != null ? CodeName.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (ShortName != null ? ShortName.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (FullName != null ? FullName.GetHashCode() : 0);
                return hashCode;
            }
        }
    }
}