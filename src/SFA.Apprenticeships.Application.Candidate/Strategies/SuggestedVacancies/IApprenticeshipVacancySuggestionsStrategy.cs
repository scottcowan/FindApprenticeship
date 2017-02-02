namespace SFA.Apprenticeships.Application.Candidate.Strategies.SuggestedVacancies
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Domain.Entities.Applications;
    using Domain.Entities.Vacancies;
    using Interfaces.Search;
    using Interfaces.Vacancies;

    public interface IApprenticeshipVacancySuggestionsStrategy
    {
        Task<SearchResults<ApprenticeshipSearchResponse, ApprenticeshipSearchParameters>> GetSuggestedApprenticeshipVacancies(
            ApprenticeshipSearchParameters searchParameters, IList<ApprenticeshipApplicationSummary> candidateApplications, int vacancyId);
    }
}
