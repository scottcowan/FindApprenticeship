using SFA.Apprenticeships.Web.Common.Mediators;

namespace SFA.Apprenticeships.Web.Candidate.Mediators.Application
{
    using System;
    using System.Threading.Tasks;
    using ViewModels.Applications;
    using ViewModels.MyApplications;
    using ViewModels.VacancySearch;

    public interface IApprenticeshipApplicationMediator
    {
        Task<MediatorResponse<ApprenticeshipApplicationViewModel>> Apply(Guid candidateId, string vacancyIdString);

        Task<MediatorResponse<ApprenticeshipApplicationViewModel>> Resume(Guid candidateId, int vacancyId);

        Task<MediatorResponse<ApprenticeshipApplicationViewModel>> Save(Guid candidateId, int vacancyId, ApprenticeshipApplicationViewModel viewModel);

        Task<MediatorResponse<AutoSaveResultViewModel>> AutoSave(Guid candidateId, int vacancyId, ApprenticeshipApplicationViewModel viewModel);

        MediatorResponse<ApprenticeshipApplicationViewModel> AddEmptyQualificationRows(ApprenticeshipApplicationViewModel viewModel);

        MediatorResponse<ApprenticeshipApplicationViewModel> AddEmptyWorkExperienceRows(ApprenticeshipApplicationViewModel viewModel);

        MediatorResponse<ApprenticeshipApplicationViewModel> AddEmptyTrainingCourseRows(ApprenticeshipApplicationViewModel viewModel);

        Task<MediatorResponse<ApprenticeshipApplicationViewModel>> PreviewAndSubmit(Guid candidateId, int vacancyId, ApprenticeshipApplicationViewModel viewModel);

        Task<MediatorResponse<ApprenticeshipApplicationPreviewViewModel>> Preview(Guid candidateId, int vacancyId);

        Task<MediatorResponse<ApprenticeshipApplicationPreviewViewModel>> Submit(Guid candidateId, int vacancyId, ApprenticeshipApplicationPreviewViewModel viewModel);

        Task<MediatorResponse<WhatHappensNextApprenticeshipViewModel>> WhatHappensNext(Guid candidateId, string vacancyIdString, string vacancyReference, string vacancyTitle, string searchReturnUrl);

        Task<MediatorResponse<ApprenticeshipApplicationViewModel>> View(Guid candidateId, int vacancyId);

        Task<MediatorResponse<MyApprenticeshipApplicationViewModel>> CandidateApplicationFeedback(Guid candidateId,
            int vacancyId);

        Task<MediatorResponse<SavedVacancyViewModel>> SaveVacancy(Guid candidateId, int vacancyId);

        MediatorResponse<SavedVacancyViewModel> DeleteSavedVacancy(Guid candidateId, int vacancyId);
    }
}