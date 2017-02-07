namespace SFA.DAS.RAA.Api.Strategies
{
    using System;
    using System.Collections.Generic;
    using Apprenticeships.Application.ReferenceData;
    using Apprenticeships.Domain.Entities.Raa.Reference;
    using Constants;

    public class GetLocalAuthoritiesStrategy : IGetLocalAuthoritiesStrategy
    {
        private readonly IReferenceDataProvider _referenceDataProvider;

        public GetLocalAuthoritiesStrategy(IReferenceDataProvider referenceDataProvider)
        {
            _referenceDataProvider = referenceDataProvider;
        }

        public IEnumerable<LocalAuthority> GetLocalAuthorities()
        {
            return _referenceDataProvider.GetLocalAuthorities();
        }

        public LocalAuthority GetLocalAuthority(int? localAuthorityId = null, string localAuthorityCode = null)
        {
            if (!localAuthorityId.HasValue && string.IsNullOrEmpty(localAuthorityCode))
            {
                throw new ArgumentException(ReferenceMessages.MissingLocalAuthorityIdentifier);
            }

            var localAuthority = localAuthorityId.HasValue ? _referenceDataProvider.GetLocalAuthorityById(localAuthorityId.Value) : _referenceDataProvider.GetLocalAuthorityByCode(localAuthorityCode);

            if (localAuthority == null)
            {
                throw new KeyNotFoundException(ReferenceMessages.LocalAuthorityNotFound);
            }

            return localAuthority;
        }
    }
}