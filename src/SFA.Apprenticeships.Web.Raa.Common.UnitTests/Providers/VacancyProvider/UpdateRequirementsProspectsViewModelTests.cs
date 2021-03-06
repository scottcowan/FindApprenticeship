﻿namespace SFA.Apprenticeships.Web.Raa.Common.UnitTests.Providers.VacancyProvider
{
    using System;
    using System.Collections.Generic;
    using Application.Interfaces.Providers;
    using Application.Interfaces.ReferenceData;
    using Application.Interfaces.Vacancies;
    using Application.Interfaces.VacancyPosting;
    using Common.Providers;
    using Configuration;
    using Domain.Entities.Raa.Parties;
    using Domain.Entities.Raa.Vacancies;
    using FluentAssertions;
    using Moq;
    using NUnit.Framework;
    using Ploeh.AutoFixture;

    using SFA.Apprenticeships.Application.Interfaces;
    using SFA.Infrastructure.Interfaces;
    using ViewModels.Vacancy;
    using Web.Common.Configuration;

    [TestFixture]
    [Parallelizable]
    public class UpdateRequirementsProspectsViewModelTests
    {
        [Test]
        public void ShouldReturnOKIfTheUserCanLockTheVacancy()
        {
            //Arrange
            const string ukprn = "ukprn";
            //const int QAVacancyTimeout = 10;
            const string userName = "userName";
            var utcNow = DateTime.UtcNow;
            const int vacancyReferenceNumber = 1;
            const string aString = "aString";
            const int autoSaveTimeoutInSeconds = 60;

            var sectorList = new List<Sector>
            {
                new Fixture().Build<Sector>().Create()
            };

            var viewModel = new VacancyRequirementsProspectsViewModel
            {
               VacancyReferenceNumber = vacancyReferenceNumber,
               DesiredQualifications = aString,
               AutoSaveTimeoutInSeconds = autoSaveTimeoutInSeconds
            };

            var vacancy = new Fixture().Build<Vacancy>()
                            .With(av => av.VacancyReferenceNumber, vacancyReferenceNumber)
                            .With(av => av.DesiredQualifications, aString)
                            .Create();

            var configurationService = new Mock<IConfigurationService>();
            configurationService.Setup(x => x.Get<CommonWebConfiguration>())
                .Returns(new CommonWebConfiguration { BlacklistedCategoryCodes = "" });
            configurationService.Setup(x => x.Get<RecruitWebConfiguration>())
                .Returns(new RecruitWebConfiguration { AutoSaveTimeoutInSeconds = autoSaveTimeoutInSeconds });
            var referenceDataService = new Mock<IReferenceDataService>();
            referenceDataService.Setup(m => m.GetSectors()).Returns(sectorList);
            var providerService = new Mock<IProviderService>();
            providerService.Setup(ps => ps.GetProvider(ukprn, true)).Returns(new Provider());

            var vacancyPostingService = new Mock<IVacancyPostingService>();
            var currentUserService = new Mock<ICurrentUserService>();
            currentUserService.Setup(cus => cus.CurrentUserName).Returns(userName);
            var dateTimeService = new Mock<IDateTimeService>();
            dateTimeService.Setup(dts => dts.UtcNow).Returns(utcNow);
            var vacancylockingService = new Mock<IVacancyLockingService>();
            vacancylockingService.Setup(vls => vls.IsVacancyAvailableToQABy(userName, vacancy)).Returns(true);

            //Arrange: get AV, update retrieved AV with NVVM, save modified AV returning same modified AV, map AV to new NVVM with same properties as input
            vacancyPostingService.Setup(
                vps => vps.GetVacancyByReferenceNumber(vacancyReferenceNumber)).Returns(vacancy);

            vacancyPostingService.Setup(vps => vps.UpdateVacancy(It.IsAny<Vacancy>())).Returns((Vacancy av) => av);

            var mapper = new Mock<IMapper>();
            mapper.Setup(m => m.Map<Vacancy, VacancyRequirementsProspectsViewModel>(It.IsAny<Vacancy>()))
                .Returns((Vacancy av) => viewModel);

            var vacancyProvider =
                new VacancyProviderBuilder().With(vacancyPostingService)
                    .With(providerService)
                    .With(configurationService)
                    .With(referenceDataService)
                    .With(mapper)
                    .With(currentUserService)
                    .With(dateTimeService)
                    .With(vacancylockingService)
                    .Build();

            var expectedResult = new QAActionResult<VacancyRequirementsProspectsViewModel>(QAActionResultCode.Ok, viewModel);

            //Act
            var result = vacancyProvider.UpdateVacancyWithComments(viewModel);
            
            //Assert
            vacancyPostingService.Verify(
                vps => vps.GetVacancyByReferenceNumber(viewModel.VacancyReferenceNumber), Times.Once);
            vacancyPostingService.Verify(
                vps =>
                    vps.UpdateVacancy(
                        It.Is<Vacancy>(av => av.VacancyReferenceNumber == viewModel.VacancyReferenceNumber &&
                            av.QAUserName == userName && av.DateStartedToQA == utcNow)));
            result.ShouldBeEquivalentTo(expectedResult);
        }

        [Test]
        public void ShouldReturnInvalidVacancyIfTheUserCantQATheVacancy()
        {
            const int vacanyReferenceNumber = 1;
            const string userName = "userName";

            var requirementsProspectsViewModel = new Fixture().Build<VacancyRequirementsProspectsViewModel>().Create();

            var vacancyPostingService = new Mock<IVacancyPostingService>();
            var vacanyLockingService = new Mock<IVacancyLockingService>();
            var currentUserService = new Mock<ICurrentUserService>();

            currentUserService.Setup(cus => cus.CurrentUserName).Returns(userName);
            vacancyPostingService.Setup(vps => vps.GetVacancyByReferenceNumber(vacanyReferenceNumber))
                .Returns(new Vacancy {VacancyReferenceNumber = vacanyReferenceNumber});
            vacanyLockingService.Setup(vls => vls.IsVacancyAvailableToQABy(userName, It.IsAny<Vacancy>()))
                .Returns(false);
            
            var vacancyProvider =
                new VacancyProviderBuilder()
                    .With(vacancyPostingService)
                    .With(vacanyLockingService)
                    .With(currentUserService)
                    .Build();

            var result = vacancyProvider.UpdateVacancyWithComments(requirementsProspectsViewModel);

            result.Code.Should().Be(QAActionResultCode.InvalidVacancy);
            result.ViewModel.Should().BeNull();
        }
    }
}
