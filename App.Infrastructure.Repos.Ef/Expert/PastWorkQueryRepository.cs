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
        public async Task<List<PastWorkDto>> GetAll(CancellationToken cancellationToken) =>
             await _context.PastWorks.Where(p => !p.IsDeleted).Select(p => new PastWorkDto()
             {
                 Id = p.Id,
                 ComplitionDate = p.ComplitionDate,
                 ExpertServiceId = p.ExpertServiceId,
                 Price = p.Price,
                 Customer = p.Customer.AppUser.Name,
                 CustomerId = p.CustomerId,
             }).ToListAsync(cancellationToken);

        public async Task<PastWorkDto?> Get(int id, CancellationToken cancellationToken) =>
            await _context.PastWorks.Where(p => p.Id == id && !p.IsDeleted).Select(p => new PastWorkDto()
            {
                Id = p.Id,
                ComplitionDate = p.ComplitionDate,
                ExpertServiceId = p.ExpertServiceId,
                Service = p.ExpertService.Service.Name,
                Expert = p.ExpertService.Expert.AppUser.Name,
                Price = p.Price,
                Customer = p.Customer.AppUser.Name,
                CustomerId = p.CustomerId,
            }).FirstOrDefaultAsync(cancellationToken);

        public async Task<List<PastWorkDto>> GetByCustomerId(int id, CancellationToken cancellationToken) =>
             await _context.PastWorks.Where(p => !p.IsDeleted && p.CustomerId == id).Select(p => new PastWorkDto()
             {
                 Id = p.Id,
                 ComplitionDate = p.ComplitionDate,
                 ExpertServiceId = p.ExpertServiceId,
                 Service = p.ExpertService.Service.Name,
                 Expert = p.ExpertService.Expert.AppUser.Name,
                 Price = p.Price,
                 Customer = p.Customer.AppUser.Name,
                 CustomerId = p.CustomerId,
             }).ToListAsync(cancellationToken);

        public async Task<List<PastWorkDto>> GetByExpertId(int id, CancellationToken cancellationToken) =>
             await _context.PastWorks.Where(p => !p.IsDeleted && p.ExpertService.ExpertId == id).Select(p => new PastWorkDto()
             {
                 Id = p.Id,
                 ComplitionDate = p.ComplitionDate,
                 ExpertServiceId = p.ExpertServiceId,
                 Service = p.ExpertService.Service.Name,
                 Expert = p.ExpertService.Expert.AppUser.Name,
                 Price = p.Price,
                 Customer = p.Customer.AppUser.Name,
                 CustomerId = p.CustomerId,
             }).ToListAsync(cancellationToken);
    }
}
