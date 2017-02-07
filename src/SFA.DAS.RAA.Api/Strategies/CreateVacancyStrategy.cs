namespace SFA.DAS.RAA.Api.Strategies
{
    using System;
    using System.Linq;
    using System.Security;
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

        private readonly IVacancyReadRepository _vacancyreadRepository;
        private readonly IVacancyWriteRepository _vacancyWriteRepository;
        private readonly IProviderReadRepository _providerReadRepository;
        private readonly IVacancyOwnerRelationshipReadRepository _vacancyOwnerRelationshipReadRepository;
        private readonly IGetOwnedProviderSitesStrategy _getOwnedProviderSitesStrategy;

        public CreateVacancyStrategy(IVacancyReadRepository vacancyreadRepository, IVacancyWriteRepository vacancyWriteRepository, IProviderReadRepository providerReadRepository, IVacancyOwnerRelationshipReadRepository vacancyOwnerRelationshipReadRepository, IGetOwnedProviderSitesStrategy getOwnedProviderSitesStrategy)
        {
            _vacancyreadRepository = vacancyreadRepository;
            _vacancyWriteRepository = vacancyWriteRepository;
            _providerReadRepository = providerReadRepository;
            _vacancyOwnerRelationshipReadRepository = vacancyOwnerRelationshipReadRepository;
            _getOwnedProviderSitesStrategy = getOwnedProviderSitesStrategy;
        }

        public Vacancy CreateVacancy(Vacancy vacancy, string ukprn)
        {
            var provider = _providerReadRepository.GetByUkprn(ukprn, false);
            if (provider == null)
            {
                throw new SecurityException(Constants.VacancyMessages.UnauthorizedProviderAccess);
            }

            var validationResult = _vacancyValidator.Validate(vacancy);

            if (vacancy.VacancyGuid != Guid.Empty)
            {
                if (_vacancyreadRepository.GetByVacancyGuid(vacancy.VacancyGuid) != null)
                {
                    validationResult.Errors.Add(new ValidationFailure("VacancyGuid", VacancyMessages.VacancyGuid.DuplicateGuid));
                }
            }

            var vacancyOwnerRelationship = _vacancyOwnerRelationshipReadRepository.GetByIds(new[] {vacancy.VacancyOwnerRelationshipId}).SingleOrDefault();
            if (vacancy.VacancyOwnerRelationshipId != 0)
            {
                if (vacancyOwnerRelationship == null)
                {
                    validationResult.Errors.Add(new ValidationFailure("VacancyOwnerRelationshipId", VacancyMessages.VacancyOwnerRelationshipId.RequiredErrorText));
                }
                else
                {
                    var ownedProviderSites = _getOwnedProviderSitesStrategy.GetOwnedProviderSites(provider.ProviderId).ToList();
                    if (ownedProviderSites.All(ps => ps.ProviderSiteId != vacancyOwnerRelationship.ProviderSiteId))
                    {
                        validationResult.Errors.Add(new ValidationFailure("VacancyOwnerRelationshipId", VacancyMessages.VacancyOwnerRelationshipId.Unauthorized));
                    }
                }
            }

            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors);
            }

            vacancy.Status = VacancyStatus.Draft;

            return vacancy;
        }
    }
}