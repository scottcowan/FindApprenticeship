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
        [TestCase("Training Provided", true, null)]
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

        [TestCase(null, true, null)]
        [TestCase("", true, null)]
        [TestCase(" ", true, null)]
        [TestCase("One hundred character string One hundred character string One hundred character string One hundred c", true, null)]
        [TestCase("String over one hundred characters String over one hundred characters String over one hundred charact", false, "Contact name must not be more than 100 characters")]
        [TestCase("<p>Invalid characters</p>", false, "Contact name contains some invalid characters")]
        public void ContactNameTest(string contactName, bool expectValid, string expectedErrorMessage)
        {
            var vacancy = new Vacancy
            {
                ContactName = contactName
            };

            if (expectValid)
            {
                _vacancyValidator.ShouldNotHaveValidationErrorFor(v => v.ContactName, vacancy);
            }
            else
            {
                _vacancyValidator.ShouldHaveValidationErrorFor(v => v.ContactName, vacancy).WithErrorMessage(expectedErrorMessage);
            }
        }

        [TestCase(null, true, null)]
        [TestCase("", true, null)]
        [TestCase(" ", false, "Contact number must only contain digits, and at most 16 digits")]
        [TestCase("www.google.com", false, "Contact number must only contain digits, and at most 16 digits")]
        [TestCase("0123456789", true, null)]
        [TestCase("+447894223", true, null)]
        [TestCase("+44(0)7894223", true, null)]
        [TestCase("01234567890123456", false, "Contact number must be between 8 and 16 digits or not specified")]
        public void ContactNumberTests(string contactNumber, bool expectValid, string expectedErrorMessage)
        {
            var vacancy = new Vacancy
            {
                ContactNumber = contactNumber
            };

            if (expectValid)
            {
                _vacancyValidator.ShouldNotHaveValidationErrorFor(v => v.ContactNumber, vacancy);
            }
            else
            {
                _vacancyValidator.ShouldHaveValidationErrorFor(v => v.ContactNumber, vacancy).WithErrorMessage(expectedErrorMessage);
            }
        }

        [TestCase(null, true, null)]
        [TestCase("", true, null)]
        [TestCase(" ", false, "Contact email address must be a valid email address")]
        [TestCase("www.google.com", false, "Contact email address must be a valid email address")]
        [TestCase("test@test.com", true, null)]
        [TestCase("test@test.co.uk", true, null)]
        [TestCase("emailaddressover100charactersemailaddressover100charactersemailaddr@emailaddressover100characters.com", false, "Contact email address must not be more than 100 characters")]
        public void ContactEmailTests(string contactEmail, bool expectValid, string expectedErrorMessage)
        {
            var vacancy = new Vacancy
            {
                ContactEmail = contactEmail
            };

            if (expectValid)
            {
                _vacancyValidator.ShouldNotHaveValidationErrorFor(v => v.ContactEmail, vacancy);
            }
            else
            {
                _vacancyValidator.ShouldHaveValidationErrorFor(v => v.ContactEmail, vacancy).WithErrorMessage(expectedErrorMessage);
            }
        }

        #endregion

        #region Further vacancy details

        [TestCase(null, true, null)]
        [TestCase("", true, null)]
        [TestCase(" ", true, null)]
        [TestCase("250 character string 250 character string 250 character string 250 character string 250 character string 250 character string 250 character string 250 character string 250 character string 250 character string 250 character string 250 character strin", true, null)]
        [TestCase("String over 250 characters String over 250 characters String over 250 characters String over 250 characters String over 250 characters String over 250 characters String over 250 characters String over 250 characters String over 250 characters String o", false, "The working week must not be more than 250 characters")]
        [TestCase("<p>Invalid characters</p>", false, "The working week contains some invalid characters")]
        public void WorkingWeekApprenticeshipTest(string workingWeek, bool expectValid, string expectedErrorMessage)
        {
            var vacancy = new Vacancy
            {
                WorkingWeek = workingWeek
            };

            if (expectValid)
            {
                _vacancyValidator.ShouldNotHaveValidationErrorFor(v => v.WorkingWeek, vacancy);
            }
            else
            {
                _vacancyValidator.ShouldHaveValidationErrorFor(v => v.WorkingWeek, vacancy).WithErrorMessage(expectedErrorMessage);
            }
        }

        [TestCase(null, true, null)]
        [TestCase("", true, null)]
        [TestCase(" ", true, null)]
        [TestCase("250 character string 250 character string 250 character string 250 character string 250 character string 250 character string 250 character string 250 character string 250 character string 250 character string 250 character string 250 character strin", true, null)]
        [TestCase("String over 250 characters String over 250 characters String over 250 characters String over 250 characters String over 250 characters String over 250 characters String over 250 characters String over 250 characters String over 250 characters String o", false, "The weekly hours must not be more than 250 characters")]
        [TestCase("<p>Invalid characters</p>", false, "The weekly hours contains some invalid characters")]
        public void WorkingWeekTraineeshipTest(string workingWeek, bool expectValid, string expectedErrorMessage)
        {
            var vacancy = new Vacancy
            {
                VacancyType = VacancyType.Traineeship,
                WorkingWeek = workingWeek
            };

            if (expectValid)
            {
                _vacancyValidator.ShouldNotHaveValidationErrorFor(v => v.WorkingWeek, vacancy);
            }
            else
            {
                _vacancyValidator.ShouldHaveValidationErrorFor(v => v.WorkingWeek, vacancy).WithErrorMessage(expectedErrorMessage);
            }
        }

        [TestCase(null, true, null)]
        [TestCase("", true, null)]
        [TestCase(" ", true, null)]
        [TestCase("Ascii Start of character", false, "The long description contains some invalid characters")]
        [TestCase("Long Description", true, null)]
        [TestCase(Samples.ValidFreeHtmlText, true, null)]
        [TestCase(Samples.InvalidHtmlTextWithInput, false, "The long description contains some invalid tags")]
        [TestCase(Samples.InvalidHtmlTextWithObject, false, "The long description contains some invalid tags")]
        [TestCase(Samples.InvalidHtmlTextWithScript, false, "The long description contains some invalid tags")]
        public void LongDescriptionTest(string desiredSkills, bool expectValid, string expectedErrorMessage)
        {
            var vacancy = new Vacancy
            {
                LongDescription = desiredSkills
            };

            if (expectValid)
            {
                _vacancyValidator.ShouldNotHaveValidationErrorFor(v => v.LongDescription, vacancy);
            }
            else
            {
                _vacancyValidator.ShouldHaveValidationErrorFor(v => v.LongDescription, vacancy).WithErrorMessage(expectedErrorMessage);
            }
        }

        [TestCase(null, true, null)]
        [TestCase("", true, null)]
        [TestCase(" ", true, null)]
        [TestCase("Ascii Start of character", false, "The work placement description contains some invalid characters")]
        [TestCase("Long Description", true, null)]
        [TestCase(Samples.ValidFreeHtmlText, true, null)]
        [TestCase(Samples.InvalidHtmlTextWithInput, false, "The work placement description contains some invalid tags")]
        [TestCase(Samples.InvalidHtmlTextWithObject, false, "The work placement description contains some invalid tags")]
        [TestCase(Samples.InvalidHtmlTextWithScript, false, "The work placement description contains some invalid tags")]
        public void LongDescriptionTraineeshipTest(string longDescription, bool expectValid, string expectedErrorMessage)
        {
            var vacancy = new Vacancy
            {
                VacancyType = VacancyType.Traineeship,
                LongDescription = longDescription
            };

            if (expectValid)
            {
                _vacancyValidator.ShouldNotHaveValidationErrorFor(v => v.LongDescription, vacancy);
            }
            else
            {
                _vacancyValidator.ShouldHaveValidationErrorFor(v => v.LongDescription, vacancy).WithErrorMessage(expectedErrorMessage);
            }
        }

        #endregion

        #region Requirements and prospects

        [TestCase(null, true, null)]
        [TestCase("", true, null)]
        [TestCase(" ", true, null)]
        [TestCase("Ascii Start of character", false, "The long description contains some invalid characters")]
        [TestCase("Long Description", true, null)]
        [TestCase(Samples.ValidFreeHtmlText, true, null)]
        [TestCase(Samples.InvalidHtmlTextWithInput, false, "The long description contains some invalid tags")]
        [TestCase(Samples.InvalidHtmlTextWithObject, false, "The long description contains some invalid tags")]
        [TestCase(Samples.InvalidHtmlTextWithScript, false, "The long description contains some invalid tags")]
        public void DesiredSkillsTest(string desiredSkills, bool expectValid, string expectedErrorMessage)
        {
            var vacancy = new Vacancy
            {
                DesiredSkills = desiredSkills
            };

            if (expectValid)
            {
                _vacancyValidator.ShouldNotHaveValidationErrorFor(v => v.DesiredSkills, vacancy);
            }
            else
            {
                _vacancyValidator.ShouldHaveValidationErrorFor(v => v.DesiredSkills, vacancy).WithErrorMessage(expectedErrorMessage);
            }
        }

        #endregion
    }
}