namespace SFA.DAS.RAA.Api.Strategies
{
    using Apprenticeships.Domain.Entities.Raa.Vacancies;

    public interface ICreateVacancyStrategy
    {
        Vacancy CreateVacancy(Vacancy vacancy, string ukprn);

        /// <summary>
        /// For manage access. Provider will not be verified except to check it exists
        /// </summary>
        /// <param name="vacancy"></param>
        /// <returns></returns>
        Vacancy CreateVacancy(Vacancy vacancy);
    }
}