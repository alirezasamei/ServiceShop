using App.Domain.Core.Customer.Dtos;

namespace App.Domain.Core.Customer.Contracts.Repositories
{
    public interface IOrderQueryRepository
    {
        Task<List<OrderDto>> GetAll(CancellationToken cancellationToken);
        Task<OrderDto?> Get(int id, CancellationToken cancellationToken);
        Task<List<OrderDto>> GetByServiceId(int serviceId, CancellationToken cancellationToken);
    }
}
