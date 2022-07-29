using App.Domain.Core.Customer.Contracts.Repositories;
using App.Infrastructure.SqlServer.Data;
using Microsoft.EntityFrameworkCore;
using App.Domain.Core.Customer.Entities;

namespace App.Infrastructure.Repos.Ef.Customer
{
    public class OrderStateCommandRepository : IOrderStateCommandRepository
    {
        private readonly AppDbContext _context;
        public OrderStateCommandRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<int> Add(string name)
        {
            var entity = new OrderState()
            {
                IsDeleted = false,
                Name = name,
            };
            await _context.OrderStates.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity.Id;
        }

        public async Task<int> Delete(int id)
        {
            var entity = await _context.OrderStates.FirstOrDefaultAsync(e => e.Id == id);
            entity.IsDeleted = true;
            await _context.SaveChangesAsync();
            return entity.Id;
        }

        public async Task<int> Update(int id, string name)
        {
            var entity = await _context.OrderStates.FirstOrDefaultAsync(e => e.Id == id);
            entity.Name = name;
            await _context.SaveChangesAsync();
            return entity.Id;
        }
    }
}
