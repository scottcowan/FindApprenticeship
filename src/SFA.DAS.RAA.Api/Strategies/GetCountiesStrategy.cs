namespace SFA.DAS.RAA.Api.Strategies
{
    using System.Collections.Generic;
    using Apprenticeships.Domain.Entities.Raa.Reference;

    public class GetCountiesStrategy : IGetCountiesStrategy
    {
        public IEnumerable<County> GetCounties()
        {
            throw new System.NotImplementedException();
        }

        public County GetCounty(int? countyId = null, string countyCode = null)
        {
            throw new System.NotImplementedException();
        }
    }
}