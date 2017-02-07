namespace SFA.DAS.RAA.Api.UnitTests.Mappers
{
    using Api.Mappers;
    using NUnit.Framework;

    [TestFixture]
    [Parallelizable]
    public class ApiMappersTests
    {
        [Test]
        public void ShouldCreateMap()
        {
            new ApiMappers().Mapper.AssertConfigurationIsValid();
        }
    }
}