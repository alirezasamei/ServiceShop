using App.Domain.Core.BaseData.Contracts.Repositories;
using App.Domain.Core.BaseData.Dtos;
using App.Domain.Core.BaseData.Entities;
using Microsoft.AspNetCore.Identity;

namespace App.Infrastructure.Repos.Ef.BaseData
{
    public class AppUserCommandRepository : IAppUserCommandRepository
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole<int>> _roleManager;

        public AppUserCommandRepository(UserManager<AppUser> userManager, RoleManager<IdentityRole<int>> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }
        //public async Task Seed()
        //{
        //    foreach (var user in _userManager.Users.ToList())
        //    {
        //        await _userManager.AddPasswordAsync(user, "123");
        //    }
        //    await _roleManager.CreateAsync(new IdentityRole<int>("admin"));
        //    await _roleManager.CreateAsync(new IdentityRole<int>("expert"));
        //    await _roleManager.CreateAsync(new IdentityRole<int>("customer"));
        //    foreach (var user in _userManager.Users.ToList())
        //    {
        //        if (user.Id < 10)
        //            await _userManager.AddToRoleAsync(user, "Expert");
        //        else if (user.Id < 19)
        //            await _userManager.AddToRoleAsync(user, "Customer");
        //        else
        //            await _userManager.AddToRoleAsync(user, "Admin");
        //    }
        //}
        public async Task<IdentityResult> Add(AppUserDto dto, CancellationToken cancellationToken)
        {
            var entity = new AppUser()
            {
                Email = dto.Email,
                EmailConfirmed = dto.EmailConfirmed,
                IsActive = dto.IsActive,
                IsDeleted = false,
                Name = dto.Name,
                PhoneNumber = dto.PhoneNumber,
                PhoneNumberConfirmed = dto.PhoneNumberConfirmed,
                SubmitDate = dto.SubmitDate,
                UserName = dto.UserName,
            };

            var result = await _userManager.CreateAsync(entity, dto.Password);
            dto.Id = entity.Id;
            await _userManager.AddToRolesAsync(entity, dto.Roles.Select(r => r.ToString()));
            return result;
        }

        public async Task<IdentityResult> Delete(int id, CancellationToken cancellationToken)
        {
            var entity = await _userManager.FindByIdAsync(id.ToString());
            entity.IsDeleted = true;
            return await _userManager.UpdateAsync(entity);
        }

        public async Task<IdentityResult> Update(AppUserDetailDto dto, CancellationToken cancellationToken)
        {
            var entity = await _userManager.FindByIdAsync(dto.Id.ToString());
            var oldRoles = await _userManager.GetRolesAsync(entity);
            var newRoles = dto.Roles.Select(r => r.ToString()).ToList();

            entity.Email = dto.Email;
            entity.Name = dto.Name;
            entity.PhoneNumber = dto.PhoneNumber;
            entity.UserName = dto.UserName;
            entity.EmailConfirmed = dto.EmailConfirmed;
            entity.PhoneNumberConfirmed= dto.PhoneNumberConfirmed;

            var addedRoles = newRoles.Except(oldRoles).ToList();
            var removedRoles = oldRoles.Except(newRoles).ToList();
            await _userManager.AddToRolesAsync(entity, addedRoles);
            await _userManager.RemoveFromRolesAsync(entity, removedRoles);

            return await _userManager.UpdateAsync(entity);
        }
    }
}
