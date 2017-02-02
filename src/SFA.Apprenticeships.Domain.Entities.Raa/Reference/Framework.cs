namespace SFA.Apprenticeships.Domain.Entities.Raa.Reference
{
    using ReferenceData;

    public class Framework
    {
        public Framework()
        {
            Status = FrameworkStatusType.Active;
        }

        public int Id { get; set; }

        public string CodeName { get; set; }

        public string ShortName { get; set; }

        public string FullName { get; set; }

        public string ParentCategoryCodeName { get; set; }

        public FrameworkStatusType Status { get; set; }

        /// <summary>
        /// TODO: Do this a better way
        /// </summary>
        /// <returns></returns>
        public Category ToCategory()
        {
            return new Category(Id, CategoryPrefixes.GetFrameworkCode(CodeName), FullName, CategoryPrefixes.GetSectorSubjectAreaTier1Code(ParentCategoryCodeName), CategoryType.Framework, (CategoryStatus)(int)Status);
        }

        protected bool Equals(Framework other)
        {
            return Id == other.Id && string.Equals(CodeName, other.CodeName) && string.Equals(ShortName, other.ShortName) && string.Equals(FullName, other.FullName) && string.Equals(ParentCategoryCodeName, other.ParentCategoryCodeName) && Status == other.Status;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Framework)obj);
        }

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
