﻿namespace SFA.Apprenticeships.Web.Raa.Common.UnitTests.Views.Shared.DisplayTemplates.Vacancy
{
    using Common.Views.Shared.DisplayTemplates.Vacancy;
    using Domain.Entities.Raa.Vacancies;
    using Domain.Entities.Vacancies;
    using FluentAssertions;
    using NUnit.Framework;
    using Ploeh.AutoFixture;
    using RazorGenerator.Testing;
    using ViewModels.Vacancy;
    using Web.Common.ViewModels;
    using VacancyType = Domain.Entities.Raa.Vacancies.VacancyType;

    [TestFixture]
    public class FurtherVacancyDetailsTests : ViewUnitTest
    {
        [Test]
        public void ApprenticeshipHeading()
        {
            //Arrange
            var viewModel = new Fixture().Build<FurtherVacancyDetailsViewModel>()
                .With(vm => vm.VacancyType, VacancyType.Apprenticeship)
                .Create();
            var details = new FurtherVacancyDetails();

            //Act
            var view = details.RenderAsHtml(viewModel);

            view.GetElementbyId("heading").Should().NotBeNull();
            view.GetElementbyId("heading").InnerText.Should().Contain("Enter further details");
        }

        [Test]
        public void TraineeshipHeading()
        {
            //Arrange
            var viewModel = new Fixture().Build<FurtherVacancyDetailsViewModel>()
                .With(vm => vm.VacancyType, VacancyType.Traineeship)
                .Create();
            var details = new FurtherVacancyDetails();

            //Act
            var view = details.RenderAsHtml(viewModel);

            //Assert
            view.GetElementbyId("heading").Should().NotBeNull();
            view.GetElementbyId("heading").InnerText.Should().Be("Enter opportunity details");
        }

        [Test]
        public void ApprenticeshipWorkingWeekLabel()
        {
            //Arrange
            var viewModel = new Fixture().Build<FurtherVacancyDetailsViewModel>()
                .With(vm => vm.VacancyType, VacancyType.Apprenticeship)
                .Create();
            var details = new FurtherVacancyDetails();

            //Act
            var view = details.RenderAsHtml(viewModel);

            //Assert
            var workingWeek = view.GetElementbyId("WorkingWeek");
            workingWeek.Should().NotBeNull();
            var label = workingWeek.PreviousSibling;
            label.Should().NotBeNull();
            label.InnerText.Should().Be("Working week");
        }

        [Test]
        public void TraineeshipWorkingWeekLabel()
        {
            //Arrange
            var viewModel = new Fixture().Build<FurtherVacancyDetailsViewModel>()
                .With(vm => vm.VacancyType, VacancyType.Traineeship)
                .Create();
            var details = new FurtherVacancyDetails();

            //Act
            var view = details.RenderAsHtml(viewModel);

            //Assert
            var workingWeek = view.GetElementbyId("WorkingWeek");
            workingWeek.Should().NotBeNull();
            var label = workingWeek.PreviousSibling;
            label.Should().NotBeNull();
            label.InnerText.Should().Be("Weekly hours");
        }

        [Test]
        public void ShouldHaveHoursPerWeekWhenApprenticeship()
        {
            //Arrange
            var viewModel = new Fixture().Build<FurtherVacancyDetailsViewModel>()
                .With(vm => vm.VacancyType, VacancyType.Apprenticeship)
                .With(vm => vm.Wage, new WageViewModel(WageType.Custom, null, null, WageUnit.NotApplicable, null))
                .Create();
            var details = new FurtherVacancyDetails();

            //Act
            var view = details.RenderAsHtml(viewModel);

            //Assert
            var hoursPerWeek = view.GetElementbyId("WageObject_HoursPerWeek");
            hoursPerWeek.Should().NotBeNull();
            hoursPerWeek.Attributes["type"].Value.Should().Be("tel");
        }

        [Test]
        public void ShouldNotHaveHoursPerWeekWhenTraineeship()
        {
            //Arrange
            var viewModel = new Fixture().Build<FurtherVacancyDetailsViewModel>()
                .With(vm => vm.VacancyType, VacancyType.Traineeship)
                .With(vm => vm.Wage, new WageViewModel(WageType.Custom, null, null, WageUnit.NotApplicable, null))
                .Create();
            var details = new FurtherVacancyDetails();

            //Act
            var view = details.RenderAsHtml(viewModel);

            //Assert
            var hoursPerWeek = view.GetElementbyId("WageObject_HoursPerWeek");
            hoursPerWeek.Should().NotBeNull();
            hoursPerWeek.Attributes["type"].Value.Should().Be("hidden");
        }
        
        [Test]
        public void ShouldHaveWageWhenApprenticeship()
        {
            //Arrange
            var viewModel = new Fixture().Build<FurtherVacancyDetailsViewModel>()
                .With(vm => vm.VacancyType, VacancyType.Apprenticeship)
                .With(vm => vm.Wage, new WageViewModel(WageType.Custom, null, null, WageUnit.NotApplicable, null))
                .Create();
            var details = new FurtherVacancyDetails();

            //Act
            var view = details.RenderAsHtml(viewModel);

            //Assert
            view.GetElementbyId("custom-wage").Should().NotBeNull();
            view.GetElementbyId("national-minimum-wage").Should().NotBeNull();
            view.GetElementbyId("apprenticeship-minimum-wage").Should().NotBeNull();
            var wage = view.GetElementbyId("WageObject_Amount");
            wage.Should().NotBeNull();
            wage.Attributes["type"].Value.Should().Be("tel");
            var wageUnit = view.GetElementbyId("WageObject_Unit");
            wageUnit.Should().NotBeNull();
            wageUnit.Name.Should().Be("select");
        }

        [Test]
        public void ShouldHaveWageRegardlessOfWageTextValue()
        {
            //Arrange
            var viewModel = new Fixture().Build<FurtherVacancyDetailsViewModel>()
                .With(vm => vm.VacancyType, VacancyType.Apprenticeship)
                .With(vm => vm.Wage, new WageViewModel(WageType.Custom, null, null, WageUnit.NotApplicable, null))
                .Create();
            var details = new FurtherVacancyDetails();

            //Act
            var view = details.RenderAsHtml(viewModel);

            //Assert
            view.GetElementbyId("custom-wage").Should().NotBeNull();
            view.GetElementbyId("national-minimum-wage").Should().NotBeNull();
            view.GetElementbyId("apprenticeship-minimum-wage").Should().NotBeNull();
            var wage = view.GetElementbyId("WageObject_Amount");
            wage.Should().NotBeNull();
            wage.Attributes["type"].Value.Should().Be("tel");
            var wageUnit = view.GetElementbyId("WageObject_Unit");
            wageUnit.Should().NotBeNull();
            wageUnit.Name.Should().Be("select");
        }

        [Test]
        public void ShouldNotHaveWageWhenTraineeship()
        {
            //Arrange
            var viewModel = new Fixture().Build<FurtherVacancyDetailsViewModel>()
                .With(vm => vm.VacancyType, VacancyType.Traineeship)
                .With(vm => vm.Wage, new WageViewModel(WageType.Custom, null, null, WageUnit.NotApplicable, null))
                .Create();
            var details = new FurtherVacancyDetails();

            //Act
            var view = details.RenderAsHtml(viewModel);

            //Assert
            view.GetElementbyId("custom-wage").Should().BeNull();
            view.GetElementbyId("national-minimum-wage").Should().BeNull();
            view.GetElementbyId("apprenticeship-minimum-wage").Should().BeNull();
            var wageType= view.GetElementbyId("WageObject_Type");
            wageType.Should().NotBeNull();
            wageType.Attributes["type"].Value.Should().Be("hidden");
            var wage = view.GetElementbyId("WageObject_Amount");
            wage.Should().NotBeNull();
            wage.Attributes["type"].Value.Should().Be("hidden");
            var wageUnit = view.GetElementbyId("WageObject_Unit");
            wageUnit.Should().NotBeNull();
            wageUnit.Attributes["type"].Value.Should().Be("hidden");
        }

        [Test]
        public void ShouldNoDisplayLegacyExpectedDurationWhenVacancySourceIsRaa()
        {
            //Arrange
            var viewModel = new Fixture().Build<FurtherVacancyDetailsViewModel>()
                .With(v => v.VacancySource, VacancySource.Raa)
                .Create();
            var details = new FurtherVacancyDetails();

            //Act
            var view = details.RenderAsHtml(viewModel);

            //Assert
            var expectedDuration = view.GetElementbyId("ExpectedDuration");
            expectedDuration.Should().BeNull();
        }
    }
}