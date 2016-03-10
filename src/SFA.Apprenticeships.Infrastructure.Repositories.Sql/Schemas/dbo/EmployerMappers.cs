﻿namespace SFA.Apprenticeships.Infrastructure.Repositories.Sql.Schemas.dbo
{
    using Infrastructure.Common.Mappers;
    using DomainEmployer = Domain.Entities.Raa.Parties.Employer;
    using Employer = Entities.Employer;
    using DomainPostalAddress = Domain.Entities.Raa.Locations.PostalAddress;
    using PostalAddress = Address.Entities.PostalAddress;

    public class EmployerMappers : MapperEngine
    {
        public override void Initialise()
        {
            Mapper.CreateMap<Employer, DomainEmployer>()
                .ForMember(v => v.Name, opt => opt.MapFrom(src => src.FullName))
                .AfterMap((v, av) =>
                {
                    av.Address = new DomainPostalAddress
                    {
                        AddressLine1 = v.AddressLine1,
                        AddressLine2 = v.AddressLine2,
                        AddressLine3 = v.AddressLine3,
                        AddressLine4 = v.AddressLine4,
                        AddressLine5 = v.AddressLine5,
                        Postcode = v.PostCode,
                        Town = v.Town
                    };

                    if (v.Latitude.HasValue && v.Longitude.HasValue)
                    {
                        av.Address.GeoPoint = new Domain.Entities.Raa.Locations.GeoPoint
                        {
                            Latitude = (double)v.Latitude.Value,
                            Longitude = (double)v.Longitude.Value
                        };
                    }
                });

            Mapper.CreateMap<DomainEmployer, Employer>()
                .ForMember(v => v.FullName, opt => opt.MapFrom(src => src.Name))
                .ForMember(v => v.AddressLine1, opt => opt.MapFrom(src => src.Address.AddressLine1))
                .ForMember(v => v.AddressLine2, opt => opt.MapFrom(src => src.Address.AddressLine2))
                .ForMember(v => v.AddressLine3, opt => opt.MapFrom(src => src.Address.AddressLine3))
                .ForMember(v => v.AddressLine4, opt => opt.MapFrom(src => src.Address.AddressLine4))
                .ForMember(v => v.AddressLine5, opt => opt.MapFrom(src => src.Address.AddressLine5))
                .ForMember(v => v.PostCode, opt => opt.MapFrom(src => src.Address.Postcode))
                .ForMember(v => v.Town, opt => opt.MapFrom(src => src.Address.Town))
                .ForMember(v => v.Latitude, opt => opt.MapFrom(src => (decimal)src.Address.GeoPoint.Latitude))  // use a converter?
                .ForMember(v => v.Longitude, opt => opt.MapFrom(src => (decimal)src.Address.GeoPoint.Longitude)); // use a converter?;
        }
    }
}
