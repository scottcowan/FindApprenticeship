﻿namespace SFA.Apprenticeships.Web.Manage.ViewModels
{
    using System.Collections.Generic;
    using System.Web.Mvc;

    public class AgencyUserViewModel
    {
        public List<SelectListItem> Teams { get; set; }
        public string TeamId { get; set; }
        public List<SelectListItem> Roles { get; set; }
        public string RoleId { get; set; }
    }
}