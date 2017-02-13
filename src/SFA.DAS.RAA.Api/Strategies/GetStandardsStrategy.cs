namespace SFA.DAS.RAA.Api.Strategies
{
    using Apprenticeships.Application.ReferenceData;
    using Apprenticeships.Domain.Entities.Raa.Reference;
    using Apprenticeships.Domain.Entities.Raa.Vacancies;
    using Constants;
    using System;
    using System.Collections.Generic;

    public class GetStandardsStrategy : IGetStandardsStrategy
    {
        private readonly IReferenceDataProvider _referenceDataProvider;

        public GetStandardsStrategy(IReferenceDataProvider referenceDataProvider)
        {
            _referenceDataProvider = referenceDataProvider;
        }
        public IEnumerable<StandardSubjectAreaTierOne> GetStandards()
        {
            return _referenceDataProvider.GetStandardSubjectAreaTierOnes();
        }

        public Standard GetStandard(int? standardId = null)
        {
            if (!standardId.HasValue)
            {
                throw new ArgumentException(ReferenceMessages.MissingStandardIdentifier);
            }

            var standard = _referenceDataProvider.GetStandardById(standardId.Value);

            if (standard == null || standard.Status != FrameworkStatusType.Active)
            {
                throw new KeyNotFoundException(ReferenceMessages.StandardNotFound);
            }
            return standard;
        }
    }
}