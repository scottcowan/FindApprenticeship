namespace SFA.Apprenticeships.Infrastructure.Presentation
{
    using Domain.Entities.Raa.Vacancies;

    public static class VacancySourcePresenter
    {
        public static bool IsRaa(this VacancySource vacancySource)
        {
            return vacancySource == VacancySource.Raa || vacancySource == VacancySource.Api;
        }

        public static bool IsLegacy(this VacancySource vacancySource)
        {
            return vacancySource != VacancySource.Raa && vacancySource != VacancySource.Api;
        }
    }
}