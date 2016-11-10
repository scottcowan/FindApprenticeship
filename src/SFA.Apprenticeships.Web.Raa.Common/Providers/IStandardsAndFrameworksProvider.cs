﻿namespace SFA.Apprenticeships.Web.Raa.Common.Providers
{
    using ViewModels.Admin;

    public interface IStandardsAndFrameworksProvider
    {
        StandardViewModel CreateStandard(StandardViewModel viewModel);
        StandardViewModel GetStandardViewModel(int standardId);
        StandardViewModel SaveStandard(StandardViewModel viewModel);
        SectorViewModel CreateSector(SectorViewModel viewModel);
        SectorViewModel GetSectorViewModel(int sectorId);
        SectorViewModel SaveSector(SectorViewModel viewModel);
    }
}