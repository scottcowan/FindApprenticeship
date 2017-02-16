namespace SFA.DAS.RAA.Api.UnitTests.Validators.VacancyValidator
{
    using Api.Validators;
    using Apprenticeships.Domain.Entities.Raa.Vacancies;
    using FluentValidation.TestHelper;
    using NUnit.Framework;

    [TestFixture]
    [Parallelizable]
    public class VacancyValidatorMinimalTextTests
    {
        private readonly VacancyValidator _vacancyValidator = new VacancyValidator();

        [TestCase(null, true, null)]
        [TestCase("", true, null)]
        [TestCase(" ", true, null)]
        [TestCase("100 character Title 100 character Title 100 character Title 100 character Title 100 character Title ", true, null)]
        [TestCase("Title over 100 characters Title over 100 characters Title over 100 characters Title over 100 characte", false, "The title must not be more than 100 characters")]
        [TestCase("<p>Invalid characters</p>", false, "The title contains some invalid characters")]
        public void TitleTest(string title, bool expectValid, string expectedErrorMessage)
        {
            var vacancy = new Vacancy
            {
                Title = title
            };

            if (expectValid)
            {
                _vacancyValidator.ShouldNotHaveValidationErrorFor(v => v.Title, vacancy);
            }
            else
            {
                _vacancyValidator.ShouldHaveValidationErrorFor(v => v.Title, vacancy).WithErrorMessage(expectedErrorMessage);
            }
        }

        [TestCase(null, true, null)]
        [TestCase("", true, null)]
        [TestCase(" ", true, null)]
        [TestCase("350 character short description 350 character short description 350 character short description 350 character short description 350 character short description 350 character short description 350 character short description 350 character short description 350 character short description 350 character short description 350 character short descriptio", true, null)]
        [TestCase("Short description over 350 characters Short description over 350 characters Short description over 350 characters Short description over 350 characters Short description over 350 characters Short description over 350 characters Short description over 350 characters Short description over 350 characters Short description over 350 characters Short des", false, "The short description must not be more than 350 characters")]
        [TestCase("<p>Invalid characters</p>", false, "The short description contains some invalid characters")]
        public void ShortDescriptionTest(string shortDescription, bool expectValid, string expectedErrorMessage)
        {
            var vacancy = new Vacancy
            {
                ShortDescription = shortDescription
            };

            if (expectValid)
            {
                _vacancyValidator.ShouldNotHaveValidationErrorFor(v => v.ShortDescription, vacancy);
            }
            else
            {
                _vacancyValidator.ShouldHaveValidationErrorFor(v => v.ShortDescription, vacancy).WithErrorMessage(expectedErrorMessage);
            }
        }
    }
}