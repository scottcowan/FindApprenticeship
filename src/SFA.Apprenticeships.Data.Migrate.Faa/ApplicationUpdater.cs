﻿namespace SFA.Apprenticeships.Data.Migrate.Faa
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Application.Interfaces;
    using Configuration;
    using Entities;
    using Entities.Sql;
    using Infrastructure.Repositories.Sql.Common;
    using Mappers;
    using Repository.Mongo;
    using Repository.Sql;

    public class ApplicationUpdater
    {
        private readonly ILogService _logService;
        private readonly IApplicationMappers _applicationMappers;
        private readonly IGetOpenConnection _targetDatabase;

        private readonly VacancyApplicationsRepository _vacancyApplicationsRepository;
        private readonly CandidateRepository _candidateRepository;
        private readonly ApplicationRepository _destinationApplicationRepository;
        private readonly ApplicationHistoryRepository _destinationApplicationHistoryRepository;
        private readonly SchoolAttendedRepository _schoolAttendedRepository;

        public ApplicationUpdater(string collectionName, IConfigurationService configurationService, ILogService logService)
        {
            _logService = logService;

            var configuration = configurationService.Get<MigrateFromFaaToAvmsPlusConfiguration>();
            var sourceDatabase = new GetOpenConnectionFromConnectionString(configuration.SourceConnectionString);
            _targetDatabase = new GetOpenConnectionFromConnectionString(configuration.TargetConnectionString);

            _applicationMappers = new ApplicationMappers(_logService);

            _vacancyApplicationsRepository = new VacancyApplicationsRepository(collectionName, configurationService, logService);
            _candidateRepository = new CandidateRepository(_targetDatabase);
            _destinationApplicationRepository = new ApplicationRepository(_targetDatabase);
            _destinationApplicationHistoryRepository = new ApplicationHistoryRepository(_targetDatabase, _logService);
            _schoolAttendedRepository = new SchoolAttendedRepository(_targetDatabase);
        }

        public void Update(Guid applicationGuid)
        {
            var application = _vacancyApplicationsRepository.GetVacancyApplication(applicationGuid);
            var candidateGuid = application.CandidateId;
            var candidateIds = _candidateRepository.GetCandidateIdsByGuid(new[] {candidateGuid});
            if (!candidateIds.ContainsKey(candidateGuid))
            {
                _logService.Warn($"Candidate {candidateGuid} for application {applicationGuid} could not be found");
                return;
            }

            var destinationCandidateId = candidateIds[candidateGuid];

            var destinationApplicationIds = _destinationApplicationRepository.GetApplicationIdsByGuid(new[] {applicationGuid});
            var candidateApplicationIds = _destinationApplicationRepository.GetApplicationIdsByCandidateIds(new[] {destinationCandidateId});
            var applicationIds = _applicationMappers.GetApplicationIds(destinationApplicationIds, candidateApplicationIds, new[] {application}, candidateIds);

            var applicationHistoryIds = _destinationApplicationHistoryRepository.GetApplicationHistoryIdsByApplicationIds(applicationIds.Values);
            var schoolAttendedIds = _schoolAttendedRepository.GetSchoolAttendedIdsByApplicationIds(applicationIds.Values);
            var applicationWithHistory = _applicationMappers.MapApplicationWithHistory(application, destinationCandidateId, applicationIds, new Dictionary<int, ApplicationSummary>(), schoolAttendedIds, new Dictionary<int, SubVacancy>(), applicationHistoryIds, new Dictionary<int, List<ApplicationHistorySummary>>());

            Update(applicationWithHistory);
        }

        public void Update(ApplicationWithHistory applicationWithHistory)
        {
            //update existing application
            _targetDatabase.UpdateSingle(applicationWithHistory.ApplicationWithSubVacancy.Application);
            
            //TODO: Likely that this creates multiple history records when the status is changed from new to inprogress and back again
            //Insert new application history records
            foreach (var applicationHistory in applicationWithHistory.ApplicationHistory.Where(a => a.ApplicationHistoryId == 0))
            {
                _targetDatabase.Insert(applicationHistory);
            }

            //Update existing application history records
            foreach (var applicationHistory in applicationWithHistory.ApplicationHistory.Where(a => a.ApplicationHistoryId != 0))
            {
                _targetDatabase.UpdateSingle(applicationHistory);
            }
        }
    }
}