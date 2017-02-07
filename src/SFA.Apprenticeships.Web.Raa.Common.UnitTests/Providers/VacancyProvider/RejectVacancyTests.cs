﻿namespace SFA.Apprenticeships.Web.Raa.Common.UnitTests.Providers.VacancyProvider
{
    using System.Threading.Tasks;
    using Application.Interfaces.Vacancies;
    using Application.Interfaces.VacancyPosting;
    using Common.Providers;
    using Domain.Entities.Raa.Vacancies;
    using FluentAssertions;
    using Moq;
    using NUnit.Framework;
    using Ploeh.AutoFixture;
    using Application.Interfaces;
    using Web.Common.Configuration;

    [TestFixture]
    [Parallelizable]
    public class RejectVacancyTests
    {
        [Test]
        public async Task RejectVacancy()
        {
            //Arrange
            var vacancyReferenceNumber = 1;
            var vacancy = new Fixture().Build<Vacancy>()
                .With(x => x.VacancyReferenceNumber, vacancyReferenceNumber)
                .With(x => x.VacancyLocationType, VacancyLocationType.SpecificLocation)
                .Create();

            var vacanyLockingService = new Mock<IVacancyLockingService>();
            var configurationService = new Mock<IConfigurationService>();
            var vacancyPostingService = new Mock<IVacancyPostingService>();
            configurationService.Setup(x => x.Get<CommonWebConfiguration>())
                .Returns(new CommonWebConfiguration { BlacklistedCategoryCodes = "" });

            vacancyPostingService.Setup(r => r.GetVacancyByReferenceNumber(vacancyReferenceNumber)).Returns(Task.FromResult(vacancy));

            vacanyLockingService.Setup(vls => vls.IsVacancyAvailableToQABy(It.IsAny<string>(), It.IsAny<Vacancy>()))
                .Returns(true);

            var vacancyProvider =
                new VacancyProviderBuilder()
                    .With(configurationService)
                    .With(vacancyPostingService)
                    .With(vacanyLockingService)
                    .Build();

            //Act
            var result = await vacancyProvider.RejectVacancy(vacancyReferenceNumber);

            //Assert
            result.Should().Be(QAActionResultCode.Ok);
            vacancyPostingService.Verify(r => r.GetVacancyByReferenceNumber(vacancyReferenceNumber));
            vacancyPostingService.Verify(
                r =>
                    r.UpdateVacancy(
                        It.Is<Vacancy>(
                            av =>
                                av.VacancyReferenceNumber == vacancyReferenceNumber &&
                                av.Status == VacancyStatus.Referred)));
        }

        [Test]
        public async Task ShouldReturnInvalidVacancyIfTheUserCantQATheVacancy()
        {
            const int vacanyReferenceNumber = 1;
            const string userName = "userName";

            var vacancyPostingService = new Mock<IVacancyPostingService>();
            var vacanyLockingService = new Mock<IVacancyLockingService>();
            var currentUserService = new Mock<ICurrentUserService>();

            currentUserService.Setup(cus => cus.CurrentUserName).Returns(userName);
            vacancyPostingService.Setup(vps => vps.GetVacancyByReferenceNumber(vacanyReferenceNumber))
                .Returns(Task.FromResult(new Vacancy { VacancyReferenceNumber = vacanyReferenceNumber }));
            vacanyLockingService.Setup(vls => vls.IsVacancyAvailableToQABy(userName, It.IsAny<Vacancy>()))
                .Returns(false);

            var vacancyProvider =
                new VacancyProviderBuilder()
                    .With(vacancyPostingService)
                    .With(vacanyLockingService)
                    .With(currentUserService)
                    .Build();

            var result = await vacancyProvider.RejectVacancy(vacanyReferenceNumber);

            result.Should().Be(QAActionResultCode.InvalidVacancy);
        }
    }
}