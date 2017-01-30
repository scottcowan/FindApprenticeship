namespace SFA.Apprenticeships.Domain.Entities.Raa.Reference
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// The information related to a UK local authority
    /// </summary>
    public class LocalAuthority
    {
        /// <summary>
        /// The local authority's primary identifier
        /// </summary>
        [Required]
        public int LocalAuthorityId { get; set; }

        /// <summary>
        /// The local authority's code identifier
        /// </summary>
        [Required]
        public string CodeName { get; set; }

        /// <summary>
        /// The shortened name of the local authority. Usually the same as the code
        /// </summary>
        [Required]
        public string ShortName { get; set; }

        /// <summary>
        /// The local authority's full name
        /// </summary>
        [Required]
        public string FullName { get; set; }

        /// <summary>
        /// The county this local authority belongs to
        /// </summary>
        [Required]
        public County County { get; set; }

        /// <summary>
        /// The region this local authority belongs to
        /// </summary>
        [Required]
        public Region Region { get; set; }

        protected bool Equals(LocalAuthority other)
        {
            return LocalAuthorityId == other.LocalAuthorityId && string.Equals(CodeName, other.CodeName) && string.Equals(ShortName, other.ShortName) && string.Equals(FullName, other.FullName) && Equals(County, other.County) && Equals(Region, other.Region);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((LocalAuthority) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = LocalAuthorityId;
                hashCode = (hashCode * 397) ^ (CodeName != null ? CodeName.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (ShortName != null ? ShortName.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (FullName != null ? FullName.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (County != null ? County.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Region != null ? Region.GetHashCode() : 0);
                return hashCode;
            }
        }
    }
}