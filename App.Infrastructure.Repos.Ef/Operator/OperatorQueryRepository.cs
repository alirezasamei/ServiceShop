using App.Domain.Core.Operator.Contracts.Repositories;
using App.Domain.Core.Operator.Dtos;
using App.Infrastructure.SqlServer.Data;
using Microsoft.EntityFrameworkCore;

namespace App.Infrastructure.Repos.Ef.Operator
{
    public class OperatorQueryRepository : IOperatorQueryRepository
    {
        private readonly AppDbContext _context;
        public OperatorQueryRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<List<OperatorDto>> GetAll() =>
             await _context.Operators.Select(p => new OperatorDto()
             {
                 Id = p.Id,
                 Email = p.Email,
                 IsActive = p.IsActive,
                 IsDeleted = p.IsDeleted,
                 Mobile = p.Mobile,
                 Name = p.Name,
                 SubmitDate = p.SubmitDate,
             }).ToListAsync();

        public async Task<OperatorDto?> Get(int id) =>
            await _context.Operators.Where(p => p.Id == id).Select(p => new OperatorDto()
            {
                Id = p.Id,
                Email = p.Email,
                IsActive = p.IsActive,
                IsDeleted = p.IsDeleted,
                Mobile = p.Mobile,
                Name = p.Name,
                SubmitDate = p.SubmitDate,
            }).FirstOrDefaultAsync();

        public async Task<OperatorDto?> Get(string name) =>
            await _context.Operators.Where(p => p.Name == name).Select(p => new OperatorDto()
            {
                Id = p.Id,
                Email = p.Email,
                IsActive = p.IsActive,
                IsDeleted = p.IsDeleted,
                Mobile = p.Mobile,
                Name = p.Name,
                SubmitDate = p.SubmitDate,
            }).FirstOrDefaultAsync();
    }
}
