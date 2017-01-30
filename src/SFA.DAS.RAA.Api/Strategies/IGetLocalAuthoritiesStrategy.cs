namespace SFA.DAS.RAA.Api.Strategies
{
    using System.Collections.Generic;
    using Apprenticeships.Domain.Entities.Raa.Reference;

    public interface IGetLocalAuthoritiesStrategy
    {
        IEnumerable<LocalAuthority> GetLocalAuthorities();

        LocalAuthority GetLocalAuthority(int? localAuthorityId = null, string localAuthorityCode = null);
    }
}