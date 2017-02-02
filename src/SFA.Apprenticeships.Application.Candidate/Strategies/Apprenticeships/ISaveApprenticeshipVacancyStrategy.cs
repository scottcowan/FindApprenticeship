namespace SFA.Apprenticeships.Application.Candidate.Strategies.Apprenticeships
{
    using System;
    using System.Threading.Tasks;
    using Domain.Entities.Applications;

    public interface ISaveApprenticeshipVacancyStrategy
    {
        Task<ApprenticeshipApplicationDetail> SaveVacancy(Guid candidateId, int vacancyId);
    }
}