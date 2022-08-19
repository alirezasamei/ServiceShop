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
        public async Task<List<CustomerDto>> GetAll(CancellationToken cancellationToken) =>
             await _context.Customers.Where(p => !p.AppUser.IsDeleted).Select(p => new CustomerDto()
             {
                 Id = p.Id,
                 AppUserId = p.AppUserId,
                 Address = p.Address,
             }).ToListAsync(cancellationToken);

        public async Task<CustomerDto?> Get(int appUserId, CancellationToken cancellationToken) =>
            await _context.Customers.Where(p => p.AppUser.Id == appUserId && !p.AppUser.IsDeleted).Select(p => new CustomerDto()
            {
                Id = p.Id,
                AppUserId = p.AppUserId,
                Address = p.Address,
            }).FirstOrDefaultAsync(cancellationToken);

        public async Task<bool> DoseExists(int appUserId, CancellationToken cancellationToken) =>
            await _context.Customers.AnyAsync(p => p.AppUser.Id == appUserId && !p.AppUser.IsDeleted, cancellationToken);

    }
}
