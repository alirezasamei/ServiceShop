using App.Domain.Core.Customer.Dtos;

namespace App.Domain.Core.Customer.Contracts.Services
{
    public interface IOrderStateService
    {
        Task<int> Add(string name);
        Task<int> Update(int id, string name);
        Task<int> Delete(int id);
        Task<List<OrderStateDto>> GetAll();
        Task<OrderStateDto?> Get(int id);
    }
}
