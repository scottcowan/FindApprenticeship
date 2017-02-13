namespace SFA.Apprenticeships.Application.Vacancies
{
    using System.Threading.Tasks;
    using Entities;

    public interface IVacancyIndexDataProvider
    {
        Task<int> GetVacancyPageCount();

        Task<VacancySummaries> GetVacancySummaries(int pageNumber);
    }
}
