namespace SFA.DAS.RAA.Api.Strategies
{
    using Apprenticeships.Application.ReferenceData;
    using Apprenticeships.Domain.Entities.Raa.Reference;
    using Constants;
    using System;
    using System.Collections.Generic;

    public class GetCountiesStrategy : IGetCountiesStrategy
    {
        private readonly IReferenceDataProvider _referenceDataProvider;

        public GetCountiesStrategy(IReferenceDataProvider referenceDataProvider)
        {
            _referenceDataProvider = referenceDataProvider;
        }

        public IEnumerable<County> GetCounties()
        {
            return _referenceDataProvider.GetCounties();
        }

        public County GetCounty(int? countyId = null, string countyCode = null)
        {
            if (!countyId.HasValue && string.IsNullOrEmpty(countyCode))
            {
                throw new ArgumentException(ReferenceMessages.MissingCountyIdentifier);
            }

            var county = countyId.HasValue ? _referenceDataProvider.GetCountyById(countyId.Value) : _referenceDataProvider.GetCountyByCode(countyCode);

            if (county == null)
            {
                throw new KeyNotFoundException(ReferenceMessages.CountyNotFound);
            }

            return county;
        }
    }
}