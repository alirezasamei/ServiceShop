﻿using App.Domain.Core.Expert.Contracts.Repositories;
using App.Domain.Core.Expert.Dtos;
using App.Infrastructure.SqlServer.Data;
using Microsoft.EntityFrameworkCore;

namespace App.Infrastructure.Repos.Ef.Expert
{
    public class ExpertServiceQueryRepository : IExpertServiceQueryRepository
    {
        private readonly AppDbContext _context;
        public ExpertServiceQueryRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<List<ExpertServiceDto>> GetAll() =>
             await _context.ExpertServices.Where(p => !p.IsDeleted).Select(p => new ExpertServiceDto()
             {
                 Id = p.Id,
                 CreationDate = p.CreationDate,
                 ExpertId = p.ExpertId,
                 IsActive = p.IsActive,
                 ServiceId = p.ServiceId,
                 Expert = p.Expert.appUser.Name,
                 Service = p.Service.Name,
             }).ToListAsync();

        public async Task<ExpertServiceDto?> Get(int id) =>
            await _context.ExpertServices.Where(p => p.Id == id && !p.IsDeleted).Select(p => new ExpertServiceDto()
            {
                Id = p.Id,
                CreationDate = p.CreationDate,
                ExpertId = p.ExpertId,
                IsActive = p.IsActive,
                ServiceId = p.ServiceId,
                Expert = p.Expert.appUser.Name,
                Service = p.Service.Name,
            }).FirstOrDefaultAsync();
    }
}
