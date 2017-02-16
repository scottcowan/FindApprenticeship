using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SFA.DAS.RAA.Api.UnitTests.Strategies
{
    using Api.Strategies;
    using Apprenticeships.Domain.Entities.Raa.Parties;
    using Apprenticeships.Domain.Entities.Raa.Vacancies;
    using Apprenticeships.Domain.Raa.Interfaces.Repositories;
    using Apprenticeships.Domain.Raa.Interfaces.Repositories.Models;
    using Moq;
    using NUnit.Framework;

    [TestFixture]
    [Parallelizable]
    public class GetVacancySummariesStrategyTests
    {
        [Test]
        public async Task AllParametersAreAddedToQuery()
        {
            const int page = 3;
            const int pageSize = 7;

            var vacancySummaryRepository = new Mock<IVacancySummaryRepository>();
            vacancySummaryRepository.Setup(r => r.GetLiveAsync(It.IsAny<VacancySummaryByStatusQuery>())).Returns(Task.FromResult(new ListWithTotalCount<VacancySummary>(new List<VacancySummary>(), 0)));

            var providerSiteRepository = new Mock<IProviderSiteReadRepository>();
            providerSiteRepository.Setup(s => s.GetByProviderId(It.IsAny<int>()))
                .Returns(() => new List<ProviderSite> {new ProviderSite() {ProviderSiteId = 1}});

            var vacancySummaryReadRepository = new Mock<IProviderReadRepository>();
            vacancySummaryReadRepository.Setup(r => r.GetByUkprn(It.IsAny<string>(), It.IsAny<bool>()))
                .Returns(() => new Provider() {ProviderId = 1});

            var strategy = new GetVacancySummariesStrategy(vacancySummaryReadRepository.Object, providerSiteRepository.Object, vacancySummaryRepository.Object);

            await strategy.GetVacancySummaries("123", "Test", VacanciesSummaryFilterTypes.Closed,
                VacancySearchMode.EmployerName, VacancyType.Traineeship, Order.Ascending,
                VacancySummaryOrderByColumn.DateSubmitted, page, pageSize);

            vacancySummaryRepository.Verify(
                s =>
                    s.GetSummariesForProvider(
                        It.Is<VacancySummaryQuery>(
                            q =>
                                q.ProviderId == 1 && 
                                q.Filter == VacanciesSummaryFilterTypes.Closed &&
                                q.Order == Order.Ascending &&
                                q.OrderByField == VacancySummaryOrderByColumn.DateSubmitted &&
                                q.ProviderSiteId == 1 &&
                                q.SearchMode == VacancySearchMode.EmployerName &&
                                q.SearchString == "Test" &&
                                q.RequestedPage == page && q.PageSize == pageSize)));
        }

        [Test]
        public async Task PageAndPageSizeAreLimited()
        {
            const int page = -3;
            const int pageSize = 777;

            var vacancySummaryRepository = new Mock<IVacancySummaryRepository>();
            vacancySummaryRepository.Setup(r => r.GetLiveAsync(It.IsAny<VacancySummaryByStatusQuery>())).Returns(Task.FromResult(new ListWithTotalCount<VacancySummary>(new List<VacancySummary>(), 0)));

            var providerSiteRepository = new Mock<IProviderSiteReadRepository>();
            providerSiteRepository.Setup(s => s.GetByProviderId(It.IsAny<int>()))
                .Returns(() => new List<ProviderSite> { new ProviderSite() { ProviderSiteId = 1 } });

            var vacancySummaryReadRepository = new Mock<IProviderReadRepository>();
            vacancySummaryReadRepository.Setup(r => r.GetByUkprn(It.IsAny<string>(), It.IsAny<bool>()))
                .Returns(() => new Provider() { ProviderId = 1 });

            var strategy = new GetVacancySummariesStrategy(vacancySummaryReadRepository.Object, providerSiteRepository.Object, vacancySummaryRepository.Object);

            await strategy.GetVacancySummaries("123", "Test", VacanciesSummaryFilterTypes.Closed,
                VacancySearchMode.EmployerName, VacancyType.Traineeship, Order.Ascending,
                VacancySummaryOrderByColumn.DateSubmitted, page, pageSize);

            vacancySummaryRepository.Verify(
                s =>
                    s.GetSummariesForProvider(
                        It.Is<VacancySummaryQuery>(
                            q =>
                                q.ProviderId == 1 &&
                                q.Filter == VacanciesSummaryFilterTypes.Closed &&
                                q.Order == Order.Ascending &&
                                q.OrderByField == VacancySummaryOrderByColumn.DateSubmitted &&
                                q.ProviderSiteId == 1 &&
                                q.SearchMode == VacancySearchMode.EmployerName &&
                                q.SearchString == "Test" &&
                                q.RequestedPage == 1 && q.PageSize == 250)));
        }
    }
}
