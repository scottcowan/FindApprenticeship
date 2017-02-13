namespace SFA.Apprenticeships.Domain.Entities.Raa.Reference
{
    using ReferenceData;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Framework instance
    /// </summary>
    public class Framework
    {
        /// <summary>
        /// Framework constructor
        /// </summary>
        public Framework()
        {
            Status = FrameworkStatusType.Active;
        }

        /// <summary>
        /// Framework's identifier
        /// </summary>
        [Required]
        public int Id { get; set; }

        /// <summary>
        /// Framework's codename
        /// </summary>
        [Required]
        public string CodeName { get; set; }

        /// <summary>
        /// Framework's shortname
        /// </summary>
        [Required]
        public string ShortName { get; set; }

        /// <summary>
        /// Framework's fullname
        /// </summary>
        [Required]
        public string FullName { get; set; }

        /// <summary>
        /// Framework's ParentCategory Code name
        /// </summary>
        public string ParentCategoryCodeName { get; set; }

        /// <summary>
        /// Framework's status
        /// </summary>
        [Required]
        public FrameworkStatusType Status { get; set; }

        /// <summary>
        /// TODO: Do this a better way
        /// </summary>
        /// <returns></returns>
        public Category ToCategory()
        {
            return new Category(Id, CategoryPrefixes.GetFrameworkCode(CodeName), FullName, CategoryPrefixes.GetSectorSubjectAreaTier1Code(ParentCategoryCodeName), CategoryType.Framework, (CategoryStatus)(int)Status);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        protected bool Equals(Framework other)
        {
            return Id == other.Id && string.Equals(CodeName, other.CodeName) && string.Equals(ShortName, other.ShortName) && string.Equals(FullName, other.FullName) && string.Equals(ParentCategoryCodeName, other.ParentCategoryCodeName) && Status == other.Status;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Framework)obj);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = Id;
                hashCode = (hashCode * 397) ^ (CodeName != null ? CodeName.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (ShortName != null ? ShortName.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (FullName != null ? FullName.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (ParentCategoryCodeName != null ? ParentCategoryCodeName.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (int)Status;
                return hashCode;
            }
        }
    }
}
