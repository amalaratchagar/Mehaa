using Core.Entities;
using Core.Entities.Inventory;
using Core.Entities.User;
using Core.Interfaces;
using Infrastructure.Data;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.Respositories
{
    public class LookupRepositoryAsync : ILookupRepositoryAsync
    {
        private MehaaDb _mehaaDb;

        public LookupRepositoryAsync(MehaaDb dbContext)
        {
            _mehaaDb = dbContext;
        }

        public IEnumerable<ItemCategory> GetCategories()
        {
            return _mehaaDb.Set<ItemCategory>().ToList();
        }

        public IEnumerable<Item> GetItems()
        {
            return _mehaaDb.Set<Item>().ToList();
        }

        public IEnumerable<Permission> GetPermissions()
        {
            return _mehaaDb.Set<Permission>().ToList();
        }

        public IEnumerable<Supplier> GetSuppliers()
        {
            return _mehaaDb.Set<Supplier>().ToList();
        }

        public IEnumerable<User> GetUsers()
        {
            return _mehaaDb.Set<User>().ToList();
        }
    }
}