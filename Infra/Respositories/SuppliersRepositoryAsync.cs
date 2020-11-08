using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Respositories
{
    public class SupplierRepositoryAsync : GenericRepositoryAsync<Supplier>, ISupplierRepositoryAsync
    {
        private readonly DbSet<Supplier> _suppliers;

        public SupplierRepositoryAsync(MehaaDb dbContext) : base(dbContext)
        {
            _suppliers = dbContext.Set<Supplier>();
        }
    }
}