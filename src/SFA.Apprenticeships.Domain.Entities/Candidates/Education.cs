﻿namespace SFA.Apprenticeships.Domain.Entities.Candidates
{
    using System;

    public class Education
    {
        public string Institution { get; set; }
        public int FromYear { get; set; }
        public int ToYear { get; set; }
    }
}
