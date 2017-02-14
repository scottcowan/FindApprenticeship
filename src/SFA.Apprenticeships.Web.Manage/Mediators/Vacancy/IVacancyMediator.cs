namespace SFA.Apprenticeships.Web.Manage.Mediators.Vacancy
{
    using Common.Mediators;
    using Raa.Common.ViewModels.Provider;
    using Raa.Common.ViewModels.Vacancy;
    using Raa.Common.ViewModels.VacancyPosting;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IVacancyMediator
    {
        Task<MediatorResponse<DashboardVacancySummaryViewModel>> ApproveVacancy(int vacancyReferenceNumber);

        Task<MediatorResponse<DashboardVacancySummaryViewModel>> RejectVacancy(int vacancyReferenceNumber);

        Task<MediatorResponse<VacancyViewModel>> ReserveVacancyForQA(int vacancyReferenceNumber);

        Task<MediatorResponse<VacancyViewModel>> ReviewVacancy(int vacancyReferenceNumber);

        Task<MediatorResponse<FurtherVacancyDetailsViewModel>> GetVacancySummaryViewModel(int vacancyReferenceNumber);

        Task<MediatorResponse<FurtherVacancyDetailsViewModel>> UpdateVacancy(FurtherVacancyDetailsViewModel viewModel);

        Task<MediatorResponse<NewVacancyViewModel>> GetBasicDetails(int vacancyReferenceNumber);

        Task<MediatorResponse<TrainingDetailsViewModel>> GetTrainingDetails(int vacancyReferenceNumber);

        Task<MediatorResponse<TrainingDetailsViewModel>> UpdateVacancy(TrainingDetailsViewModel viewModel);

        Task<MediatorResponse<VacancyQuestionsViewModel>> GetVacancyQuestionsViewModel(int vacancyReferenceNumber);

        Task<MediatorResponse<VacancyRequirementsProspectsViewModel>> GetVacancyRequirementsProspectsViewModel(
            int vacancyReferenceNumber);

        Task<MediatorResponse<VacancyOwnerRelationshipViewModel>> GetEmployerInformation(int vacancyReferenceNumber,
            bool? useEmployerLocation);

        Task<MediatorResponse<NewVacancyViewModel>> UpdateVacancy(NewVacancyViewModel viewModel);

        Task<MediatorResponse<NewVacancyViewModel>> UpdateOfflineVacancyType(NewVacancyViewModel viewModel);

        Task<MediatorResponse<VacancyQuestionsViewModel>> UpdateVacancy(VacancyQuestionsViewModel viewModel);

        Task<MediatorResponse<VacancyRequirementsProspectsViewModel>> UpdateVacancy(
            VacancyRequirementsProspectsViewModel viewModel);

        Task<MediatorResponse<VacancyOwnerRelationshipViewModel>> UpdateEmployerInformation(
            VacancyOwnerRelationshipViewModel viewModel);

        Task<MediatorResponse<LocationSearchViewModel>> GetLocationAddressesViewModel(int vacancyReferenceNumber);

        Task<MediatorResponse<LocationSearchViewModel>> AddLocations(LocationSearchViewModel viewModel);

        Task<MediatorResponse<LocationSearchViewModel>> SearchLocations(LocationSearchViewModel viewModel,
            List<VacancyLocationAddressViewModel> alreadyAddedLocations);

        Task<MediatorResponse<LocationSearchViewModel>> UseLocation(LocationSearchViewModel viewModel, int locationIndex,
            string postCodeSearch);

        MediatorResponse<LocationSearchViewModel> RemoveLocation(LocationSearchViewModel viewModel, int locationIndex);

        Task<MediatorResponse<TrainingDetailsViewModel>> SelectFrameworkAsTrainingType(TrainingDetailsViewModel viewModel);

        Task<MediatorResponse<TrainingDetailsViewModel>> SelectStandardAsTrainingType(TrainingDetailsViewModel viewModel);

        Task<MediatorResponse<VacancyViewModel>> GetVacancyViewModel(int vacancyReferenceNumber);

        MediatorResponse UnReserveVacancyForQA(int vacancyReferenceNumber);
    }
}