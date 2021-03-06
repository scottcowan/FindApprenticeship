namespace SFA.Apprenticeships.Application.VacancyPosting.Strategies
{
    using System.Collections.Generic;
    using Domain.Entities.Raa.Locations;
    using Domain.Raa.Interfaces.Repositories;

    public class VacancyLocationsStrategies : IVacancyLocationsStrategies
    {
        private readonly IVacancyLocationReadRepository _vacancyLocationReadRepository;
        private readonly IVacancyLocationWriteRepository _vacancyLocationWriteRepository;

        public VacancyLocationsStrategies(IVacancyLocationReadRepository vacancyLocationReadRepository, IVacancyLocationWriteRepository vacancyLocationWriteRepository)
        {
            _vacancyLocationReadRepository = vacancyLocationReadRepository;
            _vacancyLocationWriteRepository = vacancyLocationWriteRepository;
        }

        public List<VacancyLocation> GetVacancyLocations(int vacancyId)
        {
            return _vacancyLocationReadRepository.GetForVacancyId(vacancyId);
        }

        public List<VacancyLocation> GetVacancyLocationsByReferenceNumber(int vacancyReferenceNumber)
        {
            return _vacancyLocationReadRepository.GetForVacancyReferenceNumber(vacancyReferenceNumber);
        }

        public List<VacancyLocation> CreateVacancyLocations(List<VacancyLocation> vacancyLocations)
        {
            return _vacancyLocationWriteRepository.Create(vacancyLocations);
        }

        public List<VacancyLocation> UpdateVacancyLocations(List<VacancyLocation> vacancyLocations)
        {
            return _vacancyLocationWriteRepository.Update(vacancyLocations);
        }

        public void DeleteVacancyLocationsFor(int vacancyId)
        {
            _vacancyLocationWriteRepository.DeleteFor(vacancyId);
        }

        public IReadOnlyDictionary<int, IEnumerable<VacancyLocation>> GetVacancyLocationsByVacancyIds(IEnumerable<int> vacancyOwnerRelationshipIds)
        {
            return _vacancyLocationReadRepository.GetVacancyLocationsByVacancyIds(vacancyOwnerRelationshipIds);
        }
    }
}