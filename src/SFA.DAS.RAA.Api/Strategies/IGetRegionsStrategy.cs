namespace SFA.DAS.RAA.Api.Strategies
{
    using System.Collections.Generic;
    using Apprenticeships.Domain.Entities.Raa.Reference;

    public interface IGetRegionsStrategy
    {
        IEnumerable<Region> GetRegions();

        Region GetRegion(int? regionId = null, string regionCode = null);
    }
}