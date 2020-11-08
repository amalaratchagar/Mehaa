using Core.Entities.User;
using Core.Interfaces.User;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Respositories
{
    public class UserPermissionRepositoryAsync : GenericRepositoryAsync<UserPermission>, IUserPermissionRepositoryAsync
    {
        private readonly DbSet<UserPermission> _userPermissions;
        private readonly MehaaDb _dbContext;

        public UserPermissionRepositoryAsync(MehaaDb dbContext) : base(dbContext)
        {
            _userPermissions = dbContext.Set<UserPermission>();
            _dbContext = dbContext;
        }

        public new async Task<IReadOnlyList<UserPermission>> GetAllAsync()
        {
            return await _dbContext.Set<UserPermission>()
                                   .Include(item => item.User)
                                   .Include(item => item.Permission)
                                   .ToListAsync();
        }
    }
}