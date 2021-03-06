﻿using SFA.Apprenticeships.Web.Recruit.ViewModels.Vacancy;

namespace SFA.Apprenticeships.Web.Recruit.ViewModels.ProviderUser
{
    using System.Collections.Generic;
    using System.Web.Mvc;

    public class HomeViewModel
    {
        public ProviderUserViewModel ProviderUserViewModel { get; set; }

        public List<SelectListItem> ProviderSites { get; set; }

        public List<VacancyViewModel> Vacancies { get; set; }
    }
}