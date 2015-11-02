﻿namespace SFA.Apprenticeship.Api.AvmsCompatability.UnitTests.ServiceImplementation.Version51
{
    using System;
    using System.Linq;
    using Apprenticeships.Application.ReferenceData;
    using Apprenticeships.Domain.Entities.ReferenceData;
    using Apprenticeships.Infrastructure.Common.Mappers;
    using AvmsCompatability.Mappers.Version51;
    using FluentAssertions;
    using MessageContracts.Version51;
    using Moq;
    using NUnit.Framework;
    using ReferenceDataService = AvmsCompatability.ServiceImplementation.Version51.ReferenceDataService;

    // TODO: US868: API: reinstate tests here.

    [TestFixture]
    public class ReferenceDataServiceTests
    {
        private ReferenceDataService _service;
        private MapperEngine _mapper;
        private Mock<IReferenceDataProvider> _mockReferenceDataProvider;

        [SetUp]
        public void SetUp()
        {
            _mockReferenceDataProvider = new Mock<IReferenceDataProvider>();
            _mapper = new AvReferenceDataServiceMapper();

            _service = new ReferenceDataService(
                _mapper,
                _mockReferenceDataProvider.Object);
        }

        [Test]
        [Ignore]
        public void ShouldReflectRequestMessageIdInResponse()
        {
            // Arrange.
            var request = new GetApprenticeshipFrameworksRequest
            {
                MessageId = Guid.NewGuid()
            };

            // Act.
            var response = _service.GetApprenticeshipFrameworks(request);

            // Assert.
            response.Should().NotBeNull();
            response.MessageId.ShouldBeEquivalentTo(request.MessageId);
        }

        [Test]
        [Ignore]
        public void ShouldGetApprenticeshipFrameworks()
        {
            // Arrange.
            var request = new GetApprenticeshipFrameworksRequest();

            // Act.
            _service.GetApprenticeshipFrameworks(request);

            // Assert.
            _mockReferenceDataProvider.Verify(mock =>
                mock.GetCategories(), Times.Once());
        }

        [Test]
        [Ignore]
        public void ShouldMapApprenticeshipFrameworks()
        {
            // Arrange.
            var request = new GetApprenticeshipFrameworksRequest();

            var categories = Enumerable.Empty<Category>();

            _mockReferenceDataProvider.Setup(mock =>
                mock.GetCategories())
                .Returns(categories);

            // Act.
            var response = _service.GetApprenticeshipFrameworks(request);

            // Assert.
            response.Should().NotBeNull();
            response.ApprenticeshipFrameworks.Should().NotBeNull();
        }

        [Test]
        [Ignore]
        public void ShouldAuthenticateRequest()
        {            
        }
    }
}
