using Core.Entities.Inventory;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Respositories
{
    public class ItemRepositoryAsync : GenericRepositoryAsync<Item>, IItemRepositoryAsync
    {
        private readonly DbSet<Item> _items;

        public ItemRepositoryAsync(MehaaDb dbContext) : base(dbContext)
        {
            _items = dbContext.Set<Item>();
        }
    }
}
