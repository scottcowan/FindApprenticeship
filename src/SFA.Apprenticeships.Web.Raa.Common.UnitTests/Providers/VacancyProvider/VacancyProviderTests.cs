﻿namespace SFA.Apprenticeships.Web.Raa.Common.UnitTests.Providers.VacancyProvider
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Application.Interfaces.Providers;
    using Application.Interfaces.ReferenceData;
    using Application.Interfaces.Vacancies;
    using Application.Interfaces.VacancyPosting;
    using Configuration;
    using Domain.Entities.Raa.Parties; 
    using Domain.Entities.Raa.Vacancies;
    using FluentAssertions;
    using Moq;
    using Moq.Language.Flow;
    using NUnit.Framework;
    using Ploeh.AutoFixture;
    using SFA.Infrastructure.Interfaces;
    using ViewModels.Vacancy;
    using Web.Common.Configuration;
    using Web.Common.ViewModels;

    [TestFixture]
    public class VacancyProviderTests
    {
        private const int QAVacancyTimeout = 10;

        [Test]
        public void GetPendingQAVacanciesShouldOnlyReturnVacanciesAvailableToQa()
        {
            // Arrange
            var today = new DateTime(2016, 3, 16, 12, 0, 0);
            var vacancyPostingService = new Mock<IVacancyPostingService>();
            var providerService = new Mock<IProviderService>();
            var dateTimeService = new Mock<IDateTimeService>();
            var vacancyLockingService = new Mock<IVacancyLockingService>();
            dateTimeService.Setup(dts => dts.UtcNow).Returns(today);
            const int anInt = 1;
            const string username = "userName";
            const int submissionCount = 2;
            const int vacancyAvailableToQAReferenceNumber = 1;
            const int vacancyNotAvailableToQAReferenceNumber = 2;

            var apprenticeshipVacancies = new List<VacancySummary>
            {
                new VacancySummary
                {
                    ClosingDate = today,
                    DateSubmitted = today,
                    OwnerPartyId = anInt,
                    VacancyReferenceNumber = vacancyAvailableToQAReferenceNumber,
                    Status = VacancyStatus.ReservedForQA,
                    QAUserName = username,
                    DateStartedToQA = null,
                    SubmissionCount = submissionCount
                },
                new VacancySummary
                {
                    ClosingDate = today,
                    DateSubmitted = today,
                    OwnerPartyId = anInt,
                    VacancyReferenceNumber = vacancyNotAvailableToQAReferenceNumber,
                    Status = VacancyStatus.ReservedForQA,
                    QAUserName = username,
                    DateStartedToQA = null,
                    SubmissionCount = submissionCount
                }
            };

            vacancyPostingService.Setup(
                avr => avr.GetWithStatus(VacancyStatus.Submitted, VacancyStatus.ReservedForQA))
                .Returns(apprenticeshipVacancies);

            providerService.Setup(ps => ps.GetProviderViaOwnerParty(It.IsAny<int>())).Returns(new Provider());

            vacancyLockingService.Setup(
                vls =>
                    vls.IsVacancyAvailableToQABy(username,
                        It.Is<VacancySummary>(vs => vs.VacancyReferenceNumber == vacancyAvailableToQAReferenceNumber))).Returns(true);

            vacancyLockingService.Setup(
                vls =>
                    vls.IsVacancyAvailableToQABy(username,
                        It.Is<VacancySummary>(vs => vs.VacancyReferenceNumber == vacancyNotAvailableToQAReferenceNumber))).Returns(false);

            var currentUserService = new Mock<ICurrentUserService>();
            currentUserService.Setup(cus => cus.CurrentUserName).Returns(username);

            var vacancyProvider =
                new VacancyProviderBuilder()
                    .With(providerService)
                    .With(vacancyPostingService)
                    .With(dateTimeService)
                    .With(vacancyLockingService)
                    .With(currentUserService)
                    .Build();

            var vacancies = vacancyProvider.GetPendingQAVacancies();
            vacancies.Should().HaveCount(1);
            vacancies.Single().VacancyReferenceNumber.Should().Be(vacancyAvailableToQAReferenceNumber);

        }

        [Test]
        public void GetVacanciesPendingQAShouldCallRepositoryWithPendingQAAsDesiredStatus()
        {
            //Arrange
            var vacancyPostingService = new Mock<IVacancyPostingService>();
            var providerService = new Mock<IProviderService>();
            const int ownerPartyId = 42;
            var configurationService = new Mock<IConfigurationService>();
            configurationService.Setup(x => x.Get<ManageWebConfiguration>())
                .Returns(new ManageWebConfiguration {QAVacancyTimeout = QAVacancyTimeout});
            configurationService.Setup(x => x.Get<CommonWebConfiguration>())
                .Returns(new CommonWebConfiguration {BlacklistedCategoryCodes = ""});

            vacancyPostingService.Setup(
                avr => avr.GetWithStatus(VacancyStatus.Submitted, VacancyStatus.ReservedForQA))
                .Returns(new List<VacancySummary>
                {
                    new VacancySummary
                    {
                        ClosingDate = DateTime.Now,
                        DateSubmitted = DateTime.Now,
                        OwnerPartyId = ownerPartyId,
                        Status = VacancyStatus.Submitted
                    }
                });

            providerService.Setup(ps => ps.GetProviderViaOwnerParty(ownerPartyId)).Returns(new Provider());

            var vacancyProvider =
                new VacancyProviderBuilder()
                    .With(providerService)
                    .With(vacancyPostingService)
                    .With(configurationService)
                    .Build();

            //Act
            vacancyProvider.GetPendingQAVacancies();

            //Assert
            vacancyPostingService.Verify(avr => avr.GetWithStatus(VacancyStatus.Submitted, VacancyStatus.ReservedForQA));
            providerService.Verify(ps => ps.GetProviderViaOwnerParty(ownerPartyId), Times.Once);
        }

        

        

        [Test]
        public void ShouldSaveCommentsWhenUpdatingVacancySummaryViewModel()
        {
            const int vacancyReferenceNumber = 1;
            const string closingDateComment = "Closing date comment";
            const string workingWeekComment = "Working week comment";
            const string wageComment = "Wage comment";
            const string durationComment = "Duration comment";
            const string longDescriptionComment = "Long description comment";
            const string possibleStartDateComment = "Possible start date comment";

            var vacancyPostingService = new Mock<IVacancyPostingService>();
            var configService = new Mock<IConfigurationService>();
            configService.Setup(m => m.Get<CommonWebConfiguration>())
                .Returns(new CommonWebConfiguration {BlacklistedCategoryCodes = string.Empty});
            var provider = new VacancyProviderBuilder().With(vacancyPostingService).With(configService).Build();
            var viewModel = GetValidVacancySummaryViewModel(vacancyReferenceNumber);
            vacancyPostingService.Setup(vp => vp.GetVacancyByReferenceNumber(vacancyReferenceNumber))
                .Returns(new Vacancy());
            vacancyPostingService.Setup(vp => vp.UpdateVacancy(It.IsAny<Vacancy>()))
                .Returns(new Vacancy());
            viewModel.VacancyDatesViewModel.ClosingDateComment = closingDateComment;
            viewModel.DurationComment = durationComment;
            viewModel.LongDescriptionComment = longDescriptionComment;
            viewModel.VacancyDatesViewModel.PossibleStartDateComment = possibleStartDateComment;
            viewModel.WageComment = wageComment;
            viewModel.WorkingWeekComment = workingWeekComment;

            provider.UpdateVacancyWithComments(viewModel);

            vacancyPostingService.Verify(vp => vp.GetVacancyByReferenceNumber(vacancyReferenceNumber));
            vacancyPostingService.Verify(
                vp =>
                    vp.UpdateVacancy(
                        It.Is<Vacancy>(
                            v =>
                                v.ClosingDateComment == closingDateComment &&
                                v.DurationComment == durationComment &&
                                v.LongDescriptionComment == longDescriptionComment &&
                                v.PossibleStartDateComment == possibleStartDateComment &&
                                v.WageComment == wageComment &&
                                v.WorkingWeekComment == workingWeekComment)));
        }

        [Test]
        public void UpdateTrainingDetailsWithComments()
        {
            //Arrange
            const string ukprn = "ukprn";

            var trainingDetailsViewModel = new Fixture().Build<TrainingDetailsViewModel>().Create();

            var sectorList = new List<Sector>
            {
                new Fixture().Build<Sector>().Create()
            };

            var vacancyPostingService = new Mock<IVacancyPostingService>();
            var providerService = new Mock<IProviderService>();
            var configurationService = new Mock<IConfigurationService>();
            configurationService.Setup(x => x.Get<ManageWebConfiguration>())
                .Returns(new ManageWebConfiguration {QAVacancyTimeout = QAVacancyTimeout});
            configurationService.Setup(x => x.Get<CommonWebConfiguration>())
                .Returns(new CommonWebConfiguration {BlacklistedCategoryCodes = ""});
            var referenceDataService = new Mock<IReferenceDataService>();
            referenceDataService.Setup(m => m.GetSectors()).Returns(sectorList);
            providerService.Setup(ps => ps.GetProvider(ukprn)).Returns(new Provider());

            //Arrange: get AV, update retrieved AV with NVVM, save modified AV returning same modified AV, map AV to new NVVM with same properties as input
            vacancyPostingService.Setup(
                vps => vps.GetVacancyByReferenceNumber(trainingDetailsViewModel.VacancyReferenceNumber.Value)).Returns(
                    (long refNo) =>
                    {
                        return new Fixture().Build<Vacancy>()
                            .With(av => av.VacancyReferenceNumber, trainingDetailsViewModel.VacancyReferenceNumber.Value)
                            .With(av => av.ApprenticeshipLevelComment, Guid.NewGuid().ToString())
                            .With(av => av.FrameworkCodeNameComment, Guid.NewGuid().ToString())
                            .With(av => av.ApprenticeshipLevel, trainingDetailsViewModel.ApprenticeshipLevel)
                            .With(av => av.FrameworkCodeName, Guid.NewGuid().ToString())
                            .With(av => av.StandardIdComment, Guid.NewGuid().ToString())
                            .With(av => av.StandardId, null)
                            .Create();
                    });

            vacancyPostingService.Setup(vps => vps.UpdateVacancy(It.IsAny<Vacancy>())).Returns((Vacancy av) => av);

            var mapper = new Mock<IMapper>();
            mapper.Setup(m => m.Map<Vacancy, TrainingDetailsViewModel>(It.IsAny<Vacancy>()))
                .Returns((Vacancy av) => trainingDetailsViewModel);

            var vacancyProvider =
                new VacancyProviderBuilder().With(vacancyPostingService)
                    .With(providerService)
                    .With(configurationService)
                    .With(referenceDataService)
                    .With(mapper)
                    .Build();

            //Act
            var result = vacancyProvider.UpdateVacancyWithComments(trainingDetailsViewModel);

            //Assert
            vacancyPostingService.Verify(
                vps => vps.GetVacancyByReferenceNumber(trainingDetailsViewModel.VacancyReferenceNumber.Value),
                Times.Once);
            vacancyPostingService.Verify(
                vps =>
                    vps.UpdateVacancy(
                        It.Is<Vacancy>(
                            av => av.VacancyReferenceNumber == trainingDetailsViewModel.VacancyReferenceNumber.Value)));
            result.VacancyReferenceNumber.Should().Be(trainingDetailsViewModel.VacancyReferenceNumber);
            result.ApprenticeshipLevelComment.Should().Be(trainingDetailsViewModel.ApprenticeshipLevelComment);
            result.FrameworkCodeNameComment.Should().Be(trainingDetailsViewModel.FrameworkCodeNameComment);
            result.StandardIdComment.Should().Be(trainingDetailsViewModel.StandardIdComment);
            result.StandardId.Should().Be(trainingDetailsViewModel.StandardId);
            result.ApprenticeshipLevel.Should().Be(trainingDetailsViewModel.ApprenticeshipLevel);
            result.FrameworkCodeName.Should().Be(trainingDetailsViewModel.FrameworkCodeName);
        }

        [Test]
        public void UpdateVacancyBasicDetailsShouldExpectVacancyReferenceNumber()
        {
            //Arrange
            var newVacancyVM = new Fixture().Build<NewVacancyViewModel>()
                .With(vm => vm.VacancyReferenceNumber, null)
                .Create();

            var vacancyPostingService = new Mock<IVacancyPostingService>();
            var providerService = new Mock<IProviderService>();
            var configurationService = new Mock<IConfigurationService>();
            configurationService.Setup(x => x.Get<ManageWebConfiguration>())
                .Returns(new ManageWebConfiguration {QAVacancyTimeout = QAVacancyTimeout});
            configurationService.Setup(x => x.Get<CommonWebConfiguration>())
                .Returns(new CommonWebConfiguration {BlacklistedCategoryCodes = ""});

            var vacancyProvider =
                new VacancyProviderBuilder().With(vacancyPostingService)
                    .With(providerService)
                    .With(configurationService)
                    .Build();

            //Act
            Action action = () => vacancyProvider.UpdateVacancyWithComments(newVacancyVM);

            //Assert
            action.ShouldThrow<ArgumentNullException>();
        }

        
        [Test]
        public void UpdateVacancyRequirementsAndProspectsWithComments()
        {
            //Arrange
            var vacancyVm = new Fixture().Build<VacancyRequirementsProspectsViewModel>()
                .Create();

            var appVacancy = new Fixture().Build<Vacancy>()
                .With(x => x.VacancyReferenceNumber, vacancyVm.VacancyReferenceNumber)
                .With(x => x.Status, VacancyStatus.Submitted)
                .Create();

            var vacancyPostingService = new Mock<IVacancyPostingService>();
            var providerService = new Mock<IProviderService>();
            var configurationService = new Mock<IConfigurationService>();
            configurationService.Setup(x => x.Get<CommonWebConfiguration>())
                .Returns(new CommonWebConfiguration {BlacklistedCategoryCodes = ""});

            vacancyPostingService.Setup(
                vps => vps.GetVacancyByReferenceNumber(vacancyVm.VacancyReferenceNumber)).Returns(appVacancy);

            vacancyPostingService.Setup(vps => vps.UpdateVacancy(It.IsAny<Vacancy>())).Returns(appVacancy);

            var vacancyProvider =
                new VacancyProviderBuilder().With(vacancyPostingService)
                    .With(providerService)
                    .With(configurationService)
                    .Build();

            //Act
            var result = vacancyProvider.UpdateVacancyWithComments(vacancyVm);

            //Assert
            vacancyPostingService.Verify(vps => vps.GetVacancyByReferenceNumber(vacancyVm.VacancyReferenceNumber),
                Times.Once);
            vacancyPostingService.Verify(
                vps =>
                    vps.UpdateVacancy(It.Is<Vacancy>(av => av.VacancyReferenceNumber == vacancyVm.VacancyReferenceNumber)));
            result.VacancyReferenceNumber.Should().Be(vacancyVm.VacancyReferenceNumber);
            result.DesiredQualifications.Should().Be(vacancyVm.DesiredQualifications);
            result.DesiredQualificationsComment.Should().Be(vacancyVm.DesiredQualificationsComment);
            result.DesiredSkills.Should().Be(vacancyVm.DesiredSkills);
            result.DesiredSkillsComment.Should().Be(vacancyVm.DesiredSkillsComment);
            result.FutureProspectsComment.Should().Be(vacancyVm.FutureProspectsComment);
            result.FutureProspects.Should().Be(vacancyVm.FutureProspects);
            result.PersonalQualitiesComment.Should().Be(vacancyVm.PersonalQualitiesComment);
            result.PersonalQualities.Should().Be(vacancyVm.PersonalQualities);
            result.ThingsToConsiderComment.Should().Be(vacancyVm.ThingsToConsiderComment);
            result.ThingsToConsider.Should().Be(vacancyVm.ThingsToConsider);
        }

        private static FurtherVacancyDetailsViewModel GetValidVacancySummaryViewModel(int vacancyReferenceNumber)
        {
            return new FurtherVacancyDetailsViewModel
            {
                VacancyReferenceNumber = vacancyReferenceNumber,
                VacancyDatesViewModel = new VacancyDatesViewModel
                {
                    ClosingDate = new DateViewModel(DateTime.UtcNow.AddDays(20)),
                    PossibleStartDate = new DateViewModel(DateTime.UtcNow.AddDays(30))
                },
                Duration = 3,
                DurationType = DurationType.Years,
                LongDescription = "A description",
                WageType = WageType.ApprenticeshipMinimumWage,
                HoursPerWeek = 30,
                WorkingWeek = "A working week"
            };
        }
    }

    public static class MoqExtensions
    {
        public static void ReturnsInOrder<T, TResult>(this ISetup<T, TResult> setup,
            params TResult[] results) where T : class
        {
            setup.Returns(new Queue<TResult>(results).Dequeue);
        }
    }
}