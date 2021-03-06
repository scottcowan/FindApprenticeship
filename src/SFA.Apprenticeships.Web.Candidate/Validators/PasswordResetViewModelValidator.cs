﻿namespace SFA.Apprenticeships.Web.Candidate.Validators
{
    using Constants.Pages;
    using Constants.ViewModels;
    using FluentValidation;
    using ViewModels.Register;

    public class PasswordResetViewModelClientValidator : AbstractValidator<PasswordResetViewModel>
    {
        public PasswordResetViewModelClientValidator()
        {
            this.AddCommonRules();
        }
    }

    public class PasswordResetViewModelServerValidator : AbstractValidator<PasswordResetViewModel>
    {
        public PasswordResetViewModelServerValidator()
        {
            this.AddCommonRules();
            this.AddServerRules();
        }
    }

    public static class PasswordResetViewModelValidatorRules
    {
        public static void AddCommonRules(this AbstractValidator<PasswordResetViewModel> validator)
        {
            validator.RuleFor(x => x.PasswordResetCode)
                .NotEmpty()
                .WithMessage(PasswordResetViewModelMessages.PasswordResetCodeMessages.RequiredErrorText)
                .Length(6, 6)
                .WithMessage(PasswordResetViewModelMessages.PasswordResetCodeMessages.LengthErrorText)
                .Matches(PasswordResetViewModelMessages.PasswordResetCodeMessages.WhiteListRegularExpression)
                .WithMessage(PasswordResetViewModelMessages.PasswordResetCodeMessages.WhiteListErrorText);

            validator.RuleFor(x => x.Password)
                .Length(8, 127)
                .WithMessage(PasswordResetViewModelMessages.PasswordMessages.LengthErrorText)
                .NotEmpty()
                .WithMessage(PasswordResetViewModelMessages.PasswordMessages.RequiredErrorText)
                .Matches(PasswordResetViewModelMessages.PasswordMessages.WhiteListRegularExpression)
                .WithMessage(PasswordResetViewModelMessages.PasswordMessages.WhiteListErrorText);

            validator.RuleFor(x => x.ConfirmPassword)
                .NotEmpty()
                .WithMessage(PasswordResetViewModelMessages.ConfirmPasswordMessages.RequiredErrorText);
        }

        public static void AddServerRules(this AbstractValidator<PasswordResetViewModel> validator)
        {
            validator.RuleFor(x => x.PasswordResetCode)
                .Must(IsPasswordResetCodeValid)
                .WithMessage(PasswordResetPageMessages.InvalidCode);

            validator.RuleFor(x => x.Password)
                .Equal(x => x.ConfirmPassword)
                .WithMessage(PasswordResetViewModelMessages.PasswordMessages.PasswordsDoNotMatchErrorText);
        }

        private static bool IsPasswordResetCodeValid(PasswordResetViewModel model, string passwordResetCode)
        {
            return !string.IsNullOrWhiteSpace(passwordResetCode) && model.IsPasswordResetCodeValid;
        }
    }
}