using App.Domain.Core.BaseData.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace App.Domain.Core.BaseData.Contracts.AppServices
{
    public interface IUserAppService
    {
        Task<IdentityResult> Register(AppUserDetailDto dto);
        Task<IdentityResult> Add(AppUserDetailDto dto, IFormFile UserImage);
        Task<IdentityResult> Update(AppUserDetailDto dto, IFormFile UserImage);
        Task<IdentityResult> Delete(int id);
        Task<List<AppUserDto>> GetAll();
        Task<List<AppUserDto>> GetAll(string keyWord);
        Task<AppUserDetailDto?> Get(int id);
        Task<AppUserDto?> Get(string userName);
    }
}
