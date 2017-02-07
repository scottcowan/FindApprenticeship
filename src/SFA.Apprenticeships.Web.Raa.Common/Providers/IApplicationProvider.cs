namespace SFA.Apprenticeships.Web.Raa.Common.Providers
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using ViewModels.Application;
    using ViewModels.Application.Apprenticeship;
    using ViewModels.Application.Traineeship;

    public interface IApplicationProvider
    {
        Task<VacancyApplicationsViewModel> GetVacancyApplicationsViewModel(VacancyApplicationsSearchViewModel vacancyApplicationsSearch);

        Task<ShareApplicationsViewModel> GetShareApplicationsViewModel(int vacancyReferenceNumber);

        Task<ApprenticeshipApplicationViewModel> GetApprenticeshipApplicationViewModel(ApplicationSelectionViewModel applicationSelectionViewModel);

        void UpdateApprenticeshipApplicationViewModelNotes(Guid applicationId, string notes, bool publishUpdate);

        ApplicationSelectionViewModel SendSuccessfulDecision(ApplicationSelectionViewModel applicationSelectionViewModel);

        ApplicationSelectionViewModel SendUnsuccessfulDecision(ApplicationSelectionViewModel applicationSelectionViewModel, string candidateApplicationFeedback);

        ApplicationSelectionViewModel SetStateInProgress(ApplicationSelectionViewModel applicationSelectionViewModel);
        ApplicationSelectionViewModel SetTraineeshipStateInProgress(ApplicationSelectionViewModel applicationSelectionViewModel);

        Task<TraineeshipApplicationViewModel> GetTraineeshipApplicationViewModel(ApplicationSelectionViewModel applicationSelectionViewModel);

        void UpdateTraineeshipApplicationViewModelNotes(Guid applicationId, string notes, bool publishUpdate);

        Task ShareApplications(int vacancyReferenceNumber, string providerName, IDictionary<string, string> applicationLinks
            , DateTime linkExpiryDateTime, string recipientEmailAddress, string optionalMessage = null);
        ApplicationSelectionViewModel SetStateSubmitted(ApplicationSelectionViewModel applicationSelection);
        ApplicationSelectionViewModel SetTraineeshipStateSubmitted(ApplicationSelectionViewModel applicationSelection);
        Task<BulkDeclineCandidatesViewModel> GetBulkDeclineCandidatesViewModel(BulkDeclineCandidatesViewModel bulkDeclineCandidatesViewModel);
        BulkDeclineCandidatesViewModel SendBulkUnsuccessfulDecision(BulkDeclineCandidatesViewModel bulkDeclineCandidatesViewModel);
    }
}
