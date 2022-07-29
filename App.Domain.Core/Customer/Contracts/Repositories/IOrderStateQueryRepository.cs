using App.Domain.Core.Customer.Dtos;

namespace App.Domain.Core.Customer.Contracts.Repositories
{
    public interface IOrderStateQueryRepository
    {
        Task<List<OrderStateDto>> GetAll();
        Task<OrderStateDto?> Get(int id);
        Task<OrderStateDto?> Get(string name);
    }
}
