namespace SFA.DAS.RAA.Api.Service.UnitTests.V1.Mappers
{
    using Apprenticeships.Domain.Entities.Raa.Vacancies;
    using Apprenticeships.Domain.Entities.Vacancies;
    using NUnit.Framework;
    using Ploeh.AutoFixture;
    using Service.V1.Mappers;
    using ApiWage = Client.V1.Models.Wage;
    using ApiVacancy = Client.V1.Models.Vacancy;
    using ApprenticeshipLevel = Apprenticeships.Domain.Entities.Raa.Vacancies.ApprenticeshipLevel;
    using PublicWage = Client.V1.Models.PublicWage;
    using PublicVacancy = Client.V1.Models.PublicVacancy;
    using PublicVacancySummary = Client.V1.Models.PublicVacancySummary;
    using TrainingType = Apprenticeships.Domain.Entities.Raa.Vacancies.TrainingType;
    using VacancyLocationType = Apprenticeships.Domain.Entities.Raa.Vacancies.VacancyLocationType;
    using VacancySummary = Apprenticeships.Domain.Entities.Raa.Vacancies.VacancySummary;
    using VacancyType = Apprenticeships.Domain.Entities.Raa.Vacancies.VacancyType;

    [TestFixture]
    [Parallelizable]
    public class ApiClientMappersTests
    {
        [Test]
        public void ShouldCreateMap()
        {
            new ApiClientMappers().Mapper.AssertConfigurationIsValid();
        }

        [Test]
        public void WageMappingTest()
        {
            var mappers = new ApiClientMappers();

            var apiWage = new ApiWage("NationalMinimum", null, null, null, null, "£120.00 - £208.50", "Weekly", 30);
            var apiVacancy = new ApiVacancy {Wage = apiWage};

            var vacancy = mappers.Map<ApiVacancy, ApiVacancy>(apiVacancy);
        }

        [Test]
        public void PublicVacancySummaryMappingTest()
        {
            var mappers = new ApiClientMappers();

            var publicVacancyWage = new Fixture().Build<PublicWage>()
                .With(v => v.Type, WageType.NationalMinimum.ToString())
                .With(v => v.Unit, WageUnit.Weekly.ToString())
                .Create();
            var publicVacancySummary = new Fixture().Build<PublicVacancySummary>()
                .With(v => v.DurationType, DurationType.Weeks.ToString())
                .With(v => v.TrainingType, TrainingType.Frameworks.ToString())
                .With(v => v.ApprenticeshipLevel, ApprenticeshipLevel.FoundationDegree.ToString())
                .With(v => v.Status, VacancyStatus.Live.ToString())
                .With(v => v.VacancyType, VacancyType.Apprenticeship.ToString())
                .With(v => v.VacancyLocationType, VacancyLocationType.SpecificLocation.ToString())
                .With(v => v.Wage, publicVacancyWage)
                .Create();

            var vacancy = mappers.Map<PublicVacancySummary, VacancySummary>(publicVacancySummary);
        }

        [Test]
        public void PublicVacancyMappingTest()
        {
            var mappers = new ApiClientMappers();

            var publicVacancyWage = new Fixture().Build<PublicWage>()
                .With(v => v.Type, WageType.NationalMinimum.ToString())
                .With(v => v.Unit, WageUnit.Weekly.ToString())
                .Create();
            var publicVacancy = new Fixture().Build<PublicVacancy>()
                .With(v => v.DurationType, DurationType.Weeks.ToString())
                .With(v => v.TrainingType, TrainingType.Frameworks.ToString())
                .With(v => v.ApprenticeshipLevel, ApprenticeshipLevel.FoundationDegree.ToString())
                .With(v => v.Status, VacancyStatus.Live.ToString())
                .With(v => v.VacancyType, VacancyType.Apprenticeship.ToString())
                .With(v => v.VacancyLocationType, VacancyLocationType.SpecificLocation.ToString())
                .With(v => v.Wage, publicVacancyWage)
                .Create();

            var vacancy = mappers.Map<PublicVacancy, Vacancy>(publicVacancy);
        }
    }
}