namespace SFA.DAS.RAA.Api.Service.V1.Mappers
{
    using Apprenticeships.Domain.Entities.Raa.Parties;
    using Apprenticeships.Infrastructure.Common.Mappers;
    using Client.V1.Models;
    using ApiGeoPoint = Client.V1.Models.GeoPoint;
    using ApiPostalAddress = Client.V1.Models.PostalAddress;
    using ApiWage = Client.V1.Models.Wage;
    using ApiVacancySummary = Client.V1.Models.VacancySummary;
    using ApiVacancy = Client.V1.Models.Vacancy;
    using ApiWageUpdate = Client.V1.Models.WageUpdate;
    using ApiCounty = Client.V1.Models.County;
    using ApiLocalAuthority = Client.V1.Models.LocalAuthority;
    using ApiRegion = Client.V1.Models.Region;
    using GeoPoint = Apprenticeships.Domain.Entities.Raa.Locations.GeoPoint;
    using PostalAddress = Apprenticeships.Domain.Entities.Raa.Locations.PostalAddress;
    using VacancySummary = Apprenticeships.Domain.Entities.Raa.Vacancies.VacancySummary;
    using Vacancy = Apprenticeships.Domain.Entities.Raa.Vacancies.Vacancy;
    using Wage = Apprenticeships.Domain.Entities.Vacancies.Wage;
    using WageUpdate = Apprenticeships.Domain.Entities.Raa.Vacancies.WageUpdate;
    using County = Apprenticeships.Domain.Entities.Raa.Reference.County;
    using LocalAuthority = Apprenticeships.Domain.Entities.Raa.Reference.LocalAuthority;
    using Region = Apprenticeships.Domain.Entities.Raa.Reference.Region;

    public class ApiClientMappers : MapperEngine
    {
        public override void Initialise()
        {
            Mapper.CreateMap<ApiGeoPoint, GeoPoint>();
            Mapper.CreateMap<ApiPostalAddress, PostalAddress>();
            Mapper.CreateMap<ApiWage, Wage>();
            Mapper.CreateMap<ApiVacancySummary, VacancySummary>();
            Mapper.CreateMap<ApiVacancy, Vacancy>();
            Mapper.CreateMap<WageUpdate, ApiWageUpdate>();

            Mapper.CreateMap<PublicWage, Wage>()
                .ForMember(dest => dest.ReasonForType, opt => opt.Ignore());
            Mapper.CreateMap<PublicVacancySummary, VacancySummary>()
                .ForMember(dest => dest.NoOfOfflineApplicants, opt => opt.Ignore())
                .ForMember(dest => dest.DateSubmitted, opt => opt.Ignore())
                .ForMember(dest => dest.DateFirstSubmitted, opt => opt.Ignore())
                .ForMember(dest => dest.DateStartedToQA, opt => opt.Ignore())
                .ForMember(dest => dest.QAUserName, opt => opt.Ignore())
                .ForMember(dest => dest.SubmissionCount, opt => opt.Ignore())
                .ForMember(dest => dest.VacancyManagerId, opt => opt.Ignore())
                .ForMember(dest => dest.DeliveryOrganisationId, opt => opt.Ignore())
                .ForMember(dest => dest.ParentVacancyId, opt => opt.Ignore())
                .ForMember(dest => dest.EmployerAnonymousReason, opt => opt.Ignore())
                .ForMember(dest => dest.AnonymousAboutTheEmployer, opt => opt.Ignore())
                .ForMember(dest => dest.UpdatedDateTime, opt => opt.Ignore())
                .ForMember(dest => dest.OriginalContractOwnerId, opt => opt.Ignore())
                .ForMember(dest => dest.RegionalTeam, opt => opt.Ignore())
                .ForMember(dest => dest.EmployerLocation, opt => opt.Ignore())
                .ForMember(dest => dest.NewApplicationCount, opt => opt.Ignore())
                .ForMember(dest => dest.ApplicantCount, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedDate, opt => opt.Ignore())
                .ForMember(dest => dest.IsMultiLocation, opt => opt.Ignore());
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
                .ForMember(dest => dest.NoOfOfflineApplicants, opt => opt.Ignore())
                .ForMember(dest => dest.DateSubmitted, opt => opt.Ignore())
                .ForMember(dest => dest.DateFirstSubmitted, opt => opt.Ignore())
                .ForMember(dest => dest.DateStartedToQA, opt => opt.Ignore())
                .ForMember(dest => dest.QAUserName, opt => opt.Ignore())
                .ForMember(dest => dest.SubmissionCount, opt => opt.Ignore())
                .ForMember(dest => dest.VacancyManagerId, opt => opt.Ignore())
                .ForMember(dest => dest.DeliveryOrganisationId, opt => opt.Ignore())
                .ForMember(dest => dest.ParentVacancyId, opt => opt.Ignore())
                .ForMember(dest => dest.EmployerAnonymousReason, opt => opt.Ignore())
                .ForMember(dest => dest.UpdatedDateTime, opt => opt.Ignore())
                .ForMember(dest => dest.OriginalContractOwnerId, opt => opt.Ignore())
                .ForMember(dest => dest.RegionalTeam, opt => opt.Ignore())
                .ForMember(dest => dest.EmployerLocation, opt => opt.Ignore())
                .ForMember(dest => dest.NewApplicationCount, opt => opt.Ignore())
                .ForMember(dest => dest.ApplicantCount, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedDate, opt => opt.Ignore())
                .ForMember(dest => dest.IsMultiLocation, opt => opt.Ignore())
                .ForMember(dest => dest.OfflineVacancyType, opt => opt.Ignore());

            Mapper.CreateMap<ApiCounty, County>();
            Mapper.CreateMap<ApiLocalAuthority, LocalAuthority>();
            Mapper.CreateMap<ApiRegion, Region>();

            Mapper.CreateMap<EmployerProviderSiteLink, VacancyOwnerRelationship>()
                .ForMember(dest => dest.VacancyOwnerRelationshipId, opt => opt.MapFrom(src => src.EmployerProviderSiteLinkId))
                .ForMember(dest => dest.VacancyOwnerRelationshipGuid, opt => opt.Ignore())
                .ForMember(dest => dest.StatusType, opt => opt.UseValue(VacancyOwnerRelationshipStatusTypes.Live));
        }
    }
}