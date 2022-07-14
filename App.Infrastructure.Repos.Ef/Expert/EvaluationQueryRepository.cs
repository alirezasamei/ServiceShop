using App.Domain.Core.Expert.Contracts.Repositories;
using App.Domain.Core.Expert.Dtos;
using App.Infrastructure.SqlServer.Data;
using Microsoft.EntityFrameworkCore;

namespace App.Infrastructure.Repos.Ef.Expert
{
    public class EvaluationQueryRepository : IEvaluationQueryRepository
    {
        private readonly AppDbContext _context;
        public EvaluationQueryRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<List<EvaluationDto>> GetAll() =>
             await _context.Evaluations.Select(p => new EvaluationDto()
             {
                 Id = p.Id,
                 EvaluationTitle = p.EvaluationTitle.Name,
                 EvaluationTitleId = p.EvaluationTitleId,
                 ExpertServiceId = p.ExpertServiceId,
                 PastWorkId = p.PastWorkId,
                 Score=p.Score,
             }).ToListAsync();

        public async Task<EvaluationDto?> Get(int id) =>
            await _context.Evaluations.Where(p => p.Id == id).Select(p => new EvaluationDto()
            {
                Id = p.Id,
                EvaluationTitle = p.EvaluationTitle.Name,
                EvaluationTitleId = p.EvaluationTitleId,
                ExpertServiceId = p.ExpertServiceId,
                PastWorkId = p.PastWorkId,
                Score = p.Score,
            }).FirstOrDefaultAsync();
    }
}
