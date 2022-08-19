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
        public async Task<List<FileDto>> GetAll(CancellationToken cancellationToken) =>
             await _context.Files.Where(p => !p.IsDeleted).Select(p => new FileDto()
             {
                 Id = p.Id,
                 CreationDate = p.CreationDate,
                 Description = p.Description,
                 ExpertService = p.ExpertService == null ? null : p.ExpertService.Expert.AppUser.Name + "/" + p.ExpertService.Service.Name,
                 ExpertServiceId = p.ExpertServiceId,
                 FileType = p.FileType.Name,
                 Extention = p.FileType.Extention,
                 FileTypeId = p.FileTypeId,
                 Name = p.Name,
                 Service = p.Service.Name,
                 ServiceId = p.ServiceId,
             }).ToListAsync(cancellationToken);

        public async Task<FileDto?> Get(string id, CancellationToken cancellationToken) =>
            await _context.Files.Where(p => p.Id.ToString() == id && !p.IsDeleted).Select(p => new FileDto()
            {
                Id = p.Id,
                CreationDate = p.CreationDate,
                Description = p.Description,
                ExpertService = p.ExpertService == null ? null : p.ExpertService.Expert.AppUser.Name + "/" + p.ExpertService.Service.Name,
                ExpertServiceId = p.ExpertServiceId,
                FileType = p.FileType.Name,
                Extention = p.FileType.Extention,
                FileTypeId = p.FileTypeId,
                Name = p.Name,
                Service = p.Service.Name,
                ServiceId = p.ServiceId,
            }).FirstOrDefaultAsync(cancellationToken);
    }
}
