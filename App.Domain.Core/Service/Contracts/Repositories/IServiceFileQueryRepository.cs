using App.Domain.Core.Service.Dtos;

namespace App.Domain.Core.Service.Contracts.Repositories
{
    public interface IServiceFileQueryRepository
    {
        Task<List<ServiceFileDto>> GetAll();
        Task<ServiceFileDto?> Get(int id);
        Task<ServiceFileDto?> Get(string name);
    }
}
