namespace SFA.Apprenticeships.Application.Location
{
    using Domain.Entities.Raa.Locations;
    using Interfaces.Locations;
    using Strategies;

    public class PostalAddressService : IPostalAddressService
    {
        private readonly IPostalAddressStrategy _postalAddressStrategy;

        public PostalAddressService(IPostalAddressStrategy postalAddressStrategy)
        {
            _postalAddressStrategy = postalAddressStrategy;
        }

        public PostalAddress GetPostalAddress(string companyName, string primaryAddressableObject, string secondaryAddressableObject, string street, string town, string postcode)
        {
            return _postalAddressStrategy.GetPostalAddress(companyName, primaryAddressableObject, secondaryAddressableObject, street, town, postcode);
        }

        public PostalAddress GetPostalAddress(PostalAddress postalAddress)
        {
            return _postalAddressStrategy.GetPostalAddress(postalAddress);
        }
    }
}