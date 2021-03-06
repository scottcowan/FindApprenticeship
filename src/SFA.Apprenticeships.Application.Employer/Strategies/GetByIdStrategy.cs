﻿namespace SFA.Apprenticeships.Application.Employer.Strategies
{
    using Domain.Entities.Raa.Parties;
    using Domain.Raa.Interfaces.Repositories;

    using SFA.Apprenticeships.Application.Interfaces;

    public class GetByIdStrategy : IGetByIdStrategy
    {
        private readonly IEmployerReadRepository _employerReadRepository;
        private readonly ILogService _logService;

        public GetByIdStrategy(IEmployerReadRepository employerReadRepository, ILogService logService)
        {
            _employerReadRepository = employerReadRepository;
            _logService = logService;
        }


        public Employer Get(int employerId, bool currentOnly)
        {
            _logService.Debug("Calling Employer Repository to get employer with Id='{0}'.", employerId);

            return _employerReadRepository.GetById(employerId, currentOnly);
        }
    }
}