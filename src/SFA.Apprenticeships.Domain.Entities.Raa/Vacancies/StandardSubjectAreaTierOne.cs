namespace SFA.Apprenticeships.Domain.Entities.Raa.Vacancies
{
    using System.Collections.Generic;

    public class StandardSubjectAreaTierOne
    {
        public int Id { get; set; }
        public string Name { get; set; }
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