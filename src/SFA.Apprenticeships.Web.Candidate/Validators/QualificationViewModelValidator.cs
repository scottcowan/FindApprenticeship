﻿namespace SFA.Apprenticeships.Web.Candidate.Validators
{
    using System;
    using Constants.ViewModels;
    using FluentValidation;
    using ViewModels.Candidate;

    public class QualificationViewModelValidator : AbstractValidator<QualificationsViewModel>
    {
        public QualificationViewModelValidator()
        {
            RuleFor(x => x.QualificationType)
                .Length(0, 100)
                .WithMessage(QualificationViewModelMessages.QualificationTypeMessages.TooLongErrorText)
                .NotEmpty()
                .WithMessage(QualificationViewModelMessages.QualificationTypeMessages.RequiredErrorText)
                .Matches(QualificationViewModelMessages.QualificationTypeMessages.WhiteListRegularExpression)
                .WithMessage(QualificationViewModelMessages.QualificationTypeMessages.WhiteListErrorText);

            RuleFor(x => x.Subject)
                .Length(0, 50)
                .WithMessage(QualificationViewModelMessages.SubjectMessages.TooLongErrorText)
                .NotEmpty()
                .WithMessage(QualificationViewModelMessages.SubjectMessages.RequiredErrorText)
                .Matches(QualificationViewModelMessages.SubjectMessages.WhiteListRegularExpression)
                .WithMessage(QualificationViewModelMessages.SubjectMessages.WhiteListErrorText);

            RuleFor(x => x.Grade)
                .Length(0, 15)
                .WithMessage(QualificationViewModelMessages.GradeMessages.TooLongErrorText)
                .NotEmpty()
                .WithMessage(QualificationViewModelMessages.GradeMessages.RequiredErrorText)
                .Matches(QualificationViewModelMessages.GradeMessages.WhiteListRegularExpression)
                .WithMessage(QualificationViewModelMessages.GradeMessages.WhiteListErrorText);

            var maxYear = Convert.ToString(DateTime.UtcNow.Year - 100);
            RuleFor(x => x.Year)
                .NotEmpty()
                .WithMessage(QualificationViewModelMessages.YearMessages.RequiredErrorText)
                .Matches(QualificationViewModelMessages.YearMessages.MustBeNumericRegularExpression)
                .WithMessage(QualificationViewModelMessages.YearMessages.MustBeNumericErrorText)
                .GreaterThanOrEqualTo(maxYear)
                .WithMessage(QualificationViewModelMessages.YearMessages.MustBeGreaterThan(maxYear));

            RuleFor(x => x.Year)
                .Must(BeNowOrInThePast)
                .WithMessage(QualificationViewModelMessages.YearMessages.BeforeOrEqualErrorText)
                .When(x => !x.IsPredicted);
        }

        private static bool BeNowOrInThePast(QualificationsViewModel instance, string year)
        {
            if (string.IsNullOrEmpty(year))
            {
                //Will be picked up by required validator
                return true;
            }

            int from;

            if (int.TryParse(year, out from))
            {
                return from <= DateTime.UtcNow.Year;
            }

            return  true;
        }
    }
}