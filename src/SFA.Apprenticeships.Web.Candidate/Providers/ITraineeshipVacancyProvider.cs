namespace SFA.Apprenticeships.Web.Candidate.Providers
{
    using System;
    using System.Threading.Tasks;
    using ViewModels.VacancySearch;

    public interface ITraineeshipVacancyProvider
    {
        TraineeshipSearchResponseViewModel FindVacancies(TraineeshipSearchViewModel search);

        Task<TraineeshipVacancyDetailViewModel> GetVacancyDetailViewModel(Guid? candidateId, int vacancyId);

        Task<TraineeshipVacancyDetailViewModel> GetVacancyDetailViewModelByReferenceNumber(Guid? candidateId, int vacancyReferenceNumber);
    }
}