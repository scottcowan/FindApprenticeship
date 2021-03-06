﻿namespace SFA.Apprenticeships.Infrastructure.Common.Mappers
{
    using Application.Interfaces;
    using AutoMapper;
    using AutoMapper.Mappers;

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
}
