using App.Domain.Core.User.Dtos;

namespace App.Domain.Core.User.Contracts.Repositories
{
    public interface IOrderCommandRepository
    {
        Task<int> Add(OrderDto dto);
        Task<int> Update(OrderDto dto);
        Task<int> Delete(int id);
    }
}
