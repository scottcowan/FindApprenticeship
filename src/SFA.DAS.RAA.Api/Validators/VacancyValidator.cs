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

            RuleFor(viewModel => viewModel.VacancyType)
                .IsInEnum()
                .WithMessage(VacancyMessages.VacancyType.RequiredErrorText);

            RuleFor(m => m.OfflineApplicationUrl)
                .NotEmpty()
                .WithMessage(VacancyMessages.OfflineApplicationUrl.InvalidUrlText)
                .When(viewModel => viewModel.OfflineVacancy.HasValue && viewModel.OfflineVacancy.Value && viewModel.OfflineVacancyType != OfflineVacancyType.MultiUrl);

            RuleFor(x => x.OfflineApplicationUrl)
                .Length(0, 256)
                .WithMessage(VacancyMessages.OfflineApplicationUrl.TooLongErrorText)
                .Must(Common.IsValidUrl)
                .WithMessage(VacancyMessages.OfflineApplicationUrl.InvalidUrlText)
                .When(x => !string.IsNullOrEmpty(x.OfflineApplicationUrl));

            RuleFor(viewModel => viewModel.OfflineApplicationInstructions)
                .Matches(VacancyMessages.OfflineApplicationInstructions.WhiteListRegularExpression)
                .WithMessage(VacancyMessages.OfflineApplicationInstructions.WhiteListErrorText)
                .When(v => !string.IsNullOrEmpty(v.OfflineApplicationInstructions));

            #endregion

            #region Training details

            RuleFor(m => m.TrainingProvided)
                .Matches(VacancyMessages.TrainingProvided.WhiteListHtmlRegularExpression)
                .WithMessage(VacancyMessages.TrainingProvided.WhiteListInvalidCharacterErrorText)
                .Must(Common.BeAValidFreeText)
                .WithMessage(VacancyMessages.TrainingProvided.WhiteListInvalidTagErrorText)
                .When(x => !string.IsNullOrEmpty(x.TrainingProvided));

            RuleFor(m => m.ContactName)
                .Length(0, 100)
                .WithMessage(VacancyMessages.ContactName.TooLongErrorText)
                .Matches(VacancyMessages.ContactName.WhiteListRegularExpression)
                .WithMessage(VacancyMessages.ContactName.WhiteListErrorText)
                .When(x => !string.IsNullOrEmpty(x.ContactName));

            RuleFor(x => x.ContactNumber)
                .Length(8, 16)
                .WithMessage(VacancyMessages.ContactNumber.LengthErrorText)
                .Matches(VacancyMessages.ContactNumber.WhiteListRegularExpression)
                .WithMessage(VacancyMessages.ContactNumber.WhiteListErrorText)
                .When(x => !string.IsNullOrEmpty(x.ContactNumber));

            RuleFor(m => m.ContactEmail)
                .Length(0, 100)
                .WithMessage(VacancyMessages.ContactEmail.TooLongErrorText)
                .Matches(VacancyMessages.ContactEmail.WhiteListRegularExpression)
                .WithMessage(VacancyMessages.ContactEmail.WhiteListErrorText)
                .When(x => !string.IsNullOrEmpty(x.ContactEmail));

            #endregion

            #region Further vacancy details

            RuleFor(viewModel => viewModel.WorkingWeek)
                .Length(0, 250)
                .WithMessage(VacancyMessages.WorkingWeek.TooLongErrorText)
                .Matches(VacancyMessages.WorkingWeek.WhiteListRegularExpression)
                .WithMessage(VacancyMessages.WorkingWeek.WhiteListErrorText)
                .When(x => !string.IsNullOrEmpty(x.WorkingWeek) && x.VacancyType != VacancyType.Traineeship);

            RuleFor(viewModel => viewModel.WorkingWeek)
                .Length(0, 250)
                .WithMessage(VacancyMessages.WorkingWeek.TraineeshipTooLongErrorText)
                .Matches(VacancyMessages.WorkingWeek.WhiteListRegularExpression)
                .WithMessage(VacancyMessages.WorkingWeek.TraineeshipWhiteListErrorText)
                .When(x => !string.IsNullOrEmpty(x.WorkingWeek) && x.VacancyType == VacancyType.Traineeship);

            RuleFor(viewModel => viewModel.LongDescription)
                .Matches(VacancyMessages.LongDescription.WhiteListHtmlRegularExpression)
                .WithMessage(VacancyMessages.LongDescription.WhiteListInvalidCharacterErrorText)
                .Must(Common.BeAValidFreeText)
                .WithMessage(VacancyMessages.LongDescription.WhiteListInvalidTagErrorText)
                .When(x => !string.IsNullOrEmpty(x.LongDescription) && x.VacancyType != VacancyType.Traineeship);

            RuleFor(viewModel => viewModel.LongDescription)
                .Matches(VacancyMessages.LongDescription.WhiteListHtmlRegularExpression)
                .WithMessage(VacancyMessages.LongDescription.TraineeshipWhiteListInvalidCharacterErrorText)
                .Must(Common.BeAValidFreeText)
                .WithMessage(VacancyMessages.LongDescription.TraineeshipWhiteListInvalidTagErrorText)
                .When(x => !string.IsNullOrEmpty(x.LongDescription) && x.VacancyType == VacancyType.Traineeship);

            #endregion

            #region Requirements and prospects

            RuleFor(x => x.DesiredSkills)
                .Matches(VacancyMessages.DesiredSkills.WhiteListHtmlRegularExpression)
                .WithMessage(VacancyMessages.DesiredSkills.WhiteListInvalidCharacterErrorText)
                .Must(Common.BeAValidFreeText)
                .WithMessage(VacancyMessages.DesiredSkills.WhiteListInvalidTagErrorText)
                .When(x => !string.IsNullOrEmpty(x.DesiredSkills));

            RuleFor(x => x.PersonalQualities)
                .Matches(VacancyMessages.PersonalQualities.WhiteListHtmlRegularExpression)
                .WithMessage(VacancyMessages.PersonalQualities.WhiteListInvalidCharacterErrorText)
                .Must(Common.BeAValidFreeText)
                .WithMessage(VacancyMessages.PersonalQualities.WhiteListInvalidTagErrorText)
                .When(x => !string.IsNullOrEmpty(x.PersonalQualities));

            RuleFor(x => x.DesiredQualifications)
                .Matches(VacancyMessages.DesiredQualifications.WhiteListHtmlRegularExpression)
                .WithMessage(VacancyMessages.DesiredQualifications.WhiteListInvalidCharacterErrorText)
                .Must(Common.BeAValidFreeText)
                .WithMessage(VacancyMessages.DesiredQualifications.WhiteListInvalidTagErrorText)
                .When(x => !string.IsNullOrEmpty(x.DesiredQualifications));

            RuleFor(x => x.FutureProspects)
                .Matches(VacancyMessages.FutureProspects.WhiteListHtmlRegularExpression)
                .WithMessage(VacancyMessages.FutureProspects.WhiteListInvalidCharacterErrorText)
                .Must(Common.BeAValidFreeText)
                .WithMessage(VacancyMessages.FutureProspects.WhiteListInvalidTagErrorText)
                .When(x => !string.IsNullOrEmpty(x.FutureProspects));

            RuleFor(x => x.ThingsToConsider)
                .Matches(VacancyMessages.ThingsToConsider.WhiteListHtmlRegularExpression)
                .WithMessage(VacancyMessages.ThingsToConsider.WhiteListInvalidCharacterErrorText)
                .Must(Common.BeAValidFreeText)
                .WithMessage(VacancyMessages.ThingsToConsider.WhiteListInvalidTagErrorText)
                .When(x => !string.IsNullOrEmpty(x.ThingsToConsider));

            #endregion
        }

        private static bool IsAnonymousEmployer(Vacancy vacancy)
        {
            return vacancy.IsAnonymousEmployer.HasValue && vacancy.IsAnonymousEmployer.Value;
        }
    }
}