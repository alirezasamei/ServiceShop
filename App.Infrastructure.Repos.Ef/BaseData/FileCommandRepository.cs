using App.Domain.Core.BaseData.Contracts.Repositories;
using App.Domain.Core.BaseData.Dtos;
using App.Infrastructure.SqlServer.Data;
using Microsoft.EntityFrameworkCore;
using BaseDataEntities = App.Domain.Core.BaseData.Entities;

namespace App.Infrastructure.Repos.Ef.BaseData
{
    public class FileCommandRepository : IFileCommandRepository
    {
        private readonly AppDbContext _context;
        public FileCommandRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<int> Add(FileDto dto)
        {
            var entity = new BaseDataEntities.File()
            {
                CreationDate = dto.CreationDate,
                Description = dto.Description,
                ExpertServiceId = dto.ExpertServiceId,
                FileTypeId = dto.FileTypeId,
                IsDeleted = false,
                NameWithExtention = dto.NameWithExtention,
                ServiceId = dto.ServiceId,
            };
            await _context.Files.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity.Id;
        }

        public async Task<int> Delete(int id)
        {
            var entity = await _context.Files.FirstOrDefaultAsync(e => e.Id == id);
            entity.IsDeleted = true;
            await _context.SaveChangesAsync();
            return entity.Id;
        }

        public async Task<int> Update(FileDto dto)
        {
            var entity = await _context.Files.FirstOrDefaultAsync(e => e.Id == dto.Id);
            entity.CreationDate = dto.CreationDate;
            entity.Description = dto.Description;
            entity.ExpertServiceId = dto.ExpertServiceId;
            entity.FileTypeId = dto.FileTypeId;
            entity.NameWithExtention = dto.NameWithExtention;
            entity.ServiceId = dto.ServiceId;
            await _context.SaveChangesAsync();
            return entity.Id;
        }
    }
}
