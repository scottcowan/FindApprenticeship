namespace SFA.Apprenticeships.Domain.Entities.Raa.Locations
{
    using System;
    using System.ComponentModel.DataAnnotations;

    //TODO: Remove the existing Address entity, in favor of using this one.  This should be carried out after the DB migration

    /// <summary>
    /// SFA Approved standard postal address entity
    /// </summary>
    public class PostalAddress
    {
        /// <summary>
        /// The primary id of this address if specified by the validating entity
        /// </summary>
        public int PostalAddressId { get; set; }

        #region SFA Data Standard compliance minimum field set
        /// <summary>
        /// The first line of the address. Usually house number or name
        /// </summary>
        [Required]
        public string AddressLine1 { get; set; }
        /// <summary>
        /// The second line of the address. Usually street name
        /// </summary>
        public string AddressLine2 { get; set; }
        /// <summary>
        /// The third line of the address
        /// </summary>
        public string AddressLine3 { get; set; }
        /// <summary>
        /// The fourth line of the address
        /// </summary>
        public string AddressLine4 { get; set; }
        /// <summary>
        /// The fifth line of the address
        /// </summary>
        public string AddressLine5 { get; set; }
        /// <summary>
        /// The town or city the address belongs to
        /// </summary>
        [Required]
        public string Town { get; set; }
        /// <summary>
        /// The postcode
        /// </summary>
        [Required]
        public string Postcode { get; set; }
        /// <summary>
        /// AKA ValidationSourceKeyName.
        /// As at 13/01/2015, the SFA Data Standard for Postal Addresses list valid validating bodies as:
        /// 1. Royal Mail PAF file
        /// 2. GeoPlace data
        /// 3. PCA product (uses a PAF file source)
        /// </summary>
        public string ValidationSourceCode { get; set; }
        /// <summary>
        /// For PAF, this is the Unique Delivery Point Reference Number (UDPRN)
        /// For GeoPlace, this is the Unique Property ReferenceNumber (UPRN)
        /// PostCode anywhere uses PAF data, so this is the UDPRN.
        /// </summary>
        public string ValidationSourceKeyValue { get; set; }
#endregion

        /// <summary>
        /// The date the address was validated
        /// </summary>
        public DateTime DateValidated { get; set; }
        /// <summary>
        /// The primary identifier for the county of the address
        /// </summary>
        public int CountyId { get; set; }
        /// <summary>
        /// The name of the county
        /// </summary>
        public string County { get; set; }
        /// <summary>
        /// The primary identifier for the local authority the address is part of
        /// </summary>
        public int LocalAuthorityId { get; set; }
        /// <summary>
        /// The secondary code identifier for the local authority the address is part of
        /// </summary>
        public string LocalAuthorityCodeName { get; set; }
        /// <summary>
        /// The local authority's name
        /// </summary>
        public string LocalAuthority { get; set; }
        /// <summary>
        /// The global geopoint for the address
        /// </summary>
        public GeoPoint GeoPoint { get; set; }

        public override string ToString()
        {
            return AddressLine4 ?? AddressLine3 ?? AddressLine2 ?? AddressLine1 ?? Postcode;
        }

        public PostalAddress Clone()
        {
            return new PostalAddress
            {
                PostalAddressId = PostalAddressId,
                AddressLine1 = AddressLine1,
                AddressLine2 = AddressLine2,
                AddressLine3 = AddressLine3,
                AddressLine4 = AddressLine4,
                AddressLine5 = AddressLine5,
                Town = Town,
                Postcode = Postcode,
                ValidationSourceCode = ValidationSourceCode,
                ValidationSourceKeyValue = ValidationSourceKeyValue,
                DateValidated = DateValidated,
                CountyId = CountyId,
                County = County,
                LocalAuthorityId = LocalAuthorityId,
                LocalAuthorityCodeName = LocalAuthorityCodeName,
                LocalAuthority = LocalAuthority,
                GeoPoint = GeoPoint?.Clone()
            };
        }

        protected bool Equals(PostalAddress other)
        {
            return string.Equals(AddressLine1, other.AddressLine1) && string.Equals(AddressLine2, other.AddressLine2) && string.Equals(AddressLine3, other.AddressLine3) && string.Equals(AddressLine4, other.AddressLine4) && string.Equals(AddressLine5, other.AddressLine5) && string.Equals(County, other.County) && CountyId == other.CountyId && DateValidated.Equals(other.DateValidated) && Equals(GeoPoint, other.GeoPoint) && string.Equals(LocalAuthority, other.LocalAuthority) && string.Equals(LocalAuthorityCodeName, other.LocalAuthorityCodeName) && LocalAuthorityId == other.LocalAuthorityId && PostalAddressId == other.PostalAddressId && string.Equals(Postcode, other.Postcode) && string.Equals(Town, other.Town) && string.Equals(ValidationSourceCode, other.ValidationSourceCode) && string.Equals(ValidationSourceKeyValue, other.ValidationSourceKeyValue);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((PostalAddress) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (AddressLine1 != null ? AddressLine1.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (AddressLine2 != null ? AddressLine2.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (AddressLine3 != null ? AddressLine3.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (AddressLine4 != null ? AddressLine4.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (AddressLine5 != null ? AddressLine5.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (County != null ? County.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ CountyId;
                hashCode = (hashCode*397) ^ DateValidated.GetHashCode();
                hashCode = (hashCode*397) ^ (GeoPoint != null ? GeoPoint.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (LocalAuthority != null ? LocalAuthority.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (LocalAuthorityCodeName != null ? LocalAuthorityCodeName.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ LocalAuthorityId;
                hashCode = (hashCode*397) ^ PostalAddressId;
                hashCode = (hashCode*397) ^ (Postcode != null ? Postcode.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (Town != null ? Town.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (ValidationSourceCode != null ? ValidationSourceCode.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (ValidationSourceKeyValue != null ? ValidationSourceKeyValue.GetHashCode() : 0);
                return hashCode;
            }
        }
    }
}
