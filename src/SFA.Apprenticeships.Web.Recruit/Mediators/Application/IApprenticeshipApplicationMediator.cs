namespace SFA.Apprenticeships.Web.Recruit.Mediators.Application
{
    using System.Threading.Tasks;
    using Common.Mediators;
    using Raa.Common.ViewModels.Application;
    using Raa.Common.ViewModels.Application.Apprenticeship;

    public interface IApprenticeshipApplicationMediator
    {
        Task<MediatorResponse<ApprenticeshipApplicationViewModel>> Review(ApplicationSelectionViewModel applicationSelectionViewModel);
        Task<MediatorResponse<ApprenticeshipApplicationViewModel>> ReviewAppointCandidate(ApprenticeshipApplicationViewModel apprenticeshipApplicationViewModel);
        Task<MediatorResponse<ApprenticeshipApplicationViewModel>> ReviewRejectCandidate(ApprenticeshipApplicationViewModel apprenticeshipApplicationViewModel);
        Task<MediatorResponse<ApprenticeshipApplicationViewModel>> ReviewRevertToInProgress(ApprenticeshipApplicationViewModel apprenticeshipApplicationViewModel);
        Task<MediatorResponse<ApprenticeshipApplicationViewModel>> ReviewSetToSubmitted(ApprenticeshipApplicationViewModel apprenticeshipApplicationViewModel);
        Task<MediatorResponse<ApprenticeshipApplicationViewModel>> PromoteToInProgress(ApprenticeshipApplicationViewModel apprenticeshipApplicationViewModel);
        Task<MediatorResponse<ApprenticeshipApplicationViewModel>> ConfirmSuccessfulDecision(ApplicationSelectionViewModel applicationSelectionViewModel);
        Task<MediatorResponse<ApprenticeshipApplicationViewModel>> SendSuccessfulDecision(ApplicationSelectionViewModel applicationSelectionViewModel);
        Task<MediatorResponse<ApprenticeshipApplicationViewModel>> ConfirmUnsuccessfulDecision(ApplicationSelectionViewModel applicationSelectionViewModel);
        Task<MediatorResponse<ApprenticeshipApplicationViewModel>> SendUnsuccessfulDecision(ApprenticeshipApplicationViewModel applicationSelectionViewModel);
        Task<MediatorResponse<ApprenticeshipApplicationViewModel>> ConfirmRevertToInProgress(ApplicationSelectionViewModel applicationSelectionViewModel);
        Task<MediatorResponse<ApplicationSelectionViewModel>> RevertToInProgress(ApplicationSelectionViewModel applicationSelectionViewModel);
        Task<MediatorResponse<ApprenticeshipApplicationViewModel>> View(string application);
    }
}
