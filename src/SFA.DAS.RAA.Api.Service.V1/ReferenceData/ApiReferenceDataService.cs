namespace SFA.DAS.RAA.Api.Service.V1.ReferenceData
{
    using System.Collections.Generic;
    using Apprenticeships.Domain.Entities.Raa.Reference;
    using Apprenticeships.Domain.Entities.Raa.Vacancies;
    using Apprenticeships.Domain.Entities.ReferenceData;
    using Apprenticeships.Application.Interfaces.ReferenceData;

    public class ApiReferenceDataService : IReferenceDataService
    {
        public IEnumerable<Category> GetCategories()
        {
            throw new System.NotImplementedException();
        }

        public Category GetSubCategoryByName(string subCategoryName)
        {
            throw new System.NotImplementedException();
        }

        public Category GetCategoryByName(string categoryName)
        {
            throw new System.NotImplementedException();
        }

        public Category GetSubCategoryByCode(string subCategoryCode)
        {
            throw new System.NotImplementedException();
        }

        public Category GetCategoryByCode(string categoryCode)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Category> GetFrameworks()
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Sector> GetSectors()
        {
            throw new System.NotImplementedException();
        }

        public IList<ReleaseNote> GetReleaseNotes(DasApplication dasApplication)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<County> GetCounties()
        {
            throw new System.NotImplementedException();
        }

        public County GetCountyById(int countyId)
        {
            throw new System.NotImplementedException();
        }

        public County GetCountyByCode(string countyCode)
        {
            throw new System.NotImplementedException();
        }

        public County GetCountyByName(string countyName)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<LocalAuthority> GetLocalAuthorities()
        {
            throw new System.NotImplementedException();
        }

        public LocalAuthority GetLocalAuthorityById(int localAuthorityId)
        {
            throw new System.NotImplementedException();
        }

        public LocalAuthority GetLocalAuthorityByCode(string localAuthorityCode)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Region> GetRegions()
        {
            throw new System.NotImplementedException();
        }

        public Region GetRegionById(int regionId)
        {
            throw new System.NotImplementedException();
        }

        public Region GetRegionByCode(string regionCode)
        {
            throw new System.NotImplementedException();
        }
    }
}