namespace SFA.Apprenticeships.Web.Recruit.Mediators.Application
{
    using System.Threading.Tasks;
    using Common.Mediators;
    using Raa.Common.ViewModels.Application;
    using Raa.Common.ViewModels.Application.Traineeship;

    public interface ITraineeshipApplicationMediator
    {
        Task<MediatorResponse<TraineeshipApplicationViewModel>> Review(ApplicationSelectionViewModel applicationSelectionViewModel);
        Task<MediatorResponse<TraineeshipApplicationViewModel>> ReviewSaveAndExit(TraineeshipApplicationViewModel traineeshipApplicationViewModel);
        Task<MediatorResponse<TraineeshipApplicationViewModel>> View(string application);
        Task<MediatorResponse<TraineeshipApplicationViewModel>> ReviewSetToSubmitted(TraineeshipApplicationViewModel traineeshipApplicationViewModel);
        Task<MediatorResponse<TraineeshipApplicationViewModel>> PromoteToInProgress(TraineeshipApplicationViewModel traineeshipApplicationViewModel);
    }
}
