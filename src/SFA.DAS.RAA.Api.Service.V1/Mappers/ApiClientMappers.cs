namespace SFA.DAS.RAA.Api.Service.V1.Mappers
{
    using Apprenticeships.Domain.Entities.Raa.Parties;
    using Apprenticeships.Infrastructure.Common.Mappers;
    using Client.V1.Models;
    using ApiGeoPoint = Client.V1.Models.GeoPoint;
    using ApiPostalAddress = Client.V1.Models.PostalAddress;
    using ApiWage = Client.V1.Models.Wage;
    using ApiVacancy = Client.V1.Models.Vacancy;
    using ApiWageUpdate = Client.V1.Models.WageUpdate;
    using ApiCounty = Client.V1.Models.County;
    using ApiLocalAuthority = Client.V1.Models.LocalAuthority;
    using ApiRegion = Client.V1.Models.Region;
    using GeoPoint = Apprenticeships.Domain.Entities.Raa.Locations.GeoPoint;
    using PostalAddress = Apprenticeships.Domain.Entities.Raa.Locations.PostalAddress;
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
            Mapper.CreateMap<ApiVacancy, Vacancy>();
            Mapper.CreateMap<WageUpdate, ApiWageUpdate>();

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