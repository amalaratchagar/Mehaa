using Core.Entities;
using Core.Entities.Inventory;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Interfaces
{
    public interface ILookupRepositoryAsync 
    {
        public IEnumerable<ItemCategory> GetCategories();
    }
}
