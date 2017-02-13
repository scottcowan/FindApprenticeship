namespace SFA.Apprenticeships.Web.Candidate.UnitTests.Mediators.TraineeshipApplication
{
    using System;
    using System.Globalization;
    using System.Threading.Tasks;
    using Candidate.Mediators.Application;
    using Candidate.ViewModels.Applications;
    using Common.UnitTests.Mediators;
    using Moq;
    using NUnit.Framework;

    [TestFixture]
    [Parallelizable]
    public class ApplyTests : TestsBase
    {
        private const int ValidVacancyId = 1;
        private const int InvalidVacancyId = 99999;

        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        [TestCase(" 491802")]
        [TestCase("VAC000547307")]
        [TestCase("[[imgUrl]]")]
        [TestCase("separator.png")]
        public async Task GivenInvalidVacancyIdString_ThenVacancyNotFound(string vacancyId)
        {
            var response = await Mediator.Apply(Guid.NewGuid(), vacancyId);

            response.AssertCode(TraineeshipApplicationMediatorCodes.Apply.VacancyNotFound, false);
        }

        [Test]
        public async Task HasError()
        {
            TraineeshipApplicationProvider.Setup(p => p.GetApplicationViewModel(It.IsAny<Guid>(), InvalidVacancyId))
                .Returns(Task.FromResult(new TraineeshipApplicationViewModel("Vacancy not found")));

            var response = await Mediator.Apply(Guid.NewGuid(), InvalidVacancyId.ToString(CultureInfo.InvariantCulture));

            response.AssertCode(TraineeshipApplicationMediatorCodes.Apply.HasError, false);
        }

        [Test]
        public async Task Ok()
        {
            TraineeshipApplicationProvider.Setup(p => p.GetApplicationViewModel(It.IsAny<Guid>(), ValidVacancyId))
                .Returns(Task.FromResult(new TraineeshipApplicationViewModel()));

            var response = await Mediator.Apply(Guid.NewGuid(), ValidVacancyId.ToString(CultureInfo.InvariantCulture));

            response.AssertCode(TraineeshipApplicationMediatorCodes.Apply.Ok, true);
        }
    }
}