﻿namespace SFA.DAS.RAA.Api.AcceptanceTests.Constants
{
    public class UriFormats
    {
        public const string VacancyIdUriFormat = "/vacancy/{0}";
        public const string VacancyReferenceNumberUriFormat = "/vacancy/reference/{0}";
        public const string VacancyGuidUriFormat = "/vacancy/guid/{0}";

        public const string PublicVacancySummariesUriFormat = "/public/vacancysummaries?page={0}&pageSize={1}";

        public const string EditWageVacancyIdUriFormat = "/vacancy/{0}/wage";

        public const string LinkEmployerUri = "/employer/link";
        public const string LinkEmployerEdsUrnUriFormat = "/employer/edsurn/{0}/link";
    }
}