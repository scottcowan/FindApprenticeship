namespace SFA.Apprenticeships.Web.Candidate.UnitTests.Mediators.TraineeshipApplication
{
    using System;
    using System.Threading.Tasks;
    using Builders;
    using Candidate.Mediators.Application;
    using Candidate.Providers;
    using Common.Constants;
    using Common.Models.Application;
    using Common.UnitTests.Mediators;
    using Constants.Pages;
    using Domain.Entities.Vacancies;
    using Moq;
    using NUnit.Framework;

    [TestFixture]
    [Parallelizable]
    public class ViewTests
    {
        private const int TestVacancyId = 5;

        [TestCase(VacancyStatuses.Live)]
        [TestCase(VacancyStatuses.Expired)]
        public async Task Ok(VacancyStatuses vacancyStatus)
        {
            var candidateId = Guid.NewGuid();
            var traineeshipApplicationProvider = new Mock<ITraineeshipApplicationProvider>();

            traineeshipApplicationProvider
                .Setup(p => p.GetApplicationViewModelEx(candidateId, TestVacancyId))
                .Returns(Task.FromResult(new TraineeshipApplicationViewModelBuilder()
                    .WithVacancyStatus(vacancyStatus)
                    .Build()));

            var mediator = new TraineeshipApplicationMediatorBuilder()
                .With(traineeshipApplicationProvider)
                .Build();

            var response = await mediator.View(candidateId, TestVacancyId);

            response.AssertCode(TraineeshipApplicationMediatorCodes.View.Ok, true);
        }

        [Test]
        public async Task ApplicationNotFound()
        {
            var viewModel = new TraineeshipApplicationViewModelBuilder()
                .HasError(ApplicationViewModelStatus.ApplicationNotFound, MyApplicationsPageMessages.ApplicationNotFound)
                .Build();

            var traineeshipApplicationProvider = new Mock<ITraineeshipApplicationProvider>();

            traineeshipApplicationProvider
                .Setup(p => p.GetApplicationViewModelEx(It.IsAny<Guid>(), It.IsAny<int>()))
                .Returns(Task.FromResult(viewModel));

            var mediator = new TraineeshipApplicationMediatorBuilder()
                .With(traineeshipApplicationProvider)
                .Build();

            var response = await mediator.View(Guid.NewGuid(), TestVacancyId);

            response.AssertCode(TraineeshipApplicationMediatorCodes.View.ApplicationNotFound, true);
        }

        [Test]
        public async Task HasError()
        {
            var viewModel = new TraineeshipApplicationViewModelBuilder()
                .HasError(ApplicationViewModelStatus.Error, ApplicationPageMessages.ViewApplicationFailed)
                .Build();

            var traineeshipApplicationProvider = new Mock<ITraineeshipApplicationProvider>();

            traineeshipApplicationProvider
                .Setup(p => p.GetApplicationViewModelEx(It.IsAny<Guid>(), It.IsAny<int>()))
                .Returns(Task.FromResult(viewModel));

            var mediator = new TraineeshipApplicationMediatorBuilder()
                .With(traineeshipApplicationProvider)
                .Build();

            var response = await mediator.View(Guid.NewGuid(), TestVacancyId);

            response.AssertMessage(
                TraineeshipApplicationMediatorCodes.View.Error,
                ApplicationPageMessages.ViewApplicationFailed,
                UserMessageLevel.Warning,
                false);
        }
    }
}