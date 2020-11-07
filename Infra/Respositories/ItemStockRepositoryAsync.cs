using Core.Entities.Inventory;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Respositories
{
    public class ItemStockRepositoryAsync : GenericRepositoryAsync<ItemStock>, IItemStockRepositoryAsync
    {
        private readonly DbSet<ItemStock> _itemStocks;

        public ItemStockRepositoryAsync(MehaaDb dbContext) : base(dbContext)
        {
            _itemStocks = dbContext.Set<ItemStock>();
        }
    }
}
