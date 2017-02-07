namespace SFA.Apprenticeships.Web.Candidate.Providers
{
    using System;
    using System.Threading.Tasks;
    using ViewModels.Applications;

    public interface ITraineeshipApplicationProvider
    {
        Task<TraineeshipApplicationViewModel> GetApplicationViewModel(Guid candidateId, int vacancyId);

        Task<TraineeshipApplicationViewModel> GetApplicationViewModelEx(Guid candidateId, int vacancyId);

        Task<TraineeshipApplicationViewModel> SubmitApplication(Guid candidateId, int vacancyId, TraineeshipApplicationViewModel traineeshipApplicationViewModel);

        Task<WhatHappensNextTraineeshipViewModel> GetWhatHappensNextViewModel(Guid candidateId, int vacancyId);

        TraineeshipApplicationViewModel PatchApplicationViewModel(Guid candidateId, TraineeshipApplicationViewModel savedModel, TraineeshipApplicationViewModel submittedModel);
    }
}
