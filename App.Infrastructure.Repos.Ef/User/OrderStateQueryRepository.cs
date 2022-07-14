using App.Domain.Core.User.Contracts.Repositories;
using App.Domain.Core.User.Dtos;
using App.Infrastructure.SqlServer.Data;
using Microsoft.EntityFrameworkCore;

namespace App.Infrastructure.Repos.Ef.User
{
    public class OrderStateQueryRepository : IOrderStateQueryRepository
    {
        private readonly AppDbContext _context;
        public OrderStateQueryRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<List<OrderStateDto>> GetAll() =>
             await _context.OrderStates.Select(p => new OrderStateDto()
             {
                 Id = p.Id,
                 Name = p.Name,
             }).ToListAsync();

        public async Task<OrderStateDto?> Get(int id) =>
            await _context.OrderStates.Where(p => p.Id == id).Select(p => new OrderStateDto()
            {
                Id = p.Id,
                Name = p.Name,
            }).FirstOrDefaultAsync();

        public async Task<OrderStateDto?> Get(string name) =>
            await _context.OrderStates.Where(p => p.Name == name).Select(p => new OrderStateDto()
            {
                Id = p.Id,
                Name = p.Name,
            }).FirstOrDefaultAsync();
    }
}
