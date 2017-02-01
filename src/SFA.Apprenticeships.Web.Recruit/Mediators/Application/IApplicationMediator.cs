namespace SFA.Apprenticeships.Web.Recruit.Mediators.Application
{
    using System.Threading.Tasks;
    using Common.Mediators;
    using Raa.Common.ViewModels.Application;
    using System.Web.Mvc;

    public interface IApplicationMediator
    {
        Task<MediatorResponse<VacancyApplicationsViewModel>> GetVacancyApplicationsViewModel(VacancyApplicationsSearchViewModel vacancyApplicationsSearch);
        Task<MediatorResponse<ShareApplicationsViewModel>> ShareApplications(int vacancyReferenceNumber);
        Task<MediatorResponse<ShareApplicationsViewModel>> ShareApplications(ShareApplicationsViewModel vacancyReferenceNumber, UrlHelper urlHelper);
        Task<MediatorResponse<BulkDeclineCandidatesViewModel>> GetBulkDeclineCandidatesViewModel(BulkDeclineCandidatesViewModel bulkDeclineCandidatesViewModel);
        Task<MediatorResponse<BulkDeclineCandidatesViewModel>> ConfirmBulkDeclineCandidates(BulkDeclineCandidatesViewModel bulkDeclineCandidatesViewModel);
        Task<MediatorResponse<BulkDeclineCandidatesViewModel>> SendBulkUnsuccessfulDecision(BulkDeclineCandidatesViewModel bulkDeclineCandidatesViewModel);
    }
}