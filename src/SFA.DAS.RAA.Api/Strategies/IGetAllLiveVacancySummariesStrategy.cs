namespace SFA.DAS.RAA.Api.Strategies
{
    using System.Threading.Tasks;
    using Models;

    public interface IGetAllLiveVacancySummariesStrategy
    {
        Task<PublicVacancySummariesPage> GetAllLiveVacancySummaries(int page, int pageSize);
    }
}