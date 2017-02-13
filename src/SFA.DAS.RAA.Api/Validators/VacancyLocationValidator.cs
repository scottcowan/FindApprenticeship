namespace SFA.DAS.RAA.Api.Validators
{
    using Apprenticeships.Domain.Entities.Raa.Vacancies;
    using Apprenticeships.Domain.Entities.Raa.Vacancies.Constants;
    using Apprenticeships.Web.Common.Validators;
    using FluentValidation;

    public class VacancyLocationValidator : AbstractValidator<VacancyLocation>
    {
        public VacancyLocationValidator()
        {
            RuleFor(v => v.Address)
                .NotNull()
                .WithMessage(VacancyLocationMessages.Address.RequiredErrorText);

            RuleFor(x => x.NumberOfPositions)
                .GreaterThanOrEqualTo(1)
                .WithMessage(VacancyLocationMessages.NumberOfPositions.LengthErrorText);

            RuleFor(x => x.EmployersWebsite)
                .Must(Common.IsValidUrl)
                .WithMessage(VacancyLocationMessages.EmployersWebsite.InvalidUrlText)
                .When(x => !string.IsNullOrEmpty(x.EmployersWebsite));

            RuleFor(x => x.Address).SetValidator(new PostalAddressValidator());
        }
    }
}