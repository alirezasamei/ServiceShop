using App.Domain.Core.Expert.Contracts.Repositories;
using App.Domain.Core.Expert.Dtos;
using App.Infrastructure.SqlServer.Data;
using Microsoft.EntityFrameworkCore;

namespace App.Infrastructure.Repos.Ef.Expert
{
    public class ExpertQueryRepository : IExpertQueryRepository
    {
        private readonly AppDbContext _context;
        public ExpertQueryRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<List<ExpertDto>> GetAll(CancellationToken cancellationToken) =>
             await _context.Experts.Select(p => new ExpertDto()
             {
                 Id = p.Id,
                 AppUserId = p.AppUserId,
                 Address = p.Address,
                 ImageFileId = p.ImageFileId,
                 ImageFileName = Path.ChangeExtension(p.ImageFile.Name, p.ImageFile.FileType.Extention),
             }).ToListAsync(cancellationToken);

        public async Task<ExpertDto?> Get(int appUserId, CancellationToken cancellationToken) =>
            await _context.Experts.Where(p => p.AppUser.Id == appUserId && !p.AppUser.IsDeleted).Select(p => new ExpertDto()
            {
                Id = p.Id,
                AppUserId = p.AppUserId,
                Address = p.Address,
                ImageFileId = p.ImageFileId,
                ImageFileName = Path.ChangeExtension(p.ImageFile.Name, p.ImageFile.FileType.Extention),
            }).FirstOrDefaultAsync(cancellationToken);

        public async Task<bool> DoseExists(int appUserId, CancellationToken cancellationToken) =>
            await _context.Experts.AnyAsync(p => p.AppUser.Id == appUserId && !p.AppUser.IsDeleted, cancellationToken);
    }
}
