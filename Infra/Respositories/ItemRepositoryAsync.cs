using Core.Entities.Inventory;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Respositories
{
    public class ItemRepositoryAsync : GenericRepositoryAsync<Item>, IItemRepositoryAsync
    {
        private readonly DbSet<Item> _items;
        private readonly MehaaDb _dbContext;

        public ItemRepositoryAsync(MehaaDb dbContext) : base(dbContext)
        {
            _items = dbContext.Set<Item>();
            _dbContext = dbContext;
        }

        public new async Task<IReadOnlyList<Item>> GetAllAsync()
        {
            return await _dbContext.Set<Item>().Include(item => item.Category).ToListAsync();
        }
    }
}
