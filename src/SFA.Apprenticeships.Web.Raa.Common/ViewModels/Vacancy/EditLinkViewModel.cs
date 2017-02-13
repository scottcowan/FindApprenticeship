namespace SFA.Apprenticeships.Web.Raa.Common.ViewModels.Vacancy
{
    using Domain.Entities.Raa.Vacancies;

    public class EditLinkViewModel
    {
        public const string PartialView = "_EditLink";

        public EditLinkViewModel(VacancyStatus status, string anchorName, string editUrl, string comment, bool isUnderParagraph)
        {
            Status = status;
            AnchorName = anchorName;
            EditUrl = editUrl;
            CommentViewModel = new CommentViewModel(status, anchorName, comment, editUrl, string.Empty);
            IsUnderParagraph = isUnderParagraph;
        }

        public VacancyStatus Status { get; private set; }

        public string AnchorName { get; set; }

        public string EditUrl { get; private set; }

        public CommentViewModel CommentViewModel { get; private set; }

        public bool IsUnderParagraph { get; private set; }
    }
}