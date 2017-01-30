namespace SFA.DAS.RAA.Api.Strategies
{
    using Apprenticeships.Domain.Raa.Interfaces.Repositories.Models;
    using Models;

    public interface IGetVacancySummariesStrategy
    {
        VacancySummariesPage GetVacancySummaries(string ukprn, VacanciesSummaryFilterTypes filterType, int page, int pageSize);
    }
}