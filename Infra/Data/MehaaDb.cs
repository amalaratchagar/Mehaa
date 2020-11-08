using Core.Entities;
using Core.Entities.Inventory;
using Core.Entities.User;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class MehaaDb : DbContext
    {
        public DbSet<Item> Items { get; set; }

        public DbSet<ItemCategory> ItemCategories { get; set; }

        public DbSet<ItemStock> ItemStocks { get; set; }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Permission> Permissions { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<UserPermission> UserPermissions { get; set; }

        public MehaaDb(DbContextOptions<MehaaDb> options) : base(options)
        {
        }
    }
}