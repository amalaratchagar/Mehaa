using Core.Entities.Inventory;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Respositories
{
    public class ItemCategoryRepositoryAsync : GenericRepositoryAsync<ItemCategory>, IItemCategoryRepositoryAsync
    {
        private readonly DbSet<ItemCategory> _itemCategories ;

        public ItemCategoryRepositoryAsync(MehaaDb dbContext) : base(dbContext)
        {
            _itemCategories = dbContext.Set<ItemCategory>();
        }
    }
}
