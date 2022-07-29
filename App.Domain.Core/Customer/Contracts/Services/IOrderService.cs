using App.Domain.Core.Customer.Dtos;

namespace App.Domain.Core.Customer.Contracts.Services
{
    public interface IOrderService
    {
        Task<int> Add(OrderDto dto);
        Task<int> Update(OrderDto dto);
        Task<int> Delete(int id);
        Task<List<OrderDto>> GetAll();
        Task<OrderDto?> Get(int id);
    }
}
