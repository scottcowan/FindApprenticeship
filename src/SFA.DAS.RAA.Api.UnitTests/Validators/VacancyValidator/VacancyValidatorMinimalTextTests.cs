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

        #region Basic vacancy details

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

        [TestCase(null, false)]
        [TestCase("", false)]
        [TestCase("www.google.com", true)]
        public void OfflineApplicationUrlRequired(string websiteUrl, bool expectValid)
        {
            var vacancy = new Vacancy
            {
                OfflineVacancy = true,
                OfflineApplicationUrl = websiteUrl
            };

            if (expectValid)
            {
                _vacancyValidator.ShouldNotHaveValidationErrorFor(v => v.OfflineApplicationUrl, vacancy);
            }
            else
            {
                _vacancyValidator.ShouldHaveValidationErrorFor(v => v.OfflineApplicationUrl, vacancy).WithErrorMessage("Please supply a valid website url for candidates to apply for this vacancy on your website");
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
        public void OfflineApplicationUrlTests(string websiteUrl, bool expectValid)
        {
            var vacancy = new Vacancy
            {
                OfflineApplicationUrl = websiteUrl
            };

            if (expectValid)
            {
                _vacancyValidator.ShouldNotHaveValidationErrorFor(v => v.OfflineApplicationUrl, vacancy);
            }
            else
            {
                _vacancyValidator.ShouldHaveValidationErrorFor(v => v.OfflineApplicationUrl, vacancy).WithErrorMessage("Please supply a valid website url for candidates to apply for this vacancy on your website");
            }
        }

        [TestCase("https://recruit.findapprenticeship.service.gov.uk/vacancy/create?vacancyOwnerRelationshipId=-29&vacancyGuid=1ae20e2a-5710-43c6-8208-3e0b25e7c80b&numberOfPositions=2&comeFromPreview=False&VacancyType=Apprenticeship&FilterType=Live&SearchMode=All&Order=Ascen", true)]
        [TestCase("https://recruit.findapprenticeship.service.gov.uk/vacancy/create?vacancyOwnerRelationshipId=-29&vacancyGuid=1ae20e2a-5710-43c6-8208-3e0b25e7c80b&numberOfPositions=2&comeFromPreview=False&VacancyType=Apprenticeship&FilterType=Live&SearchMode=All&Order=Ascend", false)]
        public void OfflineApplicationUrlLengthTests(string websiteUrl, bool expectValid)
        {
            var vacancy = new Vacancy
            {
                OfflineApplicationUrl = websiteUrl
            };

            if (expectValid)
            {
                _vacancyValidator.ShouldNotHaveValidationErrorFor(v => v.OfflineApplicationUrl, vacancy);
            }
            else
            {
                _vacancyValidator.ShouldHaveValidationErrorFor(v => v.OfflineApplicationUrl, vacancy).WithErrorMessage("The website address must not be more than 256 characters");
            }
        }

        [TestCase(null, true)]
        [TestCase("", true)]
        [TestCase(" ", true)]
        [TestCase("<p>Invalid characters</p>", false)]
        public void TitleTest(string offlineApplicationInstructions, bool expectValid)
        {
            var vacancy = new Vacancy
            {
                OfflineApplicationInstructions = offlineApplicationInstructions
            };

            if (expectValid)
            {
                _vacancyValidator.ShouldNotHaveValidationErrorFor(v => v.OfflineApplicationInstructions, vacancy);
            }
            else
            {
                _vacancyValidator.ShouldHaveValidationErrorFor(v => v.OfflineApplicationInstructions, vacancy).WithErrorMessage("The instructions for candidates to apply for this vacancy on your website contains some invalid characters");
            }
        }

        #endregion

        #region Training details

        [TestCase(null, true, null)]
        [TestCase("", true, null)]
        [TestCase(" ", true, null)]
        [TestCase("Ascii Start of character", false, "Training to be provided contains some invalid characters")]
        [TestCase("Desired Skill", true, null)]
        [TestCase(Samples.ValidFreeHtmlText, true, null)]
        [TestCase(Samples.InvalidHtmlTextWithInput, false, "Training to be provided contains some invalid tags")]
        [TestCase(Samples.InvalidHtmlTextWithObject, false, "Training to be provided contains some invalid tags")]
        [TestCase(Samples.InvalidHtmlTextWithScript, false, "Training to be provided contains some invalid tags")]
        public void TrainingProvidedTest(string trainingProvided, bool expectValid, string expectedErrorMessage)
        {
            var vacancy = new Vacancy
            {
                TrainingProvided = trainingProvided
            };

            if (expectValid)
            {
                _vacancyValidator.ShouldNotHaveValidationErrorFor(v => v.TrainingProvided, vacancy);
            }
            else
            {
                _vacancyValidator.ShouldHaveValidationErrorFor(v => v.TrainingProvided, vacancy).WithErrorMessage(expectedErrorMessage);
            }
        }

        #endregion
    }
}