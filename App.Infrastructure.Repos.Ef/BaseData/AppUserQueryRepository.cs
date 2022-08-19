using App.Domain.Core.BaseData.Contracts.Repositories;
using App.Domain.Core.BaseData.Dtos;
using App.Domain.Core.BaseData.Entities;
using App.Domain.Core.BaseData.Enums;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace App.Infrastructure.Repos.Ef.BaseData
{
    public class AppUserQueryRepository : IAppUserQueryRepository
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly ILogger<AppUserQueryRepository> _logger;

        public AppUserQueryRepository(UserManager<AppUser> userManager,
            ILogger<AppUserQueryRepository> logger)
        {
            _userManager = userManager;
            _logger = logger;
        }
        public async Task<List<AppUserDto>> GetAll()
        {
            _logger.LogTrace("Start method {methodName}", nameof(GetAll));
            var users = await _userManager.Users.ToListAsync();
            var dtos = users.Where(p => !p.IsDeleted).Select(p => new AppUserDto()
            {
                Id = p.Id,
                Email = p.Email,
                EmailConfirmed = p.EmailConfirmed,
                IsActive = p.IsActive,
                Name = p.Name,
                PhoneNumber = p.PhoneNumber,
                PhoneNumberConfirmed = p.PhoneNumberConfirmed,
                SubmitDate = p.SubmitDate,
                UserName = p.UserName,
            }).ToList();
            if (dtos.Any())
            {
                _logger.LogDebug("user dtos count is {userDtosCount}", dtos.Count());
            }
            else
            {
                _logger.LogWarning("method {methodName} of repository returns nothing!", nameof(GetAll));
            }
            dtos.ForEach(d =>
            {
                var user = users.FirstOrDefault(u => u.Id == d.Id);
                d.Roles = _userManager.GetRolesAsync(user).Result.Select(r => (RoleEnum)Enum.Parse(typeof(RoleEnum), r, true)).ToList();
            });
            _logger.LogTrace("Start method {methodName}", nameof(GetAll));
            return dtos;
        }

        public async Task<AppUserDto?> Get(int id, CancellationToken cancellationToken)
        {
            var user = await _userManager.Users.Where(p => p.Id == id && !p.IsDeleted).FirstOrDefaultAsync();
            var dto = new AppUserDto()
            {
                Id = user.Id,
                Email = user.Email,
                EmailConfirmed = user.EmailConfirmed,
                IsActive = user.IsActive,
                Name = user.Name,
                PhoneNumber = user.PhoneNumber,
                PhoneNumberConfirmed = user.PhoneNumberConfirmed,
                SubmitDate = user.SubmitDate,
                UserName = user.UserName,
            };
            dto.Roles = (await _userManager.GetRolesAsync(user)).Select(r => (RoleEnum)Enum.Parse(typeof(RoleEnum), r, true)).ToList();
            return dto;
        }

        public async Task<AppUserDto?> Get(string userName, CancellationToken cancellationToken)
        {
            var user = await _userManager.Users.Where(p => p.UserName == userName && !p.IsDeleted).FirstOrDefaultAsync();
            var dto = new AppUserDto()
            {
                Id = user.Id,
                Email = user.Email,
                EmailConfirmed = user.EmailConfirmed,
                IsActive = user.IsActive,
                Name = user.Name,
                PhoneNumber = user.PhoneNumber,
                PhoneNumberConfirmed = user.PhoneNumberConfirmed,
                SubmitDate = user.SubmitDate,
                UserName = user.UserName,
            };
            dto.Roles = (await _userManager.GetRolesAsync(user)).Select(r => (RoleEnum)Enum.Parse(typeof(RoleEnum), r, true)).ToList();
            return dto;
        }
    }
}
