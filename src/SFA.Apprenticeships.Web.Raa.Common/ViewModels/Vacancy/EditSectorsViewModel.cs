namespace SFA.Apprenticeships.Web.Raa.Common.ViewModels.Vacancy
{
    using System.Collections.Generic;
    using Domain.Entities.Raa.Reference;
    using Domain.Entities.Raa.Vacancies;
    using Web.Common.Mediators;

    public class EditSectorsViewModel
    {
        public List<EditSectorViewModel> Sectors { get; set; }
        public List<Occupation> Occupations { get; set; }
    }
}