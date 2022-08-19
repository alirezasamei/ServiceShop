using App.Domain.Core.Customer.Dtos;
using App.Domain.Core.Customer.Enums;

namespace App.Domain.Core.Customer.Contracts.Services
{
    public interface IOrderService
    {
        Task<int> Add(OrderDto dto, CancellationToken cancellationToken);
        Task<int> Update(OrderDto dto, CancellationToken cancellationToken);
        Task<int> Delete(int id, CancellationToken cancellationToken);
        Task<List<OrderDto>> GetAll(CancellationToken cancellationToken);
        Task<OrderDto?> Get(int id, CancellationToken cancellationToken);
        Task<int> UpdateState(int orderId, int stateId, CancellationToken cancellationToken);
        Task<List<OrderDto>> GetByServiceId(int serviceId, CancellationToken cancellationToken);
    }
}
