using App.Domain.Core.User.Contracts.Repositories;
using App.Domain.Core.User.Dtos;
using App.Infrastructure.SqlServer.Data;
using Microsoft.EntityFrameworkCore;
using UserEntities = App.Domain.Core.User.Entities;

namespace App.Infrastructure.Repos.Ef.User
{
    public class UserCommandRepository : IUserCommandRepository
    {
        private readonly AppDbContext _context;
        public UserCommandRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<int> Add(UserDto dto)
        {
            var entity = new UserEntities.User()
            {
                Address = dto.Address,
                Email = dto.Email,
                IsActive= dto.IsActive,
                IsDeleted= dto.IsDeleted,
                Mobile= dto.Mobile,
                Name= dto.Name,
                SubmitDate= dto.SubmitDate,
            };
            await _context.Users.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity.Id;
        }

        public async Task<int> Delete(int id)
        {
            var entity = await _context.Users.FirstOrDefaultAsync(e => e.Id == id);
            _context.Users.Remove(entity);
            await _context.SaveChangesAsync();
            return entity.Id;
        }

        public async Task<int> Update(UserDto dto)
        {
            var entity = await _context.Users.FirstOrDefaultAsync(e => e.Id == dto.Id);
            entity.Address = dto.Address;
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
