namespace SFA.Apprenticeships.Application.Interfaces.Locations
{
    using Domain.Entities.Raa.Locations;

    public interface IPostalAddressService
    {
        PostalAddress GetPostalAddress(string companyName, string primaryAddressableObject, string secondaryAddressableObject, string street, string town, string postcode);

        PostalAddress GetPostalAddress(PostalAddress postalAddress);
    }
}