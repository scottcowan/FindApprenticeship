﻿namespace SFA.Apprenticeships.Web.Candidate.ViewModels.VacancySearch
{
    using System.Collections.Generic;
    using SFA.Apprenticeships.Application.Interfaces.Vacancy;

    public class VacancySearchResponseViewModel
    {
        public int TotalHits { get; set; }
        public int PageSize { get; set; }
        public IEnumerable<VacancySummaryResponse> Vacancies { get; set; }
        public VacancySearchViewModel VacancySearch { get; set; }

        public int PrevPage
        {
            get
            {
                if (VacancySearch == null) return 1;

                return VacancySearch.PageNumber == 1 ? 1 : VacancySearch.PageNumber - 1;
            }
        }

        public int NextPage
        {
            get
            {
                if (VacancySearch == null) return 1;

                var pages = Pages;
                return VacancySearch.PageNumber == pages ? pages : VacancySearch.PageNumber + 1;
            }
        }

        public int Pages
        {
            get
            {
                var pages = 1;
                if (PageSize > 0)
                {
                    pages = TotalHits/PageSize;
                    if (TotalHits%PageSize > 0) pages++;
                }

                return pages;
            }
        }
    }
}
