using App.Domain.Core.Customer.Contracts.Repositories;
using App.Domain.Core.Customer.Dtos;
using App.Infrastructure.SqlServer.Data;
using Microsoft.EntityFrameworkCore;

namespace App.Infrastructure.Repos.Ef.Customer
{
    public class OrderStateQueryRepository : IOrderStateQueryRepository
    {
        private readonly AppDbContext _context;
        public OrderStateQueryRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<List<OrderStateDto>> GetAll() =>
             await _context.OrderStates.Where(p => !p.IsDeleted).Select(p => new OrderStateDto()
             {
                 Id = p.Id,
                 Name = p.Name,
             }).ToListAsync();

        public async Task<OrderStateDto?> Get(int id) =>
            await _context.OrderStates.Where(p => p.Id == id && !p.IsDeleted).Select(p => new OrderStateDto()
            {
                Id = p.Id,
                Name = p.Name,
            }).FirstOrDefaultAsync();

        public async Task<OrderStateDto?> Get(string name) =>
            await _context.OrderStates.Where(p => p.Name == name && !p.IsDeleted).Select(p => new OrderStateDto()
            {
                Id = p.Id,
                Name = p.Name,
            }).FirstOrDefaultAsync();
    }
}
