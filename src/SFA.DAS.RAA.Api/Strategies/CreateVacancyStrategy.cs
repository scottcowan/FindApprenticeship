namespace SFA.DAS.RAA.Api.Strategies
{
    using System;
    using System.Linq;
    using System.Security;
    using Apprenticeships.Application.Employer.Strategies;
    using Apprenticeships.Application.Location.Strategies;
    using Apprenticeships.Application.Provider.Strategies;
    using Apprenticeships.Domain.Entities.Exceptions;
    using Apprenticeships.Domain.Entities.Raa.Locations.Constants;
    using Apprenticeships.Domain.Entities.Raa.Parties;
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
        private readonly IPostalAddressStrategy _postalAddressStrategy;

        public CreateVacancyStrategy(IVacancyReadRepository vacancyReadRepository, IVacancyWriteRepository vacancyWriteRepository, IProviderReadRepository providerReadRepository, IVacancyOwnerRelationshipReadRepository vacancyOwnerRelationshipReadRepository, IGetOwnedProviderSitesStrategy getOwnedProviderSitesStrategy, IReferenceNumberRepository referenceNumberRepository, IGetByIdStrategy getEmployerByIdStrategy, IGetByEdsUrnStrategy getEmployerByEdsUrnStrategy, IPostalAddressStrategy postalAddressStrategy)
        {
            _vacancyReadRepository = vacancyReadRepository;
            _vacancyWriteRepository = vacancyWriteRepository;
            _providerReadRepository = providerReadRepository;
            _vacancyOwnerRelationshipReadRepository = vacancyOwnerRelationshipReadRepository;
            _getOwnedProviderSitesStrategy = getOwnedProviderSitesStrategy;
            _referenceNumberRepository = referenceNumberRepository;
            _getEmployerByIdStrategy = getEmployerByIdStrategy;
            _getEmployerByEdsUrnStrategy = getEmployerByEdsUrnStrategy;
            _postalAddressStrategy = postalAddressStrategy;
        }

        public Vacancy CreateVacancy(Vacancy vacancy, string ukprn)
        {
            var provider = _providerReadRepository.GetByUkprn(ukprn, false);
            return CreateVacancy(vacancy, provider, false);
        }

        public Vacancy CreateVacancy(Vacancy vacancy)
        {
            var provider = _providerReadRepository.GetById(vacancy.ContractOwnerId);
            return CreateVacancy(vacancy, provider, true);
        }

        private Vacancy CreateVacancy(Vacancy vacancy, Provider provider, bool acceptLiveStatus)
        {
            if (provider == null)
            {
                throw new SecurityException(Constants.VacancyMessages.UnauthorizedProviderAccess);
            }

            if (vacancy.Status == VacancyStatus.Live && acceptLiveStatus)
            {
                //Check for agency vacancy create. When a multi location vacancy is created its child vacancies are immediately made live
            }
            else
            {
                //Ignore any passed in status and set to draft
                vacancy.Status = VacancyStatus.Draft;
            }

            if (vacancy.VacancySource != VacancySource.Raa)
            {
                vacancy.VacancySource = VacancySource.Api;
            }

            //Null any legacy or invalid fields
            vacancy.ExpectedDuration = null;
            vacancy.NoOfOfflineApplicants = 0;
            vacancy.DateSubmitted = null;
            vacancy.DateFirstSubmitted = null;
            vacancy.DateStartedToQA = null;
            vacancy.QAUserName = null;
            vacancy.DateQAApproved = null;
            vacancy.SubmissionCount = 0;
            vacancy.ParentVacancyId = null;
            vacancy.UpdatedDateTime = null;
            vacancy.OtherInformation = null;

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

                    //Get the employer initially by id
                    var employer = _getEmployerByIdStrategy.Get(vacancyOwnerRelationship.EmployerId, true);
                    //Then by EDSURN as that will update the employer if anything has changed in EDRS. Obviously this requires knowledge of the implementation of this strategy which is wrong
                    //TODO: Make _getEmployerByIdStrategy.Get update the employer if necessary
                    employer = _getEmployerByEdsUrnStrategy.Get(employer.EdsUrn);

                    if(vacancy.VacancyLocationType == VacancyLocationType.MultipleLocations)
                    {
                        if (vacancy.VacancyLocations != null && vacancy.VacancyLocations.Count > 0)
                        {
                            //Verify and geocode all addresses
                            for (int i = 0; i < vacancy.VacancyLocations.Count; i++)
                            {
                                var vacancyLocation = vacancy.VacancyLocations[i];
                                if (vacancyLocation.Address != null)
                                {
                                    try
                                    {
                                        vacancyLocation.Address = _postalAddressStrategy.GetPostalAddress(vacancyLocation.Address);
                                    }
                                    catch (CustomException ex)
                                    {
                                        if (ex.Code == Apprenticeships.Infrastructure.Postcode.ErrorCodes.PostalAddressGeocodeFailed)
                                        {
                                            validationResult.Errors.Add(new ValidationFailure($"VacancyLocations[{i}].Address.Postcode", PostalAddressMessages.Postcode.NotFound));
                                        }
                                        else
                                        {
                                            throw;
                                        }
                                    }
                                }
                            }

                            if (vacancy.VacancyLocations.Count == 1)
                            {
                                vacancy.Address = vacancy.VacancyLocations[0].Address;
                                vacancy.NumberOfPositions = vacancy.VacancyLocations[0].NumberOfPositions;
                                vacancy.VacancyLocations = null;
                            }
                            else
                            {
                                vacancy.Address = employer.Address;
                            }
                        }
                        else
                        {
                            vacancy.Address = null;
                        }
                    }
                    else
                    {
                        vacancy.Address = employer.Address;
                        vacancy.VacancyLocations = null;
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
            
            var createdVacancy = _vacancyWriteRepository.Create(vacancy);

            return createdVacancy;
        }
    }
}