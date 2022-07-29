using App.Domain.Core.Expert.Contracts.Repositories;
using App.Domain.Core.Expert.Dtos;
using App.Infrastructure.SqlServer.Data;
using Microsoft.EntityFrameworkCore;

namespace App.Infrastructure.Repos.Ef.Expert
{
    public class PastWorkQueryRepository : IPastWorkQueryRepository
    {
        private readonly AppDbContext _context;
        public PastWorkQueryRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<List<PastWorkDto>> GetAll() =>
             await _context.PastWorks.Where(p => !p.IsDeleted).Select(p => new PastWorkDto()
             {
                 Id = p.Id,
                 ComplitionDate = p.ComplitionDate,
                 ExpertServiceId = p.ExpertServiceId,
                 Price = p.Price,
                 Customer = p.Customer.appUser.Name,
                 CustomerId = p.CustomerId,
             }).ToListAsync();

        public async Task<PastWorkDto?> Get(int id) =>
            await _context.PastWorks.Where(p => p.Id == id && !p.IsDeleted).Select(p => new PastWorkDto()
            {
                Id = p.Id,
                ComplitionDate = p.ComplitionDate,
                ExpertServiceId = p.ExpertServiceId,
                Price = p.Price,
                Customer = p.Customer.appUser.Name,
                CustomerId = p.CustomerId,
            }).FirstOrDefaultAsync();
    }
}
