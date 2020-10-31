using Core.Entities;
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
        public DbSet<Item> Students { get; set; }
        public DbSet<ItemCategory> Courses { get; set; }

        public MehaaDb()
        {

        }

        public MehaaDb(DbContextOptions<MehaaDb> options) : base(options)
        {

        }
    }
}


