using App.Domain.Core.Expert.Contracts.Repositories;
using App.Domain.Core.Expert.Dtos;
using App.Infrastructure.SqlServer.Data;
using Microsoft.EntityFrameworkCore;
using App.Domain.Core.Expert.Entities;
using AutoMapper;

namespace App.Infrastructure.Repos.Ef.Expert
{
    public class TenderCommandRepository : ITenderCommandRepository
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public TenderCommandRepository(AppDbContext context,
            IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<int> Add(TenderDto dto, CancellationToken cancellationToken)
        {
            var entity = new Tender()
            {
                ExpertId = dto.ExpertId,
                OrderId = dto.OrderId,
                Price = dto.Price,
                Accepted = false,
                RegisterDate = dto.RegisterDate,
                RequiredTime = dto.RequiredTime,
                StartDate = dto.StartDate,
            };
            await _context.Tenders.AddAsync(entity);
            await _context.SaveChangesAsync(cancellationToken);
            return entity.Id;
        }

        public async Task<int> Delete(int id, CancellationToken cancellationToken)
        {
            var entity = await _context.Tenders.FirstOrDefaultAsync(e => e.Id == id);
            _context.Tenders.Remove(entity);
            await _context.SaveChangesAsync(cancellationToken);
            return entity.Id;
        }

        public async Task<int> Update(TenderDto dto, CancellationToken cancellationToken)
        {
            var entity = await _context.Tenders.FirstOrDefaultAsync(e => e.Id == dto.Id);
            entity.ExpertId = dto.ExpertId;
            entity.OrderId = dto.OrderId;
            entity.Price = dto.Price;
            entity.RegisterDate = dto.RegisterDate;
            entity.RequiredTime = dto.RequiredTime;
            entity.StartDate = dto.StartDate;
            await _context.SaveChangesAsync(cancellationToken);
            return entity.Id;
        }

        public async Task<TenderDto> Accept(int id, CancellationToken cancellationToken)
        {
            var entity = await _context.Tenders.FirstOrDefaultAsync(e => e.Id == id);
            entity.Accepted = true;
            await _context.SaveChangesAsync(cancellationToken);
            return _mapper.Map<TenderDto>(entity);
        }

        public async Task<TenderDto> Cancel(int id, CancellationToken cancellationToken)
        {
            var entity = await _context.Tenders.FirstOrDefaultAsync(e => e.Id == id);
            entity.Accepted = false;
            await _context.SaveChangesAsync(cancellationToken);
            return _mapper.Map<TenderDto>(entity);
        }
    }
}
