using App.Domain.Core.Customer.Dtos;
using App.Domain.Core.Customer.Enums;

namespace App.Domain.Core.Customer.Contracts.AppServices
{
    public interface IOrderAppService
    {
        Task<int> Add(OrderDto dto, CancellationToken cancellationToken);
        Task<int> Update(OrderDto dto, CancellationToken cancellationToken);
        Task<int> Delete(int id, int customerId, CancellationToken cancellationToken);
        Task<int> Delete(int id, CancellationToken cancellationToken);
        Task<List<OrderDto>> GetAll(string keyWord, CancellationToken cancellationToken);
        Task<List<OrderDto>> GetAll(CancellationToken cancellationToken);
        Task<OrderDto?> Get(int id, CancellationToken cancellationToken);
        Task<List<OrderDto>> GetByCustomerId(int id, string keyWord, CancellationToken cancellationToken);
        Task<List<OrderForExpertDto>> GetByExpertId(int id, CancellationToken cancellationToken);
        Task<int> Done(int tenderId, CancellationToken cancellationToken);
        Task<OrderDto?> Get(int id, int customerId, CancellationToken cancellationToken);
    }
}
