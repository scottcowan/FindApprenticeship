namespace SFA.DAS.RAA.Api.UnitTests.Validators
{
    using Api.Validators;
    using Apprenticeships.Domain.Entities.Raa.Locations;
    using FluentValidation.TestHelper;
    using NUnit.Framework;

    [TestFixture]
    [Parallelizable]
    public class PostalAddressValidatorTests
    {
        private readonly PostalAddressValidator _postalAddressValidator = new PostalAddressValidator();

        [Test]
        public void AddressLine1Required()
        {
            var postalAddress = new PostalAddress
            {
                AddressLine1 = "Address Line 1"
            };

            _postalAddressValidator.ShouldNotHaveValidationErrorFor(pa => pa.AddressLine1, postalAddress);

            postalAddress.AddressLine1 = null;

            _postalAddressValidator.ShouldHaveValidationErrorFor(pa => pa.AddressLine1, postalAddress).WithErrorMessage("Please supply the first line of the address.");
        }

        [Test]
        public void TownRequired()
        {
            var postalAddress = new PostalAddress
            {
                Town = "Town"
            };

            _postalAddressValidator.ShouldNotHaveValidationErrorFor(pa => pa.Town, postalAddress);

            postalAddress.Town = null;

            _postalAddressValidator.ShouldHaveValidationErrorFor(pa => pa.Town, postalAddress).WithErrorMessage("Please supply a value for the town property of the address.");
        }

        [Test]
        public void PostcodeRequired()
        {
            var postalAddress = new PostalAddress
            {
                Postcode = "CV1 2WT"
            };

            _postalAddressValidator.ShouldNotHaveValidationErrorFor(pa => pa.Postcode, postalAddress);

            postalAddress.Postcode = null;

            _postalAddressValidator.ShouldHaveValidationErrorFor(pa => pa.Postcode, postalAddress).WithErrorMessage("Please supply a value for the postcode property of the address.");
        }
    }
}