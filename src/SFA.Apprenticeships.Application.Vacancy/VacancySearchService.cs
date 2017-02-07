﻿namespace SFA.Apprenticeships.Application.Vacancy
{
    using System;
    using System.Threading.Tasks;
    using CuttingEdge.Conditions;
    using Domain.Entities.Exceptions;
    using Domain.Entities.Vacancies;
    using Interfaces;
    using Interfaces.Search;
    using Interfaces.Vacancies;
    using ErrorCodes = Interfaces.Vacancies.ErrorCodes;

    public class VacancySearchService<TVacancySummaryResponse, TVacancyDetail, TSearchParameters> : IVacancySearchService<TVacancySummaryResponse, TVacancyDetail, TSearchParameters>
        where TVacancySummaryResponse : VacancySummary
        where TVacancyDetail : VacancyDetail
        where TSearchParameters : VacancySearchParametersBase
    {
        private readonly ILogService _logger;

        private const string CallingMessageFormat = "Calling VacancySearchService with the following parameters; {0}";
        private const string FailedMessageFormat = "Vacancy search failed for the following parameters; {0}";

        private readonly IVacancySearchProvider<TVacancySummaryResponse, TSearchParameters> _vacancySearchProvider;
        private readonly IVacancyDataProvider<TVacancyDetail> _vacancyDataProvider;

        public VacancySearchService(IVacancySearchProvider<TVacancySummaryResponse, TSearchParameters> vacancySearchProvider, IVacancyDataProvider<TVacancyDetail> vacancyDataProvider, ILogService logger)
        {
            _vacancySearchProvider = vacancySearchProvider;
            _vacancyDataProvider = vacancyDataProvider;
            _logger = logger;
        }

        public SearchResults<TVacancySummaryResponse, TSearchParameters> Search(TSearchParameters parameters)
        {
            Condition.Requires(parameters).IsNotNull();
            Condition.Requires(parameters.SearchRadius).IsGreaterOrEqual(0);
            Condition.Requires(parameters.PageNumber).IsGreaterOrEqual(1);
            Condition.Requires(parameters.PageSize).IsGreaterOrEqual(1);

            var enterMessage = GetLoggerMessage(CallingMessageFormat, parameters);
            _logger.Debug(enterMessage);

            try
            {
                if (!string.IsNullOrEmpty(parameters.VacancyReference))
                {
                    var exactMatch = _vacancySearchProvider.FindVacancy(parameters.VacancyReference);
                    if (exactMatch != null && exactMatch.Total == 1)
                    {
                        return exactMatch;
                    }
                }
                return _vacancySearchProvider.FindVacancies(parameters);
            }
            catch (Exception e)
            {
                var message = GetLoggerMessage(FailedMessageFormat, parameters);
                _logger.Debug(message, e);
                throw new CustomException(message, e, ErrorCodes.VacanciesSearchFailed);
            }
        }

        public async Task<TVacancyDetail> GetVacancyDetails(int vacancyId)
        {
            Condition.Requires(vacancyId);

            _logger.Debug("Calling VacancyDataProvider to get vacancy details for vacancy {0}.", vacancyId);

            try
            {
                return await _vacancyDataProvider.GetVacancyDetails(vacancyId);
            }
            catch (Exception e)
            {
                var message = $"Get vacancy failed for vacancy {vacancyId}.";
                _logger.Debug(message, e);
                throw new CustomException(message, e, ErrorCodes.GetVacancyDetailsFailed);
            }
        }

        public int GetVacancyId(int vacancyReferenceNumber)
        {
            Condition.Requires(vacancyReferenceNumber);

            _logger.Debug("Calling VacancyDataProvider to get vacancy id for vacancy reference number {0}.", vacancyReferenceNumber);

            return _vacancyDataProvider.GetVacancyId(vacancyReferenceNumber);
        }

        private static string GetLoggerMessage(string message, SearchParametersBase parameters)
        {
            return string.Format(message, parameters);
        }
    }
}