namespace SFA.DAS.RAA.Api.AcceptanceTests.Builders
{
    using System;
    using System.Web.UI.WebControls;
    using Apprenticeships.Domain.Entities.Raa.Vacancies;

    public class VacancyBuilder
    {
        public int VacancyOwnerRelationshipId { get; set; }
        public VacancyLocationType VacancyLocationType { get; set; }
        public int NumberOfPositions { get; set; }
        public VacancyStatus VacancyStatus { get; set; }
        public int ContractOwnerId { get; set; }
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public string OfflineApplicationUrl { get; set; }
        public string OfflineApplicationInstructions { get; set; }

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
                OriginalContractOwnerId = ContractOwnerId,
                Title = Title,
                ShortDescription = ShortDescription,
                OfflineApplicationUrl = OfflineApplicationUrl,
                OfflineApplicationInstructions = OfflineApplicationInstructions,
            };
            return vacancy;
        }
    }
}