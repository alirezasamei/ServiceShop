using App.Domain.Core.User.Contracts.Repositories;
using App.Domain.Core.User.Dtos;
using App.Infrastructure.SqlServer.Data;
using Microsoft.EntityFrameworkCore;
using App.Domain.Core.User.Entities;

namespace App.Infrastructure.Repos.Ef.User
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
                IsDeleted = dto.IsDeleted,
                OrderStateId = dto.OrderStateId,
                RegisterDate = dto.RegisterDate,
                ServiceId = dto.ServiceId,
                UserId = dto.UserId,
            };
            await _context.Orders.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity.Id;
        }

        public async Task<int> Delete(int id)
        {
            var entity = await _context.Orders.FirstOrDefaultAsync(e => e.Id == id);
            _context.Orders.Remove(entity);
            await _context.SaveChangesAsync();
            return entity.Id;
        }

        public async Task<int> Update(OrderDto dto)
        {
            var entity = await _context.Orders.FirstOrDefaultAsync(e => e.Id == dto.Id);
            entity.IsDeleted = dto.IsDeleted;
            entity.OrderStateId = dto.OrderStateId;
            entity.RegisterDate = dto.RegisterDate;
            entity.ServiceId = dto.ServiceId;
            entity.UserId = dto.UserId;
            await _context.SaveChangesAsync();
            return entity.Id;
        }
    }
}
