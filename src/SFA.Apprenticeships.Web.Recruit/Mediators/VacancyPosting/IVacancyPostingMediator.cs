namespace SFA.Apprenticeships.Web.Recruit.Mediators.VacancyPosting
{
    using Common.Mediators;
    using Raa.Common.ViewModels.Employer;
    using Raa.Common.ViewModels.Provider;
    using Raa.Common.ViewModels.Vacancy;
    using Raa.Common.ViewModels.VacancyPosting;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IVacancyPostingMediator
    {
        MediatorResponse<EmployerSearchViewModel> GetProviderEmployers(int providerSiteId, Guid? vacancyGuid, bool? comeFromPreview);

        MediatorResponse<EmployerSearchViewModel> GetProviderEmployers(EmployerSearchViewModel employerFilterViewModel);

        MediatorResponse<EmployerSearchViewModel> GetEmployers(EmployerSearchViewModel employerFilterViewModel);

        Task<MediatorResponse<VacancyOwnerRelationshipViewModel>> GetEmployer(int providerSiteId, string edsUrn, Guid vacancyGuid, bool? comeFromPreview, bool? useEmployerLocation);

        Task<MediatorResponse<VacancyOwnerRelationshipViewModel>> ConfirmEmployer(VacancyOwnerRelationshipViewModel viewModel, string ukprn);

        Task<MediatorResponse<NewVacancyViewModel>> GetNewVacancyViewModel(int vacancyOwnerRelationshipId, Guid vacancyGuid, int? numberOfPositions);

        Task<MediatorResponse<NewVacancyViewModel>> GetNewVacancyViewModel(int vacancyReferenceNumber, bool validate, bool? comeFromPreview);

        Task<MediatorResponse<NewVacancyViewModel>> CreateVacancyAndExit(NewVacancyViewModel newVacancyViewModel, string ukprn);

        Task<MediatorResponse<NewVacancyViewModel>> CreateVacancy(NewVacancyViewModel newVacancyViewModel, string ukprn);

        Task<MediatorResponse<TrainingDetailsViewModel>> GetTrainingDetailsViewModel(int vacancyReferenceNumber, bool validate, bool? comeFromPreview);

        Task<MediatorResponse<TrainingDetailsViewModel>> UpdateVacancy(TrainingDetailsViewModel viewModel);

        Task<MediatorResponse<TrainingDetailsViewModel>> UpdateVacancyAndExit(TrainingDetailsViewModel viewModel);

        Task<MediatorResponse<FurtherVacancyDetailsViewModel>> GetVacancySummaryViewModel(int vacancyReferenceNumber, bool validate, bool? comeFromPreview);

        Task<MediatorResponse<FurtherVacancyDetailsViewModel>> UpdateVacancy(FurtherVacancyDetailsViewModel viewModel, bool acceptWarnings);

        Task<MediatorResponse<FurtherVacancyDetailsViewModel>> UpdateVacancyAndExit(FurtherVacancyDetailsViewModel viewModel);

        Task<MediatorResponse<VacancyRequirementsProspectsViewModel>> GetVacancyRequirementsProspectsViewModel(int vacancyReferenceNumber, bool validate, bool? comeFromPreview);

        Task<MediatorResponse<VacancyRequirementsProspectsViewModel>> UpdateVacancy(VacancyRequirementsProspectsViewModel viewModel);

        Task<MediatorResponse<VacancyRequirementsProspectsViewModel>> UpdateVacancyAndExit(VacancyRequirementsProspectsViewModel viewModel);

        Task<MediatorResponse<VacancyQuestionsViewModel>> GetVacancyQuestionsViewModel(int vacancyReferenceNumber, bool validate, bool? comeFromPreview);

        Task<MediatorResponse<VacancyQuestionsViewModel>> UpdateVacancy(VacancyQuestionsViewModel viewModel);

        Task<MediatorResponse<VacancyQuestionsViewModel>> UpdateVacancyAndExit(VacancyQuestionsViewModel viewModel);

        Task<MediatorResponse<VacancyViewModel>> SubmitVacancy(int vacancyReferenceNumber, bool resubmitOptin);

        Task<MediatorResponse<SubmittedVacancyViewModel>> GetSubmittedVacancyViewModel(int vacancyReferenceNumber, bool resubmitted);

        MediatorResponse<EmployerSearchViewModel> SelectNewEmployer(EmployerSearchViewModel viewModel);

        Task<MediatorResponse<VacancyViewModel>> GetPreviewVacancyViewModel(int vacancyReferenceNumber);

        Task<MediatorResponse<VacancyOwnerRelationshipViewModel>> CloneVacancy(int vacancyReferenceNumber);

        Task<MediatorResponse<LocationSearchViewModel>> AddLocations(LocationSearchViewModel newVacancyViewModel, string ukprn);

        Task<MediatorResponse<LocationSearchViewModel>> GetLocationAddressesViewModel(int providerSiteId, int employerId, string ukprn, Guid vacancyGuid, bool? comeFromPreview, bool? isAnonymousEmployer);

        Task<MediatorResponse<LocationSearchViewModel>> SearchLocations(LocationSearchViewModel viewModel, List<VacancyLocationAddressViewModel> alreadyAddedLocations);

        Task<MediatorResponse<LocationSearchViewModel>> UseLocation(LocationSearchViewModel viewModel, int locationIndex,
            string postCodeSearch);

        MediatorResponse<LocationSearchViewModel> RemoveLocation(LocationSearchViewModel viewModel, int locationIndex);

        MediatorResponse<TrainingDetailsViewModel> SelectFrameworkAsTrainingType(TrainingDetailsViewModel viewModel);

        MediatorResponse ClearLocationInformation(Guid vacancyGuid);

        MediatorResponse<TrainingDetailsViewModel> SelectStandardAsTrainingType(TrainingDetailsViewModel viewModel);

        Task<MediatorResponse<FurtherVacancyDetailsViewModel>> UpdateVacancyDates(FurtherVacancyDetailsViewModel viewModel, bool acceptWarnings);
        Task<FurtherVacancyDetailsViewModel> GetCloseVacancyViewModel(int vacancyReferenceNumber);
        Task<MediatorResponse<FurtherVacancyDetailsViewModel>> CloseVacancy(FurtherVacancyDetailsViewModel viewModel);
    }
}