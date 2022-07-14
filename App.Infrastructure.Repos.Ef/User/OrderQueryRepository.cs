using App.Domain.Core.User.Contracts.Repositories;
using App.Domain.Core.User.Dtos;
using App.Infrastructure.SqlServer.Data;
using Microsoft.EntityFrameworkCore;

namespace App.Infrastructure.Repos.Ef.User
{
    public class OrderQueryRepository : IOrderQueryRepository
    {
        private readonly AppDbContext _context;
        public OrderQueryRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<List<OrderDto>> GetAll() =>
             await _context.Orders.Select(p => new OrderDto()
             {
                 Id = p.Id,
                 IsDeleted = p.IsDeleted,
                 OrderState = p.OrderState.Name,
                 OrderStateId = p.OrderStateId,
                 RegisterDate = p.RegisterDate,
                 Service = p.Service.Name,
                 ServiceId = p.ServiceId,
                 User = p.User.Name,
                 UserId = p.UserId,
             }).ToListAsync();

        public async Task<OrderDto?> Get(int id) =>
            await _context.Orders.Where(p => p.Id == id).Select(p => new OrderDto()
            {
                Id = p.Id,
                IsDeleted = p.IsDeleted,
                OrderState = p.OrderState.Name,
                OrderStateId = p.OrderStateId,
                RegisterDate = p.RegisterDate,
                Service = p.Service.Name,
                ServiceId = p.ServiceId,
                User = p.User.Name,
                UserId = p.UserId,
            }).FirstOrDefaultAsync();
    }
}
