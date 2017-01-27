namespace SFA.DAS.RAA.Api.Strategies
{
    using Models;

    public interface IGetAllLiveVacancySummariesStrategy
    {
        VacancySummariesPage GetAllLiveVacancySummaries(int page, int pageSize);
    }
}