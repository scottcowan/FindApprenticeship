namespace SFA.Apprenticeships.Application.Candidate.Strategies
{
    using System;
    using System.Threading.Tasks;
    using Domain.Entities.Vacancies;

    public interface IGetCandidateVacancyDetailStrategy<TVacancyDetail>
        where TVacancyDetail : VacancyDetail
    {
        Task<TVacancyDetail> GetVacancyDetails(Guid candidateId, int vacancyId);
    }
}
