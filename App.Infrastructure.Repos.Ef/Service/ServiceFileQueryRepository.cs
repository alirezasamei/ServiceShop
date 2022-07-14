using App.Domain.Core.Service.Contracts.Repositories;
using App.Domain.Core.Service.Dtos;
using App.Infrastructure.SqlServer.Data;
using Microsoft.EntityFrameworkCore;

namespace App.Infrastructure.Repos.Ef.Service
{
    public class ServiceFileQueryRepository : IServiceFileQueryRepository
    {
        private readonly AppDbContext _context;
        public ServiceFileQueryRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<List<ServiceFileDto>> GetAll() =>
             await _context.ServiceFiles.Select(p => new ServiceFileDto()
             {
                 Id = p.Id,
                 CreationDate = p.CreationDate,
                 Description = p.Description,
                 FileType = p.FileType.Name,
                 FileTypeId = p.FileTypeId,
                 IsDeleted = p.IsDeleted,
                 NameWithExtention = p.NameWithExtention,
                 Service = p.Service.Name,
                 ServiceId = p.ServiceId,
             }).ToListAsync();

        public async Task<ServiceFileDto?> Get(int id) =>
            await _context.ServiceFiles.Where(p => p.Id == id).Select(p => new ServiceFileDto()
            {
                Id = p.Id,
                CreationDate = p.CreationDate,
                Description = p.Description,
                FileType = p.FileType.Name,
                FileTypeId = p.FileTypeId,
                IsDeleted = p.IsDeleted,
                NameWithExtention = p.NameWithExtention,
                Service = p.Service.Name,
                ServiceId = p.ServiceId,
            }).FirstOrDefaultAsync();

        public async Task<ServiceFileDto?> Get(string name) =>
            await _context.ServiceFiles.Where(p => p.NameWithExtention == name).Select(p => new ServiceFileDto()
            {
                Id = p.Id,
                CreationDate = p.CreationDate,
                Description = p.Description,
                FileType = p.FileType.Name,
                FileTypeId = p.FileTypeId,
                IsDeleted = p.IsDeleted,
                NameWithExtention = p.NameWithExtention,
                Service = p.Service.Name,
                ServiceId = p.ServiceId,
            }).FirstOrDefaultAsync();
    }
}
