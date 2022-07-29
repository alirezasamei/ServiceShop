﻿using App.Domain.Core.Customer.Contracts.Repositories;
using App.Domain.Core.Customer.Dtos;
using App.Infrastructure.SqlServer.Data;
using Microsoft.EntityFrameworkCore;
using CustomerEntities = App.Domain.Core.Customer.Entities;

namespace App.Infrastructure.Repos.Ef.Customer
{
    public class CustomerCommandRepository : ICustomerCommandRepository
    {
        private readonly AppDbContext _context;
        public CustomerCommandRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<int> Add(CustomerDto dto)
        {
            var entity = new CustomerEntities.Customer()
            {
                AppUserId = dto.AppUserId,
                Address = dto.Address,
            };
            await _context.Customers.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity.Id;
        }

        public async Task<int> Update(CustomerDto dto)
        {
            var entity = await _context.Customers.FirstOrDefaultAsync(e => e.Id == dto.Id);
            entity.AppUserId = dto.AppUserId;
            entity.Address = dto.Address;
            await _context.SaveChangesAsync();
            return entity.Id;
        }
    }
}
