using SFA.Apprenticeships.Domain.Raa.Interfaces.Repositories.Models;

namespace SFA.DAS.RAA.Api.Models
{
    using System.Collections.Generic;
    using Apprenticeships.Domain.Entities.Raa.Vacancies;

    public class VacancySummariesPage : Page
    {
        public IList<VacancySummary> VacancySummaries { get; set; }
    }
}