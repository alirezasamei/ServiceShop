using App.Domain.Core.Expert.Contracts.Repositories;
using App.Domain.Core.Expert.Dtos;
using App.Domain.Core.Expert.Entities;
using App.Infrastructure.SqlServer.Data;
using Microsoft.EntityFrameworkCore;

namespace App.Infrastructure.Repos.Ef.Expert
{
    public class ExpertServiceCommandRepository : IExpertServiceCommandRepository
    {
        private readonly AppDbContext _context;
        public ExpertServiceCommandRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<int> Add(ExpertServiceDto dto)
        {
            var entity = new ExpertService()
            {
                CreationDate = dto.CreationDate,
                ExpertId = dto.ExpertId,
                IsActive = dto.IsActive,
                IsDeleted = dto.IsDeleted,
                ServiceId = dto.ServiceId,                
            };
            await _context.ExpertServices.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity.Id;
        }

        public async Task<int> Delete(int id)
        {
            var entity = await _context.ExpertServices.FirstOrDefaultAsync(e => e.Id == id);
            _context.ExpertServices.Remove(entity);
            await _context.SaveChangesAsync();
            return entity.Id;
        }

        public async Task<int> Update(ExpertServiceDto dto)
        {
            var entity = await _context.ExpertServices.FirstOrDefaultAsync(e => e.Id == dto.Id);
            entity.CreationDate = dto.CreationDate;
            entity.ExpertId = dto.ExpertId;
            entity.IsActive = dto.IsActive;
            entity.IsDeleted = dto.IsDeleted;
            entity.ServiceId = dto.ServiceId;
            await _context.SaveChangesAsync();
            return entity.Id;
        }
    }
}
