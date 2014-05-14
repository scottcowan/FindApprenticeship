﻿
namespace SFA.Apprenticeships.Services.Models.ReferenceData
{
    public class Occupation : ILegacyReferenceData
    {
        public string ShortName { get; set; }
        public string Id { get; set; }
        public string Description { get; set; }
    }
}
