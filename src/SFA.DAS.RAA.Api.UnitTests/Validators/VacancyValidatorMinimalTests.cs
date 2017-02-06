namespace SFA.DAS.RAA.Api.UnitTests.Validators
{
    using Api.Validators;
    using Apprenticeships.Domain.Entities.Raa.Vacancies;
    using FluentValidation.TestHelper;
    using NUnit.Framework;

    [TestFixture]
    [Parallelizable]
    public class VacancyValidatorMinimalTests
    {
        private readonly VacancyValidator _vacancyValidator = new VacancyValidator();

        [TestCase(0, false)]
        [TestCase(1, true)]
        public void VacancyOwnerRelationshipIdRequired(int vacancyOwnerRelationshipId, bool expectValid)
        {
            var vacancy = new Vacancy
            {
                Status = VacancyStatus.Draft,
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
    }
}