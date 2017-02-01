namespace SFA.DAS.RAA.Api.Strategies
{
    using Apprenticeships.Domain.Entities.ReferenceData;
    using System.Collections.Generic;

    /// <summary>
    /// Gets Standards
    /// </summary>
    public interface IGetFrameworksStrategy
    {
        /// <summary>
        /// Gets all standards 
        /// </summary>
        /// <returns></returns>
        IEnumerable<Category> GetFrameworks();

        /// <summary>
        /// Gets standard by Id
        /// </summary>
        /// <param name="categoryId"></param>
        /// <returns></returns>
        Category GetFramework(int? categoryId = null);
    }
}