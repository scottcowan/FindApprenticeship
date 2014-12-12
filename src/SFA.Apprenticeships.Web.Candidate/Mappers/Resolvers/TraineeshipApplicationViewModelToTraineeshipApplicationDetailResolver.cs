﻿namespace SFA.Apprenticeships.Web.Candidate.Mappers.Resolvers
{
    using System.Collections.Generic;
    using AutoMapper;
    using Domain.Entities.Applications;
    using Domain.Entities.Candidates;
    using Domain.Entities.Locations;
    using Domain.Entities.Users;
    using Domain.Entities.Vacancies;
    using Helpers;
    using ViewModels.Applications;
    using ViewModels.Candidate;
    using ViewModels.VacancySearch;

    public class TraineeeshipApplicationViewModelToTraineeeshipApplicationDetailResolver :
        ITypeConverter<TraineeshipApplicationViewModel, ApplicationDetail>
    {
        public ApplicationDetail Convert(ResolutionContext context)
        {
            var model = (TraineeshipApplicationViewModel) context.SourceValue;

            var application = new ApplicationDetail
            {
                CandidateId = model.Candidate.Id,
                Vacancy = GetVacancy(model.VacancyDetail),
                CandidateDetails = GetCandidateDetails(model.Candidate),
                CandidateInformation = GetCandidateInformation(model.Candidate),
                AdditionalQuestion1Answer = model.Candidate.EmployerQuestionAnswers != null ? model.Candidate.EmployerQuestionAnswers.CandidateAnswer1 : string.Empty,
                AdditionalQuestion2Answer = model.Candidate.EmployerQuestionAnswers != null ? model.Candidate.EmployerQuestionAnswers.CandidateAnswer2 : string.Empty
            };

            return application;
        }

        private static ApplicationTemplate GetCandidateInformation(TraineeshipCandidateViewModel modelBase)
        {
            return new ApplicationTemplate
            {
                Qualifications = modelBase.HasQualifications ? ApplicationConverter.GetQualifications(modelBase.Qualifications) : new List<Qualification>(),
                WorkExperience = modelBase.HasWorkExperience ? ApplicationConverter.GetWorkExperiences(modelBase.WorkExperience) : new List<WorkExperience>(),
            };
        }

        private static RegistrationDetails GetCandidateDetails(TraineeshipCandidateViewModel modelBase)
        {
            return new RegistrationDetails
            {
                EmailAddress = modelBase.EmailAddress,
                Address = ApplicationConverter.GetAddress(modelBase.Address),
                DateOfBirth = modelBase.DateOfBirth,
                PhoneNumber = modelBase.PhoneNumber,
                FirstName = modelBase.FirstName,
                LastName = modelBase.LastName,
            };
        }

        private static VacancySummary GetVacancy(VacancyDetailViewModel model)
        {
            return new VacancySummary
            {
                Id = model.Id,
                ClosingDate = model.ClosingDate,
                Description = model.Description,
                EmployerName = model.EmployerName,
                Location = new GeoPoint
                {
                    Longitude = model.VacancyAddress.GeoPoint.Longitude,
                    Latitude = model.VacancyAddress.GeoPoint.Latitude
                },
                Title = model.Title,
            };
        }
    }
}