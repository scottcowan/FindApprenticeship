﻿using System.Threading.Tasks;
using SFA.Apprenticeships.Application.Interfaces.Service;

namespace SFA.Apprenticeships.Application.Vacancy
{
    using System.Collections.Generic;
    using Domain.Entities.Raa.Vacancies;
    using Domain.Raa.Interfaces.Queries;
    using Domain.Raa.Interfaces.Repositories;
    using Domain.Raa.Interfaces.Repositories.Models;
    using Interfaces.Vacancy;

    public class VacancySummaryService : IVacancySummaryService
    {
        private readonly IVacancySummaryRepository _vacancySummaryRepository;

        public VacancySummaryService(IVacancySummaryRepository vacancySummaryRepository)
        {
            _vacancySummaryRepository = vacancySummaryRepository;
        }

        public async Task<IServiceResult<ListWithTotalCount<VacancySummary>>> GetSummariesForProvider(VacancySummaryQuery query)
        {
            return new ServiceResult<ListWithTotalCount<VacancySummary>>(
                VacancySummaryServiceCodes.GetByProvider.Ok, await _vacancySummaryRepository.GetSummariesForProvider(query));
        }

        public VacancyCounts GetLotteryCounts(VacancySummaryQuery query)
        {
            return _vacancySummaryRepository.GetLotteryCounts(query);
        }

        public IList<VacancySummary> GetWithStatus(VacancySummaryByStatusQuery query, out int totalRecords)
        {
            return _vacancySummaryRepository.GetByStatus(query, out totalRecords);
        }

        public IList<RegionalTeamMetrics> GetRegionalTeamMetrics(VacancySummaryByStatusQuery query)
        {
            return _vacancySummaryRepository.GetRegionalTeamMetrics(query);
        }

        public VacancySummary GetById(int vacancyId)
        {
            return _vacancySummaryRepository.GetById(vacancyId);
        }

        public VacancySummary GetByReferenceNumber(int vacancyReferenceNumber)
        {
            return _vacancySummaryRepository.GetByReferenceNumber(vacancyReferenceNumber);
        }

        public IList<VacancySummary> GetByIds(IEnumerable<int> vacancyIds)
        {
            return _vacancySummaryRepository.GetByIds(vacancyIds);
        }

        public IList<VacancySummary> Find(ApprenticeshipVacancyQuery query, out int resultCount)
        {
            return _vacancySummaryRepository.Find(query, out resultCount);
        }
    }
}