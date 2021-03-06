﻿namespace SFA.Apprenticeships.Application.Interfaces.Locations
{
    using Domain.Entities.Locations;
    using Generic;

    public interface IAddressSearchService
    {
        Pageable<Address> GetAddressesFor(string fullPostcode, int currentPage, int pageSize);
    }
}