using App.Domain.Core.Expert.Contracts.Repositories;
using App.Domain.Core.Expert.Dtos;
using App.Infrastructure.SqlServer.Data;
using Microsoft.EntityFrameworkCore;
using App.Domain.Core.Expert.Entities;

namespace App.Infrastructure.Repos.Ef.Expert
{
    public class PastWorkCommandRepository : IPastWorkCommandRepository
    {
        private readonly AppDbContext _context;
        public PastWorkCommandRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<int> Add(PastWorkDto dto)
        {
            var entity = new PastWork()
            {
                ComplitionDate = dto.ComplitionDate,
                ExpertServiceId = dto.ExpertServiceId,
                IsDeleted = false,
                Price = dto.Price,
                CustomerId = dto.CustomerId,
            };
            await _context.PastWorks.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity.Id;
        }

        public async Task<int> Delete(int id)
        {
            var entity = await _context.PastWorks.FirstOrDefaultAsync(e => e.Id == id);
            entity.IsDeleted = true;
            await _context.SaveChangesAsync();
            return entity.Id;
        }

        public async Task<int> Update(PastWorkDto dto)
        {
            var entity = await _context.PastWorks.FirstOrDefaultAsync(e => e.Id == dto.Id);
            entity.ComplitionDate = dto.ComplitionDate;
            entity.ExpertServiceId = dto.ExpertServiceId;
            entity.Price = dto.Price;
            entity.CustomerId = dto.CustomerId;
            await _context.SaveChangesAsync();
            return entity.Id;
        }
    }
}
