using App.Domain.Core.User.Dtos;

namespace App.Domain.Core.User.Contracts.Repositories
{
    public interface IOrderStateQueryRepository
    {
        Task<List<OrderStateDto>> GetAll();
        Task<OrderStateDto?> Get(int id);
        Task<OrderStateDto?> Get(string name);
    }
}
