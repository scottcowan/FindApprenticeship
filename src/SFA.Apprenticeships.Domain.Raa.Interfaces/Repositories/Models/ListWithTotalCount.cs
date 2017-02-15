namespace SFA.Apprenticeships.Domain.Raa.Interfaces.Repositories.Models
{
    using System.Collections.Generic;

    public class ListWithTotalCount<T> : List<T>
    {
        public ListWithTotalCount(IEnumerable<T> list, int totalCount) : base(list)
        {
            TotalCount = totalCount;
        }
        public int TotalCount { get; set; }
    }
}