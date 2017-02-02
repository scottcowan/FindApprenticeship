namespace SFA.Apprenticeships.Application.Candidate.Strategies.Apprenticeships
{
    using System;
    using System.Threading.Tasks;
    using Domain.Entities.Applications;

    public interface ICreateApprenticeshipApplicationStrategy
    {
        Task<ApprenticeshipApplicationDetail> CreateApplication(Guid candidateId, int vacancyId);
    }
}
