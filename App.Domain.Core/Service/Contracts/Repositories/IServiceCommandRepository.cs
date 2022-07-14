using App.Domain.Core.Service.Dtos;

namespace App.Domain.Core.Service.Contracts.Repositories
{
    public interface IServiceCommandRepository
    {
        Task<int> Add(ServiceDto dto);
        Task<int> Update(ServiceDto dto);
        Task<int> Delete(int id);
    }
}
