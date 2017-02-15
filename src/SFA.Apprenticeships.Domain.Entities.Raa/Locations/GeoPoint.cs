namespace SFA.Apprenticeships.Domain.Entities.Raa.Locations
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// A global geographic coordinate
    /// </summary>
    public class GeoPoint
    {
        /// <summary>
        /// Longitude component of a lat/long pair
        /// </summary>
        [Required]
        public double Longitude { get; set; }
        /// <summary>
        /// Latitude component of a lat/long pair
        /// </summary>
        [Required]
        public double Latitude { get; set; }
        /// <summary>
        /// Easting component of a northing/easting pair
        /// </summary>
        [Required]
        public int Easting { get; set; }
        /// <summary>
        /// Northing component of a northing/easting pair
        /// </summary>
        [Required]
        public int Northing { get; set; }

        /// <summary>
        /// Represents an undefined geopoint
        /// </summary>
        public static GeoPoint NotSet => new GeoPoint
        {
            Latitude = double.NaN,
            Longitude = double.NaN,
            Easting = int.MinValue,
            Northing = int.MinValue
        };

        public override string ToString()
        {
            return $"Latitude:{Latitude}, Longitude:{Longitude}, Easting: {Easting}, Northing:{Northing}";
        }

        public bool IsSet()
        {
            return !Equals(NotSet);
        }

        public GeoPoint Clone()
        {
            return new GeoPoint
            {
                Latitude = Latitude,
                Longitude = Longitude,
                Easting = Easting,
                Northing = Northing
            };
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((GeoPoint) obj);
        }

        protected bool Equals(GeoPoint other)
        {
            return Longitude.Equals(other.Longitude) && Latitude.Equals(other.Latitude) && 
                Easting == other.Easting && Northing == other.Northing;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = Longitude.GetHashCode();
                hashCode = (hashCode*397) ^ Latitude.GetHashCode();
                hashCode = (hashCode*397) ^ Easting;
                hashCode = (hashCode*397) ^ Northing;
                return hashCode;
            }
        }
    }
}
