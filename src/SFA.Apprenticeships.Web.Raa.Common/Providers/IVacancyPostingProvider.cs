namespace SFA.Apprenticeships.Web.Raa.Common.Providers
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using System.Web.Mvc;
    using ViewModels.Admin;
    using ViewModels.Provider;
    using ViewModels.ProviderUser;
    using ViewModels.Vacancy;
    using ViewModels.VacancyPosting;

    public interface IVacancyPostingProvider
    {
        Task<NewVacancyViewModel> GetNewVacancyViewModel(int vacancyReferenceNumber);

        Task<NewVacancyViewModel> GetNewVacancyViewModel(int vacancyOwnerRelationshipId, Guid vacancyGuid, int? numberOfPositions);

        Task<NewVacancyViewModel> UpdateVacancy(NewVacancyViewModel newVacancyViewModel);

        Task<VacancyMinimumData> UpdateVacancy(VacancyMinimumData vacancyMinimumData);

        Task<TrainingDetailsViewModel> GetTrainingDetailsViewModel(int vacancyReferenceNumber);

        Task<TrainingDetailsViewModel> UpdateVacancy(TrainingDetailsViewModel viewModel);

        Task<FurtherVacancyDetailsViewModel> GetVacancySummaryViewModel(int vacancyReferenceNumber);

        Task<VacancyRequirementsProspectsViewModel> GetVacancyRequirementsProspectsViewModel(int vacancyReferenceNumber);

        Task<VacancyQuestionsViewModel> GetVacancyQuestionsViewModel(int vacancyReferenceNumber);

        Task<VacancyQuestionsViewModel> UpdateVacancy(VacancyQuestionsViewModel viewModel);

        Task<FurtherVacancyDetailsViewModel> UpdateVacancy(FurtherVacancyDetailsViewModel viewModel);

        Task<FurtherVacancyDetailsViewModel> UpdateVacancyDates(FurtherVacancyDetailsViewModel viewModel);

        Task<VacancyRequirementsProspectsViewModel> UpdateVacancy(VacancyRequirementsProspectsViewModel viewModel);

        Task<VacancyViewModel> GetVacancy(int vacancyReferenceNumber);

        List<VacancyLocationAddressViewModel> GetLocationsAddressViewModelsByReferenceNumber(int vacancyReferenceNumber);

        List<VacancyLocationAddressViewModel> GetLocationsAddressViewModels(int vacancyId);

        Task<VacancyViewModel> SubmitVacancy(int vacancyReferenceNumber);

        Task<List<SelectListItem>> GetSectorsAndFrameworks();

        List<StandardViewModel> GetStandards();

        List<SelectListItem> GetSectors();

        StandardViewModel GetStandard(int? standardId);

        Task<VacanciesSummaryViewModel> GetVacanciesSummaryForProvider(int providerId, int providerSiteId, VacanciesSummarySearchViewModel vacanciesSummarySearch);

        Task<VacancyOwnerRelationshipViewModel> CloneVacancy(int vacancyReferenceNumber);

        Task<LocationSearchViewModel> LocationAddressesViewModel(string ukprn, int providerSiteId, int employerId, Guid vacancyGuid, bool isAnonymousEmployer = false);

        Task<VacancyViewModel> GetVacancy(Guid vacancyReferenceNumber);

        Task RemoveVacancyLocationInformation(Guid vacancyGuid);

        Task RemoveLocationAddresses(Guid vacancyGuid);

        Task<LocationSearchViewModel> AddLocations(LocationSearchViewModel viewModel);

        Task EmptyVacancyLocation(int vacancyReferenceNumber);
        Task CreateVacancy(VacancyMinimumData vacancyMinimumData);
        Task TransferVacancies(ManageVacancyTransferViewModel vacancyTransferViewModel);
        Task<FurtherVacancyDetailsViewModel> CloseVacancy(FurtherVacancyDetailsViewModel viewModel);
    }
}
