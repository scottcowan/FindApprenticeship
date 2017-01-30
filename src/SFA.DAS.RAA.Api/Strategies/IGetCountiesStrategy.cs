namespace SFA.DAS.RAA.Api.Strategies
{
    using System.Collections.Generic;
    using Apprenticeships.Domain.Entities.Raa.Reference;

    public interface IGetCountiesStrategy
    {
        IEnumerable<County> GetCounties();

        County GetCounty(int? countyId = null, string countyCode = null);
    }
}