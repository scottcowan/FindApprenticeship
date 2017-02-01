namespace SFA.DAS.RAA.Api.Strategies
{
    using Apprenticeships.Application.ReferenceData;
    using Apprenticeships.Domain.Entities.Raa.Reference;
    using Apprenticeships.Domain.Entities.ReferenceData;
    using Constants;
    using System;
    using System.Collections.Generic;

    public class GetFrameworksStrategy : IGetFrameworksStrategy
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

        public Framework GetFramework(int? frameworkId = null)
        {
            if (!frameworkId.HasValue)
            {
                throw new ArgumentException(ReferenceMessages.MissingFrameworkIdentifier);
            }

            var framework = _referenceDataProvider.GetFrameworkById(frameworkId.Value);

            if (framework == null || framework.Status != FrameworkStatusType.Active)
            {
                throw new KeyNotFoundException(ReferenceMessages.FrameworkNotFound);
            }

            return framework;
        }
    }
}