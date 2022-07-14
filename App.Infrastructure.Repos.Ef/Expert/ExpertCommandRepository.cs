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
        public async Task<int> Add(ExpertDto dto)
        {
            var entity = new ExpertEntities.Expert()
            {
                Address = dto.Address,
                Email = dto.Email,
                ImageName = dto.ImageName,
                IsActive = dto.IsActive,
                IsDeleted = dto.IsDeleted,
                Mobile = dto.Mobile,
                Name = dto.Name,
                SubmitDate = dto.SubmitDate,
            };
            await _context.Experts.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity.Id;
        }

        public async Task<int> Delete(int id)
        {
            var entity = await _context.Experts.FirstOrDefaultAsync(e => e.Id == id);
            _context.Experts.Remove(entity);
            await _context.SaveChangesAsync();
            return entity.Id;
        }

        public async Task<int> Update(ExpertDto dto)
        {
            var entity = await _context.Experts.FirstOrDefaultAsync(e => e.Id == dto.Id);
            entity.Address = dto.Address;
            entity.Email = dto.Email;
            entity.ImageName = dto.ImageName;
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
