using App.Domain.Core.Customer.Dtos;

namespace App.Domain.Core.Customer.Contracts.Repositories
{
    public interface ICustomerQueryRepository
    {
        Task<List<CustomerDto>> GetAll();
        Task<CustomerDto?> Get(int appUserID);
    }
}
