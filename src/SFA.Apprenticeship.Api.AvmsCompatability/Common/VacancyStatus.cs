﻿namespace SFA.Apprenticeship.Api.AvmsCompatability.Common
{
    public enum VacancyStatus : int
    {

        Unspecified = 0,
        Draft = 1,
        Live = 2,
        Referred = 3,
        Deleted = 4,
        Submitted = 5,
        ClosingDatePassed = 6,
        Withdrawn = 7,
        Completed = 8,
        PostedInError = 9
    }
}