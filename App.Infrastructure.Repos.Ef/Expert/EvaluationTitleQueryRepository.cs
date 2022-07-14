using App.Domain.Core.Expert.Contracts.Repositories;
using App.Domain.Core.Expert.Dtos;
using App.Infrastructure.SqlServer.Data;
using Microsoft.EntityFrameworkCore;

namespace App.Infrastructure.Repos.Ef.Expert
{
    public class EvaluationTitleQueryRepository : IEvaluationTitleQueryRepository
    {
        private readonly AppDbContext _context;
        public EvaluationTitleQueryRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<List<EvaluationTitleDto>> GetAll() =>
             await _context.EvaluationTitles.Select(p => new EvaluationTitleDto()
             {
                 Id = p.Id,
                 Name = p.Name,
             }).ToListAsync();

        public async Task<EvaluationTitleDto?> Get(int id) =>
            await _context.EvaluationTitles.Where(p => p.Id == id).Select(p => new EvaluationTitleDto()
            {
                Id = p.Id,
                Name = p.Name,
            }).FirstOrDefaultAsync();

        public async Task<EvaluationTitleDto?> Get(string name) =>
            await _context.EvaluationTitles.Where(p => p.Name == name).Select(p => new EvaluationTitleDto()
            {
                Id = p.Id,
                Name = p.Name,
            }).FirstOrDefaultAsync();
    }
}
