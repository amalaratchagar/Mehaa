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
    public class ItemStockRepositoryAsync : GenericRepositoryAsync<ItemStock>, IItemStockRepositoryAsync
    {
        private readonly DbSet<ItemStock> _itemStocks;
        private readonly MehaaDb _dbContext;

        public ItemStockRepositoryAsync(MehaaDb dbContext) : base(dbContext)
        {
            _itemStocks = dbContext.Set<ItemStock>();
            _dbContext = dbContext;
        }

        public new async Task<IReadOnlyList<ItemStock>> GetAllAsync()
        {
            return await _dbContext.Set<ItemStock>().Include(stock => stock.Item).ToListAsync();
        }
    }
}
