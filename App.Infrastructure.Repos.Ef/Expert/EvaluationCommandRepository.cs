using App.Domain.Core.Expert.Contracts.Repositories;
using App.Domain.Core.Expert.Dtos;
using App.Infrastructure.SqlServer.Data;
using Microsoft.EntityFrameworkCore;
using App.Domain.Core.Expert.Entities;

namespace App.Infrastructure.Repos.Ef.Expert
{
    public class EvaluationCommandRepository : IEvaluationCommandRepository
    {
        private readonly AppDbContext _context;
        public EvaluationCommandRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<int> Add(EvaluationDto dto)
        {
            var entity = new Evaluation()
            {
                EvaluationTitleId = dto.EvaluationTitleId,
                ExpertServiceId = dto.ExpertServiceId,
                PastWorkId = dto.PastWorkId,
                Score = dto.Score,
            };
            await _context.Evaluations.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity.Id;
        }

        public async Task<int> Delete(int id)
        {
            var entity = await _context.Evaluations.FirstOrDefaultAsync(e => e.Id == id);
            _context.Evaluations.Remove(entity);
            await _context.SaveChangesAsync();
            return entity.Id;
        }

        public async Task<int> Update(EvaluationDto dto)
        {
            var entity = await _context.Evaluations.FirstOrDefaultAsync(e => e.Id == dto.Id);
            entity.EvaluationTitleId = dto.EvaluationTitleId;
            entity.ExpertServiceId = dto.ExpertServiceId;
            entity.PastWorkId = dto.PastWorkId;
            entity.Score = dto.Score;
            await _context.SaveChangesAsync();
            return entity.Id;
        }
    }
}
