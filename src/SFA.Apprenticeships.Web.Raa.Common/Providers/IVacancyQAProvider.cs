﻿namespace SFA.Apprenticeships.Web.Raa.Common.Providers
{
    using System;
    using System.Collections.Generic;
    using System.Web.Mvc;
    using ViewModels.Vacancy;
    using ViewModels.VacancyPosting;

    public interface IVacancyQAProvider
    {
        DashboardVacancySummariesViewModel GetPendingQAVacanciesOverview(DashboardVacancySummariesSearchViewModel searchViewModel);

        List<DashboardVacancySummaryViewModel> GetPendingQAVacancies();

        QAActionResultCode ApproveVacancy(int vacancyReferenceNumber);

        QAActionResultCode RejectVacancy(int vacancyReferenceNumber);

        VacancyViewModel ReserveVacancyForQA(int vacancyReferenceNumber);

        VacancyViewModel ReviewVacancy(int vacancyReferenceNumber);

        NewVacancyViewModel GetNewVacancyViewModel(int vacancyReferenceNumber);

        TrainingDetailsViewModel GetTrainingDetailsViewModel(int vacancyReferenceNumber);

        FurtherVacancyDetailsViewModel GetVacancySummaryViewModel(int vacancyReferenceNumber);

        VacancyRequirementsProspectsViewModel GetVacancyRequirementsProspectsViewModel(int vacancyReferenceNumber);

        VacancyQuestionsViewModel GetVacancyQuestionsViewModel(int vacancyReferenceNumber);

        QAActionResult<FurtherVacancyDetailsViewModel> UpdateVacancyWithComments(FurtherVacancyDetailsViewModel viewModel);

        QAActionResult<NewVacancyViewModel> UpdateVacancyWithComments(NewVacancyViewModel viewModel);

        QAActionResult<TrainingDetailsViewModel> UpdateVacancyWithComments(TrainingDetailsViewModel viewModel);

        QAActionResult<VacancyRequirementsProspectsViewModel> UpdateVacancyWithComments(VacancyRequirementsProspectsViewModel viewModel);

        QAActionResult<VacancyQuestionsViewModel> UpdateVacancyWithComments(VacancyQuestionsViewModel viewModel);

        List<SelectListItem> GetSectorsAndFrameworks();

        List<StandardViewModel> GetStandards();

        List<SelectListItem> GetSectors();

        void RemoveLocationAddresses(Guid vacancyGuid);

        NewVacancyViewModel UpdateEmployerInformationWithComments(NewVacancyViewModel existingVacancy);

        LocationSearchViewModel LocationAddressesViewModel(string ukprn, int providerSiteId, int employerId, Guid vacancyGuid, bool isAnonymousEmployer = false);

        LocationSearchViewModel AddLocations(LocationSearchViewModel viewModel);

        VacancyViewModel GetVacancyById(int vacancyId);

        VacancyViewModel GetVacancy(Guid vacancyGuid);

        VacancyViewModel GetVacancy(int vacancyReferenceNumber);

        List<VacancyLocationAddressViewModel> GetLocationsAddressViewModelsByReferenceNumber(int vacancyReferenceNumber);

        List<VacancyLocationAddressViewModel> GetLocationsAddressViewModels(int vacancyId);

        DashboardVacancySummaryViewModel GetNextAvailableVacancy();

        void UnReserveVacancyForQA(int vacancyReferenceNumber);
    }
}
