namespace SFA.DAS.RAA.Api.UnitTests.Strategies
{
    using Api.Strategies;
    using Apprenticeships.Application.VacancyPosting.Strategies;
    using Apprenticeships.Domain.Entities.Raa.Vacancies;
    using Apprenticeships.Domain.Raa.Interfaces.Repositories.Models;
    using Moq;
    using NUnit.Framework;

    [TestFixture]
    [Parallelizable]
    public class GetAllLiveVacancySummariesStrategyTests
    {
        [Test]
        public void PageAndPageSizeAreAddedToQuery()
        {
            const int page = 3;
            const int pageSize = 7;

            var getVacancySummariesStrategy = new Mock<IGetVacancySummaryStrategies>();

            var strategy = new GetAllLiveVacancySummariesStrategy(getVacancySummariesStrategy.Object);

            strategy.GetAllLiveVacancySummaries(page, pageSize);

            int resultsCount;
            getVacancySummariesStrategy.Verify(
                s =>
                    s.GetWithStatus(
                        It.Is<VacancySummaryByStatusQuery>(
                            q =>
                                q.DesiredStatuses.Length == 1 && q.DesiredStatuses[0] == VacancyStatus.Live &&
                                q.RequestedPage == page && q.PageSize == pageSize), out resultsCount));
        }

        [Test]
        public void PageAndPageSizeAreLimited()
        {
            const int page = -3;
            const int pageSize = 777;

            var getVacancySummariesStrategy = new Mock<IGetVacancySummaryStrategies>();

            var strategy = new GetAllLiveVacancySummariesStrategy(getVacancySummariesStrategy.Object);

            strategy.GetAllLiveVacancySummaries(page, pageSize);

            int resultsCount;
            getVacancySummariesStrategy.Verify(
                s =>
                    s.GetWithStatus(
                        It.Is<VacancySummaryByStatusQuery>(
                            q =>
                                q.DesiredStatuses.Length == 1 && q.DesiredStatuses[0] == VacancyStatus.Live &&
                                q.RequestedPage == 1 && q.PageSize == 250), out resultsCount));
        }
    }
}