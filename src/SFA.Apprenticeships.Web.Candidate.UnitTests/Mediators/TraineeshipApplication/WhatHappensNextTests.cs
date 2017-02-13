namespace SFA.Apprenticeships.Web.Candidate.UnitTests.Mediators.TraineeshipApplication
{
    using System;
    using System.Globalization;
    using System.Threading.Tasks;
    using Candidate.Mediators.Application;
    using Candidate.ViewModels.Applications;
    using Common.UnitTests.Mediators;
    using Domain.Entities.Applications;
    using FluentAssertions;
    using Moq;
    using NUnit.Framework;

    [TestFixture]
    [Parallelizable]
    public class WhatHappensNextTests : TestsBase
    {
        [SetUp]
        public void SetUp()
        {
            _someCandidateId = Guid.NewGuid();
        }

        private const int SomeVacancyId = 1;
        private const string VacancyReference = "001";
        private Guid _someCandidateId;
        private const string VacancyTitle = "Vacancy 001";

        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        [TestCase(" 491802")]
        [TestCase("VAC000547307")]
        [TestCase("[[imgUrl]]")]
        [TestCase("separator.png")]
        public async Task GivenInvalidVacancyIdString_ThenVacancyNotFound(string vacancyId)
        {
            var response = await Mediator.WhatHappensNext(_someCandidateId, vacancyId, VacancyReference, VacancyTitle);

            response.AssertCode(TraineeshipApplicationMediatorCodes.WhatHappensNext.VacancyNotFound, false);
        }

        [Test]
        public async Task HasError()
        {
            TraineeshipApplicationProvider.Setup(p => p.GetWhatHappensNextViewModel(It.IsAny<Guid>(), It.IsAny<int>()))
                .Returns(Task.FromResult(new WhatHappensNextTraineeshipViewModel("Has Error")));

            var response = await Mediator.WhatHappensNext(_someCandidateId,
                SomeVacancyId.ToString(CultureInfo.InvariantCulture), VacancyReference, VacancyTitle);

            response.AssertCode(TraineeshipApplicationMediatorCodes.WhatHappensNext.Ok, true);
            var viewModel = response.ViewModel;
            viewModel.VacancyReference.Should().Be(VacancyReference);
            viewModel.VacancyTitle.Should().Be(VacancyTitle);
        }

        [Test]
        public async Task Ok()
        {
            TraineeshipApplicationProvider.Setup(p => p.GetWhatHappensNextViewModel(It.IsAny<Guid>(), It.IsAny<int>()))
                .Returns(Task.FromResult(new WhatHappensNextTraineeshipViewModel()));

            var response = await Mediator.WhatHappensNext(_someCandidateId,
                SomeVacancyId.ToString(CultureInfo.InvariantCulture), VacancyReference, VacancyTitle);

            response.AssertCode(TraineeshipApplicationMediatorCodes.WhatHappensNext.Ok, true);
        }

        [Test]
        public async Task VacancyNotFound()
        {
            TraineeshipApplicationProvider.Setup(p => p.GetWhatHappensNextViewModel(It.IsAny<Guid>(), It.IsAny<int>()))
                .Returns(Task.FromResult(new WhatHappensNextTraineeshipViewModel {Status = ApplicationStatuses.ExpiredOrWithdrawn}));

            var response = await Mediator.WhatHappensNext(_someCandidateId,
                SomeVacancyId.ToString(CultureInfo.InvariantCulture), VacancyReference, VacancyTitle);

            response.AssertCode(TraineeshipApplicationMediatorCodes.WhatHappensNext.VacancyNotFound, false);
        }
    }
}