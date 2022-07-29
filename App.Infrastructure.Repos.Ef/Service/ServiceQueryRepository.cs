using App.Domain.Core.Service.Contracts.Repositories;
using App.Domain.Core.Service.Dtos;
using App.Infrastructure.SqlServer.Data;
using Microsoft.EntityFrameworkCore;

namespace App.Infrastructure.Repos.Ef.Service
{
    public class ServiceQueryRepository : IServiceQueryRepository
    {
        private readonly AppDbContext _context;
        public ServiceQueryRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<List<ServiceDto>> GetAll() =>
             await _context.Services.Where(p => !p.IsDeleted).Select(p => new ServiceDto()
             {
                 Id = p.Id,
                 CreationDate = DateTime.Now,
                 Description = p.Description,
                 ImageFileId = p.ImageFileId,
                 ImageFileName = p.ImageFile.NameWithExtention,
                 IsActive = p.IsActive,
                 Name = p.Name,
                 ParentService = p.ParentService.Name,
                 ParentServiceId = p.ParentServiceId,
                 Price = p.Price,
             }).ToListAsync();

        public async Task<ServiceDto?> Get(int id) =>
            await _context.Services.Where(p => p.Id == id & !p.IsDeleted).Select(p => new ServiceDto()
            {
                Id = p.Id,
                CreationDate = DateTime.Now,
                Description = p.Description,
                ImageFileId = p.ImageFileId,
                ImageFileName = p.ImageFile.NameWithExtention,
                IsActive = p.IsActive,
                Name = p.Name,
                ParentService = p.ParentService.Name,
                ParentServiceId = p.ParentServiceId,
                Price = p.Price,
            }).FirstOrDefaultAsync();

        public async Task<ServiceDto?> Get(string name) =>
            await _context.Services.Where(p => p.Name == name & !p.IsDeleted).Select(p => new ServiceDto()
            {
                Id = p.Id,
                CreationDate = DateTime.Now,
                Description = p.Description,
                ImageFileId = p.ImageFileId,
                ImageFileName = p.ImageFile.NameWithExtention,
                IsActive = p.IsActive,
                Name = p.Name,
                ParentService = p.ParentService.Name,
                ParentServiceId = p.ParentServiceId,
                Price = p.Price,
            }).FirstOrDefaultAsync();
    }
}
