﻿using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infra.Data
{
    public class MehaaDb : DbContext
    {
        public DbSet<Item> Items { get; set; }

        public DbSet<ItemCategory> ItemCategories { get; set; }

        public DbSet<Customer> Customers { get; set; }

        public MehaaDb(DbContextOptions<MehaaDb> options) : base(options) { }
    }
}

