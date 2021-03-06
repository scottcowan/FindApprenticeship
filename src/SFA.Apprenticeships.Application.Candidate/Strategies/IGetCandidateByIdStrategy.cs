﻿namespace SFA.Apprenticeships.Application.Candidate.Strategies
{
    using System;
    using Domain.Entities.Candidates;

    public interface IGetCandidateByIdStrategy
    {
        Candidate GetCandidate(int legacyCandidateId, bool errorIfNotFound = true);
        Candidate GetCandidate(Guid candidateId, bool errorIfNotFound = true);
    }
}