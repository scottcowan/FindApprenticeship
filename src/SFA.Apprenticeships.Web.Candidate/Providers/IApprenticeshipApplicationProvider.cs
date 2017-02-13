namespace SFA.Apprenticeships.Web.Candidate.Providers
{
    using System;
    using System.Threading.Tasks;
    using ViewModels.Applications;
    using ViewModels.MyApplications;
    using ViewModels.VacancySearch;

    public interface IApprenticeshipApplicationProvider
    {
        Task<ApprenticeshipApplicationViewModel> GetApplicationViewModel(Guid candidateId, int vacancyId);

        Task<ApprenticeshipApplicationPreviewViewModel> GetApplicationPreviewViewModel(Guid candidateId, int vacancyId);

        Task<ApprenticeshipApplicationViewModel> CreateApplicationViewModel(Guid candidateId, int vacancyId);

        ApprenticeshipApplicationViewModel PatchApplicationViewModel(Guid candidateId, ApprenticeshipApplicationViewModel savedModel, ApprenticeshipApplicationViewModel submittedModel);

        MyApplicationsViewModel GetMyApplications(Guid candidateId);

        void SaveApplication(Guid candidateId, int vacancyId, ApprenticeshipApplicationViewModel apprenticeshipApplicationViewModel);

        Task<ApprenticeshipApplicationViewModel> SubmitApplication(Guid candidateId, int vacancyId);

        Task<WhatHappensNextApprenticeshipViewModel> GetWhatHappensNextViewModel(Guid candidateId, int vacancyId, string searchReturnUrl);

        ApprenticeshipApplicationViewModel ArchiveApplication(Guid candidateId, int vacancyId);

        ApprenticeshipApplicationViewModel UnarchiveApplication(Guid candidateId, int vacancyId);

        ApprenticeshipApplicationViewModel DeleteApplication(Guid candidateId, int vacancyId);

        TraineeshipFeatureViewModel GetTraineeshipFeatureViewModel(Guid candidateId);

        Task<SavedVacancyViewModel> SaveVacancy(Guid candidateId, int vacancyId);

        SavedVacancyViewModel DeleteSavedVacancy(Guid candidateId, int vacancyId);
    }
}
