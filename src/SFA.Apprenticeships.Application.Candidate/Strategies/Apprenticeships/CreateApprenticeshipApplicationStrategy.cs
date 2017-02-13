﻿namespace SFA.Apprenticeships.Application.Candidate.Strategies.Apprenticeships
{
    using Application.Entities;
    using AutoMapper;
    using Domain.Entities.Applications;
    using Domain.Entities.Candidates;
    using Domain.Entities.Users;
    using Domain.Entities.Vacancies;
    using Domain.Interfaces.Messaging;
    using Domain.Interfaces.Repositories;
    using System;
    using System.Threading.Tasks;
    using Vacancy;

    public class CreateApprenticeshipApplicationStrategy : ICreateApprenticeshipApplicationStrategy, ISaveApprenticeshipVacancyStrategy
    {
        private readonly IApprenticeshipApplicationReadRepository _apprenticeshipApplicationReadRepository;
        private readonly IApprenticeshipApplicationWriteRepository _apprenticeshipApplicationWriteRepository;
        private readonly ICandidateReadRepository _candidateReadRepository;
        private readonly IVacancyDataProvider<ApprenticeshipVacancyDetail> _vacancyDataProvider;
        private readonly IServiceBus _serviceBus;

        public CreateApprenticeshipApplicationStrategy(
            IVacancyDataProvider<ApprenticeshipVacancyDetail> vacancyDataProvider,
            IApprenticeshipApplicationReadRepository apprenticeshipApplicationReadRepository,
            IApprenticeshipApplicationWriteRepository apprenticeshipApplicationWriteRepository,
            ICandidateReadRepository candidateReadRepository, IServiceBus serviceBus)
        {
            _vacancyDataProvider = vacancyDataProvider;
            _apprenticeshipApplicationWriteRepository = apprenticeshipApplicationWriteRepository;
            _apprenticeshipApplicationReadRepository = apprenticeshipApplicationReadRepository;
            _candidateReadRepository = candidateReadRepository;
            _serviceBus = serviceBus;
        }

        public async Task<ApprenticeshipApplicationDetail> CreateApplication(Guid candidateId, int vacancyId)
        {
            var applicationDetail = _apprenticeshipApplicationReadRepository.GetForCandidate(candidateId, vacancyId);

            if (applicationDetail == null)
            {
                // Candidate has not previously applied for this vacancy.
                return await CreateNewApplication(candidateId, vacancyId);
            }

            applicationDetail.AssertState("Create apprenticeshipApplication", ApplicationStatuses.Draft);

            if (applicationDetail.IsArchived)
            {
                return UnarchiveApplication(applicationDetail);
            }

            return applicationDetail;
        }

        public async Task<ApprenticeshipApplicationDetail> SaveVacancy(Guid candidateId, int vacancyId)
        {
            var applicationDetail = _apprenticeshipApplicationReadRepository.GetForCandidate(candidateId, vacancyId);

            if (applicationDetail != null)
            {
                return applicationDetail;
            }

            return await CreateNewApplication(candidateId, vacancyId, true);
        }

        #region

        private ApprenticeshipApplicationDetail UnarchiveApplication(ApprenticeshipApplicationDetail apprenticeshipApplicationDetail)
        {
            apprenticeshipApplicationDetail.IsArchived = false;
            _apprenticeshipApplicationWriteRepository.Save(apprenticeshipApplicationDetail);

            return _apprenticeshipApplicationReadRepository.Get(apprenticeshipApplicationDetail.EntityId);
        }

        private async Task<ApprenticeshipApplicationDetail> CreateNewApplication(Guid candidateId, int vacancyId, bool saveVacancy = false)
        {
            var vacancyDetails = await _vacancyDataProvider.GetVacancyDetails(vacancyId);

            if (vacancyDetails == null) return null;

            var candidate = _candidateReadRepository.Get(candidateId);

            var applicationTemplate = saveVacancy
                ? null
                : new ApplicationTemplate
                {
                    EducationHistory = candidate.ApplicationTemplate.EducationHistory,
                    Qualifications = candidate.ApplicationTemplate.Qualifications,
                    WorkExperience = candidate.ApplicationTemplate.WorkExperience,
                    TrainingCourses = candidate.ApplicationTemplate.TrainingCourses,
                    AboutYou = candidate.ApplicationTemplate.AboutYou,
                    DisabilityStatus = candidate.MonitoringInformation.DisabilityStatus
                };

            var applicationStatus = saveVacancy ? ApplicationStatuses.Saved : ApplicationStatuses.Draft;
            var applicationDetail = CreateApplicationDetail(candidate, vacancyDetails, applicationStatus, applicationTemplate);

            if (vacancyDetails.ApplyViaEmployerWebsite && !saveVacancy)
            {
                return applicationDetail;
            }

            _apprenticeshipApplicationWriteRepository.Save(applicationDetail);
            _serviceBus.PublishMessage(new ApprenticeshipApplicationUpdate(applicationDetail.EntityId, ApplicationUpdateType.Create));

            return applicationDetail;
        }

        private static ApprenticeshipApplicationDetail CreateApplicationDetail(
            Candidate candidate, ApprenticeshipVacancyDetail vacancyDetails, ApplicationStatuses applicationStatus, ApplicationTemplate applicationTemplate)
        {
            return new ApprenticeshipApplicationDetail
            {
                EntityId = Guid.NewGuid(),
                Status = applicationStatus,
                DateCreated = DateTime.UtcNow,
                CandidateId = candidate.EntityId,
                CandidateDetails = Mapper.Map<RegistrationDetails, RegistrationDetails>(candidate.RegistrationDetails),
                VacancyStatus = vacancyDetails.VacancyStatus,
                Vacancy = new ApprenticeshipSummary
                {
                    Id = vacancyDetails.Id,
                    VacancyReference = vacancyDetails.VacancyReference,
                    Title = vacancyDetails.Title,
                    EmployerName = vacancyDetails.IsEmployerAnonymous ? vacancyDetails.AnonymousEmployerName : vacancyDetails.EmployerName,
                    IsPositiveAboutDisability = vacancyDetails.IsPositiveAboutDisability,
                    StartDate = vacancyDetails.StartDate,
                    ClosingDate = vacancyDetails.ClosingDate,
                    Description = vacancyDetails.IsEmployerAnonymous ? vacancyDetails.AnonymousAboutTheEmployer : vacancyDetails.EmployerDescription,
                    NumberOfPositions = vacancyDetails.NumberOfPositions,
                    Location = null, // NOTE: no equivalent in legacy vacancy details.
                    VacancyLocationType = vacancyDetails.VacancyLocationType,
                },
                // Populate apprenticeshipApplication template with candidate's most recent information.
                CandidateInformation = applicationTemplate
            };
        }

        #endregion
    }
}
