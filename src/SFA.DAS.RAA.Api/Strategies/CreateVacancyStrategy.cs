namespace SFA.DAS.RAA.Api.Strategies
{
    using Apprenticeships.Domain.Entities.Raa.Vacancies;

    public class CreateVacancyStrategy : ICreateVacancyStrategy
    {
        public Vacancy CreateVacancy(Vacancy vacancy)
        {
            vacancy.Status = VacancyStatus.Draft;
            return vacancy;
        }
    }
}