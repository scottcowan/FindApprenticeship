﻿namespace SFA.Apprenticeships.Web.Raa.Common.UnitTests.Providers.ProviderProvider
{
    using Application.Interfaces.Employers;
    using Application.Interfaces.Providers;
    using Application.Interfaces.VacancyPosting;
    using Moq;
    using NUnit.Framework;
    using Common.Providers;
    using Application.Interfaces;
    using Web.Common.Configuration;

    public class TestBase
    {
        protected Mock<IProviderService> MockProviderService;
        protected Mock<IEmployerService> MockEmployerService;
        protected Mock<IConfigurationService> MockConfigurationService;
        protected Mock<IVacancyPostingService> MockVacancyPostingService;

        [SetUp]
        public void SetUp()
        {
            MockProviderService = new Mock<IProviderService>();
            MockEmployerService = new Mock<IEmployerService>();
            MockConfigurationService = new Mock<IConfigurationService>();
            MockConfigurationService.Setup(cs => cs.Get<CommonWebConfiguration>()).Returns(new CommonWebConfiguration {Features = new Features()});
            MockVacancyPostingService = new Mock<IVacancyPostingService>();
        }

        public IProviderProvider GetProviderProvider()
        {
            return new ProviderProvider(
                MockProviderService.Object,
                MockConfigurationService.Object,
                MockVacancyPostingService.Object,
                MockEmployerService.Object);
        }
    }
}
