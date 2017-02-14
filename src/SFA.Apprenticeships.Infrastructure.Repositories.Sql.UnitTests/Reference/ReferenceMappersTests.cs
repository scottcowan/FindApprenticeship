namespace SFA.Apprenticeships.Infrastructure.Repositories.Sql.UnitTests.Reference
{
    using Application.Interfaces;
    using Domain.Entities.Raa.Reference;
    using Domain.Entities.Raa.Vacancies;
    using FluentAssertions;
    using NUnit.Framework;
    using Ploeh.AutoFixture;
    using Schemas.Reference;
    using Schemas.Reference.Entities;
    using DomainFramework = Domain.Entities.Raa.Reference.Framework;
    using DomainOccupation = Domain.Entities.Raa.Reference.Occupation;
    using DomainSector = Domain.Entities.Raa.Vacancies.Sector;
    using DomainStandard = Domain.Entities.Raa.Vacancies.Standard;
    using Standard = Schemas.Reference.Entities.Standard;

    [TestFixture]
    [Parallelizable]
    public class ReferenceMappersTests
    {
        private IMapper _mapper;

        [OneTimeSetUp]
        public void Setup()
        {
            _mapper = new ReferenceMappers();
        }

        [Test]
        public void ShouldCreateMap()
        {
            new ReferenceMappers().Mapper.AssertConfigurationIsValid();
        }

        [Test]
        public void ShouldMapSector_DbToDomain()
        {
            //Arrange
            var source = new StandardSector() { FullName = "my lovely name" };

            //Act
            var destination = _mapper.Map<StandardSector, DomainSector>(source);

            //Assert
            destination.Should().NotBeNull();
            destination.Name.Should().Be(source.FullName);
            destination.Id.Should().Be(source.StandardSectorId);
            destination.Standards.Should().BeNull();
        }

        [Test]
        public void ShouldMapSector_DomainToDb()
        {
            //Arrange
            var source = new Fixture().Build<DomainSector>().Create();

            //Act
            var destination = _mapper.Map<DomainSector, StandardSector>(source);

            //Assert
            destination.Should().NotBeNull();
            destination.FullName.Should().Be(source.Name);
            destination.StandardSectorId.Should().Be(source.Id);
        }

        [Test]
        public void ShouldMapFramework_DbToDomain()
        {
            //Arrange
            var source = new ApprenticeshipFramework()
            {
                FullName = "Fake full name",
                CodeName = "fakeness",
                ShortName = "Shortie"
            };

            //Act
            var destination = _mapper.Map<ApprenticeshipFramework, DomainFramework>(source);

            //Assert
            destination.Should().NotBeNull();
            destination.FullName.Should().Be(source.FullName);
            destination.CodeName.Should().Be(source.CodeName);
            destination.ShortName.Should().Be(source.ShortName);
            destination.Id.Should().Be(source.ApprenticeshipFrameworkId);
        }

        [Test]
        public void ShouldMapFramework_DomainToDb()
        {
            //Arrange
            var source = new Fixture().Build<DomainFramework>().Create();

            //Act
            var destination = _mapper.Map<DomainFramework, ApprenticeshipFramework>(source);

            //Assert
            destination.Should().NotBeNull();
            destination.FullName.Should().Be(source.FullName);
            destination.CodeName.Should().Be(source.CodeName);
            destination.ShortName.Should().Be(source.ShortName);
            destination.ApprenticeshipFrameworkId.Should().Be(source.Id);
            destination.ApprenticeshipFrameworkStatusTypeId.Should().Be((int)source.Status);
            destination.ClosedDate.Should().NotHaveValue();
            destination.PreviousApprenticeshipOccupationId.Should().NotHaveValue();
        }

        [Test]
        public void ShouldMapStandard_DbToDomain()
        {

            //Arrange
            var source = new Standard
            {
                FullName = "Fake full name",
                ApprenticeshipFrameworkStatusTypeId = 1,
                EducationLevelId = 2,
                LarsCode = 2,
                StandardId = 1,
                StandardSectorId = 1
            };

            //Act
            var destination = _mapper.Map<Standard, DomainStandard>(source);

            //Assert
            destination.Should().NotBeNull();
            destination.ApprenticeshipLevel.Should().Be((ApprenticeshipLevel)source.EducationLevelId);
            destination.ApprenticeshipSectorId.Should().Be(source.StandardSectorId);
            destination.Id.Should().Be(source.StandardId);
            destination.LarsCode.Should().Be(source.LarsCode);
            destination.Name.Should().Be(source.FullName);
            destination.Status.Should().Be((FrameworkStatusType)source.ApprenticeshipFrameworkStatusTypeId);
        }

        [Test]
        public void ShouldMapStandard_DomainToDb()
        {
            //Arrange
            var source = new Fixture().Build<DomainStandard>().Create();

            //Act
            var destination = _mapper.Map<DomainStandard, Standard>(source);

            //Assert
            destination.Should().NotBeNull();
            destination.FullName.Should().Be(source.Name);
            destination.EducationLevelId.Should().Be((int)source.ApprenticeshipLevel);
            destination.LarsCode.Should().Be(source.LarsCode);
            destination.ApprenticeshipFrameworkStatusTypeId.Should().Be((int)source.Status);
            destination.StandardId.Should().Be(source.Id);
            destination.StandardSectorId.Should().Be(source.ApprenticeshipSectorId);
        }

        [Test]
        public void ShouldMapOccupation_DomainToDb()
        {
            //Arrange
            var source = new Fixture().Build<DomainOccupation>().Create();

            //Act
            var destination = _mapper.Map<DomainOccupation, ApprenticeshipOccupation>(source);

            //Assert
            destination.Should().NotBeNull();
            destination.FullName.Should().Be(source.FullName);
            destination.CodeName.Should().Be(source.CodeName);
            destination.ShortName.Should().Be(source.ShortName);
        }

        [Test]
        public void ShouldMapOccupation_DbToDomain()
        {
            //Arrange
            var source = new ApprenticeshipOccupation() { FullName = "Fullness", CodeName = "Coded", ShortName = "Short name" };

            //Act
            var destination = _mapper.Map<ApprenticeshipOccupation, DomainOccupation>(source);

            //Assert
            destination.Should().NotBeNull();
            destination.FullName.Should().Be(source.FullName);
            destination.CodeName.Should().Be(source.CodeName);
            destination.ShortName.Should().Be(source.ShortName);
            destination.Frameworks.Should().BeNull();
        }
    }
}