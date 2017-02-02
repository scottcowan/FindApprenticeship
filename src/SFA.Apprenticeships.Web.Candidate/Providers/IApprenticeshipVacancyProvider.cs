namespace SFA.Apprenticeships.Web.Candidate.Providers
{
    using System;
    using System.Threading.Tasks;
    using ViewModels.VacancySearch;

    public interface IApprenticeshipVacancyProvider
    {
        ApprenticeshipSearchResponseViewModel FindVacancies(ApprenticeshipSearchViewModel search);

        Task<ApprenticeshipVacancyDetailViewModel> GetVacancyDetailViewModel(Guid? candidateId, int vacancyId);

        Task<ApprenticeshipVacancyDetailViewModel> GetVacancyDetailViewModelByReferenceNumber(Guid? candidateId, int vacancyReferenceNumber);

        Task<ApprenticeshipVacancyDetailViewModel> IncrementClickThroughFor(int vacancyId);
    }
}