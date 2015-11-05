﻿namespace SFA.Apprenticeships.Web.Recruit.UnitTests.Validators.VacancyPosting
{
    using Domain.Entities.Vacancies.Apprenticeships;
    using FluentValidation.TestHelper;
    using NUnit.Framework;
    using Recruit.Validators.Vacancy;
    using ViewModels.Vacancy;

    [TestFixture]
    public class NewVacancyViewModelServerValidatorTests
    {
        private NewVacancyViewModelServerValidator _validator;

        [SetUp]
        public void SetUp()
        {
            _validator = new NewVacancyViewModelServerValidator();
        }

        [TestCase(ApprenticeshipLevel.Unknown, false)]
        [TestCase(ApprenticeshipLevel.Intermediate, true)]
        [TestCase(ApprenticeshipLevel.Higher, true)]
        [TestCase(ApprenticeshipLevel.Advanced, true)]
        [TestCase(4, false)]
        public void ShouldRequireApprenticeshipLevel(ApprenticeshipLevel apprenticeshipLevel, bool expectValid)
        {
            // Arrange.
            var viewModel = new NewVacancyViewModel
            {
                ApprenticeshipLevel = apprenticeshipLevel
            };

            // Act.
            _validator.Validate(viewModel);

            // Assert.
            if (expectValid)
            {
                _validator.ShouldNotHaveValidationErrorFor(m => m.ApprenticeshipLevel, viewModel);
            }
            else
            {
                _validator.ShouldHaveValidationErrorFor(m => m.ApprenticeshipLevel, viewModel);
            }
        }

        [TestCase(null, false)]
        [TestCase("ABC", true)]
        public void ShouldRequireFrameworkCodeName(string frameworkCodeName, bool expectValid)
        {
            // Arrange.
            var viewModel = new NewVacancyViewModel
            {
                FrameworkCodeName = frameworkCodeName
            };

            // Act.
            _validator.Validate(viewModel);

            // Assert.
            if (expectValid)
            {
                _validator.ShouldNotHaveValidationErrorFor(m => m.FrameworkCodeName, viewModel);
            }
            else
            {
                _validator.ShouldHaveValidationErrorFor(m => m.FrameworkCodeName, viewModel);
            }
        }

        [TestCase(null, false)]
        [TestCase("1234", true)]
        public void ShouldRequireStandardId(string standardIdString, bool expectValid)
        {
            // Arrange.
            int? standardId = null;
            int parsedStandardId;
            if (int.TryParse(standardIdString, out parsedStandardId))
            {
                standardId = parsedStandardId;
            }
            var viewModel = new NewVacancyViewModel
            {
                StandardId = standardId
            };

            // Act.
            _validator.Validate(viewModel);

            // Assert.
            if (expectValid)
            {
                _validator.ShouldNotHaveValidationErrorFor(m => m.StandardId, viewModel);
            }
            else
            {
                _validator.ShouldHaveValidationErrorFor(m => m.StandardId, viewModel);
            }
        }

        [TestCase("http://www.google.com", true)]
        [TestCase("asdf", false)]
        [TestCase("asdf.asdflkjasdfl", true)]
        [TestCase(null, false)]
        [TestCase("", false)]
        [TestCase("http://www.google.com/", true)]
        [TestCase("http://www.google.com/someFolder", true)]
        [TestCase("http://www.google.com/someFolder/index.html", true)]
        [TestCase("http://www.google.com/someFolder/index.html?id=445667", true)]
        [TestCase("https://www.google.com/", true)]
        [TestCase("https://www.google.com/someFolder", true)]
        [TestCase("https://www.google.com/someFolder/index.html", true)]
        [TestCase("https://www.google.com/someFolder/index.html?id=445667", true)]
        [TestCase("www.google.com", true)]
        [TestCase("www.google.com/someFolder", true)]
        [TestCase("www.google.com/someFolder/index.html", true)]
        [TestCase("www.google.com/someFolder/index.html?id=445667", true)]
        [TestCase("asdf://asdf.com", false)]
        public void ShouldHaveAValidUrlIfTheVacancyIsOffline(string url, bool expectValid)
        {
            var viewModel = new NewVacancyViewModel
            {
                ApprenticeshipLevel = ApprenticeshipLevel.Advanced,
                FrameworkCodeName = "some framework code name",
                OfflineVacancy = true,
                OfflineApplicationUrl = url
            };

            // Act.
            _validator.Validate(viewModel);

            // Assert.
            if (expectValid)
            {
                _validator.ShouldNotHaveValidationErrorFor(m => m.OfflineApplicationUrl, viewModel);
            }
            else
            {
                _validator.ShouldHaveValidationErrorFor(m => m.OfflineApplicationUrl, viewModel);
            }
        }
    }
}
