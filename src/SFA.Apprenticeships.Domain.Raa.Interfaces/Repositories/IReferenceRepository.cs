namespace SFA.Apprenticeships.Domain.Raa.Interfaces.Repositories
{
    using Entities.Raa.Reference;
    using Entities.Raa.Vacancies;
    using Entities.ReferenceData;
    using System.Collections.Generic;
    using Occupation = Entities.Raa.Reference.Occupation;

    public interface IReferenceRepository
    {
        IList<Framework> GetFrameworks();

        IEnumerable<Occupation> GetOccupations();

        IList<Standard> GetStandards();

        IList<Sector> GetSectors();

        IList<ReleaseNote> GetReleaseNotes();

        IList<StandardSubjectAreaTierOne> GetStandardSubjectAreaTierOnes();

        IEnumerable<County> GetCounties();

        County GetCountyById(int countyId);

        County GetCountyByCode(string countyCode);

        County GetCountyByName(string countyName);

        IEnumerable<LocalAuthority> GetLocalAuthorities();

        LocalAuthority GetLocalAuthorityById(int localAuthorityId);

        LocalAuthority GetLocalAuthorityByCode(string localAuthorityCode);

        IEnumerable<Region> GetRegions();

        Region GetRegionById(int regionId);

        Region GetRegionByCode(string regionCode);

        void UpdateStandard(Standard standard);

        void UpdateFramework(Category category);

        Category InsertFramework(Category entity);

        Category GetFrameworkById(int categoryId);

        Standard InsertStandard(Standard standard);

        void UpdateSector(Sector sector);

        Sector InsertSector(Sector sector);

        StandardSubjectAreaTierOne GetStandardSubjectAreaTierOneById(int standardId);
    }
}