using App.Domain.Core.User.Dtos;

namespace App.Domain.Core.User.Contracts.Repositories
{
    public interface IOrderQueryRepository
    {
        Task<List<OrderDto>> GetAll();
        Task<OrderDto?> Get(int id);
    }
}
