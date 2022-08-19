using App.Domain.Core.BaseData.Dtos;
using Microsoft.AspNetCore.Identity;

namespace App.Domain.Core.BaseData.Contracts.Services
{
    public interface IUserService
    {
        Task<IdentityResult> Add(AppUserDetailDto dto, CancellationToken cancellationToken);
        Task<IdentityResult> Update(AppUserDetailDto dto, CancellationToken cancellationToken);
        Task<IdentityResult> Delete(int id, CancellationToken cancellationToken);
        Task<List<AppUserDto>> GetAll(CancellationToken cancellationToken);
        Task<AppUserDetailDto?> Get(int id, CancellationToken cancellationToken);
        Task<AppUserDto?> Get(string userName, CancellationToken cancellationToken);
        Task<int> ConvertUserIdToCustomerId(int id, CancellationToken cancellationToken);
        Task<int> ConvertUserIdToExpertId(int id, CancellationToken cancellationToken);
    }
}
