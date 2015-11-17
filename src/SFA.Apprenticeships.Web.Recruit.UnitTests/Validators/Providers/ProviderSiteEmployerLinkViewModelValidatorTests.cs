﻿namespace SFA.Apprenticeships.Web.Recruit.UnitTests.Validators.Providers
{
    using System;
    using FluentAssertions;
    using NUnit.Framework;
    using FluentValidation.TestHelper;
    using Raa.Common.Validators.Provider;
    using Raa.Common.ViewModels.Provider;

    [TestFixture]
    public class ProviderSiteEmployerLinkViewModelValidatorTests
    {
        [TestCase(null, true)]
        [TestCase("", true)]
        [TestCase("www.google.com", true)]
        [TestCase("http://www.google.com", true)]
        [TestCase("https://www.google.com", true)]
        [TestCase("www\\asdf\\com", false)]
        [TestCase("cantbemissingdot", false)]
        [TestCase("canbeanythingwithcorrect.chars", true)]
        [TestCase("cantbeincorrechars@%", false)]
        [TestCase("www.me-you.com", true)]
        public void ShouldValidateWebSiteUrl(
            string websiteUrl,
            bool expectValid)
        {
            // Arrange.
            var viewModel = new ProviderSiteEmployerLinkViewModel
            {
                WebsiteUrl = websiteUrl,
                Description = "populated"
            };
            string uriString = null;

            // Act.
            var validator = new ProviderSiteEmployerLinkViewModelValidator();
            Action uriAction = () => { uriString = new UriBuilder(viewModel.WebsiteUrl).Uri.ToString(); };

            // Assert.
            if (expectValid)
            {
                validator.ShouldNotHaveValidationErrorFor(m => m.WebsiteUrl, viewModel);
                if (!string.IsNullOrEmpty(websiteUrl))
                {
                    uriAction.ShouldNotThrow();
                    uriString.Should().NotBeNullOrEmpty();
                }
            }
            else
            {
                validator.ShouldHaveValidationErrorFor(m => m.WebsiteUrl, viewModel);
            }
        }

        [TestCase(null, false)]
        [TestCase("", false)]
        [TestCase("something", true)]
        [TestCase(MassivleyLong, true)]
        public void ShouldValidateDescription(
            string description,
            bool expectValid)
        {
            // Arrange.
            var viewModel = new ProviderSiteEmployerLinkViewModel
            {
                WebsiteUrl = "http://www.valid.com",
                Description = description
            };

            // Act.
            var validator = new ProviderSiteEmployerLinkViewModelValidator();

            // Assert.
            if (expectValid)
            {
                validator.ShouldNotHaveValidationErrorFor(m => m.Description, viewModel);
            }
            else
            {
                validator.ShouldHaveValidationErrorFor(m => m.Description, viewModel);
            }
        }

        private const string MassivleyLong = "never too long for the validator never too long for the validator never too long for the validator never too long for the validator never too long for the validator never too long for the validator never too long for the validator never too long for the validator never too long for the validator never too long for the validator never too long for the validator never too long for the validator never too long for the validator never too long for the validator never too long for the validator never too long for the validator never too long for the validator never too long for the validator never too long for the validator never too long for the validator never too long for the validator never too long for the validator never too long for the validator never too long for the validator never too long for the validator never too long for the validator never too long for the validator never too long for the validator never too long for the validator never too long for the validator never too long for the validator never too long for the validator never too long for the validator never too long for the validator never too long for the validator never too long for the validator never too long for the validator never too long for the validator never too long for the validator never too long for the validator never too long for the validator never too long for the validator never too long for the validator never too long for the validator never too long for the validator never too long for the validator never too long for the validator never too long for the validator never too long for the validator never too long for the validator never too long for the validator never too long for the validator never too long for the validator never too long for the validator never too long for the validator never too long for the validator never too long for the validator never too long for the validator never too long for the validator never too long for the validator never too long for the validator never too long for the validator never too long for the validator never too long for the validator never too long for the validator never too long for the validator never too long for the validator never too long for the validator never too long for the validator never too long for the validator never too long for the validator never too long for the validator never too long for the validator never too long for the validator never too long for the validator never too long for the validator never too long for the validator never too long for the validator never too long for the validator never too long for the validator never too long for the validator never too long for the validator never too long for the validator never too long for the validator never too long for the validator never too long for the validator never too long for the validator never too long for the validator never too long for the validator never too long for the validator never too long for the validator never too long for the validator never too long for the validator never too long for the validator never too long for the validator never too long for the validator never too long for the validator never too long for the validator never too long for the validator never too long for the validator never too long for the validator never too long for the validator never too long for the validator never too long for the validator never too long for the validator never too long for the validator never too long for the validator never too long for the validator never too long for the validator never too long for the validator never too long for the validator never too long for the validator never too long for the validator never too long for the validator never too long for the validator never too long for the validator never too long for the validator never too long for the validator never too long for the validator never too long for the validator never too long for the validator never too long for the validator never too long for the validator never too long for the validator never too long for the validator never too long for the validator never too long for the validator never too long for the validator never too long for the validator never too long for the validator never too long for the validator never too long for the validator never too long for the validator never too long for the validator never too long for the validator never too long for the validator never too long for the validator never too long for the validator never too long for the validator never too long for the validator never too long for the validator";
    }
}