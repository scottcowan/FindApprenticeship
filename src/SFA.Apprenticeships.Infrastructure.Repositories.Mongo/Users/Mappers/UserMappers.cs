namespace SFA.Apprenticeships.Infrastructure.Repositories.Mongo.Users.Mappers
{
    using Domain.Entities.Users;
    using Infrastructure.Common.Mappers;
    using Entities;

    public class UserMappers : MapperEngine
    {
        public override void Initialise()
        {
            Mapper.CreateMap<User, MongoUser>();
            Mapper.CreateMap<MongoUser, User>();
        }
    }
}
