using App.Domain.Core.Expert.Contracts.Repositories;
using App.Domain.Core.Expert.Dtos;
using App.Infrastructure.SqlServer.Data;
using Microsoft.EntityFrameworkCore;

namespace App.Infrastructure.Repos.Ef.Expert
{
    public class ExpertServiceFileQueryRepository : IExpertServiceFileQueryRepository
    {
        private readonly AppDbContext _context;
        public ExpertServiceFileQueryRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<List<ExpertServiceFileDto>> GetAll() =>
             await _context.ExpertServiceFiles.Select(p => new ExpertServiceFileDto()
             {
                 Id = p.Id,
                 CreationDate = p.CreationDate,
                 Description = p.Description,
                 ExpertServiceId = p.ExpertServiceId,
                 FileType = p.FileType.Name,
                 FileTypeId = p.FileTypeId,
                 IsDeleted = p.IsDeleted,
                 NameWithExtention = p.NameWithExtention,
             }).ToListAsync();

        public async Task<ExpertServiceFileDto?> Get(int id) =>
            await _context.ExpertServiceFiles.Where(p => p.Id == id).Select(p => new ExpertServiceFileDto()
            {
                Id = p.Id,
                CreationDate = p.CreationDate,
                Description = p.Description,
                ExpertServiceId = p.ExpertServiceId,
                FileType = p.FileType.Name,
                FileTypeId = p.FileTypeId,
                IsDeleted = p.IsDeleted,
                NameWithExtention = p.NameWithExtention,
            }).FirstOrDefaultAsync();

        public async Task<ExpertServiceFileDto?> Get(string name) =>
            await _context.ExpertServiceFiles.Where(p => p.NameWithExtention == name).Select(p => new ExpertServiceFileDto()
            {
                Id = p.Id,
                CreationDate = p.CreationDate,
                Description = p.Description,
                ExpertServiceId = p.ExpertServiceId,
                FileType = p.FileType.Name,
                FileTypeId = p.FileTypeId,
                IsDeleted = p.IsDeleted,
                NameWithExtention = p.NameWithExtention,
            }).FirstOrDefaultAsync();
    }
}
