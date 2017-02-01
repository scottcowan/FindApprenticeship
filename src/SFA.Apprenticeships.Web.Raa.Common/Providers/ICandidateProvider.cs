namespace SFA.Apprenticeships.Web.Raa.Common.Providers
{
    using System;
    using System.Threading.Tasks;
    using ViewModels.Application.Apprenticeship;
    using ViewModels.Application.Traineeship;
    using ViewModels.Candidate;

    public interface ICandidateProvider
    {
        CandidateSearchResultsViewModel SearchCandidates(CandidateSearchViewModel searchViewModel, string ukprn);
        CandidateApplicationsViewModel GetCandidateApplications(Guid candidateId);
        Task<ApprenticeshipApplicationViewModel> GetCandidateApprenticeshipApplication(Guid applicationId);
        Task<TraineeshipApplicationViewModel> GetCandidateTraineeshipApplication(Guid applicationId);
        CandidateApplicationSummariesViewModel GetCandidateApplicationSummaries(CandidateApplicationsSearchViewModel searchViewModel, string ukprn);
    }
}