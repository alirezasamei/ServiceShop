using App.Domain.Core.BaseData.Dtos;
using App.Domain.Core.BaseData.Enums;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace App.Domain.Core.BaseData.Contracts.AppServices
{
    public interface IUserAppService
    {
        Task<IdentityResult> Register(AppUserDetailDto dto, CancellationToken cancellationToken);
        Task<IdentityResult> Add(AppUserDetailDto dto, IFormFile UserImage, CancellationToken cancellationToken);
        Task<IdentityResult> Update(AppUserDetailDto dto, IFormFile UserImage, CancellationToken cancellationToken);
        Task<IdentityResult> Delete(int id, CancellationToken cancellationToken);
        Task<List<AppUserDto>> GetAll(CancellationToken cancellationToken);
        Task<List<AppUserDto>> GetByRole(RoleEnum role, CancellationToken cancellationToken);
        Task<List<AppUserDto>> GetAll(string keyWord, CancellationToken cancellationToken);
        Task<AppUserDetailDto?> Get(int id, CancellationToken cancellationToken);
        Task<AppUserDto?> Get(string userName, CancellationToken cancellationToken);
        Task UpdatePicture(int id, IFormFile userImage, CancellationToken cancellationToken);
        Task<IdentityResult> Update(AppUserDetailDto dto, CancellationToken cancellationToken);
    }
}
