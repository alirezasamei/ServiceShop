using App.Domain.Core.BaseData.Contracts.Repositories;
using App.Domain.Core.BaseData.Dtos;
using App.Infrastructure.SqlServer.Data;
using Microsoft.EntityFrameworkCore;

namespace App.Infrastructure.Repos.Ef.BaseData
{
    public class FileTypeQueryRepository : IFileTypeQueryRepository
    {
        private readonly AppDbContext _context;
        public FileTypeQueryRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<List<FileTypeDto>> GetAll(CancellationToken cancellationToken) =>
             await _context.FileTypes.Where(p => !p.IsDeleted).Select(p => new FileTypeDto()
             {
                 Id = p.Id,
                 Name = p.Name,
                 Extention = p.Extention,
             }).ToListAsync(cancellationToken);

        public async Task<FileTypeDto?> Get(int id, CancellationToken cancellationToken) =>
            await _context.FileTypes.Where(p => p.Id == id && !p.IsDeleted).Select(p => new FileTypeDto()
            {
                Id = p.Id,
                Name = p.Name,
                Extention = p.Extention,
            }).FirstOrDefaultAsync(cancellationToken);

        public async Task<FileTypeDto?> Get(string name, CancellationToken cancellationToken) =>
            await _context.FileTypes.Where(p => p.Name == name && !p.IsDeleted).Select(p => new FileTypeDto()
            {
                Id = p.Id,
                Name = p.Name,
                Extention = p.Extention,
            }).FirstOrDefaultAsync(cancellationToken);
    }
}
