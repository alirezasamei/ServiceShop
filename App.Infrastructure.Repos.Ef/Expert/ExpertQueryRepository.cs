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
        public async Task<List<ExpertDto>> GetAll() =>
             await _context.Experts.Select(p => new ExpertDto()
             {
                 Id = p.Id,
                 AppUserId = p.AppUserId,
                 Address = p.Address,
                 ImageFileId = p.ImageFileId,
                 ImageFileName = p.ImageFile.NameWithExtention,
             }).ToListAsync();

        public async Task<ExpertDto?> Get(int appUserId) =>
            await _context.Experts.Where(p => p.appUser.Id == appUserId).Select(p => new ExpertDto()
            {
                Id = p.Id,
                AppUserId = p.AppUserId,
                Address = p.Address,
                ImageFileId = p.ImageFileId,
                ImageFileName = p.ImageFile.NameWithExtention,
            }).FirstOrDefaultAsync();
    }
}
