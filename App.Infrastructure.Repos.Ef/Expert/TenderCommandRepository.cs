using App.Domain.Core.Expert.Contracts.Repositories;
using App.Domain.Core.Expert.Dtos;
using App.Infrastructure.SqlServer.Data;
using Microsoft.EntityFrameworkCore;
using App.Domain.Core.Expert.Entities;

namespace App.Infrastructure.Repos.Ef.Expert
{
    public class TenderCommandRepository : ITenderCommandRepository
    {
        private readonly AppDbContext _context;
        public TenderCommandRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<int> Add(TenderDto dto)
        {
            var entity = new Tender()
            {
                ExpertId = dto.ExpertId,
                OrderId = dto.OrderId,
                Price = dto.Price,
                RegisterDate = dto.RegisterDate,
                RequiredTime = dto.RequiredTime,
                StartDate = dto.StartDate,
            };
            await _context.Tenders.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity.Id;
        }

        public async Task<int> Delete(int id)
        {
            var entity = await _context.Tenders.FirstOrDefaultAsync(e => e.Id == id);
            _context.Tenders.Remove(entity);
            await _context.SaveChangesAsync();
            return entity.Id;
        }

        public async Task<int> Update(TenderDto dto)
        {
            var entity = await _context.Tenders.FirstOrDefaultAsync(e => e.Id == dto.Id);
            entity.ExpertId = dto.ExpertId;
            entity.OrderId = dto.OrderId;
            entity.Price = dto.Price;
            entity.RegisterDate = dto.RegisterDate;
            entity.RequiredTime = dto.RequiredTime;
            entity.StartDate = dto.StartDate;
            await _context.SaveChangesAsync();
            return entity.Id;
        }
    }
}
