using App.Domain.Core.Customer.Dtos;

namespace App.Domain.Core.Customer.Contracts.Repositories
{
    public interface ICustomerCommandRepository
    {
        Task<int> Add(CustomerDto dto);
        Task<int> Update(CustomerDto dto);
    }
}
