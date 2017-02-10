namespace SFA.DAS.RAA.Api.Strategies
{
    using Apprenticeships.Domain.Entities.Raa.Vacancies;
    using System.Collections.Generic;

    /// <summary>
    /// Gets Standards
    /// </summary>
    public interface IGetStandardsStrategy
    {
        /// <summary>
        /// Gets all standards 
        /// </summary>
        /// <returns></returns>
        IEnumerable<StandardSubjectAreaTierOne> GetStandards();

        /// <summary>
        /// Gets standard by Id
        /// </summary>
        /// <param name="standardId"></param>
        /// <returns></returns>
        Standard GetStandard(int? standardId = null);
    }
}