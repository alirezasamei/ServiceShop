using App.Domain.Core.Operator.Contracts.Repositories;
using App.Domain.Core.Operator.Dtos;
using OperatorEntities = App.Domain.Core.Operator.Entities;
using App.Infrastructure.SqlServer.Data;
using Microsoft.EntityFrameworkCore;

namespace App.Infrastructure.Repos.Ef.Operator
{
    public class OperatorCommandRepository : IOperatorCommandRepository
    {
        private readonly AppDbContext _context;
        public OperatorCommandRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<int> Add(OperatorDto dto)
        {
            var entity = new OperatorEntities.Operator()
            {
                Email = dto.Email,
                IsActive= dto.IsActive,
                IsDeleted= dto.IsDeleted,
                Mobile= dto.Mobile,
                Name= dto.Name,
                SubmitDate= dto.SubmitDate,
            };
            await _context.Operators.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity.Id;
        }

        public async Task<int> Delete(int id)
        {
            var entity = await _context.Operators.FirstOrDefaultAsync(e => e.Id == id);
            _context.Operators.Remove(entity);
            await _context.SaveChangesAsync();
            return entity.Id;
        }

        public async Task<int> Update(OperatorDto dto)
        {
            var entity = await _context.Operators.FirstOrDefaultAsync(e => e.Id == dto.Id);
            entity.Email = dto.Email;
            entity.IsActive = dto.IsActive;
            entity.IsDeleted = dto.IsDeleted;
            entity.Mobile = dto.Mobile;
            entity.Name = dto.Name;
            entity.SubmitDate = dto.SubmitDate;
            await _context.SaveChangesAsync();
            return entity.Id;
        }
    }
}
