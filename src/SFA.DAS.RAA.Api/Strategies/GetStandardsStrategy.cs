namespace SFA.DAS.RAA.Api.Strategies
{
    using Apprenticeships.Application.ReferenceData;
    using Apprenticeships.Domain.Entities.Raa.Vacancies;
    using System.Collections.Generic;

    class GetStandardsStrategy : IGetStandardsStrategy
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

        public StandardSubjectAreaTierOne GetStandard(int? standardId = null)
        {
            throw new System.NotImplementedException();
        }
    }
}