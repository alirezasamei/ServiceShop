using App.Domain.Core.Customer.Dtos;

namespace App.Domain.Core.Customer.Contracts.AppServices
{
    public interface IOrderAppService
    {
        Task<int> Add(OrderDto dto);
        Task<int> Update(OrderDto dto);
        Task<int> Delete(int id);
        Task<List<OrderDto>> GetAll(string keyWord);
        Task<OrderDto?> Get(int id);
    }
}
