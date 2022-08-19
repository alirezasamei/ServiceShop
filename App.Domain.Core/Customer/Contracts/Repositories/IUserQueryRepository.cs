using App.Domain.Core.Customer.Dtos;

namespace App.Domain.Core.Customer.Contracts.Repositories
{
    public interface ICustomerQueryRepository
    {
        Task<List<CustomerDto>> GetAll(CancellationToken cancellationToken);
        Task<CustomerDto?> Get(int appUserID, CancellationToken cancellationToken);
        Task<bool> DoseExists(int appUserID, CancellationToken cancellationToken);
    }
}
