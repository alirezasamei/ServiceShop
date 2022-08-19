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
        public async Task<List<OrderDto>> GetAll(CancellationToken cancellationToken) =>
             await _context.Orders.Where(p => !p.IsDeleted).Select(p => new OrderDto()
             {
                 Id = p.Id,
                 OrderState = p.OrderState.Name,
                 OrderStateId = p.OrderStateId,
                 RegisterDate = p.RegisterDate,
                 Service = p.Service.Name,
                 ServiceId = p.ServiceId,
                 Customer = p.Customer.AppUser.Name,
                 CustomerId = p.CustomerId,
             }).ToListAsync(cancellationToken);

        public async Task<OrderDto?> Get(int id, CancellationToken cancellationToken) =>
            await _context.Orders.Where(p => p.Id == id && !p.IsDeleted).Select(p => new OrderDto()
            {
                Id = p.Id,
                OrderState = p.OrderState.Name,
                OrderStateId = p.OrderStateId,
                RegisterDate = p.RegisterDate,
                Service = p.Service.Name,
                ServiceId = p.ServiceId,
                Customer = p.Customer.AppUser.Name,
                CustomerId = p.CustomerId,
            }).FirstOrDefaultAsync(cancellationToken);

        public async Task<List<OrderDto>> GetByServiceId(int serviceId, CancellationToken cancellationToken) =>
             await _context.Orders.Where(p => p.ServiceId == serviceId && !p.IsDeleted).Select(p => new OrderDto()
             {
                 Id = p.Id,
                 OrderState = p.OrderState.Name,
                 OrderStateId = p.OrderStateId,
                 RegisterDate = p.RegisterDate,
                 Service = p.Service.Name,
                 ServiceId = p.ServiceId,
                 Customer = p.Customer.AppUser.Name,
                 CustomerId = p.CustomerId,
             }).ToListAsync(cancellationToken);
    }
}
