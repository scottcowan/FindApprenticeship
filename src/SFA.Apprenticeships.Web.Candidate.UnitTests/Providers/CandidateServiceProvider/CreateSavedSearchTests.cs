﻿namespace SFA.Apprenticeships.Web.Candidate.UnitTests.Providers.CandidateServiceProvider
{
    using System;
    using Application.Interfaces.Candidates;
    using Builders;
    using Constants.Pages;
    using Domain.Entities.Candidates;
    using Domain.Entities.Vacancies.Apprenticeships;
    using FluentAssertions;
    using Moq;
    using NUnit.Framework;

    [TestFixture]
    public class CreateSavedSearchTests
    {
        [Test]
        public void Success()
        {
            var candidateId = Guid.NewGuid();
            SavedSearch savedSearch = null;
            var candidateService = new Mock<ICandidateService>();
            candidateService.Setup(cs => cs.CreateSavedSearch(It.IsAny<SavedSearch>())).Callback<SavedSearch>(ss => { savedSearch = ss; });
            var provider = new CandidateServiceProviderBuilder().With(candidateService).Build();
            var viewModel = new ApprenticeshipSearchViewModelBuilder().Build();

            var response = provider.CreateSavedSearch(candidateId, viewModel);

            response.Should().NotBeNull();
            candidateService.Verify(cs => cs.CreateSavedSearch(It.IsAny<SavedSearch>()), Times.Once);
            savedSearch.Should().NotBeNull();
        }

        [Test]
        public void Mapping()
        {
            var candidateId = Guid.NewGuid();
            const ApprenticeshipSearchMode searchMode = ApprenticeshipSearchMode.Category;
            const string keywords = "chef";
            const string location = "Warwick";
            const int withinDistance = 15;
            const string apprenticeshipLevel = "Advanced";
            const string category = "Engineering";
            var subCategories = new[] {"Mechanical", "Civil"};

            SavedSearch savedSearch = null;
            var candidateService = new Mock<ICandidateService>();
            candidateService.Setup(cs => cs.CreateSavedSearch(It.IsAny<SavedSearch>())).Callback<SavedSearch>(ss => { savedSearch = ss; });
            var provider = new CandidateServiceProviderBuilder().With(candidateService).Build();
            var viewModel = new ApprenticeshipSearchViewModelBuilder()
                .WithSearchMode(searchMode)
                .WithKeywords(keywords)
                .WithLocation(location)
                .WithinDistance(withinDistance)
                .WithApprenticeshipLevel(apprenticeshipLevel)
                .WithCategory(category)
                .WithSubCategories(subCategories)
                .Build();

            var response = provider.CreateSavedSearch(candidateId, viewModel);

            response.Should().NotBeNull();
            candidateService.Verify(cs => cs.CreateSavedSearch(It.IsAny<SavedSearch>()), Times.Once);
            savedSearch.Should().NotBeNull();

            savedSearch.CandidateId.Should().Be(candidateId);
            //savedSearch.Name.Should().Be();
            savedSearch.SearchMode.Should().Be(searchMode);
            savedSearch.Keywords.Should().Be(keywords);
            savedSearch.Location.Should().Be(location);
            savedSearch.WithinDistance.Should().Be(withinDistance);
            savedSearch.ApprenticeshipLevel.Should().Be(apprenticeshipLevel);
            savedSearch.Category.Should().Be(category);
            savedSearch.SubCategories.Should().BeEquivalentTo(subCategories);
            savedSearch.LastResultsHash.Should().BeNull();
            savedSearch.DateProcessed.Should().Be(null);
        }

        [Test]
        public void Error()
        {
            var candidateId = Guid.NewGuid();
            var candidateService = new Mock<ICandidateService>();
            candidateService.Setup(cs => cs.CreateSavedSearch(It.IsAny<SavedSearch>())).Throws<Exception>();
            var provider = new CandidateServiceProviderBuilder().With(candidateService).Build();
            var viewModel = new ApprenticeshipSearchViewModelBuilder().Build();

            var response = provider.CreateSavedSearch(candidateId, viewModel);

            response.Should().NotBeNull();
            candidateService.Verify(cs => cs.CreateSavedSearch(It.IsAny<SavedSearch>()), Times.Once);
            response.HasError().Should().BeTrue();
            response.ViewModelMessage.Should().Be(VacancySearchResultsPageMessages.SaveSearchFailed);
        }
    }
}