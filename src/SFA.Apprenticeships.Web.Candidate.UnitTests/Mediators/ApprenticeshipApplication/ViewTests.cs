namespace SFA.Apprenticeships.Web.Candidate.UnitTests.Mediators.ApprenticeshipApplication
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
    using Domain.Entities.Applications;
    using Domain.Entities.Vacancies;
    using Moq;
    using NUnit.Framework;

    [TestFixture]
    [Parallelizable]
    public class ViewTests
    {
        private const int ValidVacancyId = 1;

        [Test]
        public async Task ApplicationNotFound()
        {
            var viewModel =
                new ApprenticeshipApplicationViewModelBuilder().HasError(
                    ApplicationViewModelStatus.ApplicationNotFound, MyApplicationsPageMessages.ApplicationNotFound)
                    .Build();
            var apprenticeshipApplicationProvider = new Mock<IApprenticeshipApplicationProvider>();
            apprenticeshipApplicationProvider.Setup(p => p.GetApplicationViewModel(It.IsAny<Guid>(), It.IsAny<int>()))
                .Returns(Task.FromResult(viewModel));
            var mediator =
                new ApprenticeshipApplicationMediatorBuilder().With(apprenticeshipApplicationProvider).Build();

            var response = await mediator.View(Guid.NewGuid(), ValidVacancyId);

            //Should still be able to view the application even if the vacancy is not available
            response.AssertMessage(ApprenticeshipApplicationMediatorCodes.View.ApplicationNotFound,
                ApplicationPageMessages.ViewApplicationFailed, UserMessageLevel.Warning, true);
        }

        [Test]
        public async Task Ok()
        {
            var candidateId = Guid.NewGuid();
            var apprenticeshipApplicationProvider = new Mock<IApprenticeshipApplicationProvider>();
            apprenticeshipApplicationProvider.Setup(p => p.GetApplicationViewModel(candidateId, ValidVacancyId))
                .Returns(Task.FromResult(new ApprenticeshipApplicationViewModelBuilder().WithVacancyStatus(VacancyStatuses.Live).Build()));
            var mediator =
                new ApprenticeshipApplicationMediatorBuilder().With(apprenticeshipApplicationProvider).Build();

            var response = await mediator.View(candidateId, ValidVacancyId);

            response.AssertCode(ApprenticeshipApplicationMediatorCodes.View.Ok, true);
        }

        [Test]
        public async Task VacancyNotFound()
        {
            var viewModel =
                new ApprenticeshipApplicationViewModelBuilder().WithStatus(ApplicationStatuses.ExpiredOrWithdrawn)
                    .Build();
            var apprenticeshipApplicationProvider = new Mock<IApprenticeshipApplicationProvider>();
            apprenticeshipApplicationProvider.Setup(p => p.GetApplicationViewModel(It.IsAny<Guid>(), It.IsAny<int>()))
                .Returns(Task.FromResult(viewModel));
            var mediator =
                new ApprenticeshipApplicationMediatorBuilder().With(apprenticeshipApplicationProvider).Build();

            var response = await mediator.View(Guid.NewGuid(), ValidVacancyId);

            //Should still be able to view the application even if the vacancy is not available
            response.AssertCode(ApprenticeshipApplicationMediatorCodes.View.Ok, true);
        }
    }
}