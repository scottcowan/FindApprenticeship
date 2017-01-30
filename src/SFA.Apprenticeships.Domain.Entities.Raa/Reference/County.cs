namespace SFA.Apprenticeships.Domain.Entities.Raa.Reference
{
    /// <summary>
    /// The information related to a UK county
    /// </summary>
    public class County
    {
        /// <summary>
        /// The county's primary identifier
        /// </summary>
        public int CountyId { get; set; }

        /// <summary>
        /// The county's code identifier
        /// </summary>
        public string CodeName { get; set; }

        /// <summary>
        /// The shortened name of the county. Usually the same as the code
        /// </summary>
        public string ShortName { get; set; }

        /// <summary>
        /// The county's full name
        /// </summary>
        public string FullName { get; set; }

        protected bool Equals(County other)
        {
            return CountyId == other.CountyId && string.Equals(CodeName, other.CodeName) && string.Equals(ShortName, other.ShortName) && string.Equals(FullName, other.FullName);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((County) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = CountyId;
                hashCode = (hashCode * 397) ^ (CodeName != null ? CodeName.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (ShortName != null ? ShortName.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (FullName != null ? FullName.GetHashCode() : 0);
                return hashCode;
            }
        }
    }
}