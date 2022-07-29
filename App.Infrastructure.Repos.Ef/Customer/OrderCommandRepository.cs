using App.Domain.Core.Customer.Contracts.Repositories;
using App.Domain.Core.Customer.Dtos;
using App.Infrastructure.SqlServer.Data;
using Microsoft.EntityFrameworkCore;
using App.Domain.Core.Customer.Entities;

namespace App.Infrastructure.Repos.Ef.Customer
{
    public class OrderCommandRepository : IOrderCommandRepository
    {
        private readonly AppDbContext _context;
        public OrderCommandRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<int> Add(OrderDto dto)
        {
            var entity = new Order()
            {
                IsDeleted = false,
                OrderStateId = dto.OrderStateId,
                RegisterDate = dto.RegisterDate,
                ServiceId = dto.ServiceId,
                CustomerId = dto.CustomerId,
            };
            await _context.Orders.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity.Id;
        }

        public async Task<int> Delete(int id)
        {
            var entity = await _context.Orders.FirstOrDefaultAsync(e => e.Id == id);
            entity.IsDeleted = true;
            await _context.SaveChangesAsync();
            return entity.Id;
        }

        public async Task<int> Update(OrderDto dto)
        {
            var entity = await _context.Orders.FirstOrDefaultAsync(e => e.Id == dto.Id);
            entity.OrderStateId = dto.OrderStateId;
            //entity.RegisterDate = dto.RegisterDate;
            entity.ServiceId = dto.ServiceId;
            entity.CustomerId = dto.CustomerId;
            await _context.SaveChangesAsync();
            return entity.Id;
        }
    }
}
