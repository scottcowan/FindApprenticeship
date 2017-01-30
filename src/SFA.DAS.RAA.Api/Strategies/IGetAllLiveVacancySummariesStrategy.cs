namespace SFA.DAS.RAA.Api.Strategies
{
    using Models;

    public interface IGetAllLiveVacancySummariesStrategy
    {
        PublicVacancySummariesPage GetAllLiveVacancySummaries(int page, int pageSize);
    }
}