using App.Domain.Core.Customer.Dtos;

namespace App.Domain.Core.Customer.Contracts.Repositories
{
    public interface IOrderQueryRepository
    {
        Task<List<OrderDto>> GetAll();
        Task<OrderDto?> Get(int id);
    }
}
