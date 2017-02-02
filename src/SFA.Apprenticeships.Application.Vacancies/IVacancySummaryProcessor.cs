namespace SFA.Apprenticeships.Application.Vacancies
{
    using System.Threading.Tasks;
    using Domain.Interfaces.Messaging;

    public interface IVacancySummaryProcessor
    {
        Task ProcessVacancyPages(StorageQueueMessage scheduledQueueMessage);
    }
}
