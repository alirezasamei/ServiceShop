using App.Domain.Core.Expert.Contracts.Repositories;
using App.Domain.Core.Expert.Dtos;
using App.Infrastructure.SqlServer.Data;
using Microsoft.EntityFrameworkCore;

namespace App.Infrastructure.Repos.Ef.Expert
{
    public class ExpertQueryRepository : IExpertQueryRepository
    {
        private readonly AppDbContext _context;
        public ExpertQueryRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<List<ExpertDto>> GetAll() =>
             await _context.Experts.Select(p => new ExpertDto()
             {
                 Id = p.Id,
                 Address = p.Address,
                 Email = p.Email,
                 ImageName = p.ImageName,
                 IsActive = p.IsActive,
                 IsDeleted = p.IsDeleted,
                 Mobile = p.Mobile,
                 Name = p.Name,
                 SubmitDate = p.SubmitDate,
             }).ToListAsync();

        public async Task<ExpertDto?> Get(int id) =>
            await _context.Experts.Where(p => p.Id == id).Select(p => new ExpertDto()
            {
                Id = p.Id,
                Address = p.Address,
                Email = p.Email,
                ImageName = p.ImageName,
                IsActive = p.IsActive,
                IsDeleted = p.IsDeleted,
                Mobile = p.Mobile,
                Name = p.Name,
                SubmitDate = p.SubmitDate,
            }).FirstOrDefaultAsync();

        public async Task<ExpertDto?> Get(string name) =>
            await _context.Experts.Where(p => p.Name == name).Select(p => new ExpertDto()
            {
                Id = p.Id,
                Address = p.Address,
                Email = p.Email,
                ImageName = p.ImageName,
                IsActive = p.IsActive,
                IsDeleted = p.IsDeleted,
                Mobile = p.Mobile,
                Name = p.Name,
                SubmitDate = p.SubmitDate,
            }).FirstOrDefaultAsync();
    }
}
