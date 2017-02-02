namespace SFA.Apprenticeships.Application.Candidate.Strategies.Traineeships
{
    using System;
    using System.Threading.Tasks;
    using Domain.Entities.Applications;

    public interface ICreateTraineeshipApplicationStrategy
    {
        Task<TraineeshipApplicationDetail> CreateApplication(Guid candidateId, int vacancyId);
    }
}
