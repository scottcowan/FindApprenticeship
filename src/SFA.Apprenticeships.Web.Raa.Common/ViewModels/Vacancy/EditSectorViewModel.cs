namespace SFA.Apprenticeships.Web.Raa.Common.ViewModels.Vacancy
{
    using Domain.Entities.Raa.Reference;
    using Domain.Entities.Raa.Vacancies;

    public class EditSectorViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Occupation Occupation { get; set; }
    }
}