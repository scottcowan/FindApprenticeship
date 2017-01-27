namespace SFA.Apprenticeships.Web.Raa.Common.ViewModels.Vacancy
{
    using System.Collections.Generic;

    public class EditStandardsViewModel
    {
        public IEnumerable<EditStandardViewModel> Standards { get; set; }
        public IEnumerable<OccupationViewModel> Occupations { get; set; }
        public IEnumerable<SectorViewModel> Sectors { get; set; }
    }
}