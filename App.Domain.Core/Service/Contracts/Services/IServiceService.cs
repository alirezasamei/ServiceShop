using App.Domain.Core.Service.Dtos;

namespace App.Domain.Core.Service.Contracts.Services
{
    public interface IServiceService
    {
        Task<List<ServiceDto>> GetAll(CancellationToken cancellationToken);
        Task<ServiceDto?> Get(int id, CancellationToken cancellationToken);
        Task<ServiceDto?> Get(string name, CancellationToken cancellationToken);
        Task<int> Add(ServiceDto dto, CancellationToken cancellationToken);
        Task<int> Update(ServiceDto dto, CancellationToken cancellationToken);
        Task<int> Delete(int id, CancellationToken cancellationToken);
    }
}
