namespace SFA.Apprenticeships.Domain.Entities.Raa.Vacancies
{
    using System.Collections.Generic;

    public class Sector
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int ApprenticeshipOccupationId { get; set; }

        public IEnumerable<Standard> Standards { get; set; }

        protected bool Equals(Sector other)
        {
            return Id == other.Id && string.Equals(Name, other.Name) && ApprenticeshipOccupationId == other.ApprenticeshipOccupationId && Equals(Standards, other.Standards);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Sector)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = Id;
                hashCode = (hashCode * 397) ^ (Name != null ? Name.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ ApprenticeshipOccupationId;
                hashCode = (hashCode * 397) ^ (Standards != null ? Standards.GetHashCode() : 0);
                return hashCode;
            }
        }
    }
}