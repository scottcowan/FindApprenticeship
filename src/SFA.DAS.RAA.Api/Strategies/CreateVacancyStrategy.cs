namespace SFA.DAS.RAA.Api.Strategies
{
    using Apprenticeships.Domain.Entities.Raa.Vacancies;
    using FluentValidation;
    using Validators;

    public class CreateVacancyStrategy : ICreateVacancyStrategy
    {
        private readonly VacancyValidator _vacancyValidator = new VacancyValidator();

        public Vacancy CreateVacancy(Vacancy vacancy)
        {
            vacancy.Status = VacancyStatus.Draft;

            var validationResult = _vacancyValidator.Validate(vacancy);
            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors);
            }

            return vacancy;
        }
    }
}