﻿namespace SFA.Apprenticeships.Web.Candidate.UnitTests.Mediators.ApprenticeshipSearch
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Application.Interfaces.Vacancies;
    using Candidate.Mediators.Search;
    using Candidate.ViewModels.VacancySearch;
    using Common.Constants;
    using Common.UnitTests.Mediators;
    using Constants;
    using Domain.Entities.ReferenceData;
    using Domain.Entities.Vacancies.Apprenticeships;
    using FluentAssertions;
    using Moq;
    using NUnit.Framework;

    [TestFixture]
    [Parallelizable]
    public class ResultsTests : TestsBase
    {
        [SetUp]
        public override void Setup()
        {
            base.Setup();

            SearchProvider.Setup(sp => sp.FindLocation(It.IsAny<string>()))
                .Returns<string>(l => new LocationsViewModel(new[] {new LocationViewModel {Name = l}}));

            var londonVacancies = new[]
            {
                new ApprenticeshipVacancySummaryViewModel {Description = "A London Vacancy"}
            };

            var emptyVacancies = new ApprenticeshipVacancySummaryViewModel[0];
            //This order is important. Moq will run though all matches and pick the last one
            ApprenticeshipVacancyProvider.Setup(sp => sp.FindVacancies(It.IsAny<ApprenticeshipSearchViewModel>()))
                .Returns<ApprenticeshipSearchViewModel>(
                    svm => new ApprenticeshipSearchResponseViewModel {Vacancies = emptyVacancies, VacancySearch = svm})
                .Callback<ApprenticeshipSearchViewModel>(svm => { _searchSentToSearchProvider = svm; });
            ApprenticeshipVacancyProvider.Setup(
                sp =>
                    sp.FindVacancies(
                        It.Is<ApprenticeshipSearchViewModel>(svm => svm.Location == ACityWithOneSuggestedLocation)))
                .Returns<ApprenticeshipSearchViewModel>(
                    svm => new ApprenticeshipSearchResponseViewModel {Vacancies = londonVacancies, VacancySearch = svm})
                .Callback<ApprenticeshipSearchViewModel>(svm => { _searchSentToSearchProvider = svm; });
        }

        private const string AKeyword = "A keyword";
        private const string ACityWithOneSuggestedLocation = "London";
        private const string ACityWithoutSuggestedLocations = "Liverpool";
        private const string SomeErrorMessage = "SomeErrorMessage";
        private const string ACityWithMoreThanOneSuggestedLocation = "Manchester";

        private ApprenticeshipSearchViewModel _searchSentToSearchProvider;

        [Test]
        public void ApprenticeshipLevelOk()
        {
            var searchViewModel = new ApprenticeshipSearchViewModel
            {
                Location = ACityWithOneSuggestedLocation,
                ApprenticeshipLevel = "Higher"
            };

            var response = Mediator.Results(null, searchViewModel);

            response.AssertCode(ApprenticeshipSearchMediatorCodes.Results.Ok, true);

            var viewModel = response.ViewModel;
            viewModel.Vacancies.Should().NotBeNullOrEmpty();
            var vacancies = viewModel.Vacancies.ToList();
            vacancies.Count.Should().Be(1);
            viewModel.ApprenticeshipLevels.Should().NotBeNull();
            viewModel.VacancySearch.ApprenticeshipLevel.Should().Be("Higher");
            UserDataProvider.Verify(udp => udp.Push(CandidateDataItemNames.ApprenticeshipLevel, "Higher"), Times.Once);
        }

        [Test]
        public void CategoryIsNormalizedToNewFormat()
        {
            const string oldFormattedCategoryCode = "HBY";
            const string expectedCategoryCode = "SSAT1.HBY";

            var searchViewModel = new ApprenticeshipSearchViewModel
            {
                Category = oldFormattedCategoryCode
            };

            var response = Mediator.Results(null, searchViewModel);

            response.ViewModel.VacancySearch.Category.Should().Be(expectedCategoryCode);
        }

        [Test]
        public void ChangeLocationTypeOnNationalSearchWithKeywords()
        {
            const VacancySearchSortType originalSortType = VacancySearchSortType.Distance;

            var searchViewModel = new ApprenticeshipSearchViewModel
            {
                Location = ACityWithOneSuggestedLocation,
                LocationType = ApprenticeshipLocationType.National,
                SortType = originalSortType,
                SearchAction = SearchAction.LocationTypeChanged,
                Keywords = AKeyword
            };

            var response = Mediator.Results(null, searchViewModel);

            response.AssertCode(ApprenticeshipSearchMediatorCodes.Results.Ok, true);

            response.ViewModel.VacancySearch.SortType.Should().Be(VacancySearchSortType.Relevancy);
        }

        [Test]
        public void ChangeLocationTypeOnNationalSearchWithoutKeywords()
        {
            const VacancySearchSortType originalSortType = VacancySearchSortType.Distance;

            var searchViewModel = new ApprenticeshipSearchViewModel
            {
                Location = ACityWithOneSuggestedLocation,
                LocationType = ApprenticeshipLocationType.National,
                SortType = originalSortType,
                SearchAction = SearchAction.LocationTypeChanged
            };

            var response = Mediator.Results(null, searchViewModel);

            response.AssertCode(ApprenticeshipSearchMediatorCodes.Results.Ok, true);

            response.ViewModel.VacancySearch.SortType.Should().Be(VacancySearchSortType.ClosingDate);
        }

        [Test]
        public void ChangeLocationTypeOnNonNationalSearchWithKeywords()
        {
            const VacancySearchSortType originalSortType = VacancySearchSortType.Distance;

            var searchViewModel = new ApprenticeshipSearchViewModel
            {
                Location = ACityWithOneSuggestedLocation,
                LocationType = ApprenticeshipLocationType.NonNational,
                SortType = originalSortType,
                SearchAction = SearchAction.LocationTypeChanged,
                Keywords = AKeyword
            };

            var response = Mediator.Results(null, searchViewModel);

            response.AssertCode(ApprenticeshipSearchMediatorCodes.Results.Ok, true);

            response.ViewModel.VacancySearch.SortType.Should().Be(VacancySearchSortType.Relevancy);
        }

        [Test]
        public void ChangeLocationTypeOnNonNationalSearchWithoutKeywords()
        {
            const VacancySearchSortType originalSortType = VacancySearchSortType.Distance;

            var searchViewModel = new ApprenticeshipSearchViewModel
            {
                Location = ACityWithOneSuggestedLocation,
                LocationType = ApprenticeshipLocationType.NonNational,
                SortType = originalSortType,
                SearchAction = SearchAction.LocationTypeChanged
            };

            var response = Mediator.Results(null, searchViewModel);

            response.AssertCode(ApprenticeshipSearchMediatorCodes.Results.Ok, true);

            response.ViewModel.VacancySearch.SortType.Should().Be(VacancySearchSortType.Distance);
        }

        [Test]
        public void ErrorFindingVacancies()
        {
            var searchViewModel = new ApprenticeshipSearchViewModel
            {
                Location = ACityWithOneSuggestedLocation
            };

            ApprenticeshipVacancyProvider.Setup(sp => sp.FindVacancies(It.IsAny<ApprenticeshipSearchViewModel>()))
                .Returns(new ApprenticeshipSearchResponseViewModel
                {
                    ViewModelMessage = SomeErrorMessage
                });

            var response = Mediator.Results(null, searchViewModel);

            response.AssertMessage(ApprenticeshipSearchMediatorCodes.Results.HasError, SomeErrorMessage,
                UserMessageLevel.Warning, true);
        }

        [Test]
        public void ExactMatchFoundUsingVacancyReference()
        {
            var searchViewModel = new ApprenticeshipSearchViewModel
            {
                Keywords = "VAC000123456"
            };

            ApprenticeshipVacancyProvider.Setup(sp => sp.FindVacancies(It.IsAny<ApprenticeshipSearchViewModel>()))
                .Returns(new ApprenticeshipSearchResponseViewModel
                {
                    ExactMatchFound = true,
                    VacancySearch = searchViewModel,
                    Vacancies = new List<ApprenticeshipVacancySummaryViewModel>
                    {
                        new ApprenticeshipVacancySummaryViewModel
                        {
                            Id = 123456
                        }
                    }
                });

            var response = Mediator.Results(null, searchViewModel);

            response.AssertCode(ApprenticeshipSearchMediatorCodes.Results.ExactMatchFound, false, true);
        }

        [Test]
        public void IfTheLocationIsNationalAndThereAreKeywords_SortTypeShouldBeBestMatch()
        {
            var searchViewModel = new ApprenticeshipSearchViewModel
            {
                Keywords = "Blah",
                Location = ACityWithOneSuggestedLocation,
                LocationType = ApprenticeshipLocationType.National,
                SortType = VacancySearchSortType.Distance,
                SearchAction = SearchAction.LocationTypeChanged
            };

            var response = Mediator.Results(null, searchViewModel);

            response.AssertCode(ApprenticeshipSearchMediatorCodes.Results.Ok, true);

            response.ViewModel.VacancySearch.SortType.Should().Be(VacancySearchSortType.Relevancy);
        }

        [Test]
        public void IfTheLocationIsNationalAndThereAreNoKeywords_SortTypeShouldBeClosingDate()
        {
            var searchViewModel = new ApprenticeshipSearchViewModel
            {
                Location = ACityWithOneSuggestedLocation,
                LocationType = ApprenticeshipLocationType.National,
                SortType = VacancySearchSortType.Distance,
                SearchAction = SearchAction.LocationTypeChanged
            };

            var response = Mediator.Results(null, searchViewModel);

            response.AssertCode(ApprenticeshipSearchMediatorCodes.Results.Ok, true);

            response.ViewModel.VacancySearch.SortType.Should().Be(VacancySearchSortType.ClosingDate);
        }

        [Test]
        public void IfTotalLocalHitsIsGreaterThanZero_LocationTypeIsNonNational()
        {
            var searchViewModel = new ApprenticeshipSearchViewModel
            {
                Location = ACityWithOneSuggestedLocation
            };

            ApprenticeshipVacancyProvider.Setup(sp => sp.FindVacancies(searchViewModel))
                .Returns(new ApprenticeshipSearchResponseViewModel
                {
                    TotalLocalHits = 1,
                    VacancySearch = searchViewModel
                });

            var response = Mediator.Results(null, searchViewModel);

            response.AssertCode(ApprenticeshipSearchMediatorCodes.Results.Ok, true);
            response.ViewModel.VacancySearch.LocationType = ApprenticeshipLocationType.NonNational;
        }

        [Test]
        public void KeywordSortTypes()
        {
            var searchViewModel = new ApprenticeshipSearchViewModel
            {
                Location = ACityWithOneSuggestedLocation,
                Keywords = "Sales"
            };

            var response = Mediator.Results(null, searchViewModel);

            response.AssertCode(ApprenticeshipSearchMediatorCodes.Results.Ok, true);

            var viewModel = response.ViewModel;
            var sortTypes = viewModel.SortTypes.ToList();
            sortTypes.Count.Should().Be(4);
            sortTypes.Should().Contain(sli => sli.Value == VacancySearchSortType.Relevancy.ToString());
            sortTypes.Should().Contain(sli => sli.Value == VacancySearchSortType.ClosingDate.ToString());
            sortTypes.Should().Contain(sli => sli.Value == VacancySearchSortType.Distance.ToString());
            sortTypes.Should().Contain(sli => sli.Value == VacancySearchSortType.RecentlyAdded.ToString());
        }

        [Test]
        public void LocationOk()
        {
            var searchViewModel = new ApprenticeshipSearchViewModel
            {
                Location = ACityWithOneSuggestedLocation
            };

            var response = Mediator.Results(null, searchViewModel);

            response.AssertCode(ApprenticeshipSearchMediatorCodes.Results.Ok, true);

            var viewModel = response.ViewModel;
            viewModel.Vacancies.Should().NotBeNullOrEmpty();
            var vacancies = viewModel.Vacancies.ToList();
            vacancies.Count.Should().Be(1);
            viewModel.ApprenticeshipLevels.Should().NotBeNull();
            viewModel.VacancySearch.ApprenticeshipLevel.Should().Be("All");
        }

        [Test]
        public void LocationResultIsNotValid()
        {
            var searchViewModel = new ApprenticeshipSearchViewModel
            {
                Location = ACityWithoutSuggestedLocations
            };

            SearchProvider.Setup(sp => sp.FindLocation(ACityWithoutSuggestedLocations))
                .Returns(() => new LocationsViewModel());

            var response = Mediator.Results(null, searchViewModel);

            response.AssertCode(ApprenticeshipSearchMediatorCodes.Results.Ok, true);
            response.ViewModel.VacancySearch.Should().Be(searchViewModel);
        }

        [Test]
        public void LocationSortTypes()
        {
            var searchViewModel = new ApprenticeshipSearchViewModel
            {
                Location = ACityWithOneSuggestedLocation
            };

            var response = Mediator.Results(null, searchViewModel);

            response.AssertCode(ApprenticeshipSearchMediatorCodes.Results.Ok, true);

            var viewModel = response.ViewModel;
            var sortTypes = viewModel.SortTypes.ToList();
            sortTypes.Count.Should().Be(3);
            sortTypes.Should().Contain(sli => sli.Value == VacancySearchSortType.ClosingDate.ToString());
            sortTypes.Should().Contain(sli => sli.Value == VacancySearchSortType.Distance.ToString());
            sortTypes.Should().Contain(sli => sli.Value == VacancySearchSortType.RecentlyAdded.ToString());
        }

        [Test]
        public void LocationTypeShouldBeCopiedOver()
        {
            ApprenticeshipVacancyProvider.Setup(sp => sp.FindVacancies(It.IsAny<ApprenticeshipSearchViewModel>()))
                .Callback<ApprenticeshipSearchViewModel>(svm =>
                {
                    svm.LocationType = ApprenticeshipLocationType.National;
                    _searchSentToSearchProvider = svm;
                })
                .Returns<ApprenticeshipSearchViewModel>(
                    svm =>
                        new ApprenticeshipSearchResponseViewModel
                        {
                            Vacancies = new ApprenticeshipVacancySummaryViewModel[0],
                            VacancySearch = svm
                        });

            var searchViewModel = new ApprenticeshipSearchViewModel
            {
                Keywords = AKeyword,
                Location = ACityWithOneSuggestedLocation,
                LocationType = ApprenticeshipLocationType.NonNational,
                Category = "1",
                SearchMode = ApprenticeshipSearchMode.Category
            };

            var response = Mediator.Results(null, searchViewModel);

            response.AssertCode(ApprenticeshipSearchMediatorCodes.Results.Ok, true);

            response.ViewModel.VacancySearch.LocationType.Should().Be(ApprenticeshipLocationType.National);
        }

        [Test]
        public void NewSearchWithKeywords()
        {
            var searchViewModel = new ApprenticeshipSearchViewModel
            {
                Location = ACityWithOneSuggestedLocation,
                LocationType = ApprenticeshipLocationType.NonNational,
                SortType = VacancySearchSortType.Distance,
                SearchAction = SearchAction.Search,
                Keywords = AKeyword
            };

            var response = Mediator.Results(null, searchViewModel);

            response.AssertCode(ApprenticeshipSearchMediatorCodes.Results.Ok, true);

            response.ViewModel.VacancySearch.SortType.Should().Be(VacancySearchSortType.Relevancy);
        }

        [Test]
        public void NoResults()
        {
            var searchViewModel = new ApprenticeshipSearchViewModel
            {
                Location = "Middle of Nowhere"
            };

            var response = Mediator.Results(null, searchViewModel);

            response.AssertCode(ApprenticeshipSearchMediatorCodes.Results.Ok, true);

            var viewModel = response.ViewModel;
            viewModel.Vacancies.Should().NotBeNull();
            var vacancies = viewModel.Vacancies.ToList();
            vacancies.Count.Should().Be(0);
        }

        [Test]
        public void NoSearchParameters()
        {
            var searchViewModel = new ApprenticeshipSearchViewModel
            {
                Location = string.Empty
            };

            var response = Mediator.Results(null, searchViewModel);

            response.AssertValidationResult(ApprenticeshipSearchMediatorCodes.Results.ValidationError, true);
        }

        [Test]
        public void RecentlyAddedSortOption()
        {
            var searchViewModel = new ApprenticeshipSearchViewModel
            {
                Location = ACityWithOneSuggestedLocation
            };

            var response = Mediator.Results(null, searchViewModel);


            var viewModel = response.ViewModel;
            viewModel.SortTypes.Last().Text.Should().Be("Recently added");
            viewModel.SortTypes.Last().Value.Should().Be(VacancySearchSortType.RecentlyAdded.ToString());
        }

        [Test]
        public void SaveLocationSearchToCookie()
        {
            var searchViewModel = new ApprenticeshipSearchViewModel
            {
                Location = ACityWithOneSuggestedLocation
            };

            UserDataProvider.Setup(x => x.Push(It.IsAny<string>(), It.IsAny<string>()));
            Mediator.Results(null, searchViewModel);
            UserDataProvider.Verify(
                x => x.Push(UserDataItemNames.LastSearchedLocation, ACityWithOneSuggestedLocation + "|0|0"), Times.Once);
        }

        [Test]
        public void ShouldReturnAListOfSuggestedLocations()
        {
            const int numberOfSuggestedLocations = 4;
            var searchViewModel = new ApprenticeshipSearchViewModel
            {
                Location = ACityWithMoreThanOneSuggestedLocation
            };

            SearchProvider.Setup(sp => sp.FindLocation(ACityWithMoreThanOneSuggestedLocation))
                .Returns(
                    () =>
                        new LocationsViewModel(
                            Enumerable.Range(1, numberOfSuggestedLocations + 1)
                                .Select(e => new LocationViewModel {Name = Convert.ToString(e)})));

            var response = Mediator.Results(null, searchViewModel);

            response.AssertCode(ApprenticeshipSearchMediatorCodes.Results.Ok, true);
            response.ViewModel.LocationSearches.Should().HaveCount(numberOfSuggestedLocations);
        }

        [Test]
        public void ShouldShowAMessageIfAnErrorOccursWhileFindingSuggestedLocations()
        {
            var searchViewModel = new ApprenticeshipSearchViewModel
            {
                Location = ACityWithMoreThanOneSuggestedLocation
            };

            SearchProvider.Setup(sp => sp.FindLocation(ACityWithMoreThanOneSuggestedLocation))
                .Returns(() => new LocationsViewModel {ViewModelMessage = SomeErrorMessage});

            var response = Mediator.Results(null, searchViewModel);

            response.AssertMessage(ApprenticeshipSearchMediatorCodes.Results.HasError, SomeErrorMessage,
                UserMessageLevel.Warning, true);
        }

        [Test]
        public void SortWithKeywords()
        {
            const VacancySearchSortType originalSortType = VacancySearchSortType.Distance;

            var searchViewModel = new ApprenticeshipSearchViewModel
            {
                Location = ACityWithOneSuggestedLocation,
                LocationType = ApprenticeshipLocationType.NonNational,
                SortType = originalSortType,
                SearchAction = SearchAction.Sort,
                Keywords = AKeyword
            };

            var response = Mediator.Results(null, searchViewModel);

            response.AssertCode(ApprenticeshipSearchMediatorCodes.Results.Ok, true);

            response.ViewModel.VacancySearch.SortType.Should().Be(originalSortType);
        }

        [Test]
        public void SubcategoriesAreNormalizedToNewFormat()
        {
            const string oldFormattedSubcategoryCode = "490";
            const string expectedSubcategoryCode = "FW.490";

            var searchViewModel = new ApprenticeshipSearchViewModel
            {
                SubCategories = new[] {oldFormattedSubcategoryCode}
            };

            var response = Mediator.Results(null, searchViewModel);

            response.ViewModel.VacancySearch.SubCategories.ShouldBeEquivalentTo(new[] {expectedSubcategoryCode});
        }

        [Test]
        public void TestCategorySearchModification()
        {
            const string selectedCategoryCode = "SSAT1.2";
            const string selectedCategorySubCategory = "FW.2_2";

            ReferenceDataService.Setup(rds => rds.GetCategories()).Returns(new List<Category>
            {
                new Category(1, "SSAT1.1", "1", CategoryType.SectorSubjectAreaTier1, CategoryStatus.Active, new List<Category>
                {
                    new Category(1, "FW.1_1", "1_1", CategoryType.Framework, CategoryStatus.Active),
                    new Category(2, "FW.1_2", "1_2", CategoryType.Framework, CategoryStatus.Active)
                }
                    ),
                new Category(2, selectedCategoryCode, selectedCategoryCode, CategoryType.SectorSubjectAreaTier1, CategoryStatus.Active,
                    new List<Category>
                    {
                        new Category(1, "FW.2_1", "2_1", CategoryType.Framework, CategoryStatus.Active),
                        new Category(2, selectedCategorySubCategory, selectedCategorySubCategory, CategoryType.Framework, CategoryStatus.Active)
                    }
                    )
            });

            var searchViewModel = new ApprenticeshipSearchViewModel
            {
                Keywords = AKeyword,
                Location = ACityWithOneSuggestedLocation,
                LocationType = ApprenticeshipLocationType.NonNational,
                Category = selectedCategoryCode,
                //Select Sub Categories from a different category than the one selected plus a valid one
                SubCategories = new[]
                {
                    "FW.1_1",
                    "FW.1_2",
                    selectedCategorySubCategory
                },
                SearchMode = ApprenticeshipSearchMode.Category
            };

            var response = Mediator.Results(null, searchViewModel);

            response.AssertCode(ApprenticeshipSearchMediatorCodes.Results.Ok, true);

            //The search sent to the search provider should have been modified based on the search mode
            _searchSentToSearchProvider.Should().NotBeNull();
            _searchSentToSearchProvider.Keywords.Should().BeNullOrEmpty();
            _searchSentToSearchProvider.Location.Should().Be(ACityWithOneSuggestedLocation);
            _searchSentToSearchProvider.LocationType.Should().Be(ApprenticeshipLocationType.NonNational);
            _searchSentToSearchProvider.Categories.Should().NotBeNull();
            _searchSentToSearchProvider.Categories.Count.Should().Be(2);
            _searchSentToSearchProvider.Category.Should().Be(selectedCategoryCode);
            _searchSentToSearchProvider.SubCategories.Length.Should().Be(1);
            _searchSentToSearchProvider.SubCategories[0].Should().Be(selectedCategorySubCategory);
            _searchSentToSearchProvider.SearchMode.Should().Be(ApprenticeshipSearchMode.Category);

            //But the returned search should be the original search the user submitted so as not to lose any of their changes
            var returnedSearch = response.ViewModel.VacancySearch;
            returnedSearch.Should().NotBeNull();
            returnedSearch.Keywords.Should().Be(AKeyword);
            returnedSearch.Location.Should().Be(ACityWithOneSuggestedLocation);
            returnedSearch.LocationType.Should().Be(ApprenticeshipLocationType.NonNational);
            returnedSearch.Categories.Should().NotBeNull();
            returnedSearch.Categories.Count.Should().Be(2);
            returnedSearch.Category.Should().Be(selectedCategoryCode);
            returnedSearch.SubCategories.Length.Should().Be(1);
            returnedSearch.SubCategories[0].Should().Be(selectedCategorySubCategory);
            returnedSearch.SearchMode.Should().Be(ApprenticeshipSearchMode.Category);
        }

        [Test]
        public void TestKeywordSearchModification()
        {
            const string selectedCategoryCode = "SSAT1.2";
            const string selectedCategorySubCategory = "FW.2_2";

            ReferenceDataService.Setup(rds => rds.GetCategories()).Returns(new List<Category>
            {
                new Category(1, "SSAT1.1", "1", CategoryType.SectorSubjectAreaTier1, CategoryStatus.Active, new List<Category>
                {
                    new Category(1, "FW.1_1", "1_1", CategoryType.Framework, CategoryStatus.Active),
                    new Category(2, "FW.1_2", "1_2", CategoryType.Framework, CategoryStatus.Active)
                }
                    ),
                new Category(2, selectedCategoryCode, selectedCategoryCode, CategoryType.SectorSubjectAreaTier1, CategoryStatus.Active,
                    new List<Category>
                    {
                        new Category(1, "FW.2_1", "2_1", CategoryType.Framework, CategoryStatus.Active),
                        new Category(2, selectedCategorySubCategory, selectedCategorySubCategory, CategoryType.Framework, CategoryStatus.Active)
                    }
                    )
            });

            var searchViewModel = new ApprenticeshipSearchViewModel
            {
                Keywords = AKeyword,
                Location = ACityWithOneSuggestedLocation,
                LocationType = ApprenticeshipLocationType.NonNational,
                Category = selectedCategoryCode,
                //Select Sub Categories from a different category than the one selected plus a valid one
                SubCategories = new[]
                {
                    "1_1",
                    "1_2",
                    selectedCategorySubCategory
                },
                SearchMode = ApprenticeshipSearchMode.Keyword
            };

            var response = Mediator.Results(null, searchViewModel);

            response.AssertCode(ApprenticeshipSearchMediatorCodes.Results.Ok, true);

            //The search sent to the search provider should have been modified based on the search mode
            _searchSentToSearchProvider.Should().NotBeNull();
            _searchSentToSearchProvider.Keywords.Should().Be(AKeyword);
            _searchSentToSearchProvider.Location.Should().Be(ACityWithOneSuggestedLocation);
            _searchSentToSearchProvider.LocationType.Should().Be(ApprenticeshipLocationType.NonNational);
            _searchSentToSearchProvider.Categories.Should().BeNull();
            _searchSentToSearchProvider.Category.Should().BeNullOrEmpty();
            _searchSentToSearchProvider.SubCategories.Should().BeNull();
            _searchSentToSearchProvider.SearchMode.Should().Be(ApprenticeshipSearchMode.Keyword);

            //But the returned search should be the original search the user submitted so as not to lose any of their changes
            var returnedSearch = response.ViewModel.VacancySearch;
            returnedSearch.Should().NotBeNull();
            returnedSearch.Keywords.Should().Be(AKeyword);
            returnedSearch.Location.Should().Be(ACityWithOneSuggestedLocation);
            returnedSearch.LocationType.Should().Be(ApprenticeshipLocationType.NonNational);
            returnedSearch.Categories.Should().NotBeNull();
            returnedSearch.Categories.Count.Should().Be(2);
            returnedSearch.Category.Should().Be(selectedCategoryCode);
            returnedSearch.SubCategories.Length.Should().Be(1);
            returnedSearch.SubCategories[0].Should().Be(selectedCategorySubCategory);
            returnedSearch.SearchMode.Should().Be(ApprenticeshipSearchMode.Keyword);
        }
    }
}