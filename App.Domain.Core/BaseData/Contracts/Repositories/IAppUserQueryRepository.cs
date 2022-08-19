using App.Domain.Core.BaseData.Dtos;

namespace App.Domain.Core.BaseData.Contracts.Repositories
{
    public interface IAppUserQueryRepository
    {
        Task<List<AppUserDto>> GetAll();
        Task<AppUserDto?> Get(int id, CancellationToken cancellationToken);
        Task<AppUserDto?> Get(string userName, CancellationToken cancellationToken);
    }
}
