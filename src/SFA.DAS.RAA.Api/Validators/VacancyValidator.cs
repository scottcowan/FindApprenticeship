namespace SFA.DAS.RAA.Api.Validators
{
    using Apprenticeships.Domain.Entities.Raa.Vacancies;
    using Apprenticeships.Web.Common.Validators;
    using FluentValidation;
    using VacancyMessages = Apprenticeships.Domain.Entities.Raa.Vacancies.Constants.VacancyMessages;

    public class VacancyValidator : AbstractValidator<Vacancy>
    {
        public VacancyValidator()
        {
            #region Choose employer

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

            RuleFor(x => x.EmployerWebsiteUrl)
                .Must(Common.IsValidUrl)
                .WithMessage(VacancyMessages.EmployerWebsiteUrl.InvalidUrlText)
                .When(x => !string.IsNullOrEmpty(x.EmployerWebsiteUrl));

            RuleFor(x => x.EmployerDescription)
                .Matches(VacancyMessages.EmployerDescription.WhiteListHtmlRegularExpression)
                .WithMessage(VacancyMessages.EmployerDescription.WhiteListInvalidCharacterErrorText)
                .Must(Common.BeAValidFreeText)
                .WithMessage(VacancyMessages.EmployerDescription.WhiteListInvalidTagErrorText);

            RuleFor(x => x.EmployerAnonymousName)
                 .NotEmpty()
                 .WithMessage(VacancyMessages.EmployerAnonymousName.RequiredErrorText)
                 .Matches(VacancyMessages.EmployerAnonymousName.WhiteListHtmlRegularExpression)
                 .WithMessage(VacancyMessages.EmployerAnonymousName.WhiteListInvalidCharacterErrorText)
                 .Must(Common.BeAValidFreeText)
                 .WithMessage(VacancyMessages.EmployerAnonymousName.WhiteListInvalidTagErrorText)
                 .When(IsAnonymousEmployer);

            RuleFor(x => x.EmployerAnonymousReason)
                .NotEmpty()
                .WithMessage(VacancyMessages.EmployerAnonymousReason.RequiredErrorText)
                .Matches(VacancyMessages.EmployerAnonymousReason.WhiteListHtmlRegularExpression)
                .WithMessage(VacancyMessages.EmployerAnonymousReason.WhiteListInvalidCharacterErrorText)
                .Must(Common.BeAValidFreeText)
                .WithMessage(VacancyMessages.EmployerAnonymousReason.WhiteListInvalidTagErrorText)
                .When(IsAnonymousEmployer);

            RuleFor(x => x.AnonymousAboutTheEmployer)
                .NotEmpty()
                .WithMessage(VacancyMessages.AnonymousAboutTheEmployer.RequiredErrorText)
                .Matches(VacancyMessages.AnonymousAboutTheEmployer.WhiteListHtmlRegularExpression)
                .WithMessage(VacancyMessages.AnonymousAboutTheEmployer.WhiteListInvalidCharacterErrorText)
                .Must(Common.BeAValidFreeText)
                .WithMessage(VacancyMessages.AnonymousAboutTheEmployer.WhiteListInvalidTagErrorText)
                .When(IsAnonymousEmployer);

            RuleFor(x => x.VacancyLocations)
                .NotEmpty()
                .WithMessage(VacancyMessages.VacancyLocations.RequiredErrorText)
                .When(x => x.VacancyLocationType == VacancyLocationType.MultipleLocations && x.VacancySource != VacancySource.Raa);

            RuleFor(x => x.VacancyLocations)
                .SetCollectionValidator(new VacancyLocationValidator());

            #endregion

            #region Basic vacancy details

            RuleFor(m => m.Title)
                .Length(0, 100)
                .WithMessage(VacancyMessages.Title.TooLongErrorText)
                .Matches(VacancyMessages.Title.WhiteListRegularExpression)
                .WithMessage(VacancyMessages.Title.WhiteListErrorText)
                .When(v => !string.IsNullOrEmpty(v.Title));

            RuleFor(x => x.ShortDescription)
                .Length(0, 350)
                .WithMessage(VacancyMessages.ShortDescription.TooLongErrorText)
                .Matches(VacancyMessages.ShortDescription.WhiteListRegularExpression)
                .WithMessage(VacancyMessages.ShortDescription.WhiteListErrorText)
                .When(v => !string.IsNullOrEmpty(v.ShortDescription));

            RuleFor(x => x.OfflineApplicationUrl)
                .Length(0, 256)
                .WithMessage(VacancyMessages.OfflineApplicationUrl.TooLongErrorText)
                .Must(Common.IsValidUrl)
                .WithMessage(VacancyMessages.OfflineApplicationUrl.InvalidUrlText)
                .When(x => !string.IsNullOrEmpty(x.OfflineApplicationUrl));

            #endregion
        }

        private static bool IsAnonymousEmployer(Vacancy vacancy)
        {
            return vacancy.IsAnonymousEmployer.HasValue && vacancy.IsAnonymousEmployer.Value;
        }
    }
}