using Core.Entities.User;
using Core.Interfaces.User;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Respositories
{
    public class UserRepositoryAsync : GenericRepositoryAsync<User>, IUserRepositoryAsync
    {
        private readonly DbSet<User> _users;

        public UserRepositoryAsync(MehaaDb dbContext) : base(dbContext)
        {
            _users = dbContext.Set<User>();
        }
    }
}