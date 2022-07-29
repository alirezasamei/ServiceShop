using App.Domain.Core.Customer.Contracts.Repositories;
using App.Domain.Core.Customer.Dtos;
using App.Infrastructure.SqlServer.Data;
using Microsoft.EntityFrameworkCore;

namespace App.Infrastructure.Repos.Ef.Customer
{
    public class OrderQueryRepository : IOrderQueryRepository
    {
        private readonly AppDbContext _context;
        public OrderQueryRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<List<OrderDto>> GetAll() =>
             await _context.Orders.Where(p => !p.IsDeleted).Select(p => new OrderDto()
             {
                 Id = p.Id,
                 OrderState = p.OrderState.Name,
                 OrderStateId = p.OrderStateId,
                 RegisterDate = p.RegisterDate,
                 Service = p.Service.Name,
                 ServiceId = p.ServiceId,
                 Customer = p.Customer.appUser.Name,
                 CustomerId = p.CustomerId,
             }).ToListAsync();

        public async Task<OrderDto?> Get(int id) =>
            await _context.Orders.Where(p => p.Id == id && !p.IsDeleted).Select(p => new OrderDto()
            {
                Id = p.Id,
                OrderState = p.OrderState.Name,
                OrderStateId = p.OrderStateId,
                RegisterDate = p.RegisterDate,
                Service = p.Service.Name,
                ServiceId = p.ServiceId,
                Customer = p.Customer.appUser.Name,
                CustomerId = p.CustomerId,
            }).FirstOrDefaultAsync();
    }
}
