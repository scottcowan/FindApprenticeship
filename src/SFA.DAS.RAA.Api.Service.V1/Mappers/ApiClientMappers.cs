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
                .ForMember(dest => dest.VacancyOwnerRelationshipId, opt => opt.Ignore())
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
                .ForMember(dest => dest.ContractOwnerId, opt => opt.Ignore())
                .ForMember(dest => dest.OriginalContractOwnerId, opt => opt.Ignore())
                .ForMember(dest => dest.RegionalTeam, opt => opt.Ignore())
                .ForMember(dest => dest.EmployerLocation, opt => opt.Ignore())
                .ForMember(dest => dest.NewApplicationCount, opt => opt.Ignore())
                .ForMember(dest => dest.ApplicantCount, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedDate, opt => opt.Ignore())
                .ForMember(dest => dest.IsMultiLocation, opt => opt.Ignore());
            //Mapper.CreateMap<PublicVacancy, Vacancy>();

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