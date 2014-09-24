﻿namespace SFA.Apprenticeships.Infrastructure.LegacyWebServices.Mappers
{
    using System;
    using AutoMapper;
    using Domain.Entities.Vacancies;

    public class VacancyLocationTypeResolver : ValueResolver<string, VacancyLocationType>
    {
        protected override VacancyLocationType ResolveCore(string source)
        {
            if (source == null)
            {
                return VacancyLocationType.Unknown;
            }
           
            switch (source)
            {
                case "National":
                //TODO HACK HACK HACK - REMOVE THIS HACK!!!
                case "IntermediateLevelApprenticeship":
                    return VacancyLocationType.National;
                case "Standard":
                case "MultipleLocation":
                //TODO HACK HACK HACK - REMOVE THIS HACK!!!
                case "AdvancedLevelApprenticeship":
                case "HigherApprenticeship":
                    // TODO: DONTKNOW: MultiLocation are posted once for each location so are equivelent to NonNational but needs backed by requirements in new system.
                    return VacancyLocationType.NonNational;
                default:
                    throw new ArgumentException(
                        string.Format(
                            "The vacancy location is not valid: {0}, it must be either National or Standard to map correctly",
                            source));
            }
        }
    }
}
