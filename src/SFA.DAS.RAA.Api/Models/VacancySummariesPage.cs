namespace SFA.DAS.RAA.Api.Models
{
    using System.Collections.Generic;
    using Apprenticeships.Domain.Entities.Raa.Vacancies;

    public class VacancySummariesPage
    {
        public IList<VacancySummary> VacancySummaries { get; set; }

        public int TotalCount { get; set; }

        public int CurrentPage { get; set; }

        public int TotalPages { get; set; }
    }
}