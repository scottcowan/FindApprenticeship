﻿namespace SFA.Apprenticeships.Application.UnitTests.Candidates.Strategies.ActivationReminder
{
    using Apprenticeships.Application.Candidates.Configuration;
    using Apprenticeships.Application.Candidates.Strategies;
    using Apprenticeships.Application.Candidates.Strategies.ActivationReminder;
    using Configuration;
    using Domain.Interfaces.Messaging;
    using Domain.Interfaces.Repositories;
    using Moq;
    using Interfaces;

    public class SetPendingDeletionStrategyBuilder
    {
        private Mock<IConfigurationService> _configurationService;
        private Mock<IUserWriteRepository> _userWriteRepository;
        private readonly Mock<IAuditRepository> _auditRepository = new Mock<IAuditRepository>();
        private readonly Mock<ILogService> _logService = new Mock<ILogService>();
        private readonly Mock<IServiceBus> _serviceBus = new Mock<IServiceBus>();

        private IHousekeepingStrategy _successor;

        public SetPendingDeletionStrategyBuilder()
        {
            _configurationService = new Mock<IConfigurationService>();
            _configurationService.Setup(s => s.Get<HousekeepingConfiguration>()).Returns(new HousekeepingConfigurationBuilder().Build());
            _userWriteRepository = new Mock<IUserWriteRepository>();
            _successor = new TerminatingHousekeepingStrategy(_configurationService.Object);
        }

        public SetPendingDeletionStrategy Build()
        {
            var strategy = new SetPendingDeletionStrategy(_configurationService.Object, _userWriteRepository.Object, _auditRepository.Object, _logService.Object, _serviceBus.Object);
            strategy.SetSuccessor(_successor);
            return strategy;
        }

        public SetPendingDeletionStrategyBuilder With(Mock<IConfigurationService> configurationService)
        {
            _configurationService = configurationService;
            return this;
        }

        public SetPendingDeletionStrategyBuilder With(HousekeepingConfiguration configuration)
        {
            _configurationService.Setup(s => s.Get<HousekeepingConfiguration>()).Returns(configuration);
            return this;
        }

        public SetPendingDeletionStrategyBuilder With(Mock<IUserWriteRepository> userWriteRepository)
        {
            _userWriteRepository = userWriteRepository;
            return this;
        }

        public SetPendingDeletionStrategyBuilder With(IHousekeepingStrategy successor)
        {
            _successor = successor;
            return this;
        }
    }
}