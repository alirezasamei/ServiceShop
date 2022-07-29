using App.Domain.Core.BaseData.Dtos;
using Microsoft.AspNetCore.Identity;

namespace App.Domain.Core.BaseData.Contracts.Repositories
{
    public interface IAppUserCommandRepository
    {
        Task<IdentityResult> Add(AppUserDto dto);
        Task<IdentityResult> Update(AppUserDetailDto dto);
        Task<IdentityResult> Delete(int id);
    }
}
