using App.Domain.Core.Customer.Contracts.Repositories;
using App.Domain.Core.Customer.Dtos;
using App.Infrastructure.SqlServer.Data;
using Microsoft.EntityFrameworkCore;

namespace App.Infrastructure.Repos.Ef.Customer
{
    public class CustomerQueryRepository : ICustomerQueryRepository
    {
        private readonly AppDbContext _context;
        public CustomerQueryRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<List<CustomerDto>> GetAll() =>
             await _context.Customers.Where(p => !p.appUser.IsDeleted).Select(p => new CustomerDto()
             {
                 Id = p.Id,
                 AppUserId = p.AppUserId,
                 Address = p.Address,
             }).ToListAsync();

        public async Task<CustomerDto?> Get(int appUserId) =>
            await _context.Customers.Where(p => p.appUser.Id == appUserId && !p.appUser.IsDeleted).Select(p => new CustomerDto()
            {
                Id = p.Id,
                AppUserId = p.AppUserId,
                Address = p.Address,
            }).FirstOrDefaultAsync();
    }
}
