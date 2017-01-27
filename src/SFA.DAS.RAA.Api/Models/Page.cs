namespace SFA.DAS.RAA.Api.Models
{
    public abstract class Page
    {
        public int TotalCount { get; set; }

        public int CurrentPage { get; set; }

        public int TotalPages { get; set; }
    }
}