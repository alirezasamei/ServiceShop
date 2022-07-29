using App.Domain.Core.Expert.Contracts.Repositories;
using App.Domain.Core.Expert.Dtos;
using App.Infrastructure.SqlServer.Data;
using Microsoft.EntityFrameworkCore;

namespace App.Infrastructure.Repos.Ef.Expert
{
    public class TenderQueryRepository : ITenderQueryRepository
    {
        private readonly AppDbContext _context;
        public TenderQueryRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<List<TenderDto>> GetAll() =>
             await _context.Tenders.Select(p => new TenderDto()
             {
                 Id = p.Id,
                 Expert = p.Expert.appUser.Name,
                 ExpertId = p.ExpertId,
                 OrderId = p.OrderId,
                 Price = p.Price,
                 RegisterDate = p.RegisterDate,
                 RequiredTime = p.RequiredTime,
                 StartDate = p.StartDate,
             }).ToListAsync();

        public async Task<TenderDto?> Get(int id) =>
            await _context.Tenders.Where(p => p.Id == id).Select(p => new TenderDto()
            {
                Id = p.Id,
                Expert = p.Expert.appUser.Name,
                ExpertId = p.ExpertId,
                OrderId = p.OrderId,
                Price = p.Price,
                RegisterDate = p.RegisterDate,
                RequiredTime = p.RequiredTime,
                StartDate = p.StartDate,
            }).FirstOrDefaultAsync();
    }
}
