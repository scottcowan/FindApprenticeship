namespace SFA.Apprenticeships.Infrastructure.Repositories.Sql.Schemas.dbo
{
    using System.Linq;
    using Common;
    using Domain.Interfaces.Repositories;

    public class ReferenceNumberRepository : IReferenceNumberRepository
    {
        public const string GetNextVacancyReferenceNumberSql = "SELECT NEXT VALUE FOR dbo.VacancyReferenceNumberSequence";

        private readonly IGetOpenConnection _connection;

        public ReferenceNumberRepository(IGetOpenConnection connection)
        {
            _connection = connection;
        }

        public int GetNextVacancyReferenceNumber()
        {
            return _connection.Query<int>(GetNextVacancyReferenceNumberSql).Single();
        }

        public int GetNextLegacyApplicationId()
        {
            const string sql = "SELECT NEXT VALUE FOR dbo.LegacyApplicationIdSequence";

            return _connection.Query<int>(sql).Single();
        }
    }
}
