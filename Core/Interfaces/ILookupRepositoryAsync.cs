using Core.Entities.Inventory;
using System.Collections.Generic;

namespace Core.Interfaces
{
    public interface ILookupRepositoryAsync
    {
        public IEnumerable<ItemCategory> GetCategories();

        public IEnumerable<Item> GetItems();

        public IEnumerable<Entities.User.User> GetUsers();

        public IEnumerable<Entities.User.Permission> GetPermissions();

        public IEnumerable<Entities.Supplier> GetSuppliers();
    }
}