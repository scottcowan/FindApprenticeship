﻿namespace ApprenticeshipScraper.CmdLine.Steps
{
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    using ApprenticeshipScraper.CmdLine.Models;
    using ApprenticeshipScraper.CmdLine.Services;
    using ApprenticeshipScraper.CmdLine.Settings;

    using CsQuery;

    public class TraineeDetailsScraper : IStep
    {
        public const string UrlFormat = "/traineeship/{0}";

        private readonly ICreateDirectory directory;

        private readonly IGlobalSettings settings;

        private readonly IUrlResolver resolver;

        public TraineeDetailsScraper(IUrlResolver resolver, ICreateDirectory directory, IStepLogger logger, IGlobalSettings settings)
        {
            this.resolver = resolver;
            this.directory = directory;
            this.settings = settings;
            this.Logger = logger;
        }

        public IStepLogger Logger { get; }

        public void Run(ApplicationArguments arguments)
        {
            var folder = Path.Combine(arguments.Directory, arguments.Site.ToString());
            var detailsFolder = Path.Combine(folder, FolderNames.TraineeDetails);
            this.directory.CreateDirectoryIfMissing(detailsFolder);

            var filenames = this.LookAtApprenticeshipFiles(folder);
            Parallel.ForEach(
                filenames,
                new ParallelOptions { MaxDegreeOfParallelism = this.settings.MaxDegreeOfParallelism },
                filename =>
                    {
                        using (var cookieAwareWebClient = new CookieAwareWebClient())
                        {
                            var item = this.DownloadItem(arguments.Site, filename, cookieAwareWebClient);
                            var section = this.ParsePage(item);
                            SavePage(detailsFolder, section);
                        }
                    });
        }

        private static void SavePage(string folder, dynamic section)
        {
            File.WriteAllText(Path.Combine(folder, section.Id + ".html"), section.Html);
        }

        private dynamic ParsePage(dynamic model)
        {
            var dom = model.Dom["main"];
            return new { model.Id, Html = new CQ(dom).RenderSelection() };
        }

        private dynamic DownloadItem(SiteEnum site, string filename, CookieAwareWebClient cookieAwareWebClient)
        {
            var id = filename.Substring(filename.LastIndexOf("\\") + 1).Split('.').First();
            this.Logger.Info($"Thread:{Thread.CurrentThread.ManagedThreadId:00} Id:{id}");
            var url = this.resolver.Resolve(site) + string.Format(UrlFormat, id);
            CQ dom = cookieAwareWebClient.DownloadString(url);
            return new { Id = id, Dom = dom };
        }

        private IEnumerable<string> LookAtApprenticeshipFiles(string folder)
        {
            return Directory.EnumerateFiles(Path.Combine(folder, FolderNames.TraineeResults));
        }
    }
}