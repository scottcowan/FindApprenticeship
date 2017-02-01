namespace SFA.DAS.RAA.Api.Strategies
{
    using Apprenticeships.Application.ReferenceData;
    using Apprenticeships.Domain.Entities.ReferenceData;
    using System.Collections.Generic;

    class GetFrameworksStrategy : IGetFrameworksStrategy
    {
        private readonly IReferenceDataProvider _referenceDataProvider;

        public GetFrameworksStrategy(IReferenceDataProvider referenceDataProvider)
        {
            _referenceDataProvider = referenceDataProvider;
        }
        public IEnumerable<Category> GetFrameworks()
        {
            return _referenceDataProvider.GetFrameworks();
        }

        public Category GetFramework(int? frameworkId = null)
        {
            throw new System.NotImplementedException();
        }
    }
}