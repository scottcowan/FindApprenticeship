namespace SFA.DAS.RAA.Api.Strategies
{
    using System;
    using System.Linq;
    using System.Security;
    using Apprenticeships.Application.Employer.Strategies;
    using Apprenticeships.Application.Provider.Strategies;
    using Apprenticeships.Domain.Entities.Raa.Vacancies;
    using Apprenticeships.Domain.Entities.Raa.Vacancies.Constants;
    using Apprenticeships.Domain.Interfaces.Repositories;
    using Apprenticeships.Domain.Raa.Interfaces.Repositories;
    using FluentValidation;
    using FluentValidation.Results;
    using Validators;

    public class CreateVacancyStrategy : ICreateVacancyStrategy
    {
        private readonly VacancyValidator _vacancyValidator = new VacancyValidator();

        private readonly IVacancyReadRepository _vacancyReadRepository;
        private readonly IVacancyWriteRepository _vacancyWriteRepository;
        private readonly IProviderReadRepository _providerReadRepository;
        private readonly IVacancyOwnerRelationshipReadRepository _vacancyOwnerRelationshipReadRepository;
        private readonly IGetOwnedProviderSitesStrategy _getOwnedProviderSitesStrategy;
        private readonly IReferenceNumberRepository _referenceNumberRepository;
        private readonly IGetByIdStrategy _getEmployerByIdStrategy;
        private readonly IGetByEdsUrnStrategy _getEmployerByEdsUrnStrategy;

        public CreateVacancyStrategy(IVacancyReadRepository vacancyReadRepository, IVacancyWriteRepository vacancyWriteRepository, IProviderReadRepository providerReadRepository, IVacancyOwnerRelationshipReadRepository vacancyOwnerRelationshipReadRepository, IGetOwnedProviderSitesStrategy getOwnedProviderSitesStrategy, IReferenceNumberRepository referenceNumberRepository, IGetByIdStrategy getEmployerByIdStrategy, IGetByEdsUrnStrategy getEmployerByEdsUrnStrategy)
        {
            _vacancyReadRepository = vacancyReadRepository;
            _vacancyWriteRepository = vacancyWriteRepository;
            _providerReadRepository = providerReadRepository;
            _vacancyOwnerRelationshipReadRepository = vacancyOwnerRelationshipReadRepository;
            _getOwnedProviderSitesStrategy = getOwnedProviderSitesStrategy;
            _referenceNumberRepository = referenceNumberRepository;
            _getEmployerByIdStrategy = getEmployerByIdStrategy;
            _getEmployerByEdsUrnStrategy = getEmployerByEdsUrnStrategy;
        }

        public Vacancy CreateVacancy(Vacancy vacancy, string ukprn)
        {
            var provider = _providerReadRepository.GetByUkprn(ukprn, false);
            if (provider == null)
            {
                throw new SecurityException(Constants.VacancyMessages.UnauthorizedProviderAccess);
            }

            vacancy.ContractOwnerId = provider.ProviderId;
            vacancy.OriginalContractOwnerId = provider.ProviderId;

            var validationResult = _vacancyValidator.Validate(vacancy);

            if (vacancy.VacancyGuid != Guid.Empty)
            {
                if (_vacancyReadRepository.GetByVacancyGuid(vacancy.VacancyGuid) != null)
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

                    vacancy.VacancyManagerId = vacancyOwnerRelationship.ProviderSiteId;
                    vacancy.DeliveryOrganisationId = vacancyOwnerRelationship.ProviderSiteId;

                    if (vacancy.VacancyLocationType == VacancyLocationType.SpecificLocation || vacancy.VacancyLocationType == VacancyLocationType.Nationwide)
                    {
                        //Get the employer initially by id
                        var employer = _getEmployerByIdStrategy.Get(vacancyOwnerRelationship.EmployerId, true);
                        //Then by EDSURN as that will update the employer if anything has changed in EDRS. Obviously this requires knowledge of the implementation of this strategy which is wrong
                        //TODO: Make _getEmployerByIdStrategy.Get update the employer if necessary
                        employer = _getEmployerByEdsUrnStrategy.Get(employer.EdsUrn);
                        vacancy.Address = employer.Address;
                        vacancy.LocalAuthorityCode = employer.Address.LocalAuthorityCodeName;
                    }
                    else
                    {
                        vacancy.Address = null;
                        vacancy.LocalAuthorityCode = null;
                        vacancy.NumberOfPositions = null;
                    }

                    if (string.IsNullOrEmpty(vacancy.EmployerWebsiteUrl))
                    {
                        vacancy.EmployerWebsiteUrl = vacancyOwnerRelationship.EmployerWebsiteUrl;
                    }
                    if (string.IsNullOrEmpty(vacancy.EmployerDescription))
                    {
                        vacancy.EmployerDescription = vacancyOwnerRelationship.EmployerDescription;
                    }
                }
            }

            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors);
            }

            vacancy.VacancyReferenceNumber = _referenceNumberRepository.GetNextVacancyReferenceNumber();
            
            //Ignore any passed in status and set to draft
            vacancy.Status = VacancyStatus.Draft;
            vacancy.VacancySource = VacancySource.Api;

            var createdVacancy = _vacancyWriteRepository.Create(vacancy);

            return createdVacancy;
        }
    }
}