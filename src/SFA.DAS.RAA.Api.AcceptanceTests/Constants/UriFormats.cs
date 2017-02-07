namespace SFA.DAS.RAA.Api.AcceptanceTests.Constants
{
    public class UriFormats
    {
        public const string VacancyIdUriFormat = "/vacancy/{0}";
        public const string VacancyReferenceNumberUriFormat = "/vacancy/reference/{0}";
        public const string VacancyGuidUriFormat = "/vacancy/guid/{0}";

        public const string PublicVacancyIdUriFormat = "/public/vacancy/{0}";
        public const string PublicVacancyReferenceNumberUriFormat = "/public/vacancy/reference/{0}";
        public const string PublicVacancyGuidUriFormat = "/public/vacancy/guid/{0}";

        public const string PublicVacancySummariesUriFormat = "/public/vacancysummaries?page={0}&pageSize={1}";

        public const string EditWageVacancyIdUriFormat = "/vacancy/{0}/wage";

        public const string LinkEmployerUri = "/employer/link";
        public const string LinkEmployerEdsUrnUriFormat = "/employer/edsurn/{0}/link";

        public const string GetCountiesUri = "reference/counties";
        public const string CountyIdUriFormat = "reference/county/{0}";
        public const string CountyCodeUriFormat = "reference/county/code/{0}";

        public const string GetLocalAuthoritiesUri = "reference/localauthorities";
        public const string LocalAuthorityIdUriFormat = "reference/localauthority/{0}";
        public const string LocalAuthorityCodeUriFormat = "reference/localauthority/code/{0}";

        public const string GetRegionsUri = "reference/regions";
        public const string RegionIdUriFormat = "reference/region/{0}";
        public const string RegionCodeUriFormat = "reference/region/code/{0}";

        public const string VacancySummariesUriFormat = "vacancies";
    }
}