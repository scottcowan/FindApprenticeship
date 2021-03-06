﻿namespace SFA.Apprenticeships.Infrastructure.Repositories.Mongo.Applications
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Domain.Entities.Applications;
    using Domain.Entities.Exceptions;
    using Domain.Interfaces.Repositories;
    using Entities;
    using Common;
    using Common.Configuration;
    using MongoDB.Driver.Builders;
    using MongoDB.Driver.Linq;
    using Application.Interfaces;
    using ApplicationErrorCodes = Application.Interfaces.Applications.ErrorCodes;

    public class ApprenticeshipApplicationRepository : GenericMongoClient<MongoApprenticeshipApplicationDetail>, IApprenticeshipApplicationReadRepository,
        IApprenticeshipApplicationWriteRepository, IApprenticeshipApplicationStatsRepository
    {
        private readonly ILogService _logger;
        private readonly IDateTimeService _dataTimeService;

        private readonly IMapper _mapper;

        private readonly CommonApplicationRepository _commonApplicationRepository;

        public ApprenticeshipApplicationRepository(IConfigurationService configurationService, IMapper mapper, ILogService logger, IDateTimeService dataTimeService)
        {
            var config = configurationService.Get<MongoConfiguration>();
            Initialise(config.ApplicationsDb, "apprenticeships");
            _mapper = mapper;
            _logger = logger;
            _dataTimeService = dataTimeService;
            _commonApplicationRepository = new CommonApplicationRepository(logger, Collection);
        }

        public void Delete(Guid id)
        {
            _logger.Debug("Calling repository to delete ApprenticeshipApplicationDetail with Id={0}", id);

            Collection.Remove(Query<MongoApprenticeshipApplicationDetail>.EQ(o => o.Id, id));

            _logger.Debug("Deleted ApprenticeshipApplicationDetail with Id={0}", id);
        }

        public ApprenticeshipApplicationDetail Save(ApprenticeshipApplicationDetail entity)
        {
            _logger.Debug("Calling repository to save ApprenticeshipApplicationDetail Id={0}, Status={1}", entity.EntityId, entity.Status);

            var mongoEntity = _mapper.Map<ApprenticeshipApplicationDetail, MongoApprenticeshipApplicationDetail>(entity);

            UpdateEntityTimestamps(mongoEntity);

            Collection.Save(mongoEntity);

            _logger.Debug("Saved ApprenticeshipApplicationDetail to repository with Id={0}", entity.EntityId);

            return _mapper.Map<MongoApprenticeshipApplicationDetail, ApprenticeshipApplicationDetail>(mongoEntity);
        }

        public ApprenticeshipApplicationDetail Get(Guid id, bool errorIfNotFound)
        {
            _logger.Debug("Calling repository to get ApprenticeshipApplicationDetail with Id={0}", id);

            var mongoEntity = Collection.FindOneById(id);

            string message;

            if (mongoEntity == null && errorIfNotFound)
            {
                 message = string.Format("Unknown ApprenticeshipApplicationDetail with Id={0}", id);

                throw new CustomException(message, ApplicationErrorCodes.ApplicationNotFoundError);
            }

            message = mongoEntity == null ? "Found no ApprenticeshipApplicationDetail with Id={0}" : "Found ApprenticeshipApplicationDetail with Id={0}";

            _logger.Debug(message, id);

            return mongoEntity == null ? null : _mapper.Map<MongoApprenticeshipApplicationDetail, ApprenticeshipApplicationDetail>(mongoEntity);
        }

        public ApprenticeshipApplicationDetail Get(int legacyApplicationId, bool errorIfMultipleFound)
        {
            _logger.Debug("Calling repository to get ApprenticeshipApplicationDetail with legacy Id={0}", legacyApplicationId);

            var mongoEntity = errorIfMultipleFound ? Collection.AsQueryable().SingleOrDefault(a => a.LegacyApplicationId == legacyApplicationId) : Collection.AsQueryable().FirstOrDefault(a => a.LegacyApplicationId == legacyApplicationId);

            var message = mongoEntity == null ? "Found no ApprenticeshipApplicationDetail with legacy Id={0}" : "Found ApprenticeshipApplicationDetail with legacy Id={0}";

            _logger.Debug(message, legacyApplicationId);

            return mongoEntity == null ? null : _mapper.Map<MongoApprenticeshipApplicationDetail, ApprenticeshipApplicationDetail>(mongoEntity);
        }

        public IList<ApprenticeshipApplicationSummary> GetForCandidate(Guid candidateId)
        {
            _logger.Debug("Calling repository to get ApplicationSummary list for candidate with Id={0}", candidateId);
            
            // Get apprenticeship application summaries for the specified candidate, excluding any that are archived.
            var mongoApplicationDetailsList = Collection
                .AsQueryable()
                .Where(each => each.CandidateId == candidateId)
                .ToArray();

            _logger.Debug("{0} MongoApprenticeshipApplicationDetail items returned in collection for candidate with Id={1}", mongoApplicationDetailsList.Count(), candidateId);

            _logger.Debug("Mapping MongoApprenticeshipApplicationDetail items to ApplicationSummary list for candidate with Id={0}", candidateId);

            var applicationDetailsList = _mapper
                .Map<MongoApprenticeshipApplicationDetail[], IEnumerable<ApprenticeshipApplicationSummary>>(mongoApplicationDetailsList)
                .ToList();

            _logger.Debug("{0} ApplicationSummary items returned for candidate with Id={1}", applicationDetailsList.Count(), candidateId);

            return applicationDetailsList;
        }

        public ApprenticeshipApplicationDetail GetForCandidate(Guid candidateId, int vacancyId, bool errorIfNotFound = false)
        {
            _logger.Debug("Calling repository to get ApplicationSummary for candidateId={0} and vacancyId={1}", candidateId, vacancyId);

            var mongoApplicationDetail = Collection.AsQueryable().SingleOrDefault(each => each.CandidateId == candidateId && each.Vacancy.Id == vacancyId);

            if (mongoApplicationDetail == null && errorIfNotFound)
            {
                var message = string.Format("No ApprenticeshipApplicationDetail found for candidateId={0} and vacancyId={1}", candidateId, vacancyId);
                throw new CustomException(message, ApplicationErrorCodes.ApplicationNotFoundError);
            }

            _logger.Debug("Returning ApplicationSummary for candidateId={0} and vacancyId={1}", candidateId, vacancyId);

            return _mapper.Map<MongoApprenticeshipApplicationDetail, ApprenticeshipApplicationDetail>(mongoApplicationDetail);
        }

        public IEnumerable<ApprenticeshipApplicationSummary> GetApplicationSummaries(int vacancyId)
        {
            _logger.Debug("Calling repository to get ApprenticeshipApplicationSummaries with VacancyId:{0}", vacancyId);

            var mongoEntities = Collection.Find(Query.EQ("Vacancy._id", vacancyId)).ToArray();

            _logger.Debug("Found {0} ApprenticeshipApplicationSummaries with VacancyId:{1}", mongoEntities.Length, vacancyId);

            var applicationSummaries =
                _mapper.Map<IEnumerable<MongoApprenticeshipApplicationDetail>, IEnumerable<ApprenticeshipApplicationSummary>>(
                    mongoEntities);

            return applicationSummaries;
        }

        public IEnumerable<ApprenticeshipApplicationSummary> GetSubmittedApplicationSummaries(int vacancyId)
        {
            _logger.Debug("Calling repository to get submitted ApprenticeshipApplicationSummaries with VacancyId:{0}", vacancyId);

            var mongoEntities = Collection.AsQueryable().Where(a => a.Status >= ApplicationStatuses.Submitted && a.Vacancy.Id == vacancyId).OrderBy(a => a.Status).ThenByDescending(a => a.DateUpdated).ToArray();

            _logger.Debug("Found {0} ApprenticeshipApplicationSummaries with VacancyId:{1}", mongoEntities.Length, vacancyId);

            var applicationSummaries =
                _mapper.Map<IEnumerable<MongoApprenticeshipApplicationDetail>, IEnumerable<ApprenticeshipApplicationSummary>>(
                    mongoEntities);

            return applicationSummaries;
        }

        public IEnumerable<Guid> GetDraftApplicationsForExpiredVacancies(DateTime vacancyExpiryDate)
        {
            _logger.Debug("Calling repository to get draft applications for expired vacancies");

            var applicationIds = Collection
                .AsQueryable()
                .Where(each => each.Vacancy.ClosingDate <= vacancyExpiryDate && each.DateApplied == null)
                .Select(each => each.EntityId);

            _logger.Debug("Called repository to get draft applications for expired vacancies");

            return applicationIds;
        }

        public IEnumerable<Guid> GetApplicationsSubmittedOnOrBefore(DateTime dateApplied)
        {
            _logger.Debug("Calling repository to get apprenticeship applications submitted on or before: {0}", dateApplied);

            var applicationIds = Collection
                .AsQueryable()
                .Where(each => each.DateApplied <= dateApplied)
                .Select(each => each.EntityId);

            _logger.Debug("Called repository to get apprenticeship applications submitted on or before: {0}", dateApplied);

            return applicationIds;
        }

        public IReadOnlyDictionary<int, IApplicationCounts> GetCountsForVacancyIds(IEnumerable<int> vacancyIds)
        {
            return _commonApplicationRepository.GetCountsForVacancyIds(vacancyIds);
        }

        public ApprenticeshipApplicationDetail Get(Guid id)
        {
            _logger.Debug("Calling repository to get ApprenticeshipApplicationDetail with Id={0}", id);

            var mongoEntity = Collection.FindOneById(id);

            var message = mongoEntity == null ? "Found no ApprenticeshipApplicationDetail with Id={0}" : "Found ApprenticeshipApplicationDetail with Id={0}";

            _logger.Debug(message, id);

            return mongoEntity == null ? null : _mapper.Map<MongoApprenticeshipApplicationDetail, ApprenticeshipApplicationDetail>(mongoEntity);
        }

        public void ExpireOrWithdrawForCandidate(Guid candidateId, int vacancyId)
        {
            _logger.Debug("Calling repository to expire or withdraw apprenticeship application for candidate with Id={0} and VacancyId={1}", candidateId, vacancyId);

            var applicationDetail = GetForCandidate(candidateId, vacancyId);

            if (applicationDetail == null)
            {
                _logger.Debug("Apprenticeship application to be expired or withdrawn was not found for CandidateId={0}, VacancyId={1}", candidateId, vacancyId);
                return;
            }

            _logger.Debug("Found apprenticeship application to be expired or withdrawn with Id={0}, Status={1}", applicationDetail.EntityId, applicationDetail.Status);

            applicationDetail.Status = ApplicationStatuses.ExpiredOrWithdrawn;

            Save(applicationDetail);

            _logger.Debug("Saved expired or withdrawn apprenticeship application for candidate with Id={0} and VacancyId={1}", applicationDetail.CandidateId, vacancyId);
        }

        public void UpdateApplicationNotes(Guid applicationId, string notes)
        {
            _logger.Debug("Calling repository to update apprenticeship application notes for application with Id={0}", applicationId);

            var result = Collection.Update(
                Query<MongoApprenticeshipApplicationDetail>
                    .EQ(e => e.Id, applicationId),
                Update<MongoApprenticeshipApplicationDetail>
                    .Set(e => e.Notes, notes)
                    .Set(e => e.DateUpdated, _dataTimeService.UtcNow));

            if (result.Ok)
            {
                _logger.Debug("Called repository to update apprenticeship application notes for application with Id={0} successfully", applicationId);
            }
            else
            {
                var message = $"Call to repository to update apprenticeship application notes for application with Id={applicationId} failed! Exit code={result.Code}, error message={result.ErrorMessage}";
                _logger.Error(message);
                throw new Exception(message);
            }
        }

        public bool UpdateApplicationStatus(ApprenticeshipApplicationDetail entity, ApplicationStatuses updatedStatus, bool ignoreOwnershipCheck)
        {
            var applicationId = entity.EntityId;
            var now = _dataTimeService.UtcNow;

            _logger.Info("Calling repository to try to update apprenticeship application status={1} for application with Id={0}", applicationId, updatedStatus);

            var idMatchQuery = Query<MongoApprenticeshipApplicationDetail>.EQ(e => e.Id, applicationId);
            //Only update if not owned by RAA (using the setting of DateLastViewed as a proxy for that ownership) or if ownership should be ignored
            //http://stackoverflow.com/questions/4057196/how-do-you-query-this-in-mongo-is-not-null
            var isNotOwnedByRaaQuery = Query<MongoApprenticeshipApplicationDetail>.EQ(e => e.DateLastViewed, null);

            var query = ignoreOwnershipCheck
                ? idMatchQuery
                : new QueryBuilder<MongoApprenticeshipApplicationDetail>().And(idMatchQuery, isNotOwnedByRaaQuery);

            var update = Update<MongoApprenticeshipApplicationDetail>
                .Set(e => e.Status, updatedStatus)
                .Set(e => e.IsArchived, false) // Application status has changed, ensure it appears on the candidate's dashboard.
                .Set(e => e.DateUpdated, now);

            switch (updatedStatus)
            {
                case ApplicationStatuses.Successful:
                    update = update.Set(e => e.SuccessfulDateTime, now);
                    break;
                case ApplicationStatuses.Unsuccessful:
                    update = update.Set(e => e.UnsuccessfulDateTime, now);
                    break;
            }

            var result = Collection.Update(query, update);

            if (result.Ok)
            {
                _logger.Info("Called repository to update apprenticeship application status={1} for application with Id={0} successfully with code={2}. Documents affected={3}", applicationId, updatedStatus, result.Code, result.DocumentsAffected);
                return result.DocumentsAffected == 1;
            }

            var message = $"Call to repository to update apprenticeship application status={updatedStatus} for application with Id={applicationId} failed! Exit code={result.Code}, error message={result.ErrorMessage}";
            _logger.Error(message);
            throw new Exception(message);
        }
    }
}
