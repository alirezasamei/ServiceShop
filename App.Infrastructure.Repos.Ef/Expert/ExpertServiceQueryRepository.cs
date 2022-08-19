using App.Domain.Core.Expert.Contracts.Repositories;
using App.Domain.Core.Expert.Dtos;
using App.Infrastructure.SqlServer.Data;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace App.Infrastructure.Repos.Ef.Expert
{
    public class ExpertServiceQueryRepository : IExpertServiceQueryRepository
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public ExpertServiceQueryRepository(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<List<ExpertServiceDto>> GetAll(CancellationToken cancellationToken) =>
             await _context.ExpertServices.Where(p => !p.IsDeleted).Select(p => new ExpertServiceDto()
             {
                 Id = p.Id,
                 CreationDate = p.CreationDate,
                 ExpertId = p.ExpertId,
                 IsActive = p.IsActive,
                 ServiceId = p.ServiceId,
                 Expert = p.Expert.AppUser.Name,
                 Service = p.Service.Name,
             }).ToListAsync(cancellationToken);

        public async Task<ExpertServiceDto?> Get(int id, CancellationToken cancellationToken) =>
            await _context.ExpertServices.Where(p => p.Id == id && !p.IsDeleted).Select(p => new ExpertServiceDto()
            {
                Id = p.Id,
                CreationDate = p.CreationDate,
                ExpertId = p.ExpertId,
                IsActive = p.IsActive,
                ServiceId = p.ServiceId,
                Expert = p.Expert.AppUser.Name,
                Service = p.Service.Name,
            }).FirstOrDefaultAsync(cancellationToken);

        public async Task<List<ExpertServiceDto>> GetByExpertId(int id, CancellationToken cancellationToken) =>
             await _context.ExpertServices.Where(p => p.ExpertId == id && !p.IsDeleted).Select(p => new ExpertServiceDto()
             {
                 Id = p.Id,
                 CreationDate = p.CreationDate,
                 ExpertId = p.ExpertId,
                 IsActive = p.IsActive,
                 ServiceId = p.ServiceId,
                 Expert = p.Expert.AppUser.Name,
                 Service = p.Service.Name,
             }).ToListAsync(cancellationToken);
    }
}
