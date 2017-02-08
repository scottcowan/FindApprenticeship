namespace SFA.DAS.RAA.Api.Validators
{
    using Apprenticeships.Domain.Entities.Raa.Vacancies;
    using Apprenticeships.Domain.Entities.Raa.Vacancies.Constants;
    using FluentValidation;

    public class VacancyValidator : AbstractValidator<Vacancy>
    {
        public VacancyValidator()
        {
            RuleFor(v => v.VacancyOwnerRelationshipId)
                .NotEqual(0)
                .WithMessage(VacancyMessages.VacancyOwnerRelationshipId.RequiredErrorText);

            RuleFor(v => v.VacancyGuid)
                .NotEmpty()
                .WithMessage(VacancyMessages.VacancyGuid.RequiredErrorText);

            RuleFor(v => v.VacancyLocationType)
                .Must(vlt => vlt != VacancyLocationType.Unknown)
                .WithMessage(VacancyMessages.VacancyLocationType.RequiredErrorText)
                .IsInEnum()
                .WithMessage(VacancyMessages.VacancyLocationType.RequiredErrorText);

            RuleFor(x => x.NumberOfPositions)
                .NotEmpty()
                .WithMessage(VacancyMessages.NumberOfPositions.RequiredErrorText)
                .GreaterThanOrEqualTo(1)
                .WithMessage(VacancyMessages.NumberOfPositions.LengthErrorText)
                .When(x => x.VacancyLocationType == VacancyLocationType.SpecificLocation);
        }
    }
}