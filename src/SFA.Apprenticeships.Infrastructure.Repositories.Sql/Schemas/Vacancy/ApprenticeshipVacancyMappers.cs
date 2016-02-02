﻿namespace SFA.Apprenticeships.Infrastructure.Repositories.Sql.Schemas.Vacancy
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq.Expressions;
    using AutoMapper;
    using AutoMapper.Mappers;
    using Domain.Entities.Locations;
    using Domain.Entities.Providers;
    using Domain.Entities.Vacancies;
    using Domain.Entities.Vacancies.ProviderVacancies;
    using Domain.Entities.Vacancies.ProviderVacancies.Apprenticeship;
    using SFA.Infrastructure.Interfaces;
    using VacancyLocationType = Sql.Schemas.Vacancy.Entities.VacancyLocationType;

    /// <summary>
    /// TODO: Copied because I don't want to depend on SFA.Apprenticeships.Infrastructure.Common.Mappers because this depends on lots of other things
    /// But don't want to move it to SFA.Infrastructure project because that would then depend on AutoMapper
    /// </summary>
    public abstract class MapperEngine : IMapper
    {
        private readonly IMappingEngine _mappingEngine;

        protected MapperEngine()
        {
            Mapper = new ConfigurationStore(new TypeMapFactory(), MapperRegistry.Mappers);
            _mappingEngine = new MappingEngine(Mapper);
            Initialise();
        }

        public ConfigurationStore Mapper { get; private set; }

        public TDestination Map<TSource, TDestination>(TSource sourceObject)
        {
            return _mappingEngine.Map<TDestination>(sourceObject);
        }

        public abstract void Initialise();
    }

    public class ApprenticeshipVacancyMappers : MapperEngine
    {
        public override void Initialise()
        {
            var wageTypeMap = new CodeEnumMap<WageType>
            {
                { "NAP", 0},
                { "AMW", WageType.ApprenticeshipMinimumWage },
                { "NMW", WageType.NationalMinimumWage },
                { "CUS", WageType.Custom }
            };

            var wageUnitMap = new CodeEnumMap<WageUnit>
            {
                { "N", WageUnit.NotApplicable },
                { "W", WageUnit.Weekly },
                { "M", WageUnit.Monthly },
                { "A", WageUnit.Annually },
            };

            var durationTypeMap = new CodeEnumMap<DurationType>
            {
                { "U", DurationType.Unknown },
                { "W", DurationType.Weeks },
                { "M", DurationType.Months },
                { "Y", DurationType.Years }
            };

            var trainingTypeMap = new CodeEnumMap<TrainingType>
            {
                { "F", TrainingType.Frameworks },
                { "S", TrainingType.Standards },
                { "U", TrainingType.Unknown }, // TODO: null = blank??
            };

            var apprenticeshipLevelMap = new CodeEnumMap<ApprenticeshipLevel>
            {
                { "2", ApprenticeshipLevel.Intermediate },
                { "3", ApprenticeshipLevel.Advanced },
                { "6", ApprenticeshipLevel.Degree },
                { "5", ApprenticeshipLevel.FoundationDegree },
                { "4", ApprenticeshipLevel.Higher },
                { "7", ApprenticeshipLevel.Masters },
                { "0", ApprenticeshipLevel.Unknown } // TODO: review
            };

            var vacancyStatusMap = new CodeEnumMap<ProviderVacancyStatuses>
            {
                { "LIV", ProviderVacancyStatuses.Live },
                { "CLD", ProviderVacancyStatuses.Closed },
                { "DRA", ProviderVacancyStatuses.Draft },
                { "PQA", ProviderVacancyStatuses.PendingQA },
                { "REF", ProviderVacancyStatuses.RejectedByQA },
                { "RES", ProviderVacancyStatuses.ReservedForQA },
                { "PAR", ProviderVacancyStatuses.ParentVacancy },
                { "UNK", ProviderVacancyStatuses.Unknown}
            };

            Mapper.CreateMap<string, ProviderVacancyStatuses>().ConvertUsing(code => vacancyStatusMap.CodeToEnum[code]);
            Mapper.CreateMap<ProviderVacancyStatuses, string>().ConvertUsing(status => vacancyStatusMap.EnumToCode[status]);
            
            Mapper.CreateMap<ApprenticeshipVacancy, Entities.Vacancy>()
                .MapMemberFrom(v => v.WorkingWeekText, av => av.WorkingWeek)
                .MapMemberFrom(v => v.WageTypeCode, av => wageTypeMap.EnumToCode[av.WageType])
                .MapMemberFrom(v => v.WageIntervalCode, av => wageUnitMap.EnumToCode[av.WageUnit])
                .MapMemberFrom(v => v.WageValue, av => av.Wage)
                .MapMemberFrom(v => v.DurationTypeCode, av => durationTypeMap.EnumToCode[av.DurationType])
                .MapMemberFrom(v => v.DurationValue, av => av.Duration)
                .MapMemberFrom(v => v.AV_InterviewStartDate, av => av.InterviewStartDate)
                .MapMemberFrom(v => v.TrainingTypeCode, av => trainingTypeMap.EnumToCode[av.TrainingType])
                .MapMemberFrom( v=> v.VacancyStatusCode, av => av.Status)
                .MapMemberFrom(v => v.LevelCode, av => apprenticeshipLevelMap.EnumToCode[av.ApprenticeshipLevel])
                .MapMemberFrom(v => v.LevelCodeComment, av => av.ApprenticeshipLevelComment)
                .MapMemberFrom(v => v.VacancyId, av => av.EntityId)
                .MapMemberFrom(v => v.FrameworkIdComment, av => av.FrameworkCodeNameComment)
                .MapMemberFrom(v => v.EmployerWebsiteUrl, av => av.ProviderSiteEmployerLink.WebsiteUrl)
                .MapMemberFrom(v => v.EmployerDescription, av => av.ProviderSiteEmployerLink.Description)
                .MapMemberFrom(v => v.PublishedDateTime, av => av.DateQAApproved) // TODO: Believed to be correct - no, wrong -> changed to DateQAApproved, believed to be correct
                .MapMemberFrom(v => v.FirstSubmittedDateTime, av => av.DateFirstSubmitted) // TODO: Believed to be correct
                .MapMemberFrom(v => v.VacancyTypeCode, av => "A") // Always Apprenticeship (mapping from ApprenticeshipVacancy!!)
                .MapMemberFrom(v => v.VacancyLocationTypeCode, av => av.IsEmployerLocationMainApprenticeshipLocation.GetValueOrDefault() ? VacancyLocationType.Employer : VacancyLocationType.Specific)

                // TODO: Change ApprenticeshipVacancy object in due course
                .MapMemberFrom(v => v.DirectApplicationInstructions, av => av.OfflineApplicationInstructions)
                .MapMemberFrom(v => v.DirectApplicationInstructionsComment, av => av.OfflineApplicationInstructionsComment)
                .MapMemberFrom(v => v.DirectApplicationUrl, av => av.OfflineApplicationUrl)
                .MapMemberFrom(v => v.DirectApplicationUrlComment, av => av.OfflineApplicationUrlComment)
                .MapMemberFrom(v => v.IsDirectApplication, av => av.OfflineVacancy)
                .MapMemberFrom(v => v.ParentVacancyId, av => av.ParentVacancyId)

                // These are mapped via database lookups -> no need to do anything here
                .IgnoreMember(v => v.OriginalContractOwnerVacancyPartyId) // TODO -> done in sql
                .IgnoreMember(v => v.EmployerVacancyPartyId) // ProviderSiteEmployerLink.Employer.Ern
                .IgnoreMember(v => v.ContractOwnerVacancyPartyId) // UKPrn
                .IgnoreMember(v => v.DeliveryProviderVacancyPartyId) // UKPrn
                .IgnoreMember(v => v.ManagerVacancyPartyId) // UKPrn
                .IgnoreMember(v => v.OwnerVacancyPartyId) // UKPrn
                .IgnoreMember(v => v.FrameworkId)

                // Just been hacked so that updates don't fail -> vacancy lookup?

                // TODO: Missing from ApprenticeshipVacancy - add as part of other refactoring
                .ForMember(v => v.AV_WageText, opt => opt.Ignore())
                .ForMember(v => v.AV_ContactName, opt => opt.Ignore()) // TODO: I think this has been added back in as a requirement or needs renaming to AV_ContactDetails - check AVMS

                .MapMemberFrom(v => v.TimeStartedToQA, av => av.DateStartedToQA)
                .MapMemberFrom(v => v.CreatedDateTime, av => av.DateCreated)
                .MapMemberFrom(v => v.UpdatedDateTime, av => av.DateUpdated)
                .MapMemberFrom(v => v.SubmittedDateTime, av => av.DateSubmitted)

                .End();

            Mapper.CreateMap<Entities.Vacancy, ApprenticeshipVacancy>()
                .MapMemberFrom(av => av.WorkingWeek, v => v.WorkingWeekText)
                .MapMemberFrom(av => av.WageType, v => wageTypeMap.CodeToEnum[v.WageTypeCode])
                .MapMemberFrom(av => av.WageUnit, v => wageUnitMap.CodeToEnum[v.WageIntervalCode])
                .MapMemberFrom(av => av.Wage, v => v.WageValue)
                .MapMemberFrom(av => av.DurationType, v => durationTypeMap.CodeToEnum[v.DurationTypeCode])
                .MapMemberFrom(av => av.Duration, v => v.DurationValue)
                .MapMemberFrom(av => av.InterviewStartDate, v => v.AV_InterviewStartDate)
                .MapMemberFrom(av => av.TrainingType, v => trainingTypeMap.CodeToEnum[v.TrainingTypeCode])
                .MapMemberFrom(av => av.Status, v => v.VacancyStatusCode)
                .MapMemberFrom(av => av.ApprenticeshipLevel, v => apprenticeshipLevelMap.CodeToEnum[v.LevelCode])
                .MapMemberFrom(av => av.ApprenticeshipLevelComment, v => v.LevelCodeComment)
                .MapMemberFrom(av => av.EntityId, v => v.VacancyId)
                .MapMemberFrom(av => av.FrameworkCodeNameComment, v => v.FrameworkIdComment)
                .MapMemberFrom(av => av.DateQAApproved, v => v.PublishedDateTime) // TODO: Believed to be correct -> I think it should be OK now (change dto DateQAApproved)
                .MapMemberFrom(av => av.DateFirstSubmitted, v => v.FirstSubmittedDateTime) 
                .MapMemberFrom(av => av.IsEmployerLocationMainApprenticeshipLocation, v => v.VacancyLocationTypeCode == VacancyLocationType.Employer)

                // TODO: Change ApprenticeshipVacancy object in due course
                .MapMemberFrom(av => av.OfflineApplicationInstructions, v => v.DirectApplicationInstructions)
                .MapMemberFrom(av => av.OfflineApplicationInstructionsComment, v => v.DirectApplicationInstructionsComment)
                .MapMemberFrom(av => av.OfflineApplicationUrl, v => v.DirectApplicationUrl)
                .MapMemberFrom(av => av.OfflineApplicationUrlComment, v => v.DirectApplicationUrlComment)
                .MapMemberFrom(av => av.OfflineVacancy, v => v.IsDirectApplication)

                // Need to map the following separately
                .ForMember(av => av.Ukprn, opt => opt.Ignore())
                .ForMember(av => av.FrameworkCodeName, opt => opt.Ignore())
                .ForMember(av => av.LocationAddresses, opt => opt.Ignore())

                // TODO: Currently missing from Vacancy.Vacancy
                .ForMember(av => av.LastEditedById, opt => opt.Ignore()) // TODO: Provider User Guid -> we need to create this property
                .ForMember(av => av.VacancyManagerId, opt => opt.Ignore()) // TODO: Think -> database lookup? -> we need to create this property
                .MapMemberFrom(av => av.LastEditedById, v => v.LastEditedById)
                .MapMemberFrom(av => av.VacancyManagerId, v => v.VacancyManagerId)
                .MapMemberFrom(av => av.ParentVacancyId, v => v.ParentVacancyId)

                .MapMemberFrom(av => av.DateStartedToQA, v => v.TimeStartedToQA)
                .MapMemberFrom(av => av.DateCreated, v => v.CreatedDateTime)
                .MapMemberFrom(av => av.DateUpdated, v => v.UpdatedDateTime)
                .MapMemberFrom(av => av.DateSubmitted, v => v.SubmittedDateTime)

                .ForMember(av => av.ProviderSiteEmployerLink, opt => opt.Ignore())
                .AfterMap((v, av) => 
                {
                    av.ProviderSiteEmployerLink = new ProviderSiteEmployerLink()
                    {
                        WebsiteUrl = v.EmployerWebsiteUrl,
                        Description = v.EmployerDescription,
                    };
                })

                .End();

            Mapper.CreateMap<PostalAddress, Schemas.Address.Entities.PostalAddress>()
                .MapMemberFrom(a => a.Latitude, a => a.GeoPoint == null ? null : (decimal?)a.GeoPoint.Latitude)
                .MapMemberFrom(a => a.Longitude, a => a.GeoPoint == null ? null : (decimal?)a.GeoPoint.Longitude)

                .MapMemberFrom(a => a.PostTown, a => a.Town)

                // TODO: Remove from Vacancy.Vacancy?
                .IgnoreMember(a => a.Easting)
                .IgnoreMember(a => a.Northing)

                // TODO: Not in model and may not need to be
                .IgnoreMember(a => a.PostalAddressId) // TODO: Need to add to round-trip...?
                .MapMemberFrom(a => a.DateValidated, a => (DateTime?)null) // Why?
                .MapMemberFrom(a => a.CountyId, a => (int?)null) // done via database lookup -> TODO

                //        .ForMember(a => a.Uprn, opt => opt.Ignore()) // TODO
                ;

            Mapper.CreateMap<Schemas.Address.Entities.PostalAddress, PostalAddress>()
                //.ForMember(a => a.Uprn, opt => opt.Ignore()) // TODO: What is this??
                .MapMemberFrom(a => a.GeoPoint, a => (a.Latitude == null || a.Longitude == null) ? null : new GeoPoint() { Latitude = (double)a.Latitude, Longitude = (double)a.Longitude })
                .MapMemberFrom(a => a.Town, a => a.PostTown)
                .IgnoreMember(a => a.County) // Done by database lookup -> TODO
                // TODO: Hacks
                //.MapMemberFrom(a => a.AddressLine4, a => (a.AddressLine4 + " " + a.AddressLine5).TrimEnd())
                ;
        }
    }

    public static class IMappingExpressionExtensions
    {
        public static IMappingExpression<TSource, TDestination> MapMemberFrom<TSource, TDestination, TMember>(
            this IMappingExpression<TSource, TDestination> mappingExpression,
            Expression<Func<TDestination, object>> destinationMember,
            Expression<Func<TSource, TMember>> mapFunction)
        {
            return mappingExpression.ForMember(destinationMember, opt => opt.MapFrom<TMember>(mapFunction));
        }

        public static IMappingExpression<TSource, TDestination> IgnoreMember<TSource, TDestination>(
            this IMappingExpression<TSource, TDestination> mappingExpression,
            Expression<Func<TDestination, object>> destinationMember)
        {
            return mappingExpression.ForMember(destinationMember, opt => opt.Ignore());
        }

        /// <summary>
        /// Handy when mappings are being edited so that the terminating ; doesn't keeping moving
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TDestination"></typeparam>
        /// <param name="mappingExpression"></param>
        public static void End<TSource, TDestination>(
            this IMappingExpression<TSource, TDestination> mappingExpression)
        { }
    }

    public class CodeEnumMap<T> : IEnumerable<KeyValuePair<string, T>>
    {
        private Map<string, T> _map;

        public CodeEnumMap()
        {
            _map = new Map<string, T>();
        }

        public void Add(string codeValue, T enumValue)
        {
            _map.Add(codeValue ?? "**NULL**", enumValue); // TODO: Outside the otherwise
        }

        public IEnumerator<KeyValuePair<string, T>> GetEnumerator()
        {
            return _map.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _map.GetEnumerator(); // TODO: Call the right one
        }

        public Map<string, T>.Indexer<string, T> CodeToEnum { get { return _map.Forward; } }
        public Map<string, T>.Indexer<T, string> EnumToCode { get { return _map.Reverse; } }
    }

    public class Map<T1, T2> : IEnumerable<KeyValuePair<T1, T2>>
    {
        private Dictionary<T1, T2> _forward = new Dictionary<T1, T2>();
        private Dictionary<T2, T1> _reverse = new Dictionary<T2, T1>();

        public Map()
        {
            this.Forward = new Indexer<T1, T2>(_forward);
            this.Reverse = new Indexer<T2, T1>(_reverse);
        }

        public class Indexer<T3, T4>
        {
            private Dictionary<T3, T4> _dictionary;
            public Indexer(Dictionary<T3, T4> dictionary)
            {
                _dictionary = dictionary;
            }
            public T4 this[T3 index]
            {
                get { return _dictionary[index]; }
                set { _dictionary[index] = value; }
            }
        }

        public void Add(T1 t1, T2 t2)
        {
            _forward.Add(t1, t2);
            _reverse.Add(t2, t1);
        }

        public IEnumerator<KeyValuePair<T1, T2>> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public Indexer<T1, T2> Forward { get; private set; }
        public Indexer<T2, T1> Reverse { get; private set; }

        public T2 this[T1 index]
        {
            get { return Forward[index]; }
        }
    }
}