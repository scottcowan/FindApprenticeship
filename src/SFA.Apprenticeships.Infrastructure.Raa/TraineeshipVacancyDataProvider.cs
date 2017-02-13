namespace SFA.Apprenticeships.Infrastructure.Raa
{
    using System.Threading.Tasks;
    using Application.Interfaces.Employers;
    using Application.Interfaces.Providers;
    using Application.ReferenceData;
    using Application.Vacancy;
    using DAS.RAA.Api.Service.V1.Mappers;
    using Domain.Entities.Exceptions;
    using Domain.Entities.Vacancies.Traineeships;
    using Domain.Raa.Interfaces.Repositories;
    using Mappers;
    using Application.Interfaces;
    using Application.Interfaces.Api;
    using DAS.RAA.Api.Client.V1.Models;
    using ErrorCodes = Application.Interfaces.Vacancies.ErrorCodes;
    using Vacancy = Domain.Entities.Raa.Vacancies.Vacancy;

    public class TraineeshipVacancyDataProvider : IVacancyDataProvider<TraineeshipVacancyDetail>
    {
        private static readonly IMapper ApiClientMappers = new ApiClientMappers();

        private readonly IVacancyReadRepository _vacancyReadRepository;
        private readonly IProviderService _providerService;
        private readonly IEmployerService _employerService;
        private readonly IReferenceDataProvider _referenceDataProvider;
        private readonly ILogService _logService;
        private readonly IApiClientProvider _apiClientProvider;

        public TraineeshipVacancyDataProvider(IVacancyReadRepository vacancyReadRepository, IProviderService providerService, IEmployerService employerService, IReferenceDataProvider referenceDataProvider, ILogService logService, IApiClientProvider apiClientProvider)
        {
            _vacancyReadRepository = vacancyReadRepository;
            _providerService = providerService;
            _employerService = employerService;
            _referenceDataProvider = referenceDataProvider;
            _logService = logService;
            _apiClientProvider = apiClientProvider;
        }

        public async Task<TraineeshipVacancyDetail> GetVacancyDetails(int vacancyId, bool errorIfNotFound = false)
        {
            Vacancy vacancy;
            if (_apiClientProvider.IsEnabled())
            {
                var apiClient = _apiClientProvider.GetApiClient();
                var apiResponse = await apiClient.PublicVacancyOperations.GetByIdWithHttpMessagesAsync(vacancyId);
                //TODO: check for nulls and exceptions
                var publicVacancy = apiResponse.Body;
                vacancy = ApiClientMappers.Map<PublicVacancy, Vacancy>(publicVacancy);
            }
            else
            {
                vacancy = _vacancyReadRepository.Get(vacancyId);
            }

            if (vacancy == null)
            {
                if (errorIfNotFound)
                {
                    throw new DomainException(ErrorCodes.VacancyNotFoundError, new { vacancyId });
                }
                return null;
            }

            var vacancyOwnerRelationship = _providerService.GetVacancyOwnerRelationship(vacancy.VacancyOwnerRelationshipId, false); // Some current vacancies have non-current vacancy parties
            var employer = _employerService.GetEmployer(vacancyOwnerRelationship.EmployerId, false);

            var providerSite = _providerService.GetProviderSite(vacancyOwnerRelationship.ProviderSiteId);
            if (providerSite == null)
                throw new System.Exception($"Could not find VacancyOwnerRelationship for ProviderSiteId={vacancyOwnerRelationship.ProviderSiteId}");

            var provider = _providerService.GetProvider(vacancy.ContractOwnerId);
            var categories = _referenceDataProvider.GetCategories();
            return TraineeshipVacancyDetailMapper.GetTraineeshipVacancyDetail(vacancy, employer, provider, providerSite, categories, _logService);
        }

        public int GetVacancyId(int vacancyReferenceNumber)
        {
            return _vacancyReadRepository.GetVacancyIdByReferenceNumber(vacancyReferenceNumber);
        }
    }
}