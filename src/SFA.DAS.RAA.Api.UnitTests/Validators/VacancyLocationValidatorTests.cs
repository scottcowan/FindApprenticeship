namespace SFA.DAS.RAA.Api.UnitTests.Validators
{
    using Api.Validators;
    using Apprenticeships.Domain.Entities.Raa.Locations;
    using Apprenticeships.Domain.Entities.Raa.Vacancies;
    using FluentValidation.TestHelper;
    using NUnit.Framework;

    [TestFixture]
    [Parallelizable]
    public class VacancyLocationValidatorTests
    {
        private readonly VacancyLocationValidator _vacancyLocationValidator = new VacancyLocationValidator();

        [Test]
        public void AddressRequired()
        {
            var vacancyLocation = new VacancyLocation
            {
                Address = new PostalAddress()
            };

            _vacancyLocationValidator.ShouldNotHaveValidationErrorFor(vl => vl.Address, vacancyLocation);

            vacancyLocation.Address = null;

            _vacancyLocationValidator.ShouldHaveValidationErrorFor(vl => vl.Address, vacancyLocation).WithErrorMessage("Please supply an address for this vacancy location.");
        }

        [TestCase(-1, false)]
        [TestCase(0, false)]
        [TestCase(1, true)]
        public void NumberOfPositionsRequired(int numberOfPositions, bool expectValid)
        {
            var vacancyLocation = new VacancyLocation
            {
                NumberOfPositions = numberOfPositions
            };

            if (expectValid)
            {
                _vacancyLocationValidator.ShouldNotHaveValidationErrorFor(v => v.NumberOfPositions, vacancyLocation);
            }
            else
            {
                _vacancyLocationValidator.ShouldHaveValidationErrorFor(v => v.NumberOfPositions, vacancyLocation).WithErrorMessage("There must be at least 1 position for this vacancy location.");
            }
        }

        [TestCase(null, true)]
        [TestCase("", true)]
        [TestCase("www.google.com", true)]
        [TestCase("http://www.google.com", true)]
        [TestCase("https://www.google.com", true)]
        [TestCase("www\\asdf\\com", false)]
        [TestCase("cantbemissingdot", false)]
        [TestCase("canbeanythingwithcorrect.chars", true)]
        [TestCase("cantbeincorrechars@%", false)]
        [TestCase("www.me-you.com", true)]
        public void ShouldValidateWebSiteUrl(string websiteUrl, bool expectValid)
        {
            var location = new VacancyLocation
            {
                EmployersWebsite = websiteUrl
            };

            if (expectValid)
            {
                _vacancyLocationValidator.ShouldNotHaveValidationErrorFor(v => v.EmployersWebsite, location);
            }
            else
            {
                _vacancyLocationValidator.ShouldHaveValidationErrorFor(v => v.EmployersWebsite, location).WithErrorMessage("Please supply a valid website url for the employer. This is the link that will be used to apply on the employer's website if the vacancy is set as offline.");
            }
        }
    }
}