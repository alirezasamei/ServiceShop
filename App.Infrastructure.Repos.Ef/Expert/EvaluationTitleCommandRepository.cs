using App.Domain.Core.Expert.Contracts.Repositories;
using App.Infrastructure.SqlServer.Data;
using Microsoft.EntityFrameworkCore;
using App.Domain.Core.Expert.Entities;

namespace App.Infrastructure.Repos.Ef.Expert
{
    public class EvaluationTitleCommandRepository : IEvaluationTitleCommandRepository
    {
        private readonly AppDbContext _context;
        public EvaluationTitleCommandRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<int> Add(string name)
        {
            var entity = new EvaluationTitle()
            {
                Name = name,
            };
            await _context.EvaluationTitles.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity.Id;
        }

        public async Task<int> Delete(int id)
        {
            var entity = await _context.EvaluationTitles.FirstOrDefaultAsync(e => e.Id == id);
            _context.EvaluationTitles.Remove(entity);
            await _context.SaveChangesAsync();
            return entity.Id;
        }

        public async Task<int> Update(int id, string name)
        {
            var entity = await _context.EvaluationTitles.FirstOrDefaultAsync(e => e.Id == id);
            entity.Name = name;
            await _context.SaveChangesAsync();
            return entity.Id;
        }
    }
}
