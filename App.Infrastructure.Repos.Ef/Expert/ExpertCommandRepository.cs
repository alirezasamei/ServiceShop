using App.Domain.Core.Expert.Contracts.Repositories;
using App.Domain.Core.Expert.Dtos;
using ExpertEntities = App.Domain.Core.Expert.Entities;
using App.Infrastructure.SqlServer.Data;
using Microsoft.EntityFrameworkCore;

namespace App.Infrastructure.Repos.Ef.Expert
{
    public class ExpertCommandRepository : IExpertCommandRepository
    {
        private readonly AppDbContext _context;
        public ExpertCommandRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<int> Add(ExpertDto dto, CancellationToken cancellationToken)
        {
            var entity = new ExpertEntities.Expert()
            {
                AppUserId = dto.AppUserId,
                Address = dto.Address,
                ImageFileId = dto.ImageFileId,
            };
            await _context.Experts.AddAsync(entity);
            await _context.SaveChangesAsync(cancellationToken);
            return entity.Id;
        }

        public async Task<int> Update(ExpertDto dto, CancellationToken cancellationToken)
        {
            var entity = await _context.Experts.FirstOrDefaultAsync(e => e.Id == dto.Id || e.AppUserId == dto.AppUserId);
            entity.AppUserId = dto.AppUserId;
            entity.Address = dto.Address;
            entity.ImageFileId = dto.ImageFileId;
            await _context.SaveChangesAsync(cancellationToken);
            return entity.Id;
        }
    }
}
