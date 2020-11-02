﻿using Core.Entities;
using Core.Entities.Inventory;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infrastructure.Respositories
{
    public class LookupRepositoryAsync : ILookupRepositoryAsync
    {
        MehaaDb _mehaaDb;

        public LookupRepositoryAsync(MehaaDb dbContext)
        {
            _mehaaDb = dbContext;
        }

        public IEnumerable<ItemCategory> GetCategories()
        {
           return _mehaaDb.Set<ItemCategory>().ToList();
        }
    }
}
