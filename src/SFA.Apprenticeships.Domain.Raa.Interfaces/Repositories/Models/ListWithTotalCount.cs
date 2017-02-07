namespace SFA.Apprenticeships.Domain.Raa.Interfaces.Repositories.Models
{
    using System.Collections.Generic;

    public class ListWithTotalCount<T>
    {
        public IList<T> List { get; set; }

        public int TotalCount { get; set; }
    }
}