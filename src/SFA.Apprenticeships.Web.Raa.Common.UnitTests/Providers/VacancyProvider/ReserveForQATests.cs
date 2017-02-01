namespace SFA.Apprenticeships.Web.Raa.Common.UnitTests.Providers.VacancyProvider
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Application.Interfaces.Vacancies;
    using Domain.Entities.Raa.Vacancies;
    using FluentAssertions;
    using Moq;
    using NUnit.Framework;

    [TestFixture]
    [Parallelizable]
    public class ReserveForQATests
    {
        [Test]
        public async Task ShouldReserveAndReturnTheVacancyIfItsPossibleToReserveItForQA()
        {
            const int vacancyReferenceNumber = 1;
            const string userName = "userName";

            var vacancyProviderBuilder = VacancyProviderTestHelper.GetBasicVacancyProviderBuilder(userName, vacancyReferenceNumber);
            var provider = vacancyProviderBuilder.Build();

            var result = await provider.ReserveVacancyForQA(vacancyReferenceNumber);

            vacancyProviderBuilder.VacancyPostingService.Verify(ps => ps.ReserveVacancyForQA(vacancyReferenceNumber),
                Times.Once);
            result.VacancyReferenceNumber.Should().Be(vacancyReferenceNumber);
        }

        [Test]
        public async Task ShouldReturnNullIfThereIsNotAnyAvailableVacancy()
        {
            const int vacancyReferenceNumber = 1;
            const string userName = "userName";
            VacancySummary nextVacancySummary = null;

            var vacancyLockingService = new Mock<IVacancyLockingService>();
            vacancyLockingService.Setup(vls => vls.IsVacancyAvailableToQABy(userName, It.IsAny<VacancySummary>()))
                .Returns(false);
            vacancyLockingService.Setup(vls => vls.GetNextAvailableVacancy(userName, It.IsAny<List<VacancySummary>>()))
                .Returns(nextVacancySummary);

            var vacancyProviderBuilder = VacancyProviderTestHelper.GetBasicVacancyProviderBuilder(userName, vacancyReferenceNumber);
            var provider = vacancyProviderBuilder.With(vacancyLockingService).Build();

            var result = await provider.ReserveVacancyForQA(vacancyReferenceNumber);

            result.Should().BeNull();
        }

        [Test]
        public async Task ShouldReserveTheNextVacancyAvailableIfTheOriginalOneIsNotAvailable()
        {
            const int vacancyReferenceNumber = 1;
            const int nextVacanyReferenceNumber = 2;
            const string userName = "userName";
            var nextVacancySummary = new VacancySummary {VacancyReferenceNumber = nextVacanyReferenceNumber};

            var vacancyLockingService = new Mock<IVacancyLockingService>();
            vacancyLockingService.Setup(vls => vls.IsVacancyAvailableToQABy(userName, It.IsAny<VacancySummary>()))
                .Returns(false);
            vacancyLockingService.Setup(vls => vls.GetNextAvailableVacancy(userName, It.IsAny<List<VacancySummary>>()))
                .Returns(nextVacancySummary);

            var vacancyProviderBuilder = VacancyProviderTestHelper.GetBasicVacancyProviderBuilder(userName,
                vacancyReferenceNumber, nextVacanyReferenceNumber);
            var provider = vacancyProviderBuilder.With(vacancyLockingService).Build();

            var result = await provider.ReserveVacancyForQA(vacancyReferenceNumber);

            result.VacancyReferenceNumber.Should().Be(nextVacanyReferenceNumber);
            vacancyProviderBuilder.VacancyPostingService.Verify(ps => ps.ReserveVacancyForQA(nextVacanyReferenceNumber),
                Times.Once);
        }
    }
}