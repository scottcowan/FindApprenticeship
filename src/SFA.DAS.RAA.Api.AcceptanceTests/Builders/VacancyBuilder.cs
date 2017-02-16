namespace SFA.DAS.RAA.Api.AcceptanceTests.Builders
{
    using System;
    using Apprenticeships.Domain.Entities.Raa.Vacancies;

    public class VacancyBuilder
    {
        public int VacancyOwnerRelationshipId { get; set; }
        public VacancyLocationType VacancyLocationType { get; set; }
        public int NumberOfPositions { get; set; }
        public VacancyStatus VacancyStatus { get; set; }
        public int ContractOwnerId { get; set; }

        public Vacancy Build()
        {
            var vacancy = new Vacancy
            {
                VacancyGuid = Guid.NewGuid(),
                VacancyLocationType = VacancyLocationType,
                VacancyOwnerRelationshipId = VacancyOwnerRelationshipId,
                NumberOfPositions = NumberOfPositions,
                Status = VacancyStatus,
                ContractOwnerId = ContractOwnerId,
                OriginalContractOwnerId = ContractOwnerId
            };
            return vacancy;
        }
    }
}