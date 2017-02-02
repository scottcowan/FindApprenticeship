namespace SFA.Apprenticeships.Application.Vacancy
{
    using System.Threading.Tasks;
    using Domain.Entities.Vacancies;

    public interface IVacancyDataProvider<TVacancyDetail> where TVacancyDetail : VacancyDetail
    {
        Task<TVacancyDetail> GetVacancyDetails(int vacancyId, bool errorIfNotFound = false);
        int GetVacancyId(int vacancyReferenceNumber);
    }
}
