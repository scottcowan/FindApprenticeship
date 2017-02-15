namespace SFA.DAS.RAA.Api.Validators
{
    using Apprenticeships.Domain.Entities.Raa.Locations;
    using Apprenticeships.Domain.Entities.Raa.Locations.Constants;
    using FluentValidation;
    public class PostalAddressValidator : AbstractValidator<PostalAddress>
    {
        public PostalAddressValidator()
        {
            RuleFor(x => x.AddressLine1)
                .Length(0, 50)
                .WithMessage(PostalAddressMessages.AddressLine1.TooLongErrorText)
                .NotEmpty()
                .WithMessage(PostalAddressMessages.AddressLine1.RequiredErrorText)
                .Matches(PostalAddressMessages.AddressLine1.WhiteListRegularExpression)
                .WithMessage(PostalAddressMessages.AddressLine1.WhiteListErrorText);

            RuleFor(x => x.AddressLine2)
                .Length(0, 50)
                .WithMessage(PostalAddressMessages.AddressLine2.TooLongErrorText)
                .Matches(PostalAddressMessages.AddressLine2.WhiteListRegularExpression)
                .WithMessage(PostalAddressMessages.AddressLine2.WhiteListErrorText);

            RuleFor(x => x.AddressLine3)
                .Length(0, 50)
                .WithMessage(PostalAddressMessages.AddressLine3.TooLongErrorText)
                .Matches(PostalAddressMessages.AddressLine3.WhiteListRegularExpression)
                .WithMessage(PostalAddressMessages.AddressLine3.WhiteListErrorText);

            RuleFor(x => x.AddressLine4)
                .Length(0, 50)
                .WithMessage(PostalAddressMessages.AddressLine4.TooLongErrorText)
                .Matches(PostalAddressMessages.AddressLine4.WhiteListRegularExpression)
                .WithMessage(PostalAddressMessages.AddressLine4.WhiteListErrorText);

            RuleFor(x => x.AddressLine5)
                .Length(0, 50)
                .WithMessage(PostalAddressMessages.AddressLine5.TooLongErrorText)
                .Matches(PostalAddressMessages.AddressLine5.WhiteListRegularExpression)
                .WithMessage(PostalAddressMessages.AddressLine5.WhiteListErrorText);

            RuleFor(x => x.Town)
                .Length(0, 50)
                .WithMessage(PostalAddressMessages.Town.TooLongErrorText)
                .NotEmpty()
                .WithMessage(PostalAddressMessages.Town.RequiredErrorText)
                .Matches(PostalAddressMessages.Town.WhiteListRegularExpression)
                .WithMessage(PostalAddressMessages.Town.WhiteListErrorText);

            RuleFor(x => x.Postcode)
                .Length(0, 8)
                .WithMessage(PostalAddressMessages.Postcode.TooLongErrorText)
                .NotEmpty()
                .WithMessage(PostalAddressMessages.Postcode.RequiredErrorText)
                .Matches(PostalAddressMessages.Postcode.WhiteListRegularExpression)
                .WithMessage(PostalAddressMessages.Postcode.WhiteListErrorText);
        }
    }
}