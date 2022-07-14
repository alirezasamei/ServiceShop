using App.Domain.Core.Service.Dtos;

namespace App.Domain.Core.Service.Contracts.Repositories
{
    public interface IServiceFileCommandRepository
    {
        Task<int> Add(ServiceFileDto dto);
        Task<int> Update(ServiceFileDto dto);
        Task<int> Delete(int id);
    }
}
