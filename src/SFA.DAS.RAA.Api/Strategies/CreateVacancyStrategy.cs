namespace SFA.DAS.RAA.Api.Strategies
{
    using System.Linq;
    using Apprenticeships.Application.Provider.Strategies;
    using Apprenticeships.Domain.Entities.Raa.Vacancies;
    using Apprenticeships.Domain.Entities.Raa.Vacancies.Constants;
    using Apprenticeships.Domain.Raa.Interfaces.Repositories;
    using FluentValidation;
    using FluentValidation.Results;
    using Validators;

    public class CreateVacancyStrategy : ICreateVacancyStrategy
    {
        private readonly VacancyValidator _vacancyValidator = new VacancyValidator();

        private readonly IVacancyOwnerRelationshipReadRepository _vacancyOwnerRelationshipReadRepository;
        private readonly IGetOwnedProviderSitesStrategy _getOwnedProviderSitesStrategy;
        private readonly IProviderSiteReadRepository _providerSiteReadRepository;

        public CreateVacancyStrategy(IVacancyOwnerRelationshipReadRepository vacancyOwnerRelationshipReadRepository, IGetOwnedProviderSitesStrategy getOwnedProviderSitesStrategy, IProviderSiteReadRepository providerSiteReadRepository)
        {
            _vacancyOwnerRelationshipReadRepository = vacancyOwnerRelationshipReadRepository;
            _providerSiteReadRepository = providerSiteReadRepository;
            _getOwnedProviderSitesStrategy = getOwnedProviderSitesStrategy;
        }

        public Vacancy CreateVacancy(Vacancy vacancy, string ukprn)
        {
            vacancy.Status = VacancyStatus.Draft;

            var validationResult = _vacancyValidator.Validate(vacancy);
            var vacancyOwnerRelationship = _vacancyOwnerRelationshipReadRepository.GetByIds(new[] {vacancy.VacancyOwnerRelationshipId}).SingleOrDefault();
            if (vacancy.VacancyOwnerRelationshipId != 0)
            {
                if (vacancyOwnerRelationship == null)
                {
                    validationResult.Errors.Add(new ValidationFailure("VacancyOwnerRelationshipId", VacancyMessages.VacancyOwnerRelationshipId.RequiredErrorText));
                }
                else
                {
                    var ownedProviderSites = _getOwnedProviderSitesStrategy.GetOwnedProviderSites(provider.ProviderId);
                    if (ownedProviderSites.All(ps => ps.ProviderSiteId != providerSite.ProviderSiteId))
                    {
                        throw new SecurityException(EmployerProviderSiteLinkMessages.UnauthorizedProviderSiteAccess);
                    }
                }
            }
            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors);
            }

            return vacancy;
        }
    }
}