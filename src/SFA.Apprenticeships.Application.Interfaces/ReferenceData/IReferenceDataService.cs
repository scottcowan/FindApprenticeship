﻿namespace SFA.Apprenticeships.Application.Interfaces.ReferenceData
{
    using Domain.Entities.Raa.Reference;
    using Domain.Entities.Raa.Vacancies;
    using Domain.Entities.ReferenceData;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IReferenceDataService
    {
        IEnumerable<Category> GetCategories();

        Category GetSubCategoryByName(string subCategoryName);

        Category GetCategoryByName(string categoryName);

        Category GetSubCategoryByCode(string subCategoryCode);

        Category GetCategoryByCode(string categoryCode);

        Task<IEnumerable<Category>> GetFrameworks();

        Task<IEnumerable<StandardSubjectAreaTierOne>> GetStandardSubjectAreaTierOnes();

        IEnumerable<Sector> GetSectors();

        IList<ReleaseNote> GetReleaseNotes(DasApplication dasApplication);

        Task<IEnumerable<County>> GetCounties();

        Task<County> GetCountyById(int countyId);

        Task<County> GetCountyByCode(string countyCode);

        Task<County> GetCountyByName(string countyName);

        Task<IEnumerable<LocalAuthority>> GetLocalAuthorities();

        Task<LocalAuthority> GetLocalAuthorityById(int localAuthorityId);

        Task<LocalAuthority> GetLocalAuthorityByCode(string localAuthorityCode);

        Task<IEnumerable<Region>> GetRegions();

        Task<Region> GetRegionById(int regionId);

        Task<Region> GetRegionByCode(string regionCode);
    }
}
