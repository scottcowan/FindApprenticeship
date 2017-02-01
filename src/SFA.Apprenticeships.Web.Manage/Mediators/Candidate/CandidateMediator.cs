namespace SFA.Apprenticeships.Web.Manage.Mediators.Candidate
{
    using Common.Mediators;
    using Raa.Common.Factories;
    using Raa.Common.Providers;
    using Raa.Common.Validators.Candidate;
    using Raa.Common.ViewModels.Application;
    using Raa.Common.ViewModels.Application.Apprenticeship;
    using Raa.Common.ViewModels.Application.Traineeship;
    using Raa.Common.ViewModels.Candidate;
    using System;
    using System.Threading.Tasks;
    using ViewModels;

    public class CandidateMediator : MediatorBase, ICandidateMediator
    {
        private readonly ICandidateProvider _candidateProvider;
        private readonly IVacancyQAProvider _vacancyQaProvider;
        private readonly CandidateSearchViewModelServerValidator _candidateSearchViewModelServerValidator;

        public CandidateMediator(ICandidateProvider candidateProvider, IVacancyQAProvider vacancyQaProvider, CandidateSearchViewModelServerValidator candidateSearchViewModelServerValidator)
        {
            _candidateProvider = candidateProvider;
            _vacancyQaProvider = vacancyQaProvider;
            _candidateSearchViewModelServerValidator = candidateSearchViewModelServerValidator;
        }

        public MediatorResponse<CandidateSearchResultsViewModel> Search()
        {
            var viewModel = new CandidateSearchResultsViewModel
            {
                SearchViewModel = new CandidateSearchViewModel()
            };

            return GetMediatorResponse(CandidateMediatorCodes.Search.Ok, viewModel);
        }

        public MediatorResponse<CandidateSearchResultsViewModel> Search(CandidateSearchViewModel viewModel)
        {
            viewModel.PageSizes = SelectListItemsFactory.GetPageSizes(viewModel.PageSize);

            var validatonResult = _candidateSearchViewModelServerValidator.Validate(viewModel);

            if (!validatonResult.IsValid)
            {
                return GetMediatorResponse(CandidateMediatorCodes.Search.FailedValidation, new CandidateSearchResultsViewModel { SearchViewModel = viewModel }, validatonResult);
            }

            var resultsViewModel = _candidateProvider.SearchCandidates(viewModel, null);

            return GetMediatorResponse(CandidateMediatorCodes.Search.Ok, resultsViewModel);
        }

        public MediatorResponse<CandidateApplicationsViewModel> GetCandidateApplications(Guid candidateId)
        {
            var viewModel = _candidateProvider.GetCandidateApplications(candidateId);

            return GetMediatorResponse(CandidateMediatorCodes.GetCandidateApplications.Ok, viewModel);
        }

        public async Task<MediatorResponse<ApprenticeshipApplicationViewModel>> GetCandidateApprenticeshipApplication(Guid applicationId)
        {
            var viewModel = await _candidateProvider.GetCandidateApprenticeshipApplication(applicationId);

            return GetMediatorResponse(CandidateMediatorCodes.GetCandidateApprenticeshipApplication.Ok, viewModel);
        }

        public async Task<MediatorResponse<TraineeshipApplicationViewModel>> GetCandidateTraineeshipApplication(Guid applicationId)
        {
            var viewModel = await _candidateProvider.GetCandidateTraineeshipApplication(applicationId);

            return GetMediatorResponse(CandidateMediatorCodes.GetCandidateTraineeshipApplication.Ok, viewModel);
        }

        public async Task<MediatorResponse<CandidateVacancy>> GetCandidateApprenticeshipVacancyViewModel(int vacancyId, Guid applicationId)
        {
            var applicationViewModel = await _candidateProvider.GetCandidateApprenticeshipApplication(applicationId);
            var viewModel = await GetCandidateVacancy(vacancyId, applicationViewModel);
            return GetMediatorResponse(CandidateMediatorCodes.GetCandidateApprenticeshipVacancyViewModel.Ok, viewModel);
        }

        public async Task<MediatorResponse<CandidateVacancy>> GetCandidateTraineeshipVacancyViewModel(int vacancyId, Guid applicationId)
        {
            var applicationViewModel = await _candidateProvider.GetCandidateTraineeshipApplication(applicationId);
            var viewModel = await GetCandidateVacancy(vacancyId, applicationViewModel);
            return GetMediatorResponse(CandidateMediatorCodes.GetCandidateTraineeshipVacancyViewModel.Ok, viewModel);
        }

        private async Task<CandidateVacancy> GetCandidateVacancy(int vacancyId, ApplicationViewModel applicationViewModel)
        {
            var vacancyViewModel = await _vacancyQaProvider.GetVacancyById(vacancyId);
            vacancyViewModel.IsEditable = false;
            vacancyViewModel.IsCandidateView = true;
            return new CandidateVacancy
            {
                Vacancy = vacancyViewModel,
                Application = applicationViewModel
            };
        }
    }
}