using App.Domain.Core.Expert.Contracts.Repositories;
using App.Domain.Core.Expert.Dtos;
using App.Domain.Core.Expert.Entities;
using App.Infrastructure.SqlServer.Data;
using Microsoft.EntityFrameworkCore;

namespace App.Infrastructure.Repos.Ef.Expert
{
    public class ExpertServiceFileCommandRepository : IExpertServiceFileCommandRepository
    {
        private readonly AppDbContext _context;
        public ExpertServiceFileCommandRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<int> Add(ExpertServiceFileDto dto)
        {
            var entity = new ExpertServiceFile()
            {
                CreationDate = dto.CreationDate,
                Description = dto.Description,
                ExpertServiceId = dto.ExpertServiceId,
                FileTypeId = dto.FileTypeId,
                IsDeleted = dto.IsDeleted,
                NameWithExtention = dto.NameWithExtention,                
            };
            await _context.ExpertServiceFiles.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity.Id;
        }

        public async Task<int> Delete(int id)
        {
            var entity = await _context.ExpertServiceFiles.FirstOrDefaultAsync(e => e.Id == id);
            _context.ExpertServiceFiles.Remove(entity);
            await _context.SaveChangesAsync();
            return entity.Id;
        }

        public async Task<int> Update(ExpertServiceFileDto dto)
        {
            var entity = await _context.ExpertServiceFiles.FirstOrDefaultAsync(e => e.Id == dto.Id);
            entity.CreationDate = dto.CreationDate;
            entity.Description = dto.Description;
            entity.ExpertServiceId = dto.ExpertServiceId;
            entity.FileTypeId = dto.FileTypeId;
            entity.IsDeleted = dto.IsDeleted;
            entity.NameWithExtention = dto.NameWithExtention;
            await _context.SaveChangesAsync();
            return entity.Id;
        }
    }
}
