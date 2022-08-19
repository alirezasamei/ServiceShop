using App.Domain.Core.BaseData.Dtos;
using Microsoft.AspNetCore.Identity;

namespace App.Domain.Core.BaseData.Contracts.Repositories
{
    public interface IAppUserCommandRepository
    {
        Task<IdentityResult> Add(AppUserDto dto, CancellationToken cancellationToken);
        Task<IdentityResult> Update(AppUserDetailDto dto, CancellationToken cancellationToken);
        Task<IdentityResult> Delete(int id, CancellationToken cancellationToken);
    }
}
