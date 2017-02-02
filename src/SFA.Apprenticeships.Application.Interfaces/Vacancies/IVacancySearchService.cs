namespace SFA.Apprenticeships.Application.Interfaces.Vacancies
{
    using System.Threading.Tasks;
    using Domain.Entities.Vacancies;
    using Search;

    public interface IVacancySearchService<TVacancySummaryResponse, TVacancyDetail, TSearchParameters> 
        where TVacancySummaryResponse : VacancySummary
        where TVacancyDetail : VacancyDetail
        where TSearchParameters : VacancySearchParametersBase
    {
        /// <summary>
        /// returns vacancies matching search criteria
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns>0..* matching vacancies</returns>
        SearchResults<TVacancySummaryResponse, TSearchParameters> Search(TSearchParameters parameters);

        /// <summary>
        /// returns vacancy details
        /// </summary>
        /// <param name="vacancyId">id for the vacancy to retrieve</param>
        /// <returns>vacancy detail or null</returns>
        Task<TVacancyDetail> GetVacancyDetails(int vacancyId);

        int GetVacancyId(int vacancyReferenceNumber);
    }
}
