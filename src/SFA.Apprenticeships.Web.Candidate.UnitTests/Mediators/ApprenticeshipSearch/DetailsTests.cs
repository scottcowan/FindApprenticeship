
namespace SFA.Apprenticeships.Web.Candidate.UnitTests.Mediators.ApprenticeshipSearch
{
    using Candidate.Mediators.Search;
    using Candidate.ViewModels.VacancySearch;
    using Common.Constants;
    using Common.UnitTests.Mediators;
    using Constants;
    using Domain.Entities.Applications;
    using Domain.Entities.Vacancies;
    using Moq;
    using NUnit.Framework;
    using System;
    using System.Threading.Tasks;

    [TestFixture]
    [Parallelizable]
    public class DetailsTests : TestsBase
    {
        private const string Id = "1";
        private const string VacancyDistance = "10";

        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        [TestCase(" 491802")]
        [TestCase("VAC000547307")]
        [TestCase("[[imgUrl]]")]
        [TestCase("separator.png")]
        public async Task GivenInvalidVacancyIdString_ThenVacancyNotFound(string vacancyId)
        {
            var response = await Mediator.Details(vacancyId, null);

            response.AssertCode(ApprenticeshipSearchMediatorCodes.Details.VacancyNotFound, false);
        }

        [Test]
        public async Task VacancyHasError()
        {
            const string message = "The vacancy has an error";

            var vacancyDetailViewModel = new ApprenticeshipVacancyDetailViewModel
            {
                ViewModelMessage = message,
                VacancyStatus = VacancyStatuses.Live
            };

            ApprenticeshipVacancyProvider.Setup(p => p.GetVacancyDetailViewModel(It.IsAny<Guid?>(), It.IsAny<int>())).Returns(Task.FromResult(vacancyDetailViewModel));

            var response = await Mediator.Details(Id, null);

            response.AssertMessage(ApprenticeshipSearchMediatorCodes.Details.VacancyHasError, message, UserMessageLevel.Warning, true);
        }

        [Test]
        public async Task Ok()
        {
            var vacancyDetailViewModel = new ApprenticeshipVacancyDetailViewModel
            {
                VacancyStatus = VacancyStatuses.Live
            };

            ApprenticeshipVacancyProvider.Setup(p => p.GetVacancyDetailViewModel(It.IsAny<Guid?>(), It.IsAny<int>())).Returns(Task.FromResult(vacancyDetailViewModel));

            var response = await Mediator.Details(Id, null);

            response.AssertCode(ApprenticeshipSearchMediatorCodes.Details.Ok, true);
        }

        [Test]
        public async Task PopulateDistance()
        {
            var vacancyDetailViewModel = new ApprenticeshipVacancyDetailViewModel
            {
                VacancyStatus = VacancyStatuses.Live
            };

            ApprenticeshipVacancyProvider.Setup(p => p.GetVacancyDetailViewModel(It.IsAny<Guid?>(), It.IsAny<int>())).Returns(Task.FromResult(vacancyDetailViewModel));

            UserDataProvider.Setup(udp => udp.Pop(CandidateDataItemNames.VacancyDistance)).Returns(VacancyDistance);
            UserDataProvider.Setup(udp => udp.Pop(CandidateDataItemNames.LastViewedVacancy)).Returns(VacancyType.Apprenticeship + "_" + Convert.ToString(Id));

            var response = await Mediator.Details(Id, null);

            response.AssertCode(ApprenticeshipSearchMediatorCodes.Details.Ok, true);
        }

        [Test]
        public async Task VacancyIsUnavailable_CandidateNotLoggedIn()
        {
            var vacancyDetailViewModel = new ApprenticeshipVacancyDetailViewModel
            {
                VacancyStatus = VacancyStatuses.Unavailable
            };

            ApprenticeshipVacancyProvider.Setup(
                p => p.GetVacancyDetailViewModel(It.IsAny<Guid?>(), It.IsAny<int>())).Returns(Task.FromResult(vacancyDetailViewModel));

            var response = await Mediator.Details(Id, null);

            response.AssertCodeAndMessage(ApprenticeshipSearchMediatorCodes.Details.VacancyNotFound);
        }

        [Test]
        public async Task VacancyIsUnavailble_CandidateLoggedInButHasNeverAppliedForVacancy()
        {
            var vacancyDetailViewModel = new ApprenticeshipVacancyDetailViewModel
            {
                VacancyStatus = VacancyStatuses.Unavailable
            };

            ApprenticeshipVacancyProvider.Setup(
                p => p.GetVacancyDetailViewModel(It.IsAny<Guid?>(), It.IsAny<int>())).Returns(Task.FromResult(vacancyDetailViewModel));

            var response = await Mediator.Details(Id, Guid.NewGuid());

            response.AssertCodeAndMessage(ApprenticeshipSearchMediatorCodes.Details.VacancyNotFound);
        }

        [Test]
        public async Task VacancyIsUnavailable_CandidateLoggedInAndHasPreviouslyAppliedForVacancy()
        {
            var vacancyDetailViewModel = new ApprenticeshipVacancyDetailViewModel
            {
                CandidateApplicationStatus = ApplicationStatuses.Submitted,
                VacancyStatus = VacancyStatuses.Unavailable
            };

            ApprenticeshipVacancyProvider.Setup(
                p => p.GetVacancyDetailViewModel(It.IsAny<Guid?>(), It.IsAny<int>())).Returns(Task.FromResult(vacancyDetailViewModel));

            var response = await Mediator.Details(Id, Guid.NewGuid());

            response.AssertCodeAndMessage(ApprenticeshipSearchMediatorCodes.Details.VacancyNotFound);
        }

        [Test]
        public async Task VacancyNotFound()
        {
            var response = await Mediator.Details(Id, null);

            response.AssertCode(ApprenticeshipSearchMediatorCodes.Details.VacancyNotFound, false);
        }
    }
}