﻿namespace SFA.Apprenticeships.Application.Employer.Strategies
{
    using System.Collections.Generic;
    using Domain.Entities.Raa.Parties;
    using Domain.Raa.Interfaces.Repositories;

    public class GetByIdsStrategy : IGetByIdsStrategy
    {
        private readonly IEmployerReadRepository _employerReadRepository;

        public GetByIdsStrategy(IEmployerReadRepository employerReadRepository)
        {
            _employerReadRepository = employerReadRepository;
        }

        public IEnumerable<Employer> Get(IEnumerable<int> employerIds)
        {
            return _employerReadRepository.GetByIds(employerIds);
        }

        public IEnumerable<MinimalEmployerDetails> GetMinimalDetails(IEnumerable<int> employerIds)
        {
            return _employerReadRepository.GetMinimalDetailsByIds(employerIds);
        }
    }
}