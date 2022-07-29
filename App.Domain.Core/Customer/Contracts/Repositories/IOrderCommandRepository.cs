using App.Domain.Core.Customer.Dtos;

namespace App.Domain.Core.Customer.Contracts.Repositories
{
    public interface IOrderCommandRepository
    {
        Task<int> Add(OrderDto dto);
        Task<int> Update(OrderDto dto);
        Task<int> Delete(int id);
    }
}
