using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFA.Apprenticeships.Application.Interfaces.Vacancy;
using SFA.Apprenticeships.Application.Vacancy;
using SFA.Apprenticeships.Domain.Entities.Raa.Vacancies;
using SFA.Apprenticeships.Domain.Raa.Interfaces.Queries;
using SFA.Apprenticeships.Domain.Raa.Interfaces.Repositories;
using SFA.Apprenticeships.Domain.Raa.Interfaces.Repositories.Models;

namespace SFA.DAS.RAA.Api.Service.V1.Vacancy
{
    class ApiVacancySummaryService : IVacancySummaryService
    {
        private readonly IVacancySummaryService _vacancySummaryService;

        public ApiVacancySummaryService(IVacancySummaryRepository vacancySummaryRepository)
        {
            _vacancySummaryService = new VacancySummaryService(vacancySummaryRepository);
        }

        public IList<VacancySummary> GetSummariesForProvider(VacancySummaryQuery query, out int totalRecords)
        {
            return _vacancySummaryService.GetSummariesForProvider(query, out totalRecords);
        }

        public VacancyCounts GetLotteryCounts(VacancySummaryQuery query)
        {
            return _vacancySummaryService.GetLotteryCounts(query);
        }

        public IList<VacancySummary> GetWithStatus(VacancySummaryByStatusQuery query, out int totalRecords)
        {
            return _vacancySummaryService.GetWithStatus(query, out totalRecords);
        }

        public IList<RegionalTeamMetrics> GetRegionalTeamMetrics(VacancySummaryByStatusQuery query)
        {
            return _vacancySummaryService.GetRegionalTeamMetrics(query);
        }

        public VacancySummary GetById(int vacancyId)
        {
            return _vacancySummaryService.GetById(vacancyId);
        }

        public VacancySummary GetByReferenceNumber(int vacancyReferenceNumber)
        {
            return _vacancySummaryService.GetByReferenceNumber(vacancyReferenceNumber);
        }

        public IList<VacancySummary> GetByIds(IEnumerable<int> vacancyIds)
        {
            return _vacancySummaryService.GetByIds(vacancyIds);
        }

        public IList<VacancySummary> Find(ApprenticeshipVacancyQuery query, out int resultCount)
        {
            return _vacancySummaryService.Find(query, out resultCount);
        }
    }
}
