using Core.Entities.User;
using Core.Interfaces.User;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Respositories
{
    public class PermissionRepositoryAsync : GenericRepositoryAsync<Permission>, IPermissionRepositoryAsync
    {
        private readonly DbSet<Permission> _permissions;

        public PermissionRepositoryAsync(MehaaDb dbContext) : base(dbContext)
        {
            _permissions = dbContext.Set<Permission>();
        }
    }
}