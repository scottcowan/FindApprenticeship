namespace SFA.Apprenticeships.Application.ReferenceData
{
    using Domain.Entities.Raa.Reference;
    using Domain.Entities.Raa.Vacancies;
    using Domain.Entities.ReferenceData;
    using Interfaces.ReferenceData;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class ReferenceDataService : IReferenceDataService
    {
        private readonly IReferenceDataProvider _referenceDataProvider;

        public ReferenceDataService(IReferenceDataProvider referenceDataProvider)
        {
            _referenceDataProvider = referenceDataProvider;
        }

        public IEnumerable<Category> GetCategories()
        {
            return _referenceDataProvider.GetCategories();
        }

        public Category GetSubCategoryByName(string subCategoryName)
        {
            return _referenceDataProvider.GetSubCategoryByName(subCategoryName);
        }

        public Category GetCategoryByName(string categoryName)
        {
            return _referenceDataProvider.GetCategoryByName(categoryName);
        }

        public Category GetSubCategoryByCode(string subCategoryCode)
        {
            return _referenceDataProvider.GetSubCategoryByCode(subCategoryCode);
        }

        public Category GetCategoryByCode(string categoryCode)
        {
            return _referenceDataProvider.GetCategoryByCode(categoryCode);
        }

        public Task<IEnumerable<Category>> GetFrameworks()
        {
            return Task.FromResult(_referenceDataProvider.GetFrameworks());
        }

        public Task<IEnumerable<StandardSubjectAreaTierOne>> GetStandardSubjectAreaTierOnes()
        {
            return Task.FromResult(_referenceDataProvider.GetStandardSubjectAreaTierOnes());
        }

        public IEnumerable<Sector> GetSectors()
        {
            return _referenceDataProvider.GetSectors();
        }

        public IList<ReleaseNote> GetReleaseNotes(DasApplication dasApplication)
        {
            return _referenceDataProvider.GetReleaseNotes(dasApplication);
        }

        public Task<IEnumerable<County>> GetCounties()
        {
            return Task.FromResult(_referenceDataProvider.GetCounties());
        }

        public Task<County> GetCountyById(int countyId)
        {
            return Task.FromResult(_referenceDataProvider.GetCountyById(countyId));
        }

        public Task<County> GetCountyByCode(string countyCode)
        {
            return Task.FromResult(_referenceDataProvider.GetCountyByCode(countyCode));
        }

        public Task<County> GetCountyByName(string countyName)
        {
            return Task.FromResult(_referenceDataProvider.GetCountyByName(countyName));
        }

        public Task<IEnumerable<LocalAuthority>> GetLocalAuthorities()
        {
            return Task.FromResult(_referenceDataProvider.GetLocalAuthorities());
        }

        public Task<LocalAuthority> GetLocalAuthorityById(int localAuthorityId)
        {
            return Task.FromResult(_referenceDataProvider.GetLocalAuthorityById(localAuthorityId));
        }

        public Task<LocalAuthority> GetLocalAuthorityByCode(string localAuthorityCodeName)
        {
            return Task.FromResult(_referenceDataProvider.GetLocalAuthorityByCode(localAuthorityCodeName));
        }

        public Task<IEnumerable<Region>> GetRegions()
        {
            return Task.FromResult(_referenceDataProvider.GetRegions());
        }

        public Task<Region> GetRegionById(int regionId)
        {
            return Task.FromResult(_referenceDataProvider.GetRegionById(regionId));
        }

        public Task<Region> GetRegionByCode(string regionCode)
        {
            return Task.FromResult(_referenceDataProvider.GetRegionByCode(regionCode));
        }
    }
}
