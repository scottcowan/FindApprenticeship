namespace SFA.DAS.RAA.Api.UnitTests.Validators
{
    using System;
    using Api.Validators;
    using Apprenticeships.Domain.Entities.Raa.Vacancies;
    using FluentValidation.TestHelper;
    using NUnit.Framework;

    [TestFixture]
    [Parallelizable]
    public class VacancyValidatorMinimalTests
    {
        private readonly VacancyValidator _vacancyValidator = new VacancyValidator();

        [Test]
        public void VacancyGuidRequired()
        {
            var vacancy = new Vacancy
            {
                VacancyGuid = Guid.Empty
            };

            _vacancyValidator.ShouldHaveValidationErrorFor(v => v.VacancyGuid, vacancy).WithErrorMessage("Please supply a valid vacancy guid. The guid must not have been used to create a vacancy before.");

            vacancy.VacancyGuid = Guid.NewGuid();

            _vacancyValidator.ShouldNotHaveValidationErrorFor(v => v.VacancyGuid, vacancy);
        }

        [TestCase(0, false)]
        [TestCase(1, true)]
        public void VacancyOwnerRelationshipIdRequired(int vacancyOwnerRelationshipId, bool expectValid)
        {
            var vacancy = new Vacancy
            {
                VacancyOwnerRelationshipId = vacancyOwnerRelationshipId
            };

            if (expectValid)
            {
                _vacancyValidator.ShouldNotHaveValidationErrorFor(v => v.VacancyOwnerRelationshipId, vacancy);
            }
            else
            {
                _vacancyValidator.ShouldHaveValidationErrorFor(v => v.VacancyOwnerRelationshipId, vacancy).WithErrorMessage("Please supply a valid vacancy owner relationship id. This must exist and be associated with a provider site your API key has access to.");
            }
        }

        [TestCase(VacancyLocationType.Unknown, false)]
        [TestCase(VacancyLocationType.SpecificLocation, true)]
        [TestCase(VacancyLocationType.MultipleLocations, true)]
        [TestCase(VacancyLocationType.Nationwide, true)]
        [TestCase(999, false)]
        public void VacancyLocationTypeRequired(VacancyLocationType vacancyLocationType, bool expectValid)
        {
            var vacancy = new Vacancy
            {
                VacancyLocationType = vacancyLocationType
            };

            if (expectValid)
            {
                _vacancyValidator.ShouldNotHaveValidationErrorFor(v => v.VacancyLocationType, vacancy);
            }
            else
            {
                _vacancyValidator.ShouldHaveValidationErrorFor(v => v.VacancyLocationType, vacancy).WithErrorMessage("Please supply a vacancy location type value.");
            }
        }


        [TestCase(VacancyLocationType.SpecificLocation, null, false)]
        [TestCase(VacancyLocationType.SpecificLocation, -1, false)]
        [TestCase(VacancyLocationType.SpecificLocation, 0, false)]
        [TestCase(VacancyLocationType.SpecificLocation, 1, true)]
        [TestCase(VacancyLocationType.MultipleLocations, null, true)]
        [TestCase(VacancyLocationType.MultipleLocations, 0, true)]
        [TestCase(VacancyLocationType.Nationwide, null, true)]
        [TestCase(VacancyLocationType.Nationwide, 0, true)]
        public void NumberOfPositionsRequired(VacancyLocationType vacancyLocationType, int? numberOfPositions, bool expectValid)
        {
            var vacancy = new Vacancy
            {
                VacancyLocationType = vacancyLocationType,
                NumberOfPositions = numberOfPositions
            };

            if (expectValid)
            {
                _vacancyValidator.ShouldNotHaveValidationErrorFor(v => v.NumberOfPositions, vacancy);
            }
            else
            {
                if (numberOfPositions == null)
                {
                    _vacancyValidator.ShouldHaveValidationErrorFor(v => v.NumberOfPositions, vacancy).WithErrorMessage("Please supply the number of positions for this vacancy");
                }
                else
                {
                    _vacancyValidator.ShouldHaveValidationErrorFor(v => v.NumberOfPositions, vacancy).WithErrorMessage("There must be at least 1 position for this vacancy");
                }
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
            var vacancy = new Vacancy
            {
                EmployerWebsiteUrl = websiteUrl
            };

            if (expectValid)
            {
                _vacancyValidator.ShouldNotHaveValidationErrorFor(v => v.EmployerWebsiteUrl, vacancy);
            }
            else
            {
                _vacancyValidator.ShouldHaveValidationErrorFor(v => v.EmployerWebsiteUrl, vacancy).WithErrorMessage("Please supply a valid website url for the employer. If you do not supply a url the value from the associated vacancy owner relationship will be used.");
            }
        }

        [Test]
        public void EmployerDescriptionIsNotRequired()
        {
            var vacancy = new Vacancy
            {
                EmployerDescription = null
            };

            _vacancyValidator.ShouldNotHaveValidationErrorFor(v => v.EmployerDescription, vacancy);
        }

        [TestCase("Employer description", true, null)]
        [TestCase("<p>Employer description</p>", true, null)]
        [TestCase("|Employer description|", false, "The description for the employer contains some invalid characters. If you do not supply a description the value from the associated vacancy owner relationship will be used.")]
        [TestCase("<script>Employer description</script>", false, "The description for the employer contains some invalid tags. If you do not supply a description the value from the associated vacancy owner relationship will be used.")]
        [TestCase("<input>Employer description</input>", false, "The description for the employer contains some invalid tags. If you do not supply a description the value from the associated vacancy owner relationship will be used.")]
        [TestCase("<object>Employer description</object>", false, "The description for the employer contains some invalid tags. If you do not supply a description the value from the associated vacancy owner relationship will be used.")]
        public void EmployerDescriptionInputValidation(string employerDescription, bool expectValid, string expectedErrorMessage)
        {
            var vacancy = new Vacancy
            {
                EmployerDescription = employerDescription
            };

            if (expectValid)
            {
                _vacancyValidator.ShouldNotHaveValidationErrorFor(v => v.EmployerDescription, vacancy);
            }
            else
            {
                _vacancyValidator.ShouldHaveValidationErrorFor(v => v.EmployerDescription, vacancy).WithErrorMessage(expectedErrorMessage);
            }
        }

        [TestCase(null, null, true)]
        [TestCase(false, null, true)]
        [TestCase(true, null, false)]
        [TestCase(null, "", true)]
        [TestCase(false, "", true)]
        [TestCase(true, "", false)]
        [TestCase(null, " ", true)]
        [TestCase(false, " ", true)]
        [TestCase(true, " ", false)]
        public void EmployerAnonymousNameRequired(bool? isAnonymousEmployer, string anonymousAboutTheEmployer, bool expectValid)
        {
            var vacancy = new Vacancy
            {
                IsAnonymousEmployer = isAnonymousEmployer,
                EmployerAnonymousName = anonymousAboutTheEmployer
            };

            if (expectValid)
            {
                _vacancyValidator.ShouldNotHaveValidationErrorFor(v => v.EmployerAnonymousName, vacancy);
            }
            else
            {
                _vacancyValidator.ShouldHaveValidationErrorFor(v => v.EmployerAnonymousName, vacancy).WithErrorMessage("Please supply an anonymous name for the employer as you have specified that the employer for this vacancy should be anonymous (IsAnonymousEmployer = true)");
            }
        }

        [TestCase("Employer anonymous name", true, null)]
        [TestCase("<p>Employer anonymous name</p>", true, null)]
        [TestCase("|Employer anonymous name|", false, "The anonymous name for the employer contains some invalid characters")]
        [TestCase("<script>Employer anonymous name</script>", false, "The anonymous name for the employer contains some invalid tags")]
        [TestCase("<input>Employer anonymous name</input>", false, "The anonymous name for the employer contains some invalid tags")]
        [TestCase("<object>Employer anonymous name</object>", false, "The anonymous name for the employer contains some invalid tags")]
        public void EmployerAnonymousNameInputValidation(string anonymousAboutTheEmployer, bool expectValid, string expectedErrorMessage)
        {
            var vacancy = new Vacancy
            {
                IsAnonymousEmployer = true,
                EmployerAnonymousName = anonymousAboutTheEmployer
            };

            if (expectValid)
            {
                _vacancyValidator.ShouldNotHaveValidationErrorFor(v => v.EmployerAnonymousName, vacancy);
            }
            else
            {
                _vacancyValidator.ShouldHaveValidationErrorFor(v => v.EmployerAnonymousName, vacancy).WithErrorMessage(expectedErrorMessage);
            }
        }

        [TestCase(null, null, true)]
        [TestCase(false, null, true)]
        [TestCase(true, null, false)]
        [TestCase(null, "", true)]
        [TestCase(false, "", true)]
        [TestCase(true, "", false)]
        [TestCase(null, " ", true)]
        [TestCase(false, " ", true)]
        [TestCase(true, " ", false)]
        public void EmployerAnonymousReasonRequired(bool? isAnonymousEmployer, string employerAnonymousReason, bool expectValid)
        {
            var vacancy = new Vacancy
            {
                IsAnonymousEmployer = isAnonymousEmployer,
                EmployerAnonymousReason = employerAnonymousReason
            };

            if (expectValid)
            {
                _vacancyValidator.ShouldNotHaveValidationErrorFor(v => v.EmployerAnonymousReason, vacancy);
            }
            else
            {
                _vacancyValidator.ShouldHaveValidationErrorFor(v => v.EmployerAnonymousReason, vacancy).WithErrorMessage("Please supply a reason for keeping the employer anonymous as you have specified that the employer for this vacancy should be anonymous (IsAnonymousEmployer = true)");
            }
        }

        [TestCase("Employer anonymous reason", true, null)]
        [TestCase("<p>Employer anonymous reason</p>", true, null)]
        [TestCase("|Employer anonymous reason|", false, "The reason for keeping the employer anonymous contains some invalid characters")]
        [TestCase("<script>Employer anonymous reason</script>", false, "The reason for keeping the employer anonymous contains some invalid tags")]
        [TestCase("<input>Employer anonymous reason</input>", false, "The reason for keeping the employer anonymous contains some invalid tags")]
        [TestCase("<object>Employer anonymous reason</object>", false, "The reason for keeping the employer anonymous contains some invalid tags")]
        public void EmployerAnonymousReasonInputValidation(string employerAnonymousReason, bool expectValid, string expectedErrorMessage)
        {
            var vacancy = new Vacancy
            {
                IsAnonymousEmployer = true,
                EmployerAnonymousReason = employerAnonymousReason
            };

            if (expectValid)
            {
                _vacancyValidator.ShouldNotHaveValidationErrorFor(v => v.EmployerAnonymousReason, vacancy);
            }
            else
            {
                _vacancyValidator.ShouldHaveValidationErrorFor(v => v.EmployerAnonymousReason, vacancy).WithErrorMessage(expectedErrorMessage);
            }
        }

        [TestCase(null, null, true)]
        [TestCase(false, null, true)]
        [TestCase(true, null, false)]
        [TestCase(null, "", true)]
        [TestCase(false, "", true)]
        [TestCase(true, "", false)]
        [TestCase(null, " ", true)]
        [TestCase(false, " ", true)]
        [TestCase(true, " ", false)]
        public void AnonymousAboutTheEmployerRequired(bool? isAnonymousEmployer, string anonymousAboutTheEmployer, bool expectValid)
        {
            var vacancy = new Vacancy
            {
                IsAnonymousEmployer = isAnonymousEmployer,
                AnonymousAboutTheEmployer = anonymousAboutTheEmployer
            };

            if (expectValid)
            {
                _vacancyValidator.ShouldNotHaveValidationErrorFor(v => v.AnonymousAboutTheEmployer, vacancy);
            }
            else
            {
                _vacancyValidator.ShouldHaveValidationErrorFor(v => v.AnonymousAboutTheEmployer, vacancy).WithErrorMessage("Please supply anonymous information about the employer as you have specified that the employer for this vacancy should be anonymous (IsAnonymousEmployer = true)");
            }
        }

        [TestCase("Anonymous about the employer", true, null)]
        [TestCase("<p>Anonymous about the employer</p>", true, null)]
        [TestCase("|Anonymous about the employer|", false, "The anonymous information about the employer contains some invalid characters")]
        [TestCase("<script>Anonymous about the employer</script>", false, "The anonymous information about the employer contains some invalid tags")]
        [TestCase("<input>Anonymous about the employer</input>", false, "The anonymous information about the employer contains some invalid tags")]
        [TestCase("<object>Anonymous about the employer</object>", false, "The anonymous information about the employer contains some invalid tags")]
        public void AnonymousAboutTheEmployerInputValidation(string anonymousAboutTheEmployer, bool expectValid, string expectedErrorMessage)
        {
            var vacancy = new Vacancy
            {
                IsAnonymousEmployer = true,
                AnonymousAboutTheEmployer = anonymousAboutTheEmployer
            };

            if (expectValid)
            {
                _vacancyValidator.ShouldNotHaveValidationErrorFor(v => v.AnonymousAboutTheEmployer, vacancy);
            }
            else
            {
                _vacancyValidator.ShouldHaveValidationErrorFor(v => v.AnonymousAboutTheEmployer, vacancy).WithErrorMessage(expectedErrorMessage);
            }
        }

        [Test]
        public void MultipleLocationsVacancyLocationsRequired()
        {
            var vacancy = new Vacancy
            {
                VacancyLocationType = VacancyLocationType.MultipleLocations,
                VacancyLocations = null
            };

            _vacancyValidator.ShouldHaveValidationErrorFor(v => v.VacancyLocations, vacancy).WithErrorMessage("You must supply at least one vacancy location when the vacancy location type is MultipleLocations.");
        }
    }
}