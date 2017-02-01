namespace SFA.DAS.RAA.Api.Service.UnitTests.V1.Mappers
{
    using NUnit.Framework;
    using Service.V1.Mappers;
    using ApiWage = Client.V1.Models.Wage;
    using ApiVacancy = Client.V1.Models.Vacancy;

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
    }
}