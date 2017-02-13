namespace SFA.Apprenticeships.Application.UnitTests.Candidate.Strategies.CreateApplicationStrategy
{
    using System;
    using System.Threading.Tasks;
    using Apprenticeships.Application.Candidate.Strategies.Apprenticeships;
    using Apprenticeships.Application.Vacancy;
    using Domain.Entities.Vacancies;
    using Domain.Interfaces.Repositories;
    using FluentAssertions;
    using Moq;
    using NUnit.Framework;
    using Vacancy;

    [TestFixture]
    public class GivenAFaultedServer
    {
        [Test]
        public void WhenCreatingANewApplication_ShouldThrowACustomException()
        {
            var vacancyDataProvider = new Mock<IVacancyDataProvider<ApprenticeshipVacancyDetail>>();
            var applicationReadRepository = new Mock<IApprenticeshipApplicationReadRepository>();
            var applicationWriteRepository = new Mock<IApprenticeshipApplicationWriteRepository>();
            var candidateReadRepository = new Mock<ICandidateReadRepository>();

            applicationReadRepository.Setup(arr => arr.GetForCandidate(It.IsAny<Guid>(),
                It.IsAny<int>(), It.IsAny<bool>())).Throws<Exception>();

            var createApplicationStrategy = new CreateApprenticeshipApplicationStrategy(vacancyDataProvider.Object,
                applicationReadRepository.Object, applicationWriteRepository.Object,
                candidateReadRepository.Object, null);

            Func<Task> action = async () => { await createApplicationStrategy.CreateApplication(Guid.NewGuid(), 1); };

            action.ShouldThrow<Exception>();
        }
    }
}