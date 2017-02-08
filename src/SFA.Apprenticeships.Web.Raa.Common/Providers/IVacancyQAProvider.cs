namespace SFA.Apprenticeships.Web.Raa.Common.Providers
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using System.Web.Mvc;
    using ViewModels.Vacancy;
    using ViewModels.VacancyPosting;

    public interface IVacancyQAProvider
    {
        DashboardVacancySummariesViewModel GetPendingQAVacanciesOverview(DashboardVacancySummariesSearchViewModel searchViewModel);

        List<DashboardVacancySummaryViewModel> GetPendingQAVacancies();

        Task<QAActionResultCode> ApproveVacancy(int vacancyReferenceNumber);

        Task<QAActionResultCode> RejectVacancy(int vacancyReferenceNumber);

        Task<VacancyViewModel> ReserveVacancyForQA(int vacancyReferenceNumber);

        Task<VacancyViewModel> ReviewVacancy(int vacancyReferenceNumber);

        Task<NewVacancyViewModel> GetNewVacancyViewModel(int vacancyReferenceNumber);

        Task<TrainingDetailsViewModel> GetTrainingDetailsViewModel(int vacancyReferenceNumber);

        Task<FurtherVacancyDetailsViewModel> GetVacancySummaryViewModel(int vacancyReferenceNumber);

        Task<VacancyRequirementsProspectsViewModel> GetVacancyRequirementsProspectsViewModel(int vacancyReferenceNumber);

        Task<VacancyQuestionsViewModel> GetVacancyQuestionsViewModel(int vacancyReferenceNumber);

        Task<QAActionResult<FurtherVacancyDetailsViewModel>> UpdateVacancyWithComments(FurtherVacancyDetailsViewModel viewModel);

        Task<QAActionResult<NewVacancyViewModel>> UpdateVacancyWithComments(NewVacancyViewModel viewModel);

        Task<QAActionResult<TrainingDetailsViewModel>> UpdateVacancyWithComments(TrainingDetailsViewModel viewModel);

        Task<QAActionResult<VacancyRequirementsProspectsViewModel>> UpdateVacancyWithComments(VacancyRequirementsProspectsViewModel viewModel);

        Task<QAActionResult<VacancyQuestionsViewModel>> UpdateVacancyWithComments(VacancyQuestionsViewModel viewModel);

        Task<List<SelectListItem>> GetSectorsAndFrameworks();

        List<StandardViewModel> GetStandards();

        List<SelectListItem> GetSectors();

        Task RemoveLocationAddresses(Guid vacancyGuid);

        Task<NewVacancyViewModel> UpdateEmployerInformationWithComments(NewVacancyViewModel existingVacancy);

        Task<LocationSearchViewModel> LocationAddressesViewModel(string ukprn, int providerSiteId, int employerId, Guid vacancyGuid, bool isAnonymousEmployer = false);

        Task<LocationSearchViewModel> AddLocations(LocationSearchViewModel viewModel);

        Task<VacancyViewModel> GetVacancyById(int vacancyId);

        Task<VacancyViewModel> GetVacancy(Guid vacancyGuid);

        Task<VacancyViewModel> GetVacancy(int vacancyReferenceNumber);

        List<VacancyLocationAddressViewModel> GetLocationsAddressViewModelsByReferenceNumber(int vacancyReferenceNumber);

        List<VacancyLocationAddressViewModel> GetLocationsAddressViewModels(int vacancyId);

        DashboardVacancySummaryViewModel GetNextAvailableVacancy();

        Task UnReserveVacancyForQA(int vacancyReferenceNumber);
    }
}
