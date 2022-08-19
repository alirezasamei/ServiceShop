using App.Domain.Core.Service.Dtos;

namespace App.Domain.Core.Service.Contracts.Repositories
{
    public interface IServiceCommandRepository
    {
        Task<int> Add(ServiceDto dto, CancellationToken cancellationToken);
        Task<int> Update(ServiceDto dto, CancellationToken cancellationToken);
        Task<int> Delete(int id, CancellationToken cancellationToken);
    }
}
