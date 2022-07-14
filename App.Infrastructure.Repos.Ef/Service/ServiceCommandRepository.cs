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
                ImageName = dto.ImageName,
                IsActive = dto.IsActive,
                IsDeleted = dto.IsDeleted,
                Name = dto.Name,
                ParentSrviceId = dto.ParentSrviceId,
                Price = dto.Price,
            };
            await _context.Services.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity.Id;
        }

        public async Task<int> Delete(int id)
        {
            var entity = await _context.Services.FirstOrDefaultAsync(e => e.Id == id);
            _context.Services.Remove(entity);
            await _context.SaveChangesAsync();
            return entity.Id;
        }

        public async Task<int> Update(ServiceDto dto)
        {
            var entity = await _context.Services.FirstOrDefaultAsync(e => e.Id == dto.Id);
            entity.CreationDate = dto.CreationDate;
            entity.Description = dto.Description;
            entity.ImageName = dto.ImageName;
            entity.IsActive = dto.IsActive;
            entity.IsDeleted = dto.IsDeleted;
            entity.Name = dto.Name;
            entity.ParentSrviceId = dto.ParentSrviceId;
            entity.Price = dto.Price;
            await _context.SaveChangesAsync();
            return entity.Id;
        }
    }
}
