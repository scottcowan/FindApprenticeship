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
    }
}