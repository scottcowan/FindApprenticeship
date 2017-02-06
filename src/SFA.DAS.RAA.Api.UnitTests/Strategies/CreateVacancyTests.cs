namespace SFA.DAS.RAA.Api.UnitTests.Strategies
{
    using System;
    using Api.Strategies;
    using Apprenticeships.Domain.Entities.Raa.Vacancies;
    using FluentAssertions;
    using NUnit.Framework;

    [TestFixture]
    [Parallelizable]
    public class CreateVacancyTests
    {
        public void VacancyGuidCannotBeReused()
        {
            var vacancy = new Vacancy
            {
                VacancyGuid = Guid.NewGuid()
            };

            var strategy = new CreateVacancyStrategy();

            //First call should be OK
            strategy.CreateVacancy(vacancy);
            //Second should throw an exception
            Action action = () => strategy.CreateVacancy(vacancy);
            action.ShouldThrow<Exception>().WithMessage("Something about duplicate GUIDs");
        }
    }
}