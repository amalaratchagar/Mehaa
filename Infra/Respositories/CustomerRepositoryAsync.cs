﻿using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Respositories
{
    public class CustomerRepositoryAsync : GenericRepositoryAsync<Customer>, ICustomerRepositoryAsync
    {
        private readonly DbSet<Customer> _customer;

        public CustomerRepositoryAsync(MehaaDb dbContext) : base(dbContext)
        {
            _customer = dbContext.Set<Customer>();
        }
    }
}