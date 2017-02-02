namespace SFA.Apprenticeships.Web.Candidate.UnitTests.Mediators.ApprenticeshipApplication
{
    using System;
    using System.Threading.Tasks;
    using Candidate.Mediators.Application;
    using Candidate.ViewModels.Applications;
    using Common.UnitTests.Mediators;
    using Domain.Entities.Applications;
    using Domain.Entities.Vacancies;
    using FluentAssertions;
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
        private const string SomeErrorMessage = "Error message";
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
            var response = await Mediator.WhatHappensNext(_someCandidateId, vacancyId, VacancyReference, VacancyTitle, null);

            response.AssertCode(ApprenticeshipApplicationMediatorCodes.WhatHappensNext.VacancyNotFound, false);
        }

        [Test]
        public async Task ExpiredOrWithdrawnVacancyReturnsAVacancyNotFound()
        {
            ApprenticeshipApplicationProvider.Setup(
                p => p.GetWhatHappensNextViewModel(_someCandidateId, SomeVacancyId, null))
                .Returns(Task.FromResult(new WhatHappensNextApprenticeshipViewModel
                {
                    Status = ApplicationStatuses.ExpiredOrWithdrawn
                }));

            var response = await Mediator.WhatHappensNext(_someCandidateId, SomeVacancyId.ToString(), VacancyReference,
                VacancyTitle, null);

            response.Code.Should().Be(ApprenticeshipApplicationMediatorCodes.WhatHappensNext.VacancyNotFound);
        }

        [Test]
        public async Task IfModelHasError_PopulateVacancyTitleAndVacancyReferenceInTheModel()
        {
            ApprenticeshipApplicationProvider.Setup(
                p => p.GetWhatHappensNextViewModel(_someCandidateId, SomeVacancyId, null))
                .Returns(Task.FromResult(new WhatHappensNextApprenticeshipViewModel(SomeErrorMessage)));

            var response = await Mediator.WhatHappensNext(_someCandidateId, SomeVacancyId.ToString(), VacancyReference,
                VacancyTitle, null);
            response.AssertCode(ApprenticeshipApplicationMediatorCodes.WhatHappensNext.Ok, true);
            response.ViewModel.VacancyTitle = VacancyTitle;
            response.ViewModel.VacancyReference = VacancyReference;
        }

        [Test]
        public async Task Ok()
        {
            ApprenticeshipApplicationProvider.Setup(
                p => p.GetWhatHappensNextViewModel(_someCandidateId, SomeVacancyId, null))
                .Returns(Task.FromResult(new WhatHappensNextApprenticeshipViewModel
                {
                    VacancyStatus = VacancyStatuses.Live
                }));

            var response = await Mediator.WhatHappensNext(_someCandidateId, SomeVacancyId.ToString(), VacancyReference,
                VacancyTitle, null);

            response.AssertCode(ApprenticeshipApplicationMediatorCodes.WhatHappensNext.Ok, true);
        }
    }
}