using SFA.Apprenticeships.Web.Common.Mediators;

namespace SFA.Apprenticeships.Web.Candidate.Mediators.Search
{
    using System;
    using System.Threading.Tasks;
    using Domain.Entities.Vacancies;
    using ViewModels.Account;
    using ViewModels.VacancySearch;

    public interface IApprenticeshipSearchMediator
    {
        MediatorResponse<ApprenticeshipSearchViewModel> Index(Guid? candidateId, ApprenticeshipSearchMode searchMode, bool reset);

        MediatorResponse<ApprenticeshipSearchViewModel> SearchValidation(Guid? candidateId, ApprenticeshipSearchViewModel model);

        MediatorResponse<ApprenticeshipSearchResponseViewModel> Results(Guid? candidateId, ApprenticeshipSearchViewModel model);

        MediatorResponse<ApprenticeshipSearchViewModel> SaveSearch(Guid candidateId, ApprenticeshipSearchViewModel viewModel);

        Task<MediatorResponse<ApprenticeshipVacancyDetailViewModel>> Details(string vacancyIdString, Guid? candidateId);

        Task<MediatorResponse<ApprenticeshipVacancyDetailViewModel>> DetailsByReferenceNumber(string vacancyReferenceNumberString, Guid? candidateId);

        MediatorResponse<SavedSearchViewModel> RunSavedSearch(Guid candidateId, ApprenticeshipSearchViewModel apprenticeshipSearchViewModel);

        Task<MediatorResponse<ApprenticeshipVacancyDetailViewModel>> RedirectToExternalWebsite(string id);
    }
}
