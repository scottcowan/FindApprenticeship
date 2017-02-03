namespace SFA.DAS.RAA.Api.Strategies
{
    using Apprenticeships.Domain.Entities.Raa.Vacancies;

    public interface ICreateVacancyStrategy
    {
        Vacancy CreateVacancy(Vacancy vacancy);
    }
}