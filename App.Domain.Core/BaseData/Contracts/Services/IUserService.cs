using App.Domain.Core.BaseData.Dtos;
using Microsoft.AspNetCore.Identity;

namespace App.Domain.Core.BaseData.Contracts.Services
{
    public interface IUserService
    {
        Task<IdentityResult> Add(AppUserDetailDto dto);
        Task<IdentityResult> Update(AppUserDetailDto dto);
        Task<IdentityResult> Delete(int id);
        Task<List<AppUserDto>> GetAll();
        Task<AppUserDetailDto?> Get(int id);
        Task<AppUserDto?> Get(string userName);
    }
}
