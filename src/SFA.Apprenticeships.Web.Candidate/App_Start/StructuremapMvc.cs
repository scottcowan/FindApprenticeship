using SFA.Apprenticeships.Web.Candidate;
[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(StructuremapMvc), "Start")]

namespace SFA.Apprenticeships.Web.Candidate
{
    using SFA.Apprenticeships.Infrastructure.Common.IoC;
    using SFA.Apprenticeships.Infrastructure.Elastic.Common.IoC;
    using SFA.Apprenticeships.Infrastructure.VacancySearch.IoC;
    using SFA.Apprenticeships.Web.Candidate.IoC;
    using SFA.Apprenticeships.Web.Common.IoC;
    using StructureMap;

    /// <summary>
    /// StructureMap MVC initialization. Sets the MVC resolver and the WebApi resolver to use structure map.
    /// </summary>
    public static class StructuremapMvc
    {
        public static void Start()
        {
            ObjectFactory.Initialize(x =>
            {
                x.AddRegistry<CommonRegistry>();

                x.AddRegistry<VacancySearchRegistry>();
                x.AddRegistry<ElasticsearchCommonRegistry>();

                x.AddRegistry<WebCommonRegistry>();
                x.AddRegistry<CandidateRegistry>();
            });

            WebCommonRegistry.Configure(ObjectFactory.Container);
        }
    }
}