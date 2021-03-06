﻿namespace SFA.Apprenticeships.Web.Recruit.Mediators.VacancyStatus
{
    using Common.Mediators;
    using Raa.Common.ViewModels.VacancyStatus;

    public interface IVacancyStatusMediator
    {
        MediatorResponse<ArchiveVacancyViewModel> GetArchiveVacancyViewModelByVacancyReferenceNumber(int vacancyReferenceNumber);

        MediatorResponse<ArchiveVacancyViewModel> ArchiveVacancy(ArchiveVacancyViewModel viewModel);
    }
}
