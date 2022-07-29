using App.Domain.Core.BaseData.Contracts.Repositories;
using App.Domain.Core.BaseData.Dtos;
using App.Infrastructure.SqlServer.Data;
using Microsoft.EntityFrameworkCore;

namespace App.Infrastructure.Repos.Ef.BaseData
{
    public class FileQueryRepository : IFileQueryRepository
    {
        private readonly AppDbContext _context;
        public FileQueryRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<List<FileDto>> GetAll() =>
             await _context.Files.Where(p => !p.IsDeleted).Select(p => new FileDto()
             {
                 Id = p.Id,
                 CreationDate = p.CreationDate,
                 Description = p.Description,
                 ExpertServiceId = p.ExpertServiceId,
                 FileType = p.FileType.Name,
                 FileTypeId = p.FileTypeId,
                 NameWithExtention = p.NameWithExtention,
                 Service = p.Service.Name,
                 ServiceId = p.ServiceId,
             }).ToListAsync();

        public async Task<FileDto?> Get(int id) =>
            await _context.Files.Where(p => p.Id == id && !p.IsDeleted).Select(p => new FileDto()
            {
                Id = p.Id,
                CreationDate = p.CreationDate,
                Description = p.Description,
                ExpertServiceId = p.ExpertServiceId,
                FileType = p.FileType.Name,
                FileTypeId = p.FileTypeId,
                NameWithExtention = p.NameWithExtention,
                Service = p.Service.Name,
                ServiceId = p.ServiceId,
            }).FirstOrDefaultAsync();

        public async Task<FileDto?> Get(string name) =>
            await _context.Files.Where(p => p.NameWithExtention == name && !p.IsDeleted).Select(p => new FileDto()
            {
                Id = p.Id,
                CreationDate = p.CreationDate,
                Description = p.Description,
                ExpertServiceId = p.ExpertServiceId,
                FileType = p.FileType.Name,
                FileTypeId = p.FileTypeId,
                NameWithExtention = p.NameWithExtention,
                Service = p.Service.Name,
                ServiceId = p.ServiceId,
            }).FirstOrDefaultAsync();
    }
}
