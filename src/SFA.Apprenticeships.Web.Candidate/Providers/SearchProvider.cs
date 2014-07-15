﻿namespace SFA.Apprenticeships.Web.Candidate.Providers
{
    using System;
    using System.Collections.Generic;
    using Application.Interfaces.Locations;
    using Application.Interfaces.Search;
    using Application.Interfaces.Vacancies;
    using Domain.Entities.Locations;
    using Domain.Interfaces.Mapping;
    using ViewModels.Locations;
    using ViewModels.VacancySearch;

    public class SearchProvider : ISearchProvider
    {
        private readonly ILocationSearchService _locationSearchService;
        private readonly IVacancySearchService _vacancySearchService;
        private readonly IAddressSearchService _addressSearchService;
        private readonly IMapper _mapper;

        public SearchProvider(ILocationSearchService locationSearchService, 
            IVacancySearchService vacancySearchService,
            IAddressSearchService addressSearchService,
            IMapper mapper)
        {
            _locationSearchService = locationSearchService;
            _vacancySearchService = vacancySearchService;
            _addressSearchService = addressSearchService;
            _mapper = mapper;
        }

        public IEnumerable<LocationViewModel> FindLocation(string placeNameOrPostcode)
        {
            var locations = _locationSearchService.FindLocation(placeNameOrPostcode);

            if (locations != null)
            {
                return _mapper.Map<IEnumerable<Location>, IEnumerable<LocationViewModel>>(locations);
            }

            return new LocationViewModel[] {};
        }

        public VacancySearchResponseViewModel FindVacancies(VacancySearchViewModel search, int pageSize)
        {
            var searchLocation = _mapper.Map<VacancySearchViewModel, Location>(search);

            var searchResponse = _vacancySearchService.Search(search.Keywords, searchLocation, search.PageNumber,
                pageSize, search.WithinDistance, search.SortType);

            var vacancySearchResponseViewModel =
                _mapper.Map<SearchResults<VacancySummaryResponse>, VacancySearchResponseViewModel>(searchResponse);
            vacancySearchResponseViewModel.PageSize = pageSize;
            vacancySearchResponseViewModel.VacancySearch = search;

            return vacancySearchResponseViewModel;
        }

        public IEnumerable<AddressViewModel> FindAddresses(string postcode)
        {
            var addresses = _addressSearchService.FindAddress(postcode);
            return addresses != null ? _mapper.Map<IEnumerable<Address>, IEnumerable<AddressViewModel>>(addresses) : new AddressViewModel[] { };
        }
    }
}
