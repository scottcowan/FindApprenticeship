﻿namespace SFA.Apprenticeships.Domain.Raa.Interfaces.Repositories
{
    using System.Collections.Generic;
    using Entities.Raa.Parties;
    using Models;

    public interface IProviderReadRepository
    {
        Provider GetById(int providerId);
        Provider GetByUkprn(string ukprn, bool errorIfNotFound = true);
        IEnumerable<Provider> GetByIds(IEnumerable<int> providerIds);
        IEnumerable<Provider> Search(ProviderSearchParameters searchParameters);
    }

    public interface IProviderWriteRepository
    {
        Provider Create(Provider provider);
        Provider Update(Provider provider);
    }
}
