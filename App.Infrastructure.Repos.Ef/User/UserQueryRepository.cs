using App.Domain.Core.User.Contracts.Repositories;
using App.Domain.Core.User.Dtos;
using App.Infrastructure.SqlServer.Data;
using Microsoft.EntityFrameworkCore;

namespace App.Infrastructure.Repos.Ef.User
{
    public class UserQueryRepository : IUserQueryRepository
    {
        private readonly AppDbContext _context;
        public UserQueryRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<List<UserDto>> GetAll() =>
             await _context.Users.Select(p => new UserDto()
             {
                 Id = p.Id,
                 Address = p.Address,
                 Email = p.Email,
                 IsActive = p.IsActive,
                 IsDeleted = p.IsDeleted,
                 Mobile = p.Mobile,
                 Name = p.Name,
                 SubmitDate = p.SubmitDate,
             }).ToListAsync();

        public async Task<UserDto?> Get(int id) =>
            await _context.Users.Where(p => p.Id == id).Select(p => new UserDto()
            {
                Id = p.Id,
                Address = p.Address,
                Email = p.Email,
                IsActive = p.IsActive,
                IsDeleted = p.IsDeleted,
                Mobile = p.Mobile,
                Name = p.Name,
                SubmitDate = p.SubmitDate,
            }).FirstOrDefaultAsync();

        public async Task<UserDto?> Get(string name) =>
            await _context.Users.Where(p => p.Name == name).Select(p => new UserDto()
            {
                Id = p.Id,
                Address = p.Address,
                Email = p.Email,
                IsActive = p.IsActive,
                IsDeleted = p.IsDeleted,
                Mobile = p.Mobile,
                Name = p.Name,
                SubmitDate = p.SubmitDate,
            }).FirstOrDefaultAsync();
    }
}
