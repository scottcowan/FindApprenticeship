namespace SFA.Apprenticeships.Infrastructure.Repositories.Sql.Schemas.Reference
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Domain.Entities.Raa.Reference;
    using Common;
    using Domain.Entities.Raa.Vacancies;
    using Domain.Raa.Interfaces.Repositories;
    using Entities;
    using Application.Interfaces;
    using Domain.Entities.ReferenceData;
    using County = Domain.Entities.Raa.Reference.County;
    using LocalAuthority = Domain.Entities.Raa.Reference.LocalAuthority;
    using Region = Domain.Entities.Raa.Reference.Region;
    using Standard = Domain.Entities.Raa.Vacancies.Standard;

    public class ReferenceRepository : IReferenceRepository
    {
        public const string GetCountiesSql = "SELECT * FROM dbo.County ORDER BY FullName";
        public const string GetCountyByIdSql = "SELECT * FROM dbo.County WHERE CountyId = @CountyId";
        public const string GetCountyByCodeSql = "SELECT * FROM dbo.County WHERE CodeName = @CountyCode";

        public const string GetLocalAuthoritiesSql = "SELECT la.*, c.CodeName, c.ShortName, c.FullName, lag.LocalAuthorityGroupID AS RegionId, lag.CodeName, lag.ShortName, lag.FullName FROM dbo.LocalAuthority la LEFT JOIN dbo.County c ON la.CountyId = c.CountyId LEFT JOIN dbo.LocalAuthorityGroupMembership lagm ON la.LocalAuthorityId = lagm.LocalAuthorityID JOIN dbo.LocalAuthorityGroup lag ON lagm.LocalAuthorityGroupID = lag.LocalAuthorityGroupID WHERE lag.LocalAuthorityGroupTypeID = 4";
        public const string GetLocalAuthorityByIdSql = "SELECT la.*, c.CodeName, c.ShortName, c.FullName, lag.LocalAuthorityGroupID AS RegionId, lag.CodeName, lag.ShortName, lag.FullName FROM dbo.LocalAuthority la LEFT JOIN dbo.County c ON la.CountyId = c.CountyId LEFT JOIN dbo.LocalAuthorityGroupMembership lagm ON la.LocalAuthorityId = lagm.LocalAuthorityID JOIN dbo.LocalAuthorityGroup lag ON lagm.LocalAuthorityGroupID = lag.LocalAuthorityGroupID WHERE lag.LocalAuthorityGroupTypeID = 4 AND la.LocalAuthorityId = @LocalAuthorityId";
        public const string GetLocalAuthorityByCodeSql = "SELECT la.*, c.CodeName, c.ShortName, c.FullName, lag.LocalAuthorityGroupID AS RegionId, lag.CodeName, lag.ShortName, lag.FullName FROM dbo.LocalAuthority la LEFT JOIN dbo.County c ON la.CountyId = c.CountyId LEFT JOIN dbo.LocalAuthorityGroupMembership lagm ON la.LocalAuthorityId = lagm.LocalAuthorityID JOIN dbo.LocalAuthorityGroup lag ON lagm.LocalAuthorityGroupID = lag.LocalAuthorityGroupID WHERE lag.LocalAuthorityGroupTypeID = 4 AND la.CodeName = @LocalAuthorityCode";

        public const string GetRegionsSql = "SELECT LocalAuthorityGroupID AS RegionId, CodeName, ShortName, FullName FROM[dbo].[LocalAuthorityGroup] WHERE LocalAuthorityGroupTypeID = 4";
        public const string GetRegionByIdSql = "SELECT LocalAuthorityGroupID AS RegionId, CodeName, ShortName, FullName FROM[dbo].[LocalAuthorityGroup] WHERE LocalAuthorityGroupTypeID = 4 AND LocalAuthorityGroupID = @RegionId";
        public const string GetRegionByCodeSql = "SELECT LocalAuthorityGroupID AS RegionId, CodeName, ShortName, FullName FROM[dbo].[LocalAuthorityGroup] WHERE LocalAuthorityGroupTypeID = 4 AND CodeName = @RegionCode";

        private readonly IGetOpenConnection _getOpenConnection;
        private readonly IMapper _mapper;
        private readonly ILogService _logger;

        public ReferenceRepository(IGetOpenConnection getOpenConnection, IMapper mapper, ILogService logger)
        {
            _getOpenConnection = getOpenConnection;
            _mapper = mapper;
            _logger = logger;
        }
        public IList<Framework> GetFrameworks()
        {
            var dbFrameworks = GetApprenticeshipFrameworks();
            var frameworks = dbFrameworks.Select(_mapper.Map<ApprenticeshipFramework, Framework>).ToList();
            return frameworks;
        }

        public IList<Occupation> GetOccupations()
        {
            var dbOccupations = GetApprenticeshipOccupations();
            var dbFrameworks = GetApprenticeshipFrameworks();

            var occupations = dbOccupations.Select(
                x =>
                {
                    return new Occupation
                    {
                        CodeName = x.CodeName,
                        Id = x.ApprenticeshipOccupationId,
                        FullName = x.FullName,
                        ShortName = x.ShortName,
                        Status = (OccupationStatusType)x.ApprenticeshipOccupationStatusTypeId,
                        Frameworks =
                            dbFrameworks.Where(af => af.ApprenticeshipOccupationId == x.ApprenticeshipOccupationId)
                                .Select(_mapper.Map<ApprenticeshipFramework, Framework>).ToList()
                    };
                }).ToList();

            foreach (var occupation in occupations)
            {
                foreach (var framework in occupation.Frameworks)
                {
                    framework.ParentCategoryCodeName = occupation.CodeName;
                }
            }

            _logger.Debug("Got all apprenticeship occupations");

            return occupations;
        }

        public IList<Standard> GetStandards()
        {
            _logger.Debug("Getting all standards");

            const string standardSql = "SELECT * FROM Reference.Standard ORDER BY FullName;";

            //TODO: Does this need to be here? If not, test and remove.
            var sqlParams = new
            {
            };

            var educationLevels = GetEducationLevels();
            
            var dbStandards = _getOpenConnection.Query<Entities.Standard>(standardSql, sqlParams);
            var standards = dbStandards.Select(x =>
            {
                var level = educationLevels.FirstOrDefault(el => el.EducationLevelId == x.EducationLevelId);
                var levelAsInt = int.Parse(level.CodeName);
                var std = new Standard()
                {
                    ApprenticeshipLevel = (ApprenticeshipLevel)levelAsInt,
                    Id = x.StandardId,
                    Name = x.FullName,
                    ApprenticeshipSectorId = x.StandardSectorId,
                    Status = (FrameworkStatusType)x.ApprenticeshipFrameworkStatusTypeId,
                    LarsCode = x.LarsCode
                };
                return std;
            }).ToList();

            return standards;
        }

        public IList<Sector> GetSectors()
        {
            _logger.Debug("Getting all sectors");

            const string sectorSql = "SELECT * FROM Reference.StandardSector ORDER BY FullName;";

            var sqlParams = new
            {
            };

            var dbSectors = _getOpenConnection
                .Query<StandardSector>(sectorSql, sqlParams);

            //set the standards.
            var standards = GetStandards();

            var sectors = dbSectors.Select(x =>
            {
                var result = _mapper.Map<StandardSector, Sector>(x);
                result.Standards = standards.Where(std => std.ApprenticeshipSectorId == x.StandardSectorId);
                return result;
            }).ToList();

            _logger.Debug("Got all sectors");

            return sectors ;
        }

        public IList<ReleaseNote> GetReleaseNotes()
        {
            _logger.Debug("Getting all release notes");

            var releaseNotes = _getOpenConnection.Query<ReleaseNote>("SELECT * FROM Reference.ReleaseNote ORDER BY Version");

            _logger.Debug($"Got {releaseNotes.Count} release notes");

            return releaseNotes;
        }

        public IList<StandardSubjectAreaTierOne> GetStandardSubjectAreaTierOnes()
        {
            _logger.Debug("Getting all SSAT1s");

            const string sectorSql = "SELECT * FROM dbo.ApprenticeshipOccupation;";

            var sqlParams = new
            {
            };

            var dbStandardSubjectAreaTierOnes = _getOpenConnection
                .Query<ApprenticeshipOccupation>(sectorSql, sqlParams);

            var sector = GetSectors();

            var standardSubjectAreaTierOnes = dbStandardSubjectAreaTierOnes.Select(x =>
            {
                var appOcc = new StandardSubjectAreaTierOne
                {
                    Id = x.ApprenticeshipOccupationId,
                    Name = x.FullName,
                    Sectors = sector.Where(s => s.ApprenticeshipOccupationId == x.ApprenticeshipOccupationId),
                };
                return appOcc;
            }).ToList();

            _logger.Debug("Got all SSAT1s");

            return standardSubjectAreaTierOnes;
        }

        public IEnumerable<County> GetCounties()
        {
            _logger.Debug("Getting all counties");

            var counties = _getOpenConnection.Query<County>(GetCountiesSql);

            _logger.Debug($"Got {counties.Count} counties");

            return counties;
        }

        public County GetCountyById(int countyId)
        {
            _logger.Debug($"Getting county with id {countyId}");

            var sqlParams = new
            {
                countyId
            };

            var county = _getOpenConnection.Query<County>(GetCountyByIdSql, sqlParams).FirstOrDefault();

            _logger.Debug($"Found {county}");

            return county;
        }

        public County GetCountyByCode(string countyCode)
        {
            _logger.Debug($"Getting county with code {countyCode}");

            var sqlParams = new
            {
                countyCode
            };

            var county = _getOpenConnection.Query<County>(GetCountyByCodeSql, sqlParams).FirstOrDefault();

            _logger.Debug($"Found {county}");

            return county;
        }

        public County GetCountyByName(string countyName)
        {
            _logger.Debug($"Getting county with name {countyName}");

            const string sectorSql = "SELECT * FROM dbo.County WHERE FullName = @CountyName";

            var sqlParams = new
            {
                countyName
            };

            var county = _getOpenConnection.Query<County>(sectorSql, sqlParams).FirstOrDefault();

            _logger.Debug($"Found {county}");

            return county;
        }

        public IEnumerable<LocalAuthority> GetLocalAuthorities()
        {
            _logger.Debug("Getting all local authorities");

            var localAuthorities = _getOpenConnection.Query<LocalAuthority, County, Region, LocalAuthority>(GetLocalAuthoritiesSql, (la, c, r) =>
            {
                la.County = c;
                la.Region = r;
                return la;
            }, splitOn: "CountyId,RegionId");

            _logger.Debug($"Got {localAuthorities.Count} local authorities");

            return localAuthorities;
        }

        public LocalAuthority GetLocalAuthorityById(int localAuthorityId)
        {
            _logger.Debug($"Getting local authority with id {localAuthorityId}");

            var sqlParams = new
            {
                localAuthorityId
            };

            var localAuthority = _getOpenConnection.Query<LocalAuthority, County, LocalAuthority>(GetLocalAuthorityByIdSql, (la, c) =>
            {
                la.County = c;
                return la;
            }, sqlParams, "CountyId").FirstOrDefault();

            _logger.Debug($"Found {localAuthority}");

            return localAuthority;
        }

        public LocalAuthority GetLocalAuthorityByCode(string localAuthorityCode)
        {
            _logger.Debug($"Getting local authority with code name {localAuthorityCode}");

            var sqlParams = new
            {
                localAuthorityCode
            };

            var localAuthority = _getOpenConnection.Query<LocalAuthority, County, LocalAuthority>(GetLocalAuthorityByCodeSql, (la, c) =>
            {
                la.County = c;
                return la;
            }, sqlParams, "CountyId").FirstOrDefault();

            _logger.Debug($"Found {localAuthority}");

            return localAuthority;
        }

        public IEnumerable<Region> GetRegions()
        {
            _logger.Debug("Getting all local authorities");

            var localAuthorities = _getOpenConnection.Query<Region>(GetRegionsSql);

            _logger.Debug($"Got {localAuthorities.Count} local authorities");

            return localAuthorities;
        }

        public Region GetRegionById(int regionId)
        {
            _logger.Debug($"Getting local authority with id {regionId}");

            var sqlParams = new
            {
                regionId
            };

            var region = _getOpenConnection.Query<Region>(GetRegionByIdSql, sqlParams).FirstOrDefault();

            _logger.Debug($"Found {region}");

            return region;
        }

        public Region GetRegionByCode(string regionCode)
        {
            _logger.Debug($"Getting local authority with code name {regionCode}");

            var sqlParams = new
            {
                regionCode
            };

            var region = _getOpenConnection.Query<Region>(GetRegionByCodeSql, sqlParams).FirstOrDefault();

            _logger.Debug($"Found {region}");

            return region;
        }

        private IList<ApprenticeshipOccupation> GetApprenticeshipOccupations()
        {
            _logger.Debug("Getting all apprenticeship occupations");

            const string sectorSql = "SELECT * FROM dbo.ApprenticeshipOccupation ORDER BY FullName;";

            var sqlParams = new
            {
            };

            var dbOccupations = _getOpenConnection
                .Query<ApprenticeshipOccupation>(sectorSql, sqlParams);

            _logger.Debug("Got all apprenticeship occupations");

            return dbOccupations;
        } 

        private IList<ApprenticeshipFramework> GetApprenticeshipFrameworks()
        {
            _logger.Debug("Getting all frameworks");

            const string frameworkSql = "SELECT * FROM dbo.ApprenticeshipFramework ORDER BY FullName;";

            var sqlParams = new
            {
            };

            var dbFrameworks = _getOpenConnection
                .Query<ApprenticeshipFramework>(frameworkSql, sqlParams);

            return dbFrameworks;
        } 

        private IList<EducationLevel> GetEducationLevels()
        {
            _logger.Debug("Getting all education levels");

            const string sectorSql = "SELECT * FROM Reference.EducationLevel;";

            var sqlParams = new
            {
            };

            var levels = _getOpenConnection
                .Query<EducationLevel>(sectorSql, sqlParams);
            
            _logger.Debug("Got all education levels");

            return levels;
        }

        public void UpdateStandard(Standard standard)
        {
            _logger.Debug($"Updating standard with id={standard.Id}");

            const string standardSql = "SELECT * FROM Reference.Standard WHERE StandardId = @Id";

            //TODO: Does this need to be here? If not, test and remove.
            var sqlParams = new
            {
                standard.Id
            };

            var dbStandards = _getOpenConnection.Query<Entities.Standard>(standardSql, sqlParams);

            var dbStandard = dbStandards.Single();

            dbStandard.ApprenticeshipFrameworkStatusTypeId = (int)standard.Status;
            dbStandard.LarsCode = standard.LarsCode;
            dbStandard.StandardSectorId = standard.ApprenticeshipSectorId;
            

            // get new education level
            var educationLevels = GetEducationLevels();
            var level = educationLevels.Single(s => int.Parse(s.CodeName) == (int)standard.ApprenticeshipLevel);
            dbStandard.EducationLevelId = level.EducationLevelId;

            var result = _getOpenConnection.UpdateSingle(dbStandard);

            if (!result)
                throw new Exception($"Failed to save standard with id={standard.Id}");
        }

        public void UpdateFramework(Category category)
        {
            _logger.Debug($"Updating framework with id={category.Id}");

            const string standardSql = "SELECT * FROM ApprenticeshipFramework WHERE ApprenticeshipFrameworkId = @Id";
            const string sectorSql = "SELECT * FROM dbo.ApprenticeshipOccupation ORDER BY FullName;";

            //TODO: Does this need to be here? If not, test and remove.
            var sqlParams = new
            {
                category.Id
            };

            var dbStandards = _getOpenConnection.Query<Entities.ApprenticeshipFramework>(standardSql, sqlParams);

            var dbStandard = dbStandards.Single();

            var occupations = _getOpenConnection.Query<ApprenticeshipOccupation>(sectorSql);
            var occupationId = occupations.Single(w => w.CodeName == category.ParentCategoryCodeName).ApprenticeshipOccupationId;

            dbStandard.ApprenticeshipFrameworkStatusTypeId = (int)category.Status;
            dbStandard.FullName = category.FullName;
            dbStandard.ApprenticeshipOccupationId = occupationId;

            var result = _getOpenConnection.UpdateSingle(dbStandard);

            if (!result)
                throw new Exception($"Failed to save standard with id={category.Id}");
        }

        public Category InsertFramework(Category category)
        {
            _logger.Debug($"Inserting new framework");

            const string sectorSql = "SELECT * FROM dbo.ApprenticeshipOccupation ORDER BY FullName;";

            //TODO: Does this need to be here? If not, test and remove.
            var sqlParams = new
            {
                category.Id
            };

            var dbStandard = new ApprenticeshipFramework();

            var occupations = _getOpenConnection.Query<ApprenticeshipOccupation>(sectorSql);
            var occupationId = occupations.Single(w => w.CodeName == category.ParentCategoryCodeName).ApprenticeshipOccupationId;

            dbStandard.ApprenticeshipFrameworkStatusTypeId = (int)category.Status;
            dbStandard.FullName = category.FullName;
            dbStandard.ApprenticeshipOccupationId = occupationId;
            dbStandard.CodeName = category.CodeName;
            dbStandard.ShortName = category.CodeName;

            var result = _getOpenConnection.Insert(dbStandard);

            category.Id = (int)result;

            return category;
        }

        public Standard InsertStandard(Standard standard)
        {
            _logger.Debug($"Inserting new standard");

            // get new education level
            var educationLevels = GetEducationLevels();
            var level = educationLevels.Single(s => int.Parse(s.CodeName) == (int)standard.ApprenticeshipLevel);

            var dbStandard = new Entities.Standard
            {
                ApprenticeshipFrameworkStatusTypeId = (int) standard.Status,
                LarsCode = standard.LarsCode,
                StandardSectorId = standard.ApprenticeshipSectorId,
                EducationLevelId = level.EducationLevelId,
                FullName = standard.Name
        };

            var result = _getOpenConnection.Insert(dbStandard);

            standard.Id = (int)result;

            return standard;
        }
    }
}