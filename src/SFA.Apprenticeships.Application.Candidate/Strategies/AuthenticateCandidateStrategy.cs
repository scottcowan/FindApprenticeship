﻿namespace SFA.Apprenticeships.Application.Candidate.Strategies
{
    using System;
    using Domain.Entities.Candidates;
    using Domain.Entities.Users;
    using Domain.Interfaces.Messaging;
    using Domain.Interfaces.Repositories;
    using Interfaces.Users;

    using SFA.Apprenticeships.Application.Interfaces;

    using UserAccount.Configuration;
    using UserAccount.Entities;
    using UserAccount.Strategies;

    public class AuthenticateCandidateStrategy : IAuthenticateCandidateStrategy
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly IUserReadRepository _userReadRepository;
        private readonly IUserWriteRepository _userWriteRepository;
        private readonly ICandidateReadRepository _candidateReadRepository;
        private readonly ILockAccountStrategy _lockAccountStrategy;
        private readonly IServiceBus _serviceBus;
        private readonly int _maximumPasswordAttemptsAllowed;

        public AuthenticateCandidateStrategy(
            IConfigurationService configService,
            IAuthenticationService authenticationService,
            IUserReadRepository userReadRepository,
            IUserWriteRepository userWriteRepository,
            ICandidateReadRepository candidateReadRepository,
            ILockAccountStrategy lockAccountStrategy, IServiceBus serviceBus)
        {
            _userWriteRepository = userWriteRepository;
            _authenticationService = authenticationService;
            _userReadRepository = userReadRepository;
            _candidateReadRepository = candidateReadRepository;
            _lockAccountStrategy = lockAccountStrategy;
            _serviceBus = serviceBus;
            _maximumPasswordAttemptsAllowed = configService.Get<UserAccountConfiguration>().MaximumPasswordAttemptsAllowed;
        }

        public Candidate AuthenticateCandidate(string username, string password)
        {
            var user = _userReadRepository.Get(username, false);

            if (user != null)
            {
                user.AssertState("Authenticate user", UserStatuses.Active, UserStatuses.PendingActivation, UserStatuses.Locked, UserStatuses.Dormant);

                if (_authenticationService.AuthenticateUser(user.EntityId, password))
                {
                    var candidate = _candidateReadRepository.Get(user.EntityId);

                    if (user.LoginIncorrectAttempts > 0)
                    {
                        user.LoginIncorrectAttempts = 0;
                    }

                    if (user.Status == UserStatuses.Dormant)
                    {
                        user.Status = UserStatuses.Active;
                    }

                    user.LastLogin = DateTime.UtcNow;

                    _userWriteRepository.Save(user);
                    _serviceBus.PublishMessage(new CandidateUserUpdate(user.EntityId, CandidateUserUpdateType.Update));

                    return candidate;
                }

                RegisterFailedLogin(user);
            }

            return null;
        }

        private void RegisterFailedLogin(User user)
        {
            user.LoginIncorrectAttempts++;

            if (user.LoginIncorrectAttempts < _maximumPasswordAttemptsAllowed)
            {
                _userWriteRepository.Save(user);
            }
            else
            {
                _lockAccountStrategy.LockAccount(user);
                _serviceBus.PublishMessage(new CandidateUserUpdate(user.EntityId, CandidateUserUpdateType.Update));
            }
        }
    }
}
