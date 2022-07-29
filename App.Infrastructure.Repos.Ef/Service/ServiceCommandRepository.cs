using App.Domain.Core.Service.Contracts.Repositories;
using App.Domain.Core.Service.Dtos;
using App.Infrastructure.SqlServer.Data;
using Microsoft.EntityFrameworkCore;
using ServiceEntities = App.Domain.Core.Service.Entities;

namespace App.Infrastructure.Repos.Ef.Service
{
    public class ServiceCommandRepository : IServiceCommandRepository
    {
        private readonly AppDbContext _context;
        public ServiceCommandRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<int> Add(ServiceDto dto)
        {
            var entity = new ServiceEntities.Service()
            {
                CreationDate = dto.CreationDate,
                Description = dto.Description,
                ImageFileId = dto.ImageFileId,
                IsActive = dto.IsActive,
                IsDeleted = false,
                Name = dto.Name,
                ParentServiceId = dto.ParentServiceId,
                Price = dto.Price,
            };
            await _context.Services.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity.Id;
        }

        public async Task<int> Delete(int id)
        {
            var entity = await _context.Services.FirstOrDefaultAsync(e => e.Id == id);
            entity.IsDeleted = false;
            await _context.SaveChangesAsync();
            return entity.Id;
        }

        public async Task<int> Update(ServiceDto dto)
        {
            var entity = await _context.Services.FirstOrDefaultAsync(e => e.Id == dto.Id);
            entity.CreationDate = dto.CreationDate;
            entity.Description = dto.Description;
            entity.ImageFileId = dto.ImageFileId;
            entity.IsActive = dto.IsActive;
            entity.Name = dto.Name;
            entity.ParentServiceId = dto.ParentServiceId;
            entity.Price = dto.Price;
            await _context.SaveChangesAsync();
            return entity.Id;
        }
    }
}
