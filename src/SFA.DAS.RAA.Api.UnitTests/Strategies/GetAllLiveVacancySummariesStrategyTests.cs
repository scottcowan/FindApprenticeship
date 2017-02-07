namespace SFA.DAS.RAA.Api.UnitTests.Strategies
{
    using System.Threading.Tasks;
    using Api.Strategies;
    using Apprenticeships.Domain.Entities.Raa.Vacancies;
    using Apprenticeships.Domain.Raa.Interfaces.Repositories;
    using Apprenticeships.Domain.Raa.Interfaces.Repositories.Models;
    using Moq;
    using NUnit.Framework;

    [TestFixture]
    [Parallelizable]
    public class GetAllLiveVacancySummariesStrategyTests
    {
        [Test]
        public async Task PageAndPageSizeAreAddedToQuery()
        {
            const int page = 3;
            const int pageSize = 7;

            var vacancySummaryRepository = new Mock<IVacancySummaryRepository>();
            vacancySummaryRepository.Setup(r => r.GetByStatusAsync(It.IsAny<VacancySummaryByStatusQuery>())).Returns(Task.FromResult(new ListWithTotalCount<VacancySummary>()));

            var strategy = new GetAllLiveVacancySummariesStrategy(vacancySummaryRepository.Object);

            await strategy.GetAllLiveVacancySummaries(page, pageSize);

            vacancySummaryRepository.Verify(
                s =>
                    s.GetByStatusAsync(
                        It.Is<VacancySummaryByStatusQuery>(
                            q =>
                                q.DesiredStatuses.Length == 1 && q.DesiredStatuses[0] == VacancyStatus.Live &&
                                q.RequestedPage == page && q.PageSize == pageSize)));
        }

        [Test]
        public async Task PageAndPageSizeAreLimited()
        {
            const int page = -3;
            const int pageSize = 777;

            var vacancySummaryRepository = new Mock<IVacancySummaryRepository>();

            var strategy = new GetAllLiveVacancySummariesStrategy(vacancySummaryRepository.Object);
            vacancySummaryRepository.Setup(r => r.GetByStatusAsync(It.IsAny<VacancySummaryByStatusQuery>())).Returns(Task.FromResult(new ListWithTotalCount<VacancySummary>()));

            await strategy.GetAllLiveVacancySummaries(page, pageSize);

            vacancySummaryRepository.Verify(
                s =>
                    s.GetByStatusAsync(
                        It.Is<VacancySummaryByStatusQuery>(
                            q =>
                                q.DesiredStatuses.Length == 1 && q.DesiredStatuses[0] == VacancyStatus.Live &&
                                q.RequestedPage == 1 && q.PageSize == 250)));
        }
    }
}