﻿namespace SFA.Apprenticeships.Web.Manage.UnitTests.Mediators.Vacancy
{
    using Common.Constants;
    using Common.UnitTests.Mediators;
    using FluentAssertions;
    using Manage.Mediators.Vacancy;
    using Moq;
    using NUnit.Framework;
    using Raa.Common.Providers;
    using Raa.Common.ViewModels.Vacancy;

    [TestFixture]
    public class UnReserveForQATests
    {
        [Test]
        public void ShouldAlwaysReturnOk()
        {
            const int vacancyReferenceNumber = 1;
            var viewModel = VacancyMediatorTestHelper.GetValidVacancyViewModel(vacancyReferenceNumber);

            var provider = new Mock<IVacancyQAProvider>();

            provider.Setup(p => p.ReserveVacancyForQA(vacancyReferenceNumber)).Returns(viewModel);

            var mediator = new VacancyMediatorBuilder().Build();

            var result = mediator.UnReserveVacancyForQA(vacancyReferenceNumber);

            result.AssertCode(VacancyMediatorCodes.UnReserveVacancyForQA.Ok);
        }

        [Test]
        public void ShouldCallProviderUnreserveForQA()
        {
            const int vacancyReferenceNumber = 1;
            var viewModel = VacancyMediatorTestHelper.GetValidVacancyViewModel(vacancyReferenceNumber);

            var provider = new Mock<IVacancyQAProvider>();

            provider.Setup(p => p.ReserveVacancyForQA(vacancyReferenceNumber)).Returns(viewModel);

            var mediator = new VacancyMediatorBuilder().With(provider).Build();

            mediator.UnReserveVacancyForQA(vacancyReferenceNumber);
        
            provider.Verify(p => p.UnReserveVacancyForQA(vacancyReferenceNumber), Times.Once);
        }
    }
}