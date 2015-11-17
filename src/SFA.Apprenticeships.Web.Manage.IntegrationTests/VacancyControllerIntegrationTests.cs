﻿namespace SFA.Apprenticeships.Web.Manage.IntegrationTests
{
    using System;
    using System.Linq;
    using System.Web.Mvc;
    using Common.Validators;
    using Common.ViewModels;
    using Controllers;
    using Domain.Entities.Locations;
    using Domain.Entities.Organisations;
    using Domain.Entities.Providers;
    using Domain.Entities.Vacancies.ProviderVacancies;
    using Domain.Entities.Vacancies.ProviderVacancies.Apprenticeship;
    using FluentAssertions;
    using Infrastructure.Repositories.Vacancies.Entities;
    using MongoDB.Driver;
    using MongoDB.Driver.Builders;
    using NUnit.Framework;
    using Raa.Common.ViewModels.Vacancy;

    [TestFixture]
    public class VacancyControllerIntegrationTests : ManageWebIntegrationTestsBase
    {
        [Test, Category("Integration")]
        public void GetBasicDetailsWithACorrectVacancyShouldReturnTheVacancyWithAnEmptyModelState()
        {
            // Arrange
            const int vacancyReferenceNumber = 1;
            const string title = "Vacancy title";
            var vacancy = GetCorrectVacancy(vacancyReferenceNumber, title);

            InitializeDatabaseWithVacancy(vacancy);

            var vacancyController = Container.GetInstance<VacancyController>();

            //Act
            var view = vacancyController.BasicDetails(vacancyReferenceNumber);

            // Assert
            view.Should().BeOfType<ViewResult>();

            var viewResult = view as ViewResult;

            viewResult.ViewData.ModelState.Should().HaveCount(0);
            viewResult.Model.Should().BeOfType<NewVacancyViewModel>();
            var vacancyViewModel = viewResult.Model as NewVacancyViewModel;
            vacancyViewModel.VacancyReferenceNumber.Should().Be(vacancyReferenceNumber);
            vacancyViewModel.Title.Should().Be(title);
        }

        [Test, Category("Integration")]
        public void GetBasicDetailsWithAVacancyWithErrorsShouldReturnTheVacancyWithAModelStateFilled()
        {
            // Arrange
            const int vacancyReferenceNumber = 1;
            const string title = "Vacancy title";
            var vacancy = GetVacancyWithErrorsInBasicDetails(vacancyReferenceNumber, title);

            InitializeDatabaseWithVacancy(vacancy);

            var vacancyController = Container.GetInstance<VacancyController>();

            //Act
            var view = vacancyController.BasicDetails(vacancyReferenceNumber);

            // Assert
            view.Should().BeOfType<ViewResult>();

            var viewResult = view as ViewResult;

            viewResult.ViewData.ModelState.Should().HaveCount(1);
            viewResult.ViewData.ModelState.Keys.First().Should().Be("OfflineApplicationUrl");
            viewResult.Model.Should().BeOfType<NewVacancyViewModel>();
            var vacancyViewModel = viewResult.Model as NewVacancyViewModel;
            vacancyViewModel.VacancyReferenceNumber.Should().Be(vacancyReferenceNumber);
            vacancyViewModel.Title.Should().Be(title);
        }

        [Test, Category("Integration")]
        public void PostBasicDetailsShouldRedirectToVacancyReviewIfVacancyIsCorrect()
        {
            // Arrange
            const int vacancyReferenceNumber = 1;
            const string title = "Vacancy title";
            var vacancy = GetCorrectVacancy(vacancyReferenceNumber, title);

            InitializeDatabaseWithVacancy(vacancy);

            var vacancyViewModel = GetNewVacancyViewModel(vacancyReferenceNumber, title);

            var vacancyController = Container.GetInstance<VacancyController>();

            // Act
            var result = vacancyController.BasicDetails(vacancyViewModel);

            // Assert
            result.Should().BeOfType<RedirectToRouteResult>();
            var redirection = result as RedirectToRouteResult;
            redirection.RouteName.Should().Be("ReviewVacancy");
            redirection.RouteValues.Count.Should().Be(1);
            redirection.RouteValues.Keys.First().Should().Be("vacancyReferenceNumber");
            redirection.RouteValues.Values.First().As<long>().Should().Be(vacancyReferenceNumber);
        }

        [Test, Category("Integration")]
        public void PostBasicDetailsWithErrorsShouldReturnTheViewWithModelStateFilled()
        {
            // Arrange
            const int vacancyReferenceNumber = 1;
            const string title = "Vacancy title";
            var vacancy = GetCorrectVacancy(vacancyReferenceNumber, title);

            InitializeDatabaseWithVacancy(vacancy);

            var newVacancyViewModel = GetNewVacancyViewModelWithErrors(vacancyReferenceNumber, title);

            var vacancyController = Container.GetInstance<VacancyController>();

            // Act
            var view = vacancyController.BasicDetails(newVacancyViewModel);

            // Assert
            view.Should().BeOfType<ViewResult>();

            var viewResult = view as ViewResult;

            viewResult.ViewData.ModelState.Should().HaveCount(1);
            viewResult.ViewData.ModelState.Keys.First().Should().Be("OfflineApplicationUrl");
            viewResult.Model.Should().BeOfType<NewVacancyViewModel>();
            var vacancyViewModel = viewResult.Model as NewVacancyViewModel;
            vacancyViewModel.VacancyReferenceNumber.Should().Be(vacancyReferenceNumber);
            vacancyViewModel.Title.Should().Be(newVacancyViewModel.Title);
        }

        [Test, Category("Integration")]
        public void GetSummaryWithACorrectVacancyShouldReturnTheVacancyWithAnEmptyModelState()
        {
            // Arrange
            const int vacancyReferenceNumber = 1;
            const string title = "Vacancy title";
            var vacancy = GetCorrectVacancy(vacancyReferenceNumber, title);

            InitializeDatabaseWithVacancy(vacancy);

            var vacancyController = Container.GetInstance<VacancyController>();

            //Act
            var view = vacancyController.Summary(vacancyReferenceNumber);

            // Assert
            view.Should().BeOfType<ViewResult>();

            var viewResult = view as ViewResult;

            viewResult.ViewData.ModelState.Should().HaveCount(0);
            viewResult.Model.Should().BeOfType<VacancySummaryViewModel>();
            var vacancyViewModel = viewResult.Model as VacancySummaryViewModel;
            vacancyViewModel.VacancyReferenceNumber.Should().Be(vacancyReferenceNumber);
        }

        [Test, Category("Integration")]
        public void GetSummaryWithAnIncorrectVacancyShouldReturnTheVacancyWithTheModelStateFilled()
        {
            // Arrange
            const int vacancyReferenceNumber = 1;
            const string title = "Vacancy title";
            var vacancy = GetVacancyWithErrorsAndWarningsInSummary(vacancyReferenceNumber, title);

            InitializeDatabaseWithVacancy(vacancy);

            var vacancyController = Container.GetInstance<VacancyController>();

            //Act
            var view = vacancyController.Summary(vacancyReferenceNumber);

            // Assert
            view.Should().BeOfType<ViewResult>();

            var viewResult = view as ViewResult;

            viewResult.ViewData.ModelState.Should().HaveCount(2);
            viewResult.ViewData.ModelState.Keys.First().Should().Be("WorkingWeek");
            viewResult.ViewData.ModelState.Values.First().Errors.First().Should().BeOfType<ModelError>();
            viewResult.ViewData.ModelState.Keys.Last().Should().Be("ClosingDate");
            viewResult.ViewData.ModelState.Values.Last().Errors.First().Should().BeOfType<ModelWarning>();
            viewResult.Model.Should().BeOfType<VacancySummaryViewModel>();
            var vacancyViewModel = viewResult.Model as VacancySummaryViewModel;
            vacancyViewModel.VacancyReferenceNumber.Should().Be(vacancyReferenceNumber);
        }

        [Test, Category("Integration")]
        public void PostSummaryWithACorrectVacancyShouldRedirectToPreviewPage()
        {
            const int vacancyReferenceNumber = 1;
            const string title = "Vacancy title";
            var vacancy = GetCorrectVacancy(vacancyReferenceNumber, title);

            InitializeDatabaseWithVacancy(vacancy);

            var vacancyViewModel = GetVacancySummaryViewModel(vacancyReferenceNumber);

            var vacancyController = Container.GetInstance<VacancyController>();

            // Act
            var result = vacancyController.Summary(vacancyViewModel);

            // Assert
            result.Should().BeOfType<RedirectToRouteResult>();
            var redirection = result as RedirectToRouteResult;
            redirection.RouteName.Should().Be("ReviewVacancy");
            redirection.RouteValues.Count.Should().Be(1);
            redirection.RouteValues.Keys.First().Should().Be("vacancyReferenceNumber");
            redirection.RouteValues.Values.First().As<long>().Should().Be(vacancyReferenceNumber);
        }

        [Test, Category("Integration")]
        public void PostSummaryWithAVacancyWithErrorsAndWarningsShouldReturnTheViewWithTheModelStateFilled()
        {
            const int vacancyReferenceNumber = 1;

            var vacancySummaryViewModel = GetVacancyViewModelWithErrorsAndWarningsInSummary(vacancyReferenceNumber);

            var vacancyController = Container.GetInstance<VacancyController>();

            // Act
            var view = vacancyController.Summary(vacancySummaryViewModel);

            // Assert
            view.Should().BeOfType<ViewResult>();

            var viewResult = view as ViewResult;

            viewResult.ViewData.ModelState.Should().HaveCount(2);
            viewResult.ViewData.ModelState.Keys.First().Should().Be("WorkingWeek");
            viewResult.ViewData.ModelState.Values.First().Errors.First().Should().BeOfType<ModelError>();
            viewResult.ViewData.ModelState.Keys.Last().Should().Be("ClosingDate");
            viewResult.ViewData.ModelState.Values.Last().Errors.First().Should().BeOfType<ModelWarning>();
            viewResult.Model.Should().BeOfType<VacancySummaryViewModel>();
            var vacancyViewModel = viewResult.Model as VacancySummaryViewModel;
            vacancyViewModel.VacancyReferenceNumber.Should().Be(vacancyReferenceNumber);
        }

        [Test, Category("Integration")]
        public void GetRequirementsAndProspectsWithACorrectVacancyShouldReturnTheVacancyWithAnEmptyModelState()
        {
            // Arrange
            const int vacancyReferenceNumber = 1;
            const string title = "Vacancy title";
            var vacancy = GetCorrectVacancy(vacancyReferenceNumber, title);

            InitializeDatabaseWithVacancy(vacancy);

            var vacancyController = Container.GetInstance<VacancyController>();

            //Act
            var view = vacancyController.RequirementsAndProspects(vacancyReferenceNumber);

            // Assert
            view.Should().BeOfType<ViewResult>();

            var viewResult = view as ViewResult;

            viewResult.ViewData.ModelState.Should().HaveCount(0);
            viewResult.Model.Should().BeOfType<VacancyRequirementsProspectsViewModel>();
            var vacancyViewModel = viewResult.Model as VacancyRequirementsProspectsViewModel;
            vacancyViewModel.VacancyReferenceNumber.Should().Be(vacancyReferenceNumber);
        }


        [Test, Category("Integration")]
        public void GetRequirementsProspectsWithAnIncorrectVacancyShouldReturnTheVacancyWithTheModelStateFilled()
        {
            // Arrange
            const int vacancyReferenceNumber = 1;
            const string title = "Vacancy title";
            var vacancy = GetVacancyWithErrorsInRequirementsAndProspects(vacancyReferenceNumber, title);

            InitializeDatabaseWithVacancy(vacancy);

            var vacancyController = Container.GetInstance<VacancyController>();

            //Act
            var view = vacancyController.RequirementsAndProspects(vacancyReferenceNumber);

            // Assert
            view.Should().BeOfType<ViewResult>();

            var viewResult = view as ViewResult;

            viewResult.ViewData.ModelState.Should().HaveCount(1);
            viewResult.ViewData.ModelState.Keys.First().Should().Be("DesiredQualifications");
            viewResult.Model.Should().BeOfType<VacancyRequirementsProspectsViewModel>();
            var vacancyViewModel = viewResult.Model as VacancyRequirementsProspectsViewModel;
            vacancyViewModel.VacancyReferenceNumber.Should().Be(vacancyReferenceNumber);
        }

        [Test, Category("Integration")]
        public void PostRequirementsAndProspectsWithACorrectVacancyShouldRedirectToPreviewPage()
        {
            const int vacancyReferenceNumber = 1;
            const string title = "Vacancy title";
            var vacancy = GetCorrectVacancy(vacancyReferenceNumber, title);

            InitializeDatabaseWithVacancy(vacancy);

            var vacancyViewModel = GetVacancyRequirementsAndProspectsViewModel(vacancyReferenceNumber);

            var vacancyController = Container.GetInstance<VacancyController>();

            // Act
            var result = vacancyController.RequirementsAndProspects(vacancyViewModel);

            // Assert
            result.Should().BeOfType<RedirectToRouteResult>();
            var redirection = result as RedirectToRouteResult;
            redirection.RouteName.Should().Be("ReviewVacancy");
            redirection.RouteValues.Count.Should().Be(1);
            redirection.RouteValues.Keys.First().Should().Be("vacancyReferenceNumber");
            redirection.RouteValues.Values.First().As<long>().Should().Be(vacancyReferenceNumber);
        }

        
        [Test, Category("Integration")]
        public void PostRequirementsAndProspectsWithAVacancyWithErrorsAndWarningsShouldReturnTheViewWithTheModelStateFilled()
        {
            const int vacancyReferenceNumber = 1;

            var vacancySummaryViewModel = GetVacancyViewModelWithErrorsAndWarningsRequirementsAndProspects(vacancyReferenceNumber);

            var vacancyController = Container.GetInstance<VacancyController>();

            // Act
            var view = vacancyController.RequirementsAndProspects(vacancySummaryViewModel);

            // Assert
            view.Should().BeOfType<ViewResult>();

            var viewResult = view as ViewResult;

            viewResult.ViewData.ModelState.Should().HaveCount(1);
            viewResult.ViewData.ModelState.Keys.First().Should().Be("DesiredQualifications");
            viewResult.Model.Should().BeOfType<VacancyRequirementsProspectsViewModel>();
            var vacancyViewModel = viewResult.Model as VacancyRequirementsProspectsViewModel;
            vacancyViewModel.VacancyReferenceNumber.Should().Be(vacancyReferenceNumber);
        }


        

        [Test, Category("Integration")]
        public void GetQuestionsWithACorrectVacancyShouldReturnTheVacancyWithAnEmptyModelState()
        {
            // Arrange
            const int vacancyReferenceNumber = 1;
            const string title = "Vacancy title";
            var vacancy = GetCorrectVacancy(vacancyReferenceNumber, title);

            InitializeDatabaseWithVacancy(vacancy);

            var vacancyController = Container.GetInstance<VacancyController>();

            //Act
            var view = vacancyController.Questions(vacancyReferenceNumber);

            // Assert
            view.Should().BeOfType<ViewResult>();

            var viewResult = view as ViewResult;

            viewResult.ViewData.ModelState.Should().HaveCount(0);
            viewResult.Model.Should().BeOfType<VacancyQuestionsViewModel>();
            var vacancyViewModel = viewResult.Model as VacancyQuestionsViewModel;
            vacancyViewModel.VacancyReferenceNumber.Should().Be(vacancyReferenceNumber);
        }
        
        [Test, Category("Integration")]
        public void GetQuestionsWithAnIncorrectVacancyShouldReturnTheVacancyWithTheModelStateFilled()
        {
            // Arrange
            const int vacancyReferenceNumber = 1;
            const string title = "Vacancy title";
            var vacancy = GetVacancyWithErrorsInQuestions(vacancyReferenceNumber, title);

            InitializeDatabaseWithVacancy(vacancy);

            var vacancyController = Container.GetInstance<VacancyController>();

            //Act
            var view = vacancyController.Questions(vacancyReferenceNumber);

            // Assert
            view.Should().BeOfType<ViewResult>();

            var viewResult = view as ViewResult;

            viewResult.ViewData.ModelState.Should().HaveCount(1);
            viewResult.ViewData.ModelState.Keys.First().Should().Be("FirstQuestion");
            viewResult.Model.Should().BeOfType<VacancyQuestionsViewModel>();
            var vacancyViewModel = viewResult.Model as VacancyQuestionsViewModel;
            vacancyViewModel.VacancyReferenceNumber.Should().Be(vacancyReferenceNumber);
        }

        [Test, Category("Integration")]
        public void PostQuestionsWithACorrectVacancyShouldRedirectToPreviewPage()
        {
            const int vacancyReferenceNumber = 1;
            const string title = "Vacancy title";
            var vacancy = GetCorrectVacancy(vacancyReferenceNumber, title);

            InitializeDatabaseWithVacancy(vacancy);

            var vacancyViewModel = GetVacancyQuestionsViewModel(vacancyReferenceNumber);

            var vacancyController = Container.GetInstance<VacancyController>();

            // Act
            var result = vacancyController.Questions(vacancyViewModel);

            // Assert
            result.Should().BeOfType<RedirectToRouteResult>();
            var redirection = result as RedirectToRouteResult;
            redirection.RouteName.Should().Be("ReviewVacancy");
            redirection.RouteValues.Count.Should().Be(1);
            redirection.RouteValues.Keys.First().Should().Be("vacancyReferenceNumber");
            redirection.RouteValues.Values.First().As<long>().Should().Be(vacancyReferenceNumber);
        }
        
        [Test, Category("Integration")]
        public void PostQuestionsWithAVacancyWithErrorsAndWarningsShouldReturnTheViewWithTheModelStateFilled()
        {
            const int vacancyReferenceNumber = 1;

            var vacancySummaryViewModel = GetVacancyViewModelWithErrorsInQuestions(vacancyReferenceNumber);

            var vacancyController = Container.GetInstance<VacancyController>();

            // Act
            var view = vacancyController.Questions(vacancySummaryViewModel);

            // Assert
            view.Should().BeOfType<ViewResult>();

            var viewResult = view as ViewResult;

            viewResult.ViewData.ModelState.Should().HaveCount(1);
            viewResult.ViewData.ModelState.Keys.First().Should().Be("FirstQuestion");
            viewResult.Model.Should().BeOfType<VacancyQuestionsViewModel>();
            var vacancyViewModel = viewResult.Model as VacancyQuestionsViewModel;
            vacancyViewModel.VacancyReferenceNumber.Should().Be(vacancyReferenceNumber);
        }


        [Test, Category("Integration")]
        public void ReviewAVacancyInQAChangesStatusInDatabaseToReservedForQA()
        {
            const int vacancyReferenceNumber = 1;
            const string title = "Vacancy title";
            var vacancy = GetCorrectVacancy(vacancyReferenceNumber, title);

            InitializeDatabaseWithVacancy(vacancy);

            var vacancyController = Container.GetInstance<VacancyController>();

            vacancyController.Review(vacancyReferenceNumber);

            var vacancyInDb =
                Collection.FindOne(Query<MongoApprenticeshipVacancy>.EQ(o => o.VacancyReferenceNumber,
                    vacancyReferenceNumber));

            vacancyInDb.Status.Should().Be(ProviderVacancyStatuses.ReservedForQA);
            vacancyInDb.QAUserName.Should().Be(QaUserName);
            vacancyInDb.DateStartedToQA.Should().BeCloseTo(DateTime.UtcNow, 1000);
        }

        [Test, Category("Integration")]
        public void AcceptAVacancyInQAChangesStatusInDatabaseToLive()
        {
            const int vacancyReferenceNumber = 1;
            const string title = "Vacancy title";
            var vacancy = GetCorrectVacancy(vacancyReferenceNumber, title);

            InitializeDatabaseWithVacancy(vacancy);

            var vacancyController = Container.GetInstance<VacancyController>();

            vacancyController.Approve(vacancyReferenceNumber);

            var vacancyInDb =
                Collection.FindOne(Query<MongoApprenticeshipVacancy>.EQ(o => o.VacancyReferenceNumber,
                    vacancyReferenceNumber));

            vacancyInDb.Status.Should().Be(ProviderVacancyStatuses.Live);
        }

        [Test, Category("Integration")]
        public void ShouldComeBackToDashboardAfterAcceptingTheVacancyIfTheresOnlyOneVacancyWaitingForQA()
        {
            const int vacancyReferenceNumber = 1;
            const string title = "Vacancy title";
            var vacancy = GetCorrectVacancy(vacancyReferenceNumber, title);

            InitializeDatabaseWithVacancy(vacancy);

            var vacancyController = Container.GetInstance<VacancyController>();

            var result = vacancyController.Approve(vacancyReferenceNumber);

            result.Should().BeOfType<RedirectToRouteResult>();
            var redirection = result as RedirectToRouteResult;
            redirection.RouteName.Should().Be("Dashboard");
        }

        [Test, Category("Integration")]
        public void ShouldRedirectToTheNextVacancyAfterAcceptingTheVacancyIfTheresMoreThanOneVacancyWaitingForQA()
        {
            const int vacancyReferenceNumber = 1;
            const int secondVacancyReferenceNumber = 1;
            const string title = "Vacancy title";
            var vacancy = GetCorrectVacancy(vacancyReferenceNumber, title);
            var secondVacancy = GetCorrectVacancy(secondVacancyReferenceNumber, title);

            InitializeDatabaseWithVacancy(vacancy);
            InitializeDatabaseWithVacancy(secondVacancy);

            var vacancyController = Container.GetInstance<VacancyController>();

            var result = vacancyController.Approve(vacancyReferenceNumber);

            result.Should().BeOfType<RedirectToRouteResult>();
            var redirection = result as RedirectToRouteResult;
            redirection.RouteName.Should().Be("ReviewVacancy");
            redirection.RouteValues.Count.Should().Be(1);
            redirection.RouteValues.Keys.First().Should().Be("vacancyReferenceNumber");
            redirection.RouteValues.Values.First().As<long>().Should().Be(secondVacancyReferenceNumber);
        }

        [Test, Category("Integration")]
        public void RejectAVacancyInQAChangesStatusInDatabaseToRejectedByQA()
        {
            const int vacancyReferenceNumber = 1;
            const string title = "Vacancy title";
            var vacancy = GetCorrectVacancy(vacancyReferenceNumber, title);

            InitializeDatabaseWithVacancy(vacancy);

            var vacancyController = Container.GetInstance<VacancyController>();

            vacancyController.Reject(vacancyReferenceNumber);

            var vacancyInDb =
                Collection.FindOne(Query<MongoApprenticeshipVacancy>.EQ(o => o.VacancyReferenceNumber,
                    vacancyReferenceNumber));

            vacancyInDb.Status.Should().Be(ProviderVacancyStatuses.RejectedByQA);
        }

        [Test, Category("Integration")]
        public void ShouldComeBackToDashboardAfterRejectingTheVacancyIfTheresOnlyOneVacancyWaitingForQA()
        {
            const int vacancyReferenceNumber = 1;
            const string title = "Vacancy title";
            var vacancy = GetCorrectVacancy(vacancyReferenceNumber, title);

            InitializeDatabaseWithVacancy(vacancy);

            var vacancyController = Container.GetInstance<VacancyController>();

            var result = vacancyController.Reject(vacancyReferenceNumber);

            result.Should().BeOfType<RedirectToRouteResult>();
            var redirection = result as RedirectToRouteResult;
            redirection.RouteName.Should().Be("Dashboard");
        }

        [Test, Category("Integration")]
        public void ShouldRedirectToTheNextVacancyAfterRejectingTheVacancyIfTheresMoreThanOneVacancyWaitingForQA()
        {
            const int vacancyReferenceNumber = 1;
            const int secondVacancyReferenceNumber = 1;
            const string title = "Vacancy title";
            var vacancy = GetCorrectVacancy(vacancyReferenceNumber, title);
            var secondVacancy = GetCorrectVacancy(secondVacancyReferenceNumber, title);

            InitializeDatabaseWithVacancy(vacancy);
            InitializeDatabaseWithVacancy(secondVacancy);

            var vacancyController = Container.GetInstance<VacancyController>();

            var result = vacancyController.Reject(vacancyReferenceNumber);

            result.Should().BeOfType<RedirectToRouteResult>();
            var redirection = result as RedirectToRouteResult;
            redirection.RouteName.Should().Be("ReviewVacancy");
            redirection.RouteValues.Count.Should().Be(1);
            redirection.RouteValues.Keys.First().Should().Be("vacancyReferenceNumber");
            redirection.RouteValues.Values.First().As<long>().Should().Be(secondVacancyReferenceNumber);
        }

        private void InitializeDatabaseWithVacancy(MongoApprenticeshipVacancy vacancy)
        {
            var mongoConnectionString = MongoConfiguration.VacancyDb;
            var mongoDbName = MongoUrl.Create(mongoConnectionString).DatabaseName;

            var database = new MongoClient(mongoConnectionString)
                .GetServer()
                .GetDatabase(mongoDbName);

            Collection = database.GetCollection<MongoApprenticeshipVacancy>("apprenticeshipVacancies");

            Collection.Save(vacancy);
        }

        private static MongoApprenticeshipVacancy GetCorrectVacancy(int vacancyReferenceNumber, string title)
        {
            return new MongoApprenticeshipVacancy
            {
                Title = title,
                ApprenticeshipLevel = ApprenticeshipLevel.Advanced,
                VacancyReferenceNumber = vacancyReferenceNumber,
                ClosingDate = DateTime.UtcNow.AddDays(30),
                DateCreated = DateTime.UtcNow.AddDays(-1),
                DateSubmitted = DateTime.UtcNow.AddDays(-1),
                DesiredQualifications = "desired qualifications",
                DesiredSkills = "desired skills",
                Duration = 3,
                DurationType = DurationType.Years,
                EntityId = Guid.NewGuid(),
                FutureProspects = "future prospects",
                HoursPerWeek = 40,
                LongDescription = "long description",
                OfflineVacancy = false,
                PersonalQualities = "personal qualities",
                PossibleStartDate = DateTime.UtcNow.AddDays(100),
                ProviderSiteEmployerLink = new ProviderSiteEmployerLink
                {
                    DateCreated = DateTime.UtcNow,
                    Description = "employer link",
                    DateUpdated = DateTime.UtcNow,
                    ProviderSiteErn = "101282923",
                    WebsiteUrl = "www.google.com",
                    Employer = new Employer
                    {
                        Ern = "100608868",
                        Name = "Employer name",
                        Address = new Address
                        {
                            AddressLine1 = "address line 1",
                            AddressLine2 = "address line 2",
                            AddressLine3 = "address line 3",
                            AddressLine4 = "address line 4",
                            Postcode = "postcode",
                            Uprn = null,
                            GeoPoint = new GeoPoint
                            {
                                Latitude = 0.0,
                                Longitude = 0.0
                            }
                        }
                    }
                },
                ShortDescription = "short description",
                Status = ProviderVacancyStatuses.PendingQA,
                TrainingType = TrainingType.Standards,
                StandardId = 1,
                WorkingWeek = "Working week",
                WageType = WageType.ApprenticeshipMinimumWage,
                Ukprn = "10003816"
            };
        }

        private static MongoApprenticeshipVacancy GetVacancyWithErrorsInBasicDetails(int vacancyReferenceNumber,
            string title)
        {
            var vacancy = GetCorrectVacancy(vacancyReferenceNumber, title);
            vacancy.OfflineVacancy = true;
            vacancy.OfflineApplicationUrl = "invalid url"; // Error

            return vacancy;
        }

        private static NewVacancyViewModel GetNewVacancyViewModelWithErrors(int vacancyReferenceNumber,
            string vacancyTitle)
        {
            var viewModel = GetNewVacancyViewModel(vacancyReferenceNumber, vacancyTitle);
            viewModel.OfflineVacancy = true;
            viewModel.OfflineApplicationUrl = "invalid url";

            return viewModel;
        }

        private static NewVacancyViewModel GetNewVacancyViewModel(int vacancyReferenceNumber, string title)
        {
            var vacancyViewModel = new NewVacancyViewModel
            {
                ApprenticeshipLevel = ApprenticeshipLevel.Intermediate,
                FrameworkCodeName = "framework code name",
                OfflineVacancy = false,
                ShortDescription = "short description",
                Ukprn = "ukprn",
                Title = title + "modified",
                TrainingType = TrainingType.Frameworks,
                VacancyReferenceNumber = vacancyReferenceNumber
            };
            return vacancyViewModel;
        }

        private static MongoApprenticeshipVacancy GetVacancyWithErrorsAndWarningsInSummary(int vacancyReferenceNumber,
            string vacancyTitle)
        {
            var vacancy = GetCorrectVacancy(vacancyReferenceNumber, vacancyTitle);
            vacancy.ClosingDate = DateTime.UtcNow.AddDays(5); // Warning
            vacancy.WorkingWeek = null;

            return vacancy;
        }

        private static VacancySummaryViewModel GetVacancySummaryViewModel(int vacancyReferenceNumber)
        {
            var vacancySummaryViewModel = new VacancySummaryViewModel
            {
                VacancyReferenceNumber = vacancyReferenceNumber,
                ClosingDate = new DateViewModel(DateTime.UtcNow.AddDays(30)),
                Duration = 3,
                DurationType = DurationType.Years,
                HoursPerWeek = 40,
                LongDescription = "Long description",
                PossibleStartDate = new DateViewModel(DateTime.UtcNow.AddDays(60)),
                WageType = WageType.ApprenticeshipMinimumWage,
                WorkingWeek = "working week"
            };

            return vacancySummaryViewModel;
        }

        private static VacancySummaryViewModel GetVacancyViewModelWithErrorsAndWarningsInSummary(
            int vacancyReferenceNumber)
        {
            var vacancySummaryViewModel = GetVacancySummaryViewModel(vacancyReferenceNumber);

            vacancySummaryViewModel.ClosingDate = new DateViewModel(DateTime.UtcNow.AddDays(5)); // Warning
            vacancySummaryViewModel.WorkingWeek = null; // Error

            return vacancySummaryViewModel;
        }

        private static MongoApprenticeshipVacancy GetVacancyWithErrorsInRequirementsAndProspects(
            int vacancyReferenceNumber, string vacancyTitle)
        {
            var vacancy = GetCorrectVacancy(vacancyReferenceNumber, vacancyTitle);
            vacancy.DesiredQualifications = null;

            return vacancy;
        }

        private static VacancyRequirementsProspectsViewModel GetVacancyRequirementsAndProspectsViewModel(
            int vacancyReferenceNumber)
        {
            var viewModel = new VacancyRequirementsProspectsViewModel
            {
                DesiredQualifications = "desired qualifications",
                DesiredSkills = "desired skills",
                FutureProspects = "future prospects",
                PersonalQualities = "personal qualities",
                ThingsToConsider = "things to consider",
                VacancyReferenceNumber = vacancyReferenceNumber
            };

            return viewModel;
        }

        private static VacancyRequirementsProspectsViewModel GetVacancyViewModelWithErrorsAndWarningsRequirementsAndProspects(
            int vacancyReferenceNumber)
        {
            var viewModel = new VacancyRequirementsProspectsViewModel
            {
                DesiredQualifications = null, // Error
                DesiredSkills = "desired skills",
                FutureProspects = "future prospects",
                PersonalQualities = "personal qualities",
                ThingsToConsider = "things to consider",
                VacancyReferenceNumber = vacancyReferenceNumber
            };

            return viewModel;
        }

        private static MongoApprenticeshipVacancy GetVacancyWithErrorsInQuestions(
            int vacancyReferenceNumber, string vacancyTitle)
        {
            var vacancy = GetCorrectVacancy(vacancyReferenceNumber, vacancyTitle);
            vacancy.FirstQuestion = "<script></script>";

            return vacancy;
        }

        private static VacancyQuestionsViewModel GetVacancyQuestionsViewModel(
            int vacancyReferenceNumber)
        {
            var viewModel = new VacancyQuestionsViewModel
            {
                FirstQuestion = "first question",
                SecondQuestion = "second question",
                VacancyReferenceNumber = vacancyReferenceNumber
            };

            return viewModel;
        }

        private static VacancyQuestionsViewModel GetVacancyViewModelWithErrorsInQuestions(
            int vacancyReferenceNumber)
        {
            var viewModel = new VacancyQuestionsViewModel
            {
                FirstQuestion = "<script></script>",
                VacancyReferenceNumber = vacancyReferenceNumber
            };

            return viewModel;
        }
    }
}