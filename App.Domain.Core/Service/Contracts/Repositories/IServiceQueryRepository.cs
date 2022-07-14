using App.Domain.Core.Service.Dtos;

namespace App.Domain.Core.Service.Contracts.Repositories
{
    public interface IServiceQueryRepository
    {
        Task<List<ServiceDto>> GetAll();
        Task<ServiceDto?> Get(int id);
        Task<ServiceDto?> Get(string name);
    }
}
