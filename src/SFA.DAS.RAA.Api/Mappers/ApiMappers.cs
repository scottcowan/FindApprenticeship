namespace SFA.DAS.RAA.Api.Mappers
{
    using Apprenticeships.Domain.Entities.Raa.Vacancies;
    using Apprenticeships.Domain.Entities.Vacancies;
    using Apprenticeships.Infrastructure.Common.Mappers;
    using Models;
    using VacancySummary = Apprenticeships.Domain.Entities.Raa.Vacancies.VacancySummary;

    public class ApiMappers : MapperEngine
    {
        public override void Initialise()
        {
            //Note that we only map from the domain object to the public version, not the other way round
            //However adding the reverse mapping causes a test to fail if we add a new vacancy property and don't include or ignore it in the public version
            Mapper.CreateMap<Wage, PublicWage>();
            Mapper.CreateMap<PublicWage, Wage>()
                .ForMember(dest => dest.ReasonForType, opt => opt.Ignore());

            Mapper.CreateMap<VacancySummary, PublicVacancySummary>();
            Mapper.CreateMap<PublicVacancySummary, VacancySummary>()
                .ForMember(dest => dest.VacancyOwnerRelationshipId, opt => opt.Ignore())
                .ForMember(dest => dest.NoOfOfflineApplicants, opt => opt.Ignore())
                .ForMember(dest => dest.DateSubmitted, opt => opt.Ignore())
                .ForMember(dest => dest.DateFirstSubmitted, opt => opt.Ignore())
                .ForMember(dest => dest.DateStartedToQA, opt => opt.Ignore())
                .ForMember(dest => dest.QAUserName, opt => opt.Ignore())
                .ForMember(dest => dest.DateQAApproved, opt => opt.Ignore())
                .ForMember(dest => dest.SubmissionCount, opt => opt.Ignore())
                .ForMember(dest => dest.VacancyManagerId, opt => opt.Ignore())
                .ForMember(dest => dest.DeliveryOrganisationId, opt => opt.Ignore())
                .ForMember(dest => dest.ParentVacancyId, opt => opt.Ignore())
                .ForMember(dest => dest.EmployerAnonymousReason, opt => opt.Ignore())
                .ForMember(dest => dest.UpdatedDateTime, opt => opt.Ignore())
                .ForMember(dest => dest.ContractOwnerId, opt => opt.Ignore())
                .ForMember(dest => dest.OriginalContractOwnerId, opt => opt.Ignore())
                .ForMember(dest => dest.RegionalTeam, opt => opt.Ignore())
                .ForMember(dest => dest.NewApplicationCount, opt => opt.Ignore())
                .ForMember(dest => dest.ApplicantCount, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedDate, opt => opt.Ignore())
                .ForMember(dest => dest.IsMultiLocation, opt => opt.Ignore())
                .ForMember(dest => dest.AnonymousAboutTheEmployer, opt => opt.Ignore())
                .ForMember(dest => dest.EmployerLocation, opt => opt.Ignore());

            Mapper.CreateMap<Vacancy, PublicVacancy>();
            Mapper.CreateMap<PublicVacancy, Vacancy>()
                .ForMember(dest => dest.AdditionalLocationInformationComment, opt => opt.Ignore())
                .ForMember(dest => dest.ApprenticeshipLevelComment, opt => opt.Ignore())
                .ForMember(dest => dest.ClosingDateComment, opt => opt.Ignore())
                .ForMember(dest => dest.ContactDetailsComment, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedByProviderUsername, opt => opt.Ignore())
                .ForMember(dest => dest.DesiredQualificationsComment, opt => opt.Ignore())
                .ForMember(dest => dest.DesiredSkillsComment, opt => opt.Ignore())
                .ForMember(dest => dest.DurationComment, opt => opt.Ignore())
                .ForMember(dest => dest.EditedInRaa, opt => opt.Ignore())
                .ForMember(dest => dest.EmployerDescriptionComment, opt => opt.Ignore())
                .ForMember(dest => dest.EmployerWebsiteUrlComment, opt => opt.Ignore())
                .ForMember(dest => dest.FirstQuestionComment, opt => opt.Ignore())
                .ForMember(dest => dest.FrameworkCodeNameComment, opt => opt.Ignore())
                .ForMember(dest => dest.FutureProspectsComment, opt => opt.Ignore())
                .ForMember(dest => dest.LastEditedById, opt => opt.Ignore())
                .ForMember(dest => dest.LocationAddressesComment, opt => opt.Ignore())
                .ForMember(dest => dest.LongDescriptionComment, opt => opt.Ignore())
                .ForMember(dest => dest.NumberOfPositionsComment, opt => opt.Ignore())
                .ForMember(dest => dest.OfflineApplicationInstructionsComment, opt => opt.Ignore())
                .ForMember(dest => dest.OfflineApplicationUrlComment, opt => opt.Ignore())
                .ForMember(dest => dest.OtherInformationComment, opt => opt.Ignore())
                .ForMember(dest => dest.PersonalQualitiesComment, opt => opt.Ignore())
                .ForMember(dest => dest.PossibleStartDateComment, opt => opt.Ignore())
                .ForMember(dest => dest.SecondQuestionComment, opt => opt.Ignore())
                .ForMember(dest => dest.SectorCodeNameComment, opt => opt.Ignore())
                .ForMember(dest => dest.ShortDescriptionComment, opt => opt.Ignore())
                .ForMember(dest => dest.StandardIdComment, opt => opt.Ignore())
                .ForMember(dest => dest.ThingsToConsiderComment, opt => opt.Ignore())
                .ForMember(dest => dest.TitleComment, opt => opt.Ignore())
                .ForMember(dest => dest.TrainingProvidedComment, opt => opt.Ignore())
                .ForMember(dest => dest.VacancySource, opt => opt.Ignore())
                .ForMember(dest => dest.WageComment, opt => opt.Ignore())
                .ForMember(dest => dest.WorkingWeekComment, opt => opt.Ignore())
                .ForMember(dest => dest.AnonymousEmployerDescriptionComment, opt => opt.Ignore())
                .ForMember(dest => dest.AnonymousEmployerReasonComment, opt => opt.Ignore())
                .ForMember(dest => dest.AnonymousAboutTheEmployerComment, opt => opt.Ignore())
                .ForMember(dest => dest.FrameworkStatus, opt => opt.Ignore())
                .ForMember(dest => dest.StandardStatus, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedDateTime, opt => opt.Ignore())
                .ForMember(dest => dest.VacancyOwnerRelationshipId, opt => opt.Ignore())
                .ForMember(dest => dest.NoOfOfflineApplicants, opt => opt.Ignore())
                .ForMember(dest => dest.DateSubmitted, opt => opt.Ignore())
                .ForMember(dest => dest.DateFirstSubmitted, opt => opt.Ignore())
                .ForMember(dest => dest.DateStartedToQA, opt => opt.Ignore())
                .ForMember(dest => dest.QAUserName, opt => opt.Ignore())
                .ForMember(dest => dest.DateQAApproved, opt => opt.Ignore())
                .ForMember(dest => dest.SubmissionCount, opt => opt.Ignore())
                .ForMember(dest => dest.VacancyManagerId, opt => opt.Ignore())
                .ForMember(dest => dest.DeliveryOrganisationId, opt => opt.Ignore())
                .ForMember(dest => dest.ParentVacancyId, opt => opt.Ignore())
                .ForMember(dest => dest.EmployerAnonymousReason, opt => opt.Ignore())
                .ForMember(dest => dest.UpdatedDateTime, opt => opt.Ignore())
                .ForMember(dest => dest.ContractOwnerId, opt => opt.Ignore())
                .ForMember(dest => dest.OriginalContractOwnerId, opt => opt.Ignore())
                .ForMember(dest => dest.RegionalTeam, opt => opt.Ignore())
                .ForMember(dest => dest.NewApplicationCount, opt => opt.Ignore())
                .ForMember(dest => dest.ApplicantCount, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedDate, opt => opt.Ignore())
                .ForMember(dest => dest.IsMultiLocation, opt => opt.Ignore())
                .ForMember(dest => dest.AnonymousAboutTheEmployer, opt => opt.Ignore())
                .ForMember(dest => dest.EmployerLocation, opt => opt.Ignore())
                .ForMember(dest => dest.LocalAuthorityCode, opt => opt.Ignore());
        }
    }
}