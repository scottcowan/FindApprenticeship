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
        }
    }
}