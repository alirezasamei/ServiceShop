using App.Domain.Core.Service.Contracts.Repositories;
using App.Domain.Core.Service.Dtos;
using App.Domain.Core.Service.Entities;
using App.Infrastructure.SqlServer.Data;
using Microsoft.EntityFrameworkCore;

namespace App.Infrastructure.Repos.Ef.Service
{
    public class ServiceFileCommandRepository : IServiceFileCommandRepository
    {
        private readonly AppDbContext _context;
        public ServiceFileCommandRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<int> Add(ServiceFileDto dto)
        {
            var entity = new ServiceFile()
            {
                CreationDate = dto.CreationDate,
                Description = dto.Description,
                FileTypeId = dto.FileTypeId,
                IsDeleted = dto.IsDeleted,
                NameWithExtention = dto.NameWithExtention,
                ServiceId = dto.ServiceId,
            };
            await _context.ServiceFiles.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity.Id;
        }

        public async Task<int> Delete(int id)
        {
            var entity = await _context.ServiceFiles.FirstOrDefaultAsync(e => e.Id == id);
            _context.ServiceFiles.Remove(entity);
            await _context.SaveChangesAsync();
            return entity.Id;
        }

        public async Task<int> Update(ServiceFileDto dto)
        {
            var entity = await _context.ServiceFiles.FirstOrDefaultAsync(e => e.Id == dto.Id);
            entity.CreationDate = dto.CreationDate;
            entity.Description = dto.Description;
            entity.FileTypeId = dto.FileTypeId;
            entity.IsDeleted = dto.IsDeleted;
            entity.NameWithExtention = dto.NameWithExtention;
            entity.ServiceId = dto.ServiceId;
            await _context.SaveChangesAsync();
            return entity.Id;
        }
    }
}
