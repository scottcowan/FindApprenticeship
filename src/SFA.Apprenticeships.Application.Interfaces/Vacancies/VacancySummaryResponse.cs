﻿namespace SFA.Apprenticeships.Application.Interfaces.Vacancies
{
    using Domain.Entities.Vacancies.Apprenticeships;

    //TODO: Rename to ApprenticeshipSummaryResponse.
    public class VacancySummaryResponse : ApprenticeshipSummary
    {
        public double Distance { get; set; }

        public double Score { get; set; }
    }
}
