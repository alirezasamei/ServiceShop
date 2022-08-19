using App.Domain.Core.Customer.Dtos;
using App.Domain.Core.Customer.Enums;

namespace App.Domain.Core.Customer.Contracts.Repositories
{
    public interface IOrderCommandRepository
    {
        Task<int> Add(OrderDto dto, CancellationToken cancellationToken);
        Task<int> Update(OrderDto dto, CancellationToken cancellationToken);
        Task<int> UpdateState(int orderId, int stateId, CancellationToken cancellationToken);
        Task<int> Delete(int id, CancellationToken cancellationToken);
    }
}
