﻿namespace SFA.Apprenticeships.Infrastructure.Repositories.Vacancies.Sql
{
    using Domain.Entities.Vacancies.ProviderVacancies;
    using Domain.Entities.Vacancies.ProviderVacancies.Apprenticeship;
    using SFA.Apprenticeships.Domain.Interfaces.Repositories;
    using SFA.Infrastructure.Interfaces;
    using SFA.Infrastructure.Sql;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using Vacancy = SFA.Apprenticeships.NewDB.Domain.Entities.Vacancy;
    using Reference = SFA.Apprenticeships.NewDB.Domain.Entities;
    using Domain.Interfaces.Queries;
    using System.Threading;
    using Dapper;

// TODO GenericSqlClient??

    public class ApprenticeshipVacancyRepository : IApprenticeshipVacancyReadRepository, IApprenticeshipVacancyWriteRepository
    {
        private IDictionary<string, WageType> _wageTypeMap = new Dictionary<string, WageType>();

        private readonly IMapper _mapper;
        private readonly ILogService _logger;

        private readonly IGetOpenConnection _getOpenConnection;

        /*
        public ApprenticeshipVacancyRepository(
            IConfigurationService configurationService,
            IMapper mapper,
            ILogService logger)
        {
            var config = configurationService.Get<MongoConfiguration>();

            Initialise(config.VacancyDb, "apprenticeshipVacancies");

            _mapper = mapper;
            _logger = logger;
        }
        */

        public ApprenticeshipVacancyRepository(IGetOpenConnection getOpenConnection, IMapper mapper, ILogService logger)
        {
            _getOpenConnection = getOpenConnection;
            _mapper = mapper;
            _logger = logger;
        }

        public ApprenticeshipVacancy Get(Guid id)
        {
            _logger.Debug("Calling database to get apprenticeship vacancy with Id={0}", id);

            var dbVacancy = _getOpenConnection.Query<Vacancy.Vacancy>("SELECT * FROM Vacancy.Vacancy WHERE VacancyId = @VacancyGuid", new { VacancyGuid = id }).SingleOrDefault();

            return MapVacancy(dbVacancy);
        }

        public ApprenticeshipVacancy Get(long vacancyReferenceNumber)
        {
            _logger.Debug("Calling database to get apprenticeship vacancy with Vacancy Reference Number={0}", vacancyReferenceNumber);

            var dbVacancy = _getOpenConnection.Query<Vacancy.Vacancy>(
                "SELECT * FROM Vacancy.Vacancy WHERE VacancyReferenceNumber = @VacancyReferenceNumber",
                new { VacancyReferenceNumber = vacancyReferenceNumber }).SingleOrDefault();

            // return mongoEntity == null ? null : _mapper.Map<MongoApprenticeshipVacancy, ApprenticeshipVacancy>(mongoEntity);

            return MapVacancy(dbVacancy);
        }

        private ApprenticeshipVacancy MapVacancy(Vacancy.Vacancy dbVacancy)
        {
            if (dbVacancy == null)
                return null;

            // Vacancy

            var result = _mapper.Map<Vacancy.Vacancy, ApprenticeshipVacancy>(dbVacancy);

            // TODO: Method which looks up in cache and if not found refreshes cache / loads new record
            result.Ukprn = _getOpenConnection
                .QueryCached<Vacancy.VacancyParty>(TimeSpan.FromHours(1), "SELECT * FROM Vacancy.VacancyParty")
                .Single(p => p.VacancyPartyId == dbVacancy.ManagerVacancyPartyId) // TODO: Verify
                .UKPRN.ToString(); // TODO: Casing. TODO: Type?

            // TODO: Method which looks up in cache and if not found refreshes cache / loads new record
            var employer = _getOpenConnection
                .QueryCached<Vacancy.VacancyParty>(TimeSpan.FromHours(1), "SELECT * FROM Vacancy.VacancyParty")
                .Single(p => p.VacancyPartyId == dbVacancy.EmployerVacancyPartyId); // TODO: Verify

            result.ProviderSiteEmployerLink.ProviderSiteErn = employer.EDSURN.ToString(); // TODO: Verify. TODO: Case. TODO: Type?
            result.ProviderSiteEmployerLink.Employer = new Domain.Entities.Organisations.Employer()
            {
                Address = new Domain.Entities.Locations.Address()
                {
                    // TODO
                },
                //DateCreated = employer.DateCreated, TODO
                //DateUpdated = employer.DateUpdated, TODO
                //EntityId = employer.VacancyPartyId, // TODO: Verify
                Ern = employer.EDSURN.ToString(), // TODO: Verify. TODO: Case. TODO: Type?
                Name = employer.FullName
            };

            // ApprenticeshipVacancy

            if (dbVacancy.FrameworkId != null)
            {
                // TODO: QueryCachedDictionary
                result.FrameworkCodeName = _getOpenConnection
                    .QueryCached<Reference.Framework>(TimeSpan.FromHours(1), "SELECT * FROM Reference.Framework")
                    .Single(f => f.FrameworkId == dbVacancy.FrameworkId)
                    .CodeName;
            }

            // TODO: Inconsistency of location of comment fields Vacancy vs ApprenticeshipVacancy

            return result;
        }

        public List<ApprenticeshipVacancy> GetForProvider(string ukPrn, string providerSiteErn)
        {
            const string parentVacancyStatusCode = "PAR";
            _logger.Debug("Calling database to get apprenticeship vacancies with Vacancy UkPrn = {0}, providerSiteErn = {1}", ukPrn, providerSiteErn);

            var dbVacancies = _getOpenConnection.Query<Vacancy.Vacancy>(@"
SELECT *
FROM   Vacancy.Vacancy
WHERE  Vacancy.ManagerVacancyPartyId IN (
    SELECT VacancyPartyId
    FROM   Vacancy.VacancyParty p
    WHERE  p.UKPRN = @UkPrn
    AND    p.EDSURN = @ProviderSiteUrn
)
AND Vacancy.VacancyStatusCode NOT IN @VacancyStatusCodes",
                new
                {
                    UkPrn = ukPrn,
                    ProviderSiteUrn = providerSiteErn,
                    VacancyStatusCodes = new [] {parentVacancyStatusCode}
                });

            _logger.Debug(
                $"Found {dbVacancies.Count} apprenticeship vacancies with ukprn = {ukPrn}, providerSiteErn = {providerSiteErn}");

            return dbVacancies.Select(MapVacancy).ToList();
        }

        public List<ApprenticeshipVacancy> GetWithStatus(params ProviderVacancyStatuses[] desiredStatuses)
        {
            Dapper.SqlMapper.AddTypeMap(typeof(string), System.Data.DbType.AnsiString);
            _logger.Debug("Called database to get apprenticeship vacancies in status {1}", string.Join(",", desiredStatuses));

            var statuses = desiredStatuses.Select(_mapper.Map<ProviderVacancyStatuses, string>).ToList();
            
            var dbVacancies = _getOpenConnection.Query<Vacancy.Vacancy>(@"
SELECT *
FROM   Vacancy.Vacancy
WHERE  Vacancy.VacancyStatusCode IN @VacancyStatusCodes", new
            {
                VacancyStatusCodes = statuses
            });

            // throw new NotSupportedException("This is likely to use excessive memory. Return type should be IEnumerable.");
            _logger.Debug(
                $"Found {dbVacancies.Count} apprenticeship vacancies with statuses in {string.Join(",", desiredStatuses)}");

            return dbVacancies.Select(MapVacancy).ToList();
        }

        public List<ApprenticeshipVacancy> Find(ApprenticeshipVacancyQuery query, out int totalResultsCount)
        {
            _logger.Debug("Calling database to find apprenticeship vacancies");

            var coreQuery = @"
FROM   Vacancy.Vacancy
WHERE  Vacancy.VacancyStatus = 'LIV' -- TODO: Probably would want to parameterise from constant
" + (string.IsNullOrWhiteSpace(query.FrameworkCodeName) ? "" : "AND    Vacancy.FrameworkCodeName = @FrameworkCodeName") + @"
" + (query.LiveDate.HasValue ? "AND     Vacancy.DateSubmitted >= @LiveDate" : "");

            // TODO: Vacancy.DateSubmitted should be DateLive (or DatePublished)???
            var data = _getOpenConnection.QueryMultiple<int,Vacancy.Vacancy>(@"
SELECT COUNT(*)
" + coreQuery + @"

SELECT *
" + coreQuery + @"
ORDER BY Vacancy.VacancyReferenceNumber
OFFSET ((@CurrentPage - 1) * @PageSize) ROWS
FETCH NEXT @PageSize ROWS ONLY
", query);

            totalResultsCount = data.Item1.Single();

            var dbVacancies = data.Item2;

            _logger.Debug("Found {0} apprenticeship vacanc(ies)", dbVacancies.Count);

            return new List<ApprenticeshipVacancy>();
        }

        public void Delete(Guid id)
        {
            _logger.Debug("Calling database to delete apprenticeship vacancy with Id={0}", id);

            throw new NotSupportedException("Don't really think vacancies are / should be ever deleted");

            _logger.Debug("Deleted apprenticeship vacancy with Id={0}", id);
        }

        public ApprenticeshipVacancy Save(ApprenticeshipVacancy entity)
        {
            _logger.Debug("Calling database to save apprenticeship vacancy with id={0}", entity.EntityId);

            UpdateEntityTimestamps(entity);

            // TODO: Map from ApprenticeshipVacancy to Apprenticeship ??

            var dbVacancy = _mapper.Map<ApprenticeshipVacancy, Vacancy.Vacancy>(entity);

            // TODO: This should be the other way around (to avoid a race condition)
            // and be in a single call to the database (to avoid a double latency hit)
            // This should be done as a single method in _getOpenConnection
            if (!_getOpenConnection.UpdateSingle(dbVacancy))
                _getOpenConnection.Insert(dbVacancy);

            /*
            _getOpenConnection.UpdateSingle(address);
            */

            _logger.Debug("Saved apprenticeship vacancy with to Mongodb with id={0}", entity.EntityId);

            // TODO: Mongo used to map dbVacancy back to entity, not sure what the point in that is.
            
            return entity;
        }

        public ApprenticeshipVacancy ReserveVacancyForQA(long vacancyReferenceNumber)
        {
            _logger.Debug($"Calling database to get and reserve vacancy with reference number: {vacancyReferenceNumber} for QA");

            var userName = Thread.CurrentPrincipal.Identity.Name;

            // TODO: Add QAUserName / TimeStartedToQA. Perhaps a name without QA in would be better?
            // TODO: Possibly need MutatingQueryMulti to get address etc??? Or use join as only one record
            var dbVacancy = _getOpenConnection.MutatingQuery<Vacancy.Vacancy>(@"
UPDATE Vacancy.Vacancy
SET    QAUserName             = @UserName,
       TimeStartedToQA        = @TimeStartedToQA,
WHERE  VacancyReferenceNumber = @VacancyReferenceNumber
AND    (QAUserName IS NULL OR (QAUserName = @userName))
AND    (TimeStartedToQA IS NULL OR (TimeStartedToQA > @lockExpiryTime))

DECLARE @RowCount INT = @@RowCount

IF RowCount > 1
    RAISERROR etc etc.

SELECT *
FROM   Vacancy.Vacancy
JOIN   Address.Address etc. etc.
WHERE  etc etc
AND    @RowCount = 1
", new { userName = userName, TimeStartedToQA = DateTime.UtcNow }).SingleOrDefault();

            if (dbVacancy == null)
            {
                // TODO: Mongodb references
                //_logger.Warn($"Call to Mongodb to get and reserve vacancy with reference number: {vacancyReferenceNumber} for QA failed: {result.Code}, {result.ErrorMessage}");
                return null;
            }

            //_logger.Info($"Called Mongodb to get and reserve vacancy with reference number: {vacancyReferenceNumber} for QA successfully");

            // TODO: Mapping
            return null;
        }

        private void UpdateEntityTimestamps(ApprenticeshipVacancy entity)
        {
            /* TODO
            // determine whether this is a "new" entity being saved for the first time
            if (entity.DateTimeCreated == DateTime.MinValue)
            {
                entity.DateTimeCreated = DateTime.UtcNow;
                entity.DateTimeUpdated = null;
            }
            else
            {
                entity.DateTimeUpdated = DateTime.UtcNow;
            }
            */
        }
    }
}
