namespace SFA.Apprenticeships.Application.Interfaces.VacancyPosting
{
    using Domain.Entities.Raa.Vacancies;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Domain.Raa.Interfaces.Repositories.Models;

    public interface IVacancyPostingService
    {
        Task<Vacancy> CreateVacancy(Vacancy vacancy);

        int GetNextVacancyReferenceNumber();

        Task<Vacancy> GetVacancy(int vacancyId);

        Task<Vacancy> GetVacancyByReferenceNumber(int vacancyReferenceNumber);

        Task<Vacancy> GetVacancy(Guid vacancyGuid);
        
        IList<VacancySummary> GetWithStatus(VacancySummaryByStatusQuery query, out int totalRecords);

        IReadOnlyList<VacancySummary> GetVacancySummariesByIds(IEnumerable<int> vacancyIds);

        Vacancy ReserveVacancyForQA(int vacancyReferenceNumber);

        void UnReserveVacancyForQa(int vacancyReferenceNumber);

        List<VacancyLocation> GetVacancyLocations(int vacancyId);

        List<VacancyLocation> GetVacancyLocationsByReferenceNumber(int vacancyReferenceNumber);

        List<VacancyLocation> CreateVacancyLocations(List<VacancyLocation> vacancyLocations);

        List<VacancyLocation> UpdateVacancyLocations(List<VacancyLocation> vacancyLocations);

        void DeleteVacancyLocationsFor(int vacancyId);

        Vacancy UpdateVacancy(Vacancy vacancy);

        Vacancy ArchiveVacancy(Vacancy vacancy);
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="vacancyOwnerRelationshipIds"></param>
        /// <returns>VacancyPartId => VacancyLocation</returns>
        IReadOnlyDictionary<int, IEnumerable<VacancyLocation>> GetVacancyLocationsByVacancyIds(IEnumerable<int> vacancyOwnerRelationshipIds);

        Vacancy UpdateVacanciesWithNewProvider(Vacancy vacancies);
		
        IList<RegionalTeamMetrics> GetRegionalTeamsMetrics(VacancySummaryByStatusQuery query);
    }
}
