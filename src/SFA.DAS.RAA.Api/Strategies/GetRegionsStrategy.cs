namespace SFA.DAS.RAA.Api.Strategies
{
    using System;
    using System.Collections.Generic;
    using Apprenticeships.Application.ReferenceData;
    using Apprenticeships.Domain.Entities.Raa.Reference;
    using Constants;

    public class GetRegionsStrategy : IGetRegionsStrategy
    {
        private readonly IReferenceDataProvider _referenceDataProvider;

        public GetRegionsStrategy(IReferenceDataProvider referenceDataProvider)
        {
            _referenceDataProvider = referenceDataProvider;
        }

        public IEnumerable<Region> GetRegions()
        {
            return _referenceDataProvider.GetRegions();
        }

        public Region GetRegion(int? regionId = null, string regionCode = null)
        {
            if (!regionId.HasValue && string.IsNullOrEmpty(regionCode))
            {
                throw new ArgumentException(ReferenceMessages.MissingRegionIdentifier);
            }

            var region = regionId.HasValue ? _referenceDataProvider.GetRegionById(regionId.Value) : _referenceDataProvider.GetRegionByCode(regionCode);

            if (region == null)
            {
                throw new KeyNotFoundException(ReferenceMessages.RegionNotFound);
            }

            return region;
        }
    }
}